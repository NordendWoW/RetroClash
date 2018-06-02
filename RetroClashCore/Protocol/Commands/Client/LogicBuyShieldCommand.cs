﻿using System.Threading.Tasks;
using RetroClashCore.Helpers;
using RetroClashCore.Logic;

namespace RetroClashCore.Protocol.Commands.Client
{
    public class LogicBuyShieldCommand : LogicCommand
    {
        public LogicBuyShieldCommand(Device device, Reader reader) : base(device, reader)
        {
        }

        public int ShieldType { get; set; }

        public override void Decode()
        {
            ShieldType = Reader.ReadInt32();
            Reader.ReadInt32();
        }

        public override async Task Process()
        {
            await Task.Run(() =>
            {
                Device.Player.Shield.SetShield(ShieldType);
            });
        }
    }
}