using System;

namespace ILAManagementPro.Data.Data
{
    public class absWorkScheduleLogin
    {
        public int id { get; set; }

        public string UserId { get; set; }

        public string AddUser { get; set; }

        public DateTime? AddDateTime { get; set; }

        public string UpdateUser { get; set; }

        public DateTime? UpdateDateTime { get; set; }

        public string ProgramName { get; set; }
    }
}