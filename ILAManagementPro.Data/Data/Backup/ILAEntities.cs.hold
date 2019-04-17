using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;

namespace ILAManagementPro.Data.Data
{
    public class ILAEntities : DbContext
    {
        public ILAEntities()
      : base("name=ILAEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public DbSet<CompanyMaster> CompanyMasters { get; set; }

        public DbSet<InsuredMaster> InsuredMasters { get; set; }

        public DbSet<absBerth> absBerths { get; set; }

        public DbSet<absVessel> absVessels { get; set; }

        public DbSet<absWorkGangDescription> absWorkGangDescriptions { get; set; }

        public DbSet<absvwWorkSchedule> absvwWorkSchedules { get; set; }

        public DbSet<absWorkScheduleHeader> absWorkScheduleHeaders { get; set; }

        public DbSet<absConfiguration> absConfigurations { get; set; }

        public DbSet<absWorkScheduleLogin> absWorkScheduleLogins { get; set; }

        public DbSet<absBadgeCardCrossRef> absBadgeCardCrossRefs { get; set; }

        public DbSet<absScheduleNote> absScheduleNotes { get; set; }

        public DbSet<absDailySuspension> absDailySuspensions { get; set; }

        public DbSet<absShiftTime> absShiftTimes { get; set; }

        public DbSet<absCallBack> absCallBacks { get; set; }

        public DbSet<absWorkHeader> absWorkHeaders { get; set; }

        public DbSet<absWorkDetail> absWorkDetails { get; set; }

        public DbSet<Note> Notes { get; set; }

        public DbSet<WorkDetail> WorkDetails { get; set; }

        public DbSet<WorkHeader> WorkHeaders { get; set; }

        public DbSet<absvwWorkDetail> absvwWorkDetails { get; set; }

        public DbSet<absSecurity> absSecurities { get; set; }

        public DbSet<absGPACredential> absGPACredentials { get; set; }

        public DbSet<TimeCardEntryErrorLog> TimeCardEntryErrorLogs { get; set; }

        public DbSet<absGangSchedule> absGangSchedules { get; set; }

        public DbSet<absWorkGangTemplate> absWorkGangTemplates { get; set; }

        public DbSet<absvwMemberDetail> absvwMemberDetails { get; set; }

        public DbSet<IMEmergencyContact> IMEmergencyContacts { get; set; }

        public virtual ObjectResult<abscGetWorkScheduleByDateResult> GetWorkScheduleByDate(DateTime? date)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<abscGetWorkScheduleByDateResult>(nameof(GetWorkScheduleByDate), date.HasValue ? new ObjectParameter("Date", (object)date) : new ObjectParameter("Date", typeof(DateTime)));
        }
    }
}