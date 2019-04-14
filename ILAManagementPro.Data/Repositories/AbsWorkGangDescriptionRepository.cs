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
    public class AbsWorkGangDescriptionRepository : RepositoryBase<WorkGangDescriptionEntity>, IRepository<WorkGangDescriptionEntity>
    {
        public List<WorkGangDescriptionEntity> GetAll()
        {
            List<WorkGangDescriptionEntity> source = new List<WorkGangDescriptionEntity>();
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                foreach (absWorkGangDescription workGangDescription in (IEnumerable<absWorkGangDescription>)ilaEntities.absWorkGangDescriptions)
                    source.Add(this.BuildEntity(workGangDescription));
            }
            return source.OrderBy<WorkGangDescriptionEntity, string>((Func<WorkGangDescriptionEntity, string>)(b => b.Description)).ToList<WorkGangDescriptionEntity>();
        }

        public WorkGangDescriptionEntity Get(string id)
        {
            WorkGangDescriptionEntity descriptionEntity = (WorkGangDescriptionEntity)null;
            int ID;
            if (int.TryParse(id, out ID))
            {
                using (ILAEntities ilaEntities = new ILAEntities())
                {
                    absWorkGangDescription gang = ilaEntities.absWorkGangDescriptions.Where<absWorkGangDescription>((Expression<Func<absWorkGangDescription, bool>>)(b => b.Id == ID)).FirstOrDefault<absWorkGangDescription>();
                    if (gang != null)
                        descriptionEntity = this.BuildEntity(gang);
                }
            }
            return descriptionEntity;
        }

        public void Update(WorkGangDescriptionEntity entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Error Updating absWorkGangDescription Table");
            stringBuilder.AppendLine("[ILA.DAL][Repositories][absWorkGangDescriptionRepository.cs][Update]");
            stringBuilder.AppendLine("Exception:");
            int ID;
            if (!int.TryParse(entity.Id, out ID))
                return;
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                absWorkGangDescription workGangDescription = ilaEntities.absWorkGangDescriptions.Where<absWorkGangDescription>((Expression<Func<absWorkGangDescription, bool>>)(b => b.Id == ID)).FirstOrDefault<absWorkGangDescription>();
                if (workGangDescription != null)
                {
                    workGangDescription.Description = entity.Description.ToUpper().Trim();
                    workGangDescription.DriverGang = new bool?(entity.DriverGang);
                    if (!string.IsNullOrEmpty(entity.User))
                        workGangDescription.UpdateUser = entity.User.Trim();
                    workGangDescription.UpdateDateTime = new DateTime?(DateTime.Now);
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

        public void Add(WorkGangDescriptionEntity entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool flag = false;
            int num = -1;
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                absWorkGangDescription workGangDescription = ilaEntities.absWorkGangDescriptions.Where<absWorkGangDescription>((Expression<Func<absWorkGangDescription, bool>>)(b => b.Description.ToUpper().Trim() == entity.Description.ToUpper().Trim())).FirstOrDefault<absWorkGangDescription>();
                if (workGangDescription == null)
                {
                    absWorkGangDescription entity1 = new absWorkGangDescription();
                    entity1.Description = entity.Description.ToUpper().Trim();
                    entity1.DriverGang = new bool?(entity.DriverGang);
                    if (!string.IsNullOrEmpty(entity.User))
                        entity1.AddUser = entity.User.Trim();
                    entity1.AddDateTime = new DateTime?(DateTime.Now);
                    try
                    {
                        ilaEntities.absWorkGangDescriptions.Add(entity1);
                        ilaEntities.SaveChanges();
                    }
                    catch (DbEntityValidationException ex)
                    {
                        stringBuilder.AppendLine("Error Adding record " + entity.Description.Trim() + " to absWorkGangDescription Table");
                        stringBuilder.AppendLine("[ILA.DAL][Repositories][absWorkGangDescriptionRepository.cs][Add]");
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
                        stringBuilder.AppendLine("Error Adding record " + entity.Description.Trim() + " to absWorkGangDescription Table");
                        stringBuilder.AppendLine("[ILA.DAL][Repositories][absWorkGangDescriptionRepository.cs][Add]");
                        stringBuilder.AppendLine("Exception:");
                        stringBuilder.AppendLine(ex.ToString());
                        throw new Exception(stringBuilder.ToString());
                    }
                }
                else
                {
                    flag = true;
                    num = workGangDescription.Id;
                }
            }
            if (!flag)
                return;
            entity.Id = num.ToString();
            this.Update(entity);
        }

        public void Delete(WorkGangDescriptionEntity entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Error Deleting " + entity.Description.Trim() + " from absWorkGangDescription Table");
            stringBuilder.AppendLine("[ILA.DAL][Repositories][absWorkGangDescriptionRepository.cs][Delete]");
            stringBuilder.AppendLine("Exception:");
            int ID;
            if (!int.TryParse(entity.Id, out ID))
                return;
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                absWorkGangDescription entity1 = ilaEntities.absWorkGangDescriptions.Where<absWorkGangDescription>((Expression<Func<absWorkGangDescription, bool>>)(b => b.Id == ID)).FirstOrDefault<absWorkGangDescription>();
                if (entity1 != null)
                {
                    try
                    {
                        ilaEntities.absWorkGangDescriptions.Remove(entity1);
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

        private WorkGangDescriptionEntity BuildEntity(
          absWorkGangDescription gang)
        {
            WorkGangDescriptionEntity descriptionEntity = new WorkGangDescriptionEntity();
            descriptionEntity.Id = gang.Id.ToString();
            descriptionEntity.Description = gang.Description.Trim();
            descriptionEntity.DriverGang = gang.DriverGang.HasValue && gang.DriverGang.Value;
            return descriptionEntity;
        }
    }
}