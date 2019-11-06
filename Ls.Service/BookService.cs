using Ls.Models;
using Ls.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ls.Service
{
    public interface IBookService
    {
        void SaveBook(Book book);
        void SaveLearnPlan(LearnPlan plan);
        IEnumerable<Book> GetAllBooks();
        IEnumerable<Book> GetBooksByCategoryId(string categoryId);
    }
    public class BookService: IBookService
    {
        IPlanRepository planRepos; IBookRepository bookRepos;

        public BookService(IPlanRepository planRepos, IBookRepository bookRepos)
        {
            this.planRepos = planRepos;
            this.bookRepos = bookRepos;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return bookRepos.GetAll();
        }

        public IEnumerable<Book> GetBooksByCategoryId(string categoryId)
        {
            Dictionary<string, object> parm = new Dictionary<string, object>();
            parm.Add("Categoryid", categoryId);
            return bookRepos.GetBySql("select * from bookinfo where categoryid=@Categoryid;", parm);
        }

        public void SaveBook(Book book)
        {
            bookRepos.Insert(book);
        }

        public void SaveLearnPlan(LearnPlan plan)
        {
            planRepos.Insert(plan);
        }
    }
}
