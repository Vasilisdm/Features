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

        public int Min { get; private set; }
        public int Max { get; private set; }
        public double Average { get; private set; }
        public int Count { get; private set; }
        public int Total { get; private set; }
    }
}
