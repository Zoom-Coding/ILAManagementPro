using System;

namespace ILAManagementPro.Data.Data
{
    public class TimeCardEntryErrorLog
    {
        public decimal Cardno { get; set; }

        public DateTime? DateofWork { get; set; }

        public string MsgNo { get; set; }

        public string MsgDetails { get; set; }

        public string AnsYN { get; set; }

        public decimal? Header { get; set; }

        public decimal? Company { get; set; }

        public string Berth { get; set; }

        public string Vessel { get; set; }

        public decimal? OtherHeader { get; set; }

        public DateTime? OtherDate { get; set; }

        public string AddedUser { get; set; }

        public DateTime? AddedDate { get; set; }
    }
}