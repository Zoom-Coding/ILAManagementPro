using System;
using System.Collections.Generic;
using System.Linq;

namespace ILAManagementPro.Models
{
    public class WorkHeader : EntityBase
    {
        public WorkHeader() {}

        public WorkHeader(WorkHeader old)
        {
            this.Id = old.Id;
            this.Description = old.Description;
            this.WorkScheduleHeader = new WorkScheduleHeader(old.WorkScheduleHeader);
            if (old.Header != null)
                this.Header = new Header(old.Header);
            this.CheckIn = old.CheckIn;
            this.CheckInTime = old.CheckInTime;
            this.CheckOut = old.CheckOut;
            this.workDescription = old.workDescription;
            this.Comment = old.Comment;
            if (old.GangDescription != null)
                this.GangDescription = new WorkGangDescription(old.GangDescription);
            if (old.WorkDetails != null)
            {
                WorkDetail[] array = new WorkDetail[old.WorkDetails.Count];
                old.WorkDetails.CopyTo(array);
                this.WorkDetails = ((IEnumerable<WorkDetail>)array).ToList();
            }
            if (old.ReplaceHeader != null)
                this.ReplaceHeader = new Header(old.ReplaceHeader);
            if (!string.IsNullOrEmpty(old.GangLocation))
                this.GangLocation = old.GangLocation;
            this.Location = old.Location != WorkLocation.AFT ? (old.Location != WorkLocation.MID ? (old.Location != WorkLocation.MFWD ? (old.Location != WorkLocation.MAFT ? (old.Location != WorkLocation.FWD ? WorkLocation.None : WorkLocation.FWD) : WorkLocation.MAFT) : WorkLocation.MFWD) : WorkLocation.MID) : WorkLocation.AFT;
            if (old.DriverFile == null)
                return;
            this.DriverFile = old.DriverFile;
        }

        public WorkScheduleHeader WorkScheduleHeader { get; set; }

        public Header Header { get; set; }

        public string CheckIn { get; set; }

        public DateTime? CheckInTime { get; set; }

        public string CheckOut { get; set; }

        public DateTime? CheckOutTime { get; set; }

        public string workDescription { get; set; }

        public string Comment { get; set; }

        public WorkGangDescription GangDescription { get; set; }

        public List<WorkDetail> WorkDetails { get; set; }

        public Header ReplaceHeader { get; set; }

        public string User { get; set; }

        public WorkLocation Location { get; set; }

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