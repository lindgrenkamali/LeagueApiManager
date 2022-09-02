using Application;
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

        }

        public async static Task Run()
        {

            await Setup();
            Console.WriteLine("Press 1: To see all current free champions");
            int intKey = Input.Loop(1, 1);

            switch(intKey)
            {
                case 1:
                    Application.API.Champion_V3.GetChampionNames(APIKey);
                    break;

                default:
                    break;
            }

        }
    }
}
