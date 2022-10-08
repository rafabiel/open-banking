using OpenBank.Domain.Models.Enums;

namespace OpenBank.Domain.Interfaces.Services
{
    public interface IBaseOpenBankProvider
    {
        EOpenBankProvider OpenBankPartner { get; }
    }
}