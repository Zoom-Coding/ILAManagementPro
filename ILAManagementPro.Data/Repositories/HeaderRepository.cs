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
using InsuredMaster = ILAManagementPro.Data.Data.InsuredMaster;

namespace ILAManagementPro.Data.Repositories
{
    public class HeaderRepository : RepositoryBase<HeaderEntity>, IRepository<HeaderEntity>
    {
        public List<HeaderEntity> GetAll()
        {
            this.CheckSuspensions();
            List<HeaderEntity> source = new List<HeaderEntity>();
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                foreach (InsuredMaster insuredMaster in (IEnumerable<InsuredMaster>)ilaEntities.InsuredMasters)
                    source.Add(this.BuildEntity(insuredMaster));
            }
            return source.OrderBy<HeaderEntity, string>((Func<HeaderEntity, string>)(h => h.Id)).ToList<HeaderEntity>();
        }

        public List<HeaderEntity> GetAllByDate(DateTime workDate)
        {
            this.CheckSuspensions();
            List<HeaderEntity> source = new List<HeaderEntity>();
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                foreach (InsuredMaster insuredMaster in (IEnumerable<InsuredMaster>)ilaEntities.InsuredMasters)
                    source.Add(this.BuildEntity(insuredMaster));
            }
            return source.OrderBy<HeaderEntity, string>((Func<HeaderEntity, string>)(h => h.Id)).ToList<HeaderEntity>();
        }

        public HeaderEntity Get(string id)
        {
            this.CheckSuspensions();
            HeaderEntity headerEntity = (HeaderEntity)null;
            Decimal idNumber;
            if (Decimal.TryParse(id, out idNumber))
            {
                using (ILAEntities ilaEntities = new ILAEntities())
                {
                    InsuredMaster member = ilaEntities.InsuredMasters.Where<InsuredMaster>((Expression<Func<InsuredMaster, bool>>)(m => m.CardNo == idNumber)).FirstOrDefault<InsuredMaster>();
                    if (member != null)
                        headerEntity = this.BuildEntity(member);
                }
            }
            return headerEntity;
        }

        public void Update(HeaderEntity entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Error Updating Insured Master Table");
            stringBuilder.AppendLine("[ILA.DAL][Repositories][HeaderRepository.cs][Update]");
            stringBuilder.AppendLine("Exception:");
            Decimal idNumber;
            if (!Decimal.TryParse(entity.Id, out idNumber))
                return;
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                InsuredMaster insuredMaster = ilaEntities.InsuredMasters.Where<InsuredMaster>((Expression<Func<InsuredMaster, bool>>)(m => m.CardNo == idNumber)).FirstOrDefault<InsuredMaster>();
                if (insuredMaster != null)
                {
                    if (entity.User != null)
                        insuredMaster.UpdateUser = entity.User.Trim();
                    insuredMaster.UpdateDate = new DateTime?(DateTime.Now);
                    insuredMaster.DRIVER_TWIC_ID = entity.TwicCard == null ? (string)null : entity.TwicCard.Trim();
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

        public void Add(HeaderEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(HeaderEntity entity)
        {
            throw new NotImplementedException();
        }

        private HeaderEntity BuildEntity(InsuredMaster member)
        {
            HeaderEntity headerEntity1 = new HeaderEntity();
            headerEntity1.Id = member.CardNo.ToString();
            headerEntity1.FirstName = string.IsNullOrWhiteSpace(member.FirstName) ? " " : member.FirstName.Trim();
            headerEntity1.MiddleInitial = string.IsNullOrWhiteSpace(member.MI) ? "" : member.MI.Trim();
            headerEntity1.LastName = string.IsNullOrWhiteSpace(member.LastName) ? "" : member.LastName.Trim();
            headerEntity1.DisplayName = headerEntity1.FirstName.Substring(0, 1) + " " + headerEntity1.LastName;
            headerEntity1.DisplayName = headerEntity1.DisplayName.Replace(", JR.", " JR");
            bool? nullable = member.HeaderYN;
            int num1;
            if (nullable.HasValue)
            {
                nullable = member.HeaderYN;
                num1 = !nullable.Value ? 1 : 0;
            }
            else
                num1 = 1;
            headerEntity1.HeaderMember = num1 == 0;
            if (!string.IsNullOrEmpty(member.AreaPhone))
                headerEntity1.Phone = member.AreaPhone.Trim();
            nullable = member.DailySuspension;
            if (nullable.HasValue)
            {
                HeaderEntity headerEntity2 = headerEntity1;
                nullable = member.DailySuspension;
                int num2 = nullable.Value ? 1 : 0;
                headerEntity2.DailySuspension = num2 != 0;
            }
            else
                headerEntity1.DailySuspension = false;
            if (member.Suspension != null)
                headerEntity1.Suspension = member.Suspension.Trim();
            if (member.SuspEndedDate.HasValue)
                headerEntity1.SuspensionEndDate = (DateTime?)new DateTime?(member.SuspEndedDate.Value);
            nullable = member.Active;
            if (nullable.HasValue)
            {
                HeaderEntity headerEntity2 = headerEntity1;
                nullable = member.Active;
                int num2 = nullable.Value ? 1 : 0;
                headerEntity2.Active = num2 != 0;
            }
            else
                headerEntity1.Active = false;
            headerEntity1.SSN = !member.SSN.HasValue ? (string)null : member.SSN.Value.ToString();
            if (member.DRIVER_TWIC_ID != null)
                headerEntity1.TwicCard = member.DRIVER_TWIC_ID.Trim();
            if (member.DateBirth.HasValue)
                headerEntity1.BirthDate = (DateTime?)member.DateBirth;
            if (!string.IsNullOrEmpty(member.ClassCode))
                headerEntity1.ClassCode = member.ClassCode;
            return headerEntity1;
        }

        private void CheckSuspensions()
        {
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                DateTime currentTime = DateTime.Now;
                DbSet<absDailySuspension> dailySuspensions = ilaEntities.absDailySuspensions;
                Expression<Func<absDailySuspension, bool>> predicate1 = (Expression<Func<absDailySuspension, bool>>)(d => d.SuspensionExpireDateTime < currentTime);
                foreach (absDailySuspension entity in dailySuspensions.Where<absDailySuspension>(predicate1).ToList<absDailySuspension>())
                    ilaEntities.absDailySuspensions.Remove(entity);
                StringBuilder stringBuilder = new StringBuilder();
                try
                {
                    ilaEntities.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    stringBuilder.AppendLine("Error Deleting from absDailySuspensions Table");
                    stringBuilder.AppendLine("[ILA.DAL][Repositories][HeaderRepository.cs][CheckSuspensions]");
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
                    stringBuilder.AppendLine("Error Deleting from absDailySuspensions Table");
                    stringBuilder.AppendLine("[ILA.DAL][Repositories][HeaderRepository.cs][CheckSuspensions]");
                    stringBuilder.AppendLine("Exception:");
                    stringBuilder.AppendLine(ex.ToString());
                    throw new Exception(stringBuilder.ToString());
                }
                List<Decimal> suspendeds = ilaEntities.absDailySuspensions.Select<absDailySuspension, Decimal>((Expression<Func<absDailySuspension, Decimal>>)(c => c.CardNumber)).ToList<Decimal>();
                DbSet<InsuredMaster> insuredMasters = ilaEntities.InsuredMasters;
                Expression<Func<InsuredMaster, bool>> predicate2 = (Expression<Func<InsuredMaster, bool>>)(c => c.DailySuspension.HasValue && c.DailySuspension.Value && !suspendeds.Contains(c.CardNo));
                foreach (InsuredMaster insuredMaster in (IEnumerable<InsuredMaster>)insuredMasters.Where<InsuredMaster>(predicate2))
                    insuredMaster.DailySuspension = new bool?(false);
                try
                {
                    ilaEntities.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    stringBuilder.AppendLine("Error relieving daily suspension from InsuredMaster Table");
                    stringBuilder.AppendLine("[ILA.DAL][Repositories][HeaderRepository.cs][CheckSuspensions]");
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
                    stringBuilder.AppendLine("Error relieving daily suspension from InsuredMaster Table");
                    stringBuilder.AppendLine("[ILA.DAL][Repositories][HeaderRepository.cs][CheckSuspensions]");
                    stringBuilder.AppendLine("Exception:");
                    stringBuilder.AppendLine(ex.ToString());
                    throw new Exception(stringBuilder.ToString());
                }
            }
        }
    }
}