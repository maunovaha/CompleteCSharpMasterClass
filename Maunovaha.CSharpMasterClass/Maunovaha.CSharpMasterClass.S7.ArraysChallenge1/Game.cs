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
        private byte ContiguousChipCount => 3;

        public void Run()
        {
            SetupUi();
            SetupPlayers();
            SetupGameboard(SelectDifficulty());

            Player winner = Loop();
            DisplayGameOver(winner);

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

        private Player Loop()
        {
            do
            {
                ClearScreen();
                Draw();
                Update();

                (bool gameOver, Player winner) = CheckGameOver(CurrentPlayer);

                if (gameOver)
                {
                    return winner;
                }

                ChangeTurn();
            }
            while (true);
        }

        private void DisplayGameOver(Player winner)
        {
            ClearScreen();
            Draw();

            if (winner != null)
            {
                Console.WriteLine("\n*** Game over, {0} won! ***\n", winner.Name);
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

        private (bool gameOver, Player winner) CheckGameOver(Player player)
        {
            string pattern = GetPattern(player, ContiguousChipCount);

            if (IsHorizontalMatch(pattern) 
                || IsVerticalMatch(pattern)
                || IsDiagonalMatchFromLeftToRight(pattern) 
                || IsDiagonalMatchFromRightToLeft(pattern))
            {
                return (true, player);
            }
            else if (IsDraw())
            {
                return (true, null);
            }
             
            return (false, null);
        }

        private bool IsDraw() => Gameboard.IsFull();

        private bool IsHorizontalMatch(string winningPattern)
        {
            for (int row = 0; row < Gameboard.RowCount; row++)
            {
                for (int column = 0; column < Gameboard.Grid[row].Length - (ContiguousChipCount - 1); column++)
                {
                    string chip1 = Gameboard.Get(row, column);
                    string chip2 = Gameboard.Get(row, column + 1);
                    string chip3 = Gameboard.Get(row, column + 2);
                    string currentPattern = chip1 + chip2 + chip3;

                    if (currentPattern == winningPattern)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool IsVerticalMatch(string winningPattern)
        {
            for (int row = 0; row < Gameboard.RowCount - (ContiguousChipCount - 1); row++)
            {
                for (int column = 0; column < Gameboard.Grid[row].Length; column++)
                {
                    string chip1 = Gameboard.Get(row, column);
                    string chip2 = Gameboard.Get(row + 1, column);
                    string chip3 = Gameboard.Get(row + 2, column);
                    string currentPattern = chip1 + chip2 + chip3;

                    if (currentPattern == winningPattern)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool IsDiagonalMatchFromLeftToRight(string winningPattern)
        {
            for (int row = 0; row < Gameboard.RowCount - (ContiguousChipCount - 1); row++)
            {
                for (int column = 0; column < Gameboard.Grid[row].Length - (ContiguousChipCount - 1); column++)
                {
                    string chip1 = Gameboard.Get(row, column);
                    string chip2 = Gameboard.Get(row + 1, column + 1);
                    string chip3 = Gameboard.Get(row + 2, column + 2);
                    string currentPattern = chip1 + chip2 + chip3;

                    if (currentPattern == winningPattern)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool IsDiagonalMatchFromRightToLeft(string winningPattern)
        {
            for (int row = 0; row < Gameboard.RowCount - (ContiguousChipCount - 1); row++)
            {
                for (int column = Gameboard.Grid[row].Length - 1; column > 1; column--)
                {
                    string chip1 = Gameboard.Get(row, column);
                    string chip2 = Gameboard.Get(row + 1, column - 1);
                    string chip3 = Gameboard.Get(row + 2, column - 2);
                    string currentPattern = chip1 + chip2 + chip3;

                    if (currentPattern == winningPattern)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
