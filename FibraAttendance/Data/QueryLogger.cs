using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;

namespace FibraAttendance.Data
{
    public class QueryLogger : DbCommandInterceptor
    {
        private readonly ILogger<QueryLogger> _logger;

        public QueryLogger(ILogger<QueryLogger> logger)
        {
            _logger = logger;
        }

        public override InterceptionResult<DbDataReader> ReaderExecuting(
            DbCommand command,
            CommandEventData eventData,
            InterceptionResult<DbDataReader> result)
        {
            _logger.LogInformation(command.CommandText);
            return result;
        }

        public override ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(
            DbCommand command,
            CommandEventData eventData,
            InterceptionResult<DbDataReader> result,
            CancellationToken cancellationToken = default)
        {
            _logger.LogInformation(command.CommandText);
            return ValueTask.FromResult(result);
        }
    }
}
