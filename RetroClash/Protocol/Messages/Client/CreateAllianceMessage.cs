﻿using System.Threading.Tasks;
using RetroClash.Extensions;
using RetroClash.Logic;
using RetroClash.Protocol.Messages.Server;

namespace RetroClash.Protocol.Messages.Client
{
    public class CreateAllianceMessage : PiranhaMessage
    {
        public CreateAllianceMessage(Device device, Reader reader) : base(device, reader)
        {
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public int Badge { get; set; }
        public int Type { get; set; }
        public int RequiredScore { get; set; }

        public override void Decode()
        {
            Name = Reader.ReadString();
            Description = Reader.ReadString();
            Badge = Reader.ReadInt32();
            Type = Reader.ReadInt32();
            RequiredScore = Reader.ReadInt32();
        }

        public override async Task Process()
        {
            /*var alliance = await MySQL.CreateAlliance();

            if (alliance != null)
            {
                alliance.Name = Name;
                alliance.Description = Description;
                alliance.Badge = Badge;
                alliance.Type = Type;
                alliance.RequiredScore = RequiredScore;

                alliance.Members.Add(
                    new AllianceMember(Device.Player.AccountId, Enums.Role.Leader, Device.Player.Score));

                await Resources.Gateway.Send(new AvailableServerCommandMessage(Device)
                {
                    Command = await new LogicJoinAlliance(Device)
                    {
                        AllianceId = alliance.Id,
                        AllianceName = Name,
                        AllianceBadge = Badge,
                        Role = Enums.Role.Leader
                    }.Handle()
                });

                Device.Player.AllianceId = alliance.Id;

                await MySQL.SaveAlliance(alliance);
            }
            else
            {*/
            await Resources.Gateway.Send(new AllianceCreateFailedMessage(Device));
            //}
        }
    }
}