using System;
using System.Collections.Generic;

namespace Merlin2d.Spells
{
    public class SpellDirector : ISpellDirector
    {
        Dictionary<string, SpellInfo> spells;
        Dictionary<string, int> effectCosts;

        public SpellDirector()
        {

        }

        public ISpell Build(string spellName)
        {
            ISpellBuilder builder;

            if (spells[spellName].SpellType == SpellType.Projectile)
            {
                builder = new ProjectileSpellBuilder();
            }
            else
            {
                builder = new SelfCastSpellBuilder();
            }

            // todo: solve IWizard
            return builder.CreateSpell();
        }
    }
}
