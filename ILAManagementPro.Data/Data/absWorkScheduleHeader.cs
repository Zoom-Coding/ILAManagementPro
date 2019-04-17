namespace ILAManagementPro.Data.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("absWorkScheduleHeader")]
    public partial class absWorkScheduleHeader
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public absWorkScheduleHeader()
        {
            absWorkHeader = new HashSet<absWorkHeader>();
        }

        public int id { get; set; }

        public DateTime DateWorked { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CompanyId { get; set; }

        public int BerthId { get; set; }

        public int VesselId { get; set; }

        public DateTime ShiftTime { get; set; }

        public bool Display { get; set; }

        public bool Cancelled { get; set; }

        public bool BerthQuestion { get; set; }

        [StringLength(20)]
        public string SetBack { get; set; }

        public bool? EmergencyGang { get; set; }

        [StringLength(50)]
        public string AddUser { get; set; }

        public DateTime? AddDateTime { get; set; }

        [StringLength(50)]
        public string UpdateUser { get; set; }

        public DateTime? UpdateDateTime { get; set; }

        public virtual absBerth absBerth { get; set; }

        public virtual absVessel absVessel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<absWorkHeader> absWorkHeader { get; set; }

        public virtual CompanyMaster CompanyMaster { get; set; }
    }
}
