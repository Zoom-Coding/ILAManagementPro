namespace ILAManagementPro.Data.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("absShiftTimes")]
    public partial class absShiftTime
    {
        public int id { get; set; }

        [Required]
        [StringLength(8)]
        public string DisplayTime { get; set; }

        [Required]
        [StringLength(5)]
        public string MilitaryTime { get; set; }

        [Required]
        [StringLength(5)]
        public string PickTime { get; set; }

        [StringLength(50)]
        public string AddUser { get; set; }

        public DateTime? AddDateTime { get; set; }

        [StringLength(50)]
        public string UpdateUser { get; set; }

        public DateTime? UpdateDateTime { get; set; }
    }
}
