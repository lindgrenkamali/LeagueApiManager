using Application.API;
using Library.Models.DataDragon;
using Library.Models.RiotDevPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    internal sealed class Output
    {
        internal static void PrintSummonerDTO(SummonerV4 s4)
        {
            Console.WriteLine($"AccountId: {s4.AccountId}");
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

        internal static void PrintChampionStats(DDJson json)
        {
            Console.Clear();

            foreach (var champion in json.Data.Values)
            {
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine($"Name: {champion.Name}");
                Console.WriteLine($"Hp: {champion.Stats.Hp}".PadRight(20) + $"HpPerLevel: {champion.Stats.HpPerLevel}");
                Console.WriteLine($"Mp: {champion.Stats.Mp}".PadRight(20) + $"MpPerLevel: {champion.Stats.MpPerLevel}");
                Console.WriteLine($"Armor: {champion.Stats.Armor}".PadRight(20) + $"ArmorPerLevel: {champion.Stats.ArmorPerLevel}");
                Console.WriteLine($"SpellBlock: {champion.Stats.SpellBlock}");
                Console.WriteLine($"AttackDamage: {champion.Stats.AttackDamage}".PadRight(20) + $"AttackDamagePerLevel: {champion.Stats.AttackDamagePerLevel}");
                Console.WriteLine($"AttackSpeed: {champion.Stats.AttackSpeed}".PadRight(20) + $"AttackSpeedPerLevel: {(champion.Stats.AttackSpeedPerLevel/100) * champion.Stats.AttackSpeed}");
                Console.WriteLine($"AttackRange: {champion.Stats.AttackRange}");
                Console.WriteLine($"MoveSpeed: {champion.Stats.MoveSpeed}");
                Console.WriteLine("---------------------------------------------------");

            }

            
        }

        internal static void PrintError(HttpStatusCode hsc)
        {
            Console.WriteLine($"The API request was {hsc} and therefore couldn't recieve any data");
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


        internal static void PrintChampionMasteries(List<ChampionMasteryDto> listCMD, DDJson ddj)
        {
            Console.Clear();
            foreach (var cmd in listCMD)
            {
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine($"Champion: {DataDragon.ChampionNumberToChampionName(ddj, cmd.ChampionId)}");
                Console.WriteLine($"Level: {cmd.ChampionLevel}");
                Console.WriteLine($"Points: {cmd.ChampionPoints}");
                Console.WriteLine($"TokensEarned: {cmd.TokensEarned}");
                Console.WriteLine($"PointsSinceLastLevel: {cmd.ChampionPointsSinceLastLevel}");
                Console.WriteLine($"PointsUntilNextLevel: {cmd.ChampionPointsUntilNextLevel}");
                Console.WriteLine($"ChestGranted: {(cmd.ChestGranted ? "Yes" : "No")}");
                Console.WriteLine($"LastPlayTime: {cmd.LastPlayTime}");
                Console.WriteLine("---------------------------------------------------");
            }
        }
    }
}
