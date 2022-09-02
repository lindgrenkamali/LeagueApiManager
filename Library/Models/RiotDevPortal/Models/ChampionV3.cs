using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models.RiotDevPortal.Models
{
    public struct ChampionV3
    {
        [JsonProperty("maxNewPlayerLevel")]
        public int MaxNewPlayerLevel { get; set; }

        [JsonProperty("freeChampionIdsForNewPlayers")]
        public List<int> FreeChampionIdsForNewPlayers { get; set; }

        [JsonProperty("freeChampionIds")]

        public List<int> FreeChampionIds { get; set; }
    }
}
