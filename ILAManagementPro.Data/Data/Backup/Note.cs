using System;

namespace ILAManagementPro.Data.Data
{
    public class Note
    {
        public int NoteId { get; set; }

        public decimal? CardNo { get; set; }

        public string Note1 { get; set; }

        public string AddedUser { get; set; }

        public DateTime? AddedDate { get; set; }

        public string UpdateUser { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}