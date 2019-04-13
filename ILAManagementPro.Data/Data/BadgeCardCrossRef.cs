using ILAManagementPro.Models;
using System;

namespace ILAManagementPro.Data.Data
{
    public class BadgeCardCrossRef
    {
        public int Id { get; set; }

        public decimal CardNumber { get; set; }

        public int BadgeNumber { get; set; }

        public string AddUser { get; set; }

        public DateTime? AddDateTime { get; set; }

        public string UpdateUser { get; set; }

        public DateTime? UpdateDateTime { get; set; }

        public virtual InsuredMaster InsuredMaster { get; set; }
    }
}