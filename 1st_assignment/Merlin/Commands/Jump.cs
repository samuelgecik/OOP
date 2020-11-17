using System;
using Merlin.Actors;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;

namespace Merlin.Commands
{
    public class Jump : Command
    {
        private IActor actor;
        private int jumpHeight;

        public Jump(IMovable movable, int jumpHeight)
        {
            if (movable is IActor)
            {
                actor = (IActor)movable;
                this.jumpHeight = jumpHeight;
            }
            else
            {
                throw new ArgumentException("Jump class accepts only objects of type IActor");
            }
        }

        public void Execute()
        {
            for (int i = 1; i <= jumpHeight; i++)
            {
                if (actor.GetWorld().IntersectWithWall(actor) == false)
                {
                    actor.SetPosition(actor.GetX(), actor.GetY() - 1);
                }
                else
                {
                    actor.SetPosition(actor.GetX(), actor.GetY() + 1);
                    break;
                }
            }
        }
    }
}