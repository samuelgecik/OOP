using System;
using Merlin2d;
using Merlin2d.Game;
using Merlin2d.Game.Actors;

namespace Merlin
{
    public class Kettle : AbstractActor
    {
        private int temperature = 96;
        private int counter;
        private bool isSpilled = false;
        private Animation initialAnimation = new Animation("resources/kettle.png", 64, 49);
        private Animation hotAnimation = new Animation("resources/kettle_hot.png", 64, 49);
        private Animation spilledAnimation = new Animation("resources/kettle_spilled.png", 64, 49);


        public Kettle()
        {
            SetAnimation(initialAnimation); //set animation for kettle
            SetPosition(100, 100); //set position of the kettle in the game world
            initialAnimation.Start();
        }

        public override void Update()
        {
            if(isSpilled == false)
            {
                if (counter++ % 120 == 0)
                {
                    temperature -= 1;
                }

                if (temperature < 20)
                {
                    temperature = 20; //kattle temperature can't go under 20
                }

                if (temperature > 60)
                {
                    SetAnimation(hotAnimation);
                    hotAnimation.Start();
                }

                if (temperature > 100)
                {
                    temperature = 20;
                    // kettle ignores next changes
                    isSpilled = true;
                    SetAnimation(spilledAnimation);
                    spilledAnimation.Start();
                }
            }
        }

        public int GetTemperature()
        {
            return temperature;
        }

        public void IncreaseTemperature(int delta)
        {
            temperature += delta;
        }
    }
}
