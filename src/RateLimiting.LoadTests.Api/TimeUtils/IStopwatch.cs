using System;

namespace RateLimiting.LoadTests.Api.TimeUtils
{
    internal interface IStopwatch
    {
        TimeSpan Elapsed { get; }
        void Start();
    }
}