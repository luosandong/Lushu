using CommonDal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ls.Models
{
    [Table(Name = "websitebaseinfo")]
    public class WebSiteBaseInfo
    {
        [Key]
        public string ICP { get; set; }
        public int AccessCount { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string Contact { get; set; }
        public string ContactTel { get; set; }
        public string Address { get; set; }



    }
}
