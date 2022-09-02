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
        public static async Task<List<int>> GetChampionNumbers(string key)
        {
            string url = $"https://euw1.api.riotgames.com/lol/platform/v3/champion-rotations?api_key={key}";

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(url))
                {
                    if (res.IsSuccessStatusCode)
                    {
                        using (HttpContent content = res.Content)
                        {
                            return JsonConvert.DeserializeObject<List<int>>(await content.ReadAsStringAsync());

                        }
                    }

                    else
                    {
                        return new List<int>();
                    }

                }
            }
        }

        public static async Task<List<string>> GetChampionNames(string key)
        {
            var championNumbers = GetChampionNumbers(key);
            

        }
    }
}
