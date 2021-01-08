using System;
using System.Collections.Generic;
using Merlin2d.Game;

namespace Merlin2d.Spells
{
    public class SpellDirector : ISpellDirector
    {
        Dictionary<string, SpellInfo> spells;
        Dictionary<string, int> effectCosts;

        public SpellDirector(ISpellDataProvider provider)
        {
            spells = provider.GetSpellInfo();
            effectCosts = provider.GetSpellEffects();
        }

        public ISpell Build(string spellName)
        {
            ISpellBuilder builder;
            SpellInfo spellInfo = spells[spellName];

            if (spellInfo.SpellType == SpellType.Projectile)
            {
                builder = new ProjectileSpellBuilder();
                Animation animation = new Animation(spellInfo.AnimationPath,
                    spellInfo.AnimationWidth, spellInfo.AnimationHeight);
                builder.SetAnimation(animation);
            }
            else
            {
                builder = new SelfCastSpellBuilder();
            }

            // todo: solve IWizard
            return builder.;
        }
    }
}
