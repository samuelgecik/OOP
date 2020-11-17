using System;
using Merlin2d.Game;
using Merlin2d.Game.Actors;

namespace Merlin2d.Actors
{
    public class Enemy : AbstractActor
    {
        private readonly Animation animation = new Animation("resources/enemy.png", 64, 58);

        private int min;
        private int max;
        private int sight;
        private int x;
        private int counter;

        private bool facingRight = true;

        private Player player;

        Random random = new Random();

        public int Min { get => min; private set => min = value; }
        public int Max { get => max; private set => max = value; }
        public int Sight { get => sight; private set => sight = value; }

        public Enemy(Player player, int minRadius, int maxRadius, int sightOfStevie)
        {
            this.player = player;
            this.Min = minRadius;
            this.Max = maxRadius;
            this.Sight = sightOfStevie;
            SetAnimation(animation);
        }

        public override void Update()
        {

            x = random.Next(min, max);

            for(int i = 1; i <= x; i++)
            {
                if (facingRight)
                {
                    animation.Start();
                    this.SetPosition(this.GetX() + 1, this.GetY());
                    while (PlayerInThePlainSight())
                    {
                        this.SetPosition(this.GetX() + 1, this.GetY());
                    }
                }
                else
                {
                    animation.FlipAnimation();
                    animation.Start();
                    this.SetPosition(this.GetX() - 1, this.GetY());
                    while (PlayerInThePlainSight())
                    {
                        this.SetPosition(this.GetX() - 1, this.GetY());
                    }
                }
            }
            facingRight = !facingRight;
        }

        private bool PlayerInThePlainSight()
        {
            return FacingPlayer()
                           && Math.Abs(player.GetX() - this.GetX()) <= Sight;
        }

        private bool FacingPlayer()
        {
            return (player.GetX() < this.GetX() && !facingRight)
                || (player.GetX() > this.GetX() && facingRight);
        }
    }
}