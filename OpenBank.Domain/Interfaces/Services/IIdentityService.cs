using OpenBank.Domain.Interfaces.Models;
using OpenBank.Domain.Models.Enums;

namespace OpenBank.Domain.Interfaces.Services
{
    public interface IIdentityService : IBaseOpenBankProvider
    {
        Task<IIdentity> GetIdentityAsync(string token);
    }
}