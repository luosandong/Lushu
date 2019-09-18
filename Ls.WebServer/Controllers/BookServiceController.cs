using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ls.Models;
using Ls.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Ls.WebServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookServiceController : ControllerBase
    {
        private IBookCategoryService _bookCategoryService;

        public BookServiceController(IBookCategoryService bookCategoryService)
        {
            _bookCategoryService = bookCategoryService;
        }
        [HttpPost]
        [HttpGet]
        [Route("list")]
        public ActionResult<List<BookCategory>> List()
        {
            var result = _bookCategoryService.GetAll();
            return new ActionResult<List<BookCategory>>(result?.ToList());
        }
        [HttpPost]
        [Route("save")]
        public ActionResult<BookCategory> Save([FromBody] BookCategory categoey)
        {
            //BookCategory categoey = new BookCategory();
            categoey.Id = Guid.NewGuid().ToString();
            //categoey.ParentId = obj["parentId"].ToObject<string>();
            //categoey.Sequence = obj["sequence"].ToObject<int>();
            //categoey.Name = obj["name"].ToObject<string>();
            //categoey.Layer = obj["layer"].ToObject<int>();

            _bookCategoryService.Insert(categoey);
            return new ActionResult<BookCategory>(categoey);
        }

        [HttpPost]
        [Route("update")]
        public ActionResult<BookCategory> Update([FromBody] BookCategory categoey)
        {
            _bookCategoryService.Update(categoey);
            return new ActionResult<BookCategory>(categoey);
        }

        [HttpPost]
        [Route("delete")]
        public ActionResult<bool> Delete([FromBody] JObject obj)
        {
            var categoryId = obj["categoryId"].ToObject<string>();
            _bookCategoryService.Delete(categoryId);
            return new ActionResult<bool>(true);
        }
    }
}