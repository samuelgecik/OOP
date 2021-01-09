using System;
using Merlin2d.Actors;
using Merlin2d.Strategies;

namespace Merlin2d.Commands
{
    public class EffectSlow : IEffectCommand
    {
        public void Execute(IMovable movable)
        {
            movable.SetSpeedStrategy(new ModifiedSpeedStrategy(0.5));
        }
    }
}
