using System;
using System.Collections.Generic;
using System.Linq;

namespace Features
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Employee> developers = new Employee[]
            {
                new Employee { Id = 1, Name = "vsl"},
                new Employee { Id = 2, Name = "kst"}
            };

            IEnumerable<Employee> sales = new List<Employee>()
            {
                new Employee { Id = 3, Name = "kel"}
            };

            foreach (var employee in developers.Where(e => e.Name.Length < 4).OrderBy(e => e.Name))
            {
                Console.WriteLine(employee.Name);
            } 
        }
    }
}
