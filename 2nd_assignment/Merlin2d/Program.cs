using System;
using Merlin2d.Game;

namespace Merlin2d
{
    class Program
    {
        Action<IWorld> setCamera = world =>
        {
           world.CenterOn(world.GetActors().Find(a => a.GetName() == "player"));
        };
    }
}
