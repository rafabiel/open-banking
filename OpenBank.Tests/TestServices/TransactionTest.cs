using FluentAssertions;
using Moq;
using OpenBank.Domain.Interfaces.Models;
using OpenBank.Domain.Interfaces.Services;
using OpenBank.Domain.Models;

namespace OpenBank.Tests.TestServices
{
    public class TransactionTest
    {
        private const string ErrorMessage = "@PARAM can't be null";
        private readonly Mock<ITransactionService> _transactionService;
        
        public TransactionTest()
        {
            _transactionService = new Mock<ITransactionService>();
        }
        
        [Fact]
        public async Task Get_Transactions_Success()
        {
            _transactionService.Setup(x => x.GetTransactionsAsync(It.IsAny<string>()))
                .ReturnsAsync(new List<ITransaction>());

            var transactions = await _transactionService.Object.GetTransactionsAsync(string.Empty);

            transactions.Should().NotBeNull();
            transactions.Should().BeOfType<List<ITransaction>>();
        }

        [Fact]
        public async Task Get_Transactions_With_No_Token_Error()
        {
            _transactionService.Setup(x => x.GetTransactionsAsync(It.IsAny<string>()))
                .Throws(new ArgumentException("Token can't be null"));
            
            await FluentActions.Invoking(() => _transactionService.Object.GetTransactionsAsync(string.Empty))
                .Should()
                .ThrowAsync<ArgumentException>().WithMessage(ErrorMessage.Replace("@PARAM", "Token"));
        }
    }
}