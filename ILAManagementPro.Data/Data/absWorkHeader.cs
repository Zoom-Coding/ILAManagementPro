namespace ILAManagementPro.Data.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("absWorkHeader")]
    public partial class absWorkHeader
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public absWorkHeader()
        {
            absWorkDetail = new HashSet<absWorkDetail>();
        }

        [Key]
        public int CounterId { get; set; }

        public int? WorkScheduleHeaderId { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Header { get; set; }

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

        public int? WorkGangDescriptionId { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ReplaceHeaderId { get; set; }

        [StringLength(50)]
        public string Location { get; set; }

        public DateTime? AddedDate { get; set; }

        [StringLength(20)]
        public string AddedUser { get; set; }

        public DateTime? UpdateDate { get; set; }

        [StringLength(20)]
        public string UpdateUser { get; set; }

        [StringLength(250)]
        public string DriverFile { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<absWorkDetail> absWorkDetail { get; set; }

        public virtual absWorkGangDescription absWorkGangDescription { get; set; }

        public virtual absWorkScheduleHeader absWorkScheduleHeader { get; set; }

        public virtual InsuredMaster InsuredMaster { get; set; }

        public virtual InsuredMaster InsuredMaster1 { get; set; }
    }
}
