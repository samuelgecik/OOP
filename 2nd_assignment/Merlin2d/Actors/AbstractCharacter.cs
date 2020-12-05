using System;
using Merlin2d.Commands;
using Merlin2d.Strategies;

namespace Merlin2d.Actors
{
    public class AbstractCharacter : AbstractActor, ICharacter
    {
        private double speed;
        private int health;

        public AbstractCharacter(string name) : base(name)
        {
            
        }

        public void AddEffect(ICommand effect)
        {
            throw new NotImplementedException();
        }

        public void ChangeHealth(int delta)
        {
            health += delta;
        }

        public void Die()
        {
            throw new NotImplementedException();
        }

        public int GetHealth()
        {
            return health;
        }

        public double GetSpeed(double speed)
        {
            return speed;
        }

        public void RemoveEffect(ICommand effect)
        {
            throw new NotImplementedException();
        }

        public void SetSpeedStrategy(ISpeedStrategy strategy)
        {
            throw new NotImplementedException();
        }
    }
}
