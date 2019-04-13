using System;
using System.Collections.Generic;
using System.Linq;

namespace ILAManagementPro.Models
{
    public class WorkScheduleHeader : EntityBase
    {
        public WorkScheduleHeader()
        {
        }

        public WorkScheduleHeader(WorkScheduleHeader old)
        {
            this.Id = old.Id;
            this.Description = old.Description;
            this.DateWorked = old.DateWorked;
            this.Company = new Company(old.Company);
            this.Berth = new Berth(old.Berth);
            this.Vessel = new Vessel(old.Vessel);
            this.ShiftTime = old.ShiftTime;
            this.Display = old.Display;
            this.Cancelled = old.Cancelled;
            this.BerthQuestion = old.BerthQuestion;
            this.SetBack = old.SetBack;
            this.EmergencyGang = old.EmergencyGang;
            if (!string.IsNullOrEmpty(old.User))
                this.User = old.User;
            if (old.WorkHeaders == null)
                return;
            WorkHeader[] array = new WorkHeader[old.WorkHeaders.Count];
            old.WorkHeaders.CopyTo(array);
            this.WorkHeaders = ((IEnumerable<WorkHeader>)array).ToList();
        }

        public DateTime DateWorked { get; set; }

        public Company Company { get; set; }

        public Berth Berth { get; set; }

        public Vessel Vessel { get; set; }

        public DateTime ShiftTime { get; set; }

        public bool Display { get; set; }

        public bool Cancelled { get; set; }

        public bool BerthQuestion { get; set; }

        public string SetBack { get; set; }

        public bool? EmergencyGang { get; set; }

        public string User { get; set; }

        public List<WorkHeader> WorkHeaders { get; set; }
    }
}