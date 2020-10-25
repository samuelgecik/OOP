using System;
using Merlin2d.Game;
using Merlin2d.Game.Actors;

namespace Merlin
{
    public class PowerSource : AbstractActor, ISwitchable, IObservable
    {
        private bool powerSourceState;

        public PowerSource()
        {

        }

        public override void Update()
        {
            if (Input.GetInstance().IsKeyPressed(Input.Key.E))
            {
                Toggle();
            }
        }

        public bool IsOn()
        {
            if (powerSourceState == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Subscribe(IObserver observer)
        {
            throw new NotImplementedException();
        }

        public void Unsubscribe(IObserver observer)
        {
            throw new NotImplementedException();
        }

        public void Toggle()
        {
            powerSourceState = !powerSourceState;
        }

        public void TurnOff()
        {
            powerSourceState = true;
        }

        public void TurnOn()
        {
            powerSourceState = false;
        }
    }
}
