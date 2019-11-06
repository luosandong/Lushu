using CommonDal;
using System;
using System.Collections.Generic;

namespace Ls.Models
{
    [Table(Name = "bookcategory")]
    public class BookCategory
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        [FieldDef(ColumnName = "parent_id")]
        public string ParentId { get; set; }
        [MapIgnore]
        public int Layer { get; set; }
        public int Sequence { get; set; }
        [MapIgnore]
        public List<Book> Books { get; set; }
    }
}
