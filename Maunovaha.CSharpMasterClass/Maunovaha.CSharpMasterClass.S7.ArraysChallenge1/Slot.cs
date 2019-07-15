using System;

namespace Maunovaha.CSharpMasterClass.S7.ArraysChallenge1
{
    internal class Slot
    {
        public Chip Chip { get; set; }
        public bool IsFree => Chip.IsNumber;

        public Slot(string chip)
        {
            Chip = new Chip(chip);
        }

        public Slot(int chip) : this(chip.ToString())
        {
        }

        public bool TryPlace(Chip chip)
        {
            if (IsFree)
            {
                Chip = chip;
            }

            // This comparison works without defining our own Equals method because
            // we do `Chip = chip;` above which means that we are comparing object instances.
            return Chip.Equals(chip);
        }

        public override string ToString() => Chip.ToString();
    }
}
