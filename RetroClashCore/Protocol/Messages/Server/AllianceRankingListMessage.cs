﻿using System.IO;
using System.Threading.Tasks;
using RetroClashCore.Logic;
using RetroGames.Helpers;

namespace RetroClashCore.Protocol.Messages.Server
{
    public class AllianceRankingListMessage : PiranhaMessage
    {
        public AllianceRankingListMessage(Device device) : base(device)
        {
            Id = 24401;
        }

        public override async Task Encode()
        {
            var count = 0;

            using (var buffer = new MemoryStream())
            {
                foreach (var alliance in Resources.LeaderboardCache.GlobalAlliances)
                {
                    if (alliance == null) continue;
                    await buffer.WriteLongAsync(alliance.Id);
                    await buffer.WriteStringAsync(alliance.Name);
                    await buffer.WriteIntAsync(count + 1);
                    await buffer.WriteIntAsync(alliance.Score);
                    await buffer.WriteIntAsync(200);

                    await alliance.AllianceRankingEntry(buffer);

                    if (count++ >= 199)
                        break;
                }

                await Stream.WriteIntAsync(count);
                await Stream.WriteBufferAsync(buffer.ToArray());

                await Stream.WriteIntAsync(Utils
                    .GetSecondsUntilNextMonth); // Tournament Seconds left - 7 Days -> 604800

                await Stream.WriteIntAsync(3); // Reward Count
                await Stream.WriteIntAsync(100000); // #1 Reward
                await Stream.WriteIntAsync(10000); // #2 Reward
                await Stream.WriteIntAsync(1000); // #3 Reward
            }
        }
    }
}