using System;

namespace EmployeeComparison
{
    // Define the Employee class with Id, FirstName, and LastName properties
    class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Overload the '==' operator to compare Employee objects based on Id
        public static bool operator ==(Employee emp1, Employee emp2)
        {
            // Check for null on either side to prevent runtime errors
            if (ReferenceEquals(emp1, null) || ReferenceEquals(emp2, null))
                return ReferenceEquals(emp1, emp2);

            // Return true if their Ids are equal
            return emp1.Id == emp2.Id;
        }

        // Overload the '!=' operator as required when overloading '=='
        public static bool operator !=(Employee emp1, Employee emp2)
        {
            return !(emp1 == emp2);
        }

        // Override the Equals method to use our new definition of equality
        public override bool Equals(object obj)
        {
            var other = obj as Employee;
            return other != null && this.Id == other.Id;
        }

        // Override GetHashCode as well when overriding Equals
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create two Employee objects
            Employee employee1 = new Employee { Id = 1, FirstName = "John", LastName = "Doe" };
            Employee employee2 = new Employee { Id = 1, FirstName = "Jane", LastName = "Smith" };

            // Compare the two Employee objects using the overloaded '==' operator
            bool areEqual = employee1 == employee2;

            // Display the result of the comparison
            Console.WriteLine("Employee 1 and Employee 2 are equal: " + areEqual);
        }
    }
}
