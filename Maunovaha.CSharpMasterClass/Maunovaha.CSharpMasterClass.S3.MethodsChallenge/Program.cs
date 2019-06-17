using System;

namespace Maunovaha.CSharpMasterClass.S3.MethodsChallenge
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Challenge is to create three variables with names of my friends
            //
            // Then creating a method `GreetFriend` which writes "Hi <name>, my friend to the console."
            // In which the <name> is a parameter passed to the method.

            string name1 = "Pekka";
            string name2 = "Bazi";
            string name3 = "Kari";

            GreetFriend(name1); // Outputs `Hi Pekka, my friend!`
            GreetFriend(name2); // Outputs `Hi Bazi, my friend!`
            GreetFriend(name3); // Outputs `Hi Kari, my friend!`

            Read();
        }

        public static void GreetFriend(string name)
        {
            Console.WriteLine($"Hi {name}, my friend!");
        }

        public static void Read()
        {
            Console.Read();
        }
    }
}
