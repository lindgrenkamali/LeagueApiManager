using Application;
using Application.API;
using Library.Models.RiotDevPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    public static class Menu
    {
        private static string APIKey { get; set; }

        private static string Server { get; set; }

        private static async Task Setup()
        {
            string apiKey = ApiKey.Get();

            if (apiKey == "")
            {
                ApiKey.Set(await Input.Key());
            }

            else
            {
                APIKey = apiKey;
            }
           Server = Input.GetServer();

        }

        public async static Task Run()
        {

            await Setup();
            await Show();

        }

        public async static Task Show()
        {
            Console.WriteLine("Press 1: To see all current free champions");
            Console.WriteLine("Press 2: To see a summoners SummonerDTO");
            int intKey = Input.IntLoop(1, 2);

            switch (intKey)
            {
                case 1:
                    Output.PrintChampionRotation(await Champion_V3.GetChampionNames(APIKey, Server));
                    GoBack();
                    break;

                case 2:
                    Output.PrintSummonerDTO(await Summoner_V4.BySummonerName(Server, Input.SummonerName(), APIKey));
                    GoBack();
                    break;

                default:
                    break;
            }
        }

        public async static void GoBack()
        {
            Console.WriteLine("\nPress any key to go back");
            Console.ReadKey();
            Console.Clear();
            await Show();
        }
    }
}
