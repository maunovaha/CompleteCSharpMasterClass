using System;

namespace Maunovaha.CSharpMasterClass.S7.ArraysChallenge1
{
    internal class Gameboard
    {
        private Slot[,] Grid { get; } = {
            { new Slot('1'), new Slot('2'), new Slot('3') },
            { new Slot('4'), new Slot('5'), new Slot('6') },
            { new Slot('7'), new Slot('8'), new Slot('9') }
        };

        public void Draw()
        {
            DrawEmptyRow();
            DrawChipRow(Grid[0, 0], Grid[0, 1], Grid[0, 2]);
            DrawLineRow();

            DrawEmptyRow();
            DrawChipRow(Grid[1, 0], Grid[1, 1], Grid[1, 2]);
            DrawLineRow();

            DrawEmptyRow();
            DrawChipRow(Grid[2, 0], Grid[2, 1], Grid[2, 2]);
            DrawEmptyRow();
        }

        public bool TryPlace(int slot, char chip)
        {
            // TODO: Validate chip.. 0 - 9, or X or O (?)
            // So it is bassed here based on direct user input?

            int row = SlotToRow(slot);
            int column = SlotToColumn(slot);

            return Grid[row, column].TryPlace(chip);
        }

        private void DrawChipRow(Slot a, Slot b, Slot c)
        {
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", a, b, c);
        }

        private void DrawLineRow()
        {
            Console.WriteLine("__{0}__|__{0}__|__{0}__", '_');
        }

        private void DrawEmptyRow()
        {
            Console.WriteLine("  {0}  |  {0}  |  {0}  ", ' ');
        }

        private int SlotToRow(int slot)
        {
            // slot = 1; row = 0;
            // slot = 2; row = 0;
            // slot = 3; row = 0;
            //
            // slot = 4; row = 1;
            // slot = 5; row = 1;
            // slot = 6; row = 1;
            //
            // slot = 7; row = 2;
            // slot = 8; row = 2;
            // slot = 9; row = 2;

            return 0;
        }

        private int SlotToColumn(int slot)
        {
            return 0;
        }
    }
}
