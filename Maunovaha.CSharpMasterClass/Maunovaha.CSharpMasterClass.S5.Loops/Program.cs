using System;

namespace Maunovaha.CSharpMasterClass.S5.Loops
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //////////////////////////////////
            // For loops
            //////////////////////////////////
            
            for (int i = 0; i < 10; ++i)
            {
                Console.WriteLine("For loop, i: {0}", i); // 0, 1, 2, 3, 4, 5 ...
            }

            Console.WriteLine("--------------------------\n");

            for (int i = 0; i < 50; i += 5)
            {
                Console.WriteLine("For loop, i: {0}", i); // 0, 5, 10, 15, 20 ...
            }

            Console.WriteLine("--------------------------\n");

            for (int i = 1; i < 10; i += 2)
            {
                Console.WriteLine("For loop, i: {0}", i); // 1, 3, 5, 7, 9
            }

            Console.WriteLine("--------------------------\n");

            //////////////////////////////////
            // Do while (Runs at least once)
            //////////////////////////////////

            int j = 0;

            do
            {
                Console.WriteLine("Do while, j: {0}", j); // 0, 1, 2, 3, 4
                j++;
            }
            while (j < 5);

            Console.WriteLine("--------------------------\n");

            string friendName;

            do
            {
                Console.WriteLine("Please enter name of your friend:");
                friendName = Console.ReadLine();
            }
            while (!friendName.ToLower().Equals("mauno"));

            Console.WriteLine("Friend name was: {0}", friendName);
            Console.WriteLine("--------------------------\n");

            //////////////////////////////////
            // While loop
            //////////////////////////////////

            int s = 10;

            while (s > 0)
            {
                Console.WriteLine("While loop, s: {0}", s); // 10, 9, 8, 7, 6 ...
                s--;
            }

            Console.WriteLine("--------------------------\n");

            //////////////////////////////////
            // Break and continue
            //////////////////////////////////
            
            for (int i = 0; i < 10; ++i)
            {
                if (i == 5) // or e.g. i % 2 == 0 (even numbers)
                {
                    continue; // Skips print of 5
                }

                if (i == 7)
                {
                    break;
                }

                Console.WriteLine("Break and continue, i: {0}", i); // 0, 1, 2, 3, 4, 6
            }

            Console.Read();
        }
    }
}
