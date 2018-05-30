﻿using System.Threading.Tasks;
using RetroClashCore.Extensions;
using RetroClashCore.Logic;

namespace RetroClashCore.Protocol.Commands.Client
{
    public class LogicBuyDecoCommand : LogicCommand
    {
        public LogicBuyDecoCommand(Device device, Reader reader) : base(device, reader)
        {
        }

        public int DecoId { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public override void Decode()
        {
            X = Reader.ReadInt32();
            Y = Reader.ReadInt32();
            DecoId = Reader.ReadInt32();
        }

        public override async Task Process()
        {
            Device.Player.LogicGameObjectManager.AddDeco(DecoId, X, Y);
        }
    }
}