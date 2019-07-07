using System;
namespace Maunovaha.CSharpMasterClass.S7.ArraysChallenge1
{
    internal class Slot
    {
        public char Chip { get; set; }

        private bool IsFree => Chip >= '0' && Chip <= '9';

        public Slot(char chip)
        {
            Chip = chip;
        }

        public bool TryPlace(char chip)
        {
            if (IsFree)
            {
                Chip = chip;
            }

            return Chip.Equals(chip);
        }

        public override string ToString() => Chip.ToString();
    }
}
