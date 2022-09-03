using Library.Models.RiotDevPortal.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.API
{
    public class Summoner_V4
    {

        public async static Task<SummonerV4> BySummonerName(string server, string summonerName, string key)
        {
            string url = $"https://{server}.api.riotgames.com/lol/summoner/v4/summoners/by-name/{summonerName}?api_key={key}";

            string summonerInfo = await Response.Get(url);

            if (summonerInfo != "")
            {
                return JsonConvert.DeserializeObject<SummonerV4>(summonerInfo);
            }

            else
            {
                return null;
            }
        }
    }
}
