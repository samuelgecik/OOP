using System;
using Merlin2d.Game;
using Merlin2d.Game.Actors;

namespace Merlin2d.Spells
{
    public class SpellEffectFactory : IFactory
    {
        public SpellEffectFactory()
        {
        }

        public IActor Create(string actorType, string actorName, int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
