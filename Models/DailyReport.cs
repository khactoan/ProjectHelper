using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectHelper.Models
{
    public enum Status
    {
        InProgress, ToDo, CodeDone, Done, Investigate
    }
    public class DailyReport
    {
        public int Id { get; set; }
        public string TicketTitle { get; set; }
        public Status Status { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReportDate { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
