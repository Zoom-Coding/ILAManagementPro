using System;

namespace ILAManagementPro.Data.Data
{
    public class absvwMemberDetail
    {
        public decimal CardNo { get; set; }

        public string LastName { get; set; }

        public string MI { get; set; }

        public string FirstName { get; set; }

        public DateTime? DateBirth { get; set; }

        public string ClassCode { get; set; }

        public byte[] Photo { get; set; }
    }
}