using System;
using System.Collections.Generic;
using Merlin2d.Commands;
using Merlin2d.Game;
using Merlin2d.Game.Actors;

namespace Merlin2d.Spells
{
    public class ProjectileSpellBuilder : ISpellBuilder
    {
        private List<IEffectCommand> effects = new List<IEffectCommand>();
        private ISpell projectileSpell;
        private SpellEffectFactory factory = new SpellEffectFactory();
        private Animation animation;
        private int cost;
        private string name;

        public ProjectileSpellBuilder(string name)
        {
            this.name = name;
        }

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
            projectileSpell = new ProjectileSpell(name, cost, animation, caster, (IEnumerable<ICommand>)effects);
            return projectileSpell;
        }

        public ISpellBuilder SetAnimation(Animation animation)
        {
            this.animation = animation;
            return this;
        }

        public ISpellBuilder SetSpellCost(int cost)
        {
            this.cost = cost;
            return this;
        }
    }
}
