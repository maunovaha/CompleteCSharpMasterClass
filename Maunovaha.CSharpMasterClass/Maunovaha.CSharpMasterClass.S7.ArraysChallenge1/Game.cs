using System;
using System.Collections.Generic;
using System.Linq;

namespace Maunovaha.CSharpMasterClass.S7.ArraysChallenge1
{
    internal class Game
    {
        private bool IsRunning { get; set; }
        private List<Player> Players { get; set; } = new List<Player>();
        private byte CurrentPlayerIndex { get; set; }
        private Gameboard Gameboard { get; set; }

        public void Run()
        {
            SetupUi();
            SetupPlayers();
            SetupGameboard(SelectDifficulty());

            Loop();

            Console.Read();
        }

        private void SetupUi()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void SetupPlayers()
        {
            Players.Add(new Player("Player 1", Chip.X));
            Players.Add(new Player("Player 2", Chip.O));
        }

        private void SetupGameboard(DifficultyLevel difficulty)
        {
            // Keeping it simple, creating e.g. 3x3, 6x6 and 9x9 grids..
            int rows = (int)difficulty * 3;
            int columns = (int)difficulty * 3;

            Gameboard = new Gameboard(rows, columns);
        }

        private DifficultyLevel SelectDifficulty()
        {
            Console.WriteLine("Select difficulty, 1 = Easy, 2 = Medium, 3 = Hard: ");

            if (Enum.TryParse(Console.ReadLine(), out DifficultyLevel difficulty))
            {
                return difficulty;
            }

            Console.WriteLine("\n*** Error, your input was invalid!");
            return SelectDifficulty();
        }

        private void Loop()
        {
            IsRunning = true;

            do
            {
                ClearScreen();
                Draw();
                Update();
                IsRunning = !IsGameOver();
            }
            while (IsRunning);

            // Here, or somewhere else? e.g. inside Run(); ?
            // Console.WriteLine("Congrats {0}, you won!", "Player 1");
        }

        private void ClearScreen()
        {
            Console.Clear();
        }

        private void Draw()
        {
            Gameboard.Draw();
        }

        private void Update()
        {
            Players.ElementAt(CurrentPlayerIndex++).Update(Gameboard);

            if (CurrentPlayerIndex > Players.Count - 1)
            {
                CurrentPlayerIndex = 0;
            }
        }

        private bool IsGameOver()
        {
            return true;
        }
    }
}
