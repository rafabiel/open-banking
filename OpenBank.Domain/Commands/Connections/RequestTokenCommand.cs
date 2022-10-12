using MediatR;
using OpenBank.Domain.Interfaces.Models;

namespace OpenBank.Domain.Commands.Connections
{
    public class RequestTokenCommand : IRequest<IRequestToken>
    {
        public RequestTokenCommand(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; }
    }
}