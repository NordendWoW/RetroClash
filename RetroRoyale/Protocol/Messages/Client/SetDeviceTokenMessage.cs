﻿using RetroGames.Helpers;
using RetroRoyale.Logic;

namespace RetroRoyale.Protocol.Messages.Client
{
    public class SetDeviceTokenMessage : PiranhaMessage
    {
        public SetDeviceTokenMessage(Device device, Reader reader) : base(device, reader)
        {
        }

        public override void Decode()
        {
            Reader.ReadString();
        }
    }
}