namespace ILAManagementPro.Data.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WorkHeader")]
    public partial class WorkHeader
    {
        [Key]
        public int CounterId { get; set; }

        public DateTime? DateWorked { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Header { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Company { get; set; }

        [StringLength(7)]
        public string Berth { get; set; }

        [StringLength(15)]
        public string Vessel { get; set; }

        [Required]
        [StringLength(1)]
        public string CheckIn { get; set; }

        public DateTime? CheckInTime { get; set; }

        [StringLength(1)]
        public string CheckOut { get; set; }

        public DateTime? CheckOutTime { get; set; }

        [StringLength(8)]
        public string Description { get; set; }

        [StringLength(18)]
        public string Comment { get; set; }

        public DateTime? AddedDate { get; set; }

        [StringLength(20)]
        public string AddedUser { get; set; }

        public DateTime? UpdateDate { get; set; }

        [StringLength(20)]
        public string UpdateUser { get; set; }
    }
}
