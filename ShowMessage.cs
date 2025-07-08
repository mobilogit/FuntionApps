using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace HelloAzureApp.Functions
{
    public class ShowMessage
    {
        private readonly ILogger _logger;

        public ShowMessage(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<ShowMessage>();
        }

        [Function("ShowMessage")]
        public HttpResponseData Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("ShowMessage function triggered.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
            response.WriteString("Hello from Azure Functions running on .NET 9!");

            return response;
        }
    }
}