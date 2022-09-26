using Application;
using Application.API;
using Library.Models.DataDragon;
using Library.Models.RiotDevPortal.API;
using Library.Models.RiotDevPortal.Models;
using Newtonsoft.Json;


namespace ConsoleApplication
{
    public static class Menu
    {
        private static string APIKey { get; set; }

        private static string Server { get; set; }

        private static DDJson DataDragonJson { get; set; }

        private static async Task Setup()
        {
            Response response = await DataDragon.GetJson();
            DataDragonJson = JsonConvert.DeserializeObject<DDJson>(response.Content);

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
            while(true)
            {

            
            Console.Clear();
            Console.WriteLine("Press 1: To see all current free champions");
            Console.WriteLine("Press 2: To get SummonerDTO(accountid, profileiconid, revisiondate, name, id, puuid and summonerlevel)");
            Console.WriteLine("Press 3: To get stats for champions");
            Console.WriteLine("Press 4: To get AccountDto(puuid, gamename and tagline)");
            Console.WriteLine("Press 5: To list ChampionMasteryDtos");

            int intKey = Input.IntLoop(1, 5);
            Response r = new();

            switch (intKey)
            {
                case 1:
                    Output.PrintChampionRotation(await Champion_V3.GetChampionNames(APIKey, Server));
                    GoBack();
                    break;

                case 2:
                     r = await Summoner_V4.BySummonerName(Server, Input.SummonerName(), APIKey);

                    if(r.Success)
                    {
                        Output.PrintSummonerDTO(JsonConvert.DeserializeObject<SummonerV4>(r.Content));
                    }
                    else
                    {
                        Output.PrintError(r.StatusCode);
                    }
                    
                    GoBack();
                    break;

                case 3:
                    Output.PrintChampionStats(DataDragonJson);
                    GoBack();
                    Console.SetCursorPosition(0, 0);
                    break;

                case 4:
                    r = await Account_V1.ByGameNameTagline(Input.GetRegion(), Input.SummonerName(), Input.TagLine(), APIKey);

                    if (r.Success)
                    {
                        Output.PrintAccountDto(JsonConvert.DeserializeObject<AccountDto>(r.Content));
                    }
                    else
                    {
                        Output.PrintError(r.StatusCode);
                    }
                    
                    GoBack();
                    break;

                    case 5:
                    r = await Champion_Mastery_V4.ByEncryptedSummonerId(Server, Input.EncryptedSummonerId(), APIKey);

                    if(r.Success)
                    {
                        Output.PrintChampionMasteries(JsonConvert.DeserializeObject<List<ChampionMasteryDto>>(r.Content), DataDragonJson);
                    }

                    else
                    {
                        Output.PrintError(r.StatusCode);
                    }
                    GoBack();
                    break;
                default:
                    break;
            }
            }
        }

        public async static void GoBack()
        {
            Console.WriteLine("\nPress any key to go back");
            Console.ReadKey();
        }

       
    }
}
