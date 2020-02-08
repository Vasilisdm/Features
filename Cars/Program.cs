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
            var cars = new XElement("Cars", from record in carRecords
                                            select new XElement("Car",
                                                new XAttribute("Name", record.Name),
                                                new XAttribute("Combined", record.Combined),
                                                new XAttribute("Manufacturer", record.Manufacturer))
                                    );

            document.Add(cars);
            document.Save("Cars.xml");
        }
    }
}
