using System.Linq;
using Merlin2d.Game;
using Merlin2d.Game.Actors;

namespace Merlin2d.Commands
{
    public class Gravity : IPhysics
    {
        private IWorld world;
        private IAction<IActor> fall = new Fall<IActor>(2);

        public Gravity()
        {
        }

        public void Execute()
        {
            world.GetActors().Where(a => a.IsAffectedByPhysics())
                .ToList().ForEach(a => fall.Execute(a));
        }

        public void SetWorld(IWorld world)
        {
            this.world = world;
        }
    }
}
