﻿using System.Threading.Tasks;
using RetroClash.Extensions;
using RetroClash.Logic;

namespace RetroClash.Protocol.Messages.Server
{
    public class GoogleServiceAccountBoundMessage : PiranhaMessage
    {
        public GoogleServiceAccountBoundMessage(Device device) : base(device)
        {
            Id = 24261;
        }

        public override async Task Encode()
        {
            await Stream.WriteIntAsync(1);
        }
    }
}