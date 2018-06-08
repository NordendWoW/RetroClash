﻿using System.Threading.Tasks;
using RetroClashCore.Logic;
using RetroGames.Helpers;

namespace RetroClashCore.Protocol.Messages.Server
{
    public class DisconnectedMessage : PiranhaMessage
    {
        public DisconnectedMessage(Device device) : base(device)
        {
            Id = 25892;
        }

        // ErrorCodes
        // 1 = Another Device is connecting

        public override async Task Encode()
        {
            await Stream.WriteIntAsync(1);
        }
    }
}