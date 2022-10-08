using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OpenBank.Domain;
using OpenBank.Domain.Interfaces.Models;
using OpenBank.Domain.Interfaces.Services;
using OpenBank.Domain.Models.Enums;
using OpenBank.Domain.Responses;
using OpenBank.Plaid.Interfaces;
using OpenBank.Plaid.Requests;
using OpenBank.Plaid.Responses;
using OpenBank.Plaid.Utils;

namespace OpenBank.Plaid.Services
{
    public class TokenService : ITokenService
    {
        private readonly IPlaidApi _plaidApi;
        private readonly IOptions<PlaidConfig> _settings;
        private readonly IOptions<BasePlaidRequest> _plaidBase;
        private readonly ILogger<TokenService> _logger;

        public TokenService(IPlaidApi plaidApi, IOptions<BasePlaidRequest> plaidBase, IOptions<PlaidConfig> settings, ILogger<TokenService> logger)
        {
            _plaidApi = plaidApi;
            _plaidBase = plaidBase;
            _settings = settings;
            _logger = logger;
        }

        public EOpenBankProvider OpenBankPartner => EOpenBankProvider.Plaid;
        
        public async Task<IRequestToken?> GetTempToken()
        {
            try
            {
                var request = _plaidBase.Value.MakePlaidRequest(new UserRequest(new Guid()), _settings.Value);

                var response = await _plaidApi.CreateLinkTokenAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.GetContentAsync<PlaidErrorResponse>();
                    
                    throw new ArgumentException(error!.ErrorMessage);
                }
                
                var retVal = await response.GetContentAsync<LinkTokenResponse>();

                return new RequestTokenResponse(retVal!.Expiration, retVal.LinkToken, retVal.RequestId);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error in get link token");
                throw;
            }
        }
    }
}