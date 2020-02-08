using System;
namespace Cars
{
    public class CarStatistics
    {
        public CarStatistics()
        {
            Max = Int32.MinValue;
            Min = Int32.MaxValue;
        }

        public CarStatistics Accumulate(Car car)
        {
            Count += 1;
            Total += car.Combined;
            Max = Math.Max(Max, car.Combined);
            Min = Math.Min(Min, car.Combined);

            return this;
        }

        public CarStatistics Compute()
        {
            Average = Total / Count;

            return this;
        }

        private int Min { get; set; }
        private int Max { get; set; }
        private double Average { get; set; }
        private int Count { get; set; }
        private int Total { get; set; }
    }
}
