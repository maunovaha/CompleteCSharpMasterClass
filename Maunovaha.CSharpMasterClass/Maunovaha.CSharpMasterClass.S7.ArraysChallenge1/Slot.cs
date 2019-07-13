﻿namespace Maunovaha.CSharpMasterClass.S7.ArraysChallenge1
{
    internal class Slot
    {
        public Chip Chip { get; set; }
        private bool IsFree => Chip.IsNumber;

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

            // TODO: Check if below can work when we dont even implement IEquatable for it?
            return Chip.Equals(chip);
        }

        public override string ToString() => Chip.ToString();
    }
}
