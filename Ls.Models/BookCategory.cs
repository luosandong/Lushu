using CommonDal;
using System;

namespace Ls.Models
{
    [Table(Name = "book_category")]
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
    }
}
