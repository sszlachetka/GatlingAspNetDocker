using System;
using System.Threading.Tasks;

namespace Catalog.Service.Mock.TimeUtils
{
    internal class TaskDelayGenerator : IDelayGenerator
    {
        public Task New(TimeSpan duration)
        {
            return Task.Delay(duration);
        }
    }
}