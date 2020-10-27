using System;
using System.Collections.Generic;
using Merlin2d.Game;
using Merlin2d.Game.Actors;

namespace Merlin
{
    public class Crystal : AbstractActor, ISwitchable, IObserver
    {
        private Animation animationOn = new Animation("resources/crystal_on.png", 28, 32);
        private Animation animationOff = new Animation("resources/crystal_off.png", 28, 32);
        private bool crystalState = false;
        private bool hasPower = false;
        private int counter;

        public Crystal(PowerSource powerSource)
        {
            SetAnimation(animationOff);
            SetPosition(200, 250);
            animationOff.Start();
            animationOn.Start();
            if (powerSource != null)
            {
                powerSource.Subscribe(this);
                crystalState = powerSource.IsOn();
            }
        }
    

        public override void Update()
        {
            if (counter++ % 120 == 0)
            {
                Toggle();
            }

        }

        public void Toggle()
        {
            if (IsOn())
            {
                TurnOff();
            }
            else
            {
                TurnOn();
            }
        }

        public void TurnOn()
        {
            crystalState = true;
            UpdateAnimation();
        }

        public void TurnOff()
        {
            crystalState = false;
            UpdateAnimation();
        }

        private void UpdateAnimation()
        {
            if (hasPower && IsOn())
            {
                SetAnimation(animationOn);
            }
            else
            {
                SetAnimation(animationOff);
            }
        }

        public bool IsOn()
        {
            return crystalState; 
        }

        public void Notify(IObservable observable)
        {
            if (observable is PowerSource powerSource)
            {
                if (powerSource.PowerSourceState == true)
                {
                    hasPower = true;
                }
                else
                {
                    hasPower = false;
                }
            }
        }
    }
}
