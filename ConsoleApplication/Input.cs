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
            int intKey = 0;

            while (intKey > max || intKey < min)
            {
                var input = Console.ReadLine();
                int.TryParse(input, out intKey);
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

        internal static string GetRegion()
        {
            var regions = Enum.GetNames(typeof(Region));

            for (int i = 0; i < regions.Length; i++)
            {
                Console.WriteLine($"Enter {i+1} to select {regions[i]}");
            }

            return RegionEnum.Get(IntLoop(1, regions.Length)).ToString();
        }

        internal static string GetServer()
        {
            Console.Clear();

            var servers =  Enum.GetNames(typeof(Server));

            for (int i = 0; i < servers.Length; i++)
            {
                Console.WriteLine($"Enter {i + 1} to select {servers[i]}");
            }

            return ServerEnum.Get(IntLoop(1, servers.Length)).ToString();
        }

        internal static string SummonerName()
        {
            Console.WriteLine("Input SummonerName(3-18)");
            string summonerName = StringLoop(3, 18);
            return VariableManager.RemoveSpace(summonerName);
        }

        internal static string EncryptedSummonerId()
        {
            Console.WriteLine("Input EncryptedSummonerId");
            string encryptedsummonerid = StringLoop(40, 63);
            return encryptedsummonerid;
        }

        internal static string TagLine()
        {
            Console.WriteLine("Input TagLine(3 letters)");
            string tagLine = StringLoop(3, 3);
            return tagLine.ToLower();
        }
       
    }
}
