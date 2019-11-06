using CommonDal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ls.Models
{
    [Table(Name="learnplan")]
    public class LearnPlan
    {
        [Key]
        public string Id { get; set; }
        public string BookId { get; set; }
        public string UserId { get; set; }
        public string PlanName { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime PlanFinishTime { get; set; }
        public DateTime FinishTime { get; set; }
        public int PlanType { get; set; }
        public int PlanDays { get; set; }
        public int PlanPages { get; set; }
        public int Days { get; set; }
        public int Status { get; set; }
        public int Percentage { get; set; }
        public string Description { get; set; }
    }
}
