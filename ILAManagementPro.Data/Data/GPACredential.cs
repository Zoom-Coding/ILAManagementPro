using System;

namespace ILAManagementPro.Data.Data
{
    public class GPACredential
    {
        public decimal CARD_ID { get; set; }

        public string NAME { get; set; }

        public string FIRST_NAME { get; set; }

        public string MIDDLE_INIT { get; set; }

        public string LAST_NAME { get; set; }

        public string ADDRESS { get; set; }

        public string CITY { get; set; }

        public string STATE { get; set; }

        public string ZIP { get; set; }

        public DateTime? DOB { get; set; }

        public string GENDER { get; set; }

        public decimal? SSN { get; set; }

        public string RACE { get; set; }

        public decimal? ILACardNumber { get; set; }
    }
}