using System;

namespace Maunovaha.CSharpMasterClass.S4.Decisions
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //////////////////////////////////
            // If statements
            //////////////////////////////////

            Console.WriteLine("What's the temperature like?");
            string userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int temperature))
            {
                if (temperature < 10)
                {
                    Console.WriteLine("You are in Finland?");
                }
                else
                {
                    Console.WriteLine("Seems rather hot");
                }
            }
            else
            {
                Console.WriteLine("Value you entered could not be parsed");
            }

            // I believe using `Equals()` is the proper method for string comparison
            if ("maunovaha".Equals("maunovaha"))
            {
                Console.WriteLine("Hello Mauno");
            }

            if (true || false) // Passes, ofc. Using e.g. true && false etc. checks works similar
            {
                Console.WriteLine("I am executed..");
            }

            //////////////////////////////////
            // Switch statements
            //////////////////////////////////

            int age = 45;

            switch (age)
            {
                case 15:
                    Console.WriteLine("Too young to party");
                    break;
                case 25:
                    Console.WriteLine("Good to go");
                    break;
                case 35:
                case 40:
                    Console.WriteLine("Really?");
                    break;
                default:
                    Console.WriteLine("How old are you then?");
                    break;
            }

            string someName = "John";

            switch (someName)
            {
                case "John":
                    Console.WriteLine("someName is John");
                    break;
            }

            //////////////////////////////////
            // Ternary operators (nothing new...)
            //////////////////////////////////

            int someVal = 10;

            bool someBool = someVal == 10 ? true : false;
            someBool = someVal == 10;
            someBool = someVal < 10;

            string someStr = someBool ? "yes" : "no";
            someStr = someBool ? (someVal < 10 ? "jaa" : "joo") : "jee";

            Console.Read();
        }
    }
}
