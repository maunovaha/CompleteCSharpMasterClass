using System;
using System.Linq;

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
        public int FirstSlotId => 1;
        public int LastSlotId => FirstSlotId + SlotCount - 1;
        public int MaxSlotLength => LastSlotId.ToString().Length;
        public int MaxSlotLengthWithPadding => MaxSlotLength + SlotPadding * 2;
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
            DrawGrid();
        }

        public bool TryPlace(int slot, Chip chip)
        {
            (int row, int column) = SlotToRowAndColumn(slot);
            bool reservedSlot = row == -1 && column == -1;

            if (reservedSlot)
            {
                return false;
            }
            return Grid[row][column].TryPlace(chip);
        }

        public string Get(int row, int column) => Grid[row][column].Chip.Value;

        // public string GetValue(int row, int column)
        // {
        //     try
        //     {
        //         return Grid[row][column].Chip.Value;
        //     }
        //     catch (IndexOutOfRangeException)
        //     {
        //         return "";
        //     }
        // }

        public bool IsWithinGrid(int slot) => slot >= FirstSlotId && slot <= LastSlotId;

        public bool IsFull()
        {
            for (int row = 0; row < RowCount; row++)
            {
                for (int column = 0; column < Grid[row].Length; column++)
                {
                    if (Grid[row][column].IsFree)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

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

        private void DrawGrid()
        {
            for (int row = 0; row < RowCount; row++)
            {
                DrawEmptyRow();
                DrawChipRow(Grid[row]);

                if (row != RowCount - 1)
                {
                    DrawLineRow();
                }
                else
                {
                    DrawEmptyRow();
                }
            }
        }

        private void DrawEmptyRow()
        {
            DrawRow(SlotSpace);
        }

        private void DrawLineRow()
        {
            DrawRow(SlotLine);
        }

        private void DrawChipRow(Slot[] row)
        {
            string slotPadding = new string(SlotSpace, SlotPadding);
            string slotPaddingRight = slotPadding;
            string slotRow = "";

            for (int column = 0; column < row.Length; column++)
            {
                string slotValue = row[column].Chip.Value;
                string slotValueMaxLengthDifference = new string(SlotSpace, MaxSlotLength - slotValue.Length);
                string slotPaddingLeft = slotPadding + slotValueMaxLengthDifference;

                slotRow += slotPaddingLeft + slotValue + slotPaddingRight;

                if (column < row.Length - 1)
                {
                    slotRow += SlotDivider;
                }
            }

            Console.WriteLine(slotRow);
        }

        private void DrawRow(char slotFill)
        {
            string slotContent = new string(slotFill, MaxSlotLengthWithPadding) + SlotDivider;
            string slotRow = string.Concat(Enumerable.Repeat(slotContent, ColumnCountPerRow));

            Console.WriteLine(RemoveLastMark(slotRow));
        }

        private string RemoveLastMark(string value) => value.Remove(value.Length - 1);

        private (int row, int column) SlotToRowAndColumn(int slot)
        {
            for (int row = 0; row < RowCount; row++)
            {
                for (int column = 0; column < Grid[row].Length; column++)
                {
                    if (Grid[row][column].Chip.Equals(slot))
                    {
                        return (row, column);
                    }
                }
            }
            return (-1, -1); // Bad design, but works for now
        }
    }
}
