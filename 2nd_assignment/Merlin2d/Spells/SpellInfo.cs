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
    }
}
