using System;
using Merlin2d.Commands;
using Merlin2d.Game;

namespace Merlin2d.Actors.State
{
    public class LivingState : AbstractCharacter, IPlayerState
    {
        private readonly Animation animation = new Animation("resources/player.png", 64, 58);
        private Player player;
        private ICommand jump;

        // Neistost implementácie keďže movy su v AM a posuvam do nich objekt
        public LivingState(Player player) : base(player.GetName(),1)
        {
            this.player = player;
            jump = new Jump(player, 30);
        }

        public override Animation GetAnimation()
        {
            return animation;
        }

        public override void Update()
        {
            if (Input.GetInstance().IsKeyDown(Input.Key.ONE))
            {
                player.Cast("fireball");
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
