using System;
using System.ComponentModel.DataAnnotations;

namespace ILAManagementPro.Data.Data
{
    public class absGPACredential
    {
        public decimal CARD_ID { get; set; }

        [StringLength(255)]
        public string NAME { get; set; }

        [StringLength(255)]
        public string FIRST_NAME { get; set; }

        [StringLength(255)]
        public string MIDDLE_INIT { get; set; }

        [StringLength(255)]
        public string LAST_NAME { get; set; }

        [StringLength(255)]
        public string ADDRESS { get; set; }

        [StringLength(255)]
        public string CITY { get; set; }

        [StringLength(255)]
        public string STATE { get; set; }

        public string ZIP { get; set; }

        public DateTime? DOB { get; set; }

        [StringLength(255)]
        public string GENDER { get; set; }

        public decimal? SSN { get; set; }

        [StringLength(255)]
        public string RACE { get; set; }

        public decimal? ILACardNumber { get; set; }
    }
}
