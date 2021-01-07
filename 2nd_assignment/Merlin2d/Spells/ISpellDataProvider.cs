using System;
using System.Collections.Generic;

namespace Merlin2d.Spells
{
    public interface ISpellDataProvider
    {
        Dictionary<string, SpellInfo> GetSpellInfo();
        Dictionary<string, int> GetSpellEffects();
    }
}
