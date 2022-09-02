using Library.Models.RiotDevPortal.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class ApiKey
    {
        public static string Get()
        {
            return Key.GetAPIKey();
        }

        public static bool Set(string key)
        {
            return Key.SetAPIKey(key);
        }

        public static async Task<bool> Verify(string key)
        {
            return await Key.Verify(key);
        }
    }
}
