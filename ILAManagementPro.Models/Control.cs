using System;

namespace ILAManagementPro.Models
{
    public class Control : EntityBase
    {
        public string FtpFileName { get; set; }

        public string FtpFileFolder { get; set; }

        public string FtpDrugTestFileName { get; set; }

        public string FtpWelfareFileName { get; set; }

        public string FtpWelfareArchiveFileName { get; set; }

        public string FtpScriptFileName { get; set; }

        public string FtpLogFileName { get; set; }

        public string FtpBatchFileName { get; set; }

        public string FtpServerAddress { get; set; }

        public string FtpUserId { get; set; }

        public string FtpPWD { get; set; }

        public decimal? EmpDues { get; set; }

        public decimal? UnionDues { get; set; }

        public DateTime? FtpCutOff { get; set; }

        public decimal? FtpInterval { get; set; }

        public string FtpSendFileName { get; set; }

        public bool? CheckInProcess { get; set; }

        public bool? CreditUnionInProcess { get; set; }

        public string CoImportFileFolder { get; set; }

        public string CoImportArchiveFolder { get; set; }

        public decimal? HHRate { get; set; }

        public string WeekImportTo { get; set; }

        public string WeekImportCC { get; set; }

        public string AccountantTo { get; set; }

        public string AccountantCC { get; set; }

        public string EmailWeek { get; set; }

        public string EmailAcct { get; set; }

        public string UpdateUser { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}