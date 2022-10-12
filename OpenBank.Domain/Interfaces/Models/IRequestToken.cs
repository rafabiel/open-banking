namespace OpenBank.Domain.Interfaces.Models
{
    public interface IRequestToken
    { 
        DateTime Expiration { get; }
        
        string Token { get; }
        
        string RequestId { get; }
    }
}