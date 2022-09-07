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
        public static async Task<AccountDto> ByPuuid(string region, string puuid)
        {
            string url = $"https://{region}.api.riotgames.com/riot/account/v1/accounts/by-puuid/{puuid}";

            string res = await Response.Get(url);

            if (res == "")
            {
                return new AccountDto();
            }

            else
            {
                return JsonConvert.DeserializeObject<AccountDto>(res);
            }
        }

        public static async Task<AccountDto> ByGameNameTagline(string region, string gamename, string tagline, string apiKey)
        {
            string url = $"https://{region}.api.riotgames.com/riot/account/v1/accounts/by-riot-id/" +
                $"{VariableManager.RemoveSpace(gamename)}/{tagline}?api_key={apiKey}";

            string res = await Response.Get(url);

            if (res == "")
            {
                return new AccountDto();
            }

            else
            {
                return JsonConvert.DeserializeObject<AccountDto>(res);
            }
        }

    }
}
