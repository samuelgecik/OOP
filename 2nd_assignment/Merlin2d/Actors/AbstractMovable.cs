using System;
using Merlin2d.Commands;
using Merlin2d.Strategies;

namespace Merlin2d.Actors
{
    public class AbstractMovable :  AbstractActor, IMovable
    {
        private double stepRemainder = 0;
        private ISpeedStrategy speedStrategy = new NormalSpeedStrategy();
        protected ICommand moveRight;
        protected ICommand moveLeft;
        protected ICommand moveUp;
        protected ICommand moveDown;
        protected ICommand currentMove;
        protected ActorOrientation orientation = ActorOrientation.FacingRight;
        protected ActorOrientation right = ActorOrientation.FacingRight;
        protected ActorOrientation left = ActorOrientation.FacingLeft;


        public AbstractMovable(string name, int step = 1) : base(name)
        {
            moveRight = new Move(this, -1, 0, step);
            moveLeft = new Move(this, 1, 0, step);
            moveUp = new Move(this, 0, -1, step);
            moveDown = new Move(this, 0, 1, step);
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

        public ActorOrientation GetOrientation()
        {
            return orientation;
        }
    }
}
