using Ls.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ls.Repository
{
    public interface IBookRepository: IBaseRepository<Book>
    {

    }
    public class BookRepository: BaseRepository<Book>, IBookRepository
    {
    }
}
