using System;

namespace Maunovaha.CSharpMasterClass.S4.Decisions
{
    internal class Program
    {
        public static void Main(string[] args)
        {
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

            Console.Read();
        }
    }
}
