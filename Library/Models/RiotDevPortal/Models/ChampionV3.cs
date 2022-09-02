using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models.RiotDevPortal.Models
{
    public struct Normal
    {
        [JsonProperty("maxNewPlayerLevel")]
        public int MaxNewPlayerLevel { get; set; }

        [JsonProperty("freeChampionIdsForNewPlayers")]
        public List<int> FreeChampionIdsForNewPlayers { get; set; }

        [JsonProperty("freeChampionIds")]

        public List<int> FreeChampionIds { get; set; }
    }

    public struct Converted
    {
        public Converted()
        {
            MaxNewPlayerLevel = 0;
            FreeChampionIdsForNewPlayers = new List<string>();
            FreeChampionIds = new List<string>();
        }

        public int MaxNewPlayerLevel { get; set; }


        public List<string> FreeChampionIdsForNewPlayers { get; set; }


        public List<string> FreeChampionIds { get; set; }
    }
}
