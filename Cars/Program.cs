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

            foreach (Car car in cars)
            {
                Console.WriteLine(car.Name);
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
