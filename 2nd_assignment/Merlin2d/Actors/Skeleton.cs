using System;
using Merlin2d.Commands;
using Merlin2d.Game;
using Merlin2d.Strategies;

namespace Merlin2d.Actors
{
    public class Skeleton : AbstractMovable
    {
        private readonly Animation animation = new Animation("resources/enemy.png", 64, 58);

        private int min;
        private int max;
        private int sight;
        private int steps;
        private Player player;

        private Func<ActorOrientation, ActorOrientation> turnBack = x =>
        {
            return x = x == ActorOrientation.FacingRight ?
            ActorOrientation.FacingLeft : ActorOrientation.FacingRight;
        };

        Random random = new Random();

        public Skeleton(string name, int step, Player player, int minRadius,
                        int maxRadius, int sightOfStevie) : base(name, step)
        {
            this.player = player;
            this.min = minRadius;
            this.max = maxRadius;
            this.sight = sightOfStevie;
            SetAnimation(animation);
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
            return (player.GetX() < this.GetX() && orientation == left)
                || (player.GetX() > this.GetX() && orientation == right);
        }
    }
}