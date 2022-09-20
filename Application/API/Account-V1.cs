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
    public class Account_V1
    {
        public static async Task<Response> ByPuuid(string region, string puuid)
        {
            string url = $"https://{region}.api.riotgames.com/riot/account/v1/accounts/by-puuid/{puuid}";

            return await Response.Get(url);

        
        }

        public static async Task<Response> ByGameNameTagline(string region, string gamename, string tagline, string apiKey)
        {
            string url = $"https://{region}.api.riotgames.com/riot/account/v1/accounts/by-riot-id/" +
                $"{VariableManager.RemoveSpace(gamename)}/{tagline}?api_key={apiKey}";

            return await Response.Get(url);

            
        }

    }
}
