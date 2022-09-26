using Library.Models.DataDragon;
using Library.Models.RiotDevPortal.API;
using Library.Models.RiotDevPortal.Models;
using Newtonsoft.Json;


namespace Application.API
{
    public sealed class Champion_V3
    {
        public static async Task<Response> GetChampionRotation(string key, string server)
        {
            string url = $"https://{server}.api.riotgames.com/lol/platform/v3/champion-rotations?api_key={key}";

            return await Response.Get(url);
        }

        public static async Task<Converted> GetChampionNames(string key, string server)
        {
            Normal championNumbers = JsonConvert.DeserializeObject<Normal>((await GetChampionRotation(key, server)).Content);
            var response = await DataDragon.GetJson();
            DDJson json = JsonConvert.DeserializeObject<DDJson>(response.Content.ToString());

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
