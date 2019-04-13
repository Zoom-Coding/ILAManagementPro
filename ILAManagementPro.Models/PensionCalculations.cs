namespace ILAManagementPro.Models
{
    public class PensionCalculations : EntityBase
    {
        public string MemberNum { get; set; }

        public int? CreditedYears { get; set; }

        public decimal? CreditedHours { get; set; }

        public int? ParticipantAge { get; set; }

        public int? SpouseAge { get; set; }

        public decimal? MonthlyPension_0 { get; set; }

        public decimal? MonthlyPension_5 { get; set; }

        public decimal? MonthlyPension_10 { get; set; }

        public decimal? MonthlyPension_15 { get; set; }

        public decimal? MonthlyPension_20 { get; set; }

        public decimal? MonthlyPension_25 { get; set; }

        public decimal? LumpSum_0 { get; set; }

        public decimal? LumpSum_5 { get; set; }

        public decimal? LumpSum_10 { get; set; }

        public decimal? LumpSum_15 { get; set; }

        public decimal? LumpSum_20 { get; set; }

        public decimal? LumpSum_25 { get; set; }

        public decimal? MemberPension_0 { get; set; }

        public decimal? MemberPension_5 { get; set; }

        public decimal? MemberPension_10 { get; set; }

        public decimal? MemberPension_15 { get; set; }

        public decimal? MemberPension_20 { get; set; }

        public decimal? MemberPension_25 { get; set; }

        public decimal? SpousePension_0 { get; set; }

        public decimal? SpousePension_5 { get; set; }

        public decimal? SpousePension_10 { get; set; }

        public decimal? SpousePension_15 { get; set; }

        public decimal? SpousePension_20 { get; set; }

        public decimal? SpousePension_25 { get; set; }
    }
}