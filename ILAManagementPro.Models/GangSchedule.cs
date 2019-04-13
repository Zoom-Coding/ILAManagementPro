using System;

namespace ILAManagementPro.Models
{
    public class GangSchedule : EntityBase
    {
        public int ID { get; set; }

        public string LloydsId { get; set; }

        public string OutVoyage { get; set; }

        public string Berth { get; set; }

        public DateTime? StartTime { get; set; }

        public string GangPos { get; set; }

        public DateTime AddDateTime { get; set; }

        public char AddDelete { get; set; }
    }
}