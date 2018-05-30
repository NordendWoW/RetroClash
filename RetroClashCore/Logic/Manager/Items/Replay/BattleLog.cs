﻿using Newtonsoft.Json;

namespace RetroClashCore.Logic.Manager.Items.Replay
{
    public class BattleLog
    {
        [JsonProperty("loot")]
        public int[][] Loot { get; set; }

        [JsonProperty("units")]
        public int[][] Units { get; set; }

        [JsonProperty("spells")]
        public int[][] Spells { get; set; }

        [JsonProperty("levels")]
        public int[][] Levels { get; set; }

        [JsonProperty("stats")]
        public BattleLogStats Stats { get; set; }
    }
}