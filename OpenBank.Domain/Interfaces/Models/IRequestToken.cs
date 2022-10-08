namespace OpenBank.Domain.Interfaces.Models
{
    public interface IRequestToken
    { 
        DateTime Expiration { get; }
        
        string LinkToken { get; }
        
        string RequestId { get; }
    }
}