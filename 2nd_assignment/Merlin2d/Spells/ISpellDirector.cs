using System;
namespace Merlin2d.Spells
{
    public interface ISpellDirector
    {
        ISpell Build(string spellName);
    }
}
