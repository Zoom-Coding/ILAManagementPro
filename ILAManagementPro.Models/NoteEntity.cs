using System;

namespace ILAManagementPro.Models
{
    public class NoteEntity : EntityBase
    {
        public decimal? CardNo { get; set; }

        public string Content { get; set; }

        public bool? ScheduleNote { get; set; }

        public DateTime? ScheduleBeginDate { get; set; }

        public DateTime? ScheduleEndDate { get; set; }

        public DateTime? SuspensionExpire { get; set; }

        public string User { get; set; }
    }
}