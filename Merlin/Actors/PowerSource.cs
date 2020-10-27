using System;
using System.Collections.Generic;
using Merlin2d.Game;
using Merlin2d.Game.Actors;

namespace Merlin
{
    public class PowerSource : AbstractActor, ISwitchable, IObservable
    {
        private readonly Animation animationOn = new Animation("resources/source_on.png", 64, 23);
        private readonly Animation animationOff = new Animation("resources/source_off.png", 64, 23);
        private bool powerSourceState;
        private List<IObserver> observers = new List<IObserver>();

        public bool PowerSourceState
        {
            get
            {
                return powerSourceState;
            }
            private set
            {
                powerSourceState = value;
            }
        }

        public PowerSource()
        {
            SetAnimation(animationOff);
            SetPosition(200, 200);
            animationOff.Start();
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
            PowerSourceState = true;
            SetAnimation(animationOn);
            foreach (Crystal crystal in observers)
            {
                crystal.Notify(this);
            }
        }

        public void TurnOff()
        {
            PowerSourceState = false;
            SetAnimation(animationOff);
            foreach (Crystal crystal in observers)
            {
                crystal.Notify(this);
            }
        }
    }
}