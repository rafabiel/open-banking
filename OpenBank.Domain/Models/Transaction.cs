using OpenBank.Domain.Interfaces.Models;

namespace OpenBank.Domain.Models
{
    public class Transaction : ITransaction
    {
        public string Id { get; }
        public DateTime Date { get; }
        public double? Amount { get; }
    }
}