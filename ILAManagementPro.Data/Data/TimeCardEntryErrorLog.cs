namespace ILAManagementPro.Data.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TimeCardEntryErrorLog")]
    public partial class TimeCardEntryErrorLog
    {
        [Key]
        [Column(TypeName = "numeric")]
        public decimal Cardno { get; set; }

        public DateTime? DateofWork { get; set; }

        [StringLength(10)]
        public string MsgNo { get; set; }

        [StringLength(500)]
        public string MsgDetails { get; set; }

        [StringLength(3)]
        public string AnsYN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Header { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Company { get; set; }

        [StringLength(7)]
        public string Berth { get; set; }

        [StringLength(15)]
        public string Vessel { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? OtherHeader { get; set; }

        public DateTime? OtherDate { get; set; }

        [StringLength(20)]
        public string AddedUser { get; set; }

        public DateTime? AddedDate { get; set; }
    }
}
