using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Net;

namespace TourBooking.Controllers
{
    [AllowAnonymous]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {
        private readonly ILogger _logger;
        public ErrorsController( ILogger logger)
        {
            _logger = logger;
        }
        [Route("error")]
        public Exception Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context.Error;
            _logger.Error(exception, "general error handler catch this error");
            var code = 500; 

            if (exception is HttpStatusException httpException)
            {
                code = (int)httpException.Status;
            }
            Response.StatusCode = code; 
            return exception; 
        }
        public class HttpStatusException : Exception
        {
            public HttpStatusCode Status { get; private set; }

            public HttpStatusException(HttpStatusCode status, string msg) : base(msg)
            {
                Status = status;
            }
        }
    }
}
