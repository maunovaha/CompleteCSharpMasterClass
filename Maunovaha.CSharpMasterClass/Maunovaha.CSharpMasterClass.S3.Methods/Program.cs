using System;

namespace Maunovaha.CSharpMasterClass.S3.Methods
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Methods without return value
            Greet(); // Outputs `Hello there!`
            Console.WriteLine("Wazzup?"); // Outputs `Wazzup?`

            // Methods with return value
            Console.WriteLine($"1 + 1 = {Sum(1, 2)}"); // Outputs `1 + 2 = 3`
            Console.WriteLine($"2 * 4 = {Multiply(2, 4)}"); // Outputs `2 * 4 = 8`
            Console.WriteLine($"1 / 4 = {Divide(1, 4)}"); // Outputs `1 / 4 = 0,25`
            Console.WriteLine($"1 / 0 = {Divide(1, 0)}"); // Outputs `1 / 4 = 0,25`
            Console.WriteLine($"1.0 / 4.0 = {Divide(1.0, 4.0)}"); // Outputs `1.0 / 4.0 = 0,25`

            //////////////////////////////////
            // Input handling
            //////////////////////////////////

            ReadSum();
            ReadNumber(5, 10);

            //////////////////////////////////
            // Operators
            //////////////////////////////////

            int num1 = -5;
            Console.WriteLine("num1 = {0}", -num1); // Outputs `num2 = 5`

            bool sunny = false;
            Console.WriteLine("sunny = {0}", !sunny); // Outputs `sunny = True`

            // Increment operators (pre/post -increment/decrement)

            int num2 = 0;
            num2++;
            Console.WriteLine("num2 = {0}", num2); // Outputs `num2 = 1`
            Console.WriteLine("num2 = {0}", num2++); // Outputs `num2 = 1`
            Console.WriteLine("num2 = {0}", num2); // Outputs `num2 = 2`
            Console.WriteLine("num2 = {0}", ++num2); // Outputs `num2 = 3`
            Console.WriteLine("num2 = {0}", --num2); // Outputs `num2 = 2`

            // The normal stuff for these..
            // 
            // num2 = 10 + 10;
            // num2 = 10 - 10;
            // num2 = 10 / 10; -- Remember to cast of rest of the int is cut away
            // num2 = 10 * 10;
            // num2 = 10 % 10;

            bool lower = 1 < 2;
            Console.WriteLine("lower = {0}", lower); // Outputs `lower = True`

            bool equal = 1 == 1;
            Console.WriteLine("equal = {0}", equal); // Outputs `equal = True`

            // Conditional operators

            bool lazy = true;
            bool pro = true;
            bool lazyAndPro = lazy && pro; // This is true because both of these are true
            Console.WriteLine("lazyAndPro = {0}", lazyAndPro); // Outputs `lazyAndPro = True`

            pro = false;
            bool lazyOrPro = lazy || pro; // This is true because one of them is still true
            Console.WriteLine("lazyOrPro = {0}", lazyOrPro); // Outputs `lazyOrPro = True`

            Console.Read();
        }

        public static void ReadNumber(int min = Int32.MinValue, int max = Int32.MaxValue)
        {
            Console.WriteLine("Please enter a number between {0} and {1}", min, max);

            string userInput = Console.ReadLine();
            int number = 0; // Local variable needs to be assigned when we coding with C#

            try
            {
                number = Convert.ToInt32(userInput);

                if (number < min || number > max)
                {
                    throw new OverflowException(); // I could raise ArgumentException as well here?
                }
            }
            catch (FormatException)
            {
                // throw; // Use this if you want to re-raise or debug
                Console.WriteLine("Error, given value is not a number");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Error, given value must be between {0} and {1}", min, max);
            }
            finally
            {
                // Executed every time when try/catch block is done
                // Basically this is used for e.g. closing internet connection or similar tasks..
            }

            Console.WriteLine("The number you gave was: {0}", number);
        }

        public static void ReadSum()
        {
            int number1 = ReadNumber("Please enter the first number: ");
            int number2 = ReadNumber("Please enter the second number: ");

            Console.WriteLine("{0} + {1} = {2}", number1, number2, Sum(number1, number2));
        }

        public static int ReadNumber(string message)
        {
            Console.WriteLine(message);
            string userInput = Console.ReadLine();

            if (Int32.TryParse(userInput, out int number))
            {
                return number;
            }
            else
            {
                Console.WriteLine("Error reading a number, please try again.");
            }
            return ReadNumber(message);
        }

        public static void Greet()
        {
            Console.WriteLine("Hello there!");
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
            // This is important: If we try to divide two ints as e.g. 4 / 0 it would throw an
            // DivideByZeroException; But because we use (double)b cast then dividing a 
            // floating -point value by zero doesn't throw an exception; it results in positive 
            // infinity, negative infinity, or not a number (NaN), according to the rules 
            // of IEEE 754 arithmetic.
            //
            // Moreover, without (double)b cast, the result would be single digit value.
            // E.g. the result of 1 / 4 would be 0 rather than 0,25 (which is correct)
            double result = a / (double)b;

            if (Double.IsNaN(result) || Double.IsInfinity(result))
            {
                Console.WriteLine("You accidentally divided with zero! (Returning zero for now)");
                return 0.0; // Default value
            }
            return result;
        }

        public static double Divide(double a, double b) // Method overloading
        {
            return a / b; // This works ofc without conversion as well
        }
    }
}
