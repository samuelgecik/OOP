using System;
using Merlin2d.Game;
using Merlin2d.Game.Actors;

namespace Merlin
{
    public class Stove : AbstractActor
    {
        private Kettle insertedKettle;
        private int counter;
        private int wood = 3;
        private Animation stoveAnimation = new Animation("resources/stove.png", 64, 34);
        private Animation coldStoveAnimation = new Animation("resources/stove_cold.png", 64, 34);


        public Stove()
        {
            SetAnimation(stoveAnimation);
            SetPosition(170, 170);
            stoveAnimation.Start();
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
                coldStoveAnimation.Start();
            }

            //if (counter++ % 120 == 0) // just to check functionality
            //{
            //    this.AddWood();
            //}

            if (counter++ % 60 == 0 && wood > 0)
            {
                insertedKettle.IncreaseTemperature(1);
            }         
        }

        public void AddWood()
        {
            if (wood < 3)
            {
                this.wood++;
            }
        }

        public void RemoveWood()
        {
            if (wood > 0)
            {
                this.wood--;
            }
        }
    }
}