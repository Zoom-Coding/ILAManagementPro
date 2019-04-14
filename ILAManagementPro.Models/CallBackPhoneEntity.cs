namespace ILAManagementPro.Models
{
    public class CallBackPhoneEntity : EntityBase
    {
        public CallBackPhoneEntity()
        {
        }

        public CallBackPhoneEntity(CallBackPhoneEntity old)
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