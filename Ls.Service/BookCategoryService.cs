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
        private IBookCategoryRepository _bookCategoryRepository;

        public BookCategoryService(IBookCategoryRepository bookCategoryRepository)
        {
            _bookCategoryRepository = bookCategoryRepository;
        }

        public IList<BookCategory> GetAll()
        {
            return _bookCategoryRepository.GetAll()?.ToList();
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
