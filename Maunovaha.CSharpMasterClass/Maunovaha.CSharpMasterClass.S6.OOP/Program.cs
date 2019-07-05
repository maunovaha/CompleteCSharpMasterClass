using System;

namespace Maunovaha.CSharpMasterClass.S6.OOP
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Person p1 = new Person("Rick", "Dangerous");
            p1.Greet(); // Outputs `Hello, my name is Rick Dangerous (p. 0400111222)`

            Person p2 = new Person();
            p2.Greet(); // Outputs `Hello, my name is  (p. 0400111222)`

            Person p3 = new Person { FirstName = "John", PhoneNumber = "0400222333" };
            p3.Greet(); // Outputs `Hello, my name is John  (p. 0400222333)`

            Person p4 = new Person();
            p4.FirstName = "Crazy"; // Using this not preferred, cos we could do it inline
            p4.LastName = "Shit";   // E.g. new Person { FirstName = "Crazy", LastName = "Shit" };
            p4.Greet(); // Outputs `Hello, my name is Crazy Shit (p. 0400111222)`

            // ---------------------------------

            Vector v1 = new Vector(1.0f, 2.0f, 3.0f);
            v1.Debug(); // Outputs `X: 1, Y: 2, Z: 3`

            Vector v2 = Vector.Zero;
            v2.Debug(); // Outputs `X: 0, Y: 0, Z: 0`

            // ---------------------------------

            Employee e1 = new Employee
            {
                Salary = 2000,
                JobTitle = Employee.Role.Programmer
            };
            e1.DisplaySalary(); // Outputs `My job title is `Programmer` and salary `20000/mo``

            Employee e2 = new Employee
            {
                Salary = 2000,
                JobTitle = Employee.Role.Artist
            };
            e2.DisplaySalary(); // Outputs `My job title is `Artist` and salary `2000/mo``

            Console.Read();
        }
    }
}
