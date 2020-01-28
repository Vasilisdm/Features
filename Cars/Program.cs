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
            var cars = ProcessFile("fuel.csv");

            var efficientBmwMethodSyntax = cars.Where(c => c.Manufacturer == "BMW" && c.Year == 2016)
                                 .OrderByDescending(c => c.Combined)
                                 .ThenBy(c => c.Name)
                                 .First();

            Console.WriteLine($"Most efficient BMW found in method syntax: {efficientBmwMethodSyntax.Name}");

            var efficientBmwQuerySyntax = (from car in cars
                                           where car.Manufacturer == "BMW" && car.Year == 2016
                                           orderby car.Combined descending, car.Name ascending
                                           select car).First();

            Console.WriteLine($"Most efficient BMW found in query syntax: {efficientBmwQuerySyntax.Name}");


            var topTeCarsCombinedEf = cars.OrderByDescending(c => c.Combined)
                                          .ThenBy(c => c.Name)
                                          .Take(10)
                                          .ToList();

            foreach (Car car in topTeCarsCombinedEf)
            {
                Console.WriteLine($"{car.Name} : {car.Combined}");
            }
        }

        private static List<Car> ProcessFile(string path)
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
