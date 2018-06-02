﻿using Newtonsoft.Json;

namespace RetroClashCore.Logic.Replay.Items
{
    public class ReplayUnitItem
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("cnt", DefaultValueHandling = DefaultValueHandling.Include)]
        public int Cnt { get; set; }
    }
}