using System;

namespace ILAManagementPro.Models
{
    public class WelfareMemberEntity : EntityBase
    {
        public string MemberNumber { get; set; }

        public string MemberName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Age { get; set; }

        public string MaritalStatus { get; set; }

        public DateTime MarriageDate { get; set; }

        public string SpouseDependentNumber { get; set; }

        public string SpouseName { get; set; }

        public string SpouseBirthDate { get; set; }

        public string SpouseAge { get; set; }

        public int? LastCalendarYearPosted { get; set; }

        public DateTime LastCalendarDatePosted { get; set; }
    }
}