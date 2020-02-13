using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
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

            return query.ToList();
        }

        public static void CreateXML()
        {
            var carRecords = Cars("fuel.csv");

            var ns = (XNamespace)"http://vsl.com";
            var ex = (XNamespace)"http://vsl.com/cars";

            var document = new XDocument();
            var cars = new XElement(ns + "Cars", from record in carRecords
                                            select new XElement(ex + "Car",
                                                new XAttribute("Name", record.Name),
                                                new XAttribute("Combined", record.Combined),
                                                new XAttribute("Manufacturer", record.Manufacturer))
                                    );

            cars.Add(new XAttribute(XNamespace.Xmlns + "ex", ex));
            document.Add(cars);
            document.Save("Fuel.xml");
        }

        public static void QueryXML()
        {
            var document = XDocument.Load("Fuel.xml");

            var ns = (XNamespace)"http://vsl.com";
            var ex = (XNamespace)"http://vsl.com/cars";

            var xmlQuery = from element in document.Element(ns + "Cars")?.Elements(ex + "Car") ?? Enumerable.Empty<XElement>()
                           where element.Attribute("Manufacturer").Value == "BMW"
                           select element.Attribute("Name").Value;

            foreach (var name in xmlQuery)
            {
                Console.WriteLine(name);
            }
        }

        public static void InsertData()
        {
            var cars = Cars("fuel.csv");
            var db = new CarDb();

            if (!db.Cars.Any())
            {
                foreach (var car in cars)
                {
                    db.Cars.Add(car);
                }

                db.SaveChanges();
            }
        }

        internal static void QueryData()
        {
            throw new NotImplementedException();
        }
    }
}
