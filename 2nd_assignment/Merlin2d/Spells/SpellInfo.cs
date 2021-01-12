using System;
using System.Collections.Generic;

namespace Merlin2d.Spells
{
    public class SpellInfo
    { 
        public string Name { get; set; }
        public SpellType SpellType { get; set; }
        public IEnumerable<string> EffectNames { get; set; }
        public string AnimationPath { get; set; }
        public int AnimationWidth { get; set; }
        public int AnimationHeight { get; set; }
        
        public static implicit operator SpellInfo(string line)
        {
            string[] values = line.Split(";");
            string[] effects = values[5].Split(",");

            SpellInfo info = new SpellInfo
            {
                Name = values[0].ToLower(),
                AnimationPath = values[2],
                AnimationWidth = int.Parse(values[3]),
                AnimationHeight = int.Parse(values[4]),
                EffectNames = effects,
            };

            if (values[1].ToLower().Equals("projectile"))
            {
                info.SpellType = SpellType.Projectile;
                if (values[2] == "none")
                {
                    throw new FormatException("The projectile spell must have animation path declared");
                }
            }
            else if (values[1].ToLower().Equals("selfcast"))
            {
                info.SpellType = SpellType.Selfcast;
            }
            else
            {
                throw new FormatException("Inserted value does not match any spell type");
            }

            return info;
        }
    }
}
