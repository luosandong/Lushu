using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ls.WebServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected ActionResult<dynamic> Ok(object data)
        {
            return new ActionResult<dynamic>(new { code = 200, data = data, error = "" });
        }

        protected ActionResult<dynamic> Error(string errorMessage)
        {
            return new ActionResult<dynamic>(new { code = 500, data = "", error = errorMessage });
        }
    }
}