using OpenBank.Domain.Interfaces.Models;

namespace OpenBank.Domain.Interfaces.Services
{
    public interface ITokenService : IBaseOpenBankProvider
    {
        Task<IRequestToken?> RequestTokenAsync(Guid userId);
        
        Task<IToken> ExchangeTokenAsync(string token);
    }
}