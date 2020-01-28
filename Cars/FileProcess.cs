﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CarExtensions;

namespace Cars
{
    public static class FileProcess
    {
        public static List<Manufacturer> Manufacturers(string path)
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


        public static List<Car> Cars(string path)
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
