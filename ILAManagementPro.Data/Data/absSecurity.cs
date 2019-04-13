using System;

namespace ILAManagementPro.Data.Data
{
    public class absSecurity
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string UserName { get; set; }

        public bool? AuthorizeUsers { get; set; }

        public bool? PrintBadge { get; set; }

        public bool? WorkScheduleMaintenance { get; set; }

        public string AddUser { get; set; }

        public DateTime? AddDateTime { get; set; }

        public string UpdateUser { get; set; }

        public DateTime? UpdateDateTime { get; set; }

        public bool? TimeCardMaintenance { get; set; }

        public bool? PodiumProgram { get; set; }
    }
}