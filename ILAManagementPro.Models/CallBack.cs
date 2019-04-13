using System;

namespace ILAManagementPro.Models
{
    public class CallBack : EntityBase
    {
        public CallBack()
        {
        }

        public CallBack(CallBack old)
        {
            this.Id = old.Id;
            this.Description = old.Description;
            this.Member = new Header(old.Member);
            this.Phone = old.Phone;
            this.CallBackDateTime = old.CallBackDateTime;
            this.Active = old.Active;
        }

        public Header Member { get; set; }

        public string Phone { get; set; }

        public DateTime CallBackDateTime { get; set; }

        public bool Active { get; set; }

        public string User { get; set; }
    }
}