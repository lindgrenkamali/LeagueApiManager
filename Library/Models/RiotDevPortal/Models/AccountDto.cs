using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models.RiotDevPortal.Models
{
    public class AccountDto
    {
        [JsonProperty("puuid")]
        public string PUUID { get; set; }

        [JsonProperty("gameName")]
        public string GameName { get; set; }

        [JsonProperty("tagLine")]
        public string TagLine { get; set; }
    }
}
