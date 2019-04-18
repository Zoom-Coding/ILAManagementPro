using System;
using System.ComponentModel.DataAnnotations;

namespace ILAManagementPro.Data.Data
{
    public class absvwWorkSchedule
    {
        [Key]
        public int Id { get; set; }

        [StringLength(11)]
        public string Berth { get; set; }

        [StringLength(50)]
        public string Vessel { get; set; }

        [Required]
        public DateTime ShiftDateTime { get; set; }

        [StringLength(15)]
        public string Company { get; set; }

        [StringLength(8000)]
        public string Header { get; set; }

        [StringLength(4000)]
        public string GangDescription { get; set; }

        [Required]
        public bool Cancelled { get; set; }

        [Required]
        public int IsReplacementHeader { get; set; }

        [StringLength(20)]
        public string SetBack { get; set; }

        public bool? EmergencyGang { get; set; }
    }
}