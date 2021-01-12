using System;
using Merlin2d.Actors;
using Merlin2d.Commands;
using Merlin2d.Game;

namespace Merlin2d
{
    class Program
    {
        static void Main(string[] args)
        {
            GameContainer container = new GameContainer("window", 650, 400); //constructor, creates new instance of the game
            Gravity gravity = new Gravity();
            container.GetWorld().SetPhysics(gravity);

            Player player = new Player("player", 1);
            container.GetWorld().AddActor(player);
            player.SetPhysics(true);
            player.SetPosition(220, 100);

            Skeleton enemy = new Skeleton("skelton", 1, player, 5, 20, 20);
            container.GetWorld().AddActor(enemy);
            enemy.SetPhysics(true);
            enemy.SetPosition(300, 100);

            container.SetMap("resources/maps/map01.tmx");

            Action<IWorld> setCamera = world =>
            {
               world.CenterOn(world.GetActors().Find(a => a.GetName() == "player"));
            };

            container.Run(); //start the game, infinite loop, no change is accepted after this until the game ends
        }
    }
}
