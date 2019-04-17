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
    public class absGangScheduleRepository : RepositoryBase<absGangScheduleEntity>, IRepository<absGangScheduleEntity>
    {
        public List<absGangScheduleEntity> GetAll()
        {
            List<absGangScheduleEntity> source = new List<absGangScheduleEntity>();
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                foreach (absGangSchedule absGangSchedule in (IEnumerable<absGangSchedule>)ilaEntities.absGangSchedules)
                    source.Add(this.BuildEntity(absGangSchedule));
            }
            return source.OrderBy<absGangScheduleEntity, DateTime?>((Func<absGangScheduleEntity, DateTime?>)(b => (DateTime?)b.StartTime)).ToList<absGangScheduleEntity>();
        }

        public List<absGangScheduleEntity> GetAll(DateTime startDate)
        {
            List<absGangScheduleEntity> source = new List<absGangScheduleEntity>();
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                DbSet<absGangSchedule> absGangSchedules = ilaEntities.absGangSchedules;
                Expression<Func<absGangSchedule, bool>> predicate = (Expression<Func<absGangSchedule, bool>>)(x => x.StartTime.Value >= startDate.Date);
                foreach (absGangSchedule schedule in (IEnumerable<absGangSchedule>)absGangSchedules.Where<absGangSchedule>(predicate))
                    source.Add(this.BuildEntity(schedule));
            }
            return source.OrderBy<absGangScheduleEntity, DateTime?>((Func<absGangScheduleEntity, DateTime?>)(b => (DateTime?)b.StartTime)).ToList<absGangScheduleEntity>();
        }

        public absGangScheduleEntity Get(string id)
        {
            absGangScheduleEntity gangScheduleEntity = (absGangScheduleEntity)null;
            int ID;
            if (int.TryParse(id, out ID))
            {
                using (ILAEntities ilaEntities = new ILAEntities())
                {
                    absGangSchedule schedule = ilaEntities.absGangSchedules.Where<absGangSchedule>((Expression<Func<absGangSchedule, bool>>)(b => b.id == ID)).FirstOrDefault<absGangSchedule>();
                    if (schedule != null)
                        gangScheduleEntity = this.BuildEntity(schedule);
                }
            }
            return gangScheduleEntity;
        }

        public void Update(absGangScheduleEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Add(absGangScheduleEntity entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool flag = false;
            int num = -1;
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                absGangSchedule absGangSchedule = ilaEntities.absGangSchedules.Where<absGangSchedule>((Expression<Func<absGangSchedule, bool>>)(b => b.StartTime.Value == entity.StartTime.Value && b.LloydsId == entity.LloydsId && b.Gang == entity.GangPos)).FirstOrDefault<absGangSchedule>();
                if (absGangSchedule == null)
                {
                    absGangSchedule entity1 = new absGangSchedule()
                    {
                        LloydsId = entity.LloydsId,
                        OutVoyage = entity.OutVoyage,
                        Berth = entity.Berth,
                        StartTime = new DateTime?(((DateTime?)entity.StartTime).Value),
                        Gang = entity.GangPos,
                        AddDateTime = new DateTime?(DateTime.Now)
                    };
                    entity1.AddDateTime = new DateTime?(DateTime.Now);
                    try
                    {
                        ilaEntities.absGangSchedules.Add(entity1);
                        ilaEntities.SaveChanges();
                    }
                    catch (DbEntityValidationException ex)
                    {
                        stringBuilder.AppendLine("Error Adding record " + entity.LloydsId + " to GangSchedule Table");
                        stringBuilder.AppendLine("[ILA.DAL][Repositories][absGangScheduleRepository.cs][Add]");
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
                        stringBuilder.AppendLine("Error Adding record " + entity.LloydsId + " to GangSchedule Table");
                        stringBuilder.AppendLine("[ILA.DAL][Repositories][absVesselRepository.cs][Add]");
                        stringBuilder.AppendLine("Exception:");
                        stringBuilder.AppendLine(ex.ToString());
                        throw new Exception(stringBuilder.ToString());
                    }
                }
                else
                {
                    flag = true;
                    num = absGangSchedule.id;
                }
            }
        }

        public void Delete(absGangScheduleEntity entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Error Deleting record " + entity.LloydsId + " to GangSchedule Table");
            stringBuilder.AppendLine("[ILA.DAL][Repositories][absVesselRepository.cs][Delete]");
            stringBuilder.AppendLine("Exception:");
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                absGangSchedule entity1 = ilaEntities.absGangSchedules.Where<absGangSchedule>((Expression<Func<absGangSchedule, bool>>)(b => b.LloydsId == entity.LloydsId && b.OutVoyage == entity.OutVoyage && b.StartTime == (DateTime?)entity.StartTime.Value && b.Gang == entity.GangPos)).FirstOrDefault<absGangSchedule>();
                if (entity1 == null)
                    return;
                try
                {
                    ilaEntities.absGangSchedules.Remove(entity1);
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

        private absGangScheduleEntity BuildEntity(absGangSchedule schedule)
        {
            return new absGangScheduleEntity()
            {
                LloydsId = schedule.LloydsId,
                OutVoyage = schedule.OutVoyage.Trim(),
                StartTime = (DateTime?)schedule.StartTime,
                Berth = schedule.Berth.Trim(),
                GangPos = schedule.Gang.Trim(),
                AddDateTime = (DateTime)schedule.AddDateTime.Value
            };
        }
    }
}