
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
    public class AbsCallBackRepository : RepositoryBase<CallBackEntity>, IRepository<CallBackEntity>
    {
        public List<CallBackEntity> GetAll()
        {
            List<CallBackEntity> source = new List<CallBackEntity>();
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                foreach (absCallBack absCallBack in (IEnumerable<absCallBack>)ilaEntities.absCallBacks)
                    source.Add(this.BuildEntity(absCallBack));
            }
            return source.OrderBy<CallBackEntity, DateTime>((Func<CallBackEntity, DateTime>)(b => (DateTime)b.CallBackDateTime)).ToList<CallBackEntity>();
        }

        public List<CallBackEntity> GetAllActive()
        {
            List<CallBackEntity> source = new List<CallBackEntity>();
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                DbSet<absCallBack> absCallBacks = ilaEntities.absCallBacks;
                Expression<Func<absCallBack, bool>> predicate = (Expression<Func<absCallBack, bool>>)(a => a.active);
                foreach (absCallBack CallBack in (IEnumerable<absCallBack>)absCallBacks.Where<absCallBack>(predicate))
                    source.Add(this.BuildEntity(CallBack));
            }
            return source.OrderBy<CallBackEntity, DateTime>((Func<CallBackEntity, DateTime>)(b => (DateTime)b.CallBackDateTime)).ToList<CallBackEntity>();
        }

        public List<CallBackEntity> GetAllActiveByDate(DateTime callBackDate)
        {
            List<CallBackEntity> source = new List<CallBackEntity>();
            DateTime _theDate = callBackDate.Date;
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                DbSet<absCallBack> absCallBacks = ilaEntities.absCallBacks;
                Expression<Func<absCallBack, bool>> predicate = (Expression<Func<absCallBack, bool>>)(a => a.active);
                foreach (absCallBack CallBack in absCallBacks.Where<absCallBack>(predicate).ToList<absCallBack>().Where<absCallBack>((Func<absCallBack, bool>)(a => DateTime.Compare(a.callBackDateTime.Date, _theDate) == 0)).ToList<absCallBack>())
                    source.Add(this.BuildEntity(CallBack));
            }
            return source.OrderBy<CallBackEntity, DateTime>((Func<CallBackEntity, DateTime>)(b => (DateTime)b.CallBackDateTime)).ToList<CallBackEntity>();
        }

        public CallBackEntity Get(string id)
        {
            CallBackEntity callBackEntity = (CallBackEntity)null;
            int ID;
            if (int.TryParse(id, out ID))
            {
                using (ILAEntities ilaEntities = new ILAEntities())
                {
                    absCallBack CallBack = ilaEntities.absCallBacks.Where<absCallBack>((Expression<Func<absCallBack, bool>>)(b => b.id == ID)).FirstOrDefault<absCallBack>();
                    if (CallBack != null)
                        callBackEntity = this.BuildEntity(CallBack);
                }
            }
            return callBackEntity;
        }

        public void Update(CallBackEntity entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int ID;
            if (!int.TryParse(entity.Id, out ID))
                return;
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                absCallBack absCallBack = ilaEntities.absCallBacks.Where<absCallBack>((Expression<Func<absCallBack, bool>>)(b => b.id == ID)).FirstOrDefault<absCallBack>();
                if (absCallBack != null)
                {
                    absCallBack.cardNumberId = Convert.ToDecimal(entity.Member.Id);
                    absCallBack.phoneNumber = entity.Phone.Trim();
                    absCallBack.callBackDateTime = (DateTime)entity.CallBackDateTime;
                    absCallBack.active = entity.Active;
                    if (!string.IsNullOrEmpty(entity.User))
                        absCallBack.UpdateUser = entity.User.ToString();
                    absCallBack.UpdateDateTime = new DateTime?(DateTime.Now);
                    try
                    {
                        ilaEntities.SaveChanges();
                    }
                    catch (DbEntityValidationException ex)
                    {
                        stringBuilder.AppendLine("Error Updating absCallBack Table");
                        stringBuilder.AppendLine("[ILA.DAL][Repositories][AbsCallBackRepository.cs][Update]");
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
                        stringBuilder.AppendLine("Error Updating absCallBack Table");
                        stringBuilder.AppendLine("[ILA.DAL][Repositories][AbsCallBackRepository.cs][Update]");
                        stringBuilder.AppendLine("Exception:");
                        stringBuilder.AppendLine(ex.ToString());
                        throw new Exception(stringBuilder.ToString());
                    }
                }
            }
        }

        public void Add(CallBackEntity entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                absCallBack entity1 = new absCallBack();
                entity1.cardNumberId = Convert.ToDecimal(entity.Member.Id);
                entity1.phoneNumber = entity.Phone.Trim();
                entity1.callBackDateTime = (DateTime)entity.CallBackDateTime;
                entity1.active = entity.Active;
                if (!string.IsNullOrEmpty(entity.User))
                    entity1.AddUser = entity.User.ToString();
                entity1.AddDateTime = new DateTime?(DateTime.Now);
                try
                {
                    ilaEntities.absCallBacks.Add(entity1);
                    ilaEntities.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    stringBuilder.AppendLine("Error Adding record to absCallBack Table");
                    stringBuilder.AppendLine("[ILA.DAL][Repositories][AbsCallBackRepository.cs][Add]");
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
                    stringBuilder.AppendLine("Error Adding record to absCallBack Table");
                    stringBuilder.AppendLine("[ILA.DAL][Repositories][AbsCallBackRepository.cs][Add]");
                    stringBuilder.AppendLine("Exception:");
                    stringBuilder.AppendLine(ex.ToString());
                    throw new Exception(stringBuilder.ToString());
                }
            }
        }

        public void Delete(CallBackEntity entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int ID;
            if (!int.TryParse(entity.Id, out ID))
                return;
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                absCallBack entity1 = ilaEntities.absCallBacks.Where<absCallBack>((Expression<Func<absCallBack, bool>>)(b => b.id == ID)).FirstOrDefault<absCallBack>();
                if (entity1 != null)
                {
                    try
                    {
                        ilaEntities.absCallBacks.Remove(entity1);
                        ilaEntities.SaveChanges();
                    }
                    catch (DbEntityValidationException ex)
                    {
                        stringBuilder.AppendLine("Error Deleting from absCallBack Table");
                        stringBuilder.AppendLine("[ILA.DAL][Repositories][AbsCallBackRepository.cs][Delete]");
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
                        stringBuilder.AppendLine("Error Deleting from absCallBack Table");
                        stringBuilder.AppendLine("[ILA.DAL][Repositories][AbsCallBackRepository.cs][Delete]");
                        stringBuilder.AppendLine("Exception:");
                        stringBuilder.AppendLine(ex.ToString());
                        throw new Exception(stringBuilder.ToString());
                    }
                }
            }
        }

        private CallBackEntity BuildEntity(absCallBack CallBack)
        {
            CallBackEntity callBackEntity1 = new CallBackEntity();
            callBackEntity1.Id = CallBack.id.ToString();
            CallBackEntity callBackEntity2 = callBackEntity1;
            HeaderEntity headerEntity1 = new HeaderEntity();
            headerEntity1.Id = CallBack.cardNumberId.ToString();
            headerEntity1.FirstName = CallBack.InsuredMaster.FirstName;
            headerEntity1.MiddleInitial = CallBack.InsuredMaster.MI;
            headerEntity1.LastName = CallBack.InsuredMaster.LastName;
            headerEntity1.SenClass = CallBack.InsuredMaster.ClassCode;
            headerEntity1.SSN = this.GetSSNLastFour(CallBack.InsuredMaster.SSNo);
            headerEntity1.DisplayName = this.BuildHeaderDisplayName(CallBack.InsuredMaster.FirstName, CallBack.InsuredMaster.LastName);
            HeaderEntity headerEntity2 = headerEntity1;
            callBackEntity2.Member = headerEntity2;
            callBackEntity1.Phone = CallBack.phoneNumber.Trim();
            callBackEntity1.CallBackDateTime = (DateTime)CallBack.callBackDateTime;
            callBackEntity1.Active = CallBack.active;
            return callBackEntity1;
        }

        private string GetSSNLastFour(string SSN)
        {
            return SSN.Length < 4 ? SSN : SSN.Substring(SSN.Length - 4);
        }

        private string BuildHeaderDisplayName(string firstName, string lastName)
        {
            if (firstName.Length < 1)
                firstName += " ";
            return (firstName.Substring(0, 1) + " " + lastName).Replace(", JR.", " JR");
        }
    }
}