using System;

namespace Catalog.Service.Mock
{
    public class DurationRange
    {
        public DurationRange(int min, int max)
        {
            if (min > max)
                throw new ArgumentException("min > max", nameof(min));
            if (min < 0) throw new ArgumentException("min < 0", nameof(min));

            Min = min;
            Max = max;
        }

        public int Min { get; }
        public int Max { get; }

        public bool IsZero()
        {
            return IsConstValue() && ConstValue() == 0;
        }

        public bool IsConstValue()
        {
            return Min == Max;
        }

        public int ConstValue()
        {
            return IsConstValue()
                ? Min
                : throw new InvalidOperationException(
                    $"Range <{Min}, {Max}> is not const.");
        }
    }
}