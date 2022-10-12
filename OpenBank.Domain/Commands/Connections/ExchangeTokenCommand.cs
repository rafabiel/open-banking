using MediatR;

namespace OpenBank.Domain.Commands.Connections
{
    public class ExchangeTokenCommand : IRequest<string>
    {
        public ExchangeTokenCommand(string token)
        {
            Token = token;
        }

        public string Token { get; }
    }
}