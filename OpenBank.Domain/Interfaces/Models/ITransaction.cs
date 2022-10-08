namespace OpenBank.Domain.Interfaces.Models
{
    public interface ITransaction
    {
        string Id { get; }
        
        DateTime Date { get; }
        
        double? Amount { get; }
    }
}