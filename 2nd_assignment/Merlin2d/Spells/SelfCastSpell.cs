using System;
using System.Collections.Generic;
using Merlin2d.Commands;

namespace Merlin2d.Spells
{
    public class SelfCastSpell : ISpell
    {
        public SelfCastSpell()
        {
        }

        public ISpell AddEffect(ICommand effect)
        {
            throw new NotImplementedException();
        }

        public void AddEffects(IEnumerable<ICommand> effects)
        {
            throw new NotImplementedException();
        }

        public void Cast()
        {
            throw new NotImplementedException();
        }

        public int GetCost()
        {
            throw new NotImplementedException();
        }
    }
}
