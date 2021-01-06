using System;
namespace Merlin2d.Strategies
{
    public class ModifiedSpeedStrategy : ISpeedStrategy
    {
        private double speedMultiplier;

        public ModifiedSpeedStrategy(double speedMultiplier)
        {
            this.speedMultiplier = speedMultiplier;
        }

        public double GetSpeed(double speed)
        {
            return speed * speedMultiplier;
        }
    }

}
