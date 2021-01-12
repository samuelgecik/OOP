using System;
using System.Collections.Generic;
using Merlin2d.Actors;
using Merlin2d.Commands;

namespace Merlin2d.Spells
{
    public class SelfCastSpell : ISpell
    {
        private int cost;
        private IWizard caster;

        private List<ICommand> effects;

        public SelfCastSpell(int cost, IWizard caster,
            IEnumerable<IEffectCommand> effects)
        {
            this.cost = cost;
            this.caster = caster;
            this.effects = (List<ICommand>)effects;
        }

        public ISpell AddEffect(ICommand effect)
        {
            this.effects.Add(effect);
            return this;
        }

        public void AddEffects(IEnumerable<ICommand> effects)
        {
            List<ICommand> effectsList = (List<ICommand>)effects;
            effectsList.ForEach(e => this.effects.Add(e));
        }

        public void Cast()
        {
            if (caster is ICharacter)
            {
                effects.ForEach(e => ((ICharacter)caster).AddEffect(e));
            }
        }

        public int GetCost()
        {
            return cost;
        }
    }
}
