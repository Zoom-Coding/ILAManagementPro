namespace ILAManagementPro.Models
{
    public class Badge : EntityBase
    {
        public Badge()
        {
        }

        public Badge(Badge old)
        {
            this.Id = old.Id;
            this.Description = old.Description;
            this.CardNumber = old.CardNumber;
            this.BadgeNumber = old.BadgeNumber;
        }

        public decimal CardNumber { get; set; }

        public int BadgeNumber { get; set; }

        public string User { get; set; }
    }
}