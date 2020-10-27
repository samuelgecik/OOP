using System;
using Merlin2d.Game;
using Merlin2d.Game.Actors;

namespace Merlin
{
    public class Stove : AbstractActor
    {
        private readonly Animation hotStoveAnimation = new Animation("resources/stove.png", 64, 34);
        private readonly Animation coldStoveAnimation = new Animation("resources/stove_cold.png", 64, 34);
        private Kettle insertedKettle;
        private int wood;
        private int counter;

        public Stove()
        {
            SetAnimation(hotStoveAnimation);
            SetPosition(170, 170);
            hotStoveAnimation.Start();
        }

        public void AddKettle(Kettle kettle)
        {
            if (kettle != null)
            {
                insertedKettle = kettle;
            }
        }

        public override void Update()
        {
            if (wood == 0)
            {
                SetAnimation(coldStoveAnimation);
            }

            if (counter++ % 60 == 0 && wood > 0)
            {
                SetAnimation(hotStoveAnimation);
                insertedKettle.IncreaseTemperature(wood);
            }         
        }

        public void AddWood()
        {
            if (wood < 3)
            {
                wood++;
            }
        }

        public void RemoveWood()
        {
            if (wood > 0)
            {
                wood--;
            }
        }
    }
}