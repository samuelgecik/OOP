using System;
using System.Collections.Generic;
using Merlin2d.Game;
using Merlin2d.Game.Actors;

namespace Merlin
{
    public class Crystal : AbstractSwitchable, ISwitchable, IObserver
    {
        private Animation animationOn = new Animation("resources/crystal_on.png", 28, 32);
        private Animation animationOff = new Animation("resources/crystal_off.png", 28, 32);
        private bool hasPower = false;
        private int counter;

        public Crystal(PowerSource powerSource)
        {
            SetAnimation(animationOff);
            animationOff.Start();
            animationOn.Start();
            if (powerSource != null)
            {
                powerSource.Subscribe(this);
                hasPower = powerSource.IsOn();
            }
        }
    

        public override void Update()
        {
            if (counter++ % 120 == 0 && hasPower)
            {
                Toggle();
            }

        }

        protected override void UpdateAnimation()
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

        public void Notify(IObservable observable)
        {
            if (observable is PowerSource powerSource)
            {
                if (powerSource.IsOn() == true)
                {
                    hasPower = true;
                }
                else
                {
                    hasPower = false;
                    TurnOff();
                }
            }
        }
    }
}
