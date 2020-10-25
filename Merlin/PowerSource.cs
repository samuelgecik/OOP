using System;
using System.Collections.Generic;
using Merlin2d.Game;
using Merlin2d.Game.Actors;

namespace Merlin
{
    public class PowerSource : AbstractActor, ISwitchable, IObservable
    {
        private Animation sourceOn = new Animation("resources/source_on.png", 56, 32);
        private Animation sourceOff = new Animation("resources/source_off.png", 56, 32);
        private bool powerSourceState;
        private List<IObserver> observers = new List<IObserver>();

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
            observers.Add(observer);
        }

        public void Unsubscribe(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void Toggle()
        {
            powerSourceState = !powerSourceState;
            if (powerSourceState == true)
            {
                SetAnimation(sourceOn);
                sourceOn.Start();
            }
            else
            {
                SetAnimation(sourceOff);
                sourceOff.Start();
            }
        }

        public void TurnOff()
        {
            powerSourceState = true;
            foreach(Crystal crystal in observers)
            {
                crystal.Notify();
            }
        }

        public void TurnOn()
        {
            powerSourceState = false;
            foreach (Crystal crystal in observers)
            {
                crystal.Notify();
            }
        }
    }
}
