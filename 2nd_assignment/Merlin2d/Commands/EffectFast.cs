using System;
using Merlin2d.Actors;
using Merlin2d.Strategies;

namespace Merlin2d.Commands
{
    public class EffectFast : IEffectCommand
    {
        public void Execute(IMovable movable = null)
        {
            movable.SetSpeedStrategy(new ModifiedSpeedStrategy(2));
        }
    }
}
