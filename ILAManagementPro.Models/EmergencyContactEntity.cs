using System;

namespace ILAManagementPro.Models
{
    public class EmergencyContactEntity : EntityBase
    {
        public int id { get; set; }

        public Decimal CardNo { get; set; }

        public string ContactName { get; set; }

        public string Phone1 { get; set; }

        public string Phone2 { get; set; }

        public string Relationship { get; set; }

        public string AddUser { get; set; }

        public DateTime? AddDateTime { get; set; }

        public string UpdateUser { get; set; }

        public DateTime? UpdateDateTime { get; set; }
    }
}