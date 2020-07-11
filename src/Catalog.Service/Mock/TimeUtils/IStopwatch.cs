using System;

namespace Catalog.Service.Mock.TimeUtils
{
    internal interface IStopwatch
    {
        TimeSpan Elapsed { get; }
        void Start();
    }
}