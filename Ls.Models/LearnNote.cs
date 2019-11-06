using CommonDal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ls.Models
{
    [Table(Name = "learnnote")]
    public class LearnNote
    {
        [Key]
        public string Id { get; set; }
        public string BookId { get; set; }
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string Subject { get; set; }
        public string NoteContent { get; set; }
        public DateTime NoteTime { get; set; }
        public int StarCount { get; set; }
        public string Summary { get; set; }
        public int OpposeCount { get; set; }
        public string Tags { get; set; }
        public int ReadCount { get; set; }
        public int WordCount { get; set; }
        public int CommentCount { get; set; }
    }
}
