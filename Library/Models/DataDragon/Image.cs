using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models.DataDragon
{
    public class Image
    {
        [JsonProperty("full")]
        public string Full { get; set; }

        [JsonProperty("sprite")]
        public string Sprite { get; set; }

        [JsonProperty("group")]
        public string Group { get; set; }

        [JsonProperty("x")]
        public ushort X { get; set; }

        [JsonProperty("y")]
        public ushort Y { get; set; }

        [JsonProperty("w")]
        public ushort W { get; set; }

        [JsonProperty("h")]
        public ushort H { get; set; }

    }
}