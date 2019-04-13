using System;

namespace ILAManagementPro.Models
{
    public class MemberDetail : EntityBase
    {
        public string CardNumber { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string MI { get; set; }

        public DateTime BirthDate { get; set; }

        public string ClassCode { get; set; }

        public byte[] Photo { get; set; }
    }
}