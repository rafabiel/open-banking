using System.IO;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using OpenBank.Domain.Commands.Connections;
using OpenBank.Domain.Utils;

namespace OpenBank.Functions.HttpTriggers
{
    public class ExchangeTokenHttpTrigger
    {
        private readonly IMediator _mediator;

        public ExchangeTokenHttpTrigger(IMediator mediator)
            => _mediator = mediator;

        [FunctionName(nameof(ExchangeTokenHttpTrigger))]
        public async Task<IActionResult> ExchangeTokenAsync(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "connection/exchange/{publicToken}")] HttpRequest req, 
            string publicToken, ILogger log)
        {
            var openBankId = await _mediator.Send(new ExchangeTokenCommand(publicToken));
            
            return new OkObjectResult(openBankId);
        }
    }
}