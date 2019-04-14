using System;

namespace ILAManagementPro.Models
{
    public class AbsVWRecapDaysWorkedEntity : EntityBase
    {
        public DateTime FromWorkDate { get; set; }

        public DateTime ToWorkDate { get; set; }

        public Decimal CardNo { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string MI { get; set; }

        public string Class { get; set; }

        public string Sex { get; set; }

        public string UnionFlag { get; set; }

        public int InCount { get; set; }

        public int UnionCount { get; set; }

        public int NonUnionCount { get; set; }

        public int MenCount { get; set; }

        public int WomenCount { get; set; }

        public int BlackCount { get; set; }

        public int HispanicCount { get; set; }

        public int WhiteCount { get; set; }

        public int AsianCount { get; set; }

        public int OtherCount { get; set; }
    }
}