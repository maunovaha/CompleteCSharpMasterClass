using System;
using System.Collections.Generic;
using System.Linq;

namespace Maunovaha.CSharpMasterClass.S7.ArraysChallenge1
{
    internal class Game
    {
        private bool IsRunning { get; set; }
        private List<Player> Players { get; set; } = new List<Player>();

        private Gameboard Gameboard { get; set; } = new Gameboard();

        public void Run()
        {
            SetupUi();
            SetupPlayers();

            Loop();

            Console.Read();
        }

        private void SetupUi()
        {
            // Make some UI class which allows to clear UI as well.. (?)
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
        }

        private void SetupPlayers()
        {
            Players.Add(new Player($"Player 1", 'X'));
            Players.Add(new Player($"Player 2", 'O'));
        }

        private void Loop()
        {
            IsRunning = true;

            do
            {
                Gameboard.Draw();

                Players.ElementAt(0).Update(Gameboard);

                Gameboard.Draw();

                // Check win/lose condition (?)

                IsRunning = false;

                // Take player reference here?
                // Ask number as long as it is valid?
                // Update board 
                // Check win condition ... etc.
            }
            while (IsRunning);
        }

        private void Draw()
        {
            // Hmm.. ? Gameboard.Draw();
        }

        private void Clear()
        {
            // Clears the screen...
            // Console.Clear(); ???
        }
    }
}
