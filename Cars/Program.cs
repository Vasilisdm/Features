using System;
using System.Linq;
using Cars;

namespace CarExt
{
    class Program
    {
        static void Main()
        {
            var cars = FileProcess.Cars("fuel.csv");

            var efficientBmwMethodSyntax = cars.Where(c => c.Manufacturer == "BMW" && c.Year == 2016)
                                 .OrderByDescending(c => c.Combined)
                                 .ThenBy(c => c.Name)
                                 .Select(c => new { c.Manufacturer, c.Name, c.Combined })
                                 .First();

            Console.WriteLine($"Efficient BMW(Method Syntax) {efficientBmwMethodSyntax.Manufacturer} : {efficientBmwMethodSyntax.Name} : {efficientBmwMethodSyntax.Combined}");

            var efficientBmwQuerySyntax = (from car in cars
                                           where car.Manufacturer == "BMW" && car.Year == 2016
                                           orderby car.Combined descending, car.Name ascending
                                           select new
                                           {
                                               car.Manufacturer,
                                               car.Name,
                                               car.Combined
                                           }).First();

            Console.WriteLine($"Efficient BMW(Query Syntax) {efficientBmwQuerySyntax.Manufacturer} : {efficientBmwQuerySyntax.Name} : {efficientBmwQuerySyntax.Combined}");


            var topTenCarsCombinedEf = cars.OrderByDescending(c => c.Combined)
                                          .ThenBy(c => c.Name)
                                          .Take(10)
                                          .ToList();
            Console.WriteLine("\n");
            foreach (Car car in topTenCarsCombinedEf)
            {
                Console.WriteLine($"{car.Name} : {car.Combined}");
            }

            var manufacturers = FileProcess.Manufacturers("manufacturers.csv");

            foreach (var manufacturer in manufacturers)
            {
                Console.WriteLine(manufacturer.Name);
            }
        }
    }
}
