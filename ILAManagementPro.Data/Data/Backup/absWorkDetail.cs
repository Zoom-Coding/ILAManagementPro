using System;

namespace ILAManagementPro.Data.Data
{
    public class absWorkDetail
    {
        public int Id { get; set; }

        public int absWorkHeaderId { get; set; }

        public int? Seq { get; set; }

        public decimal? CardNo { get; set; }

        public string CheckIn { get; set; }

        public DateTime? CheckInTime { get; set; }

        public string CheckOut { get; set; }

        public DateTime? CheckOutTime { get; set; }

        public string DetlComment { get; set; }

        public string AddUser { get; set; }

        public DateTime? AddDateTime { get; set; }

        public string UpdateUser { get; set; }

        public DateTime? UpdateDateTime { get; set; }

        public bool? FTPWrite { get; set; }

        public virtual absWorkHeader absWorkHeader { get; set; }
    }
}