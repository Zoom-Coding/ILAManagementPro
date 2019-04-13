using System;

namespace ILAManagementPro.Models
{
    public class GPAMemberTransfer : EntityBase
    {
        public string CardId { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public char? Action { get; set; }
    }
}