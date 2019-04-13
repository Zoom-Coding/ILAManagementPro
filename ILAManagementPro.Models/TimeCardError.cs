using System;

namespace ILAManagementPro.Models
{
    public class TimeCardError : EntityBase
    {
        public TimeCardError()
        {
        }

        public TimeCardError(TimeCardError old)
        {
            this.Id = old.Id;
            this.Description = old.Description;
            this.Cardno = old.Cardno;
            if (old.DateofWork.HasValue)
                this.DateofWork = new DateTime?(old.DateofWork.Value);
            this.MsgNo = old.MsgNo;
            this.MsgDetails = old.MsgDetails;
            this.AnsYN = old.AnsYN;
            decimal? nullable = old.Header;
            if (nullable.HasValue)
            {
                nullable = old.Header;
                this.Header = new decimal?(nullable.Value);
            }
            nullable = old.Company;
            if (nullable.HasValue)
            {
                nullable = old.Company;
                this.Company = new decimal?(nullable.Value);
            }
            this.Berth = old.Berth;
            this.Vessel = old.Vessel;
            nullable = old.OtherHeader;
            if (nullable.HasValue)
            {
                nullable = old.OtherHeader;
                this.OtherHeader = new decimal?(nullable.Value);
            }
            DateTime? otherDate = old.OtherDate;
            if (otherDate.HasValue)
            {
                otherDate = old.OtherDate;
                this.OtherDate = new DateTime?(otherDate.Value);
            }
            this.User = old.User;
        }

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

        public string User { get; set; }
    }
}