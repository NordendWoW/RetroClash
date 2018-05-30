﻿using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RetroClashCore.Helpers;
using RetroClashCore.Logic;
using RetroClashCore.Logic.Manager;
using RetroClashCore.Logic.Manager.Items.Replay;

namespace RetroClashCore.Protocol.Commands.Client
{
    public class LogicPlaceAttackerCommand : LogicCommand
    {
        public LogicPlaceAttackerCommand(Device device, Reader reader) : base(device, reader)
        {
        }

        public int UnitId { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public override void Decode()
        {
            X = Reader.ReadInt32(); // X
            Y = Reader.ReadInt32(); // Y

            UnitId = Reader.ReadInt32();

            Reader.ReadInt32();
        }

        public override async Task Process()
        {
            var index = Device.Player.Units.Troops.FindIndex(unit => unit.Id == UnitId);

            if (index > -1)
            {
                Device.Player.Units.Troops[index].Count--;

                if (Device.State == Enums.State.Battle)
                    Device.Player.Battle.RecordCommand(new ReplayCommand
                    {
                        CommandType = Type,
                        ReplayCommandInfo = new ReplayCommandInfo
                        {
                            ReplayCommandBase = GetBase(),
                            X = X,
                            Y = Y,
                            Data = UnitId
                        }
                    });
            }
        }
    }
}