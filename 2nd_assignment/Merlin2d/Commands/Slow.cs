using System;
using Merlin2d.Actors;
using Merlin2d.Strategies;

namespace Merlin2d.Commands
{
    public class Slow : ICommand
    {
        IMovable movable;

        public Slow(IMovable movable)
        {
            this.movable = movable;
        }

        public void Execute()
        {
            movable.SetSpeedStrategy(new SlowSpeedStrategy());
        }
    }
}
