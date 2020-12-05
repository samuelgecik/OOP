using System;
using Merlin2d.Strategies;

namespace Merlin2d.Actors
{
    public interface IMovable
    {
        void SetSpeedStrategy(ISpeedStrategy strategy);
        double GetSpeed(double speed);
    }
}
