﻿using System.IO;
using System.Threading.Tasks;
using RetroClashCore.Logic;
using RetroGames.Helpers;

namespace RetroClashCore.Protocol.Messages.Server
{
    public class AvatarRankingListMessage : PiranhaMessage
    {
        public AvatarRankingListMessage(Device device) : base(device)
        {
            Id = 24403;
        }

        public override async Task Encode()
        {
            var count = 0;

            using (var buffer = new MemoryStream())
            {
                foreach (var player in Resources.LeaderboardCache.GlobalPlayers)
                {
                    if (player == null) continue;
                    await buffer.WriteLongAsync(player.AccountId);
                    await buffer.WriteStringAsync(player.Name);

                    await buffer.WriteIntAsync(count + 1);
                    await buffer.WriteIntAsync(player.Score);
                    await buffer.WriteIntAsync(200);

                    await player.AvatarRankingEntry(buffer);

                    if (count++ >= 199)
                        break;
                }

                await Stream.WriteIntAsync(count);
                await Stream.WriteBufferAsync(buffer.ToArray());
            }
        }
    }
}