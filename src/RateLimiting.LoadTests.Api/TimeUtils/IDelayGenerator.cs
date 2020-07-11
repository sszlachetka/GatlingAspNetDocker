using System;
using System.Threading.Tasks;

namespace RateLimiting.LoadTests.Api.TimeUtils
{
    internal interface IDelayGenerator
    {
        Task New(TimeSpan duration);
    }
}