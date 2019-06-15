using System;

namespace Maunovaha.CSharpMasterClass.S2.DataTypes
{
    internal class Program
    {
        // Note: Using `static` for variables is needed as they are accessed at the class level.
        // Other option would be to have an object instance which has those variables stored (?).

        private static readonly int age1 = 32;
        private static readonly int age2; // Defaults to `0` (not null)

        public static void Main(string[] args)
        {
            //////////////////////////////////////////////////
            // Printing class (static) variables
            //////////////////////////////////////////////////

            Console.WriteLine("age1: {0}", age1); // Outputs `32`
            Console.WriteLine($"age2: {age2}"); // Outputs `0`

            int age3 = 14;
            Console.WriteLine($"age3: {age3}"); // Outputs `14`

            // Data types and their length 
            // Tip: Use the smallest data type your value fits into
            // 
            // sbyte   x = 0;     // -128 to 127
            // byte    x = 0;     // 0 to 255
            // short   x = 0;     // -32767 to 32767
            // ushort  x = 0;     // 0 to 65,535
            // int     x = 0;     // -2,147,483,648 to 2,147,483,647
            // uint    x = 0;     // 0 to 4,294,967,295
            // long    x = 0;     // -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807
            // ulong   x = 0;     // 0 to 18,446,744,073,709,551,615
            //
            // float   x = 0.0f;  // 7-digit precision  (Used mostly in graphics libs, high demands for processing power)
            // double  x = 0.0;   // 15-digit precision (Used mostly in real world values, except cash)
            // decimal x = 0.0;   // 28-digit precision (Used mostly in financial apps, high level of accuracy)
            //
            // bool    x = false; // or true
            // char    x = 'A';   // U+0000 to U+ffff
            // string  x = "A";   // Allows multiple letters and unicodes
            //
            // More types: https://docs.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/types-and-variables

            //////////////////////////////////////////////////
            // Assigning and printing int, double and float
            //////////////////////////////////////////////////

            int i1 = 10;
            int i2 = 5;
            int iSum = i1 + i2;
            Console.WriteLine($"iSum: {iSum}"); // Outputs `iSum: 15`

            // Multiple variable assignment
            int i3 = 1, i4 = 2;
            Console.WriteLine($"i3: {i3}, i4: {i4}"); // Outputs `i3: 1, i4: 2`

            double d1 = 3.5;
            double d2 = 3.6;
            double dDiv1 = d2 / d1;
            Console.WriteLine($"dDiv1: {dDiv1}"); // Outputs `dDiv1: 1,02857142857143`

            // Division test
            double dDiv2 = d1 / i1;
            double dDiv3 = i1 / d1;
            int dDiv4 = (int)6.5 / 2; // Without casting, this would cause an error
            Console.WriteLine($"dDiv4: {dDiv4}"); // Outputs `dDiv4: 3`

            float f1 = 3.0f;
            float f2 = 6.555666777888f;
            float f3 = f1 + f2;
            Console.WriteLine($"f3: {f3}"); // Outputs `f3: 9,555667` (Because 7-digit precision)
            Console.WriteLine($"f3: {f3:0.00#}"); // Outputs `f3: 9,556` (Because rounding/limit)

            //////////////////////////////////////////////////
            // Working with strings
            ////////////////////////////////////////////////// 

            string name = "Mauno";
            string message = $"My name is: {name}";
            Console.WriteLine(message); // Outputs `My name is Mauno`
            Console.WriteLine(message.ToUpper()); // Outputs `MY NAME IS MAUNO`
            Console.WriteLine(message.ToLower()); // Outputs `my name is mauno`

            //////////////////////////////////////////////////
            // Implicit and explicit conversion
            //////////////////////////////////////////////////

            // Implicit
            int iNum = 12345;
            long lNum = iNum;
            Console.WriteLine($"lNum: {lNum}"); // Outputs `12345`

            float fNum = 13.37f;
            double dNum = fNum;
            Console.WriteLine($"dNum: {dNum}"); // Outputs `13,3699998855591` (Not good!!!)

            // Explicit
            double dCash = 13.37;
            int iCash = (int)dCash;
            Console.WriteLine($"iCash: {iCash}"); // Outputs `13`

            // Type conversions
            Console.WriteLine($"Double to string: {13.37.ToString()}"); // Outputs `Double to string: 13,37`
            Console.WriteLine($"Float to string: {13.37f.ToString()}"); // Outputs `Float to string: 13,37`
            Console.WriteLine($"Bool to string: {true.ToString()}"); // Outputs `True`

            //////////////////////////////////////////////////
            // Parsing a string to an integer
            //////////////////////////////////////////////////

            string myString1 = "10";
            string myString2 = "20";
            string myString3 = myString1 + myString2;
            Console.WriteLine($"myString3: {myString3}"); // Outputs `1020`

            // This will crash the program if the parse fails (Exception is thrown)
            int myParsedInt1 = Int32.Parse(myString1) + Int32.Parse(myString2);
            Console.WriteLine($"myParsedInt1: {myParsedInt1}"); // Outputs `30`

            // Safe way to parse an int (quick example)
            if (Int32.TryParse(myString1, out int parsedInt))
            {
                Console.WriteLine($"parsedInt: {parsedInt}"); // Outputs `10`
            }

            // ...
            Console.Read();
        }
    }
}
