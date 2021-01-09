using System;
using System.Collections.Generic;
using Merlin2d.Commands;
using Merlin2d.Game;

namespace Merlin2d.Spells
{
    public class SelfCastSpellBuilder : ISpellBuilder
    {
        private List<IEffectCommand> effects;
        private ISpell projectileSpell;
        private SpellEffectFactory factory = new SpellEffectFactory();
        private int cost;

        public ISpellBuilder AddEffect(string effectName)
        {
            IEffectCommand effect = factory.Create(effectName);
            if (effect == null)
            {
                throw new FormatException("Couldn't find specified effect in my database.");
            }
            effects.Add(effect);
            return this;
        }

        public ISpell CreateSpell(IWizard caster)
        {
            throw new NotImplementedException();
        }

        public ISpellBuilder SetAnimation(Animation animation)
        {
            throw new NotImplementedException();
        }

        public ISpellBuilder SetSpellCost(int cost)
        {
            this.cost = cost;
            return this;
        }
    }
}
