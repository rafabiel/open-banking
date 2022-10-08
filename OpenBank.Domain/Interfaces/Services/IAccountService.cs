using OpenBank.Domain.Interfaces.Models;

namespace OpenBank.Domain.Interfaces.Services
{
    public interface IAccountService : IBaseOpenBankProvider
    {
        Task<IAccount> GetAccountAsync(string token);
    }
}