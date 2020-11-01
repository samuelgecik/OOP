using System;
using Merlin2d;
using Merlin2d.Game;
using Merlin2d.Game.Actors;

namespace Merlin
{
    public class Kettle : AbstractActor
    {
        private readonly Animation initialAnimation = new Animation("resources/kettle.png", 64, 49);
        private readonly Animation hotAnimation = new Animation("resources/kettle_hot.png", 64, 49);
        private readonly Animation spilledAnimation = new Animation("resources/kettle_spilled.png", 64, 49);
        private int temperature;
        private bool isSpilled = false;
        private int counter;

        public Kettle()
        {
            SetAnimation(initialAnimation);
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
                    temperature = 20; // kettle temperature can't go under 20
                }

                if (temperature > 60)
                {
                    SetAnimation(hotAnimation);
                    hotAnimation.Start();
                }

                if (temperature > 100)
                {
                    temperature = 20;
                    isSpilled = true; // kettle ignores next changes
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
