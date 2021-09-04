using System;
using Microsoft.Extensions.Logging;

namespace src.Exceptions
{
    public class CustomRequestException : Exception
    {
        
        private readonly ILogger<CustomRequestException> _logger;
        public CustomRequestException(ILogger<CustomRequestException> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public CustomRequestException(string message) : base(message)
        {
            _logger.LogError($"{this.ToString()}: {message}");
        }

        public CustomRequestException(string message, Exception innerException) : base(message, innerException)
        {
            _logger.LogError($"{this.ToString()}: Message {message}\n Inner Exception: {innerException}");
        }
    }
}