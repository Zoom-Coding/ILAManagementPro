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
    public class AbsWorkDetailRepository : RepositoryBase<absWorkDetailEntity>, IRepository<absWorkDetailEntity>
    {
        public List<absWorkDetailEntity> GetAll()
        {
            List<absWorkDetailEntity> workDetailEntityList = new List<absWorkDetailEntity>();
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                foreach (absWorkDetail absWorkDetail in (IEnumerable<absWorkDetail>)ilaEntities.absWorkDetails)
                {
                    absWorkDetail h = absWorkDetail;
                    absWorkDetailEntity workDetailEntity = this.BuildEntity(h);
                    if (h.CardNo.HasValue)
                    {
                        InsuredMaster insuredMaster = ilaEntities.InsuredMasters.Where<InsuredMaster>((Expression<Func<InsuredMaster, bool>>)(g => g.CardNo == h.CardNo.Value)).FirstOrDefault<InsuredMaster>();
                        if (insuredMaster != null)
                        {
                            workDetailEntity.FirstName = insuredMaster.FirstName;
                            workDetailEntity.LastName = insuredMaster.LastName;
                        }
                    }
                    workDetailEntityList.Add(workDetailEntity);
                }
            }
            return workDetailEntityList;
        }

        public List<absWorkDetailEntity> GetAllCounts(DateTime Date)
        {
            List<absWorkDetailEntity> workDetailEntityList = new List<absWorkDetailEntity>();
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                DbSet<absWorkDetail> absWorkDetails = ilaEntities.absWorkDetails;
                Expression<Func<absWorkDetail, bool>> predicate = (Expression<Func<absWorkDetail, bool>>)(c => c.absWorkHeader.absWorkScheduleHeader.DateWorked == Date);
                foreach (absWorkDetail absWorkDetail in (IEnumerable<absWorkDetail>)absWorkDetails.Where<absWorkDetail>(predicate))
                {
                    absWorkDetail h = absWorkDetail;
                    absWorkDetailEntity workDetailEntity = this.BuildEntity(h);
                    if (h.CardNo.HasValue)
                    {
                        InsuredMaster insuredMaster = ilaEntities.InsuredMasters.Where<InsuredMaster>((Expression<Func<InsuredMaster, bool>>)(g => g.CardNo == h.CardNo.Value)).FirstOrDefault<InsuredMaster>();
                        if (insuredMaster != null)
                        {
                            workDetailEntity.FirstName = insuredMaster.FirstName;
                            workDetailEntity.LastName = insuredMaster.LastName;
                        }
                    }
                    workDetailEntityList.Add(workDetailEntity);
                }
            }
            return workDetailEntityList;
        }

        public List<absWorkDetailEntity> GetByWorkHeader(string id)
        {
            List<absWorkDetailEntity> workDetailEntityList = new List<absWorkDetailEntity>();
            int WorkHeaderId;
            if (int.TryParse(id, out WorkHeaderId))
            {
                using (ILAEntities ilaEntities = new ILAEntities())
                {
                    DbSet<absWorkDetail> absWorkDetails = ilaEntities.absWorkDetails;
                    Expression<Func<absWorkDetail, bool>> predicate = (Expression<Func<absWorkDetail, bool>>)(h => h.absWorkHeaderId == WorkHeaderId);
                    foreach (absWorkDetail absWorkDetail in (IEnumerable<absWorkDetail>)absWorkDetails.Where<absWorkDetail>(predicate))
                    {
                        absWorkDetail h = absWorkDetail;
                        absWorkDetailEntity workDetailEntity = this.BuildEntity(h);
                        if (h.CardNo.HasValue)
                        {
                            InsuredMaster insuredMaster = ilaEntities.InsuredMasters.Where<InsuredMaster>((Expression<Func<InsuredMaster, bool>>)(g => g.CardNo == h.CardNo.Value)).FirstOrDefault<InsuredMaster>();
                            if (insuredMaster != null)
                            {
                                workDetailEntity.FirstName = insuredMaster.FirstName;
                                workDetailEntity.LastName = insuredMaster.LastName;
                            }
                        }
                        workDetailEntityList.Add(workDetailEntity);
                    }
                }
            }
            return workDetailEntityList;
        }

        public List<absWorkDetailEntity> GetByCardNumber(Decimal cardNumber)
        {
            List<absWorkDetailEntity> workDetailEntityList = new List<absWorkDetailEntity>();
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                DbSet<absWorkDetail> absWorkDetails = ilaEntities.absWorkDetails;
                Expression<Func<absWorkDetail, bool>> predicate = (Expression<Func<absWorkDetail, bool>>)(h => h.CardNo.HasValue && h.CardNo.Value == cardNumber);
                foreach (absWorkDetail absWorkDetail in (IEnumerable<absWorkDetail>)absWorkDetails.Where<absWorkDetail>(predicate))
                {
                    absWorkDetail h = absWorkDetail;
                    absWorkDetailEntity workDetailEntity = this.BuildEntity(h);
                    if (h.CardNo.HasValue)
                    {
                        InsuredMaster insuredMaster = ilaEntities.InsuredMasters.Where<InsuredMaster>((Expression<Func<InsuredMaster, bool>>)(g => g.CardNo == h.CardNo.Value)).FirstOrDefault<InsuredMaster>();
                        if (insuredMaster != null)
                        {
                            workDetailEntity.FirstName = insuredMaster.FirstName;
                            workDetailEntity.LastName = insuredMaster.LastName;
                        }
                    }
                    workDetailEntityList.Add(workDetailEntity);
                }
            }
            return workDetailEntityList;
        }

        public List<absWorkDetailEntity> GetByCardNumberToday(Decimal cardNumber)
        {
            List<absWorkDetailEntity> workDetailEntityList = new List<absWorkDetailEntity>();
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                DateTime dateToCheck = DateTime.Now.AddDays(-3.0);
                DbSet<absWorkDetail> absWorkDetails = ilaEntities.absWorkDetails;
                Expression<Func<absWorkDetail, bool>> predicate = (Expression<Func<absWorkDetail, bool>>)(h => h.CardNo.HasValue && h.CardNo.Value == cardNumber && h.CheckInTime.HasValue && h.CheckInTime >= (DateTime?)dateToCheck);
                foreach (absWorkDetail absWorkDetail in (IEnumerable<absWorkDetail>)absWorkDetails.Where<absWorkDetail>(predicate))
                {
                    absWorkDetail h = absWorkDetail;
                    absWorkDetailEntity workDetailEntity = this.BuildEntity(h);
                    if (h.CardNo.HasValue)
                    {
                        InsuredMaster insuredMaster = ilaEntities.InsuredMasters.Where<InsuredMaster>((Expression<Func<InsuredMaster, bool>>)(g => g.CardNo == h.CardNo.Value)).FirstOrDefault<InsuredMaster>();
                        if (insuredMaster != null)
                        {
                            workDetailEntity.FirstName = insuredMaster.FirstName;
                            workDetailEntity.LastName = insuredMaster.LastName;
                        }
                    }
                    workDetailEntityList.Add(workDetailEntity);
                }
            }
            return workDetailEntityList;
        }

        public List<absWorkDetailEntity> GetCheckedInByDate(DateTime checkinDate)
        {
            List<absWorkDetailEntity> workDetailEntityList = new List<absWorkDetailEntity>();
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                DbSet<absWorkDetail> absWorkDetails = ilaEntities.absWorkDetails;
                Expression<Func<absWorkDetail, bool>> predicate = (Expression<Func<absWorkDetail, bool>>)(c => c.absWorkHeader.absWorkScheduleHeader.DateWorked == checkinDate && c.CheckInTime.HasValue);
                foreach (absWorkDetail absWorkDetail in (IEnumerable<absWorkDetail>)absWorkDetails.Where<absWorkDetail>(predicate))
                {
                    absWorkDetail h = absWorkDetail;
                    absWorkDetailEntity workDetailEntity = this.BuildEntity(h);
                    if (h.CardNo.HasValue)
                    {
                        InsuredMaster insuredMaster = ilaEntities.InsuredMasters.Where<InsuredMaster>((Expression<Func<InsuredMaster, bool>>)(g => g.CardNo == h.CardNo.Value)).FirstOrDefault<InsuredMaster>();
                        if (insuredMaster != null)
                        {
                            workDetailEntity.FirstName = insuredMaster.FirstName;
                            workDetailEntity.LastName = insuredMaster.LastName;
                        }
                    }
                    workDetailEntityList.Add(workDetailEntity);
                }
            }
            return workDetailEntityList;
        }

        public List<AbsVWWorkDetailEntity> GetByHeaderDateCheckIn(
          Decimal header,
          DateTime workDate,
          DateTime checkInTime)
        {
            List<AbsVWWorkDetailEntity> source = new List<AbsVWWorkDetailEntity>();
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                DbSet<absvwWorkDetail> absvwWorkDetails = ilaEntities.absvwWorkDetails;
                Expression<Func<absvwWorkDetail, bool>> predicate = (Expression<Func<absvwWorkDetail, bool>>)(d => d.HeaderHeader == (Decimal?)header && d.ScheduleDateWorked == workDate && d.HeaderCheckInTime == (DateTime?)checkInTime && d.DetailSequence > (int?)0);
                foreach (absvwWorkDetail detail in (IEnumerable<absvwWorkDetail>)absvwWorkDetails.Where<absvwWorkDetail>(predicate))
                    source.Add(this.BuildViewEntity(detail));
            }
            return source.OrderBy<AbsVWWorkDetailEntity, int?>((Func<AbsVWWorkDetailEntity, int?>)(x => (int?)x.Seq)).ToList<AbsVWWorkDetailEntity>();
        }

        public List<AbsVWWorkDetailEntity> GetByCardBetweenDates(
          Decimal cardNumber,
          DateTime fromDate,
          DateTime toDate)
        {
            List<AbsVWWorkDetailEntity> source = new List<AbsVWWorkDetailEntity>();
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                DbSet<absvwWorkDetail> absvwWorkDetails = ilaEntities.absvwWorkDetails;
                Expression<Func<absvwWorkDetail, bool>> predicate = (Expression<Func<absvwWorkDetail, bool>>)(d => (d.DetailCardNumber == (Decimal?)cardNumber || d.HeaderHeader == (Decimal?)cardNumber) && d.ScheduleDateWorked >= fromDate && d.ScheduleDateWorked <= toDate);
                foreach (absvwWorkDetail detail in (IEnumerable<absvwWorkDetail>)absvwWorkDetails.Where<absvwWorkDetail>(predicate))
                    source.Add(this.BuildViewEntity(detail));
            }
            return source.OrderBy<AbsVWWorkDetailEntity, DateTime>((Func<AbsVWWorkDetailEntity, DateTime>)(x => (DateTime)x.DateWorked)).ToList<AbsVWWorkDetailEntity>();
        }

        public List<AbsVWWorkDetailEntity> GetBetweenDates(
          DateTime fromDate,
          DateTime toDate)
        {
            List<AbsVWWorkDetailEntity> source = new List<AbsVWWorkDetailEntity>();
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                DbSet<absvwWorkDetail> absvwWorkDetails = ilaEntities.absvwWorkDetails;
                Expression<Func<absvwWorkDetail, bool>> predicate = (Expression<Func<absvwWorkDetail, bool>>)(d => d.ScheduleDateWorked >= fromDate && d.ScheduleDateWorked <= toDate && d.DetailSequence > (int?)0);
                foreach (absvwWorkDetail detail in (IEnumerable<absvwWorkDetail>)absvwWorkDetails.Where<absvwWorkDetail>(predicate))
                    source.Add(this.BuildViewEntity(detail));
            }
            return source.OrderBy<AbsVWWorkDetailEntity, DateTime>((Func<AbsVWWorkDetailEntity, DateTime>)(x => (DateTime)x.DateWorked)).ToList<AbsVWWorkDetailEntity>();
        }

        public List<AbsVWRecapDaysWorkedEntity> GetRecapDaysWorked(
          DateTime fromDate,
          DateTime toDate)
        {
            List<AbsVWRecapDaysWorkedEntity> daysWorkedEntityList = new List<AbsVWRecapDaysWorkedEntity>();
            List<AbsVWRecapDaysWorkedEntity> source = new List<AbsVWRecapDaysWorkedEntity>();
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                DbSet<absWorkDetail> absWorkDetails = ilaEntities.absWorkDetails;
                Expression<Func<absWorkDetail, bool>> predicate = (Expression<Func<absWorkDetail, bool>>)(c => c.absWorkHeader.absWorkScheduleHeader.DateWorked >= fromDate && c.absWorkHeader.absWorkScheduleHeader.DateWorked <= toDate);
                foreach (absWorkDetail absWorkDetail in (IEnumerable<absWorkDetail>)absWorkDetails.Where<absWorkDetail>(predicate))
                {
                    absWorkDetail d = absWorkDetail;
                    AbsVWRecapDaysWorkedEntity daysWorkedEntity1 = new AbsVWRecapDaysWorkedEntity();
                    AbsVWRecapDaysWorkedEntity daysWorkedEntity2 = daysWorkedEntity1;
                    Decimal? nullable = d.CardNo;
                    Decimal num = nullable.Value;
                    daysWorkedEntity2.CardNo = (Decimal)num;
                    daysWorkedEntity1.FromWorkDate = (DateTime)fromDate;
                    daysWorkedEntity1.ToWorkDate = (DateTime)toDate;
                    InsuredMaster insuredMaster = ilaEntities.InsuredMasters.Where<InsuredMaster>((Expression<Func<InsuredMaster, bool>>)(c => (Decimal?)c.CardNo == d.CardNo)).FirstOrDefault<InsuredMaster>();
                    if (insuredMaster != null)
                    {
                        daysWorkedEntity1.LastName = insuredMaster.LastName == null ? "" : insuredMaster.LastName.Trim();
                        daysWorkedEntity1.FirstName = insuredMaster.FirstName == null ? "" : insuredMaster.FirstName.Trim();
                        daysWorkedEntity1.MI = insuredMaster.MI == null ? "" : insuredMaster.MI.Trim();
                        daysWorkedEntity1.Class = insuredMaster.ClassCode == null ? "" : insuredMaster.ClassCode.Trim();
                        daysWorkedEntity1.Sex = insuredMaster.Sex == null ? "" : insuredMaster.Sex.Trim();
                        if (insuredMaster.PrintLabel.HasValue && insuredMaster.PrintLabel.Value)
                        {
                            daysWorkedEntity1.UnionFlag = "UNION";
                            daysWorkedEntity1.UnionCount = 1;
                            daysWorkedEntity1.NonUnionCount = 0;
                        }
                        else
                        {
                            daysWorkedEntity1.UnionFlag = "NON-UNION";
                            daysWorkedEntity1.UnionCount = 0;
                            daysWorkedEntity1.NonUnionCount = 1;
                        }
                        daysWorkedEntity1.InCount = 1;
                        if (daysWorkedEntity1.Sex == "M")
                        {
                            daysWorkedEntity1.MenCount = 1;
                            daysWorkedEntity1.WomenCount = 0;
                        }
                        else
                        {
                            daysWorkedEntity1.MenCount = 0;
                            daysWorkedEntity1.WomenCount = 1;
                        }
                        nullable = insuredMaster.EthnicOrigin;
                        if (nullable.HasValue)
                        {
                            nullable = insuredMaster.EthnicOrigin;
                            if (nullable.Value == new Decimal(3))
                            {
                                daysWorkedEntity1.BlackCount = 1;
                                daysWorkedEntity1.HispanicCount = 0;
                                daysWorkedEntity1.WhiteCount = 0;
                                daysWorkedEntity1.AsianCount = 0;
                                daysWorkedEntity1.OtherCount = 0;
                            }
                            else
                            {
                                nullable = insuredMaster.EthnicOrigin;
                                if (nullable.Value == new Decimal(5))
                                {
                                    daysWorkedEntity1.BlackCount = 0;
                                    daysWorkedEntity1.HispanicCount = 1;
                                    daysWorkedEntity1.WhiteCount = 0;
                                    daysWorkedEntity1.AsianCount = 0;
                                    daysWorkedEntity1.OtherCount = 0;
                                }
                                else
                                {
                                    nullable = insuredMaster.EthnicOrigin;
                                    if (nullable.Value == new Decimal(1))
                                    {
                                        daysWorkedEntity1.BlackCount = 0;
                                        daysWorkedEntity1.HispanicCount = 0;
                                        daysWorkedEntity1.WhiteCount = 1;
                                        daysWorkedEntity1.AsianCount = 0;
                                        daysWorkedEntity1.OtherCount = 0;
                                    }
                                    else
                                    {
                                        nullable = insuredMaster.EthnicOrigin;
                                        if (nullable.Value == new Decimal(4))
                                        {
                                            daysWorkedEntity1.BlackCount = 0;
                                            daysWorkedEntity1.HispanicCount = 0;
                                            daysWorkedEntity1.WhiteCount = 0;
                                            daysWorkedEntity1.AsianCount = 1;
                                            daysWorkedEntity1.OtherCount = 0;
                                        }
                                        else
                                        {
                                            daysWorkedEntity1.BlackCount = 0;
                                            daysWorkedEntity1.HispanicCount = 0;
                                            daysWorkedEntity1.WhiteCount = 0;
                                            daysWorkedEntity1.AsianCount = 0;
                                            daysWorkedEntity1.OtherCount = 1;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            daysWorkedEntity1.BlackCount = 0;
                            daysWorkedEntity1.HispanicCount = 0;
                            daysWorkedEntity1.WhiteCount = 0;
                            daysWorkedEntity1.AsianCount = 0;
                            daysWorkedEntity1.OtherCount = 1;
                        }
                        source.Add(daysWorkedEntity1);
                    }
                }
            }
            return source.GroupBy(t =>
            {
                var data = new AbsVWRecapDaysWorkedEntity
                {
                    FromWorkDate = (DateTime)t.FromWorkDate,
                    ToWorkDate = (DateTime)t.ToWorkDate,
                    CardNo = (Decimal)t.CardNo,
                    LastName = t.LastName,
                    FirstName = t.FirstName,
                    MI = t.MI,
                    Class = t.Class,
                    Sex = t.Sex,
                    UnionFlag = t.UnionFlag,
                    UnionCount = t.UnionCount,
                    NonUnionCount = t.NonUnionCount,
                    MenCount = t.MenCount,
                    WomenCount = t.WomenCount,
                    BlackCount = t.BlackCount,
                    HispanicCount = t.HispanicCount,
                    WhiteCount = t.WhiteCount,
                    AsianCount = t.AsianCount,
                    OtherCount = t.OtherCount
                };
                return data;
            }).Select<IGrouping<AbsVWRecapDaysWorkedEntity, AbsVWRecapDaysWorkedEntity >, AbsVWRecapDaysWorkedEntity > (g => new AbsVWRecapDaysWorkedEntity()
            {
                FromWorkDate = (DateTime)g.Key.FromWorkDate,
                ToWorkDate = (DateTime)g.Key.ToWorkDate,
                CardNo = (Decimal)g.Key.CardNo,
                LastName = g.Key.LastName,
                FirstName = g.Key.FirstName,
                MI = g.Key.MI,
                Class = g.Key.Class,
                Sex = g.Key.Sex,
                UnionFlag = g.Key.UnionFlag,
                InCount = g.Sum<AbsVWRecapDaysWorkedEntity>((Func<AbsVWRecapDaysWorkedEntity, int>)(i => i.InCount)),
                UnionCount = g.Key.UnionCount,
                NonUnionCount = g.Key.NonUnionCount,
                MenCount = g.Key.MenCount,
                WomenCount = g.Key.WomenCount,
                BlackCount = g.Key.BlackCount,
                HispanicCount = g.Key.HispanicCount,
                WhiteCount = g.Key.WhiteCount,
                AsianCount = g.Key.AsianCount,
                OtherCount = g.Key.OtherCount
            }).ToList<AbsVWRecapDaysWorkedEntity>();
        }

        public absWorkDetailEntity Get(string id)
        {
            absWorkDetailEntity workDetailEntity = (absWorkDetailEntity)null;
            int ID;
            if (int.TryParse(id, out ID))
            {
                using (ILAEntities ilaEntities = new ILAEntities())
                {
                    absWorkDetail detail = ilaEntities.absWorkDetails.Where<absWorkDetail>((Expression<Func<absWorkDetail, bool>>)(h => h.id == ID)).FirstOrDefault<absWorkDetail>();
                    if (detail != null)
                    {
                        workDetailEntity = this.BuildEntity(detail);
                        if (detail.CardNo.HasValue)
                        {
                            InsuredMaster insuredMaster = ilaEntities.InsuredMasters.Where<InsuredMaster>((Expression<Func<InsuredMaster, bool>>)(g => g.CardNo == detail.CardNo.Value)).FirstOrDefault<InsuredMaster>();
                            if (insuredMaster != null)
                            {
                                workDetailEntity.FirstName = insuredMaster.FirstName;
                                workDetailEntity.LastName = insuredMaster.LastName;
                            }
                        }
                    }
                }
            }
            return workDetailEntity;
        }

        public int CheckOutDetailBetweenDates(
          DateTime fromTime,
          DateTime toTime,
          DateTime checkOutTime,
          string checkOut,
          string user)
        {
            int num = 0;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Error Updating absWorkDetail Table");
            stringBuilder.AppendLine("[ILA.DAL][Repositories][AbsWorkDetailRepository.cs][CheckOutDetailBetweenDates]");
            stringBuilder.AppendLine("Exception:");
            List<Decimal> cardNumbers = new List<Decimal>();
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                IQueryable<absWorkDetail> source = ilaEntities.absWorkDetails.Where<absWorkDetail>((Expression<Func<absWorkDetail, bool>>)(c => c.CheckOut == (object)null && c.CheckInTime.HasValue && c.CheckInTime.Value >= fromTime && c.CheckInTime.Value <= toTime));
                foreach (absWorkDetail absWorkDetail in (IEnumerable<absWorkDetail>)source)
                {
                    absWorkDetail.CheckOut = checkOut;
                    absWorkDetail.CheckOutTime = new DateTime?(checkOutTime);
                    absWorkDetail.UpdateUser = user;
                    absWorkDetail.UpdateDateTime = new DateTime?(DateTime.Now);
                    if (absWorkDetail.CardNo.HasValue)
                        cardNumbers.Add(absWorkDetail.CardNo.Value);
                }
                num = source.Count<absWorkDetail>();
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
                stringBuilder.Clear();
                stringBuilder.AppendLine("Error Updating InsuredMaster Table");
                stringBuilder.AppendLine("[ILA.DAL][Repositories][AbsWorkDetailRepository.cs][CheckOutDetailBetweenDates]");
                stringBuilder.AppendLine("Exception:");
                DbSet<InsuredMaster> insuredMasters = ilaEntities.InsuredMasters;
                Expression<Func<InsuredMaster, bool>> predicate = (Expression<Func<InsuredMaster, bool>>)(h => cardNumbers.Contains(h.CardNo));
                foreach (InsuredMaster insuredMaster in (IEnumerable<InsuredMaster>)insuredMasters.Where<InsuredMaster>(predicate))
                {
                    insuredMaster.DateLastWorked = new DateTime?(checkOutTime.Date);
                    insuredMaster.UpdateDate = new DateTime?(DateTime.Now);
                    insuredMaster.UpdateUser = user;
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
            return num;
        }

        public void Update(absWorkDetailEntity entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Error Updating absWorkDetail Table");
            stringBuilder.AppendLine("[ILA.DAL][Repositories][AbsWorkDetailRepository.cs][Update]");
            stringBuilder.AppendLine("Exception:");
            int entityId = Convert.ToInt32(entity.Id);
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                absWorkDetail absWorkDetail1 = ilaEntities.absWorkDetails.Where<absWorkDetail>((Expression<Func<absWorkDetail, bool>>)(h => h.id == entityId)).FirstOrDefault<absWorkDetail>();
                if (absWorkDetail1 == null)
                    return;
                absWorkDetail1.absWorkHeaderId = Convert.ToInt32(entity.Header.Id);
                absWorkDetail1.Seq = !((int?)entity.Seq).HasValue ? new int?() : new int?(((int?)entity.Seq).Value);
                absWorkDetail1.CardNo = !((Decimal?)entity.CardNo).HasValue ? new Decimal?() : new Decimal?(((Decimal?)entity.CardNo).Value);
                absWorkDetail1.CheckIn = entity.CheckIn == null ? (string)null : entity.CheckIn.Trim();
                DateTime? nullable1;
                if (((DateTime?)entity.CheckInTime).HasValue)
                {
                    absWorkDetail absWorkDetail2 = absWorkDetail1;
                    nullable1 = (DateTime?)entity.CheckInTime;
                    DateTime? nullable2 = new DateTime?(nullable1.Value);
                    absWorkDetail2.CheckInTime = nullable2;
                }
                else
                    absWorkDetail1.CheckInTime = new DateTime?();
                absWorkDetail1.CheckOut = entity.CheckOut == null ? (string)null : entity.CheckOut.Trim();
                nullable1 = (DateTime?)entity.CheckOutTime;
                if (nullable1.HasValue)
                {
                    absWorkDetail absWorkDetail2 = absWorkDetail1;
                    nullable1 = (DateTime?)entity.CheckOutTime;
                    DateTime? nullable2 = new DateTime?(nullable1.Value);
                    absWorkDetail2.CheckOutTime = nullable2;
                }
                else
                {
                    absWorkDetail absWorkDetail2 = absWorkDetail1;
                    nullable1 = new DateTime?();
                    DateTime? nullable2 = nullable1;
                    absWorkDetail2.CheckOutTime = nullable2;
                }
                absWorkDetail1.DetlComment = entity.DetailComment == null ? (string)null : entity.DetailComment.Trim();
                absWorkDetail1.UpdateUser = string.IsNullOrEmpty(entity.User) ? (string)null : entity.User;
                if (((bool?)entity.FTPWrite).HasValue)
                    absWorkDetail1.FTPWrite = (bool?)entity.FTPWrite;
                absWorkDetail1.UpdateDateTime = new DateTime?(DateTime.Now);
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

        public void UpdateDateLastWorked(absWorkDetailEntity entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Error Updating InsuredMaster Table");
            stringBuilder.AppendLine("[ILA.DAL][Repositories][AbsWorkDetailRepository.cs][UpdateDateLastWorked]");
            stringBuilder.AppendLine("Exception:");
            Decimal card = new Decimal(0);
            if (!((Decimal?)entity.CardNo).HasValue)
                return;
            card = ((Decimal?)entity.CardNo).Value;
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                InsuredMaster insuredMaster = ilaEntities.InsuredMasters.Where<InsuredMaster>((Expression<Func<InsuredMaster, bool>>)(h => h.CardNo == card)).FirstOrDefault<InsuredMaster>();
                if (insuredMaster != null)
                {
                    insuredMaster.DateLastWorked = new DateTime?(((DateTime?)entity.CheckOutTime).Value.Date);
                    insuredMaster.UpdateUser = string.IsNullOrEmpty(entity.User) ? (string)null : entity.User;
                    insuredMaster.UpdateDate = new DateTime?(DateTime.Now);
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

        public void Add(absWorkDetailEntity entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Error Adding to absWorkDetail Table");
            stringBuilder.AppendLine("[ILA.DAL][Repositories][AbsWorkDetailRepository.cs][Add]");
            stringBuilder.AppendLine("Exception:");
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                absWorkDetail entity1 = new absWorkDetail();
                entity1.absWorkHeaderId = Convert.ToInt32(entity.Header.Id);
                if (((int?)entity.Seq).HasValue)
                    entity1.Seq = new int?(((int?)entity.Seq).Value);
                if (((Decimal?)entity.CardNo).HasValue)
                    entity1.CardNo = new Decimal?(((Decimal?)entity.CardNo).Value);
                if (entity.CheckIn != null)
                    entity1.CheckIn = entity.CheckIn.Trim();
                if (((DateTime?)entity.CheckInTime).HasValue)
                    entity1.CheckInTime = new DateTime?(((DateTime?)entity.CheckInTime).Value);
                if (entity.CheckOut != null)
                    entity1.CheckOut = entity.CheckOut.Trim();
                if (((DateTime?)entity.CheckOutTime).HasValue)
                    entity1.CheckOutTime = new DateTime?(((DateTime?)entity.CheckOutTime).Value);
                if (entity.DetailComment != null)
                    entity1.DetlComment = entity.DetailComment.Trim();
                if (!string.IsNullOrEmpty(entity.User))
                    entity1.AddUser = entity.User;
                if (((bool?)entity.FTPWrite).HasValue)
                    entity1.FTPWrite = (bool?)entity.FTPWrite;
                entity1.AddDateTime = new DateTime?(DateTime.Now);
                try
                {
                    ilaEntities.absWorkDetails.Add(entity1);
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

        public void Delete(absWorkDetailEntity entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Error Deleting from absBerth Table");
            stringBuilder.AppendLine("[ILA.DAL][Repositories][AbsWorkDetailRepository.cs][Delete]");
            stringBuilder.AppendLine("Exception:");
            int entityId = Convert.ToInt32(entity.Id);
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                absWorkDetail entity1 = ilaEntities.absWorkDetails.Where<absWorkDetail>((Expression<Func<absWorkDetail, bool>>)(h => h.id == entityId)).FirstOrDefault<absWorkDetail>();
                if (entity1 == null)
                    return;
                try
                {
                    ilaEntities.absWorkDetails.Remove(entity1);
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

        private absWorkDetailEntity BuildEntity(absWorkDetail detail)
        {
            absWorkDetailEntity workDetailEntity = new absWorkDetailEntity();
            workDetailEntity.Id = detail.id.ToString();
            workDetailEntity.Header = this.GetHeader(detail.absWorkHeader);
            if (detail.Seq.HasValue)
                workDetailEntity.Seq = (int?)new int?(detail.Seq.Value);
            if (detail.CardNo.HasValue)
                workDetailEntity.CardNo = (Decimal?)new Decimal?(detail.CardNo.Value);
            if (detail.CheckIn != null)
                workDetailEntity.CheckIn = detail.CheckIn.Trim();
            if (detail.CheckInTime.HasValue)
                workDetailEntity.CheckInTime = (DateTime?)new DateTime?(detail.CheckInTime.Value);
            if (detail.CheckOut != null)
                workDetailEntity.CheckOut = detail.CheckOut.Trim();
            if (detail.CheckOutTime.HasValue)
                workDetailEntity.CheckOutTime = (DateTime?)new DateTime?(detail.CheckOutTime.Value);
            if (detail.DetlComment != null)
                workDetailEntity.DetailComment = detail.DetlComment.Trim();
            if (detail.FTPWrite.HasValue)
                workDetailEntity.FTPWrite = (bool?)detail.FTPWrite;
            return workDetailEntity;
        }

        private absWorkHeaderEntity GetHeader(absWorkHeader Header)
        {
            absWorkHeaderEntity workHeaderEntity1 = new absWorkHeaderEntity();
            workHeaderEntity1.Id = Header.CounterId.ToString();
            absWorkHeaderEntity workHeaderEntity2 = workHeaderEntity1;
            WorkScheduleHeaderEntity scheduleHeaderEntity1 = new WorkScheduleHeaderEntity();
            scheduleHeaderEntity1.Id = Header.WorkScheduleHeaderId.ToString();
            scheduleHeaderEntity1.DateWorked = (DateTime)Header.absWorkScheduleHeader.DateWorked;
            WorkScheduleHeaderEntity scheduleHeaderEntity2 = scheduleHeaderEntity1;
            CompanyEntity companyEntity1 = new CompanyEntity();
            companyEntity1.Id = Header.absWorkScheduleHeader.CompanyId.ToString();
            companyEntity1.CompanyId = Header.absWorkScheduleHeader.CompanyMaster.CompanyId;
            CompanyEntity companyEntity2 = companyEntity1;
            scheduleHeaderEntity2.Company = companyEntity2;
            WorkScheduleHeaderEntity scheduleHeaderEntity3 = scheduleHeaderEntity1;
            BerthEntity berthEntity1 = new BerthEntity();
            berthEntity1.Id = Header.absWorkScheduleHeader.BerthId.ToString();
            berthEntity1.ShortBerthName = Header.absWorkScheduleHeader.absBerth.BerthShortName;
            BerthEntity berthEntity2 = berthEntity1;
            scheduleHeaderEntity3.Berth = berthEntity2;
            WorkScheduleHeaderEntity scheduleHeaderEntity4 = scheduleHeaderEntity1;
            VesselEntity vesselEntity1 = new VesselEntity();
            vesselEntity1.Id = Header.absWorkScheduleHeader.VesselId.ToString();
            vesselEntity1.VesselName = Header.absWorkScheduleHeader.absVessel.VesselName;
            VesselEntity vesselEntity2 = vesselEntity1;
            scheduleHeaderEntity4.Vessel = vesselEntity2;
            scheduleHeaderEntity1.ShiftTime = (DateTime)Header.absWorkScheduleHeader.ShiftTime;
            scheduleHeaderEntity1.Display = Header.absWorkScheduleHeader.Display;
            scheduleHeaderEntity1.Cancelled = Header.absWorkScheduleHeader.Cancelled;
            WorkScheduleHeaderEntity scheduleHeaderEntity5 = scheduleHeaderEntity1;
            workHeaderEntity2.WorkScheduleHeader = scheduleHeaderEntity5;
            Decimal num;
            if (Header.Header.HasValue)
            {
                absWorkHeaderEntity workHeaderEntity3 = workHeaderEntity1;
                HeaderEntity headerEntity1 = new HeaderEntity();
                HeaderEntity headerEntity2 = headerEntity1;
                num = Header.Header.Value;
                string str = num.ToString();
                headerEntity2.Id = str;
                headerEntity1.FirstName = Header.InsuredMaster.FirstName.Trim();
                headerEntity1.MiddleInitial = Header.InsuredMaster.MI.Trim();
                headerEntity1.LastName = Header.InsuredMaster.LastName.Trim();
                headerEntity1.DisplayName = this.BuildDisplayName(Header.InsuredMaster.FirstName.Trim(), Header.InsuredMaster.LastName.Trim());
                headerEntity1.HeaderMember = this.isHeader(Header.InsuredMaster.HeaderYN);
                HeaderEntity headerEntity3 = headerEntity1;
                workHeaderEntity3.Header = headerEntity3;
            }
            if (!string.IsNullOrEmpty(Header.CheckIn))
                workHeaderEntity1.CheckIn = Header.CheckIn.Trim();
            if (Header.CheckInTime.HasValue)
                workHeaderEntity1.CheckInTime = (DateTime?)new DateTime?(Header.CheckInTime.Value);
            if (!string.IsNullOrEmpty(Header.CheckOut))
                workHeaderEntity1.CheckOut = Header.CheckOut.Trim();
            if (Header.CheckOutTime.HasValue)
                workHeaderEntity1.CheckOutTime = (DateTime?)new DateTime?(Header.CheckOutTime.Value);
            if (!string.IsNullOrEmpty(Header.Description))
                workHeaderEntity1.workDescription = Header.Description.Trim();
            if (!string.IsNullOrEmpty(Header.Comment))
                workHeaderEntity1.Comment = Header.Comment.Trim();
            if (Header.WorkGangDescriptionId.HasValue)
                workHeaderEntity1.GangDescription = new AbsWorkGangDescriptionRepository().Get(Header.WorkGangDescriptionId.Value.ToString());
            if (Header.ReplaceHeaderId.HasValue)
            {
                absWorkHeaderEntity workHeaderEntity3 = workHeaderEntity1;
                HeaderEntity headerEntity1 = new HeaderEntity();
                HeaderEntity headerEntity2 = headerEntity1;
                num = Header.ReplaceHeaderId.Value;
                string str = num.ToString();
                headerEntity2.Id = str;
                headerEntity1.FirstName = Header.InsuredMaster1.FirstName.Trim();
                headerEntity1.MiddleInitial = Header.InsuredMaster1.MI.Trim();
                headerEntity1.LastName = Header.InsuredMaster1.LastName.Trim();
                headerEntity1.DisplayName = this.BuildDisplayName(Header.InsuredMaster1.FirstName.Trim(), Header.InsuredMaster1.LastName.Trim());
                headerEntity1.HeaderMember = this.isHeader(Header.InsuredMaster1.HeaderYN);
                HeaderEntity headerEntity3 = headerEntity1;
                workHeaderEntity3.ReplaceHeader = headerEntity3;
            }
            return workHeaderEntity1;
        }

        private string BuildDisplayName(string firstName, string lastName)
        {
            if (firstName.Length < 1)
                firstName += " ";
            return (firstName.Substring(0, 1) + " " + lastName).Replace(", JR.", " JR");
        }

        private bool isHeader(bool? value)
        {
            bool flag = false;
            if (value.HasValue)
                flag = value.Value;
            return flag;
        }

        private AbsVWWorkDetailEntity BuildViewEntity(absvwWorkDetail detail)
        {
            AbsVWWorkDetailEntity workDetailEntity = new AbsVWWorkDetailEntity();
            workDetailEntity.Id = detail.WorkDetailId.ToString();
            workDetailEntity.DateWorked = (DateTime)detail.ScheduleDateWorked;
            workDetailEntity.Company = detail.ScheduleCompany;
            workDetailEntity.CompanyName = detail.ScheduleCompanyName;
            workDetailEntity.Berth = detail.ScheduleBerth;
            workDetailEntity.Vessel = detail.ScheduleVessel;
            workDetailEntity.ScheduleShiftTime = (DateTime)detail.ScheduleShiftTime;
            workDetailEntity.ScheduleDisplay = detail.ScheduleDisplay;
            workDetailEntity.ScheduleCancelled = detail.ScheduleCancelled;
            workDetailEntity.ScheduleBerthQuestion = detail.ScheduleBerthQuestion;
            workDetailEntity.Header = (Decimal?)detail.HeaderHeader;
            workDetailEntity.HeaderName = detail.HeaderHeaderName;
            workDetailEntity.HdrCheckIn = detail.HeaderCheckIn;
            workDetailEntity.HdrCheckinTime = (DateTime?)detail.HeaderCheckInTime;
            workDetailEntity.HdrCheckOut = detail.HeaderCheckOut;
            workDetailEntity.HdrCheckOutTime = (DateTime?)detail.HeaderCheckOutTime;
            workDetailEntity.HeaderDescription = detail.HeaderDescription;
            workDetailEntity.HeaderComment = detail.HeaderComment;
            workDetailEntity.HeaderWorkGangDescription = detail.HeaderWorkGangDescription;
            workDetailEntity.Seq = (int?)detail.DetailSequence;
            workDetailEntity.CardNo = (Decimal?)detail.DetailCardNumber;
            workDetailEntity.DetlName = detail.DetailMemberName;
            workDetailEntity.CheckIn = detail.DetailCheckIn;
            workDetailEntity.DtlCheckInTimeShow = (DateTime?)detail.DetailCheckInTime;
            workDetailEntity.CheckOut = detail.DetailCheckOut;
            workDetailEntity.DtlCheckOutTimeShow = (DateTime?)detail.DetailCheckOutTime;
            workDetailEntity.DetlComment = detail.DetailComment;
            workDetailEntity.ScheduleAddUser = detail.ScheduleAddUser;
            workDetailEntity.ScheduleAddDateTime = (DateTime?)detail.ScheduleAddDateTime;
            workDetailEntity.ScheduleUpdateUser = detail.ScheduleUpdateUser;
            workDetailEntity.ScheduleUpdateDateTime = (DateTime?)detail.ScheduleUpdateDateTime;
            workDetailEntity.HeaderAddedDate = (DateTime?)detail.HeaderAddedDate;
            workDetailEntity.HeaderAddedUser = detail.HeaderAddedUser;
            workDetailEntity.HeaderUpdateDate = (DateTime?)detail.HeaderUpdateDate;
            workDetailEntity.HeaderUpdateUser = detail.HeaderUpdateUser;
            workDetailEntity.DetailAddUser = detail.DetailAddUser;
            workDetailEntity.DetailAddDateTime = (DateTime?)detail.DetailAddDateTime;
            workDetailEntity.DetailUpdateUser = detail.DetailUpdateUser;
            workDetailEntity.DetailUpdateDateTime = (DateTime?)detail.DetailUpdateDateTime;
            workDetailEntity.DateOfWork = (DateTime)detail.ScheduleDateWorked;
            workDetailEntity.HdrCheckInTimeShow = (DateTime?)detail.HeaderCheckInTime;
            workDetailEntity.HdrCheckOutTimeShow = (DateTime?)detail.HeaderCheckOutTime;
            workDetailEntity.DetlCheckInTime = (DateTime?)detail.DetailCheckInTime;
            workDetailEntity.DtlCheckOutTime = (DateTime?)detail.DetailCheckOutTime;
            workDetailEntity.DetlCheckOutTime = (DateTime?)detail.DetailCheckOutTime;
            workDetailEntity.CardName = detail.DetailMemberName;
            workDetailEntity.CardCheckInTimeShow = (DateTime?)detail.DetailCheckInTime;
            workDetailEntity.CardCheckOut = detail.DetailCheckOut;
            workDetailEntity.CardCheckOutTimeShow = (DateTime?)detail.DetailCheckOutTime;
            workDetailEntity.RecNo = detail.WorkDetailId;
            workDetailEntity.Comment = detail.DetailComment;
            return workDetailEntity;
        }
    }
}