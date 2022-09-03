using Library.Models.DataDragon;
using Library.Models.RiotDevPortal.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.API
{
    public class Champion_V3
    {
        public static async Task<Normal> GetChampionRotation(string key, string server)
        {
            string url = $"https://{server}.api.riotgames.com/lol/platform/v3/champion-rotations?api_key={key}";

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(url))
                {
                    if (res.IsSuccessStatusCode)
                    {
                        using (HttpContent content = res.Content)
                        {
                            return JsonConvert.DeserializeObject<Normal>(await content.ReadAsStringAsync());

                        }
                    }

                    else
                    {
                        return new Normal();
                    }

                }
            }
        }

        public static async Task<Converted> GetChampionNames(string key, string server)
        {
            Normal championNumbers = await GetChampionRotation(key, server);
            Json json = await DataDragon.GetJson();
            

            Converted championNames = new Converted();

            championNames.MaxNewPlayerLevel = championNumbers.MaxNewPlayerLevel;

            foreach (var number in championNumbers.FreeChampionIdsForNewPlayers)
            {
                championNames.FreeChampionIdsForNewPlayers.Add(DataDragon.ChampionNumberToChampionName(json, number));
            }

            foreach (var number in championNumbers.FreeChampionIds)
            {
                championNames.FreeChampionIds.Add(DataDragon.ChampionNumberToChampionName(json, number));
            }

            return championNames;

        }
    }
}
