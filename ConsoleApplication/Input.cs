using Application;
using Application.Enum;
using Library.Models.RiotDevPortal.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    internal class Input
    {
        internal static async Task<string> Key()
        {
            Console.WriteLine("Input your API-key");

            string apiKey = "";

            bool validKey = false;

            while (validKey == false)
            {
                apiKey = Console.ReadLine();
                validKey = await ApiKey.Verify(apiKey);
            }

            return apiKey;
        }

        internal static int IntLoop(int min, int max)
        {
            int intKey = -1;

            while (intKey > max || intKey < min)
            {
                int.TryParse(Console.ReadLine(), out intKey);
            }

            return intKey;
        }

        internal static string StringLoop(int min, int max)
        {
            string inputString = "";

            while (inputString.Length < min ||inputString.Length > max)
            {
                inputString = Console.ReadLine();
            }

            return inputString;
        }

        internal static string GetServer()
        {
            var names =  Enum.GetNames(typeof(Server));
            var values = Enum.GetValues(typeof(Server));

            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine($"Enter {i} to select {names[i]}");
            }

            return ServerEnum.Get(IntLoop(0, names.Length)).ToString();
        }

        internal static string SummonerName()
        {
            Console.WriteLine("Input SummonerName(3-18)");
            string summonerName = StringLoop(3, 18);
            return summonerName.Replace(" ", "%20");
        }
    }
}
