using System;

namespace Maunovaha.CSharpMasterClass.S3.Methods
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Methods without return value
            Greet(); // Outputs `Hello there!`
            WriteLine("Wazzup?"); // Outputs `Wazzup?`

            // Methods with return value
            WriteLine($"1 + 1 = {Sum(1, 2)}"); // Outputs `1 + 2 = 3`
            WriteLine($"2 * 4 = {Multiply(2, 4)}"); // Outputs `2 * 4 = 8`
            WriteLine($"1 / 4 = {Divide(1, 4)}"); // Outputs `1 / 4 = 0,25`
            WriteLine($"1.0 / 4.0 = {Divide(1.0, 4.0)}"); // Outputs `1.0 / 4.0 = 0,25`

            Read();
        }

        public static void Greet()
        {
            Console.WriteLine("Hello there!");
        }

        public static void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public static void Read()
        {
            Console.Read();
        }

        public static int Sum(int a, int b)
        {
            return a + b;
        }

        public static int Multiply(int a, int b)
        {
            return a * b;
        }

        public static double Divide(int a, int b)
        {
            return a / (double)b; // Without (double) conversion, result would be single digit value
        }

        public static double Divide(double a, double b) // Method overloading
        {
            return a / b; // This works ofc without conversion as well
        }
    }
}
