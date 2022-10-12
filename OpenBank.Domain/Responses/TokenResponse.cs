using OpenBank.Domain.Interfaces.Models;

namespace OpenBank.Domain.Responses
{
    public class TokenResponse : IToken
    {
        public TokenResponse(string token, string openBankId)
        {
            Token = token;
            OpenBankId = openBankId;
        }

        public string Token { get; }
        
        public string OpenBankId { get; }
    }
}