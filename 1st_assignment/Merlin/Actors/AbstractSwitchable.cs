using System;
using Merlin2d.Game.Actors;

namespace Merlin
{
    public abstract class AbstractSwitchable : AbstractActor, ISwitchable
    {
        protected bool isOn = false;
        public AbstractSwitchable()
        {
        }

        public override void Update()
        {
            throw new NotImplementedException();
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

        public virtual void TurnOn()
        {
            isOn = true;
            UpdateAnimation();
        }

        public virtual void TurnOff()
        {
            isOn = false;
            UpdateAnimation();
        }

        public bool IsOn()
        {
            return isOn;
        }

        protected abstract void UpdateAnimation();

    }
}
