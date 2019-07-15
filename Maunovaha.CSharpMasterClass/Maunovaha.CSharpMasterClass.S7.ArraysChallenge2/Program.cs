using System;

namespace Maunovaha.CSharpMasterClass.S7.ArraysChallenge2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Challenge is to create a jagged array, which contains 3 "friends arrays", in which
            // two family members should be stored.
            //
            // Introduce the family members from different families to each other via console
            // (three different introductions).

            // Possible to declare array outside as well..
            string[] example = new string[] { "Jones", "Rick" };

            string[][] families = new string[][]
            {
                new string[] { "Mauno", "Kappu" },
                new string[] { "Pekka", "Pasi" },
                example
            };

            Introduce(families[0], families[1]); // Outputs `Hi Mauno and Kappu, I would like to introduce Pasi to you`
            Introduce(families[1], families[2]); // etc.
            Introduce(families[2], families[0]); // etc.

            Console.Read();
        }

        private static void Introduce(string[] strangers, string[] introduced)
        {
            Console.WriteLine("Hi {0} and {1}, I would like to introduce {2} to you.",
                strangers[0],
                strangers[1],
                introduced[1]);
        }
    }
}

