using System;
using Merlin2d.Game.Actors;

namespace Merlin.Commands
{
    public class Fall<T> : IAction<T> where T : IActor
    {
        private int speed;
        public Fall(int speed)
        {
            this.speed = speed;
        }

        public void Execute(T t)
        {
            if (t.GetWorld().IntersectWithWall(t) == false)
            {
                t.SetPosition(t.GetX(), t.GetY() + speed);
            }
        }
    }
}
