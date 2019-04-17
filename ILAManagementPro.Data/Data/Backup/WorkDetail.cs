using System;

namespace ILAManagementPro.Data.Data
{
    public class WorkDetail
    {
        public int DetlCounter { get; set; }

        public DateTime? DateOfWork { get; set; }

        public decimal? Header { get; set; }

        public int? Seq { get; set; }

        public decimal? CardNo { get; set; }

        public string CheckIn { get; set; }

        public DateTime? CheckInTime { get; set; }

        public string CheckOut { get; set; }

        public DateTime? CheckOutTime { get; set; }

        public string DetlComment { get; set; }

        public DateTime? AddedDate { get; set; }

        public string AddedUser { get; set; }

        public DateTime? UpdateDate { get; set; }

        public string UpdateUser { get; set; }
    }
}