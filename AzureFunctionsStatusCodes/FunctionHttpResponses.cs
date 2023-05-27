using System.Net;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace AzureFunctionsStatusCodes
{
    public class FunctionHttpResponses
    {
        private readonly ILogger _logger;

        public FunctionHttpResponses(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<FunctionHttpResponses>();
        }

        [Function(nameof(OkHttpStatusCode))]
        public HttpResponseData OkHttpStatusCode([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.WriteString("Welcome to Azure Functions!");

            return response;
        }

        [Function(nameof(BadRequestHttpStatusCode))]
        public HttpResponseData BadRequestHttpStatusCode([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse();
            response.WriteString("Welcome to Azure Functions!");
            response.StatusCode = HttpStatusCode.BadRequest;

            return response;
        }

        [Function(nameof(InternalErrorHttpStatusCode))]
        public HttpResponseData InternalErrorHttpStatusCode([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.InternalServerError);
            response.WriteString("Welcome to Azure Functions!");

            return response;
        }

        [Function(nameof(OkStatusCode))]
        public IActionResult OkStatusCode([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            return new OkObjectResult("Welcome to Azure Functions!");
        }

        [Function(nameof(AlwaysHttp200StatusCode))]
        public IActionResult AlwaysHttp200StatusCode([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            return new BadRequestObjectResult("Welcome to Azure Functions!");
        }

        [Function(nameof(AlwaysHttp200StatusCodeAgain))]
        public IActionResult AlwaysHttp200StatusCodeAgain([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            return new InternalServerErrorResult();
        }
    }
}
