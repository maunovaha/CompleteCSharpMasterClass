﻿namespace Maunovaha.CSharpMasterClass.S7.ArraysChallenge1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Challenge is to create Tic Tac Toe which runs in console window.
            // The game is played by entering numbers between 1 - 9.
            // 
            // Layout of the game should be e.g.
            //
            //      |     |
            //   1  |  2  |  X
            // _____|_____|_____
            //      |     |
            //   4  |  X  |  6
            // _____|_____|_____
            //      |     |
            //   O  |  8  |  9
            //      |     |
            //
            // Player 1 -> Choose a number between 1 - 9:
            //
            // Hence, the whole game should run at top left of the console window
            // and including simple error handling, win condition etc.

            Game game = new Game();
            game.Run();
        }
    }
}
