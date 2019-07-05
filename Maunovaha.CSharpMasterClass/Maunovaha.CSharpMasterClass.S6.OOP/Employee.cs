using System;
using System.Diagnostics;

namespace Maunovaha.CSharpMasterClass.S6.OOP
{
    internal class Employee
    {
        public string FirstName { get; }
        public string LastName { get; }

        // `;set` is needed to initialize object with `new Employee { JobTitle = "x" };`
        public Role JobTitle { get; set; }
        public int Salary { get; set; }

        // Deconstructor is called when running out of scope for this object.. etc.
        // Basically evertime the object is disposed
        ~Employee()
        {
            // You cannot see these, because I believe there are no guarantees when the 
            // garbage collector is going to run..
            //
            // Using IDisposable is closer to C++ -style destructors
            // https://docs.microsoft.com/en-us/dotnet/api/system.idisposable?redirectedfrom=MSDN&view=netframework-4.8
            Console.WriteLine("Destructing employee..");
            Debug.Write("Destructing employee..");
        }

        public void DisplaySalary()
        {
            int salary = Salary;

            if (JobTitle.Equals(Role.Programmer))
            {
                salary *= 10;
            }

            Console.WriteLine("My job title is `{0}` and salary `{1}/mo`", JobTitle, salary);
        }

        internal enum Role
        {
            Programmer,
            Artist
        }
    }
}
