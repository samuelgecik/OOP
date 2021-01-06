using System;
using Merlin2d.Game;

namespace Merlin2d.Spells
{
    public class SelfCastSpellBuilder : ISpellBuilder
    {
        public SelfCastSpellBuilder()
        {
        }

        public ISpellBuilder AddEffect(string effectName)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
