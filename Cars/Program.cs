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

            // Join in method extension syntax
            var topTenEfficientCarsM = cars.Join(manufacturers,
                                            c => new { c.Manufacturer, c.Year },
                                            m => new { Manufacturer = m.Name, m.Year },
                                            (c, m) => new
                                            {
                                                m.HeadQuarters,
                                                c.Name,
                                                c.Combined
                                            })
                                            .OrderByDescending(c => c.Combined)
                                            .ThenBy(c => c.Name)
                                            .Take(10);
            // Join in query syntax
            var topTenEfficientCars = (from car in cars
                                       join manufacturer in manufacturers
                                       on new { car.Manufacturer, car.Year } equals new { Manufacturer = manufacturer.Name, manufacturer.Year }
                                       orderby car.Combined descending, car.Name ascending
                                       select new
                                       {
                                           manufacturer.HeadQuarters,
                                           car.Name,
                                           car.Combined
                                       }).Take(10);

            // Group join usage
            var efficientCarsGroupedByManufacturerM = manufacturers.GroupJoin(cars, m => m.Name, c => c.Manufacturer, (m, g) => new
            {
                Manufacturer = m,
                Cars = g
            }).GroupBy(m => m.Manufacturer.HeadQuarters);

            // Usage of join and putting the result into a variable in order to group by Headquarters.
            var efficientCarsGroupedByManufacturer = from manufacturer in manufacturers
                                                     join car in cars on manufacturer.Name equals car.Manufacturer into carGroup
                                                     select new
                                                     {
                                                         Manufacturer = manufacturer,
                                                         Cars = carGroup
                                                     } into result
                                                     group result by result.Manufacturer.HeadQuarters;

            // Use an anonymous type to return the min,max and avg consumption grouped by Manufacturer and ordered by MaxConsumption
            var efficiencyByManufacturer = from car in cars
                                           group car by car.Manufacturer into carGroup
                                           select new
                                           {
                                               Name = carGroup.Key,
                                               MaxConsumption = carGroup.Max(c => c.Combined),
                                               MinConsumption = carGroup.Min(c => c.Combined),
                                               AvgConsumption = carGroup.Average(c => c.Combined)
                                           } into result
                                           orderby result.MaxConsumption descending
                                           select result;

            foreach (var group in efficiencyByManufacturer)
            {
                Console.WriteLine($"{group.Name}");
                Console.WriteLine($"\t Max : {group.MaxConsumption}");
                Console.WriteLine($"\t Min : {group.MinConsumption}");
                Console.WriteLine($"\t Avg : {group.AvgConsumption}");
            }
        }
    }
}
