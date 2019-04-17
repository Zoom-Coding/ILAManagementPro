using System;
using System.Collections.Generic;

namespace ILAManagementPro.Data.Data
{
    public class InsuredMaster
    {
        public InsuredMaster()
        {
            this.absBadgeCardCrossRefs = (ICollection<absBadgeCardCrossRef>)new HashSet<absBadgeCardCrossRef>();
            this.absDailySuspensions = (ICollection<absDailySuspension>)new HashSet<absDailySuspension>();
            this.absCallBacks = (ICollection<absCallBack>)new HashSet<absCallBack>();
            this.absWorkHeaders = (ICollection<absWorkHeader>)new HashSet<absWorkHeader>();
            this.absWorkHeaders1 = (ICollection<absWorkHeader>)new HashSet<absWorkHeader>();
        }

        public decimal CardNo { get; set; }

        public decimal? OrigCardNo { get; set; }

        public string LastName { get; set; }

        public string OrigLastName { get; set; }

        public string MI { get; set; }

        public string MiddleName { get; set; }

        public string FirstName { get; set; }

        public string OrigFirstName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string ST { get; set; }

        public string Zip { get; set; }

        public DateTime? DateBirth { get; set; }

        public DateTime? DateHired { get; set; }

        public DateTime? DateRetired { get; set; }

        public string ClassCode { get; set; }

        public string Sex { get; set; }

        public decimal? SSN { get; set; }

        public string SSNo { get; set; }

        public string AreaPhone { get; set; }

        public string PrintEmergFundCheck { get; set; }

        public bool? PrintLabel { get; set; }

        public string Suspension { get; set; }

        public DateTime? SuspEndedDate { get; set; }

        public bool? CheckOffAuth { get; set; }

        public bool? CopeAuth { get; set; }

        public string MemberAgencyFeePay { get; set; }

        public bool? VotingRights { get; set; }

        public bool? MemberServicePay { get; set; }

        public string PerCapitaHourly { get; set; }

        public decimal? MonthCapitaDollars { get; set; }

        public bool? SendToExcelThisMonth { get; set; }

        public string AddedUser { get; set; }

        public DateTime? AddedDate { get; set; }

        public string UpdateUser { get; set; }

        public DateTime? UpdateDate { get; set; }

        public bool? HasNotes { get; set; }

        public string strDateBirth { get; set; }

        public string strDateHired { get; set; }

        public string strDateRetired { get; set; }

        public DateTime? DateLastWorked { get; set; }

        public DateTime? DateDeceased { get; set; }

        public DateTime? DateRenewed { get; set; }

        public bool? HiringHallFee { get; set; }

        public bool? Active { get; set; }

        public decimal? EthnicOrigin { get; set; }

        public DateTime? MemberSince { get; set; }

        public decimal? LocalRate { get; set; }

        public decimal? CreditUnion { get; set; }

        public DateTime? EffDateChkOff { get; set; }

        public DateTime? EffDateHHFee { get; set; }

        public bool? Settlement { get; set; }

        public DateTime? DateSettleStart { get; set; }

        public decimal? SettleAmt { get; set; }

        public bool? HeaderYN { get; set; }

        public bool? DailySuspension { get; set; }

        public string DRIVER_TWIC_ID { get; set; }

        public string CellPhone { get; set; }

        public string EmailAddress { get; set; }

        public virtual ICollection<absBadgeCardCrossRef> absBadgeCardCrossRefs { get; set; }

        public virtual ICollection<absDailySuspension> absDailySuspensions { get; set; }

        public virtual ICollection<absCallBack> absCallBacks { get; set; }

        public virtual ICollection<absWorkHeader> absWorkHeaders { get; set; }

        public virtual ICollection<absWorkHeader> absWorkHeaders1 { get; set; }
    }
}