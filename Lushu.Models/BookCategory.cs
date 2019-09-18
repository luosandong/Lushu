using System;

namespace Lushu.Models
{
    public class BookCategory
    {
        [KeyAttribute]
        public string Id { get; set; }
        public string Name { get; set; }
        public string ParentId { get; set; }
        public int Layer { get; set; }
        public int Sequence { get; set; }
    }
}
