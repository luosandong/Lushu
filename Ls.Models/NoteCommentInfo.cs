using CommonDal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ls.Models
{
    [Table(Name = "notecommentinfo")]
    public class NoteCommentInfo
    {
        [Key]
        public string Id { get; set; }
        public string CommentatorName { get; set; }
        public string CommentatorId { get; set; }
        public string CommentMessage { get; set; }
        public string ParentCommentId { get; set; }
        /// <summary>
        /// 笔记ID
        /// </summary>
        public string LearnNoteId { get; set; }
        public DateTime SubmitTime { get; set; }
        /// <summary>
        /// 赞
        /// </summary>
        public int Approve { get; set; }
        /// <summary>
        /// 反对
        /// </summary>
        public int Oppose { get; set; }
    }
}
