namespace ILAManagementPro.Data.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    
    [Table("absWorkScheduleLogins")]
    public partial class absWorkScheduleLogin
    {
        public int id { get; set; }

        [Required]
        [StringLength(20)]
        public string UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string ProgramName { get; set; }

        [StringLength(50)]
        public string AddUser { get; set; }

        public DateTime? AddDateTime { get; set; }

        [StringLength(50)]
        public string UpdateUser { get; set; }

        public DateTime? UpdateDateTime { get; set; }
    }
}
