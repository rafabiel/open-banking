using OpenBank.Domain.Interfaces.Models;

namespace OpenBank.Domain.Interfaces.Services
{
    public interface ITokenService : IBaseOpenBankProvider
    {
       Task<IRequestToken?> GetTempToken();
    }
}