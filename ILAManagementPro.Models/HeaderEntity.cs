using System;

namespace ILAManagementPro.Models
{
    public class HeaderEntity : EntityBase
    {
        public HeaderEntity()
        {
        }

        public HeaderEntity(HeaderEntity old)
        {
            this.Id = old.Id;
            this.Description = old.Description;
            this.DisplayName = old.DisplayName;
            this.LastName = old.LastName;
            this.FirstName = old.FirstName;
            this.MiddleInitial = old.MiddleInitial;
            this.HeaderMember = old.HeaderMember;
            this.SenClass = old.SenClass;
            this.SSN = old.SSN;
            this.DailySuspension = old.DailySuspension;
            this.Suspension = old.Suspension;
            this.Active = old.Active;
            this.Phone = old.Phone;
            this.TwicCard = old.TwicCard;
        }

        public override string ToString()
        {
            return this.Id;
        }

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

        public DateTime? BirthDate { get; set; }

        public string ClassCode { get; set; }

        public DateTime? SuspensionEndDate { get; set; }
    }
}