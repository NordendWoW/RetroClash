﻿using Newtonsoft.Json;

namespace RetroClash.Logic.Manager.Items.Replay
{
    public class ReplayCommandInfo
    {
        [JsonProperty("base")]
        public ReplayCommandBase ReplayCommandBase { get; set; }

        [JsonProperty("d")]
        public int Data { get; set; }

        [JsonProperty("x")]
        public int X { get; set; }

        [JsonProperty("y")]
        public int Y { get; set; }
    }
}