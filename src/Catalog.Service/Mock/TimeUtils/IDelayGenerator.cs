using System;
using System.Threading.Tasks;

namespace Catalog.Service.Mock.TimeUtils
{
    internal interface IDelayGenerator
    {
        Task New(TimeSpan duration);
    }
}