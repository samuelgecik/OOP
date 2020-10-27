using System;
namespace Merlin
{
    public interface ISwitchable
    {
        void Toggle();
        void TurnOn();
        void TurnOff();
        bool IsOn();
    }
}
