using CheckerApp.Application.Common.Interfaces;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CheckerApp.Application.Common.Behaviors
{
    public class LoggingBehavior<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger _logger;
        private readonly ICurrentUserService _currentUserService;

        public LoggingBehavior(ILogger<TRequest> logger, ICurrentUserService currentUserService)
        {
            _logger = logger;
            _currentUserService = currentUserService;
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var name = typeof(TRequest).Name;

            _logger.LogInformation("[{RequestTime}] Запрос метода \"{MethodName}\" от пользователя \"{UserName}\"",
                DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), name, _currentUserService.UserName);

            return Task.CompletedTask;
        }
    }
}
