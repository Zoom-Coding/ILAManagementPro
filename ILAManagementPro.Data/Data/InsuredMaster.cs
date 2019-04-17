namespace ILAManagementPro.Data.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InsuredMaster")]
    public partial class InsuredMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InsuredMaster()
        {
            absBadgeCardCrossRef = new HashSet<absBadgeCardCrossRef>();
            absCallBack = new HashSet<absCallBack>();
            absDailySuspension = new HashSet<absDailySuspension>();
            absWorkHeader = new HashSet<absWorkHeader>();
            absWorkHeader1 = new HashSet<absWorkHeader>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        public decimal CardNo { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? OrigCardNo { get; set; }

        [StringLength(20)]
        public string LastName { get; set; }

        [StringLength(20)]
        public string OrigLastName { get; set; }

        [StringLength(1)]
        public string MI { get; set; }

        [StringLength(20)]
        public string MiddleName { get; set; }

        [StringLength(20)]
        public string FirstName { get; set; }

        [StringLength(20)]
        public string OrigFirstName { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(30)]
        public string City { get; set; }

        [StringLength(2)]
        public string ST { get; set; }

        [StringLength(10)]
        public string Zip { get; set; }

        public DateTime? DateBirth { get; set; }

        public DateTime? DateHired { get; set; }

        public DateTime? DateRetired { get; set; }

        [StringLength(3)]
        public string ClassCode { get; set; }

        [StringLength(1)]
        public string Sex { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SSN { get; set; }

        [StringLength(9)]
        public string SSNo { get; set; }

        [StringLength(10)]
        public string AreaPhone { get; set; }

        [StringLength(1)]
        public string PrintEmergFundCheck { get; set; }

        public bool? PrintLabel { get; set; }

        [StringLength(1)]
        public string Suspension { get; set; }

        public DateTime? SuspEndedDate { get; set; }

        public bool? CheckOffAuth { get; set; }

        public bool? CopeAuth { get; set; }

        [StringLength(1)]
        public string MemberAgencyFeePay { get; set; }

        public bool? VotingRights { get; set; }

        public bool? MemberServicePay { get; set; }

        [StringLength(1)]
        public string PerCapitaHourly { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? MonthCapitaDollars { get; set; }

        public bool? SendToExcelThisMonth { get; set; }

        [StringLength(20)]
        public string AddedUser { get; set; }

        public DateTime? AddedDate { get; set; }

        [StringLength(20)]
        public string UpdateUser { get; set; }

        public DateTime? UpdateDate { get; set; }

        public bool? HasNotes { get; set; }

        [StringLength(8)]
        public string strDateBirth { get; set; }

        [StringLength(8)]
        public string strDateHired { get; set; }

        [StringLength(8)]
        public string strDateRetired { get; set; }

        public DateTime? DateLastWorked { get; set; }

        public DateTime? DateDeceased { get; set; }

        public DateTime? DateRenewed { get; set; }

        public bool? HiringHallFee { get; set; }

        public bool? Active { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? EthnicOrigin { get; set; }

        public DateTime? MemberSince { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? LocalRate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CreditUnion { get; set; }

        public DateTime? EffDateChkOff { get; set; }

        public DateTime? EffDateHHFee { get; set; }

        public bool? Settlement { get; set; }

        public DateTime? DateSettleStart { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SettleAmt { get; set; }

        public bool? HeaderYN { get; set; }

        public bool? DailySuspension { get; set; }

        [StringLength(100)]
        public string DRIVER_TWIC_ID { get; set; }

        [StringLength(10)]
        public string CellPhone { get; set; }

        public string EmailAddress { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<absBadgeCardCrossRef> absBadgeCardCrossRef { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<absCallBack> absCallBack { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<absDailySuspension> absDailySuspension { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<absWorkHeader> absWorkHeader { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<absWorkHeader> absWorkHeader1 { get; set; }
    }
}
