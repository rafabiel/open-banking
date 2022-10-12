using MediatR;
using Microsoft.Extensions.Logging;
using OpenBank.Domain.Commands.Connections;
using OpenBank.Domain.Interfaces.Models;
using OpenBank.Domain.Interfaces.Services;
using OpenBank.Domain.Models.Enums;

namespace OpenBank.Domain.Handlers.Connections
{
    public class RequestTokenHandler : IRequestHandler<RequestTokenCommand, IRequestToken>
    {
        private readonly IEnumerable<ITokenService> _services;
        private readonly ILogger<RequestTokenHandler> _logger;

        public RequestTokenHandler(IEnumerable<ITokenService> services, ILogger<RequestTokenHandler> logger)
        {
            _services = services;
            _logger = logger;
        }

        public async Task<IRequestToken> Handle(RequestTokenCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var tokenService = _services.SingleOrDefault(x => x.OpenBankPartner == EOpenBankProvider.Plaid);

                return await tokenService!.RequestTokenAsync(request.UserId) ??
                       throw new ArgumentException($"Service ({nameof(ITokenService)}) not found");
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error in get link token");
                throw;
            }
        }
    }
}