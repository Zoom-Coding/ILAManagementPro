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
    public class absWorkGangTemplateRepository : RepositoryBase<absWorkGangTemplateEntity>, IRepository<absWorkGangTemplateEntity>
    {
        public List<absWorkGangTemplateEntity> GetAll()
        {
            List<absWorkGangTemplateEntity> gangTemplateEntityList = new List<absWorkGangTemplateEntity>();
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                foreach (absWorkGangTemplate workGangTemplate in (IEnumerable<absWorkGangTemplate>)ilaEntities.absWorkGangTemplates)
                    gangTemplateEntityList.Add(this.BuildEntity(workGangTemplate));
            }
            return gangTemplateEntityList;
        }

        public absWorkGangTemplateEntity Get(string id)
        {
            absWorkGangTemplateEntity gangTemplateEntity = (absWorkGangTemplateEntity)null;
            int ID;
            if (int.TryParse(id, out ID))
            {
                using (ILAEntities ilaEntities = new ILAEntities())
                {
                    absWorkGangTemplate gang = ilaEntities.absWorkGangTemplates.Where<absWorkGangTemplate>((Expression<Func<absWorkGangTemplate, bool>>)(b => b.Id == ID)).FirstOrDefault<absWorkGangTemplate>();
                    if (gang != null)
                        gangTemplateEntity = this.BuildEntity(gang);
                }
            }
            return gangTemplateEntity;
        }

        public void Update(absWorkGangTemplateEntity entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Error Updating absBerth Table");
            stringBuilder.AppendLine("[ILA.DAL][Repositories][AbsBerthRepository.cs][Update]");
            stringBuilder.AppendLine("Exception:");
            int ID;
            if (!int.TryParse(entity.Id, out ID))
                return;
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                absWorkGangTemplate workGangTemplate1 = ilaEntities.absWorkGangTemplates.Where<absWorkGangTemplate>((Expression<Func<absWorkGangTemplate, bool>>)(b => b.Id == ID)).FirstOrDefault<absWorkGangTemplate>();
                if (workGangTemplate1 != null)
                {
                    workGangTemplate1.TemplateDescription = entity.TemplateDescription;
                    workGangTemplate1.TemplateCount = entity.TemplateCount;
                    workGangTemplate1.Default2GangId = entity.Default2GangId;
                    workGangTemplate1.Default6GangId = entity.Default6GangId;
                    workGangTemplate1.Default7GangId = entity.Default7GangId;
                    workGangTemplate1.DefaultWBGangId = entity.DefaultWBGangId;
                    if (!string.IsNullOrEmpty(entity.AddUser))
                        workGangTemplate1.AddUser = entity.AddUser;
                    if (!string.IsNullOrEmpty(entity.UpdateUser))
                        workGangTemplate1.UpdateUser = entity.UpdateUser;
                    DateTime? nullable1;
                    if (((DateTime?)entity.AddDateTime).HasValue)
                    {
                        absWorkGangTemplate workGangTemplate2 = workGangTemplate1;
                        nullable1 = (DateTime?)entity.AddDateTime;
                        DateTime? nullable2 = new DateTime?(nullable1.Value);
                        workGangTemplate2.AddDateTime = nullable2;
                    }
                    nullable1 = (DateTime?)entity.UpdateDateTime;
                    if (nullable1.HasValue)
                    {
                        absWorkGangTemplate workGangTemplate2 = workGangTemplate1;
                        nullable1 = (DateTime?)entity.UpdateDateTime;
                        DateTime? nullable2 = new DateTime?(nullable1.Value);
                        workGangTemplate2.UpdateDateTime = nullable2;
                    }
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

        public void Add(absWorkGangTemplateEntity entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Error Adding record " + entity.TemplateDescription.Trim() + " to absBerth Table");
            stringBuilder.AppendLine("[ILA.DAL][Repositories][AbsBerthRepository.cs][Add]");
            stringBuilder.AppendLine("Exception:");
            bool flag = false;
            int num = -1;
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                absWorkGangTemplate workGangTemplate1 = ilaEntities.absWorkGangTemplates.Where<absWorkGangTemplate>((Expression<Func<absWorkGangTemplate, bool>>)(b => b.TemplateDescription.ToUpper().Trim() == entity.TemplateDescription.ToUpper().Trim())).FirstOrDefault<absWorkGangTemplate>();
                if (workGangTemplate1 == null)
                {
                    absWorkGangTemplate entity1 = new absWorkGangTemplate();
                    entity1.TemplateDescription = entity.TemplateDescription;
                    entity1.TemplateCount = entity.TemplateCount;
                    entity1.Default2GangId = entity.Default2GangId;
                    entity1.Default6GangId = entity.Default6GangId;
                    entity1.Default7GangId = entity.Default7GangId;
                    entity1.DefaultWBGangId = entity.DefaultWBGangId;
                    if (!string.IsNullOrEmpty(entity.AddUser))
                        entity1.AddUser = entity.AddUser;
                    if (!string.IsNullOrEmpty(entity.UpdateUser))
                        entity1.UpdateUser = entity.UpdateUser;
                    DateTime? nullable1 = (DateTime?)entity.AddDateTime;
                    if (nullable1.HasValue)
                    {
                        absWorkGangTemplate workGangTemplate2 = entity1;
                        nullable1 = (DateTime?)entity.AddDateTime;
                        DateTime? nullable2 = new DateTime?(nullable1.Value);
                        workGangTemplate2.AddDateTime = nullable2;
                    }
                    nullable1 = (DateTime?)entity.UpdateDateTime;
                    if (nullable1.HasValue)
                    {
                        absWorkGangTemplate workGangTemplate2 = entity1;
                        nullable1 = (DateTime?)entity.UpdateDateTime;
                        DateTime? nullable2 = new DateTime?(nullable1.Value);
                        workGangTemplate2.UpdateDateTime = nullable2;
                    }
                    try
                    {
                        ilaEntities.absWorkGangTemplates.Add(entity1);
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
                    num = workGangTemplate1.Id;
                }
            }
            if (!flag)
                return;
            entity.Id = num.ToString();
            this.Update(entity);
        }

        public void Delete(absWorkGangTemplateEntity entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Error Deleting " + entity.TemplateDescription.Trim() + " from absWorkGangTemplate Table");
            stringBuilder.AppendLine("[ILA.DAL][Repositories][AbsWorkGangTemplateRepository.cs][Delete]");
            stringBuilder.AppendLine("Exception:");
            int ID;
            if (!int.TryParse(entity.Id, out ID))
                return;
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                absWorkGangTemplate entity1 = ilaEntities.absWorkGangTemplates.Where<absWorkGangTemplate>((Expression<Func<absWorkGangTemplate, bool>>)(b => b.Id == ID)).FirstOrDefault<absWorkGangTemplate>();
                if (entity1 != null)
                {
                    try
                    {
                        ilaEntities.absWorkGangTemplates.Remove(entity1);
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

        private absWorkGangTemplateEntity BuildEntity(absWorkGangTemplate gang)
        {
            absWorkGangTemplateEntity gangTemplateEntity = new absWorkGangTemplateEntity();
            gangTemplateEntity.Id = gang.Id.ToString();
            gangTemplateEntity.TemplateDescription = gang.TemplateDescription.Trim();
            gangTemplateEntity.TemplateCount = gang.TemplateCount;
            gangTemplateEntity.Default2GangId = gang.Default2GangId;
            gangTemplateEntity.Default6GangId = gang.Default6GangId;
            gangTemplateEntity.Default7GangId = gang.Default7GangId;
            gangTemplateEntity.DefaultWBGangId = gang.DefaultWBGangId;
            if (!string.IsNullOrEmpty(gang.AddUser))
                gangTemplateEntity.AddUser = gang.AddUser;
            if (!string.IsNullOrEmpty(gang.UpdateUser))
                gangTemplateEntity.UpdateUser = gang.UpdateUser;
            if (gang.AddDateTime.HasValue)
                gangTemplateEntity.AddDateTime = (DateTime?)new DateTime?(gang.AddDateTime.Value);
            if (gang.UpdateDateTime.HasValue)
                gangTemplateEntity.UpdateDateTime = (DateTime?)new DateTime?(gang.UpdateDateTime.Value);
            return gangTemplateEntity;
        }
    }
}