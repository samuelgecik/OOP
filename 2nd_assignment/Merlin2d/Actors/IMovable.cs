using System;
using Merlin2d.Game.Actors;
using Merlin2d.Strategies;

namespace Merlin2d.Actors
{
    public interface IMovable : IActor
    {
        void SetSpeedStrategy(ISpeedStrategy strategy);
        double GetSpeed(double speed);
        double GetStepRemainder();
        void UpdateStepRemainder(double delta);
        ActorOrientation GetOrientation();
    }
}
