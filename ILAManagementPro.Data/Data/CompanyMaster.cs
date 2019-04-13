using System;
using System.Collections.Generic;

namespace ILAManagementPro.Data.Data
{
    public class CompanyMaster
    {
        public CompanyMaster()
        {
            this.WorkScheduleHeaders = new HashSet<absWorkScheduleHeader>();
        }

        public decimal CoNo { get; set; }

        public string CompanyId { get; set; }

        public string CompanyName { get; set; }

        public string CoSymbol { get; set; }

        public string CompanyCode { get; set; }

        public bool Active { get; set; }

        public string FileName { get; set; }

        public decimal? CoImport { get; set; }

        public string AddedUser { get; set; }

        public DateTime? AddedDate { get; set; }

        public string UpdateUser { get; set; }

        public DateTime? UpdateDate { get; set; }

        public bool? HasNotes { get; set; }

        public virtual ICollection<absWorkScheduleHeader> WorkScheduleHeaders { get; set; }
    }
}