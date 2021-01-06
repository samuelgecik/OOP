using System;
using Merlin2d.Actors;
using Merlin2d.Game.Actors;

namespace Merlin2d.Commands
{
    public class Move : ICommand
    {
        private IActor actor;
        private int dx;
        private int dy;
        private int step;
        private double speed;
        

        public Move(IMovable movable, int dx, int dy, int step)
        {
            if (movable is IMovable)
            {
                actor = (IActor)movable;
                this.dx = dx;
                this.dy = dy;
                this.step = step;
                this.speed = movable.GetSpeed(step);
            }
            else
            {
                throw new ArgumentException("Move class accepts only objects of type ICharacter");
            }
        }

        // todo: remain manipulation and speed control

        public void Execute()
        {
            actor.SetPosition(actor.GetX() + dx, actor.GetY() + dy);
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