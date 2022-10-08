using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using OpenBank.Domain.Interfaces.Services;
using OpenBank.Domain.Models.Enums;

namespace OpenBank.Functions.HttpTriggers
{
    public class GetTempTokenHttpTrigger
    {
        private readonly IEnumerable<ITokenService> _services;

        public GetTempTokenHttpTrigger(IEnumerable<ITokenService> service)
        {
            _services = service;
        }

        [FunctionName("GetTempTokenHttpTrigger")]
        public async Task<IActionResult> RunAsync(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req, ILogger log)
        {
            var tokenService = _services.SingleOrDefault(x => x.OpenBankPartner == EOpenBankProvider.Plaid);
            
            var retVal = await tokenService!.GetTempToken();
            
            return new OkObjectResult(retVal);
        }
    }
}