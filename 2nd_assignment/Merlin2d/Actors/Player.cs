using System;
using Merlin2d.Commands;
using Merlin2d.Game;
using Merlin2d.Spells;
using Merlin2d.Strategies;

namespace Merlin2d.Actors
{
    public class Player : AbstractCharacter, IWizard
    {
        private readonly Animation animation = new Animation("resources/player.png", 64, 58);
        private ICommand jump;
        private ISpeedStrategy speedStrategy = new NormalSpeedStrategy();

        public Player(string name, int step) : base(name, step)
        { 
            jump = new Jump(this, 30);
            SetAnimation(animation);
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

        public override void Update()
        {
            if (Input.GetInstance().IsKeyDown(Input.Key.ONE))
            {
                Cast("fireball");
            }

            if (Input.GetInstance().IsKeyDown(Input.Key.LEFT))
            {
                if (orientation == right)
                {
                    animation.FlipAnimation();
                    orientation = left;
                }
                moveLeft.Execute();
                animation.Start();
            }
            else if (Input.GetInstance().IsKeyDown(Input.Key.RIGHT))
            {
                if (orientation == left)
                {
                    animation.FlipAnimation();
                    orientation = right;
                }
                moveRight.Execute();
                animation.Start();
            }
            else if (Input.GetInstance().IsKeyDown(Input.Key.UP))
            {
                moveUp.Execute();
                animation.Start();
            }
            else if (Input.GetInstance().IsKeyDown(Input.Key.DOWN))
            {
                moveDown.Execute();
                animation.Start();
            }
            else if (Input.GetInstance().IsKeyPressed(Input.Key.SPACE))
            {
                jump.Execute();
            }
            else
            {
                animation.Stop();
            }
        }
    }
}
