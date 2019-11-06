using Ls.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Ls.Models;

namespace Ls.Service
{
    public interface IBookCategoryService
    {
        void Insert(BookCategory bookCategory);
        void Update(BookCategory bookCategory);
        bool Delete(string bookCategoryId);
        IList<BookCategory> GetAll();
    }
    public class BookCategoryService: IBookCategoryService
    {
        private IBookCategoryRepository _bookCategoryRepository; IBookRepository bookRepos;

        public BookCategoryService(IBookCategoryRepository bookCategoryRepository, IBookRepository bookRepos)
        {
            _bookCategoryRepository = bookCategoryRepository;
            this.bookRepos = bookRepos;
        }

        public IList<BookCategory> GetAll()
        {
            var categories = _bookCategoryRepository.GetAll()?.ToList();
            foreach (var item in categories)
            {
                var parm = new Dictionary<string, object>
                {
                    { "Categoryid", item.Id }
                };
                item.Books = bookRepos.GetBySql("select * from bookinfo where categoryid=@Categoryid;", parm)?.ToList<Book>();
            }
            return categories;
        }

        public void Insert(BookCategory bookCategory)
        {
            _bookCategoryRepository.Insert(bookCategory);
        }

        public void Update(BookCategory bookCategory)
        {
            _bookCategoryRepository.Update(bookCategory);
        }

        public bool Delete(string bookCategoryId)
        {
            try
            {
                _bookCategoryRepository.Delete(new BookCategory() { Id = bookCategoryId });
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
    }
}
