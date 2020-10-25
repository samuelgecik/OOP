using System;
using System.Collections.Generic;
using Merlin2d.Game;
using Merlin2d.Game.Actors;

namespace Merlin
{
    public class Crystal : AbstractActor, ISwitchable, IObserver
    {
        private Animation crystalOn = new Animation("resources/crystal_on.png", 56, 32);
        private Animation crystalOff = new Animation("resources/crystal_off.png", 56, 32);
        private bool crystalState;

        public Crystal()
        {
            
        }
    

        public override void Update()
        {

        }

        public void Toggle()
        {
            crystalState = !crystalState;
            if (crystalState == true)
            {
                SetAnimation(crystalOn);
                crystalOn.Start();
            }
            else
            {
                SetAnimation(crystalOff);
                crystalOff.Start();
            }
        }

        public void TurnOn()
        {
            crystalState = true;
        }

        public void TurnOff()
        {
            crystalState = false;
        }

        public bool IsOn()
        {
            if (crystalState)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Notify()
        {
            throw new NotImplementedException();
        }
    }
}
