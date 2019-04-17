using System;

namespace ILAManagementPro.Data.Data
{
    public class WorkHeader
    {
        public int CounterId { get; set; }

        public DateTime? DateWorked { get; set; }

        public Decimal? Header { get; set; }

        public Decimal? Company { get; set; }

        public string Berth { get; set; }

        public string Vessel { get; set; }

        public string CheckIn { get; set; }

        public DateTime? CheckInTime { get; set; }

        public string CheckOut { get; set; }

        public DateTime? CheckOutTime { get; set; }

        public string Description { get; set; }

        public string Comment { get; set; }

        public DateTime? AddedDate { get; set; }

        public string AddedUser { get; set; }

        public DateTime? UpdateDate { get; set; }

        public string UpdateUser { get; set; }
    }
}