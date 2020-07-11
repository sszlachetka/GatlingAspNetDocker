using System;
using System.Threading.Tasks;

namespace Catalog.Api.TimeUtils
{
    internal interface IDelayGenerator
    {
        Task New(TimeSpan duration);
    }
}