namespace ILAManagementPro.Data.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("absSecurity")]
    public partial class absSecurity
    {
        public int id { get; set; }

        [Required]
        [StringLength(9)]
        public string Login { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        public bool? AuthorizeUsers { get; set; }

        public bool? PrintBadge { get; set; }

        public bool? WorkScheduleMaintenance { get; set; }

        public bool? TimeCardMaintenance { get; set; }

        public bool? PodiumProgram { get; set; }

        [StringLength(50)]
        public string AddUser { get; set; }

        public DateTime? AddDateTime { get; set; }

        [StringLength(50)]
        public string UpdateUser { get; set; }

        public DateTime? UpdateDateTime { get; set; }
    }
}
