using System;

namespace Maunovaha.CSharpMasterClass.S1.HelloWorld
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Sets console text color
            Console.ForegroundColor = ConsoleColor.Green;

            // Sets console background color
            Console.BackgroundColor = ConsoleColor.DarkGray;

            // Sets the whole console window (background) to use the defined colors
            Console.Clear();

            string name = "Stranger";
            Console.WriteLine($"Hello {name}!");

            // Requires <Enter> to exit the program (only on Windows?)
            Console.Read();
        }
    }
}
