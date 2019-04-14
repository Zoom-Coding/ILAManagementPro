namespace ILAManagementPro.Models
{
    public class InsuredMasterEntity : EntityBase
    {
        public string DisplayName { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string MiddleInitial { get; set; }

        public bool HeaderMember { get; set; }

        public string SenClass { get; set; }

        public string SSN { get; set; }

        public string Phone { get; set; }

        public bool DailySuspension { get; set; }

        public string Suspension { get; set; }

        public bool Active { get; set; }

        public string TwicCard { get; set; }

        public string User { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }
    }
}