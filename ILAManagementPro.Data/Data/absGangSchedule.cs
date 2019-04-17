namespace ILAManagementPro.Data.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("absGangSchedule")]
    public partial class absGangSchedule
    {
        public int id { get; set; }

        [Required]
        [StringLength(7)]
        public string LloydsId { get; set; }

        [StringLength(5)]
        public string OutVoyage { get; set; }

        [StringLength(4)]
        public string Berth { get; set; }

        public DateTime? StartTime { get; set; }

        [StringLength(7)]
        public string Gang { get; set; }

        public DateTime? AddDateTime { get; set; }
    }
}
