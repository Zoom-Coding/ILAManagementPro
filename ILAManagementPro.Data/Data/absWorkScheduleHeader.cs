using System;
using System.Collections.Generic;

namespace ILAManagementPro.Data.Data
{
    public class absWorkScheduleHeader
    {
        public absWorkScheduleHeader()
        {
            this.absWorkHeaders = new HashSet<absWorkHeader>();
        }

        public int Id { get; set; }

        public DateTime DateWorked { get; set; }

        public decimal CompanyId { get; set; }

        public int BerthId { get; set; }

        public int VesselId { get; set; }

        public DateTime ShiftTime { get; set; }

        public bool Display { get; set; }

        public bool Cancelled { get; set; }

        public bool BerthQuestion { get; set; }

        public string AddUser { get; set; }

        public DateTime? AddDateTime { get; set; }

        public string UpdateUser { get; set; }

        public DateTime? UpdateDateTime { get; set; }

        public string SetBack { get; set; }

        public bool? EmergencyGang { get; set; }

        public virtual absBerth Berth { get; set; }

        public virtual absVessel Vessel { get; set; }

        public virtual CompanyMaster CompanyMaster { get; set; }

        public virtual ICollection<absWorkHeader> absWorkHeaders { get; set; }
    }
}