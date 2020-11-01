using System;
using Merlin.Actors;
using Merlin2d.Game;

namespace Merlin
{
    class Program
    {
        static void Main(string[] args)
        {
            GameContainer container = new GameContainer("window", 650, 400); //constructor, creates new instance of the game

            Kettle kettle = new Kettle();
            container.GetWorld().AddActor(kettle);
            kettle.SetPosition(100, 100);

            Stove stove = new Stove();
            container.GetWorld().AddActor(stove);
            stove.SetPosition(170, 170);
            stove.AddKettle(kettle);

            PowerSource source = new PowerSource();
            container.GetWorld().AddActor(source);
            source.SetPosition(200, 200);

            Crystal crystal = new Crystal(source);
            container.GetWorld().AddActor(crystal);
            crystal.SetPosition(200, 250);

            CrackedCrystal crackedCrystal = new CrackedCrystal(source, 3);
            container.GetWorld().AddActor(crackedCrystal);
            crackedCrystal.SetPosition(200, 350);

            Player player = new Player();
            container.GetWorld().AddActor(player);
            player.SetPhysics(true);
            player.SetPosition(120, 100);


            container.SetMap("resources/maps/map01.tmx");

            stove.AddKettle(kettle);



            container.Run(); //start the game, infinite loop, no change is accepted after this until the game ends
        }
    }
}
