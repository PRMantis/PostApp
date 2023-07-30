using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PostApp.Data;
using PostApp.Tables;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Formats.Tar;

namespace PostApp.Services.Logging
{
    public class DatabaseLogger : ILogger
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly string _categoryName;

        public DatabaseLogger(IServiceScopeFactory scopeFactory, string categoryName)
        {
            _scopeFactory = scopeFactory;
            _categoryName = categoryName;
        }

        public IDisposable BeginScope<TState>(TState state) => null;

        public bool IsEnabled(LogLevel logLevel) 
        {
            if (logLevel == LogLevel.None)
            {
                return true;
            }
            return false;
        }


        public void Log<TState>(
            LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception exception,
            Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
                return;

            string message = formatter(state, exception);

            using (var scope = _scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<PostContext>();
                var logEntry = new LogEntries
                {
                    Timestamp = DateTime.UtcNow,
                    LogLevel = logLevel.ToString(),
                    Message = message,
                    Exception = exception?.ToString() ?? ""
                };

                dbContext.AddEntitiesToDatabase(new List<LogEntries>() { logEntry });
                dbContext.SaveChanges();
            }

        }
    }
}
