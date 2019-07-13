using System;
using System.Collections.Generic;
using System.Linq;

namespace Maunovaha.CSharpMasterClass.S7.ArraysChallenge1
{
    internal class Game
    {
        private Gameboard Gameboard { get; set; }
        private List<Player> Players { get; set; } = new List<Player>();
        private byte CurrentPlayerIndex { get; set; }
        private Player CurrentPlayer => Players.ElementAt(CurrentPlayerIndex);
        private int ContiguousChipCount => 3;

        public void Run()
        {
            SetupUi();
            SetupPlayers();
            SetupGameboard(SelectDifficulty());

            GameStatus gameStatus = Loop();
            DisplayGameOver(gameStatus);

            Console.Read();
        }

        private void SetupUi()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void SetupPlayers()
        {
            Players.Add(new Player("Player (X)", Chip.X));
            Players.Add(new Player("Player (O)", Chip.O));
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

            if (int.TryParse(Console.ReadLine(), out int difficulty))
            {
                // Dunno why, but parsing Enum value here from int allows invalid values to
                // pass as well.. so using "stupid" switch statement instead.

                switch (difficulty)
                {
                    case 1:
                        return DifficultyLevel.Easy;
                    case 2:
                        return DifficultyLevel.Medium;
                    case 3:
                        return DifficultyLevel.Hard;
                }
            }

            Console.WriteLine("\n*** Error, your input was invalid!\n");
            return SelectDifficulty();
        }

        private GameStatus Loop()
        {
            GameStatus gameStatus = new GameStatus();

            do
            {
                ClearScreen();
                Draw();
                Update();

                if (!IsGameOver(CurrentPlayer, ref gameStatus))
                {
                    ChangeTurn();
                }
            }
            while (gameStatus.IsRunning);

            return gameStatus;
        }

        private void DisplayGameOver(GameStatus gameStatus)
        {
            ClearScreen();
            Draw();

            if (!gameStatus.IsRunning && gameStatus.Winner != null)
            {
                Console.WriteLine("\n*** Game over, {0} won! ***\n", gameStatus.Winner.Name);
            }
            else
            {
                Console.WriteLine("\n*** Game over, it was a draw! ***\n");
            }
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
            CurrentPlayer.Update(Gameboard);
        }

        private void ChangeTurn()
        {
            CurrentPlayerIndex++;

            if (CurrentPlayerIndex > Players.Count - 1)
            {
                CurrentPlayerIndex = 0;
            }
        }

        private string GetPattern(Player player, int count)
        {
            return string.Concat(Enumerable.Repeat(player.Chip.Value, count));
        }

        private string GetPattern(List<Slot> row, int startIndex, int count)
        {
            return string.Concat(row.GetRange(startIndex, count).Select(slot => slot.Chip.Value));
        }

        private bool IsGameOver(Player player, ref GameStatus gameStatus)
        {
            string winningPattern = GetPattern(player, ContiguousChipCount);

            // Checking horizontal line matches
            for (int row = 0; row < Gameboard.RowCount; row++)
            {
                for (int column = 0; column < Gameboard.Grid[row].Length - (ContiguousChipCount - 1); column++)
                {
                    string siblings = GetPattern(Gameboard.Grid[row].ToList(), column, ContiguousChipCount);

                    if (winningPattern == siblings)
                    {
                        gameStatus.SetGameOver(CurrentPlayer);
                        return true;
                    }
                }
            }

            // TODO: Checking vertical line matches

            // TODO: Checking draw

            return false;
        }

        private class GameStatus
        {
            public bool IsRunning { get; private set; } = true;
            public Player Winner { get; private set; }

            public void SetGameOver(Player player = null)
            {
                IsRunning = false;
                Winner = player;
            }
        }
    }
}
