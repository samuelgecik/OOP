using System;
using System.Collections.Generic;
using Merlin2d.Commands;
using Merlin2d.Game;

namespace Merlin2d.Spells
{
    public class ProjectileSpellBuilder : ISpellBuilder
    {
        private List<ICommand> effects;
        ISpell projectileSpell;

        public ProjectileSpellBuilder()
        {
        }

        public ISpellBuilder AddEffect(string effectName)
        {
            effects.Add(effectName);
        }

        public ISpell CreateSpell(IWizard caster)
        {
        }

        public ISpellBuilder SetAnimation(Animation animation)
        {
            throw new NotImplementedException();
        }

        public ISpellBuilder SetSpellCost(int cost)
        {
            throw new NotImplementedException();
        }
    }
}
