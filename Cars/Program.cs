using System;
using System.Linq;
using System.Xml.Linq;
using Cars;

namespace CarExt
{
    class Program
    {
        static void Main()
        {
            var carRecords = FileProcess.Cars("fuel.csv");

            var document = new XDocument();
            var cars = new XElement("Cars");

            foreach (var record in carRecords)
            {
                var car = new XElement("Car");
                var name = new XElement("Name", record.Name);
                var combined = new XElement("Combined", record.Combined);

                car.Add(name);
                car.Add(combined);

                cars.Add(car);
            }

            document.Add(cars);
            document.Save("Cars.xml");
        }
    }
}
