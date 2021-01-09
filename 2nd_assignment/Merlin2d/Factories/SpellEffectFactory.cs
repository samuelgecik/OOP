using System;
using Merlin2d.Commands;
using Merlin2d.Game;
using Merlin2d.Game.Actors;

namespace Merlin2d.Spells
{
    public class SpellEffectFactory
    {
        public IEffectCommand Create(string effectName)
        {
            switch (effectName.ToLower())
            {
                case "slow":
                    EffectSlow slow = new EffectSlow();
                    return slow;

                case "fast":
                    EffectFast fast = new EffectFast();
                    return fast;

                default:
                    return null;
            }
        }
    }
}
