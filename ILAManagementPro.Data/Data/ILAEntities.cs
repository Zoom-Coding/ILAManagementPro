namespace ILAManagementPro.Data.Data
{
    using System.Data.Entity;

    public partial class ILAEntities : DbContext
    {
        public ILAEntities()
            : base("name=ILAEntities")
        {
        }

        public virtual DbSet<absBadgeCardCrossRef> absBadgeCardCrossRefs { get; set; }
        public virtual DbSet<absBerth> absBerths { get; set; }
        public virtual DbSet<absCallBack> absCallBacks { get; set; }
        public virtual DbSet<absConfiguration> absConfigurations { get; set; }
        public virtual DbSet<absDailySuspension> absDailySuspensions { get; set; }
        public virtual DbSet<absGangSchedule> absGangSchedules { get; set; }
        public virtual DbSet<absScheduleNote> absScheduleNotes { get; set; }
        public virtual DbSet<absSecurity> absSecurities { get; set; }
        public virtual DbSet<absShiftTime> absShiftTimes { get; set; }
        public virtual DbSet<absVessel> absVessels { get; set; }
        public virtual DbSet<absWorkDetail> absWorkDetails { get; set; }
        public virtual DbSet<absWorkGangDescription> absWorkGangDescriptions { get; set; }
        public virtual DbSet<absWorkGangTemplate> absWorkGangTemplates { get; set; }
        public virtual DbSet<absWorkHeader> absWorkHeaders { get; set; }
        public virtual DbSet<absWorkScheduleHeader> absWorkScheduleHeaders { get; set; }
        public virtual DbSet<absWorkScheduleLogin> absWorkScheduleLogins { get; set; }
        public virtual DbSet<CompanyMaster> CompanyMasters { get; set; }
        public virtual DbSet<IMEmergencyContact> IMEmergencyContacts { get; set; }
        public virtual DbSet<InsuredMaster> InsuredMasters { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<WorkHeader> WorkHeaders { get; set; }
        public virtual DbSet<WorkDetail> WorkDetails { get; set; }
        public virtual DbSet<TimeCardEntryErrorLog> TimeCardEntryErrorLogs { get; set; }
        public virtual DbSet<absvwMemberDetail> absvwMemberDetails { get; set; }
        public virtual DbSet<absvwWorkDetail> absvwWorkDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<absBadgeCardCrossRef>()
                .Property(e => e.CardNumber)
                .HasPrecision(9, 0);

            modelBuilder.Entity<absBerth>()
                .Property(e => e.BerthShortName)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<absBerth>()
                .Property(e => e.BerthFullName)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<absBerth>()
                .HasMany(e => e.absWorkScheduleHeader)
                .WithRequired(e => e.absBerth)
                .HasForeignKey(e => e.BerthId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<absCallBack>()
                .Property(e => e.cardNumberId)
                .HasPrecision(9, 0);

            modelBuilder.Entity<absCallBack>()
                .Property(e => e.phoneNumber)
                .IsFixedLength();

            modelBuilder.Entity<absConfiguration>()
                .Property(e => e.keyValue)
                .IsUnicode(false);

            modelBuilder.Entity<absConfiguration>()
                .Property(e => e.propValue)
                .IsUnicode(false);

            modelBuilder.Entity<absDailySuspension>()
                .Property(e => e.CardNumber)
                .HasPrecision(9, 0);

            modelBuilder.Entity<absGangSchedule>()
                .Property(e => e.LloydsId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<absGangSchedule>()
                .Property(e => e.OutVoyage)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<absGangSchedule>()
                .Property(e => e.Berth)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<absGangSchedule>()
                .Property(e => e.Gang)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<absScheduleNote>()
                .Property(e => e.note)
                .IsUnicode(false);

            modelBuilder.Entity<absShiftTime>()
                .Property(e => e.DisplayTime)
                .IsFixedLength();

            modelBuilder.Entity<absShiftTime>()
                .Property(e => e.MilitaryTime)
                .IsFixedLength();

            modelBuilder.Entity<absShiftTime>()
                .Property(e => e.PickTime)
                .IsFixedLength();

            modelBuilder.Entity<absVessel>()
                .Property(e => e.VesselName)
                .IsFixedLength();

            modelBuilder.Entity<absVessel>()
                .Property(e => e.LLoydsId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<absVessel>()
                .HasMany(e => e.absWorkScheduleHeader)
                .WithRequired(e => e.absVessel)
                .HasForeignKey(e => e.VesselId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<absWorkDetail>()
                .Property(e => e.CardNo)
                .HasPrecision(9, 0);

            modelBuilder.Entity<absWorkDetail>()
                .Property(e => e.CheckIn)
                .IsFixedLength();

            modelBuilder.Entity<absWorkDetail>()
                .Property(e => e.CheckOut)
                .IsFixedLength();

            modelBuilder.Entity<absWorkDetail>()
                .Property(e => e.DetlComment)
                .IsFixedLength();

            modelBuilder.Entity<absWorkDetail>()
                .Property(e => e.AddUser)
                .IsFixedLength();

            modelBuilder.Entity<absWorkDetail>()
                .Property(e => e.UpdateUser)
                .IsFixedLength();

            modelBuilder.Entity<absWorkDetail>()
                .Property(e => e.TrashPile)
                .IsFixedLength();

            modelBuilder.Entity<absWorkGangDescription>()
                .Property(e => e.WorkGangDescription)
                .IsFixedLength();

            modelBuilder.Entity<absWorkGangDescription>()
                .HasMany(e => e.absWorkHeader)
                .WithOptional(e => e.absWorkGangDescription)
                .HasForeignKey(e => e.WorkGangDescriptionId);

            modelBuilder.Entity<absWorkGangTemplate>()
                .Property(e => e.TemplateDescription)
                .IsFixedLength();

            modelBuilder.Entity<absWorkHeader>()
                .Property(e => e.Header)
                .HasPrecision(9, 0);

            modelBuilder.Entity<absWorkHeader>()
                .Property(e => e.CheckIn)
                .IsFixedLength();

            modelBuilder.Entity<absWorkHeader>()
                .Property(e => e.CheckOut)
                .IsFixedLength();

            modelBuilder.Entity<absWorkHeader>()
                .Property(e => e.Comment)
                .IsFixedLength();

            modelBuilder.Entity<absWorkHeader>()
                .Property(e => e.ReplaceHeaderId)
                .HasPrecision(9, 0);

            modelBuilder.Entity<absWorkHeader>()
                .Property(e => e.AddedUser)
                .IsFixedLength();

            modelBuilder.Entity<absWorkHeader>()
                .Property(e => e.UpdateUser)
                .IsFixedLength();

            modelBuilder.Entity<absWorkHeader>()
                .HasMany(e => e.absWorkDetail)
                .WithRequired(e => e.absWorkHeader)
                .HasForeignKey(e => e.absWorkHeaderId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<absWorkScheduleHeader>()
                .Property(e => e.CompanyId)
                .HasPrecision(3, 0);

            modelBuilder.Entity<absWorkScheduleHeader>()
                .Property(e => e.SetBack)
                .IsFixedLength();

            modelBuilder.Entity<absWorkScheduleHeader>()
                .HasMany(e => e.absWorkHeader)
                .WithOptional(e => e.absWorkScheduleHeader)
                .HasForeignKey(e => e.WorkScheduleHeaderId);

            modelBuilder.Entity<absWorkScheduleLogin>()
                .Property(e => e.UserId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CompanyMaster>()
                .Property(e => e.CoNo)
                .HasPrecision(3, 0);

            modelBuilder.Entity<CompanyMaster>()
                .Property(e => e.CompanyName)
                .IsUnicode(false);

            modelBuilder.Entity<CompanyMaster>()
                .Property(e => e.CoSymbol)
                .IsFixedLength();

            modelBuilder.Entity<CompanyMaster>()
                .Property(e => e.CompanyCode)
                .IsFixedLength();

            modelBuilder.Entity<CompanyMaster>()
                .Property(e => e.FileName)
                .IsUnicode(false);

            modelBuilder.Entity<CompanyMaster>()
                .Property(e => e.CoImport)
                .HasPrecision(1, 0);

            modelBuilder.Entity<CompanyMaster>()
                .Property(e => e.AddedUser)
                .IsFixedLength();

            modelBuilder.Entity<CompanyMaster>()
                .Property(e => e.UpdateUser)
                .IsFixedLength();

            modelBuilder.Entity<CompanyMaster>()
                .HasMany(e => e.absWorkScheduleHeader)
                .WithRequired(e => e.CompanyMaster)
                .HasForeignKey(e => e.CompanyId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<IMEmergencyContact>()
                .Property(e => e.CardNo)
                .HasPrecision(9, 0);

            modelBuilder.Entity<IMEmergencyContact>()
                .Property(e => e.Phone1)
                .IsFixedLength();

            modelBuilder.Entity<IMEmergencyContact>()
                .Property(e => e.Phone2)
                .IsFixedLength();

            modelBuilder.Entity<InsuredMaster>()
                .Property(e => e.CardNo)
                .HasPrecision(9, 0);

            modelBuilder.Entity<InsuredMaster>()
                .Property(e => e.OrigCardNo)
                .HasPrecision(9, 0);

            modelBuilder.Entity<InsuredMaster>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<InsuredMaster>()
                .Property(e => e.OrigLastName)
                .IsFixedLength();

            modelBuilder.Entity<InsuredMaster>()
                .Property(e => e.MI)
                .IsFixedLength();

            modelBuilder.Entity<InsuredMaster>()
                .Property(e => e.MiddleName)
                .IsUnicode(false);

            modelBuilder.Entity<InsuredMaster>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<InsuredMaster>()
                .Property(e => e.OrigFirstName)
                .IsUnicode(false);

            modelBuilder.Entity<InsuredMaster>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<InsuredMaster>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<InsuredMaster>()
                .Property(e => e.ST)
                .IsFixedLength();

            modelBuilder.Entity<InsuredMaster>()
                .Property(e => e.Zip)
                .IsFixedLength();

            modelBuilder.Entity<InsuredMaster>()
                .Property(e => e.ClassCode)
                .IsFixedLength();

            modelBuilder.Entity<InsuredMaster>()
                .Property(e => e.Sex)
                .IsFixedLength();

            modelBuilder.Entity<InsuredMaster>()
                .Property(e => e.SSN)
                .HasPrecision(9, 0);

            modelBuilder.Entity<InsuredMaster>()
                .Property(e => e.SSNo)
                .IsUnicode(false);

            modelBuilder.Entity<InsuredMaster>()
                .Property(e => e.AreaPhone)
                .IsFixedLength();

            modelBuilder.Entity<InsuredMaster>()
                .Property(e => e.PrintEmergFundCheck)
                .IsFixedLength();

            modelBuilder.Entity<InsuredMaster>()
                .Property(e => e.Suspension)
                .IsFixedLength();

            modelBuilder.Entity<InsuredMaster>()
                .Property(e => e.MemberAgencyFeePay)
                .IsFixedLength();

            modelBuilder.Entity<InsuredMaster>()
                .Property(e => e.PerCapitaHourly)
                .IsFixedLength();

            modelBuilder.Entity<InsuredMaster>()
                .Property(e => e.AddedUser)
                .IsUnicode(false);

            modelBuilder.Entity<InsuredMaster>()
                .Property(e => e.UpdateUser)
                .IsUnicode(false);

            modelBuilder.Entity<InsuredMaster>()
                .Property(e => e.strDateBirth)
                .IsFixedLength();

            modelBuilder.Entity<InsuredMaster>()
                .Property(e => e.strDateHired)
                .IsFixedLength();

            modelBuilder.Entity<InsuredMaster>()
                .Property(e => e.strDateRetired)
                .IsFixedLength();

            modelBuilder.Entity<InsuredMaster>()
                .Property(e => e.EthnicOrigin)
                .HasPrecision(2, 0);

            modelBuilder.Entity<InsuredMaster>()
                .Property(e => e.LocalRate)
                .HasPrecision(2, 0);

            modelBuilder.Entity<InsuredMaster>()
                .Property(e => e.CreditUnion)
                .HasPrecision(2, 0);

            modelBuilder.Entity<InsuredMaster>()
                .Property(e => e.DRIVER_TWIC_ID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<InsuredMaster>()
                .Property(e => e.CellPhone)
                .IsFixedLength();

            modelBuilder.Entity<InsuredMaster>()
                .HasMany(e => e.absBadgeCardCrossRef)
                .WithRequired(e => e.InsuredMaster)
                .HasForeignKey(e => e.CardNumber)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InsuredMaster>()
                .HasMany(e => e.absCallBack)
                .WithRequired(e => e.InsuredMaster)
                .HasForeignKey(e => e.cardNumberId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InsuredMaster>()
                .HasMany(e => e.absDailySuspension)
                .WithRequired(e => e.InsuredMaster)
                .HasForeignKey(e => e.CardNumber)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InsuredMaster>()
                .HasMany(e => e.absWorkHeader)
                .WithOptional(e => e.InsuredMaster)
                .HasForeignKey(e => e.Header);

            modelBuilder.Entity<InsuredMaster>()
                .HasMany(e => e.absWorkHeader1)
                .WithOptional(e => e.InsuredMaster1)
                .HasForeignKey(e => e.ReplaceHeaderId);

            modelBuilder.Entity<Note>()
                .Property(e => e.CardNo)
                .HasPrecision(9, 0);

            modelBuilder.Entity<Note>()
                .Property(e => e.AddedUser)
                .IsFixedLength();

            modelBuilder.Entity<Note>()
                .Property(e => e.UpdateUser)
                .IsFixedLength();

            modelBuilder.Entity<WorkHeader>()
                .Property(e => e.Header)
                .HasPrecision(9, 0);

            modelBuilder.Entity<WorkHeader>()
                .Property(e => e.Company)
                .HasPrecision(3, 0);

            modelBuilder.Entity<WorkHeader>()
                .Property(e => e.Berth)
                .IsFixedLength();

            modelBuilder.Entity<WorkHeader>()
                .Property(e => e.Vessel)
                .IsFixedLength();

            modelBuilder.Entity<WorkHeader>()
                .Property(e => e.CheckIn)
                .IsFixedLength();

            modelBuilder.Entity<WorkHeader>()
                .Property(e => e.CheckOut)
                .IsFixedLength();

            modelBuilder.Entity<WorkHeader>()
                .Property(e => e.Comment)
                .IsFixedLength();

            modelBuilder.Entity<WorkHeader>()
                .Property(e => e.AddedUser)
                .IsFixedLength();

            modelBuilder.Entity<WorkHeader>()
                .Property(e => e.UpdateUser)
                .IsFixedLength();

            modelBuilder.Entity<TimeCardEntryErrorLog>()
                .Property(e => e.Cardno)
                .HasPrecision(9, 0);

            modelBuilder.Entity<TimeCardEntryErrorLog>()
                .Property(e => e.MsgNo)
                .IsFixedLength();

            modelBuilder.Entity<TimeCardEntryErrorLog>()
                .Property(e => e.MsgDetails)
                .IsFixedLength();

            modelBuilder.Entity<TimeCardEntryErrorLog>()
                .Property(e => e.AnsYN)
                .IsFixedLength();

            modelBuilder.Entity<TimeCardEntryErrorLog>()
                .Property(e => e.Header)
                .HasPrecision(9, 0);

            modelBuilder.Entity<TimeCardEntryErrorLog>()
                .Property(e => e.Company)
                .HasPrecision(3, 0);

            modelBuilder.Entity<TimeCardEntryErrorLog>()
                .Property(e => e.Berth)
                .IsFixedLength();

            modelBuilder.Entity<TimeCardEntryErrorLog>()
                .Property(e => e.Vessel)
                .IsFixedLength();

            modelBuilder.Entity<TimeCardEntryErrorLog>()
                .Property(e => e.OtherHeader)
                .HasPrecision(9, 0);

            modelBuilder.Entity<TimeCardEntryErrorLog>()
                .Property(e => e.AddedUser)
                .IsFixedLength();
        }
    }
}
