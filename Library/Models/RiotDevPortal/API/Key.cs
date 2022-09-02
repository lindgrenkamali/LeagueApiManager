using Library.Models.RiotDevPortal.FileManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models.RiotDevPortal.API
{
    public static class Key
    {
        public static string GetAPIKey()
        {
            if(File.Exists("key"))
            {
                return Encryption.Decrypt("key");
            }

            else
            {
                return "";
            }
        }

        public static bool SetAPIKey(string key)
        {
            return Encryption.Encrypt(key, "key");
        }

        public async static Task<bool> Verify(string key)
        {
            string url = "https://euw1.api.riotgames.com/lol/platform/v3/champion-rotations?api_key=";

            string urlKey = url + key;

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(urlKey))
                {
                    if (res.IsSuccessStatusCode)
                    {
                        return true;
                    }

                    else
                    {
                        return false;
                    }
                }
            }
        }
    }
}
