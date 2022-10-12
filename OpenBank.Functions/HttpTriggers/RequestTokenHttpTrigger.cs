using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using OpenBank.Domain.Commands.Connections;

namespace OpenBank.Functions.HttpTriggers
{
    public class RequestTokenHttpTrigger
    {
        private readonly IMediator _mediator;

        public RequestTokenHttpTrigger(IMediator mediator)
            => _mediator = mediator;

        [FunctionName(nameof(RequestTokenHttpTrigger))]
        public async Task<IActionResult> RequestTokenAsync(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "connection/request/{userId}")] HttpRequest req, Guid userId, ILogger log)
        {
            var token = await _mediator.Send(new RequestTokenCommand(userId));
            
            return new OkObjectResult(token);
        }
    }
}