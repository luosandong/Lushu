using Ls.Models;
using Ls.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ls.Service
{
    public interface ILearnNoteService
    {
        void SaveNote(LearnNote note);
        IEnumerable<LearnNote> GetNotes();
        IEnumerable<LearnNote> GetNotesByBookId(string bookId);
        LearnNote GetNote(string noteId);
        bool AddReadCount(string noteId);
        void UpdateNote(LearnNote note);
    }
    public class LearnNoteService : ILearnNoteService
    {
        ILearnNoteRepository noteRepos;
        public LearnNoteService(ILearnNoteRepository noteRepos)
        {
            this.noteRepos = noteRepos;
        }

        public bool AddReadCount(string noteId)
        {
            try
            {
                var note = noteRepos.Get(noteId);
                note.ReadCount += 1;

                noteRepos.Update(note);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
           
        }

        public LearnNote GetNote(string noteId)
        {
            return noteRepos.Get(noteId);
        }

        public IEnumerable<LearnNote> GetNotes()
        {
            return noteRepos.GetAll();
        }

        public IEnumerable<LearnNote> GetNotesByBookId(string bookId)
        {
            return noteRepos.GetBySql("select * from learnnote where bookId=@BookId",
                new Dictionary<string, object>() {{"BookId", bookId}});
        }

        public void SaveNote(LearnNote note)
        {
            noteRepos.Insert(note);
        }

        public void UpdateNote(LearnNote note)
        {
            noteRepos.Update(note);
        }
    }
}
