using System;

namespace ILAManagementPro.Data.Data
{
    public class GetWorkScheduleByDateResult
    {
        public int Id { get; set; }

        public string Berth { get; set; }

        public string Vessel { get; set; }

        public DateTime ShiftDateTime { get; set; }

        public string Company { get; set; }

        public string Header { get; set; }

        public string GangDescription { get; set; }

        public bool Cancelled { get; set; }

        public int IsReplacementHeader { get; set; }

        public string SetBack { get; set; }

        public bool? EmergencyGang { get; set; }
    }
}