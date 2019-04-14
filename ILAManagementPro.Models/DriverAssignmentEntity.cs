using System;

namespace ILAManagementPro.Models
{
    public class DriverAssignmentEntity : EntityBase
    {
        public string LlyodsId { get; set; }

        public DateTime? StartTime { get; set; }

        public string GANG { get; set; }

        public string ILACardId { get; set; }

        public char Action { get; set; }

        public bool FTPWrite { get; set; }
    }
}