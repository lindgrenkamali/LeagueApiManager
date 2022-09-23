using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models.DataDragon
{
    public sealed class Info
    {
        [JsonProperty("attack")]
        public decimal Attack { get; set; }

        [JsonProperty("defense")]
        public decimal Defense { get; set; }

        [JsonProperty("magic")]
        public decimal Magic { get; set; }

        [JsonProperty("difficulty")]
        public decimal Difficulty { get; set; }

    }
}