using OpenBank.Domain.Interfaces.Models;
using OpenBank.Domain.Models.Enums;

namespace OpenBank.Domain.Interfaces.Services
{
    public interface IAuthService : IBaseOpenBankProvider
    {
        Task<IAuth> GetAuth(string token);
    }
}