using System;

namespace ILAManagementPro.Data.Data
{
    public class absvwWorkDetail
    {
        public int WorkDetailId { get; set; }

        public DateTime ScheduleDateWorked { get; set; }

        public string ScheduleCompany { get; set; }

        public string ScheduleCompanyName { get; set; }

        public string ScheduleBerth { get; set; }

        public string ScheduleVessel { get; set; }

        public DateTime ScheduleShiftTime { get; set; }

        public bool ScheduleDisplay { get; set; }

        public bool ScheduleCancelled { get; set; }

        public bool ScheduleBerthQuestion { get; set; }

        public Decimal? HeaderHeader { get; set; }

        public string HeaderHeaderName { get; set; }

        public string HeaderCheckIn { get; set; }

        public DateTime? HeaderCheckInTime { get; set; }

        public string HeaderCheckOut { get; set; }

        public DateTime? HeaderCheckOutTime { get; set; }

        public string HeaderDescription { get; set; }

        public string HeaderComment { get; set; }

        public string HeaderWorkGangDescription { get; set; }

        public int? DetailSequence { get; set; }

        public decimal? DetailCardNumber { get; set; }

        public string DetailMemberName { get; set; }

        public string DetailCheckIn { get; set; }

        public DateTime? DetailCheckInTime { get; set; }

        public string DetailCheckOut { get; set; }

        public DateTime? DetailCheckOutTime { get; set; }

        public string DetailComment { get; set; }

        public string ScheduleAddUser { get; set; }

        public DateTime? ScheduleAddDateTime { get; set; }

        public string ScheduleUpdateUser { get; set; }

        public DateTime? ScheduleUpdateDateTime { get; set; }

        public DateTime? HeaderAddedDate { get; set; }

        public string HeaderAddedUser { get; set; }

        public DateTime? HeaderUpdateDate { get; set; }

        public string HeaderUpdateUser { get; set; }

        public string DetailAddUser { get; set; }

        public DateTime? DetailAddDateTime { get; set; }

        public string DetailUpdateUser { get; set; }

        public DateTime? DetailUpdateDateTime { get; set; }
    }
}