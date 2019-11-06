using System;
using System.Collections.Generic;
using System.Text;
using Ls.Models;
using Ls.Repository;

namespace Ls.Service
{
    public interface INoteCommentService
    {
        bool SaveComment(NoteCommentInfo commnetInfo);
        IEnumerable<NoteCommentInfo> GetCommentsByNoteId(string learnNoteId);
    }
    public class NoteCommentService: INoteCommentService
    {
        private INoteCommentRepository noteCommentRepository;
        private ILearnNoteRepository learnNoteRepository;
        public NoteCommentService(INoteCommentRepository noteCommentRepository,ILearnNoteRepository learnNoteRepository)
        {
            this.noteCommentRepository = noteCommentRepository;
            this.learnNoteRepository = learnNoteRepository;
        }

        public IEnumerable<NoteCommentInfo> GetCommentsByNoteId(string learnNoteId)
        {
            return noteCommentRepository.GetCommentsByNoteId(learnNoteId);
        }

        public bool SaveComment(NoteCommentInfo commnetInfo)
        {
            try
            {
                noteCommentRepository.Insert(commnetInfo);
                var note = learnNoteRepository.Get(commnetInfo.LearnNoteId);
                note.CommentCount += 1;
                learnNoteRepository.Update(note);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }
    }
}
