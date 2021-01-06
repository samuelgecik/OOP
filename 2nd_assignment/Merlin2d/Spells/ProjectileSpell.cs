using System;
using System.Collections.Generic;
using Merlin2d.Actors;
using Merlin2d.Commands;
using Merlin2d.Game.Actors;
using Merlin2d.Strategies;

namespace Merlin2d.Spells
{
    public class ProjectileSpell : AbstractActor, IMovable, ISpell
    {
        private int cost;
        private IActor caster;
        private ISpeedStrategy speedStrategy = new NormalSpeedStrategy();


        private List<ICommand> effects;

        public ProjectileSpell(string name, int cost,
            IActor caster, IEnumerable<ICommand> effects) : base(name)
        {
            this.cost = cost;
            this.caster = caster;
            this.effects = (List<ICommand>)effects;
        }

        public ISpell AddEffect(ICommand effect)
        {
            this.effects.Add(effect);
            return this;
        }

        public void AddEffects(IEnumerable<ICommand> effects)
        {
            List<ICommand> effectsList = (List<ICommand>)effects;
            effectsList.ForEach(e => this.effects.Add(e));
        }

        public void Cast()
        {
            throw new NotImplementedException();
        }

        public int GetCost()
        {
            return cost;
        }

        public double GetSpeed(double speed)
        {
            return speedStrategy.GetSpeed(speed);
        }

        public void SetSpeedStrategy(ISpeedStrategy strategy)
        {
            speedStrategy = strategy;
        }

        public override void Update()
        {
            if (this.GetWorld().GetActors().Exists(a => this.IntersectsWithActor(a)))
            {
                // todo: affect the object by spell effects
            };
        }
    }
}
