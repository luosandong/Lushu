using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ls.Models;
using Ls.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ls.WebServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebSiteController : ControllerBase
    {
        IWebSiteBaseInfoService _webSiteBaseInfoService;
        public WebSiteController(IWebSiteBaseInfoService webSiteBaseInfoService)
        {
            _webSiteBaseInfoService = webSiteBaseInfoService;
        }
        [HttpGet]
        [Route("info")]
        public ActionResult<WebSiteBaseInfo> GetWebSiteInfo()
        {
            var result = _webSiteBaseInfoService.GetInfo();
            return new ActionResult<WebSiteBaseInfo>(result);
        }
    }
}