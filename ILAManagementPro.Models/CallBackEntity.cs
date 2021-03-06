﻿using System;

namespace ILAManagementPro.Models
{
    public class CallBackEntity : EntityBase
    {
        public CallBackEntity()
        {
        }

        public CallBackEntity(CallBackEntity old)
        {
            this.Id = old.Id;
            this.Description = old.Description;
            this.Member = new HeaderEntity(old.Member);
            this.Phone = old.Phone;
            this.CallBackDateTime = old.CallBackDateTime;
            this.Active = old.Active;
        }

        public HeaderEntity Member { get; set; }

        public string Phone { get; set; }

        public DateTime CallBackDateTime { get; set; }

        public bool Active { get; set; }

        public string User { get; set; }
    }
}