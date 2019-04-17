namespace ILAManagementPro.Data.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("absBadgeCardCrossRef")]
    public partial class absBadgeCardCrossRef
    {
        public int id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CardNumber { get; set; }

        public int BadgeNumber { get; set; }

        [StringLength(50)]
        public string AddUser { get; set; }

        public DateTime? AddDateTime { get; set; }

        [StringLength(50)]
        public string UpdateUser { get; set; }

        public DateTime? UpdateDateTime { get; set; }

        public virtual InsuredMaster InsuredMaster { get; set; }
    }
}