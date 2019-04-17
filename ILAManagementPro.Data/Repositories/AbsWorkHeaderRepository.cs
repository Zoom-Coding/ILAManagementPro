using ILAManagementPro.Data.Data;
using ILAManagementPro.Data.Interfaces;
using ILAManagementPro.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ILAManagementPro.Data.Repositories
{
    public class AbsWorkHeaderRepository : RepositoryBase<absWorkHeaderEntity>, IRepository<absWorkHeaderEntity>
    {
        public List<absWorkHeaderEntity> GetAll()
        {
            List<absWorkHeaderEntity> workHeaderEntityList = new List<absWorkHeaderEntity>();
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                foreach (absWorkHeader absWorkHeader in (IEnumerable<absWorkHeader>)ilaEntities.absWorkHeaders)
                    workHeaderEntityList.Add(this.BuildEntity(absWorkHeader));
            }
            AbsWorkDetailRepository detailRepository = new AbsWorkDetailRepository();
            foreach (absWorkHeaderEntity workHeaderEntity in workHeaderEntityList)
                workHeaderEntity.WorkDetails = (List<absWorkDetailEntity>)detailRepository.GetByWorkHeader(workHeaderEntity.Id);
            return workHeaderEntityList;
        }

        public List<absWorkHeaderEntity> GetAllByDateWorked(DateTime dateWorked)
        {
            List<absWorkHeaderEntity> workHeaderEntityList = new List<absWorkHeaderEntity>();
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                DbSet<absWorkHeader> absWorkHeaders = ilaEntities.absWorkHeaders;
                Expression<Func<absWorkHeader, bool>> predicate = (Expression<Func<absWorkHeader, bool>>)(c => c.absWorkScheduleHeader.DateWorked == dateWorked);
                foreach (absWorkHeader Header in (IEnumerable<absWorkHeader>)absWorkHeaders.Where<absWorkHeader>(predicate))
                    workHeaderEntityList.Add(this.BuildEntity(Header));
            }
            AbsWorkDetailRepository detailRepository = new AbsWorkDetailRepository();
            foreach (absWorkHeaderEntity workHeaderEntity in workHeaderEntityList)
                workHeaderEntity.WorkDetails = (List<absWorkDetailEntity>)detailRepository.GetByWorkHeader(workHeaderEntity.Id);
            return workHeaderEntityList;
        }

        public List<absWorkHeaderEntity> GetAllByDateWorkedWithoutDetails(
          DateTime dateWorked)
        {
            List<absWorkHeaderEntity> workHeaderEntityList = new List<absWorkHeaderEntity>();
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                DbSet<absWorkHeader> absWorkHeaders = ilaEntities.absWorkHeaders;
                Expression<Func<absWorkHeader, bool>> predicate = (Expression<Func<absWorkHeader, bool>>)(c => c.absWorkScheduleHeader.DateWorked == dateWorked);
                foreach (absWorkHeader Header in (IEnumerable<absWorkHeader>)absWorkHeaders.Where<absWorkHeader>(predicate))
                {
                    absWorkHeaderEntity workHeaderEntity = this.BuildEntity(Header);
                    workHeaderEntity.WorkDetails = (List<absWorkDetailEntity>)new List<absWorkDetailEntity>();
                    workHeaderEntityList.Add(workHeaderEntity);
                }
            }
            return workHeaderEntityList;
        }

        public List<absWorkHeaderEntity> GetByScheduleHeader(
          int WorkScheduleHeaderId)
        {
            List<absWorkHeaderEntity> workHeaderEntityList = new List<absWorkHeaderEntity>();
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                DbSet<absWorkHeader> absWorkHeaders = ilaEntities.absWorkHeaders;
                Expression<Func<absWorkHeader, bool>> predicate = (Expression<Func<absWorkHeader, bool>>)(h => h.WorkScheduleHeaderId == (int?)WorkScheduleHeaderId);
                foreach (absWorkHeader Header in (IEnumerable<absWorkHeader>)absWorkHeaders.Where<absWorkHeader>(predicate))
                    workHeaderEntityList.Add(this.BuildEntity(Header));
            }
            AbsWorkDetailRepository detailRepository = new AbsWorkDetailRepository();
            foreach (absWorkHeaderEntity workHeaderEntity in workHeaderEntityList)
                workHeaderEntity.WorkDetails = (List<absWorkDetailEntity>)detailRepository.GetByWorkHeader(workHeaderEntity.Id);
            return workHeaderEntityList;
        }

        public List<absWorkHeaderEntity> GetByScheduleHeaderWithoutDetails(
          int WorkScheduleHeaderId)
        {
            List<absWorkHeaderEntity> workHeaderEntityList = new List<absWorkHeaderEntity>();
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                DbSet<absWorkHeader> absWorkHeaders = ilaEntities.absWorkHeaders;
                Expression<Func<absWorkHeader, bool>> predicate = (Expression<Func<absWorkHeader, bool>>)(h => h.WorkScheduleHeaderId == (int?)WorkScheduleHeaderId);
                foreach (absWorkHeader Header in (IEnumerable<absWorkHeader>)absWorkHeaders.Where<absWorkHeader>(predicate))
                {
                    absWorkHeaderEntity workHeaderEntity = this.BuildEntity(Header);
                    workHeaderEntity.WorkDetails = (List<absWorkDetailEntity>)new List<absWorkDetailEntity>();
                    workHeaderEntityList.Add(workHeaderEntity);
                }
            }
            return workHeaderEntityList;
        }

        public absWorkHeaderEntity Get(string id)
        {
            absWorkHeaderEntity workHeaderEntity = (absWorkHeaderEntity)null;
            int ID;
            if (int.TryParse(id, out ID))
            {
                using (ILAEntities ilaEntities = new ILAEntities())
                {
                    absWorkHeader Header = ilaEntities.absWorkHeaders.Where<absWorkHeader>((Expression<Func<absWorkHeader, bool>>)(h => h.CounterId == ID)).FirstOrDefault<absWorkHeader>();
                    if (Header != null)
                        workHeaderEntity = this.BuildEntity(Header);
                }
            }
            if (workHeaderEntity != null)
                workHeaderEntity.WorkDetails = (List<absWorkDetailEntity>)new AbsWorkDetailRepository().GetByWorkHeader(workHeaderEntity.Id);
            return workHeaderEntity;
        }

        public absWorkHeaderEntity GetByHeaderNumberAndWorkDate(
          Decimal HeaderNumber,
          DateTime WorkDate)
        {
            absWorkHeaderEntity workHeaderEntity = (absWorkHeaderEntity)null;
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                absWorkHeader Header1 = ilaEntities.absWorkHeaders.Where<absWorkHeader>((Expression<Func<absWorkHeader, bool>>)(h => h.absWorkScheduleHeader.DateWorked == WorkDate && h.ReplaceHeaderId.HasValue && h.ReplaceHeaderId == (Decimal?)HeaderNumber && h.CheckOut == (object)null)).FirstOrDefault<absWorkHeader>();
                if (Header1 != null)
                {
                    workHeaderEntity = this.BuildEntity(Header1);
                }
                else
                {
                    absWorkHeader Header2 = ilaEntities.absWorkHeaders.Where<absWorkHeader>((Expression<Func<absWorkHeader, bool>>)(h => h.absWorkScheduleHeader.DateWorked == WorkDate && !h.ReplaceHeaderId.HasValue && h.Header == (Decimal?)HeaderNumber && h.CheckOut == (object)null)).FirstOrDefault<absWorkHeader>();
                    if (Header2 != null)
                        workHeaderEntity = this.BuildEntity(Header2);
                }
            }
            if (workHeaderEntity != null)
                workHeaderEntity.WorkDetails = (List<absWorkDetailEntity>)new AbsWorkDetailRepository().GetByWorkHeader(workHeaderEntity.Id);
            return workHeaderEntity;
        }

        public int CheckOutHeadersBetweenDates(
          DateTime fromTime,
          DateTime toTime,
          DateTime checkOutTime,
          string checkOut,
          string user)
        {
            int num = 0;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Error Updating absWorkHeader Table");
            stringBuilder.AppendLine("[ILA.DAL][Repositories][AbsWorkHeaderRepository.cs][CheckOutHeadersBetweenDates]");
            stringBuilder.AppendLine("Exception:");
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                IQueryable<absWorkHeader> source = ilaEntities.absWorkHeaders.Where<absWorkHeader>((Expression<Func<absWorkHeader, bool>>)(c => c.CheckOut == (object)null && c.CheckInTime.HasValue && c.CheckInTime.Value >= fromTime && c.CheckInTime.Value <= toTime));
                foreach (absWorkHeader absWorkHeader in (IEnumerable<absWorkHeader>)source)
                {
                    absWorkHeader.CheckOut = checkOut;
                    absWorkHeader.CheckOutTime = new DateTime?(checkOutTime);
                    absWorkHeader.UpdateUser = user;
                    absWorkHeader.UpdateDate = new DateTime?(DateTime.Now);
                }
                num = source.Count<absWorkHeader>();
                try
                {
                    ilaEntities.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (DbEntityValidationResult entityValidationError in ex.EntityValidationErrors)
                    {
                        stringBuilder.AppendLine("Entity Type: " + entityValidationError.Entry.Entity.GetType().Name);
                        foreach (DbValidationError validationError in (IEnumerable<DbValidationError>)entityValidationError.ValidationErrors)
                        {
                            stringBuilder.AppendLine("Property: " + validationError.PropertyName);
                            stringBuilder.AppendLine("Message: ");
                            stringBuilder.AppendLine(validationError.ErrorMessage);
                        }
                        stringBuilder.AppendLine();
                    }
                    throw new DbUnexpectedValidationException(stringBuilder.ToString());
                }
                catch (Exception ex)
                {
                    stringBuilder.AppendLine(ex.ToString());
                    throw new Exception(stringBuilder.ToString());
                }
            }
            return num;
        }

        public void Update(absWorkHeaderEntity entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int entityId = Convert.ToInt32(entity.Id);
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                absWorkHeader absWorkHeader1 = ilaEntities.absWorkHeaders.Where<absWorkHeader>((Expression<Func<absWorkHeader, bool>>)(h => h.CounterId == entityId)).FirstOrDefault<absWorkHeader>();
                if (absWorkHeader1 == null)
                    return;
                absWorkHeader1.WorkScheduleHeaderId = new int?(Convert.ToInt32(entity.WorkScheduleHeader.Id));
                absWorkHeader1.Header = entity.Header == null ? new Decimal?() : new Decimal?(Convert.ToDecimal(entity.Header.Id));
                absWorkHeader1.CheckIn = string.IsNullOrEmpty(entity.CheckIn) ? (string)null : entity.CheckIn.Trim();
                DateTime? nullable1;
                if (((DateTime?)entity.CheckInTime).HasValue)
                {
                    absWorkHeader absWorkHeader2 = absWorkHeader1;
                    nullable1 = (DateTime?)entity.CheckInTime;
                    DateTime? nullable2 = new DateTime?(nullable1.Value);
                    absWorkHeader2.CheckInTime = nullable2;
                }
                else
                    absWorkHeader1.CheckInTime = new DateTime?();
                absWorkHeader1.CheckOut = string.IsNullOrEmpty(entity.CheckOut) ? (string)null : entity.CheckOut.Trim();
                nullable1 = (DateTime?)entity.CheckOutTime;
                if (nullable1.HasValue)
                {
                    absWorkHeader absWorkHeader2 = absWorkHeader1;
                    nullable1 = (DateTime?)entity.CheckOutTime;
                    DateTime? nullable2 = new DateTime?(nullable1.Value);
                    absWorkHeader2.CheckOutTime = nullable2;
                }
                else
                {
                    absWorkHeader absWorkHeader2 = absWorkHeader1;
                    nullable1 = new DateTime?();
                    DateTime? nullable2 = nullable1;
                    absWorkHeader2.CheckOutTime = nullable2;
                }
                absWorkHeader1.Description = string.IsNullOrEmpty(entity.workDescription) ? (string)null : entity.workDescription.Trim();
                absWorkHeader1.Comment = string.IsNullOrEmpty(entity.Comment) ? (string)null : entity.Comment.Trim();
                absWorkHeader1.WorkGangDescriptionId = entity.GangDescription == null ? new int?() : new int?(Convert.ToInt32(entity.GangDescription.Id));
                absWorkHeader1.ReplaceHeaderId = entity.ReplaceHeader == null ? new Decimal?() : new Decimal?(Convert.ToDecimal(entity.ReplaceHeader.Id));
                if (!string.IsNullOrEmpty(entity.User))
                    absWorkHeader1.UpdateUser = entity.User.Trim();
                if (!string.IsNullOrEmpty(entity.GangLocation))
                    absWorkHeader1.Location = entity.GangLocation;
                else if (entity.Location != absWorkHeaderEntity.WorkLocation.None)
                    absWorkHeader1.Location = ((object)entity.Location).ToString();
                absWorkHeader1.UpdateDate = new DateTime?(DateTime.Now);
                if (entity.DriverFile != null)
                    absWorkHeader1.DriverFile = entity.DriverFile;
                try
                {
                    ilaEntities.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    stringBuilder.AppendLine("Error Updating absWorkHeader Table");
                    stringBuilder.AppendLine("[ILA.DAL][Repositories][AbsWorkHeaderRepository.cs][Update]");
                    stringBuilder.AppendLine("Exception:");
                    foreach (DbEntityValidationResult entityValidationError in ex.EntityValidationErrors)
                    {
                        stringBuilder.AppendLine("Entity Type: " + entityValidationError.Entry.Entity.GetType().Name);
                        foreach (DbValidationError validationError in (IEnumerable<DbValidationError>)entityValidationError.ValidationErrors)
                        {
                            stringBuilder.AppendLine("Property: " + validationError.PropertyName);
                            stringBuilder.AppendLine("Message: ");
                            stringBuilder.AppendLine(validationError.ErrorMessage);
                        }
                        stringBuilder.AppendLine();
                    }
                    throw new DbUnexpectedValidationException(stringBuilder.ToString());
                }
                catch (Exception ex)
                {
                    stringBuilder.AppendLine("Error Updating absWorkHeader Table");
                    stringBuilder.AppendLine("[ILA.DAL][Repositories][AbsWorkHeaderRepository.cs][Update]");
                    stringBuilder.AppendLine("Exception:");
                    stringBuilder.AppendLine(ex.ToString());
                    throw new Exception(stringBuilder.ToString());
                }
            }
        }

        public void Add(absWorkHeaderEntity entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int num = -1;
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                absWorkHeader entity1 = new absWorkHeader();
                entity1.WorkScheduleHeaderId = new int?(Convert.ToInt32(entity.WorkScheduleHeader.Id));
                if (entity.Header != null)
                    entity1.Header = new Decimal?(Convert.ToDecimal(entity.Header.Id));
                if (!string.IsNullOrEmpty(entity.CheckIn))
                    entity1.CheckIn = entity.CheckIn.Trim();
                DateTime? nullable1;
                if (((DateTime?)entity.CheckInTime).HasValue)
                {
                    absWorkHeader absWorkHeader = entity1;
                    nullable1 = (DateTime?)entity.CheckInTime;
                    DateTime? nullable2 = new DateTime?(nullable1.Value);
                    absWorkHeader.CheckInTime = nullable2;
                }
                if (!string.IsNullOrEmpty(entity.CheckOut))
                    entity1.CheckOut = entity.CheckOut.Trim();
                nullable1 = (DateTime?)entity.CheckOutTime;
                if (nullable1.HasValue)
                {
                    absWorkHeader absWorkHeader = entity1;
                    nullable1 = (DateTime?)entity.CheckOutTime;
                    DateTime? nullable2 = new DateTime?(nullable1.Value);
                    absWorkHeader.CheckOutTime = nullable2;
                }
                if (!string.IsNullOrEmpty(entity.workDescription))
                    entity1.Description = entity.workDescription.Trim();
                if (!string.IsNullOrEmpty(entity.Comment))
                    entity1.Comment = entity.Comment.Trim();
                if (entity.GangDescription != null)
                    entity1.WorkGangDescriptionId = new int?(Convert.ToInt32(entity.GangDescription.Id));
                if (entity.ReplaceHeader != null)
                    entity1.ReplaceHeaderId = new Decimal?(Convert.ToDecimal(entity.ReplaceHeader.Id));
                if (!string.IsNullOrEmpty(entity.User))
                    entity1.AddedUser = entity.User.Trim();
                if (!string.IsNullOrEmpty(entity.GangLocation))
                    entity1.Location = entity.GangLocation;
                else if (entity.Location != absWorkHeaderEntity.WorkLocation.None)
                    entity1.Location = ((object)entity.Location).ToString();
                entity1.AddedDate = new DateTime?(DateTime.Now);
                if (entity.DriverFile != null)
                    entity1.DriverFile = entity.DriverFile;
                try
                {
                    ilaEntities.absWorkHeaders.Add(entity1);
                    ilaEntities.SaveChanges();
                    num = entity1.CounterId;
                }
                catch (DbEntityValidationException ex)
                {
                    stringBuilder.AppendLine("Error Adding to absWorkHeader Table");
                    stringBuilder.AppendLine("[ILA.DAL][Repositories][AbsWorkHeaderRepository.cs][Add]");
                    stringBuilder.AppendLine("Exception:");
                    foreach (DbEntityValidationResult entityValidationError in ex.EntityValidationErrors)
                    {
                        stringBuilder.AppendLine("Entity Type: " + entityValidationError.Entry.Entity.GetType().Name);
                        foreach (DbValidationError validationError in (IEnumerable<DbValidationError>)entityValidationError.ValidationErrors)
                        {
                            stringBuilder.AppendLine("Property: " + validationError.PropertyName);
                            stringBuilder.AppendLine("Message: ");
                            stringBuilder.AppendLine(validationError.ErrorMessage);
                        }
                        stringBuilder.AppendLine();
                    }
                    throw new DbUnexpectedValidationException(stringBuilder.ToString());
                }
                catch (Exception ex)
                {
                    stringBuilder.AppendLine("Error Adding to absWorkHeader Table");
                    stringBuilder.AppendLine("[ILA.DAL][Repositories][AbsWorkHeaderRepository.cs][Add]");
                    stringBuilder.AppendLine("Exception:");
                    stringBuilder.AppendLine(ex.ToString());
                    throw new Exception(stringBuilder.ToString());
                }
            }
            if (num <= -1)
                return;
            AbsWorkDetailRepository detailRepository = new AbsWorkDetailRepository();
            foreach (absWorkDetailEntity workDetail in (List<absWorkDetailEntity>)entity.WorkDetails)
            {
                workDetail.Header = new absWorkHeaderEntity();
                workDetail.Header.Id = num.ToString();
                detailRepository.Add(workDetail);
            }
        }

        public void Delete(absWorkHeaderEntity entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Error Deleting absWorkHeader Table");
            stringBuilder.AppendLine("[ILA.DAL][Repositories][AbsWorkHeaderRepository.cs][Delete]");
            stringBuilder.AppendLine("Exception:");
            AbsWorkDetailRepository detailRepository = new AbsWorkDetailRepository();
            foreach (absWorkDetailEntity entity1 in detailRepository.GetByWorkHeader(entity.Id))
                detailRepository.Delete(entity1);
            int entityId = Convert.ToInt32(entity.Id);
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                absWorkHeader entity1 = ilaEntities.absWorkHeaders.Where<absWorkHeader>((Expression<Func<absWorkHeader, bool>>)(h => h.CounterId == entityId)).FirstOrDefault<absWorkHeader>();
                if (entity1 == null)
                    return;
                try
                {
                    ilaEntities.absWorkHeaders.Remove(entity1);
                    ilaEntities.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (DbEntityValidationResult entityValidationError in ex.EntityValidationErrors)
                    {
                        stringBuilder.AppendLine("Entity Type: " + entityValidationError.Entry.Entity.GetType().Name);
                        foreach (DbValidationError validationError in (IEnumerable<DbValidationError>)entityValidationError.ValidationErrors)
                        {
                            stringBuilder.AppendLine("Property: " + validationError.PropertyName);
                            stringBuilder.AppendLine("Message: ");
                            stringBuilder.AppendLine(validationError.ErrorMessage);
                        }
                        stringBuilder.AppendLine();
                    }
                    throw new DbUnexpectedValidationException(stringBuilder.ToString());
                }
                catch (Exception ex)
                {
                    stringBuilder.AppendLine(ex.ToString());
                    throw new Exception(stringBuilder.ToString());
                }
            }
        }

        private absWorkHeaderEntity BuildEntity(absWorkHeader Header)
        {
            absWorkHeaderEntity workHeaderEntity1 = new absWorkHeaderEntity();
            workHeaderEntity1.Id = Header.CounterId.ToString();
            absWorkHeaderEntity workHeaderEntity2 = workHeaderEntity1;
            WorkScheduleHeaderEntity scheduleHeaderEntity1 = new WorkScheduleHeaderEntity();
            scheduleHeaderEntity1.Id = Header.WorkScheduleHeaderId.ToString();
            scheduleHeaderEntity1.DateWorked = (DateTime)Header.absWorkScheduleHeader.DateWorked;
            WorkScheduleHeaderEntity scheduleHeaderEntity2 = scheduleHeaderEntity1;
            CompanyEntity companyEntity1 = new CompanyEntity();
            companyEntity1.Id = Header.absWorkScheduleHeader.CompanyId.ToString();
            companyEntity1.CompanyId = Header.absWorkScheduleHeader.CompanyMaster.CompanyId;
            companyEntity1.CompanyName = Header.absWorkScheduleHeader.CompanyMaster.CompanyName;
            CompanyEntity companyEntity2 = companyEntity1;
            scheduleHeaderEntity2.Company = companyEntity2;
            WorkScheduleHeaderEntity scheduleHeaderEntity3 = scheduleHeaderEntity1;
            BerthEntity berthEntity1 = new BerthEntity();
            berthEntity1.Id = Header.absWorkScheduleHeader.BerthId.ToString();
            berthEntity1.ShortBerthName = Header.absWorkScheduleHeader.absBerth.BerthShortName;
            BerthEntity berthEntity2 = berthEntity1;
            scheduleHeaderEntity3.Berth = berthEntity2;
            WorkScheduleHeaderEntity scheduleHeaderEntity4 = scheduleHeaderEntity1;
            VesselEntity vesselEntity1 = new VesselEntity();
            vesselEntity1.Id = Header.absWorkScheduleHeader.VesselId.ToString();
            vesselEntity1.VesselName = Header.absWorkScheduleHeader.absVessel.VesselName;
            vesselEntity1.LLoydsNumber = Header.absWorkScheduleHeader.absVessel.LLoydsId;
            VesselEntity vesselEntity2 = vesselEntity1;
            scheduleHeaderEntity4.Vessel = vesselEntity2;
            scheduleHeaderEntity1.ShiftTime = (DateTime)Header.absWorkScheduleHeader.ShiftTime;
            scheduleHeaderEntity1.Display = Header.absWorkScheduleHeader.Display;
            scheduleHeaderEntity1.Cancelled = Header.absWorkScheduleHeader.Cancelled;
            WorkScheduleHeaderEntity scheduleHeaderEntity5 = scheduleHeaderEntity1;
            workHeaderEntity2.WorkScheduleHeader = scheduleHeaderEntity5;
            Decimal num;
            if (Header.Header.HasValue)
            {
                absWorkHeaderEntity workHeaderEntity3 = workHeaderEntity1;
                HeaderEntity headerEntity1 = new HeaderEntity();
                HeaderEntity headerEntity2 = headerEntity1;
                num = Header.Header.Value;
                string str = num.ToString();
                headerEntity2.Id = str;
                headerEntity1.FirstName = Header.InsuredMaster.FirstName.Trim();
                headerEntity1.MiddleInitial = Header.InsuredMaster.MI.Trim();
                headerEntity1.LastName = Header.InsuredMaster.LastName.Trim();
                headerEntity1.DisplayName = this.BuildHeaderDisplayName(Header.InsuredMaster.FirstName.Trim(), Header.InsuredMaster.LastName.Trim());
                headerEntity1.HeaderMember = this.isHeader(Header.InsuredMaster.HeaderYN);
                HeaderEntity headerEntity3 = headerEntity1;
                workHeaderEntity3.Header = headerEntity3;
            }
            if (!string.IsNullOrEmpty(Header.CheckIn))
                workHeaderEntity1.CheckIn = Header.CheckIn.Trim();
            if (Header.CheckInTime.HasValue)
                workHeaderEntity1.CheckInTime = (DateTime?)new DateTime?(Header.CheckInTime.Value);
            if (!string.IsNullOrEmpty(Header.CheckOut))
                workHeaderEntity1.CheckOut = Header.CheckOut.Trim();
            if (Header.CheckOutTime.HasValue)
                workHeaderEntity1.CheckOutTime = (DateTime?)new DateTime?(Header.CheckOutTime.Value);
            if (!string.IsNullOrEmpty(Header.Description))
                workHeaderEntity1.workDescription = Header.Description.Trim();
            if (!string.IsNullOrEmpty(Header.Comment))
                workHeaderEntity1.Comment = Header.Comment.Trim();
            if (Header.WorkGangDescriptionId.HasValue)
                workHeaderEntity1.GangDescription = new AbsWorkGangDescriptionRepository().Get(Header.WorkGangDescriptionId.Value.ToString());
            if (Header.ReplaceHeaderId.HasValue)
            {
                absWorkHeaderEntity workHeaderEntity3 = workHeaderEntity1;
                HeaderEntity headerEntity1 = new HeaderEntity();
                HeaderEntity headerEntity2 = headerEntity1;
                num = Header.ReplaceHeaderId.Value;
                string str = num.ToString();
                headerEntity2.Id = str;
                headerEntity1.FirstName = Header.InsuredMaster1.FirstName.Trim();
                headerEntity1.MiddleInitial = Header.InsuredMaster1.MI.Trim();
                headerEntity1.LastName = Header.InsuredMaster1.LastName.Trim();
                headerEntity1.DisplayName = this.BuildHeaderDisplayName(Header.InsuredMaster1.FirstName.Trim(), Header.InsuredMaster1.LastName.Trim());
                headerEntity1.HeaderMember = this.isHeader(Header.InsuredMaster1.HeaderYN);
                HeaderEntity headerEntity3 = headerEntity1;
                workHeaderEntity3.ReplaceHeader = headerEntity3;
            }
            if (Header.Location != null)
            {
                if (Header.Location.Contains("GANG"))
                {
                    workHeaderEntity1.GangLocation = Header.Location;
                }
                else
                {
                    if (Header.Location == ((object)absWorkHeaderEntity.WorkLocation.AFT).ToString())
                    {
                        workHeaderEntity1.Location = absWorkHeaderEntity.WorkLocation.AFT;
                        workHeaderEntity1.GangLocation = Header.Location;
                    }
                    if (Header.Location == ((object)absWorkHeaderEntity.WorkLocation.MID).ToString())
                    {
                        workHeaderEntity1.Location = absWorkHeaderEntity.WorkLocation.MID;
                        workHeaderEntity1.GangLocation = Header.Location;
                    }
                    if (Header.Location == ((object)absWorkHeaderEntity.WorkLocation.MFWD).ToString())
                    {
                        workHeaderEntity1.Location = absWorkHeaderEntity.WorkLocation.MFWD;
                        workHeaderEntity1.GangLocation = Header.Location;
                    }
                    if (Header.Location == ((object)absWorkHeaderEntity.WorkLocation.MAFT).ToString())
                    {
                        workHeaderEntity1.Location = absWorkHeaderEntity.WorkLocation.MAFT;
                        workHeaderEntity1.GangLocation = Header.Location;
                    }
                    if (Header.Location == ((object)absWorkHeaderEntity.WorkLocation.FWD).ToString())
                    {
                        workHeaderEntity1.Location = absWorkHeaderEntity.WorkLocation.FWD;
                        workHeaderEntity1.GangLocation = Header.Location;
                    }
                }
            }
            if (Header.DriverFile != null)
                workHeaderEntity1.DriverFile = Header.DriverFile;
            return workHeaderEntity1;
        }

        private bool isHeader(bool? value)
        {
            bool flag = false;
            if (value.HasValue)
                flag = value.Value;
            return flag;
        }

        private string BuildHeaderDisplayName(string firstName, string lastName)
        {
            if (firstName.Length < 1)
                firstName += " ";
            return (firstName.Substring(0, 1) + " " + lastName).Replace(", JR.", " JR");
        }
    }
}