using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Catalog.Api.Contract;
using IdGen;
using NLog;

namespace Catalog.Api.Mock
{
    public class LoggingCatalogServiceDecorator : ICatalogService
    {
        private readonly IdGenerator _idGenerator;
        private readonly Logger _logger;
        private readonly ICatalogService _service;
        private readonly Stopwatch _stopwatch;

        public LoggingCatalogServiceDecorator(ICatalogService service, Stopwatch stopwatch,
            IdGenerator idGenerator, string loggerName)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _stopwatch = stopwatch ?? throw new ArgumentNullException(nameof(stopwatch));
            _idGenerator = idGenerator ?? throw new ArgumentNullException(nameof(idGenerator));
            _logger = LogManager.GetLogger(loggerName);
        }

        public async Task<SearchResult> Search(SearchQuery query)
        {
            var id = LogBegin(nameof(Search));

            var result = await _service.Search(query);

            LogEnd(nameof(Search), id);

            return result;
        }

        public async Task<DetailsResult> Details(DetailsQuery query)
        {
            var id = LogBegin(nameof(Details));

            var result = await _service.Details(query);

            LogEnd(nameof(Details), id);

            return result;
        }

        public async Task<BatchUpdateResult> BatchUpdate(BatchUpdateCommand command)
        {
            var id = LogBegin(nameof(BatchUpdate));

            var result = await _service.BatchUpdate(command);

            LogEnd(nameof(BatchUpdate), id);

            return result;
        }

        private long LogBegin(string method)
        {
            var id = _idGenerator.CreateId();
            var entry = new LogEventInfo(LogLevel.Debug, null, method);
            entry.Properties["ElapsedMs"] = _stopwatch.ElapsedMilliseconds;
            entry.Properties["ReqId"] = id;
            entry.Properties["IsBegin"] = 1;
            _logger.Log(entry);

            return id;
        }

        private void LogEnd(string method, long id)
        {
            var entry = new LogEventInfo(LogLevel.Debug, null, method);
            entry.Properties["ElapsedMs"] = _stopwatch.ElapsedMilliseconds;
            entry.Properties["ReqId"] = id;
            entry.Properties["IsBegin"] = 0;
            _logger.Log(entry);
        }
    }
}