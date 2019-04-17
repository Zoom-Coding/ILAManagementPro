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
    public class AbsConfigurationRepository : RepositoryBase<ConfigurationEntity>, IRepository<ConfigurationEntity>
    {
        public List<ConfigurationEntity> GetAll()
        {
            List<ConfigurationEntity> source = new List<ConfigurationEntity>();
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                foreach (absConfiguration absConfiguration in (IEnumerable<absConfiguration>)ilaEntities.absConfigurations)
                    source.Add(this.BuildEntity(absConfiguration));
            }
            return source.OrderBy<ConfigurationEntity, string>((Func<ConfigurationEntity, string>)(c => c.Id)).ToList<ConfigurationEntity>();
        }

        public ConfigurationEntity Get(string id)
        {
            ConfigurationEntity configurationEntity = (ConfigurationEntity)null;
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                absConfiguration config = ilaEntities.absConfigurations.Where<absConfiguration>((Expression<Func<absConfiguration, bool>>)(c => c.keyValue.Trim() == id.Trim())).FirstOrDefault<absConfiguration>();
                if (config != null)
                    configurationEntity = this.BuildEntity(config);
            }
            return configurationEntity;
        }

        public void Update(ConfigurationEntity entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                absConfiguration absConfiguration = ilaEntities.absConfigurations.Where<absConfiguration>((Expression<Func<absConfiguration, bool>>)(c => c.keyValue.Trim() == entity.Id.Trim())).FirstOrDefault<absConfiguration>();
                if (absConfiguration == null)
                    return;
                absConfiguration.propValue = entity.PropertyValue.Trim();
                if (!string.IsNullOrEmpty(entity.User))
                    absConfiguration.UpdateUser = entity.User.ToString();
                absConfiguration.UpdateDateTime = new DateTime?(DateTime.Now);
                try
                {
                    ilaEntities.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    stringBuilder.AppendLine("Error Updating absConfiguration Table");
                    stringBuilder.AppendLine("[ILA.DAL][Repositories][AbsConfigurationRepository.cs][Update]");
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
                    stringBuilder.AppendLine("Error Updating absConfiguration Table");
                    stringBuilder.AppendLine("[ILA.DAL][Repositories][AbsConfigurationRepository.cs][Update]");
                    stringBuilder.AppendLine("Exception:");
                    stringBuilder.AppendLine(ex.ToString());
                    throw new Exception(stringBuilder.ToString());
                }
            }
        }

        public void Add(ConfigurationEntity entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool flag = false;
            string str = (string)null;
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                absConfiguration absConfiguration = ilaEntities.absConfigurations.Where<absConfiguration>((Expression<Func<absConfiguration, bool>>)(c => c.keyValue.Trim() == entity.Id.Trim())).FirstOrDefault<absConfiguration>();
                if (absConfiguration == null)
                {
                    absConfiguration entity1 = new absConfiguration();
                    entity1.keyValue = entity.Id.Trim();
                    entity1.propValue = entity.PropertyValue.Trim();
                    if (!string.IsNullOrEmpty(entity.User))
                        entity1.AddUser = entity.User.ToString();
                    entity1.AddDateTime = new DateTime?(DateTime.Now);
                    try
                    {
                        ilaEntities.absConfigurations.Add(entity1);
                        ilaEntities.SaveChanges();
                    }
                    catch (DbEntityValidationException ex)
                    {
                        stringBuilder.AppendLine("Error Adding record " + entity.Id.Trim() + " to absConfiguration Table");
                        stringBuilder.AppendLine("[ILA.DAL][Repositories][AbsConfigurationRepository.cs][Add]");
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
                        stringBuilder.AppendLine("Error Adding record " + entity.Id.Trim() + " to absConfiguration Table");
                        stringBuilder.AppendLine("[ILA.DAL][Repositories][AbsConfigurationRepository.cs][Add]");
                        stringBuilder.AppendLine("Exception:");
                        stringBuilder.AppendLine(ex.ToString());
                        throw new Exception(stringBuilder.ToString());
                    }
                }
                else
                {
                    flag = true;
                    str = absConfiguration.keyValue;
                }
            }
            if (!flag)
                return;
            entity.Id = str.Trim();
            this.Update(entity);
        }

        public void Delete(ConfigurationEntity entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                absConfiguration entity1 = ilaEntities.absConfigurations.Where<absConfiguration>((Expression<Func<absConfiguration, bool>>)(c => c.keyValue.Trim() == entity.Id.Trim())).FirstOrDefault<absConfiguration>();
                if (entity1 == null)
                    return;
                try
                {
                    ilaEntities.absConfigurations.Remove(entity1);
                    ilaEntities.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    stringBuilder.AppendLine("Error Deleting " + entity.Id.Trim() + " from absConfiguration Table");
                    stringBuilder.AppendLine("[ILA.DAL][Repositories][AbsBerthRepository.cs][Delete]");
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
                    stringBuilder.AppendLine("Error Deleting " + entity.Id.Trim() + " from absConfiguration Table");
                    stringBuilder.AppendLine("[ILA.DAL][Repositories][AbsBerthRepository.cs][Delete]");
                    stringBuilder.AppendLine("Exception:");
                    stringBuilder.AppendLine(ex.ToString());
                    throw new Exception(stringBuilder.ToString());
                }
            }
        }

        private ConfigurationEntity BuildEntity(absConfiguration config)
        {
            ConfigurationEntity configurationEntity = new ConfigurationEntity();
            configurationEntity.Id = config.keyValue.Trim();
            configurationEntity.PropertyValue = config.propValue.Trim();
            return configurationEntity;
        }
    }
}