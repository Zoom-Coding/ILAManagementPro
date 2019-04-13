using System;

namespace ILAManagementPro.Data.Data
{
    public class GangSchedule
    {
        public int Id { get; set; }

        public string LloydsId { get; set; }

        public string OutVoyage { get; set; }

        public string Berth { get; set; }

        public DateTime? StartTime { get; set; }

        public string Gang { get; set; }

        public DateTime? AddDateTime { get; set; }
    }
}