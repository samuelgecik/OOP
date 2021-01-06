using System;
namespace Merlin2d.Strategies
{
    public class LimitedSpeedStrategy : ISpeedStrategy
    {
        public LimitedSpeedStrategy()
        {
        }

        public double GetSpeed(double speed)
        {
            return speed < 1 ? speed : 1;
        }
    }
}
