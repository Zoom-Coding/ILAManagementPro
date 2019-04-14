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
    public class AbsScheduleLoginRepository : RepositoryBase<absScheduleLoginEntity>, IRepository<absScheduleLoginEntity>
    {
        public List<absScheduleLoginEntity> GetAll()
        {
            List<absScheduleLoginEntity> source = new List<absScheduleLoginEntity>();
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                foreach (absWorkScheduleLogin workScheduleLogin in (IEnumerable<absWorkScheduleLogin>)ilaEntities.absWorkScheduleLogins)
                    source.Add(this.BuildEntity(workScheduleLogin));
            }
            return source.OrderBy<absScheduleLoginEntity, string>((Func<absScheduleLoginEntity, string>)(b => b.UserId)).ToList<absScheduleLoginEntity>();
        }

        public absScheduleLoginEntity Get(string id)
        {
            absScheduleLoginEntity scheduleLoginEntity = (absScheduleLoginEntity)null;
            int ID;
            if (int.TryParse(id, out ID))
            {
                using (ILAEntities ilaEntities = new ILAEntities())
                {
                    absWorkScheduleLogin login = ilaEntities.absWorkScheduleLogins.Where<absWorkScheduleLogin>((Expression<Func<absWorkScheduleLogin, bool>>)(b => b.id == ID)).FirstOrDefault<absWorkScheduleLogin>();
                    if (login != null)
                        scheduleLoginEntity = this.BuildEntity(login);
                }
            }
            return scheduleLoginEntity;
        }

        public absScheduleLoginEntity GetByUserId(
          string ProgramName,
          string userId)
        {
            absScheduleLoginEntity scheduleLoginEntity = (absScheduleLoginEntity)null;
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                absWorkScheduleLogin login = ilaEntities.absWorkScheduleLogins.Where<absWorkScheduleLogin>((Expression<Func<absWorkScheduleLogin, bool>>)(b => b.UserId.Trim() == userId.Trim() && b.ProgramName.Trim() == ProgramName.Trim())).FirstOrDefault<absWorkScheduleLogin>();
                if (login != null)
                    scheduleLoginEntity = this.BuildEntity(login);
            }
            return scheduleLoginEntity;
        }

        public void Update(absScheduleLoginEntity entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Error Updating absWorkScheduleLogins Table");
            stringBuilder.AppendLine("[ILA.DAL][Repositories][AbsScheduleLoginRepository.cs][Update]");
            stringBuilder.AppendLine("Exception:");
            int ID;
            if (!int.TryParse(entity.Id, out ID))
                return;
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                absWorkScheduleLogin workScheduleLogin = ilaEntities.absWorkScheduleLogins.Where<absWorkScheduleLogin>((Expression<Func<absWorkScheduleLogin, bool>>)(b => b.id == ID)).FirstOrDefault<absWorkScheduleLogin>();
                if (workScheduleLogin != null)
                {
                    workScheduleLogin.UserId = entity.UserId.Trim();
                    workScheduleLogin.ProgramName = entity.ProgramName.Trim();
                    if (!string.IsNullOrEmpty(entity.User))
                        workScheduleLogin.UpdateUser = entity.User.ToString();
                    workScheduleLogin.UpdateDateTime = new DateTime?(DateTime.Now);
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

        public void Add(absScheduleLoginEntity entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool flag = false;
            int num = -1;
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                absWorkScheduleLogin workScheduleLogin = ilaEntities.absWorkScheduleLogins.Where<absWorkScheduleLogin>((Expression<Func<absWorkScheduleLogin, bool>>)(b => b.UserId.ToUpper().Trim() == entity.UserId.ToUpper().Trim() && b.ProgramName.Trim() == entity.ProgramName.Trim())).FirstOrDefault<absWorkScheduleLogin>();
                if (workScheduleLogin == null)
                {
                    absWorkScheduleLogin entity1 = new absWorkScheduleLogin();
                    entity1.UserId = entity.UserId.Trim();
                    entity1.ProgramName = entity.ProgramName.Trim();
                    if (!string.IsNullOrEmpty(entity.User))
                        entity1.AddUser = entity.User.ToString();
                    entity1.AddDateTime = new DateTime?(DateTime.Now);
                    try
                    {
                        ilaEntities.absWorkScheduleLogins.Add(entity1);
                        ilaEntities.SaveChanges();
                    }
                    catch (DbEntityValidationException ex)
                    {
                        stringBuilder.AppendLine("Error Adding record " + entity.UserId.Trim() + " to absWorkScheduleLogins Table");
                        stringBuilder.AppendLine("[ILA.DAL][Repositories][AbsScheduleLoginRepository.cs][Add]");
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
                        stringBuilder.AppendLine("Error Adding record " + entity.UserId.Trim() + " to absWorkScheduleLogins Table");
                        stringBuilder.AppendLine("[ILA.DAL][Repositories][AbsScheduleLoginRepository.cs][Add]");
                        stringBuilder.AppendLine("Exception:");
                        stringBuilder.AppendLine(ex.ToString());
                        throw new Exception(stringBuilder.ToString());
                    }
                }
                else
                {
                    flag = true;
                    num = workScheduleLogin.id;
                }
            }
            if (!flag)
                return;
            entity.Id = num.ToString();
            this.Update(entity);
        }

        public void Delete(absScheduleLoginEntity entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int entityId = -1;
            if (!int.TryParse(entity.Id, out entityId))
                return;
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                absWorkScheduleLogin entity1 = ilaEntities.absWorkScheduleLogins.Where<absWorkScheduleLogin>((Expression<Func<absWorkScheduleLogin, bool>>)(b => b.id == entityId)).FirstOrDefault<absWorkScheduleLogin>();
                if (entity1 != null)
                {
                    try
                    {
                        ilaEntities.absWorkScheduleLogins.Remove(entity1);
                        ilaEntities.SaveChanges();
                    }
                    catch (DbEntityValidationException ex)
                    {
                        stringBuilder.AppendLine("Error Deleting " + entity.UserId.Trim() + " from absWorkScheduleLogins Table");
                        stringBuilder.AppendLine("[ILA.DAL][Repositories][AbsScheduleLoginRepository.cs][Delete]");
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
                        stringBuilder.AppendLine("Error Deleting " + entity.UserId.Trim() + " from absWorkScheduleLogins Table");
                        stringBuilder.AppendLine("[ILA.DAL][Repositories][AbsScheduleLoginRepository.cs][Delete]");
                        stringBuilder.AppendLine("Exception:");
                        stringBuilder.AppendLine(ex.ToString());
                        throw new Exception(stringBuilder.ToString());
                    }
                }
            }
        }

        private absScheduleLoginEntity BuildEntity(absWorkScheduleLogin login)
        {
            absScheduleLoginEntity scheduleLoginEntity = new absScheduleLoginEntity();
            scheduleLoginEntity.Id = login.id.ToString();
            scheduleLoginEntity.UserId = login.UserId.Trim();
            scheduleLoginEntity.ProgramName = login.ProgramName.Trim();
            return scheduleLoginEntity;
        }

        List<absScheduleLoginEntity> IRepository<absScheduleLoginEntity>.GetAll()
        {
            throw new NotImplementedException();
        }

        absScheduleLoginEntity IRepository<absScheduleLoginEntity>.Get(string id)
        {
            throw new NotImplementedException();
        }
    }
}