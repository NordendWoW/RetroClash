﻿using System.Collections.Generic;
using Newtonsoft.Json;
using RetroClashCore.Logic.Manager;
using RetroClashCore.Logic.Replay.Items;

namespace RetroClashCore.Logic.Replay
{
    public class LogicReplay
    {
        [JsonProperty("level")]
        public LogicGameObjectManager Level { get; set; }

        [JsonProperty("timestamp")]
        public int Timestamp { get; set; }

        [JsonProperty("end_tick")]
        public int EndTick { get; set; }

        [JsonProperty("attacker")]
        public ReplayProfile Attacker { get; set; }

        [JsonProperty("defender")]
        public ReplayProfile Defender { get; set; }

        [JsonProperty("cmd")]
        public List<ReplayCommand> Commands = new List<ReplayCommand>();
    }
}