using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Cars;
using CarExtensions;

namespace CarExt
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = ProcessCars("fuel.csv");

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

            var manufacturers = ProcessManufacturers("manufacturers.csv");

            foreach (var manufacturer in manufacturers)
            {
                Console.WriteLine(manufacturer.Name);
            }
        }

        private static List<Manufacturer> ProcessManufacturers(string path)
        {
            var query = File.ReadAllLines(path)
                            .Where(line => line.Length > 1)
                            .Select(line =>
                                {
                                    var manufacturerFileColumns = line.Split(",");
                                    return new Manufacturer
                                    {
                                        Name = manufacturerFileColumns[0],
                                        HeadQuarters = manufacturerFileColumns[1],
                                        Year = int.Parse(manufacturerFileColumns[2])
                                    };
                                });

            return query.ToList();
        }

        private static List<Car> ProcessCars(string path)
        {
            
            var query = File.ReadAllLines(path)
                            .Skip(1)
                            .Where(line => line.Length > 1)
                            .ToCar();

            //var query = from line in File.ReadAllLines(path).Skip(1)
            //            where (line.Length > 1)
            //            select (Car.ParseFromCsv(line));

            return query.ToList();
        }
    }
}
