﻿using System.Threading.Tasks;
using RetroClash.Extensions;
using RetroClash.Logic;

namespace RetroClash.Protocol.Commands.Server
{
    public class LogicJoinAlliance : LogicCommand
    {
        public LogicJoinAlliance(Device device) : base(device)
        {
            Type = 1;
        }

        public long AllianceId { get; set; }
        public string AllianceName { get; set; }
        public int AllianceBadge { get; set; }
        public Enums.Role Role { get; set; }

        public override async Task Encode()
        {
            await Stream.WriteLongAsync(AllianceId);
            await Stream.WriteStringAsync(AllianceName);
            await Stream.WriteIntAsync(AllianceBadge);
            Stream.WriteByte((byte) Role);
        }
    }
}