using System;

namespace ILAManagementPro.Data.Data
{
    public class absWorkGangTemplate
    {
        public int Id { get; set; }

        public string TemplateDescription { get; set; }

        public int TemplateCount { get; set; }

        public int Default2GangId { get; set; }

        public int Default6GangId { get; set; }

        public int Default7GangId { get; set; }

        public int DefaultWBGangId { get; set; }

        public string AddUser { get; set; }

        public DateTime? AddDateTime { get; set; }

        public string UpdateUser { get; set; }

        public DateTime? UpdateDateTime { get; set; }
    }
}