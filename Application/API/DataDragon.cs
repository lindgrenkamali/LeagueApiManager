using Library.Models.DataDragon;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Application.API
{
    public class DataDragon
    {
        private static readonly string Url = "https://ddragon.leagueoflegends.com/api/versions.json";

        public async static Task<string> GetLatestVersion()
        {

            using (HttpClient client = new HttpClient())
            {

                string response = await client.GetStringAsync(Url);

                List<string> responseList = response.Split(",").ToList();

                return responseList[0].Replace("[", "").Replace("\"", "");

            }
        }

        public async static Task<Json> GetJson()
        {
            string url = $"http://ddragon.leagueoflegends.com/cdn/{await GetLatestVersion()}/data/en_US/champion.json";

            return JsonConvert.DeserializeObject<Json>(await Response.Get(url));
        }


        public static string ChampionNumberToChampionName(Json json, int championNumber)
        {
            return json.Data.Where(x => x.Value.Key == championNumber).SingleOrDefault().Value.Name;
        }

        public static Json SortByStats(Json json, int stats, int level)
        {
            if (level == 1)
            {
                level = 0;
            }

            else
            {
                level -= 1;
            }

            if (stats == 0)
            {
               return (Json)json.Data.OrderBy(x => x.Value.Stats.Hp + (x.Value.Stats.HpPerLevel * level));
            }

            else if (stats == 1)
            {
                return (Json)json.Data.OrderBy(x => x.Value.Stats.Mp + (x.Value.Stats.MpPerLevel * level));
            }

            else if (stats == 2)
            {
                return (Json)json.Data.OrderBy(x => x.Value.Stats.Armor + (x.Value.Stats.ArmorPerLevel * level));
            }

            else if (stats == 3)
            {
                return (Json)json.Data.OrderBy(x => x.Value.Stats.SpellBlock + (x.Value.Stats.SpellBlockPerLevel * level));
            }

            else if (stats == 4)
            {
                return (Json)json.Data.OrderBy(x => x.Value.Stats.AttackDamage + (x.Value.Stats.AttackDamagePerLevel * level));
            }

            
            else if (stats == 5)
            {
                return (Json)json.Data.OrderBy(x => x.Value.Stats.AttackSpeed * (((x.Value.Stats.AttackSpeedPerLevel /100) * level) + 1));
            }

            else if (stats == 6)
            {
                return (Json)json.Data.OrderBy(x => x.Value.Stats.AttackRange);
            }


            else if (stats == 7)
            {
                return (Json)json.Data.OrderBy(x => x.Value.Stats.MoveSpeed);
            }

            else
            {
                return (Json)json.Data.OrderBy(x => x.Value.Stats.Hp + x.Value.Stats.Mp +
                x.Value.Stats.Armor + x.Value.Stats.SpellBlock +
                x.Value.Stats.AttackDamage + x.Value.Stats.AttackRange + x.Value.Stats.AttackSpeed +
                x.Value.Stats.MoveSpeed);

            }

        }
    }
}
