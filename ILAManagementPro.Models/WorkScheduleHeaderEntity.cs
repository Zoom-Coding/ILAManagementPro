using System;
using System.Collections.Generic;
using System.Linq;

namespace ILAManagementPro.Models
{
    public class WorkScheduleHeaderEntity : EntityBase
    {
        public WorkScheduleHeaderEntity()
        {
        }

        public WorkScheduleHeaderEntity(WorkScheduleHeaderEntity old)
        {
            this.Id = old.Id;
            this.Description = old.Description;
            this.DateWorked = old.DateWorked;
            this.Company = new CompanyEntity(old.Company);
            this.Berth = new BerthEntity(old.Berth);
            this.Vessel = new VesselEntity(old.Vessel);
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
            absWorkHeaderEntity[] array = new absWorkHeaderEntity[old.WorkHeaders.Count];
            old.WorkHeaders.CopyTo(array);
            this.WorkHeaders = ((IEnumerable<absWorkHeaderEntity>)array).ToList();
        }

        public DateTime DateWorked { get; set; }

        public CompanyEntity Company { get; set; }

        public BerthEntity Berth { get; set; }

        public VesselEntity Vessel { get; set; }

        public DateTime ShiftTime { get; set; }

        public bool Display { get; set; }

        public bool Cancelled { get; set; }

        public bool BerthQuestion { get; set; }

        public string SetBack { get; set; }

        public bool? EmergencyGang { get; set; }

        public string User { get; set; }

        public List<absWorkHeaderEntity> WorkHeaders { get; set; }
    }
}