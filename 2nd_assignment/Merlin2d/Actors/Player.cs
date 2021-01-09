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
        private ICommand moveRight;
        private ICommand moveLeft;
        private ICommand moveUp;
        private ICommand moveDown;
        private ICommand jump;
        private ActorOrientation orientation = ActorOrientation.FacingRight;
        private ActorOrientation right = ActorOrientation.FacingRight;
        private ActorOrientation left = ActorOrientation.FacingLeft;
        private ISpeedStrategy speedStrategy = new NormalSpeedStrategy();

        public Player(string name) : base(name)
        {
            moveLeft = new Move(this, -1, 0, 1);
            moveRight = new Move(this, 1, 0, 1);
            moveUp = new Move(this, 0, -1, 1);
            moveDown = new Move(this, 0, 1, 1);
            jump = new Jump(this, 30);
            SetAnimation(animation);
        }

        public void Cast(ISpell spell)
        {
            ISpellDirector director = new SpellDirector(SpellDataProvider.GetInstance(), this);
            director.Build("fireball");
        }

        public void ChangeMana(int delta)
        {
            throw new NotImplementedException();
        }

        public int GetMana()
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
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
