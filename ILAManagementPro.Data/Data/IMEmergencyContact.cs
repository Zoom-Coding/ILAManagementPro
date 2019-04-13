using System;

namespace ILAManagementPro.Data.Data
{
    public class IMEmergencyContact
    {
        public int Id { get; set; }

        public decimal CardNo { get; set; }

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