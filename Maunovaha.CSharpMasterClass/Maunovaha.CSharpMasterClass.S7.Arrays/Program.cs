using System;
using System.Collections;

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

            ////////////////////////////////////////
            // Jagged arrays
            ////////////////////////////////////////

            int[][] jaggedArr1 = new int[3][];
            jaggedArr1[0] = new int[5];
            jaggedArr1[1] = new int[5] { 1, 2, 3, 4, 5 };
            jaggedArr1[2] = new int[] { 1, 2, 3, 4, 5 }; // The best, when initializing right away

            int[][] jaggedArr2 = new int[/* 3 is optional here */][]
            {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6 },
                new int[3] // These are `0` by default
            };

            for (int i = 0; i < jaggedArr2.Length; i++)
            {
                for (int j = 0; j < jaggedArr2[i].Length; j++)
                {
                    Console.WriteLine("jaggedArr2[i][j] = {0}", jaggedArr2[i][j]);
                }
            }

            ////////////////////////////////////////
            // Arrays as parameters
            ////////////////////////////////////////

            double average = CalculateAverage(new int[] { 10, 5 });
            Console.WriteLine("Average is: {0}", average); // Outputs `Average is: 7,5`

            int[] values = new int[] { 2 };
            int[] multiplied = MultiplyByTwo(values);
            Console.WriteLine("2 * 2 = {0}", multiplied[0]); // Outputs `2 * 2 = 4`

            // This is weird, but apparently arrays works like references, so the MultiplyByTwo
            // method actually modifies the real array value. So the above will output 4 as well(!)
            Console.WriteLine("values[0] = {0}", values[0]); // Outputs `values[0] = 4`

            // Modifying array numbers directly will work, so we can declare void method and it works the 
            // same as well.. without returning array instance.
            int[] test = new int[] { 2 };
            MultiplyByTwoAlternative(ref test);
            Console.WriteLine("test is {0}", test[0]); // Outputs `test is 4`

            ////////////////////////////////////////
            // ArrayList
            ////////////////////////////////////////

            // Undefined amount of objects
            ArrayList list1 = new ArrayList();
            list1.Add(1234);

            Console.WriteLine("list1 capacity is: {0}", list1.Capacity); // Outputs `4`
            // So list capacity is increased automatically by some code underneath..

            // Creates array list which initial capacity is 3
            ArrayList list2 = new ArrayList(3);
            list2.Add(11);
            list2.Add(12.3f); // Allows to push different data types
            list2.Add('A');
            list2.Add("Hello"); // Increases the capacity automatically over 3 (!)

            // Interestingly, this will output `6` so the capacity is always doubled? when going
            // over the initial capacity???
            Console.WriteLine("list2 capacity is: {0}", list2.Capacity);

            foreach (var value in list2)
            {
                Console.WriteLine("Value is {0}", value);
            }

            ArrayList list3 = new ArrayList()
            {
                "A",
                "A",
                "B"
            };

            list3.Remove("A"); // Removes element with given value
            list3.Remove("A"); // Needed to call again to remove all occurences(?)
            Console.WriteLine("list3 size is: {0}", list3.Count); // Outputs `list3 size is: 1`

            list3.RemoveAt(0); // Removes the final element
            Console.WriteLine("list3 size is: {0}", list3.Count); // Outputs `list3 size is: 0`

            ArrayList list4 = new ArrayList()
            {
                1,
                1.1,
                "1,2" // Note, using `1.2` here causes Convert.ToDouble(val); fail...
            };

            double sum = 0.0;

            foreach (object val in list4)
            {
                if (val is int)
                {
                    sum += Convert.ToDouble(val);
                }
                else if (val is double)
                {
                    sum += (double)val;
                }
                else if (val is string)
                {
                    sum += Convert.ToDouble(val);
                }
            }

            Console.WriteLine("sum is: {0}", sum); // Outputs `sum is: 3,3`

            Console.Read();
        }

        // Using ref here makes sure that we cannot initialize passed array inline.. e.g.
        // `MultiplyByTwoAlternative(new int[] { 2 });` <-- Does not work(!)
        private static void MultiplyByTwoAlternative(ref int[] numbers)
        {
            numbers[0] = 4;
        }

        private static int[] MultiplyByTwo(int[] numbers)
        {
            int[] multiplied = numbers; // Reference

            for (int i = 0; i < multiplied.Length; i++)
            {
                multiplied[i] *= 2;
            }

            // Doing `int[] multiplied = numbers;` above will create a reference to array.. 
            // so if we try to output the value of `numbers[0]` here, it is the same as `multiplied[0]`
            Console.WriteLine("numbers[0]: " + numbers[0]); // Outputs `4`

            return multiplied;
        }

        private static double CalculateAverage(int[] numbers)
        {
            double sum = 0;
            int numbersCount = numbers.Length;

            for (int i = 0; i < numbersCount; i++)
            {
                sum += numbers[i];
            }

            return sum / /*(double)*/numbersCount;
        }
    }
}
