using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = ProcessFile("fuel.csv");

            var combinedEf = cars.OrderByDescending(c => c.Combined);

            Console.WriteLine("Most fuel efficient cars");
            foreach (Car car in combinedEf.Take(10))
            {
                Console.WriteLine($"{car.Name} : {car.Combined}");
            }
        }

        private static List<Car> ProcessFile(string path)
        {
            //return
            //    File.ReadAllLines(path)
            //    .Skip(1)
            //    .Where(line => line.Length > 1)
            //    .Select(Car.ParseFromCsv)
            //    .ToList();

            var query = from line in File.ReadAllLines(path).Skip(1)
                        where (line.Length > 1)
                        select (Car.ParseFromCsv(line));

            return query.ToList();
        }
    }
}
