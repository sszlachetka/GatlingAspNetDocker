using System;
using System.Diagnostics;

namespace RateLimiting.LoadTests.Api.TimeUtils
{
    internal class DiagnosticsStopwatch : IStopwatch
    {
        private readonly Stopwatch _stopwatch = new Stopwatch();

        public void Start()
        {
            _stopwatch.Start();
        }

        public TimeSpan Elapsed => _stopwatch.Elapsed;
    }
}