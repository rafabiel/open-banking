using Refit;

namespace OpenBank.Plaid.Interfaces
{
    public interface IPlaidApi
    {
        [Post("/link/token/create")]
        [Headers("Content-Type: application/json")]
        Task<HttpResponseMessage> CreateLinkTokenAsync([Body] string request);

        [Post("/item/public_token/exchange")]
        [Headers("Content-Type: application/json")]
        Task<HttpResponseMessage> ExchangeTokenAsync([Body] string request);
    }
}