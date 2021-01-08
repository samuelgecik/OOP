using System;
namespace Merlin2d.Strategies
{
    public class SlowSpeedStrategy : ISpeedStrategy
    {
        public SlowSpeedStrategy()
        {
        }

        public double GetSpeed(double speed)
        {
            return speed * 0.5;
        }
    }
}
