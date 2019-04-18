using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ILAManagementPro.Data.Data
{
    [Table("absvwWorkDetails")]
    public class absvwWorkDetail
    {
        [Key]
        public int WorkDetailId { get; set; }

        [Required]
        public DateTime ScheduleDateWorked { get; set; }
        
        [StringLength(15)]
        public string ScheduleCompany { get; set; }
        
        [StringLength(30)]
        public string ScheduleCompanyName { get; set; }

        [Required]
        [StringLength(10)]
        public string ScheduleBerth { get; set; }

        [Required]
        [StringLength(50)]
        public string ScheduleVessel { get; set; }

        [Required]
        public DateTime ScheduleShiftTime { get; set; }

        public bool ScheduleDisplay { get; set; }

        public bool ScheduleCancelled { get; set; }

        public bool ScheduleBerthQuestion { get; set; }

        public decimal? HeaderHeader { get; set; }

        [StringLength(43)]
        public string HeaderHeaderName { get; set; }

        [StringLength(1)]
        public string HeaderCheckIn { get; set; }

        public DateTime? HeaderCheckInTime { get; set; }

        [StringLength(1)]
        public string HeaderCheckOut { get; set; }

        public DateTime? HeaderCheckOutTime { get; set; }

        [StringLength(8)]
        public string HeaderDescription { get; set; }

        [StringLength(18)]
        public string HeaderComment { get; set; }

        [Required]
        [StringLength(50)]
        public string HeaderWorkGangDescription { get; set; }

        public int? DetailSequence { get; set; }

        public decimal? DetailCardNumber { get; set; }

        [StringLength(43)]
        public string DetailMemberName { get; set; }

        [StringLength(1)]
        public string DetailCheckIn { get; set; }

        public DateTime? DetailCheckInTime { get; set; }

        [StringLength(1)]
        public string DetailCheckOut { get; set; }

        public DateTime? DetailCheckOutTime { get; set; }

        [StringLength(250)]
        public string DetailComment { get; set; }

        [StringLength(50)]
        public string ScheduleAddUser { get; set; }

        public DateTime? ScheduleAddDateTime { get; set; }

        [StringLength(50)]
        public string ScheduleUpdateUser { get; set; }

        public DateTime? ScheduleUpdateDateTime { get; set; }

        public DateTime? HeaderAddedDate { get; set; }

        [StringLength(20)]
        public string HeaderAddedUser { get; set; }

        public DateTime? HeaderUpdateDate { get; set; }

        [StringLength(20)]
        public string HeaderUpdateUser { get; set; }

        [StringLength(20)]
        public string DetailAddUser { get; set; }

        public DateTime? DetailAddDateTime { get; set; }

        [StringLength(20)]
        public string DetailUpdateUser { get; set; }

        public DateTime? DetailUpdateDateTime { get; set; }
    }
}