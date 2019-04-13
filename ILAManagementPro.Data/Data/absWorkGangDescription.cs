using System;
using System.Collections.Generic;

namespace ILAManagementPro.Data.Data
{
    public class absWorkGangDescription
    {
        public absWorkGangDescription()
        {
            this.absWorkHeaders = new HashSet<absWorkHeader>();
        }

        public int Id { get; set; }

        public string Description { get; set; }

        public string AddUser { get; set; }

        public DateTime? AddDateTime { get; set; }

        public string UpdateUser { get; set; }

        public DateTime? UpdateDateTime { get; set; }

        public bool? DriverGang { get; set; }

        public virtual ICollection<absWorkHeader> absWorkHeaders { get; set; }
    }
}