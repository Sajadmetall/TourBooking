using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace TourBooking.Controllers
{
    [AllowAnonymous]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {
        [Route("error")]
        public Exception Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context.Error; 
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
