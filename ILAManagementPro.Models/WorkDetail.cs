using System;

namespace ILAManagementPro.Models
{
    public class WorkDetail : EntityBase
    {
        public WorkHeader Header { get; set; }

        public int? Seq { get; set; }

        public Decimal? CardNo { get; set; }

        public string CheckIn { get; set; }

        public DateTime? CheckInTime { get; set; }

        public string CheckOut { get; set; }

        public DateTime? CheckOutTime { get; set; }

        public string DetailComment { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string User { get; set; }

        public bool? FTPWrite { get; set; }
    }
}
