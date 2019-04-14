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
    public class AbsBerthRepository : RepositoryBase<BerthEntity>, IRepository<BerthEntity>
    {
        public List<BerthEntity> GetAll()
        {
            List<BerthEntity> source = new List<BerthEntity>();
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                foreach (absBerth absBerth in (IEnumerable<absBerth>)ilaEntities.absBerths)
                    source.Add(this.BuildEntity(absBerth));
            }
            return source.OrderBy<BerthEntity, string>((Func<BerthEntity, string>)(b => b.ShortBerthName)).ToList<BerthEntity>();
        }

        public BerthEntity Get(string id)
        {
            BerthEntity berthEntity = (BerthEntity)null;
            int ID;
            if (int.TryParse(id, out ID))
            {
                using (ILAEntities ilaEntities = new ILAEntities())
                {
                    absBerth berth = ilaEntities.absBerths.Where<absBerth>((Expression<Func<absBerth, bool>>)(b => b.id == ID)).FirstOrDefault<absBerth>();
                    if (berth != null)
                        berthEntity = this.BuildEntity(berth);
                }
            }
            return berthEntity;
        }

        public void Update(BerthEntity entity)
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
                absBerth absBerth = ilaEntities.absBerths.Where<absBerth>((Expression<Func<absBerth, bool>>)(b => b.id == ID)).FirstOrDefault<absBerth>();
                if (absBerth != null)
                {
                    absBerth.BerthShortName = entity.ShortBerthName.ToUpper().Trim();
                    if (entity.FullBerthName != null)
                        absBerth.BerthFullName = entity.FullBerthName.ToUpper().Trim();
                    if (!string.IsNullOrEmpty(entity.User))
                        absBerth.UpdateUser = entity.User.ToString();
                    absBerth.UpdateDateTime = new DateTime?(DateTime.Now);
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

        public void Add(BerthEntity entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Error Adding record " + entity.ShortBerthName.Trim() + " to absBerth Table");
            stringBuilder.AppendLine("[ILA.DAL][Repositories][AbsBerthRepository.cs][Add]");
            stringBuilder.AppendLine("Exception:");
            bool flag = false;
            int num = -1;
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                absBerth absBerth = ilaEntities.absBerths.Where<absBerth>((Expression<Func<absBerth, bool>>)(b => b.BerthShortName.ToUpper().Trim() == entity.ShortBerthName.ToUpper().Trim())).FirstOrDefault<absBerth>();
                if (absBerth == null)
                {
                    absBerth entity1 = new absBerth();
                    entity1.BerthShortName = entity.ShortBerthName.ToUpper().Trim();
                    if (entity.FullBerthName != null)
                        entity1.BerthFullName = entity.FullBerthName.ToUpper().Trim();
                    if (!string.IsNullOrEmpty(entity.User))
                        entity1.AddUser = entity.User.ToString();
                    entity1.AddDateTime = new DateTime?(DateTime.Now);
                    try
                    {
                        ilaEntities.absBerths.Add(entity1);
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
                    num = absBerth.id;
                }
            }
            if (!flag)
                return;
            entity.Id = num.ToString();
            this.Update(entity);
        }

        public void Delete(BerthEntity entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Error Deleting " + entity.ShortBerthName.Trim() + " from absBerth Table");
            stringBuilder.AppendLine("[ILA.DAL][Repositories][AbsBerthRepository.cs][Delete]");
            stringBuilder.AppendLine("Exception:");
            int ID;
            if (!int.TryParse(entity.Id, out ID))
                return;
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                absBerth entity1 = ilaEntities.absBerths.Where<absBerth>((Expression<Func<absBerth, bool>>)(b => b.id == ID)).FirstOrDefault<absBerth>();
                if (entity1 != null)
                {
                    try
                    {
                        ilaEntities.absBerths.Remove(entity1);
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

        private BerthEntity BuildEntity(absBerth berth)
        {
            BerthEntity berthEntity = new BerthEntity();
            berthEntity.Id = berth.id.ToString();
            berthEntity.ShortBerthName = berth.BerthShortName.Trim();
            if (!string.IsNullOrWhiteSpace(berth.BerthFullName))
                berthEntity.FullBerthName = berth.BerthFullName.Trim();
            return berthEntity;
        }
    }
}