using System;
using System.Collections.Generic;
using System.Text;
using Ls.Models;

namespace Ls.Repository
{
    public interface IBookCategoryRepository: IBaseRepository<BookCategory>
    {

    }
    public class BookCategoryRepository:BaseRepository<BookCategory>, IBookCategoryRepository
    {
    }
}
