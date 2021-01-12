using System;
using System.Collections.Generic;
using Merlin2d.Actors;
using Merlin2d.Commands;
using Merlin2d.Game;
using Merlin2d.Game.Actors;

namespace Merlin2d.Spells
{
    public class ProjectileSpell : AbstractMovable, ISpell
    {
        private int cost;
        private IWizard caster;
        Animation animation;

        private List<ICommand> effects;

        public ProjectileSpell(string name, int cost, Animation animation,
            IWizard caster, IEnumerable<ICommand> effects) : base(name)
        {
            this.cost = cost;
            this.caster = caster;
            this.animation = animation;
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
            SetAnimation(animation);

            if (caster is IMovable)
            {
                if (((IMovable)caster).GetOrientation().Equals(right))
                {
                    animation.Start();
                    currentMove = moveRight;
                }
                else
                {
                    animation.FlipAnimation();
                    animation.Start();
                    currentMove = moveLeft;
                }
            }
        }

        public int GetCost()
        {
            return cost;
        }

        public override void Update()
        {
            currentMove.Execute();

            if (this.GetWorld().GetActors()
                .Exists(a => this.IntersectsWithActor(a) && a != this.caster && a is ICharacter))
            {
                ICharacter hit = (ICharacter)this.GetWorld().GetActors()
                    .Find(a => this.IntersectsWithActor(a) && a != this && a is ICharacter);
                effects.ForEach(e => hit.AddEffect(e));
                animation.Stop();
                this.RemoveFromWorld();
            }

            if (this.GetWorld().IntersectWithWall(this))
            {
                animation.Stop();
                this.RemoveFromWorld();
            }
        }
    }
}
