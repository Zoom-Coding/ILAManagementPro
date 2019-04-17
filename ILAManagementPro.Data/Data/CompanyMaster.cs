namespace ILAManagementPro.Data.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CompanyMaster")]
    public partial class CompanyMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CompanyMaster()
        {
            absWorkScheduleHeader = new HashSet<absWorkScheduleHeader>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        public decimal CoNo { get; set; }

        [StringLength(15)]
        public string CompanyId { get; set; }

        [StringLength(30)]
        public string CompanyName { get; set; }

        [StringLength(1)]
        public string CoSymbol { get; set; }

        [StringLength(5)]
        public string CompanyCode { get; set; }

        public bool Active { get; set; }

        [StringLength(30)]
        public string FileName { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CoImport { get; set; }

        [StringLength(20)]
        public string AddedUser { get; set; }

        public DateTime? AddedDate { get; set; }

        [StringLength(20)]
        public string UpdateUser { get; set; }

        public DateTime? UpdateDate { get; set; }

        public bool? HasNotes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<absWorkScheduleHeader> absWorkScheduleHeader { get; set; }
    }
}
