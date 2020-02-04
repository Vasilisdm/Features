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

            //var topTenEfficientCarsM = cars.Join(manufacturers,
            //                                c => new { c.Manufacturer, c.Year},
            //                                m => new { Manufacturer = m.Name, m.Year },
            //                                (c, m) => new
            //                                {
            //                                    m.HeadQuarters,
            //                                    c.Name,
            //                                    c.Combined
            //                                })
            //                                .OrderByDescending(c => c.Combined)
            //                                .ThenBy(c => c.Name)
            //                                .Take(10);

            //foreach (var car in topTenEfficientCarsM)
            //{
            //    Console.WriteLine($"Efficient Cars {car.HeadQuarters} : {car.Name} : {car.Combined}");
            //}


            //var topTenEfficientCars = (from car in cars
            //                           join manufacturer in manufacturers
            //                           on new {car.Manufacturer, car.Year} equals new { Manufacturer = manufacturer.Name, manufacturer.Year }
            //                               orderby car.Combined descending, car.Name ascending
            //                               select new
            //                               {
            //                                   manufacturer.HeadQuarters,
            //                                   car.Name,
            //                                   car.Combined
            //                               }).Take(10);

            var efficientCarsGroupedByManufacturerM = manufacturers.GroupJoin(cars, m => m.Name, c => c.Manufacturer, (m, g) => new
            {
                Manufacturer = m,
                Cars = g
            });

            foreach (var group in efficientCarsGroupedByManufacturerM)
            {
                Console.WriteLine($"{group.Manufacturer.Name} : {group.Manufacturer.HeadQuarters}");
                foreach (var car in group.Cars.OrderByDescending(c => c.Combined).Take(3))
                {
                    Console.WriteLine($"\t{car.Name} : {car.Combined}");
                }
            }

            var efficientCarsGroupedByManufacturer = from manufacturer in manufacturers
                                                     join car in cars on manufacturer.Name equals car.Manufacturer into carGroup
                                                     select new
                                                     {
                                                         Manufacturer = manufacturer,
                                                         Cars = carGroup
                                                     };

            foreach (var group in efficientCarsGroupedByManufacturer)
            {
                Console.WriteLine($"{group.Manufacturer.Name} : {group.Manufacturer.HeadQuarters}");
                foreach (var car in group.Cars.OrderByDescending(c => c.Combined).Take(3))
                {
                    Console.WriteLine($"\t{car.Name} : {car.Combined}");
                }
            }
        }
    }
}
