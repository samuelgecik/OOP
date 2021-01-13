using System;
using Merlin2d.Game;

namespace Merlin2d.Actors.State
{
    public class DyingState : IPlayerState
    {
        private Animation animation;
        private Player player;

        public DyingState(Player player)
        {
            this.player = player;
        }

        public Animation GetAnimation()
        {
            return animation;
        }

        public void Update()
        {
            player.SetAnimation(animation);

            Message msg = new Message("You have died. Game Over", player.GetX(),
                player.GetY() + 20, fontSize: 12, new Color(0, 0, 0),
                messageDuration: Game.Enums.MessageDuration.Long);
            player.GetWorld().AddMessage(msg);

            player.RemoveFromWorld();
        }
    }
}
