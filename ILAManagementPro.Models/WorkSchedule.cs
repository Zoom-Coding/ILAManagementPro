using System;
using System.Collections.Generic;

namespace ILAManagementPro.Models
{
    public class WorkSchedule : EntityBase
    {
        public DateTime WorkScheduleDate { get; set; }

        public string Berth { get; set; }

        public string Ship { get; set; }

        public DateTime ShiftTime { get; set; }

        public Company Company { get; set; }

        public bool Cancelled { get; set; }

        public List<WorkHeader> WorkHeaders { get; set; }

        public string Setback { get; set; }

        public bool? EmergencyGang { get; set; }
    }
}