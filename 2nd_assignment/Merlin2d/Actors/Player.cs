using System;
using Merlin2d.Commands;
using Merlin2d.Game;
using Merlin2d.Strategies;

namespace Merlin2d.Actors
{
    public class Player : AbstractActor, IMovable
    {
        private readonly Animation animation = new Animation("resources/player.png", 64, 58);
        private ICommand moveRight;
        private ICommand moveLeft;
        private ICommand moveUp;
        private ICommand moveDown;
        private ICommand jump;
        private double speed;
        private bool facingRight = true;
        private ISpeedStrategy speedStrategy = new NormalSpeedStrategy();

        public Player(string name) : base(name)
        {
            moveLeft = new Move(this, -1, 0, 1, speed);
            moveRight = new Move(this, 1, 0, 1, speed);
            moveUp = new Move(this, 0, -1, 1, speed);
            moveDown = new Move(this, 0, 1, 1, speed);
            jump = new Jump(this, 30);
            SetAnimation(animation);
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
