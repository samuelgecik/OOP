using System;
using Merlin2d.Game;

namespace Merlin2d.Actors.State
{
    public interface IPlayerState
    {
        void Update();
        Animation GetAnimation();
    }
}
