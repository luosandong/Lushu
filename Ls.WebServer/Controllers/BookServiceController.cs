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
    public class SaveBookAndPlanParam
    {
        public Book Book { get; set; }
        public LearnPlan plan { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class BookServiceController : BaseController
    {

        private IBookCategoryService _bookCategoryService;
        IBookService bookService;

        public BookServiceController(IBookCategoryService bookCategoryService, IBookService bookService)
        {
            _bookCategoryService = bookCategoryService;
            this.bookService = bookService;
        }
        [HttpPost]
        [HttpGet]
        [Route("bookcategories")]
        public ActionResult<dynamic> GetBookCategories()
        {
            string id = HttpContext.Request.Query["id"];
            var result = _bookCategoryService.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("list")]
        public ActionResult<dynamic> GetBooks()
        {
            try
            {
                return Ok(bookService.GetAllBooks());
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
            
        }

        [HttpGet]
        [Route("getbooksbycategoryid")]
        public ActionResult<dynamic> GetBooksByCategory()
        {
            try
            {
                string categoryId = HttpContext.Request.Query["categoryId"];
                return Ok(bookService.GetBooksByCategoryId(categoryId));
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }

        }

        [HttpPost]
        [Route("saveplan")]
        public ActionResult<dynamic> SaveBookAndPlan([FromBody] SaveBookAndPlanParam par)
        {
            try
            {
                var book = par.Book;
                book.Id = Guid.NewGuid().ToString();
                bookService.SaveBook(book);
                var plan = par.plan;
                plan.BookId = book.Id;
                plan.CreateTime = DateTime.Now;
                plan.Id = Guid.NewGuid().ToString();
                bookService.SaveLearnPlan(plan);
                return Ok("ok");
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
            
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