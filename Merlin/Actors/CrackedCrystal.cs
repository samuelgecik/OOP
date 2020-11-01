using System;
namespace Merlin
{
    public class CrackedCrystal : Crystal
    {
        private int remainingUses;

        public CrackedCrystal(PowerSource source) : this(source, 3)
        {

        }

        public CrackedCrystal(PowerSource source, int remaingUses) : base(source)
        {
            remainingUses = remaingUses;
        }

        public override void TurnOn()
        {
            if (remainingUses-- > 0)
            {
                base.TurnOn();
            }
        }
    }
}
