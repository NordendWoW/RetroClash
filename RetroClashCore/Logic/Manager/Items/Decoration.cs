﻿using Newtonsoft.Json;

namespace RetroClashCore.Logic.Manager.Items
{
    public class Decoration
    {
        [JsonProperty("data")]
        public int Data { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("x")]
        public int X { get; set; }

        [JsonProperty("y")]
        public int Y { get; set; }
    }
}