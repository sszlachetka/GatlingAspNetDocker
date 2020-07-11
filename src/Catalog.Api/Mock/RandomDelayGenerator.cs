using System;
using System.Threading.Tasks;
using Catalog.Api.TimeUtils;

namespace Catalog.Api.Mock
{
    internal class RandomDelayGenerator
    {
        private readonly IDelayGenerator _delayGenerator;
        private readonly RandomData _random;

        public RandomDelayGenerator(IDelayGenerator delayGenerator, RandomData random)
        {
            _delayGenerator = delayGenerator ?? throw new ArgumentNullException(nameof(delayGenerator));
            _random = random ?? throw new ArgumentNullException(nameof(random));
        }

        public Task New(Range range)
        {
            if (range == null) throw new ArgumentNullException(nameof(range));

            return range.IsZero() ? Task.CompletedTask : _delayGenerator.New(ToTimeSpan(range));
        }

        private TimeSpan ToTimeSpan(Range range)
        {
            return TimeSpan.FromMilliseconds(
                range.IsConstValue() ? range.ConstValue() : _random.Int(range.Min, range.Max));
        }
    }
}