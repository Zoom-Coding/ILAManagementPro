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
    public class TimeCardErrorRepository : RepositoryBase<TimeCardErrorEntity>, IRepository<TimeCardErrorEntity>
    {
        public List<TimeCardErrorEntity> GetAll()
        {
            List<TimeCardErrorEntity> timeCardErrorEntityList = new List<TimeCardErrorEntity>();
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                foreach (TimeCardEntryErrorLog cardEntryErrorLog in (IEnumerable<TimeCardEntryErrorLog>)ilaEntities.TimeCardEntryErrorLogs)
                    timeCardErrorEntityList.Add(this.BuildEntity(cardEntryErrorLog));
            }
            return timeCardErrorEntityList;
        }

        public TimeCardErrorEntity Get(string id)
        {
            TimeCardErrorEntity timeCardErrorEntity = (TimeCardErrorEntity)null;
            DateTime ID;
            if (DateTime.TryParse(id, out ID))
            {
                using (ILAEntities ilaEntities = new ILAEntities())
                {
                    TimeCardEntryErrorLog log = ilaEntities.TimeCardEntryErrorLogs.Where<TimeCardEntryErrorLog>((Expression<Func<TimeCardEntryErrorLog, bool>>)(b => b.AddedDate == (DateTime?)ID)).FirstOrDefault<TimeCardEntryErrorLog>();
                    if (log != null)
                        timeCardErrorEntity = this.BuildEntity(log);
                }
            }
            return timeCardErrorEntity;
        }

        public void Update(TimeCardErrorEntity entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Error Updating Time Card Entry Error Log Table");
            stringBuilder.AppendLine("[ILA.DAL][Repositories][TimeCardErrorRepository.cs][Update]");
            stringBuilder.AppendLine("Exception:");
            DateTime ID;
            if (!DateTime.TryParse(entity.Id, out ID))
                return;
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                TimeCardEntryErrorLog cardEntryErrorLog1 = ilaEntities.TimeCardEntryErrorLogs.Where<TimeCardEntryErrorLog>((Expression<Func<TimeCardEntryErrorLog, bool>>)(b => b.AddedDate == (DateTime?)ID)).FirstOrDefault<TimeCardEntryErrorLog>();
                if (cardEntryErrorLog1 != null)
                {
                    cardEntryErrorLog1.Cardno = (Decimal)entity.Cardno;
                    DateTime? nullable1;
                    if (((DateTime?)entity.DateofWork).HasValue)
                    {
                        TimeCardEntryErrorLog cardEntryErrorLog2 = cardEntryErrorLog1;
                        nullable1 = (DateTime?)entity.DateofWork;
                        DateTime? nullable2 = new DateTime?(nullable1.Value);
                        cardEntryErrorLog2.DateofWork = nullable2;
                    }
                    Decimal? nullable3;
                    if (((Decimal?)entity.Header).HasValue)
                    {
                        TimeCardEntryErrorLog cardEntryErrorLog2 = cardEntryErrorLog1;
                        nullable3 = (Decimal?)entity.Header;
                        Decimal? nullable2 = new Decimal?(nullable3.Value);
                        cardEntryErrorLog2.Header = nullable2;
                    }
                    nullable3 = (Decimal?)entity.Company;
                    if (nullable3.HasValue)
                    {
                        TimeCardEntryErrorLog cardEntryErrorLog2 = cardEntryErrorLog1;
                        nullable3 = (Decimal?)entity.Company;
                        Decimal? nullable2 = new Decimal?(nullable3.Value);
                        cardEntryErrorLog2.Company = nullable2;
                    }
                    nullable3 = (Decimal?)entity.OtherHeader;
                    if (nullable3.HasValue)
                    {
                        TimeCardEntryErrorLog cardEntryErrorLog2 = cardEntryErrorLog1;
                        nullable3 = (Decimal?)entity.OtherHeader;
                        Decimal? nullable2 = new Decimal?(nullable3.Value);
                        cardEntryErrorLog2.OtherHeader = nullable2;
                    }
                    nullable1 = (DateTime?)entity.OtherDate;
                    if (nullable1.HasValue)
                    {
                        TimeCardEntryErrorLog cardEntryErrorLog2 = cardEntryErrorLog1;
                        nullable1 = (DateTime?)entity.OtherDate;
                        DateTime? nullable2 = new DateTime?(nullable1.Value);
                        cardEntryErrorLog2.OtherDate = nullable2;
                    }
                    if (entity.MsgNo != null)
                        cardEntryErrorLog1.MsgNo = entity.MsgNo.Trim();
                    if (entity.MsgDetails != null)
                        cardEntryErrorLog1.MsgDetails = entity.MsgDetails.Trim();
                    if (entity.AnsYN != null)
                        cardEntryErrorLog1.AnsYN = entity.AnsYN.Trim();
                    if (entity.Berth != null)
                        cardEntryErrorLog1.Berth = entity.Berth.Trim();
                    if (entity.Vessel != null)
                        cardEntryErrorLog1.Vessel = entity.Vessel.Trim();
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

        public void Add(TimeCardErrorEntity entity)
        {
            StringBuilder stringBuilder1 = new StringBuilder();
            stringBuilder1.AppendLine("Error Adding to Time Card Entry Error Log Table");
            stringBuilder1.AppendLine("[ILA.DAL][Repositories][TimeCardErrorRepository.cs][Add]");
            stringBuilder1.AppendLine("Exception:");
            StringBuilder stringBuilder2 = new StringBuilder();
            StringBuilder stringBuilder3 = new StringBuilder();
            StringBuilder stringBuilder4 = new StringBuilder();
            stringBuilder2.Append("INSERT INTO TimeCardEntryErrorLog(");
            stringBuilder3.Append("AddedDate,Cardno");
            stringBuilder4.Append(" Values('" + DateTime.Now.ToString() + "', '" + (object)(Decimal)entity.Cardno + "'");
            if (((DateTime?)entity.DateofWork).HasValue)
            {
                stringBuilder3.Append(",DateofWork");
                stringBuilder4.Append(", '" + DateTime.Now.ToString() + "'");
            }
            Decimal? nullable;
            if (((Decimal?)entity.Header).HasValue)
            {
                stringBuilder3.Append(",Header");
                StringBuilder stringBuilder5 = stringBuilder4;
                nullable = (Decimal?)entity.Header;
                string str = ", " + nullable.Value.ToString();
                stringBuilder5.Append(str);
            }
            nullable = (Decimal?)entity.Company;
            if (nullable.HasValue)
            {
                stringBuilder3.Append(",Company");
                StringBuilder stringBuilder5 = stringBuilder4;
                nullable = (Decimal?)entity.Company;
                string str = ", " + nullable.Value.ToString();
                stringBuilder5.Append(str);
            }
            nullable = (Decimal?)entity.OtherHeader;
            if (nullable.HasValue)
            {
                stringBuilder3.Append(",OtherHeader");
                StringBuilder stringBuilder5 = stringBuilder4;
                nullable = (Decimal?)entity.OtherHeader;
                string str = ", " + nullable.Value.ToString();
                stringBuilder5.Append(str);
            }
            if (((DateTime?)entity.OtherDate).HasValue)
            {
                stringBuilder3.Append(",OtherDate");
                stringBuilder4.Append(", '" + ((DateTime?)entity.OtherDate).Value.ToString() + "'");
            }
            if (entity.MsgNo != null)
            {
                stringBuilder3.Append(",MsgNo");
                stringBuilder4.Append(", '" + entity.MsgNo.Trim() + "'");
            }
            if (entity.MsgDetails != null)
            {
                stringBuilder3.Append(",MsgDetails");
                stringBuilder4.Append(", '" + entity.MsgDetails.Trim() + "'");
            }
            if (entity.AnsYN != null)
            {
                stringBuilder3.Append(",AnsYN");
                stringBuilder4.Append(", '" + entity.AnsYN.Trim() + "'");
            }
            if (entity.Berth != null)
            {
                stringBuilder3.Append(",Berth");
                stringBuilder4.Append(", '" + entity.Berth.Trim() + "'");
            }
            if (entity.Vessel != null)
            {
                stringBuilder3.Append(",Vessel");
                stringBuilder4.Append(", '" + entity.Vessel.Trim() + "'");
            }
            if (entity.User != null)
            {
                stringBuilder3.Append(",AddedUser");
                stringBuilder4.Append(", '" + entity.User.Trim() + "'");
            }
            stringBuilder3.Append(")");
            stringBuilder4.Append(")");
            stringBuilder2.Append(stringBuilder3.ToString());
            stringBuilder2.Append(stringBuilder4.ToString());
            try
            {
                SQLData.AddTimeCardErrorLog(stringBuilder2.ToString());
            }
            catch (Exception ex)
            {
            }
        }

        public void Delete(TimeCardErrorEntity entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Error Deleting from Time Card Entry Error Log Table");
            stringBuilder.AppendLine("[ILA.DAL][Repositories][TimeCardErrorRepository.cs][Delete]");
            stringBuilder.AppendLine("Exception:");
            DateTime ID;
            if (!DateTime.TryParse(entity.Id, out ID))
                return;
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                TimeCardEntryErrorLog entity1 = ilaEntities.TimeCardEntryErrorLogs.Where<TimeCardEntryErrorLog>((Expression<Func<TimeCardEntryErrorLog, bool>>)(b => b.AddedDate == (DateTime?)ID)).FirstOrDefault<TimeCardEntryErrorLog>();
                if (entity1 != null)
                {
                    try
                    {
                        ilaEntities.TimeCardEntryErrorLogs.Remove(entity1);
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

        private TimeCardErrorEntity BuildEntity(TimeCardEntryErrorLog log)
        {
            TimeCardErrorEntity timeCardErrorEntity1 = new TimeCardErrorEntity();
            timeCardErrorEntity1.Id = log.AddedDate.ToString();
            timeCardErrorEntity1.Cardno = (Decimal)log.Cardno;
            if (log.DateofWork.HasValue)
                timeCardErrorEntity1.DateofWork = (DateTime?)new DateTime?(log.DateofWork.Value);
            Decimal? nullable1 = log.Header;
            if (nullable1.HasValue)
            {
                TimeCardErrorEntity timeCardErrorEntity2 = timeCardErrorEntity1;
                nullable1 = log.Header;
                Decimal? nullable2 = new Decimal?(nullable1.Value);
                timeCardErrorEntity2.Header = (Decimal?)nullable2;
            }
            nullable1 = log.Company;
            if (nullable1.HasValue)
            {
                TimeCardErrorEntity timeCardErrorEntity2 = timeCardErrorEntity1;
                nullable1 = log.Company;
                Decimal? nullable2 = new Decimal?(nullable1.Value);
                timeCardErrorEntity2.Company = (Decimal?)nullable2;
            }
            nullable1 = log.OtherHeader;
            if (nullable1.HasValue)
            {
                TimeCardErrorEntity timeCardErrorEntity2 = timeCardErrorEntity1;
                nullable1 = log.OtherHeader;
                Decimal? nullable2 = new Decimal?(nullable1.Value);
                timeCardErrorEntity2.OtherHeader = (Decimal?)nullable2;
            }
            DateTime? otherDate = log.OtherDate;
            if (otherDate.HasValue)
            {
                TimeCardErrorEntity timeCardErrorEntity2 = timeCardErrorEntity1;
                otherDate = log.OtherDate;
                DateTime? nullable2 = new DateTime?(otherDate.Value);
                timeCardErrorEntity2.OtherDate = (DateTime?)nullable2;
            }
            if (log.MsgNo != null)
                timeCardErrorEntity1.MsgNo = log.MsgNo.Trim();
            if (log.MsgDetails != null)
                timeCardErrorEntity1.MsgDetails = log.MsgDetails.Trim();
            if (log.AnsYN != null)
                timeCardErrorEntity1.AnsYN = log.AnsYN.Trim();
            if (log.Berth != null)
                timeCardErrorEntity1.Berth = log.Berth.Trim();
            if (log.Vessel != null)
                timeCardErrorEntity1.Vessel = log.Vessel.Trim();
            return timeCardErrorEntity1;
        }
    }
}