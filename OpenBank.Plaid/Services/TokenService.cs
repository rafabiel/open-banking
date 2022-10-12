using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OpenBank.Domain;
using OpenBank.Domain.Interfaces.Models;
using OpenBank.Domain.Interfaces.Services;
using OpenBank.Domain.Models.Enums;
using OpenBank.Domain.Responses;
using OpenBank.Domain.Utils;
using OpenBank.Plaid.Interfaces;
using OpenBank.Plaid.Requests;
using OpenBank.Plaid.Responses;
using OpenBank.Plaid.Utils;

namespace OpenBank.Plaid.Services
{
    public class TokenService : ITokenService
    {
        private readonly IPlaidApi _plaidApi;
        private readonly PlaidConfig _config;
        private readonly ILogger<TokenService> _logger;

        public TokenService(IPlaidApi plaidApi, IOptions<PlaidConfig> config,
            ILogger<TokenService> logger)
        {
            _plaidApi = plaidApi;
            _config = config.Value;
            _logger = logger;
        }

        public EOpenBankProvider OpenBankPartner => EOpenBankProvider.Plaid;

        public async Task<IRequestToken?> RequestTokenAsync(Guid userId)
        {
            try
            {
                var request = new LinkTokenRequest
                {
                    User = new UserRequest(userId),
                    Language =  _config.Language,
                    Products = _config.Products,
                    Webhook = _config.Webhook,
                    ClientId = _config.ClientId,
                    ClientName = _config.ClientName,
                    ClientSecret = _config.ClientSecret,
                    CountryCodes = _config.Countries
                }.ToJson();

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

        public async Task<IToken> ExchangeTokenAsync(string token)
        {
            try
            {
                var request = new ExchangeTokenRequest
                {
                    ClientId = _config.ClientId,
                    ClientSecret = _config.ClientSecret,
                    PublicToken = token
                }.ToJson();

                var response = await _plaidApi.ExchangeTokenAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.GetContentAsync<PlaidErrorResponse>();

                    throw new ArgumentException(error!.ErrorMessage);
                }

                var exchangeTokenResponse = await response.GetContentAsync<ExchangeTokenResponse>();

                if (string.IsNullOrWhiteSpace(exchangeTokenResponse?.AccessToken))
                    throw new ArgumentException("Token cannot be exchanged");
                
                return new TokenResponse(exchangeTokenResponse.AccessToken, exchangeTokenResponse.ItemId);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error in get access token");
                throw;
            }
        }
    }
}