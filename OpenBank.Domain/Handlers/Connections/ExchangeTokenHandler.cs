using MediatR;
using Microsoft.Extensions.Logging;
using OpenBank.Domain.Commands.Connections;
using OpenBank.Domain.Interfaces.Services;
using OpenBank.Domain.Models.Enums;
using Exception = System.Exception;

namespace OpenBank.Domain.Handlers.Connections
{
    public class ExchangeTokenHandler : IRequestHandler<ExchangeTokenCommand, string>
    {
        private readonly IEnumerable<ITokenService> _services;
        private readonly ILogger<ExchangeTokenHandler> _logger;
        
        public ExchangeTokenHandler(IEnumerable<ITokenService> services, ILogger<ExchangeTokenHandler> logger)
        {
            _services = services;
            _logger = logger;
        }

        public async Task<string> Handle(ExchangeTokenCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var tokenService = _services.SingleOrDefault(x => x.OpenBankPartner == EOpenBankProvider.Plaid);

                var tokenExchanged = await tokenService!.ExchangeTokenAsync(request.Token) ??
                       throw new ArgumentException($"Service ({nameof(ITokenService)}) not found");

                return tokenExchanged.OpenBankId;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error in exchange token");
                
                throw;
            }
        }
    }
}