using System;
namespace Merlin2d.Spells
{
    public interface IWizard
    {
        void ChangeMana(int delta);
        int GetMana();
        void Cast(ISpell spell);
    }
}
