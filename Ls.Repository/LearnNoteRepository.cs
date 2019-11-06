using Ls.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ls.Repository
{
    public interface ILearnNoteRepository : IBaseRepository<LearnNote>
    {
        void AddReadCountByNoteId(string noteId);
    }
    public class LearnNoteRepository : BaseRepository<LearnNote>, ILearnNoteRepository
    {
        public void AddReadCountByNoteId(string noteId)
        {
            //ExecuteSql("UPDATE ")
        }
    }
}
