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
    public class AbsWorkScheduleHeaderRepository : RepositoryBase<WorkScheduleHeaderEntity>, IRepository<WorkScheduleHeaderEntity>
    {
        public List<WorkScheduleHeaderEntity> GetAll()
        {
            List<WorkScheduleHeaderEntity> scheduleHeaderEntityList = new List<WorkScheduleHeaderEntity>();
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                foreach (absWorkScheduleHeader workScheduleHeader in (IEnumerable<absWorkScheduleHeader>)ilaEntities.absWorkScheduleHeaders)
                    scheduleHeaderEntityList.Add(this.BuildEntity(workScheduleHeader));
            }
            AbsWorkHeaderRepository headerRepository = new AbsWorkHeaderRepository();
            foreach (WorkScheduleHeaderEntity scheduleHeaderEntity in scheduleHeaderEntityList)
                scheduleHeaderEntity.WorkHeaders = (List<absWorkHeaderEntity>)headerRepository.GetByScheduleHeader(Convert.ToInt32(scheduleHeaderEntity.Id));
            return scheduleHeaderEntityList;
        }

        public List<WorkScheduleHeaderEntity> GetMostCurrentTwoDays()
        {
            List<WorkScheduleHeaderEntity> scheduleHeaderEntityList1 = new List<WorkScheduleHeaderEntity>();
            List<WorkScheduleHeaderEntity> scheduleHeaderEntityList2 = new List<WorkScheduleHeaderEntity>();
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                DateTime latest = ilaEntities.absWorkScheduleHeaders.Select<absWorkScheduleHeader, DateTime>((Expression<Func<absWorkScheduleHeader, DateTime>>)(c => c.DateWorked)).Max<DateTime>().AddDays(-2.0);
                DbSet<absWorkScheduleHeader> workScheduleHeaders = ilaEntities.absWorkScheduleHeaders;
                Expression<Func<absWorkScheduleHeader, bool>> predicate = (Expression<Func<absWorkScheduleHeader, bool>>)(c => c.DateWorked > latest);
                foreach (absWorkScheduleHeader schedule in (IEnumerable<absWorkScheduleHeader>)workScheduleHeaders.Where<absWorkScheduleHeader>(predicate))
                    scheduleHeaderEntityList1.Add(this.BuildEntity(schedule));
                IQueryable<absWorkScheduleHeader> source = ilaEntities.absWorkScheduleHeaders.Where<absWorkScheduleHeader>((Expression<Func<absWorkScheduleHeader, bool>>)(c => c.DateWorked <= latest && c.Display));
                if (source.Count<absWorkScheduleHeader>() > 0)
                {
                    foreach (absWorkScheduleHeader workScheduleHeader in (IEnumerable<absWorkScheduleHeader>)source)
                        workScheduleHeader.Display = false;
                    try
                    {
                        ilaEntities.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            AbsWorkHeaderRepository headerRepository = new AbsWorkHeaderRepository();
            foreach (WorkScheduleHeaderEntity scheduleHeaderEntity in scheduleHeaderEntityList1)
                scheduleHeaderEntity.WorkHeaders = headerRepository.GetByScheduleHeaderWithoutDetails(Convert.ToInt32(scheduleHeaderEntity.Id));
            return scheduleHeaderEntityList1;
        }

        public List<WorkScheduleHeaderEntity> GetDisplayedToday()
        {
            List<WorkScheduleHeaderEntity> scheduleHeaderEntityList = new List<WorkScheduleHeaderEntity>();
            DateTime today = DateTime.Now.Date;
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                DbSet<absWorkScheduleHeader> workScheduleHeaders = ilaEntities.absWorkScheduleHeaders;
                Expression<Func<absWorkScheduleHeader, bool>> predicate = (Expression<Func<absWorkScheduleHeader, bool>>)(c => c.Display && c.DateWorked == today);
                foreach (absWorkScheduleHeader schedule in (IEnumerable<absWorkScheduleHeader>)workScheduleHeaders.Where<absWorkScheduleHeader>(predicate))
                    scheduleHeaderEntityList.Add(this.BuildEntity(schedule));
            }
            AbsWorkHeaderRepository headerRepository = new AbsWorkHeaderRepository();
            foreach (WorkScheduleHeaderEntity scheduleHeaderEntity in scheduleHeaderEntityList)
                scheduleHeaderEntity.WorkHeaders = headerRepository.GetByScheduleHeaderWithoutDetails(Convert.ToInt32(scheduleHeaderEntity.Id));
            return scheduleHeaderEntityList;
        }

        public WorkScheduleHeaderEntity Get(string id)
        {
            WorkScheduleHeaderEntity scheduleHeaderEntity = (WorkScheduleHeaderEntity)null;
            int ID;
            if (int.TryParse(id, out ID))
            {
                using (ILAEntities ilaEntities = new ILAEntities())
                {
                    absWorkScheduleHeader schedule = ilaEntities.absWorkScheduleHeaders.Where<absWorkScheduleHeader>((Expression<Func<absWorkScheduleHeader, bool>>)(b => b.Id == ID)).FirstOrDefault<absWorkScheduleHeader>();
                    if (schedule != null)
                        scheduleHeaderEntity = this.BuildEntity(schedule);
                }
            }
            if (scheduleHeaderEntity != null)
                scheduleHeaderEntity.WorkHeaders = (List<absWorkHeaderEntity>)new AbsWorkHeaderRepository().GetByScheduleHeader(Convert.ToInt32(scheduleHeaderEntity.Id));
            return scheduleHeaderEntity;
        }

        public WorkScheduleHeaderEntity GetByDateShiftCompanyShipBerth(
          DateTime workDate,
          DateTime shiftDateTime,
          int companyId,
          int shipId,
          int berthId)
        {
            WorkScheduleHeaderEntity scheduleHeaderEntity = (WorkScheduleHeaderEntity)null;
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                absWorkScheduleHeader schedule = ilaEntities.absWorkScheduleHeaders.Where<absWorkScheduleHeader>((Expression<Func<absWorkScheduleHeader, bool>>)(b => b.DateWorked == workDate && b.ShiftTime == shiftDateTime && b.CompanyId == (Decimal)companyId && b.VesselId == shipId && b.BerthId == berthId)).FirstOrDefault<absWorkScheduleHeader>();
                if (schedule != null)
                    scheduleHeaderEntity = this.BuildEntity(schedule);
            }
            if (scheduleHeaderEntity != null)
                scheduleHeaderEntity.WorkHeaders = (List<absWorkHeaderEntity>)new AbsWorkHeaderRepository().GetByScheduleHeader(Convert.ToInt32(scheduleHeaderEntity.Id));
            return scheduleHeaderEntity;
        }

        public void Update(WorkScheduleHeaderEntity entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int entityId = Convert.ToInt32(entity.Id);
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                absWorkScheduleHeader workScheduleHeader = ilaEntities.absWorkScheduleHeaders.Where<absWorkScheduleHeader>((Expression<Func<absWorkScheduleHeader, bool>>)(b => b.Id == entityId)).FirstOrDefault<absWorkScheduleHeader>();
                if (workScheduleHeader != null)
                {
                    workScheduleHeader.DateWorked = (DateTime)entity.DateWorked;
                    workScheduleHeader.CompanyId = Convert.ToDecimal(entity.Company.Id);
                    workScheduleHeader.BerthId = Convert.ToInt32(entity.Berth.Id);
                    workScheduleHeader.VesselId = Convert.ToInt32(entity.Vessel.Id);
                    workScheduleHeader.ShiftTime = (DateTime)entity.ShiftTime;
                    workScheduleHeader.Display = entity.Display;
                    workScheduleHeader.Cancelled = entity.Cancelled;
                    workScheduleHeader.BerthQuestion = entity.BerthQuestion;
                    workScheduleHeader.SetBack = entity.SetBack == null ? (string)null : entity.SetBack.Trim();
                    workScheduleHeader.EmergencyGang = !((bool?)entity.EmergencyGang).HasValue ? new bool?() : new bool?(((bool?)entity.EmergencyGang).Value);
                    if (!string.IsNullOrEmpty(entity.User))
                        workScheduleHeader.UpdateUser = entity.User.Trim();
                    workScheduleHeader.UpdateDateTime = new DateTime?(DateTime.Now);
                    try
                    {
                        ilaEntities.SaveChanges();
                    }
                    catch (DbEntityValidationException ex)
                    {
                        stringBuilder.AppendLine("Error Updating absWorkScheduleHeader Table");
                        stringBuilder.AppendLine("[ILA.DAL][Repositories][absWorkScheduleHeaderRepository.cs][Update]");
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
                        stringBuilder.AppendLine("Error Updating absWorkScheduleHeader Table");
                        stringBuilder.AppendLine("[ILA.DAL][Repositories][absWorkScheduleHeaderRepository.cs][Update]");
                        stringBuilder.AppendLine("Exception:");
                        stringBuilder.AppendLine(ex.ToString());
                        throw new Exception(stringBuilder.ToString());
                    }
                }
            }
            AbsWorkHeaderRepository headerRepository = new AbsWorkHeaderRepository();
            foreach (absWorkHeaderEntity entity1 in headerRepository.GetByScheduleHeader(entityId))
                headerRepository.Delete(entity1);
            foreach (absWorkHeaderEntity workHeader in (List<absWorkHeaderEntity>)entity.WorkHeaders)
                headerRepository.Add(workHeader);
        }

        public void Add(WorkScheduleHeaderEntity entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int num = 0;
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                absWorkScheduleHeader entity1 = new absWorkScheduleHeader();
                entity1.DateWorked = (DateTime)entity.DateWorked;
                entity1.CompanyId = Convert.ToDecimal(entity.Company.Id);
                entity1.BerthId = Convert.ToInt32(entity.Berth.Id);
                entity1.VesselId = Convert.ToInt32(entity.Vessel.Id);
                entity1.ShiftTime = (DateTime)entity.ShiftTime;
                entity1.Display = entity.Display;
                entity1.Cancelled = entity.Cancelled;
                entity1.BerthQuestion = entity.BerthQuestion;
                if (entity.SetBack != null)
                    entity1.SetBack = entity.SetBack.Trim();
                if (!string.IsNullOrEmpty(entity.User))
                    entity1.AddUser = entity.User.Trim();
                entity1.EmergencyGang = !((bool?)entity.EmergencyGang).HasValue ? new bool?(false) : new bool?(((bool?)entity.EmergencyGang).Value);
                entity1.AddDateTime = new DateTime?(DateTime.Now);
                try
                {
                    ilaEntities.absWorkScheduleHeaders.Add(entity1);
                    ilaEntities.SaveChanges();
                    num = entity1.Id;
                }
                catch (DbEntityValidationException ex)
                {
                    stringBuilder.AppendLine("Error Adding record to absWorkScheduleHeader Table");
                    stringBuilder.AppendLine("[ILA.DAL][Repositories][absWorkScheduleHeaderRepository.cs][Add]");
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
                    stringBuilder.AppendLine("Error Adding record to absWorkScheduleHeader Table");
                    stringBuilder.AppendLine("[ILA.DAL][Repositories][absWorkScheduleHeaderRepository.cs][Add]");
                    stringBuilder.AppendLine("Exception:");
                    stringBuilder.AppendLine(ex.ToString());
                    throw new Exception(stringBuilder.ToString());
                }
            }
            AbsWorkHeaderRepository headerRepository = new AbsWorkHeaderRepository();
            WorkScheduleHeaderEntity scheduleHeaderEntity = new AbsWorkScheduleHeaderRepository().Get(num.ToString());
            foreach (absWorkHeaderEntity workHeader in (List<absWorkHeaderEntity>)entity.WorkHeaders)
            {
                workHeader.WorkScheduleHeader = scheduleHeaderEntity;
                workHeader.User = entity.User;
                headerRepository.Add(workHeader);
            }
        }

        public void Delete(WorkScheduleHeaderEntity entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Error Deleting record from absWorkScheduleHeader Table");
            stringBuilder.AppendLine("[ILA.DAL][Repositories][absWorkScheduleHeaderRepository.cs][Delete]");
            stringBuilder.AppendLine("Exception:");
            AbsWorkHeaderRepository headerRepository = new AbsWorkHeaderRepository();
            foreach (absWorkHeaderEntity entity1 in headerRepository.GetByScheduleHeader(Convert.ToInt32(entity.Id)))
                headerRepository.Delete(entity1);
            int ID;
            if (!int.TryParse(entity.Id, out ID))
                return;
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                absWorkScheduleHeader entity1 = ilaEntities.absWorkScheduleHeaders.Where<absWorkScheduleHeader>((Expression<Func<absWorkScheduleHeader, bool>>)(b => b.Id == ID)).FirstOrDefault<absWorkScheduleHeader>();
                if (entity1 != null)
                {
                    try
                    {
                        ilaEntities.absWorkScheduleHeaders.Remove(entity1);
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
        }

        private WorkScheduleHeaderEntity BuildEntity(
          absWorkScheduleHeader schedule)
        {
            WorkScheduleHeaderEntity scheduleHeaderEntity1 = new WorkScheduleHeaderEntity();
            scheduleHeaderEntity1.Id = schedule.Id.ToString();
            scheduleHeaderEntity1.DateWorked = (DateTime)schedule.DateWorked;
            WorkScheduleHeaderEntity scheduleHeaderEntity2 = scheduleHeaderEntity1;
            CompanyEntity companyEntity1 = new CompanyEntity();
            companyEntity1.CompanyId = schedule.CompanyMaster.CompanyId;
            companyEntity1.Active = schedule.CompanyMaster.Active;
            companyEntity1.CompanyName = schedule.CompanyMaster.CompanyName.Trim();
            companyEntity1.Id = schedule.CompanyId.ToString();
            CompanyEntity companyEntity2 = companyEntity1;
            scheduleHeaderEntity2.Company = companyEntity2;
            WorkScheduleHeaderEntity scheduleHeaderEntity3 = scheduleHeaderEntity1;
            BerthEntity berthEntity1 = new BerthEntity();
            berthEntity1.Id = schedule.BerthId.ToString();
            berthEntity1.ShortBerthName = schedule.Berth.BerthShortName.Trim();
            BerthEntity berthEntity2 = berthEntity1;
            scheduleHeaderEntity3.Berth = berthEntity2;
            WorkScheduleHeaderEntity scheduleHeaderEntity4 = scheduleHeaderEntity1;
            VesselEntity vesselEntity1 = new VesselEntity();
            vesselEntity1.Id = schedule.VesselId.ToString();
            vesselEntity1.VesselName = schedule.Vessel.VesselName.Trim();
            VesselEntity vesselEntity2 = vesselEntity1;
            scheduleHeaderEntity4.Vessel = vesselEntity2;
            scheduleHeaderEntity1.ShiftTime = (DateTime)schedule.ShiftTime;
            scheduleHeaderEntity1.Display = schedule.Display;
            scheduleHeaderEntity1.Cancelled = schedule.Cancelled;
            scheduleHeaderEntity1.BerthQuestion = schedule.BerthQuestion;
            if (schedule.SetBack != null)
                scheduleHeaderEntity1.SetBack = schedule.SetBack.Trim();
            if (schedule.EmergencyGang.HasValue)
                scheduleHeaderEntity1.EmergencyGang = (bool?)new bool?(schedule.EmergencyGang.Value);
            return scheduleHeaderEntity1;
        }
    }
}