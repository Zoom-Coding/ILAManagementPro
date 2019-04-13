using System;

namespace ILAManagementPro.Models
{
    public class GPACredentials : EntityBase
    {
        public string CardId { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public DateTime? DOB { get; set; }

        public string SSNo { get; set; }

        public string ILACardNumber { get; set; }
    }
}