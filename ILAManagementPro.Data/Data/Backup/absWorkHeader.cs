using System;
using System.Collections.Generic;

namespace ILAManagementPro.Data.Data
{
    public class absWorkHeader
    {
        public absWorkHeader()
        {
            this.absWorkDetails = new HashSet<absWorkDetail>();
        }

        public int CounterId { get; set; }

        public int? WorkScheduleHeaderId { get; set; }

        public decimal? Header { get; set; }

        public string CheckIn { get; set; }

        public DateTime? CheckInTime { get; set; }

        public string CheckOut { get; set; }

        public DateTime? CheckOutTime { get; set; }

        public string Description { get; set; }

        public string Comment { get; set; }

        public int? WorkGangDescriptionId { get; set; }

        public decimal? ReplaceHeaderId { get; set; }

        public DateTime? AddedDate { get; set; }

        public string AddedUser { get; set; }

        public DateTime? UpdateDate { get; set; }

        public string UpdateUser { get; set; }

        public string Location { get; set; }

        public string DriverFile { get; set; }

        public virtual absWorkGangDescription absWorkGangDescription { get; set; }

        public virtual absWorkScheduleHeader absWorkScheduleHeader { get; set; }

        public virtual InsuredMaster InsuredMaster { get; set; }

        public virtual InsuredMaster InsuredMaster1 { get; set; }

        public virtual ICollection<absWorkDetail> absWorkDetails { get; set; }
    }
}