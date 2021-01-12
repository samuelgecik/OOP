using System;
using System.Collections.Generic;
using Merlin2d.Commands;
using Merlin2d.Strategies;

namespace Merlin2d.Actors
{
    public abstract class AbstractCharacter : AbstractMovable, ICharacter
    {
        private List<ICommand> effects = new List<ICommand>();

        protected int health;
        protected int mana;

        public AbstractCharacter(string name, int step) : base(name, step)
        {
            
        }

        public override void Update()
        {
            // todo: affect the object by spell effects

            effects.ForEach(delegate(ICommand e)
            { e.Execute();
              this.RemoveEffect(e);
            });
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


        public void RemoveEffect(ICommand effect)
        {
            effects.Remove(effect);
        }
    }
}
