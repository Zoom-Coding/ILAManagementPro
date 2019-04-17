using System;

namespace ILAManagementPro.Data.Data
{
    public class absGangSchedule
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