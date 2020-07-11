using System;
using System.Threading.Tasks;

namespace Catalog.Api.TimeUtils
{
    internal class TaskDelayGenerator : IDelayGenerator
    {
        public Task New(TimeSpan duration)
        {
            return Task.Delay(duration);
        }
    }
}