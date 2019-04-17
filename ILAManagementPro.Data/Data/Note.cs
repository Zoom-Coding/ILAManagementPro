namespace ILAManagementPro.Data.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Notes")]
    public partial class Note
    {
        [Key]
        public int NoteId { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CardNo { get; set; }

        [Column("Note", TypeName = "ntext")]
        public string Content { get; set; }

        [StringLength(20)]
        public string AddedUser { get; set; }

        public DateTime? AddedDate { get; set; }

        [StringLength(20)]
        public string UpdateUser { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}
