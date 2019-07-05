using System;

namespace Maunovaha.CSharpMasterClass.S6.OOP
{
    internal class Person
    {
        public string FirstName { get; set; }

        // Using e.g. `private string firstName;` is not as flexible as properties, because 
        // cannot use the constructor initialization the same way..

        public string LastName { get; set; }

        public string PhoneNumber { get; set; } = "0400111222";

        // Appararently, C# works similar as C++ in terms of constructors.
        // E.g. We need to declare empty constructor for below code to work, because
        // we have also declared constructor which takes firstName and lastName.
        // In other words, creating that kind of constructor will overwrite the default one.
        //
        // Person p3 = new Person { FirstName = "John", PhoneNumber = "0400222333" };
        // p3.Greet(); // Outputs `Hello, my name is John  (p. 0400222333)`
        // 
        // So the above code will call this empty constructor ...
        public Person()
        {
            Console.WriteLine("Invoked every time..");
        }

        public Person(string firstName, string lastName) : base() // `base()` calls empty constructor
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public void Greet()
        {
            Console.WriteLine("Hello, my name is {0} {1} (p. {2})", FirstName, LastName, PhoneNumber);
        }
    }
}
