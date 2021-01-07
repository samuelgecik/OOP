using System;
using System.ComponentModel;

namespace Merlin2d.Spells
{
    public enum SpellType
    {
        [Description("selfcast")]
        Selfcast,

        [Description("projectile")]
        Projectile
    }
}
