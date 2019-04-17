using System;

namespace ILAManagementPro.Data.Data
{
    public class absCallBack
    {
        public int Id { get; set; }

        public decimal CardNumberId { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime CallBackDateTime { get; set; }

        public bool Active { get; set; }

        public string AddUser { get; set; }

        public DateTime? AddDateTime { get; set; }

        public string UpdateUser { get; set; }

        public DateTime? UpdateDateTime { get; set; }

        public virtual InsuredMaster InsuredMaster { get; set; }
    }
}