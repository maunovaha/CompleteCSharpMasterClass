using System;

namespace Maunovaha.CSharpMasterClass.S7.Arrays
{
    internal class Program
    {
        public static string nullString; // Will be `null` by default
        public static int nullInt; // Cannot be `null`, will be `0` by default
        public static float nullFloat; // Cannot be `null`, will be `0.0` by default`

        // Same applies to property of type e.g. int, _cannot be null_
        public static int NullInt { get; set; }

        public static void Main(string[] args)
        {
            if (nullString == null)
            {
                Console.WriteLine("Holy shit, nullString!"); // This is printed(!)
            }

            // For this, compiler detects an error.. "unassigned variable of type string"
            //
            // string what;
            //
            // if (what == null)
            // {
            // }

            // Causes error, cannot compare int, float, etc. to null
            //
            // if (NullInt == null)
            // {
            // }

            ////////////////////////////////////////
            // Declaring and initializing arrays, etc.
            ////////////////////////////////////////

            int[] grades = { 5, 6, 7 };
            string[] names = { "John", "Rick", "Mike" };
            sbyte[] flags = { -1, 4, 6 };

            int[] numbers = new int[5];
            // numbers[7] = 2; // Crashes program, but before that, no error
            numbers[0] = 1;
            numbers[4] = 2;

            for (int i = 0; i < numbers.Length; ++i)
            {
                // Note: Unassigned `int` elements has value of `0` by default
                Console.WriteLine("numbers[{0}] = {1}", i, numbers[i]); // 1, 0, 0, 0, 2
            }

            int[] levels1 = new int[3] { 1, 2, 3 }; // Works, but e.g. [3] is redundant
            int[] levels2 = new int[] { 1, 2, 3 }; // Works, but still clumsy
            int[] levels3 = { 1, 2, 3 }; // The best

            foreach (int level in levels3)
            {
                Console.WriteLine("level {0}", level); // `level 1, level 2, level 3`
            }

            ////////////////////////////////////////
            // Multi dimensional arrays
            ////////////////////////////////////////

            string[,] twoD; // 2D array
            int[,,] threeD; // 3D array

            int[,] array2d = new int[,]
            {
                { 1, 2, 3 },
                { 3, 5, 6 },
                { 7, 8, 9 }
            };
            Console.WriteLine("array2d[1, 1] = {0}", array2d[1, 1]); // Outputs `5` from the center

            array2d[0, 1] = 22; // Changing value ..

            int[,,] array3d = /* new int[,,] */
            {
                {
                    { 1, 2, 3 },
                    { 7, 7, 7 }
                },
                {
                    { 4, 5, 6 },
                    { 1, 9, 1 } // Row count needs to match, cannot have 3 rows here, if the above has only 2
                }
            };
            Console.WriteLine("array2d[1, 1, 1] = {0}", array3d[1, 1, 1]); // Outputs `9`
            Console.WriteLine("array3d has {0} dimensions", array3d.Rank); // 3D array has 3 dimensions, ofc.

            Console.Read();
        }
    }
}
