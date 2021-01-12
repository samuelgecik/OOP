using System;
using System.Collections.Generic;
using Merlin2d.Game;

namespace Merlin2d.Spells
{
    public class SpellDirector : ISpellDirector
    {
        private IWizard caster;

        Dictionary<string, SpellInfo> spells;
        Dictionary<string, int> effectCosts;

        public SpellDirector(ISpellDataProvider provider, IWizard caster)
        {
            spells = provider.GetSpellInfo();
            effectCosts = provider.GetSpellEffects();
            this.caster = caster;
        }

        public ISpell Build(string spellName)
        {
            ISpellBuilder builder;
            SpellInfo spellInfo = spells[spellName];
            List<string> thisSpellEffects = (List<string>)spellInfo.EffectNames;
            int cost = 0;

            if (spellInfo.SpellType == SpellType.Projectile)
            {
                builder = new ProjectileSpellBuilder(spellName);
                Animation animation = new Animation(spellInfo.AnimationPath,
                    spellInfo.AnimationWidth, spellInfo.AnimationHeight);
                builder.SetAnimation(animation);
            }
            else
            {
                builder = new SelfCastSpellBuilder();
            }

            foreach (string effect in thisSpellEffects)
            {
                cost += effectCosts[effect];
                builder.AddEffect(effect);
            }
            return builder.SetSpellCost(cost).CreateSpell(caster);
        }
    }
}
