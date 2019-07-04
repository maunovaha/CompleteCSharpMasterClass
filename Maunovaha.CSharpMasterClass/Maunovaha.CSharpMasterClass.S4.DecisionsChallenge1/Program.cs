using System;
using System.Collections.Generic;

namespace Maunovaha.CSharpMasterClass.S4.DecisionsChallenge1
{
    internal class Program
    {
        // Used as "fake" database
        private static readonly List<User> Users = new List<User>();

        public static void Main(string[] args)
        {
            // Challenge is to create login system where user can first register,
            // and then log in.
            //
            // The program should check if the user has entered correct username and password,
            // and then to log in.
            //
            // Because storing data is not covered yet, registering / loggin in can happen
            // in one executing and then forgotten.
            //
            // I should use if statements/methods to solve the challenge.

            Register();
            LogIn();

            Console.Read();
        }

        private static void Register()
        {
            string username = ReadInput("username", 4);
            string password = ReadInput("password", 8);

            Users.Add(new User(username, password));
        }

        private static void LogIn()
        {
            Console.WriteLine("\n---------------------------");
            Console.WriteLine("--- Log in");
            Console.WriteLine("---------------------------\n");

            Console.WriteLine("Username: ");
            string username = Console.ReadLine();

            Console.WriteLine("Password: ");
            string password = Console.ReadLine();

            User user = new User(username, password);

            if (!Users.Contains(user))
            {
                Console.WriteLine("Login failed, please try again");
                LogIn();
            }
            else
            {
                Console.WriteLine("Congrats, you logged in successfully!");
            }
        }

        private static string ReadInput(string field, byte limit)
        {
            Console.WriteLine("Please enter {0} (min. {1} marks): ", field, limit);
            string input = Console.ReadLine();

            if (input.Length < limit)
            {
                Console.WriteLine("You entered {0} which was too short!", field);
                return ReadInput(field, limit);
            }

            return input;
        }

        public class User : IEquatable<User>
        {
            public string Username { get; private set; } // Using readonly could work as well?
            public string Password { get; private set; }

            public User(string username, string password)
            {
                Username = username;
                Password = password;
            }

            // If this is not implemented, doing a check like `if (!Users.Contains(user))` does not
            // work because the class is missing object comparison logic
            public bool Equals(User other)
            {
                return Username.Equals(other.Username) && Password.Equals(other.Password);
            }
        }
    }
}
