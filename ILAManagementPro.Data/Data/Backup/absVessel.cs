using System;
using System.Collections.Generic;

namespace ILAManagementPro.Data.Data
{
    public class absVessel
    {
        public absVessel()
        {
            this.absWorkScheduleHeaders = new HashSet<absWorkScheduleHeader>();
        }

        public int id { get; set; }

        public string VesselName { get; set; }

        public string AddUser { get; set; }

        public DateTime? AddDateTime { get; set; }

        public string UpdateUser { get; set; }

        public DateTime? UpdateDateTime { get; set; }

        public string LLoydsId { get; set; }

        public virtual ICollection<absWorkScheduleHeader> absWorkScheduleHeaders { get; set; }
    }
}