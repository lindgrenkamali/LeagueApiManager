using Newtonsoft.Json;


namespace Library.Models.RiotDevPortal.Models
{
    public sealed class ChampionMasteryDto
    {
        [JsonProperty("championPointsUntilNextLevel")]
        public long ChampionPointsUntilNextLevel { get; set; }

        [JsonProperty("chestGranted")]
        public bool ChestGranted { get; set; }

        [JsonProperty("championId")]
        public int ChampionId { get; set; }

        [JsonProperty("lastPlayTime")]
        public long LastPlayTime { get; set; }

        [JsonProperty("championLevel")]
        public int ChampionLevel { get; set; }

        [JsonProperty("summonerId")]
        public string SummonerId { get; set; }

        [JsonProperty("championPoints")]
        public int ChampionPoints { get; set; }

        [JsonProperty("championPointsSinceLastLevel")]
        public long ChampionPointsSinceLastLevel { get; set; }

        [JsonProperty("tokensEarned")]
        public int TokensEarned { get; set; }
    }
}
