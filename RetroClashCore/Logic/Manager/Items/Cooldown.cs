﻿using Newtonsoft.Json;

namespace RetroClashCore.Logic.Manager.Items
{
    public class Cooldown
    {
        [JsonProperty("cooldown")]
        public int CooldownSeconds { get; set; }

        [JsonProperty("target")]
        public int Target { get; set; }
    }
}