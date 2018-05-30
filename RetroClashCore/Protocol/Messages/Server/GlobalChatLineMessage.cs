﻿using System.Threading.Tasks;
using RetroClashCore.Helpers;
using RetroClashCore.Logic;

namespace RetroClashCore.Protocol.Messages.Server
{
    public class GlobalChatLineMessage : PiranhaMessage
    {
        public GlobalChatLineMessage(Device device) : base(device)
        {
            Id = 24715;
        }

        public string Message { get; set; }
        public string Name { get; set; }

        public int ExpLevel { get; set; }
        public int League { get; set; }

        public long AccountId { get; set; }

        public override async Task Encode()
        {
            await Stream.WriteStringAsync(Message); // Message
            await Stream.WriteStringAsync(Name); // Name

            await Stream.WriteIntAsync(ExpLevel); // ExpLevel
            await Stream.WriteIntAsync(League); // League

            await Stream.WriteLongAsync(AccountId); // AccountId
            await Stream.WriteLongAsync(AccountId); // HomeId

            Stream.WriteByte(0); // IsInClan
        }
    }
}