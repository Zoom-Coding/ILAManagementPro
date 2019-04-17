using System;
using System.Collections.Generic;

namespace ILAManagementPro.Data.Data
{
    public class absBerth
    {
        public absBerth()
        {
            this.WorkScheduleHeaders = new HashSet<absWorkScheduleHeader>();
        }

        public int id { get; set; }

        public string BerthShortName { get; set; }

        public string BerthFullName { get; set; }

        public string AddUser { get; set; }

        public DateTime? AddDateTime { get; set; }

        public string UpdateUser { get; set; }

        public DateTime? UpdateDateTime { get; set; }

        public virtual ICollection<absWorkScheduleHeader> WorkScheduleHeaders { get; set; }
    }
}