﻿using PostApp.Data;

namespace PostApp.Services.Logging
{
    public class DatabaseLoggerProvider : ILoggerProvider
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public DatabaseLoggerProvider(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new DatabaseLogger(_scopeFactory, categoryName);
        }

        public void Dispose() { }
    }
}
