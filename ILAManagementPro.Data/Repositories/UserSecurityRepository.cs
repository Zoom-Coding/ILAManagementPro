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
    public class UserSecurityRepository : RepositoryBase<UserSecurityEntity>, IRepository<UserSecurityEntity>
    {
        public List<UserSecurityEntity> GetAll()
        {
            List<UserSecurityEntity> source = new List<UserSecurityEntity>();
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                foreach (absSecurity absSecurity in (IEnumerable<absSecurity>)ilaEntities.absSecurities)
                    source.Add(this.BuildEntity(absSecurity));
            }
            return source.OrderBy<UserSecurityEntity, string>((Func<UserSecurityEntity, string>)(b => b.Id)).ToList<UserSecurityEntity>();
        }

        public UserSecurityEntity Get(string id)
        {
            UserSecurityEntity userSecurityEntity = (UserSecurityEntity)null;
            int ID;
            if (int.TryParse(id, out ID))
            {
                using (ILAEntities ilaEntities = new ILAEntities())
                {
                    absSecurity member = ilaEntities.absSecurities.Where<absSecurity>((Expression<Func<absSecurity, bool>>)(b => b.id == ID)).FirstOrDefault<absSecurity>();
                    if (member != null)
                        userSecurityEntity = this.BuildEntity(member);
                }
            }
            return userSecurityEntity;
        }

        public UserSecurityEntity GetByCardNumber(Decimal cardNumber)
        {
            UserSecurityEntity userSecurityEntity = (UserSecurityEntity)null;
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                try
                {
                    string CardNo = cardNumber.ToString();
                    absSecurity member = ilaEntities.absSecurities.Where<absSecurity>((Expression<Func<absSecurity, bool>>)(b => b.Login.Trim() == CardNo.Trim())).FirstOrDefault<absSecurity>();
                    if (member != null)
                        userSecurityEntity = this.BuildEntity(member);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            return userSecurityEntity;
        }

        public UserSecurityEntity GetByLogIn(string logIn)
        {
            UserSecurityEntity userSecurityEntity = (UserSecurityEntity)null;
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                absSecurity member = ilaEntities.absSecurities.Where<absSecurity>((Expression<Func<absSecurity, bool>>)(b => b.Login.ToUpper().Trim() == logIn.ToUpper().Trim())).FirstOrDefault<absSecurity>();
                if (member != null)
                    userSecurityEntity = this.BuildEntity(member);
            }
            return userSecurityEntity;
        }

        public void Update(UserSecurityEntity entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Error Updating abs Security Table");
            stringBuilder.AppendLine("Card #: " + entity.LogIn.ToString());
            stringBuilder.AppendLine("[ILA.DAL][Repositories][UserSecurityRepository.cs][Update]");
            stringBuilder.AppendLine("Exception:");
            int ID;
            if (!int.TryParse(entity.Id, out ID))
                return;
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                absSecurity absSecurity1 = ilaEntities.absSecurities.Where<absSecurity>((Expression<Func<absSecurity, bool>>)(b => b.id == ID)).FirstOrDefault<absSecurity>();
                if (absSecurity1 != null)
                {
                    absSecurity1.Login = entity.LogIn;
                    if (entity.UserName != null)
                        absSecurity1.UserName = entity.UserName.Trim();
                    bool? nullable1;
                    if (((bool?)entity.AuthorizeUsers).HasValue)
                    {
                        absSecurity absSecurity2 = absSecurity1;
                        nullable1 = (bool?)entity.AuthorizeUsers;
                        bool? nullable2 = new bool?(nullable1.Value);
                        absSecurity2.AuthorizeUsers = nullable2;
                    }
                    else
                        absSecurity1.AuthorizeUsers = new bool?();
                    nullable1 = (bool?)entity.PrintBadges;
                    if (nullable1.HasValue)
                    {
                        absSecurity absSecurity2 = absSecurity1;
                        nullable1 = (bool?)entity.PrintBadges;
                        bool? nullable2 = new bool?(nullable1.Value);
                        absSecurity2.PrintBadge = nullable2;
                    }
                    else
                    {
                        absSecurity absSecurity2 = absSecurity1;
                        nullable1 = new bool?();
                        bool? nullable2 = nullable1;
                        absSecurity2.PrintBadge = nullable2;
                    }
                    nullable1 = (bool?)entity.WorkScheduleMaintenance;
                    if (nullable1.HasValue)
                    {
                        absSecurity absSecurity2 = absSecurity1;
                        nullable1 = (bool?)entity.WorkScheduleMaintenance;
                        bool? nullable2 = new bool?(nullable1.Value);
                        absSecurity2.WorkScheduleMaintenance = nullable2;
                    }
                    else
                    {
                        absSecurity absSecurity2 = absSecurity1;
                        nullable1 = new bool?();
                        bool? nullable2 = nullable1;
                        absSecurity2.WorkScheduleMaintenance = nullable2;
                    }
                    nullable1 = (bool?)entity.TimeCardMaintenance;
                    if (nullable1.HasValue)
                    {
                        absSecurity absSecurity2 = absSecurity1;
                        nullable1 = (bool?)entity.TimeCardMaintenance;
                        bool? nullable2 = new bool?(nullable1.Value);
                        absSecurity2.TimeCardMaintenance = nullable2;
                    }
                    else
                    {
                        absSecurity absSecurity2 = absSecurity1;
                        nullable1 = new bool?();
                        bool? nullable2 = nullable1;
                        absSecurity2.TimeCardMaintenance = nullable2;
                    }
                    nullable1 = (bool?)entity.PodiumProgram;
                    if (nullable1.HasValue)
                    {
                        absSecurity absSecurity2 = absSecurity1;
                        nullable1 = (bool?)entity.PodiumProgram;
                        bool? nullable2 = new bool?(nullable1.Value);
                        absSecurity2.PodiumProgram = nullable2;
                    }
                    else
                    {
                        absSecurity absSecurity2 = absSecurity1;
                        nullable1 = new bool?();
                        bool? nullable2 = nullable1;
                        absSecurity2.PodiumProgram = nullable2;
                    }
                    if (!string.IsNullOrEmpty(entity.User))
                        absSecurity1.UpdateUser = entity.User.Trim();
                    absSecurity1.UpdateDateTime = new DateTime?(DateTime.Now);
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

        public void Add(UserSecurityEntity entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Error Adding to abs Security Table");
            stringBuilder.AppendLine("Card #: " + entity.LogIn.ToString());
            stringBuilder.AppendLine("[ILA.DAL][Repositories][UserSecurityRepository.cs][Add]");
            stringBuilder.AppendLine("Exception:");
            bool flag = false;
            int id;
            int.TryParse(entity.Id, out id);
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                absSecurity absSecurity1 = ilaEntities.absSecurities.Where<absSecurity>((Expression<Func<absSecurity, bool>>)(b => b.id == id)).FirstOrDefault<absSecurity>();
                if (absSecurity1 == null)
                {
                    absSecurity entity1 = new absSecurity();
                    entity1.Login = entity.LogIn;
                    if (entity.UserName != null)
                        entity1.UserName = entity.UserName.Trim();
                    bool? nullable1;
                    if (((bool?)entity.AuthorizeUsers).HasValue)
                    {
                        absSecurity absSecurity2 = entity1;
                        nullable1 = (bool?)entity.AuthorizeUsers;
                        bool? nullable2 = new bool?(nullable1.Value);
                        absSecurity2.AuthorizeUsers = nullable2;
                    }
                    else
                        entity1.AuthorizeUsers = new bool?();
                    nullable1 = (bool?)entity.PrintBadges;
                    if (nullable1.HasValue)
                    {
                        absSecurity absSecurity2 = entity1;
                        nullable1 = (bool?)entity.PrintBadges;
                        bool? nullable2 = new bool?(nullable1.Value);
                        absSecurity2.PrintBadge = nullable2;
                    }
                    else
                    {
                        absSecurity absSecurity2 = entity1;
                        nullable1 = new bool?();
                        bool? nullable2 = nullable1;
                        absSecurity2.PrintBadge = nullable2;
                    }
                    nullable1 = (bool?)entity.WorkScheduleMaintenance;
                    if (nullable1.HasValue)
                    {
                        absSecurity absSecurity2 = entity1;
                        nullable1 = (bool?)entity.WorkScheduleMaintenance;
                        bool? nullable2 = new bool?(nullable1.Value);
                        absSecurity2.WorkScheduleMaintenance = nullable2;
                    }
                    else
                    {
                        absSecurity absSecurity2 = entity1;
                        nullable1 = new bool?();
                        bool? nullable2 = nullable1;
                        absSecurity2.WorkScheduleMaintenance = nullable2;
                    }
                    nullable1 = (bool?)entity.TimeCardMaintenance;
                    if (nullable1.HasValue)
                    {
                        absSecurity absSecurity2 = entity1;
                        nullable1 = (bool?)entity.TimeCardMaintenance;
                        bool? nullable2 = new bool?(nullable1.Value);
                        absSecurity2.TimeCardMaintenance = nullable2;
                    }
                    else
                    {
                        absSecurity absSecurity2 = entity1;
                        nullable1 = new bool?();
                        bool? nullable2 = nullable1;
                        absSecurity2.TimeCardMaintenance = nullable2;
                    }
                    nullable1 = (bool?)entity.PodiumProgram;
                    if (nullable1.HasValue)
                    {
                        absSecurity absSecurity2 = entity1;
                        nullable1 = (bool?)entity.PodiumProgram;
                        bool? nullable2 = new bool?(nullable1.Value);
                        absSecurity2.PodiumProgram = nullable2;
                    }
                    else
                    {
                        absSecurity absSecurity2 = entity1;
                        nullable1 = new bool?();
                        bool? nullable2 = nullable1;
                        absSecurity2.PodiumProgram = nullable2;
                    }
                    if (!string.IsNullOrEmpty(entity.User))
                        entity1.AddUser = entity.User.Trim();
                    entity1.AddDateTime = new DateTime?(DateTime.Now);
                    try
                    {
                        ilaEntities.absSecurities.Add(entity1);
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
                    id = absSecurity1.id;
                }
            }
            if (!flag)
                return;
            entity.Id = id.ToString();
            this.Update(entity);
        }

        public void Delete(UserSecurityEntity entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Error Deleting from absSecurity Table");
            stringBuilder.AppendLine("Card #: " + entity.LogIn.ToString());
            stringBuilder.AppendLine("[ILA.DAL][Repositories][UserSecurityRepository.cs][Delete]");
            stringBuilder.AppendLine("Exception:");
            int ID;
            if (!int.TryParse(entity.Id, out ID))
                return;
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                absSecurity entity1 = ilaEntities.absSecurities.Where<absSecurity>((Expression<Func<absSecurity, bool>>)(b => b.id == ID)).FirstOrDefault<absSecurity>();
                if (entity1 != null)
                {
                    try
                    {
                        ilaEntities.absSecurities.Remove(entity1);
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

        private UserSecurityEntity BuildEntity(absSecurity member)
        {
            UserSecurityEntity userSecurityEntity = new UserSecurityEntity();
            userSecurityEntity.Id = member.id.ToString();
            userSecurityEntity.LogIn = member.Login;
            if (member.UserName != null)
                userSecurityEntity.UserName = member.UserName.Trim();
            if (member.AuthorizeUsers.HasValue)
                userSecurityEntity.AuthorizeUsers = (bool?)new bool?(member.AuthorizeUsers.Value);
            if (member.PrintBadge.HasValue)
                userSecurityEntity.PrintBadges = (bool?)new bool?(member.PrintBadge.Value);
            if (member.WorkScheduleMaintenance.HasValue)
                userSecurityEntity.WorkScheduleMaintenance = (bool?)new bool?(member.WorkScheduleMaintenance.Value);
            if (member.TimeCardMaintenance.HasValue)
                userSecurityEntity.TimeCardMaintenance = (bool?)new bool?(member.TimeCardMaintenance.Value);
            if (member.PodiumProgram.HasValue)
                userSecurityEntity.PodiumProgram = (bool?)new bool?(member.PodiumProgram.Value);
            return userSecurityEntity;
        }
    }
}