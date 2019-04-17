namespace ILAManagementPro.Data.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("absWorkDetail")]
    public partial class absWorkDetail
    {
        public int id { get; set; }

        public int absWorkHeaderId { get; set; }

        public int? Seq { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CardNo { get; set; }

        [StringLength(1)]
        public string CheckIn { get; set; }

        public DateTime? CheckInTime { get; set; }

        [StringLength(1)]
        public string CheckOut { get; set; }

        public DateTime? CheckOutTime { get; set; }

        [StringLength(250)]
        public string DetlComment { get; set; }

        [StringLength(20)]
        public string AddUser { get; set; }

        public DateTime? AddDateTime { get; set; }

        [StringLength(20)]
        public string UpdateUser { get; set; }

        public DateTime? UpdateDateTime { get; set; }

        public bool? FTPWrite { get; set; }

        [StringLength(1)]
        public string TrashPile { get; set; }

        public virtual absWorkHeader absWorkHeader { get; set; }
    }
}
