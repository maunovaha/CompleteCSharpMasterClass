using System;

namespace Maunovaha.Section1.HelloWorld
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Sets console text color
            Console.ForegroundColor = ConsoleColor.Green;

            // Sets console background color
            Console.BackgroundColor = ConsoleColor.DarkGray;

            // Sets the whole console window to use the defined colors 
            // (fills the background as well)
            Console.Clear();                                                                       

            string name = "Stranger";
            Console.WriteLine($"Hello {name}!");

            // Requires <Enter> to exit the program (only on Windows)
            Console.Read();
        }
    }
}
