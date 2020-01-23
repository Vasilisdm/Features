using System;
using System.Collections.Generic;

namespace Features
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee[] developers = new Employee[]
            {
                new Employee { Id = 1, Name = "vsl"},
                new Employee { Id = 2, Name = "vsl1"}
            };

            List<Employee> sales = new List<Employee>()
            {
                new Employee { Id = 3, Name = "vsl2"}
            };
        }
    }
}
