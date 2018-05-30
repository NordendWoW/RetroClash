﻿using System.Threading.Tasks;
using RetroClashCore.Extensions;
using RetroClashCore.Logic;

namespace RetroClashCore.Protocol.Messages.Server
{
    public class AvatarProfileMessage : PiranhaMessage
    {
        public AvatarProfileMessage(Device device) : base(device)
        {
            Id = 24334;
        }

        public long UserId { get; set; }

        public override async Task Encode()
        {
            if (UserId == Device.Player.AccountId)
            {
                await Device.Player.LogicClientAvatar(Stream);

                await Stream.WriteIntAsync(0); // Troops Donated
                await Stream.WriteIntAsync(0); // Troops Received               
            }
            else
            {
                await (await Resources.PlayerCache.GetPlayer(UserId)).LogicClientAvatar(Stream);

                await Stream.WriteIntAsync(0); // Troops Donated
                await Stream.WriteIntAsync(0); // Troops Received
            }
        }
    }
}