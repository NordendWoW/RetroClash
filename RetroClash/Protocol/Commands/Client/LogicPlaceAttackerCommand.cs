﻿using System.Threading.Tasks;
using RetroClash.Extensions;
using RetroClash.Logic;

namespace RetroClash.Protocol.Commands.Client
{
    public class LogicPlaceAttackerCommand : LogicCommand
    {
        public LogicPlaceAttackerCommand(Device device, Reader reader) : base(device, reader)
        {
        }

        public int UnitId { get; set; }

        public override void Decode()
        {
            Reader.ReadInt32(); // X
            Reader.ReadInt32(); // Y

            UnitId = Reader.ReadInt32();

            Reader.ReadInt32();
        }

        public override async Task Process()
        {
            var index = Device.Player.Units.Troops.FindIndex(unit => unit.Id == UnitId);

            if (index > -1)
                Device.Player.Units.Troops[index].Count--;
        }
    }
}