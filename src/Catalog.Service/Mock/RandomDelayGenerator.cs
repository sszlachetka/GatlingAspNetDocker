using System;
using System.Threading.Tasks;

namespace Catalog.Service.Mock
{
    internal class RandomDelayGenerator
    {
        private readonly RandomData _random;

        public RandomDelayGenerator(RandomData random)
        {
            _random = random ?? throw new ArgumentNullException(nameof(random));
        }

        public Task New(DurationRange range)
        {
            if (range == null) throw new ArgumentNullException(nameof(range));

            return range.IsZero() ? Task.CompletedTask : Task.Delay(ToTimeSpan(range));
        }

        private TimeSpan ToTimeSpan(DurationRange range)
        {
            return TimeSpan.FromMilliseconds(
                range.IsConstValue() ? range.ConstValue() : _random.Int(range.Min, range.Max));
        }
    }
}