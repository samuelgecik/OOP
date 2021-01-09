using System;
using Merlin2d.Actors;
using Merlin2d.Game.Actors;

namespace Merlin2d.Commands
{
    public interface IEffectCommand
    {
        void Execute(IMovable movable);
    }
}
