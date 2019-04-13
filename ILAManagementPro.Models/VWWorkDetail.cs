using System;

namespace ILAManagementPro.Models
{
    public class VWWorkDetail
    {
        public DateTime DateWorked { get; set; }

        public string Company { get; set; }

        public string CompanyName { get; set; }

        public string Berth { get; set; }

        public string Vessel { get; set; }

        public DateTime ScheduleShiftTime { get; set; }

        public bool ScheduleDisplay { get; set; }

        public bool ScheduleCancelled { get; set; }

        public bool ScheduleBerthQuestion { get; set; }

        public decimal? Header { get; set; }

        public string HeaderName { get; set; }

        public string HdrCheckIn { get; set; }

        public DateTime? HdrCheckinTime { get; set; }

        public string HdrCheckOut { get; set; }

        public DateTime? HdrCheckOutTime { get; set; }

        public string HeaderDescription { get; set; }

        public string HeaderComment { get; set; }

        public string HeaderWorkGangDescription { get; set; }

        public int? Seq { get; set; }

        public decimal? CardNo { get; set; }

        public string DetlName { get; set; }

        public string CheckIn { get; set; }

        public DateTime? DtlCheckInTimeShow { get; set; }

        public string CheckOut { get; set; }

        public DateTime? DtlCheckOutTimeShow { get; set; }

        public string DetlComment { get; set; }

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

        public DateTime DateOfWork { get; set; }

        public DateTime? HdrCheckInTimeShow { get; set; }

        public DateTime? HdrCheckOutTimeShow { get; set; }

        public DateTime? DetlCheckInTime { get; set; }

        public DateTime? DtlCheckOutTime { get; set; }

        public DateTime? DetlCheckOutTime { get; set; }

        public string CardName { get; set; }

        public DateTime? CardCheckInTimeShow { get; set; }

        public string CardCheckOut { get; set; }

        public DateTime? CardCheckOutTimeShow { get; set; }

        public int RecNo { get; set; }

        public string Comment { get; set; }
    }
}