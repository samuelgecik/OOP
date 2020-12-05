using System;
using Merlin2d.Commands;

namespace Merlin2d.Spells
{
    public interface ISpell
    {
        ISpell AddEffect(ICommand effect);
        void AddEffects(IEnumerable<ICommand> effects);
        int GetCost();
        void Cast();
    }
}
