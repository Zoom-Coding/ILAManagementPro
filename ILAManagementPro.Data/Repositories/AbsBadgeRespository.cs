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
    public class AbsBadgeRepository : RepositoryBase<BadgeEntity>, IRepository<BadgeEntity>
    {
        public List<BadgeEntity> GetAll()
        {
            List<BadgeEntity> badgeEntityList = new List<BadgeEntity>();
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                foreach (absBadgeCardCrossRef badgeCardCrossRef in (IEnumerable<absBadgeCardCrossRef>)ilaEntities.absBadgeCardCrossRefs)
                    badgeEntityList.Add(this.BuildEntity(badgeCardCrossRef));
            }
            return badgeEntityList;
        }

        public BadgeEntity Get(string id)
        {
            BadgeEntity badgeEntity = (BadgeEntity)null;
            int ID;
            if (int.TryParse(id, out ID))
            {
                using (ILAEntities ilaEntities = new ILAEntities())
                {
                    absBadgeCardCrossRef badge = ilaEntities.absBadgeCardCrossRefs.Where<absBadgeCardCrossRef>((Expression<Func<absBadgeCardCrossRef, bool>>)(b => b.Id == ID)).FirstOrDefault<absBadgeCardCrossRef>();
                    if (badge != null)
                        badgeEntity = this.BuildEntity(badge);
                }
            }
            return badgeEntity;
        }

        public BadgeEntity GetByBadgeNumber(int badgeNumber)
        {
            BadgeEntity badgeEntity = (BadgeEntity)null;
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                absBadgeCardCrossRef badge = ilaEntities.absBadgeCardCrossRefs.Where<absBadgeCardCrossRef>((Expression<Func<absBadgeCardCrossRef, bool>>)(b => b.BadgeNumber == badgeNumber)).FirstOrDefault<absBadgeCardCrossRef>();
                if (badge != null)
                    badgeEntity = this.BuildEntity(badge);
            }
            return badgeEntity;
        }

        public void Update(BadgeEntity entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Error Updating Badge Card Cross Reference Table");
            stringBuilder.AppendLine("Badge #: " + entity.BadgeNumber.ToString());
            stringBuilder.AppendLine("Card #: " + ((Decimal)entity.CardNumber).ToString());
            stringBuilder.AppendLine("[ILA.DAL][Repositories][AbsBadgeRepository.cs][Update]");
            stringBuilder.AppendLine("Exception:");
            int ID;
            if (!int.TryParse(entity.Id, out ID))
                return;
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                absBadgeCardCrossRef badgeCardCrossRef = ilaEntities.absBadgeCardCrossRefs.Where<absBadgeCardCrossRef>((Expression<Func<absBadgeCardCrossRef, bool>>)(b => b.Id == ID)).FirstOrDefault<absBadgeCardCrossRef>();
                if (badgeCardCrossRef != null)
                {
                    badgeCardCrossRef.BadgeNumber = entity.BadgeNumber;
                    badgeCardCrossRef.CardNumber = (Decimal)entity.CardNumber;
                    if (!string.IsNullOrEmpty(entity.User))
                        badgeCardCrossRef.UpdateUser = entity.User.Trim();
                    badgeCardCrossRef.UpdateDateTime = new DateTime?(DateTime.Now);
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

        public void Add(BadgeEntity entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Error Adding to Badge Card Cross Reference Table");
            stringBuilder.AppendLine("Badge #: " + entity.BadgeNumber.ToString());
            stringBuilder.AppendLine("Card #: " + ((Decimal)entity.CardNumber).ToString());
            stringBuilder.AppendLine("[ILA.DAL][Repositories][AbsBadgeRepository.cs][Add]");
            stringBuilder.AppendLine("Exception:");
            bool flag = false;
            int num = -1;
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                absBadgeCardCrossRef badgeCardCrossRef = ilaEntities.absBadgeCardCrossRefs.Where<absBadgeCardCrossRef>((Expression<Func<absBadgeCardCrossRef, bool>>)(b => b.BadgeNumber == entity.BadgeNumber)).FirstOrDefault<absBadgeCardCrossRef>();
                if (badgeCardCrossRef == null)
                {
                    absBadgeCardCrossRef entity1 = new absBadgeCardCrossRef();
                    entity1.BadgeNumber = entity.BadgeNumber;
                    entity1.CardNumber = (Decimal)entity.CardNumber;
                    if (!string.IsNullOrEmpty(entity.User))
                        entity1.AddUser = entity.User.Trim();
                    entity1.AddDateTime = new DateTime?(DateTime.Now);
                    try
                    {
                        ilaEntities.absBadgeCardCrossRefs.Add(entity1);
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
                    num = badgeCardCrossRef.Id;
                }
            }
            if (!flag)
                return;
            entity.Id = num.ToString();
            this.Update(entity);
        }

        public void Delete(BadgeEntity entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Error Deleting from Badge Card Cross Reference Table");
            stringBuilder.AppendLine("Badge #: " + entity.BadgeNumber.ToString());
            stringBuilder.AppendLine("Card #: " + ((Decimal)entity.CardNumber).ToString());
            stringBuilder.AppendLine("[ILA.DAL][Repositories][AbsBadgeRepository.cs][Delete]");
            stringBuilder.AppendLine("Exception:");
            int ID;
            if (!int.TryParse(entity.Id, out ID))
                return;
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                absBadgeCardCrossRef entity1 = ilaEntities.absBadgeCardCrossRefs.Where<absBadgeCardCrossRef>((Expression<Func<absBadgeCardCrossRef, bool>>)(b => b.Id == ID)).FirstOrDefault<absBadgeCardCrossRef>();
                if (entity1 != null)
                {
                    try
                    {
                        ilaEntities.absBadgeCardCrossRefs.Remove(entity1);
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

        private BadgeEntity BuildEntity(absBadgeCardCrossRef badge)
        {
            BadgeEntity badgeEntity = new BadgeEntity();
            badgeEntity.Id = badge.Id.ToString();
            badgeEntity.CardNumber = (Decimal)badge.CardNumber;
            badgeEntity.BadgeNumber = badge.BadgeNumber;
            return badgeEntity;
        }
    }
}