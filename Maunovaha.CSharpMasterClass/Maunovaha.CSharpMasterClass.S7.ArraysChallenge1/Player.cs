using System;

namespace Maunovaha.CSharpMasterClass.S7.ArraysChallenge1
{
    internal class Player
    {
        public string Name { get; private set; }

        private char Chip { get; set; }

        // How to keep track of pelimerkki? X or O?

        public Player(string name, char chip)
        {
            Name = name;
            Chip = chip;
        }

        public void Update(Gameboard gameBoard)
        {
            // do while input valid (?)
            // also, display error properly ...

            Console.WriteLine("{0} -> Choose a number between 1 - 9: ", Name);
            string jees = Console.ReadLine();

            gameBoard.TryPlace(0, 'X');

            // Read input(?)
        }
    }
}
