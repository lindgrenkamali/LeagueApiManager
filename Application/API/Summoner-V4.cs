using Library.Models.RiotDevPortal.API;
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

        public async static Task<Response> BySummonerName(string server, string summonerName, string key)
        {
            string url = $"https://{server}.api.riotgames.com/lol/summoner/v4/summoners/by-name/{summonerName}?api_key={key}";

            return await Response.Get(url);

        }
    }
}
