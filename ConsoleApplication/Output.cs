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
        internal static void PrintChampionRotation(Converted converted)
        {
            Console.WriteLine($"Here are all the current free champions for all the players above level{converted.MaxNewPlayerLevel}:\n");

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
