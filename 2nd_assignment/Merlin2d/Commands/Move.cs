using System;
using Merlin2d.Actors;
using Merlin2d.Game.Actors;

namespace Merlin2d.Commands
{
    public class Move : ICommand
    {
        private IMovable actor;
        private int dx;
        private int dy;
        private double step;
        private double speed;
        private double remainder = 0;


        public Move(IMovable movable, int dx, int dy, int step)
        {
            if (movable is IMovable)
            {
                actor = movable;
                this.dx = dx;
                this.dy = dy;
                this.step = step;
            }
            else
            {
                throw new ArgumentException("Move class accepts only objects of type IMovable");
            }
        }
        
        public void Execute()
        {
            remainder = actor.GetStepRemainder();
            // possible fixme where speed can be adjusted from IMovable via the observer pattern
            speed = actor.GetSpeed(step);
            remainder += speed - (int)speed;
            if (remainder >= 1)
            {
                speed++;
                actor.UpdateStepRemainder(--remainder);
            }
            actor.SetPosition(actor.GetX() + dx + (int)speed, actor.GetY() + dy + (int)speed);

            while (actor.GetWorld().IntersectWithWall(actor))
            {
                if (dx != 0 && dy == 0)
                {
                    actor.SetPosition(actor.GetX() - (dx / Math.Abs(dx)), actor.GetY());
                }
                else if (dx == 0 && dy != 0)
                {
                    actor.SetPosition(actor.GetX(), actor.GetY() - (dy / Math.Abs(dy)));
                }
            }
        }
    }
}