namespace ILAManagementPro.Models
{
    public class CallBackPhone : EntityBase
    {
        public CallBackPhone()
        {
        }

        public CallBackPhone(CallBackPhone old)
        {
            this.Id = old.Id;
            this.Description = old.Description;
            this.CardNumber = old.CardNumber;
            this.PhoneNumber = old.PhoneNumber;
        }

        public override string ToString()
        {
            return this.PhoneNumber;
        }

        public decimal CardNumber { get; set; }

        public string PhoneNumber { get; set; }

        public string User { get; set; }
    }
}