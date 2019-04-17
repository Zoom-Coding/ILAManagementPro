namespace ILAManagementPro.Data.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("absWorkGangTemplate")]
    public partial class absWorkGangTemplate
    {
        public int id { get; set; }

        [Required]
        [StringLength(200)]
        public string TemplateDescription { get; set; }

        public int TemplateCount { get; set; }

        public int Default2GangId { get; set; }

        public int Default6GangId { get; set; }

        public int Default7GangId { get; set; }

        public int DefaultWBGangId { get; set; }

        [StringLength(50)]
        public string AddUser { get; set; }

        public DateTime? AddDateTime { get; set; }

        [StringLength(50)]
        public string UpdateUser { get; set; }

        public DateTime? UpdateDateTime { get; set; }
    }
}
