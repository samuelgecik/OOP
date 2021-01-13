using System;
using Merlin2d.Actors.State;
using Merlin2d.Commands;
using Merlin2d.Game;
using Merlin2d.Spells;
using Merlin2d.Strategies;

namespace Merlin2d.Actors
{
    public class Player : AbstractCharacter, IWizard
    {
        private ISpeedStrategy speedStrategy = new NormalSpeedStrategy();
        private IPlayerState state;

        public Player(string name, int step) : base(name, step)
        { 
            state = new LivingState(this);
        }

        public void Cast(string spellName)
        {
            ISpellDirector director = new SpellDirector(SpellDataProvider.GetInstance(), this);
            ISpell spell = director.Build(spellName);
            spell.Cast();
        }

        public void ChangeMana(int delta)
        {
            mana = mana + delta >= 0 ? mana + delta : 0;
        }

        public int GetMana()
        {
            return mana;
        }

        public override void Die()
        {
            state = new DyingState(this);
        }

        public override void Update()
        {
            state.Update();
        }
    }
}
