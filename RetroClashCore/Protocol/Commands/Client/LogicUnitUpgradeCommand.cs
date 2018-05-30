﻿using System.Threading.Tasks;
using RetroClashCore.Extensions;
using RetroClashCore.Logic;

namespace RetroClashCore.Protocol.Commands.Client
{
    public class LogicUnitUpgradeCommand : LogicCommand
    {
        public LogicUnitUpgradeCommand(Device device, Reader reader) : base(device, reader)
        {
        }

        public int UnitId { get; set; }
        public int IsSpell { get; set; }
        public int Count { get; set; }

        public override void Decode()
        {
            Reader.ReadInt32();

            IsSpell = Reader.ReadInt32();
            UnitId = Reader.ReadInt32();

            Reader.ReadInt32();
        }

        public override async Task Process()
        {
            Device.Player.Units.Upgrade(UnitId, IsSpell);
        }
    }
}