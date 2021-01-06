using System;
using System.Collections.Generic;
using Merlin2d.Commands;
using Merlin2d.Strategies;

namespace Merlin2d.Actors
{
    public abstract class AbstractCharacter : AbstractActor, ICharacter
    {
        private List<ICommand> effects = new List<ICommand>();

        private int health;
        private ISpeedStrategy speedStrategy = new NormalSpeedStrategy();

        public AbstractCharacter(string name) : base(name)
        {
            
        }

        public override void Update()
        {
            effects.ForEach(e => e.Execute());
        }

        public void AddEffect(ICommand effect)
        {
            effects.Add(effect);
        }

        public void ChangeHealth(int delta)
        {
            health += delta;
        }

        public void Die()
        {
            this.RemoveFromWorld();
        }

        public int GetHealth()
        {
            return health;
        }

        public double GetSpeed(double speed)
        {
            return speedStrategy.GetSpeed(speed);
        }

        public void RemoveEffect(ICommand effect)
        {
            effects.Remove(effect);
        }

        public void SetSpeedStrategy(ISpeedStrategy strategy)
        {
            speedStrategy = strategy;
        }
    }
}
