using Library.Models.RiotDevPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    internal class Output
    {
        internal static void PrintSummonerDTO(SummonerV4 s4)
        {
            Console.WriteLine($"AccounId: {s4.AccountId}");
            Console.WriteLine($"ProfileIconId: {s4.ProfileIconId}");
            Console.WriteLine($"RevisionDate: {s4.RevisionDate}");
            Console.WriteLine($"Name: {s4.Name}");
            Console.WriteLine($"Id: {s4.Id}");
            Console.WriteLine($"PUUID: {s4.PUUID}");
            Console.WriteLine($"SummonerLevel {s4.SummonerLevel}");

        }

        internal static void PrintChampionRotation(Converted converted)
        {
            Console.Clear();
            Console.WriteLine($"Here are all the current free champions for all the players above level {converted.MaxNewPlayerLevel}:\n");

            foreach (var champion in converted.FreeChampionIds)
            {
                Console.WriteLine(champion);
            }

            Console.WriteLine($"\n\nHere all the current free champions for all the players level {converted.MaxNewPlayerLevel} and below:\n");

            foreach (var champion in converted.FreeChampionIdsForNewPlayers)
            {
                Console.WriteLine(champion);
            }
        }
    }
}
