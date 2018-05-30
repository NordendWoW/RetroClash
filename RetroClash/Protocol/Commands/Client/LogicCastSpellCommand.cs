﻿using System.Threading.Tasks;
using RetroClash.Extensions;
using RetroClash.Logic;
using RetroClash.Logic.Manager.Items.Replay;

namespace RetroClash.Protocol.Commands.Client
{
    public class LogicCastSpellCommand : LogicCommand
    {
        public LogicCastSpellCommand(Device device, Reader reader) : base(device, reader)
        {
        }

        public int SpellId { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public override void Decode()
        {
            X = Reader.ReadInt32(); // X
            Y = Reader.ReadInt32(); // Y

            SpellId = Reader.ReadInt32();

            Reader.ReadInt32();
        }

        public override async Task Process()
        {
            var index = Device.Player.Units.Spells.FindIndex(spell => spell.Id == SpellId);

            if (index > -1)
            {
                Device.Player.Units.Spells[index].Count--;

                if (Device.State == Enums.State.Battle)
                    Device.Player.Battle.RecordCommand(new ReplayCommand
                    {
                        CommandType = Type,
                        ReplayCommandInfo = new ReplayCommandInfo
                        {
                            ReplayCommandBase = GetBase(),
                            X = X,
                            Y = Y,
                            Data = SpellId
                        }
                    });
            }
        }
    }
}