using Application;
using Application.API;
using Library.Models.DataDragon;
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

        private static Json DataDragonJson { get; set; }

        private static async Task Setup()
        {
            DataDragonJson = await DataDragon.GetJson();

            string apiKey = ApiKey.Get();

            bool apiKeyValid = await ApiKey.Verify(apiKey);

            if (apiKey == "" || apiKeyValid == false)
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
            Console.Clear();
            Console.WriteLine("Press 1: To see all current free champions");
            Console.WriteLine("Press 2: To see a summoners SummonerDTO");
            Console.WriteLine("Press 3: To get highest stats for a champion");
            Console.WriteLine("Press 4: To get AccountDto");
            int intKey = Input.IntLoop(1, 4);

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

                case 3:
                    Output.PrintChampionStats(DataDragonJson);
                    GoBack();
                    Console.SetCursorPosition(0, 0);
                    break;

                case 4:
                    Output.PrintAccountDto(await Account_V1.ByGameNameTagline(Input.GetRegion(), Input.SummonerName(), Input.TagLine(), APIKey));
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
