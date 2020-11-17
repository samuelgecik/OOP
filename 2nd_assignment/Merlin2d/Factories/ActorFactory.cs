using System;
using Merlin2d.Actors;
using Merlin2d.Game;
using Merlin2d.Game.Actors;

namespace Merlin2d.Factories
{
    public class ActorFactory : IFactory
    {
        public IActor Create(string actorType, string actorName, int x, int y)
        {
            switch (actorType)
            {
                case "Player":
                    Player player = new Player(actorName);
                    player.SetPosition(x, y);
                    return player;

                default:
                    return null;
            }
        }
    }
}
