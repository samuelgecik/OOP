//using System;
//using System.Linq;
//using Merlin2d.Game;
//using Merlin2d.Game.Actions;
//using Merlin2d.Game.Actors;

//namespace Merlin.Commands
//{
//    public class Gravity : IPhysics
//    {
//        private IWorld world;
//        private IAction<AbstractActor> fall = new Fall<AbstractActor>(2);

//        public Gravity()
//        {
//        }

//        public void Execute()
//        {
//            world.GetActors().Where(a => a.IsAffectedByPhysics())
//                .ToList().ForEach(a => fall.Execute(a));
//        }

//        public void SetWorld(IWorld world)
//        {

//        }
//    }
//}
