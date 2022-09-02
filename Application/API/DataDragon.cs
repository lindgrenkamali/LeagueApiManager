using Library.Models.DataDragon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async static Task<Json> GetJson(string version)
        {
            string url = $"http://ddragon.leagueoflegends.com/cdn/{version}/data/en_US/champion.json";

            return 
        }


    }
}
