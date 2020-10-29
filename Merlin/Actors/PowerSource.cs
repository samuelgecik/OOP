using System;
using System.Collections.Generic;
using Merlin2d.Game;
using Merlin2d.Game.Actors;

namespace Merlin
{
    public class PowerSource : AbstractSwitchable, ISwitchable, IObservable
    {
        private readonly Animation animationOn = new Animation("resources/source_on.png", 64, 23);
        private readonly Animation animationOff = new Animation("resources/source_off.png", 64, 23);
        private List<IObserver> observers = new List<IObserver>();

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

        public void Subscribe(IObserver observer)
        {
            observers.Add(observer);
        }

        public void Unsubscribe(IObserver observer)
        {
            observers.Remove(observer);
        }

        public override void TurnOn()
        {
            isOn = true;
            SetAnimation(animationOn);
            foreach (Crystal crystal in observers)
            {
                crystal.Notify(this);
            }
        }

        public override void TurnOff()
        {
            isOn  = false;
            SetAnimation(animationOff);
            foreach (Crystal crystal in observers)
            {
                crystal.Notify(this);
            }
        }

        protected override void UpdateAnimation()
        {
            if (IsOn())
            {
                SetAnimation(animationOn);
            }
            else
            {
                SetAnimation(animationOff);
            }
        }
    }
}