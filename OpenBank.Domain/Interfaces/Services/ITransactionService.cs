using OpenBank.Domain.Interfaces.Models;
using OpenBank.Domain.Models.Enums;

namespace OpenBank.Domain.Interfaces.Services
{
    public interface ITransactionService : IBaseOpenBankProvider
    {
        Task<IEnumerable<ITransaction>> GetTransactionsAsync(string token);
    }
}