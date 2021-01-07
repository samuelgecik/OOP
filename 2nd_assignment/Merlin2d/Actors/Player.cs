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
            throw new NotImplementedException();
        }

        public void ChangeMana(int delta)
        {
            throw new NotImplementedException();
        }

        public int GetMana()
        {
            throw new NotImplementedException();
        }

        public double GetSpeed(double speed)
        {
            throw new NotImplementedException();
        }

        public void SetSpeedStrategy(ISpeedStrategy strategy)
        {
            speedStrategy = strategy;
        }

        public override void Update()
        {
            if (Input.GetInstance().IsKeyDown(Input.Key.LEFT))
            {
                if (facingRight)
                {
                    animation.FlipAnimation();
                    facingRight = false;
                }
                moveLeft.Execute();
                animation.Start();
            }
            else if (Input.GetInstance().IsKeyDown(Input.Key.RIGHT))
            {
                if (!facingRight)
                {
                    animation.FlipAnimation();
                    facingRight = true;
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
