using System;
using Merlin2d.Game;

namespace Merlin
{
    class Program
    {
        static void Main(string[] args)
        {
            GameContainer container = new GameContainer("window", 650, 400); //constructor, creates new instance of the game
            Kettle kettle = new Kettle();
            Stove stove = new Stove();
            PowerSource source = new PowerSource();
            Crystal crystal = new Crystal(source);

            container.SetMap("resources/maps/level01.tmx");
            container.GetWorld().AddActor(kettle);
            container.GetWorld().AddActor(stove);
            container.GetWorld().AddActor(source);
            container.GetWorld().AddActor(crystal);

            stove.AddKettle(kettle);



            container.Run(); //start the game, infinite loop, no change is accepted after this until the game ends
        }
    }
}
