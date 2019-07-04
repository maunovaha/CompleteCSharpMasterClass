using System;
using System.Collections.Generic;

namespace Maunovaha.CSharpMasterClass.S4.DecisionsChallenge2
{
    internal class Program
    {
        private static readonly Player HighScoreHolder = new Player("Suba", 1000);
        private static Application App { get; set; } // = new Application(...);

        public static void Main(string[] args)
        {
            // Challenge is to create application which keeps track of high score.
            //
            // The program is modified to my own taste, but basically we set high score holder
            // in the beginning and each player beating the previous score will be assigned
            // as a leader.
            //
            // Hence, everytime the player score is set we log current status to the console.

            App = new Application(HighScoreHolder);
            App.AddPlayer(new Player("Mauno", 1500));
            App.AddPlayer(new Player("Pekka", 3500));
            App.AddPlayer(new Player("Sami", 1200));
            App.Run();

            // The program outputs:
            //
            // New high score is 1500!
            // New high score holder is `Mauno`
            // -----------------------------

            // New high score is 3500!
            // New high score holder is `Pekka`
            // -----------------------------

            // The old high score of 3500 could not be broken and is still held by `Pekka`
            // -----------------------------
        }

        private class Application
        {
            private /* readonly */ Player HighScoreHolder { get; set; }

            private List<Player> Players { get; set; } = new List<Player>();

            public Application(Player highScoreHolder)
            {
                HighScoreHolder = highScoreHolder;
            }

            public void Run()
            {
                foreach (Player player in Players)
                {
                    if (player.Score > HighScoreHolder.Score)
                    {
                        HighScoreHolder = player;
                        DisplayNewHighScore(HighScoreHolder);
                    }
                    else
                    {
                        DisplayCurrentHighScore();
                    }
                }
            }

            public void AddPlayer(Player player)
            {
                Players.Add(player);
            }

            private void DisplayNewHighScore(Player player)
            {
                Console.WriteLine("New high score is {0}!", player.Score);
                Console.WriteLine("New high score holder is `{0}`", player.Name);
                Console.WriteLine("-----------------------------\n");
            }

            private void DisplayCurrentHighScore()
            {
                Console.WriteLine("The old high score of {0} could not be broken and is still held by `{1}`", 
                    HighScoreHolder.Score, 
                    HighScoreHolder.Name);
                Console.WriteLine("-----------------------------\n");
            }
        }

        private class Player
        {
            public string Name { get; }
            public int Score { get; }
            
            public Player(string name, int score)
            {
                Name = name;
                Score = score;
            }
        }
    }
}
