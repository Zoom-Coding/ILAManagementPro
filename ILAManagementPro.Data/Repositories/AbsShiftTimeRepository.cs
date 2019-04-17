using ILAManagementPro.Data.Data;
using ILAManagementPro.Data.Interfaces;
using ILAManagementPro.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ILAManagementPro.Data.Repositories
{
    public class AbsShiftTimeRepository : RepositoryBase<ShiftEntity>, IRepository<ShiftEntity>
    {
        public List<ShiftEntity> GetAll()
        {
            List<ShiftEntity> source = new List<ShiftEntity>();
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                foreach (absShiftTime absShiftTime in (IEnumerable<absShiftTime>)ilaEntities.absShiftTimes)
                    source.Add(this.BuildEntity(absShiftTime));
            }
            return source.OrderBy<ShiftEntity, string>((Func<ShiftEntity, string>)(b => b.MilitaryTime)).ToList<ShiftEntity>();
        }

        public ShiftEntity Get(string id)
        {
            ShiftEntity shiftEntity = (ShiftEntity)null;
            int ID;
            if (int.TryParse(id, out ID))
            {
                using (ILAEntities ilaEntities = new ILAEntities())
                {
                    absShiftTime shift = ilaEntities.absShiftTimes.Where<absShiftTime>((Expression<Func<absShiftTime, bool>>)(b => b.id == ID)).FirstOrDefault<absShiftTime>();
                    if (shift != null)
                        shiftEntity = this.BuildEntity(shift);
                }
            }
            return shiftEntity;
        }

        public void Update(ShiftEntity entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Error Updating absShiftTime Table");
            stringBuilder.AppendLine("[ILA.DAL][Repositories][absShiftTimeRepository.cs][Update]");
            stringBuilder.AppendLine("Exception:");
            int ID;
            if (!int.TryParse(entity.Id, out ID))
                return;
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                absShiftTime absShiftTime = ilaEntities.absShiftTimes.Where<absShiftTime>((Expression<Func<absShiftTime, bool>>)(b => b.id == ID)).FirstOrDefault<absShiftTime>();
                if (absShiftTime != null)
                {
                    absShiftTime.DisplayTime = entity.DisplayTime.ToUpper().Trim();
                    absShiftTime.MilitaryTime = entity.MilitaryTime.Trim();
                    absShiftTime.PickTime = entity.PickTime.Trim();
                    if (!string.IsNullOrEmpty(entity.User))
                        absShiftTime.UpdateUser = entity.User.Trim();
                    absShiftTime.UpdateDateTime = new DateTime?(DateTime.Now);
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
            }
        }

        public void Add(ShiftEntity entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Error Adding record " + entity.DisplayTime.Trim() + " to absShiftTime Table");
            stringBuilder.AppendLine("[ILA.DAL][Repositories][absShiftTimeRepository.cs][Add]");
            stringBuilder.AppendLine("Exception:");
            bool flag = false;
            int num = -1;
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                absShiftTime absShiftTime = ilaEntities.absShiftTimes.Where<absShiftTime>((Expression<Func<absShiftTime, bool>>)(b => b.DisplayTime.ToUpper().Trim() == entity.DisplayTime.ToUpper().Trim())).FirstOrDefault<absShiftTime>();
                if (absShiftTime == null)
                {
                    absShiftTime entity1 = new absShiftTime();
                    entity1.DisplayTime = entity.DisplayTime.ToUpper().Trim();
                    entity1.MilitaryTime = entity.MilitaryTime.Trim();
                    entity1.PickTime = entity.PickTime.Trim();
                    if (!string.IsNullOrEmpty(entity.User))
                        entity1.AddUser = entity.User.Trim();
                    entity1.AddDateTime = new DateTime?(DateTime.Now);
                    try
                    {
                        ilaEntities.absShiftTimes.Add(entity1);
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
                else
                {
                    flag = true;
                    num = absShiftTime.id;
                }
            }
            if (!flag)
                return;
            entity.Id = num.ToString();
            this.Update(entity);
        }

        public void Delete(ShiftEntity entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Error Deleting " + entity.DisplayTime.Trim() + " from absShiftTime Table");
            stringBuilder.AppendLine("[ILA.DAL][Repositories][absShiftTimeRepository.cs][Delete]");
            stringBuilder.AppendLine("Exception:");
            int ID;
            if (!int.TryParse(entity.Id, out ID))
                return;
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                absShiftTime entity1 = ilaEntities.absShiftTimes.Where<absShiftTime>((Expression<Func<absShiftTime, bool>>)(b => b.id == ID)).FirstOrDefault<absShiftTime>();
                if (entity1 != null)
                {
                    try
                    {
                        ilaEntities.absShiftTimes.Remove(entity1);
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

        private ShiftEntity BuildEntity(absShiftTime shift)
        {
            ShiftEntity shiftEntity = new ShiftEntity();
            shiftEntity.Id = shift.id.ToString();
            shiftEntity.DisplayTime = shift.DisplayTime.Trim();
            shiftEntity.MilitaryTime = shift.MilitaryTime.Trim();
            shiftEntity.PickTime = shift.PickTime.Trim();
            return shiftEntity;
        }
    }
}