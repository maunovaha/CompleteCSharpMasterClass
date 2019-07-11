using System;

namespace Maunovaha.CSharpMasterClass.S7.ArraysChallenge1
{
    internal class Gameboard
    {
        // Initially, I used two-dimensional array defined as `Slot[,] Grid` but since I want to
        // receive complete row of columns - easily - switching to jagged array was a better choice.
        public Slot[][] Grid { get; private set; }
        public int RowCount => Grid.Length;
        // This needs fixing later if we are going to have rows with different number of 
        // columns, atm. this hard-coding doesn't matter.
        public int ColumnCountPerRow => Grid[0].Length;
        public int SlotCount => RowCount * ColumnCountPerRow;
        public int FirstSlotId => 89;
        public int LastSlotId => FirstSlotId + SlotCount - 1;
        public int MaxSlotLength => LastSlotId.ToString().Length;

        private int SlotPadding => 2;
        private char SlotDivider => '|';
        private char SlotSpace => ' ';
        private char SlotLine => '_';

        public Gameboard(int rows, int columns)
        {
            SetupGrid(rows, columns);
        }

        public void Draw()
        {
            for (int row = 0; row < RowCount; row++)
            {
                DrawEmptyRow();
                DrawSlotRow(Grid[row]);
                DrawLineRow();
            }
        }

        public bool TryPlace(int slot, Chip chip)
        {
            int row = SlotToRow(slot);
            int column = SlotToColumn(slot);

            Console.WriteLine("row: " + row + " column: " + column); // slot 90 => row 9, column 8.. what?

            // return Grid[row][column].TryPlace(chip);

            return true;
        }

        public bool IsWithinGrid(int slot) => slot >= FirstSlotId && slot <= LastSlotId;

        private void SetupGrid(int rows, int columns)
        {
            Grid = new Slot[rows][];

            for (int row = 0, chip = FirstSlotId; row < RowCount; row++)
            {
                Grid[row] = new Slot[columns];

                for (int column = 0; column < columns; column++)
                {
                    Grid[row][column] = new Slot(chip++);
                }
            }
        }

        private void DrawLineRow()
        {
            DrawRow(SlotLine);
        }

        private void DrawEmptyRow()
        {
            DrawRow(SlotSpace);
        }

        private void DrawSlotRow(Slot[] row)
        {
            string slotFill = new string(SlotSpace, SlotPadding);
            string line = "";

            for (int column = 0; column < row.Length; column++)
            {
                // Ugly, will be fixed..
                string chip = row[column].Chip.ToString();
                int chipLength = chip.Length;
                string extraFill = new string(' ', MaxSlotLength - chipLength);

                line += slotFill + extraFill + row[column] + slotFill;

                if (column < row.Length - 1)
                {
                    line += SlotDivider;
                }
            }

            Console.WriteLine(line);
        }

        private void DrawRow(char fill)
        {
            string slotContent = new string(fill, MaxSlotLength);
            string slotFill = new string(fill, SlotPadding);
            string line = "";

            for (int column = 0; column < ColumnCountPerRow; column++)
            {
                line += slotFill + slotContent + slotFill;

                if (column < ColumnCountPerRow - 1)
                {
                    line += SlotDivider;
                }
            }

            Console.WriteLine(line);
        }

        private int SlotToRow(int slot) => (slot - 1) / RowCount;

        private int SlotToColumn(int slot) => (slot - 1) % ColumnCountPerRow;
    }
}
