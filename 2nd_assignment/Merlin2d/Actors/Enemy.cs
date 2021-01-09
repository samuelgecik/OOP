using System;
using Merlin2d.Commands;
using Merlin2d.Game;
using Merlin2d.Strategies;

namespace Merlin2d.Actors
{
    public class Enemy : AbstractMovable
    {
        private readonly Animation animation = new Animation("resources/enemy.png", 64, 58);

        private int min;
        private int max;
        private int sight;
        private int steps;
        private bool facingRight = true;

        private Move currentMove;
        private Move moveRight;
        private Move moveLeft;
        private Player player;
        private ActorOrientation orientation = ActorOrientation.FacingRight;
        private ActorOrientation right = ActorOrientation.FacingRight;
        private ActorOrientation left = ActorOrientation.FacingLeft;
        private Func<ActorOrientation, ActorOrientation> turnBack = x =>
        {
            return x = x == ActorOrientation.FacingRight ?
            ActorOrientation.FacingLeft : ActorOrientation.FacingRight;
        };

        Random random = new Random();

        public Enemy(string name, Player player, int minRadius,
                        int maxRadius, int sightOfStevie) : base(name)
        {
            this.player = player;
            this.min = minRadius;
            this.max = maxRadius;
            this.sight = sightOfStevie;
            SetAnimation(animation);
            moveRight = new Move(this, 1, 0, 1);
            moveLeft = new Move(this, -1, 0, 1);
        }

        public override void Update()
        {
            if (steps-- <= 0 && !PlayerInThePlainSight())
            {
                steps = random.Next(min, max);
                animation.FlipAnimation();
                animation.Start();
                orientation = turnBack(orientation);
            }

            if (orientation == right)
            {
                currentMove = moveRight;
            }
            else
            {
                currentMove = moveLeft;
            }

            currentMove.Execute();
        }

        private bool PlayerInThePlainSight()
        {
            return FacingPlayer()
                           && Math.Abs(player.GetX() - this.GetX()) <= sight;
        }

        private bool FacingPlayer()
        {
            return (player.GetX() < this.GetX() && !facingRight)
                || (player.GetX() > this.GetX() && facingRight);
        }
    }
}