using Library.Models.DataDragon;
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

        internal static void PrintChampionStats(Json json)
        {
            Console.Clear();

            foreach (var champion in json.Data.Values)
            {
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine($"Name: {champion.Name}");
                Console.WriteLine($"HP: {champion.Stats.Hp}");
                Console.WriteLine($"MP: {champion.Stats.Mp}");
                Console.WriteLine($"Armor: {champion.Stats.Armor}");
                Console.WriteLine($"SpellBlock: {champion.Stats.SpellBlock}");
                Console.WriteLine($"AttackDamage: {champion.Stats.AttackDamage}");
                Console.WriteLine($"AttackSpeed: {champion.Stats.AttackSpeed}");
                Console.WriteLine($"AttackRange: {champion.Stats.AttackRange}");
                Console.WriteLine($"MoveSpeed: {champion.Stats.MoveSpeed}");
                Console.WriteLine("---------------------------------------------------");

            }

            
        }

        internal static void PrintAccountDto(AccountDto ad)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine($"PUUID: {ad.PUUID}");
            Console.WriteLine($"GameName: {ad.GameName}");
            Console.WriteLine($"TagLine: {ad.TagLine}");
            Console.WriteLine("---------------------------------------------------");

        }
    }
}
