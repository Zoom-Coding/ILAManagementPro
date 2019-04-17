namespace ILAManagementPro.Data.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IMEmergencyContact")]
    public partial class IMEmergencyContact
    {
        public int id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CardNo { get; set; }

        [StringLength(200)]
        public string ContactName { get; set; }

        [StringLength(10)]
        public string Phone1 { get; set; }

        [StringLength(10)]
        public string Phone2 { get; set; }

        [StringLength(50)]
        public string Relationship { get; set; }

        [StringLength(20)]
        public string AddUser { get; set; }

        public DateTime? AddDateTime { get; set; }

        [StringLength(20)]
        public string UpdateUser { get; set; }

        public DateTime? UpdateDateTime { get; set; }
    }
}
