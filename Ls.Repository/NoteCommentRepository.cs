using System;
using System.Collections.Generic;
using System.Text;
using Ls.Models;

namespace Ls.Repository
{
    public interface INoteCommentRepository: IBaseRepository<NoteCommentInfo>
    {
        IEnumerable<NoteCommentInfo> GetCommentsByNoteId(string learnNoteId);
    }
    public class NoteCommentRepository : BaseRepository<NoteCommentInfo>, INoteCommentRepository
    {
        public IEnumerable<NoteCommentInfo> GetCommentsByNoteId(string learnNoteId)
        {
           return GetBySql("SELECT * FROM notecommentinfo WHERE learnNoteId=@LearnNoteId",
                new Dictionary<string, object>() {{"LearnNoteId", learnNoteId}});
        }
    }
}
