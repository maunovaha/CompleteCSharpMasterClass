using System;

namespace Maunovaha.CSharpMasterClass.S2.DataTypesChallenge
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Challenge is to create variable for each of the primitive data types.
            //
            // After that, I should create two values of type string, and first one should say
            // "I control text". For the second one, I should use whole number and use `Parse` 
            // method in order to convert that string to an integer.
            //
            // Every variable value should be written to console.

            sbyte sbyteVal = -1;
            byte byteVal = 1;
            int intVal = -2;
            uint uintVal = 2;
            short shortVal = -3;
            ushort ushortVal = 3;
            long longVal = -4;
            ulong ulongVal = 4;
            float floatVal = 5.0f;
            double doubleVal = 6.0;
            decimal decimalVal = 7.0m;
            char charVal = 'A';
            bool boolVal = true;
            string stringVal = "I control text";

            Console.WriteLine($"sbyteVal: {sbyteVal}"); // Outputs `sbyteVal: -1`
            Console.WriteLine($"byteVal: {byteVal}"); // Outputs `byteVal: 1`
            Console.WriteLine($"intVal: {intVal}"); // Outputs `intVal: -2`
            Console.WriteLine($"uintVal: {uintVal}"); // Outputs `uintVal: 2`
            Console.WriteLine($"shortVal: {shortVal}"); // Outputs `shortVal: -3`
            Console.WriteLine($"ushortVal: {ushortVal}"); // Outputs `ushortVal: 3`
            Console.WriteLine($"longVal: {longVal}"); // Outputs `longVal: -4`
            Console.WriteLine($"ulongVal: {ulongVal}"); // Outputs `ulongVal: 4`
            Console.WriteLine($"floatVal: {floatVal}"); // Outputs `floatVal: 5`
            Console.WriteLine($"doubleVal: {doubleVal}"); // Outputs `doubleVal: 6`
            Console.WriteLine($"decimalVal: {decimalVal}"); // Outputs `decimalVal: 7,0`
            Console.WriteLine($"charVal: {charVal}"); // Outputs `charVal: A`
            Console.WriteLine($"boolVal: {boolVal}"); // Outputs `boolVal: True`
            Console.WriteLine($"stringVal: {stringVal}"); // Outputs `stringVal: I control text`
            
            string yearAsText = "2019";
            int year = Int32.Parse(yearAsText);

            Console.WriteLine($"year: {year}"); // Outputs `year: 2019`
            Console.Read();
        }
    }
}
