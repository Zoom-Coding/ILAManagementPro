namespace ILAManagementPro.Models
{
    public class PensionHrsEntity : EntityBase
    {
        public string MemberNum { get; set; }

        public decimal? CalendarYr { get; set; }

        public decimal? ContractYr { get; set; }

        public decimal? Hours { get; set; }

        public decimal? AccumulatedHrs { get; set; }

        public decimal? AccumulatedYrs { get; set; }

        public string GratuitousType { get; set; }

        public string Desc { get; set; }
    }
}