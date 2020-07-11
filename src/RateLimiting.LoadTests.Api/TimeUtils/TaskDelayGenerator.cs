using System;
using System.Threading.Tasks;

namespace RateLimiting.LoadTests.Api.TimeUtils
{
    internal class TaskDelayGenerator : IDelayGenerator
    {
        public Task New(TimeSpan duration)
        {
            return Task.Delay(duration);
        }
    }
}