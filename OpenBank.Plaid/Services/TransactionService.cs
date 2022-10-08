using OpenBank.Domain.Interfaces.Models;
using OpenBank.Domain.Interfaces.Services;
using OpenBank.Domain.Models.Enums;

namespace OpenBank.Plaid.Services
{
    public class TransactionService : ITransactionService
    {
        public EOpenBankProvider OpenBankPartner => EOpenBankProvider.Plaid;
        
        public Task<IEnumerable<ITransaction>> GetTransactionsAsync(string token)
        {
            throw new NotImplementedException();
        }
    }
}