﻿using System;
using Merlin.Commands;
using Merlin2d;
using Merlin2d.Game;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;

namespace Merlin.Actors
{
    public class Player : AbstractActor, IMovable
    {
        private readonly Animation animation = new Animation("resources/player.png", 64, 58);

        private Command moveLeft;
        private Command moveRight;
        private Command jump;
        private bool facingRight = true;

        public Player()
        {
            moveLeft = new Move(this, -1, 0);
            moveRight = new Move(this, 1, 0);
            jump = new Jump(this, 20);
            SetAnimation(animation);
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
