using System;

namespace Maunovaha.CSharpMasterClass.S5.LoopsChallenge
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Challenge is to create a program which allows to enter
            // student scores and calculate average for them.
            //
            // The program should end when -1 is given.
            //
            // So the program should check if the entry is a number 
            // and add that to the sum. Finally, once entering the scores ends, 
            // the program should write onto the console the average.
            //
            // The numbers entered should be between 0 and 20; and the program
            // should not crash if the wrong value is entered.

            Application app = new Application();
            app.Run();
        }

        private class Application
        {
            private readonly int ProgramTerminator = -1;
            private readonly int MinScore = 0;
            private readonly int MaxScore = 20;

            public void Run()
            {
                // Uses new C# tuple format ..
                (int totalScore, int numberOfStudents) = ReadStudentScores();
                double averageScore = MathUtil.Average(totalScore, numberOfStudents);

                Console.WriteLine("Total score: {0}, student count: {1}, average: {2}",
                    totalScore,
                    numberOfStudents,
                    averageScore);

                Console.Read();
            }

            private (int totalScore, int numberOfStudents) ReadStudentScores()
            {
                int totalScore = 0;
                int numberOfStudents = 0;
                int score;

                do
                {
                    Console.WriteLine("Enter a score between {0} - {1}: ", MinScore, MaxScore);
                    string userInput = Console.ReadLine();

                    if (int.TryParse(userInput, out score) && (score >= MinScore && score <= MaxScore))
                    {
                        totalScore += score;
                        numberOfStudents++;
                    }
                    else if (score != ProgramTerminator)
                    {
                        Console.WriteLine("\nError, enter a proper score!");
                        Console.WriteLine("----------------------------\n");
                    }
                }
                while (score != ProgramTerminator);

                return (totalScore, numberOfStudents);
            }

            private static class MathUtil
            {
                public static double Average(int sum, int count) => sum / (double)count;
            }
        }

        // Random experiments, not related to working program ...
        //
        // public static int? Read()
        // {
        //     if (int.TryParse(Console.ReadLine(), out int value))
        //     {
        //         return value;
        //     }
        //     return null;
        // }
        //
        // private int ReadScore() /* out int someParam1, out int someParam2 */
        // {
        //     int score = 0;
           
        //     try
        //     {
        //         string userInput = Console.ReadLine();
        //         score = Convert.ToInt32(userInput);
             
        //         if (score == -1 || score < 10 || score > 20)
        //         {
        //             throw new ArgumentException();
        //         }
        //     }
        //     catch (Exception e) when (e is FormatException || e is OverflowException || e is ArgumentException)
        //     {
        //         Console.WriteLine("Error, enter a proper score!");
        //         Console.WriteLine("----------------------------\n");
        //     }
           
        //     return score;
        // }
    }
}
