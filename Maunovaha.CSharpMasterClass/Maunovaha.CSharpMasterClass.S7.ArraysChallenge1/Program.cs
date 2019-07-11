namespace Maunovaha.CSharpMasterClass.S7.ArraysChallenge1
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
            //   X  |  8  |  9
            //      |     |
            //
            // Player 1 -> Choose a number between 1 - 9:
            //
            // Hence, the whole game should run at top left of the console window
            // and including simple error handling, win condition etc.
            //
            // As a bonus, the game will have three different difficulty modes: 
            // easy, medium and hard (having e.g. 3x3, 6x6 and 9x9 grid).

            Game game = new Game();
            game.Run();
        }
    }
}
