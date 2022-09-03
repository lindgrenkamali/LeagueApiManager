using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models.RiotDevPortal.Models
{
    public class SummonerV4
    {
        [JsonProperty("accountId")]
        public string AccountId { get; set; }

        [JsonProperty("profileIconId")]
        public int ProfileIconId { get; set; }

        [JsonProperty("revisionDate")]
        public long RevisionDate { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("puuid")]
        public string PUUID { get; set; }

        [JsonProperty("summonerLevel")]
        public long SummonerLevel { get; set; } 
    }
}
