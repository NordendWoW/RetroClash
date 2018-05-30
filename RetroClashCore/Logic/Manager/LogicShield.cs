﻿using System;
using Newtonsoft.Json;
using RetroClashCore.Files;
using RetroClashCore.Files.Logic;

namespace RetroClashCore.Logic.Manager
{
    public class LogicShield
    {
        [JsonProperty("shield_duration")]
        public int ShieldDuration { get; set; }

        [JsonProperty("shield_end_time")]
        public DateTime EndTime { get; set; }

        [JsonIgnore]
        public bool IsShieldActive => EndTime >= DateTime.Now;

        [JsonIgnore]
        public int ShieldSecondsLeft => (int) (EndTime - DateTime.Now).TotalSeconds;

        public void SetShield(int type)
        {
            if (!IsShieldActive)
            {
                ShieldDuration = ((Shields) Csv.Tables.Get(Enums.Gamefile.Shields).GetDataWithId(type)).TimeH;
                EndTime = DateTime.Now.AddHours(ShieldDuration);
            }
            else
            {
                var shieldDuration = ((Shields) Csv.Tables.Get(Enums.Gamefile.Shields).GetDataWithId(type)).TimeH;
                ShieldDuration += shieldDuration;
                EndTime = EndTime.AddHours(shieldDuration);
            }
        }

        public void RemoveShield()
        {
            ShieldDuration = 0;
            EndTime = DateTime.Now;
        }
    }
}