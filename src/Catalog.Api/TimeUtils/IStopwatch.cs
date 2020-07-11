using System;

namespace Catalog.Api.TimeUtils
{
    internal interface IStopwatch
    {
        TimeSpan Elapsed { get; }
        void Start();
    }
}