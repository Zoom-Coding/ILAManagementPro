using System;
using System.Collections.Generic;
using System.Linq;

namespace ILAManagementPro.Models
{
    public class absWorkHeaderEntity : EntityBase
    {
        public absWorkHeaderEntity()
        {
        }

        public absWorkHeaderEntity(absWorkHeaderEntity old)
        {
            this.Id = old.Id;
            this.Description = old.Description;
            this.WorkScheduleHeader = new WorkScheduleHeaderEntity(old.WorkScheduleHeader);
            if (old.Header != null)
                this.Header = new HeaderEntity(old.Header);
            this.CheckIn = old.CheckIn;
            this.CheckInTime = old.CheckInTime;
            this.CheckOut = old.CheckOut;
            this.workDescription = old.workDescription;
            this.Comment = old.Comment;
            if (old.GangDescription != null)
                this.GangDescription = new WorkGangDescriptionEntity(old.GangDescription);
            if (old.WorkDetails != null)
            {
                absWorkDetailEntity[] array = new absWorkDetailEntity[old.WorkDetails.Count];
                old.WorkDetails.CopyTo(array);
                this.WorkDetails = ((IEnumerable<absWorkDetailEntity>)array).ToList<absWorkDetailEntity>();
            }
            if (old.ReplaceHeader != null)
                this.ReplaceHeader = new HeaderEntity(old.ReplaceHeader);
            if (!string.IsNullOrEmpty(old.GangLocation))
                this.GangLocation = old.GangLocation;
            this.Location = old.Location != absWorkHeaderEntity.WorkLocation.AFT ? (old.Location != absWorkHeaderEntity.WorkLocation.MID ? (old.Location != absWorkHeaderEntity.WorkLocation.MFWD ? (old.Location != absWorkHeaderEntity.WorkLocation.MAFT ? (old.Location != absWorkHeaderEntity.WorkLocation.FWD ? absWorkHeaderEntity.WorkLocation.None : absWorkHeaderEntity.WorkLocation.FWD) : absWorkHeaderEntity.WorkLocation.MAFT) : absWorkHeaderEntity.WorkLocation.MFWD) : absWorkHeaderEntity.WorkLocation.MID) : absWorkHeaderEntity.WorkLocation.AFT;
            if (old.DriverFile == null)
                return;
            this.DriverFile = old.DriverFile;
        }

        public WorkScheduleHeaderEntity WorkScheduleHeader { get; set; }

        public HeaderEntity Header { get; set; }

        public string CheckIn { get; set; }

        public DateTime? CheckInTime { get; set; }

        public string CheckOut { get; set; }

        public DateTime? CheckOutTime { get; set; }

        public string workDescription { get; set; }

        public string Comment { get; set; }

        public WorkGangDescriptionEntity GangDescription { get; set; }

        public List<absWorkDetailEntity> WorkDetails { get; set; }

        public HeaderEntity ReplaceHeader { get; set; }

        public string User { get; set; }

        public absWorkHeaderEntity.WorkLocation Location { get; set; }

        public string DriverFile { get; set; }

        public string GangLocation { get; set; }

        public enum WorkLocation
        {
            None,
            FWD,
            MFWD,
            MID,
            MAFT,
            AFT,
        }
    }
}