using System;
using Merlin2d.Strategies;

namespace Merlin2d.Actors
{
    public class AbstractMovable :  AbstractActor, IMovable
    {
        private double stepRemainder = 0;
        private ISpeedStrategy speedStrategy = new NormalSpeedStrategy();


        public AbstractMovable(string name) : base(name)
        {
        }

        public double GetStepRemainder()
        {
            return stepRemainder;
        }

        public void UpdateStepRemainder(double remainder)
        {
            stepRemainder = remainder;
        }

        public double GetSpeed(double speed)
        {
            return speedStrategy.GetSpeed(speed);
        }

        public void SetSpeedStrategy(ISpeedStrategy strategy)
        {
            speedStrategy = strategy;
        }

    }
}
