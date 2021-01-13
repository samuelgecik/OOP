using System;
using System.Collections.Generic;
using Merlin2d.Commands;
using Merlin2d.Game;

namespace Merlin2d.Spells
{
    public class SelfCastSpellBuilder : ISpellBuilder
    {
        private List<IEffectCommand> effects = new List<IEffectCommand>();
        private SpellEffectFactory factory = new SpellEffectFactory();
        private ISpell selfCastSpell;
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
            selfCastSpell = new SelfCastSpell(cost, caster, effects);
            return selfCastSpell; ;
        }

        public ISpellBuilder SetAnimation(Animation animation)
        {
            throw new FormatException("Self cast spell does not have an animation.");
        }

        public ISpellBuilder SetSpellCost(int cost)
        {
            this.cost = (int)(cost * 0.7);
            return this;
        }
    }
}
