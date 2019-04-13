using System;

namespace ILAManagementPro.Data.Data
{
    public class absScheduleNote
    {
        public int Id { get; set; }

        public string Note { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime EndDate { get; set; }

        public string AddUser { get; set; }

        public DateTime? AddDateTime { get; set; }

        public string UpdateUser { get; set; }

        public DateTime? UpdateDateTime { get; set; }
    }
}