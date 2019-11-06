using CommonDal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ls.Models
{
    [Table(Name = "bookinfo")]
    public class Book
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
        public int TotalPages { get; set; }
        public DateTime PubDate { get; set; }
        public decimal Price { get; set; }
        public string Press { get; set; }
    }
}
