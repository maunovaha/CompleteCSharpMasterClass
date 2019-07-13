using System;
using System.Linq;

namespace Maunovaha.CSharpMasterClass.S7.ArraysChallenge1
{
    internal class Player
    {
        public string Name { get; }
        public Chip Chip { get; }

        public Player(string name, Chip chip)
        {
            Name = name;
            Chip = chip;
        }

        public void Update(Gameboard gameBoard)
        {
            bool chipPlaced = false;

            do
            {
                Console.Write("\n{0} -> Choose a number between {1} - {2}: ",
                    Name,
                    gameBoard.FirstSlotId,
                    gameBoard.LastSlotId);

                if (int.TryParse(Console.ReadLine(), out int slot) && gameBoard.IsWithinGrid(slot))
                {
                    chipPlaced = gameBoard.TryPlace(slot, Chip);

                    if (!chipPlaced)
                    {
                        Console.WriteLine("\n*** Error, slot is already taken!");
                    }
                }
                else
                {
                    Console.WriteLine("\n*** Error, your input was invalid!");
                }
            }
            while (!chipPlaced);
        }
    }
}
