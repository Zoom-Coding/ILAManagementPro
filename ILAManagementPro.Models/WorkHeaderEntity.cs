using System;
using System.Collections.Generic;

namespace ILAManagementPro.Models
{
    public class WorkHeaderEntity : EntityBase
    {
        public DateTime? DateWorked { get; set; }

        public string Header { get; set; }

        public CompanyEntity Company { get; set; }

        public string Berth { get; set; }

        public string Vessel { get; set; }

        public string CheckIn { get; set; }

        public DateTime? CheckInTime { get; set; }

        public string CheckOut { get; set; }

        public DateTime? CheckOutTime { get; set; }

        public new string Description { get; set; }

        public string Comment { get; set; }

        public DateTime? ShiftTime { get; set; }

        public string GangDescription { get; set; }

        public bool? Display { get; set; }

        public List<WorkDetailEntity> WorkDetails { get; set; }

        public string User { get; set; }

        public bool IsReplacementHeader { get; set; }
    }
}