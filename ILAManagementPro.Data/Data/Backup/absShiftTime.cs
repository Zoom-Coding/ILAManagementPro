using System;

namespace ILAManagementPro.Data.Data
{
    public class absShiftTime
    {
        public int Id { get; set; }

        public string DisplayTime { get; set; }

        public string MilitaryTime { get; set; }

        public string PickTime { get; set; }

        public string AddUser { get; set; }

        public DateTime? AddDateTime { get; set; }

        public string UpdateUser { get; set; }

        public DateTime? UpdateDateTime { get; set; }
    }
}