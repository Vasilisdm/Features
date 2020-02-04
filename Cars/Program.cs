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

            var topTenEfficientCarsM = cars.Join(manufacturers,
                                            c => c.Manufacturer,
                                            m => m.Name,
                                            (c, m) => new
                                            {
                                                m.HeadQuarters,
                                                c.Name,
                                                c.Combined
                                            })
                                            .OrderByDescending(c => c.Combined)
                                            .ThenBy(c => c.Name)
                                            .Take(10);

            foreach (var car in topTenEfficientCarsM)
            {
                Console.WriteLine($"Efficient Cars {car.HeadQuarters} : {car.Name} : {car.Combined}");
            }


            var topTenEfficientCars = (from car in cars
                                       join manufacturer in manufacturers
                                       on new {car.Manufacturer, car.Year} equals new { Manufacturer = manufacturer.Name, manufacturer.Year }
                                           orderby car.Combined descending, car.Name ascending
                                           select new
                                           {
                                               manufacturer.HeadQuarters,
                                               car.Name,
                                               car.Combined
                                           }).Take(10);
            Console.WriteLine("\n");
            foreach (var car in topTenEfficientCars)
            {
                Console.WriteLine($"Efficient Cars {car.HeadQuarters} : {car.Name} : {car.Combined}");
            }
        }
    }
}
