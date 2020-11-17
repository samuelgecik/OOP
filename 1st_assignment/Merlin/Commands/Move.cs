using System;
using Merlin.Actors;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;

namespace Merlin.Commands
{
    public class Move : Command
    {
        private IActor actor;
        private int dx;
        private int dy;

        public Move(IMovable movable, int dx, int dy)
        {
            if (movable is IActor)
            {
                actor = (IActor)movable;
                this.dx = dx;
                this.dy = dy;
            }
            else
            {
                throw new ArgumentException("Move class accepts only objects of type IActor");
            }
        }

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