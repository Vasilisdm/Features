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
            var manufacturers = FileProcess.Manufacturers("manufacturers.csv");

            var efficientBmwMethodSyntax = cars.Where(c => c.Manufacturer == "BMW" && c.Year == 2016)
                                 .OrderByDescending(c => c.Combined)
                                 .ThenBy(c => c.Name)
                                 .Select(c => new { c.Manufacturer, c.Name, c.Combined })
                                 .First();

            Console.WriteLine($"Efficient BMW(Method Syntax) {efficientBmwMethodSyntax.Manufacturer} : {efficientBmwMethodSyntax.Name} : {efficientBmwMethodSyntax.Combined}");

            var topTenEfficientCars = (from car in cars
                                           join manufacturer in manufacturers
                                           on car.Manufacturer equals manufacturer.Name
                                           orderby car.Combined descending, car.Name ascending
                                           select new
                                           {
                                               manufacturer.HeadQuarters,
                                               car.Name,
                                               car.Combined
                                           }).Take(10);

            foreach (var car in topTenEfficientCars)
            {
                Console.WriteLine($"Efficient Cars {car.HeadQuarters} : {car.Name} : {car.Combined}");
            }
        }
    }
}
