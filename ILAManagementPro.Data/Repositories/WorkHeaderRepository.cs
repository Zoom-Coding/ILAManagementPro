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
using WorkHeaderEntity = ILAManagementPro.Models.WorkHeaderEntity;
using DbWorkHeader = ILAManagementPro.Data.Data.WorkHeader;
using WorkDetailEntity = ILAManagementPro.Models.WorkDetailEntity;
using DbWorkDetail = ILAManagementPro.Data.Data.WorkDetail;

namespace ILAManagementPro.Data.Repositories
{
    public class WorkHeaderRepository : RepositoryBase<WorkHeaderEntity>, IRepository<WorkHeaderEntity>
    {
        public List<WorkHeaderEntity> GetAll()
        {
            List<WorkHeaderEntity> source = new List<WorkHeaderEntity>();
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                foreach (DbWorkHeader workHeader in (IEnumerable<DbWorkHeader>)ilaEntities.WorkHeaders)
                {
                    DbWorkHeader v = workHeader;
                    WorkHeaderEntity tempHeader = this.BuildHeaderEntity(v);
                    if (v.Company.HasValue)
                    {
                        CompanyMaster company = ilaEntities.CompanyMasters.Where<CompanyMaster>((Expression<Func<CompanyMaster, bool>>)(c => c.CoNo == v.Company.Value)).FirstOrDefault<CompanyMaster>();
                        if (company != null)
                            tempHeader.Company = this.BuildCompanyEntity(company);
                    }
                    tempHeader.WorkDetails = new List<WorkDetailEntity>();
                    DbSet<DbWorkDetail> workDetails = ilaEntities.WorkDetails;
                    Expression<Func<DbWorkDetail, bool>> predicate = (Expression<Func<DbWorkDetail, bool>>)(c => c.DateOfWork == tempHeader.DateWorked && c.Header == v.Header);
                    foreach (DbWorkDetail wd in (IEnumerable<DbWorkDetail>)workDetails.Where<DbWorkDetail>(predicate))
                        ((List<WorkDetailEntity>)tempHeader.WorkDetails).Add(this.BuildDetailEntity(wd));
                    source.Add(tempHeader);
                }
            }
            return source.OrderBy<WorkHeaderEntity, string>((Func<WorkHeaderEntity, string>)(b => b.Header)).ToList<WorkHeaderEntity>();
        }

        public List<WorkHeaderEntity> GetAllByDateWorked(DateTime dateWorked)
        {
            List<WorkHeaderEntity> source = new List<WorkHeaderEntity>();
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                DbSet<DbWorkHeader> workHeaders = ilaEntities.WorkHeaders;
                Expression<Func<DbWorkHeader, bool>> predicate1 = (Expression<Func<DbWorkHeader, bool>>)(c => c.DateWorked == (DateTime?)dateWorked);
                foreach (DbWorkHeader workHeader in (IEnumerable<DbWorkHeader>)workHeaders.Where<DbWorkHeader>(predicate1))
                {
                    DbWorkHeader v = workHeader;
                    WorkHeaderEntity tempHeader = this.BuildHeaderEntity(v);
                    if (v.Company.HasValue)
                    {
                        CompanyMaster company = ilaEntities.CompanyMasters.Where<CompanyMaster>((Expression<Func<CompanyMaster, bool>>)(c => c.CoNo == v.Company.Value)).FirstOrDefault<CompanyMaster>();
                        if (company != null)
                            tempHeader.Company = this.BuildCompanyEntity(company);
                    }
                    tempHeader.WorkDetails = (List<WorkDetailEntity>)new List<WorkDetailEntity>();
                    DbSet<DbWorkDetail> workDetails = ilaEntities.WorkDetails;
                    Expression<Func<DbWorkDetail, bool>> predicate2 = (Expression<Func<DbWorkDetail, bool>>)(c => c.DateOfWork == tempHeader.DateWorked && c.Header == v.Header);
                    foreach (DbWorkDetail wd in (IEnumerable<DbWorkDetail>)workDetails.Where<DbWorkDetail>(predicate2))
                        ((List<WorkDetailEntity>)tempHeader.WorkDetails).Add(this.BuildDetailEntity(wd));
                    source.Add(tempHeader);
                }
            }
            return source.OrderBy<WorkHeaderEntity, string>((Func<WorkHeaderEntity, string>)(b => b.Header)).ToList<WorkHeaderEntity>();
        }

        public WorkHeaderEntity Get(string id)
        {
            WorkHeaderEntity ret = (WorkHeaderEntity)null;
            int ID;
            if (int.TryParse(id, out ID))
            {
                using (ILAEntities ilaEntities = new ILAEntities())
                {
                    DbWorkHeader workHeader = ilaEntities.WorkHeaders.Where<DbWorkHeader>((Expression<Func<DbWorkHeader, bool>>)(b => b.CounterId == ID)).FirstOrDefault<DbWorkHeader>();
                    if (workHeader != null)
                    {
                        ret = this.BuildHeaderEntity(workHeader);
                        if (workHeader.Company.HasValue)
                        {
                            CompanyMaster company = ilaEntities.CompanyMasters.Where<CompanyMaster>((Expression<Func<CompanyMaster, bool>>)(c => c.CoNo == workHeader.Company.Value)).FirstOrDefault<CompanyMaster>();
                            if (company != null)
                                ret.Company = this.BuildCompanyEntity(company);
                        }
                        ret.WorkDetails = (List<WorkDetailEntity>)new List<WorkDetailEntity>();
                        DbSet<DbWorkDetail> workDetails = ilaEntities.WorkDetails;
                        Expression<Func<DbWorkDetail, bool>> predicate = (Expression<Func<DbWorkDetail, bool>>)(c => c.DateOfWork == ret.DateWorked && c.Header == workHeader.Header);
                        foreach (DbWorkDetail workDetail in (IEnumerable<DbWorkDetail>)workDetails.Where<DbWorkDetail>(predicate))
                            ((List<WorkDetailEntity>)ret.WorkDetails).Add(this.BuildDetailEntity(workDetail));
                    }
                }
            }
            return ret;
        }

        public void Update(WorkHeaderEntity entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Error Updating WorkHeader Table");
            stringBuilder.AppendLine("[ILA.DAL][Repositories][WorkHeaderRepository.cs][Update]");
            stringBuilder.AppendLine("Exception:");
            int ID;
            if (!int.TryParse(entity.Id, out ID))
                return;
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                DbWorkHeader workHeader = ilaEntities.WorkHeaders.Where<DbWorkHeader>((Expression<Func<DbWorkHeader, bool>>)(b => b.CounterId == ID)).FirstOrDefault<DbWorkHeader>();
                if (workHeader != null)
                {
                    DateTime? nullable1 = (DateTime?)entity.DateWorked;
                    if (nullable1.HasValue)
                    {
                        DbWorkHeader workHeader1 = workHeader;
                        nullable1 = (DateTime?)entity.DateWorked;
                        DateTime? nullable2 = new DateTime?(nullable1.Value);
                        workHeader1.DateWorked = nullable2;
                    }
                    else
                    {
                        DbWorkHeader workHeader1 = workHeader;
                        nullable1 = new DateTime?();
                        DateTime? nullable2 = nullable1;
                        workHeader1.DateWorked = nullable2;
                    }
                    workHeader.Header = entity.Header == null ? new Decimal?() : new Decimal?(Convert.ToDecimal(entity.Header));
                    workHeader.Company = entity.Company == null ? new Decimal?() : new Decimal?((Decimal)Convert.ToInt32(entity.Company.Id));
                    workHeader.Berth = entity.Berth == null ? (string)null : entity.Berth.Trim();
                    workHeader.Vessel = entity.Vessel == null ? (string)null : entity.Vessel.Trim();
                    workHeader.CheckIn = entity.CheckIn == null ? (string)null : entity.CheckIn.Trim();
                    nullable1 = (DateTime?)entity.CheckInTime;
                    if (nullable1.HasValue)
                    {
                        DbWorkHeader workHeader1 = workHeader;
                        nullable1 = (DateTime?)entity.CheckInTime;
                        DateTime? nullable2 = new DateTime?(nullable1.Value);
                        workHeader1.CheckInTime = nullable2;
                    }
                    else
                    {
                        DbWorkHeader workHeader1 = workHeader;
                        nullable1 = new DateTime?();
                        DateTime? nullable2 = nullable1;
                        workHeader1.CheckInTime = nullable2;
                    }
                    workHeader.CheckOut = entity.CheckOut == null ? (string)null : entity.CheckOut.Trim();
                    nullable1 = (DateTime?)entity.CheckOutTime;
                    if (nullable1.HasValue)
                    {
                        DbWorkHeader workHeader1 = workHeader;
                        nullable1 = (DateTime?)entity.CheckOutTime;
                        DateTime? nullable2 = new DateTime?(nullable1.Value);
                        workHeader1.CheckOutTime = nullable2;
                    }
                    else
                    {
                        DbWorkHeader workHeader1 = workHeader;
                        nullable1 = new DateTime?();
                        DateTime? nullable2 = nullable1;
                        workHeader1.CheckOutTime = nullable2;
                    }
                    workHeader.Description = entity.Description == null ? (string)null : entity.Description.Trim();
                    workHeader.Comment = entity.Comment == null ? (string)null : entity.Comment.Trim();
                    workHeader.UpdateUser = entity.User == null ? (string)null : entity.User.Trim();
                    workHeader.UpdateDate = new DateTime?(DateTime.Now);
                    try
                    {
                        ilaEntities.SaveChanges();
                        DbSet<DbWorkDetail> workDetails = ilaEntities.WorkDetails;
                        Expression<Func<DbWorkDetail, bool>> predicate = (Expression<Func<DbWorkDetail, bool>>)(c => c.DateOfWork == entity.DateWorked && c.Header == workHeader.Header);
                        foreach (DbWorkDetail entity1 in workDetails.Where<DbWorkDetail>(predicate).ToList<DbWorkDetail>())
                        {
                            ilaEntities.WorkDetails.Remove(entity1);
                            ilaEntities.SaveChanges();
                            foreach (DbWorkDetail buildWorkDetail in this.BuildWorkDetails((List<WorkDetailEntity>)entity.WorkDetails))
                            {
                                ilaEntities.WorkDetails.Add(buildWorkDetail);
                                ilaEntities.SaveChanges();
                            }
                        }
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

        public void Add(WorkHeaderEntity entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                DbWorkHeader entity1 = new DbWorkHeader();
                DateTime? nullable1;
                if (((DateTime?)entity.DateWorked).HasValue)
                {
                    DbWorkHeader workHeader = entity1;
                    nullable1 = (DateTime?)entity.DateWorked;
                    DateTime? nullable2 = new DateTime?(nullable1.Value);
                    workHeader.DateWorked = nullable2;
                }
                if (entity.Header != null)
                    entity1.Header = new Decimal?(Convert.ToDecimal(entity.Header));
                if (entity.Company != null)
                    entity1.Company = new Decimal?((Decimal)Convert.ToInt32(entity.Company.Id));
                if (entity.Berth != null)
                    entity1.Berth = entity.Berth.Trim();
                if (entity.Vessel != null)
                    entity1.Vessel = entity.Vessel.Trim();
                if (entity.CheckIn != null)
                    entity1.CheckIn = entity.CheckIn.Trim();
                nullable1 = (DateTime?)entity.CheckInTime;
                if (nullable1.HasValue)
                {
                    DbWorkHeader workHeader = entity1;
                    nullable1 = (DateTime?)entity.CheckInTime;
                    DateTime? nullable2 = new DateTime?(nullable1.Value);
                    workHeader.CheckInTime = nullable2;
                }
                if (entity.CheckOut != null)
                    entity1.CheckOut = entity.CheckOut.Trim();
                nullable1 = (DateTime?)entity.CheckOutTime;
                if (nullable1.HasValue)
                {
                    DbWorkHeader workHeader = entity1;
                    nullable1 = (DateTime?)entity.CheckOutTime;
                    DateTime? nullable2 = new DateTime?(nullable1.Value);
                    workHeader.CheckOutTime = nullable2;
                }
                if (entity.Description != null)
                    entity1.Description = entity.Description.Trim();
                if (entity.Comment != null)
                    entity1.Comment = entity.Comment.Trim();
                if (entity.User != null)
                    entity1.AddedUser = entity.User.Trim();
                entity1.AddedDate = new DateTime?(DateTime.Now);
                try
                {
                    ilaEntities.WorkHeaders.Add(entity1);
                    ilaEntities.SaveChanges();
                    foreach (DbWorkDetail buildWorkDetail in this.BuildWorkDetails((List<WorkDetailEntity>)entity.WorkDetails))
                    {
                        ilaEntities.WorkDetails.Add(buildWorkDetail);
                        ilaEntities.SaveChanges();
                    }
                }
                catch (DbEntityValidationException ex)
                {
                    stringBuilder.AppendLine("Error Adding record " + entity.Header.Trim() + " to WorkHeader Table");
                    stringBuilder.AppendLine("[ILA.DAL][Repositories][WorkHeaderRepository.cs][Add]");
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
                    stringBuilder.AppendLine("Error Adding record " + entity.Header.Trim() + " to WorkHeader Table");
                    stringBuilder.AppendLine("[ILA.DAL][Repositories][WorkHeaderRepository.cs][Add]");
                    stringBuilder.AppendLine("Exception:");
                    stringBuilder.AppendLine(ex.ToString());
                    throw new Exception(stringBuilder.ToString());
                }
            }
        }

        public void Delete(WorkHeaderEntity entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Error Deleting " + entity.Header.Trim() + " from WorkHeader Table");
            stringBuilder.AppendLine("[ILA.DAL][Repositories][WorkHeaderRepository.cs][Delete]");
            stringBuilder.AppendLine("Exception:");
            int ID;
            if (!int.TryParse(entity.Id, out ID))
                return;
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                DbWorkHeader entity1 = ilaEntities.WorkHeaders.Where<DbWorkHeader>((Expression<Func<DbWorkHeader, bool>>)(b => b.CounterId == ID)).FirstOrDefault<DbWorkHeader>();
                if (entity1 != null)
                {
                    try
                    {
                        ilaEntities.WorkHeaders.Remove(entity1);
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

        private WorkHeaderEntity BuildHeaderEntity(DbWorkHeader workHeader)
        {
            WorkHeaderEntity workHeaderEntity1 = new WorkHeaderEntity();
            workHeaderEntity1.Id = workHeader.CounterId.ToString();
            if (workHeader.DateWorked.HasValue)
                workHeaderEntity1.DateWorked = (DateTime?)new DateTime?(workHeader.DateWorked.Value);
            if (workHeader.Header.HasValue)
                workHeaderEntity1.Header = workHeader.Header.Value.ToString();
            if (workHeader.Company.HasValue)
            {
                WorkHeaderEntity workHeaderEntity2 = workHeaderEntity1;
                CompanyEntity companyEntity1 = new CompanyEntity();
                companyEntity1.Id = workHeader.Company.Value.ToString();
                CompanyEntity companyEntity2 = companyEntity1;
                workHeaderEntity2.Company = companyEntity2;
            }
            if (workHeader.Berth != null)
                workHeaderEntity1.Berth = workHeader.Berth.Trim();
            if (workHeader.Vessel != null)
                workHeaderEntity1.Vessel = workHeader.Vessel.Trim();
            if (!string.IsNullOrEmpty(workHeader.CheckIn))
                workHeaderEntity1.CheckIn = workHeader.CheckIn.Trim();
            if (workHeader.CheckInTime.HasValue)
                workHeaderEntity1.CheckInTime = (DateTime?)new DateTime?(workHeader.CheckInTime.Value);
            if (!string.IsNullOrEmpty(workHeader.CheckOut))
                workHeaderEntity1.CheckOut = workHeader.CheckOut.Trim();
            if (workHeader.CheckOutTime.HasValue)
                workHeaderEntity1.CheckOutTime = (DateTime?)new DateTime?(workHeader.CheckOutTime.Value);
            if (workHeader.Description != null)
                workHeaderEntity1.Description = workHeader.Description.Trim();
            if (workHeader.Comment != null)
                workHeaderEntity1.Comment = workHeader.Comment.Trim();
            return workHeaderEntity1;
        }

        private WorkDetailEntity BuildDetailEntity(DbWorkDetail workDetail)
        {
            WorkDetailEntity workDetailEntity = new WorkDetailEntity();
            workDetailEntity.Id = workDetail.DetlCounter.ToString();
            if (workDetail.DateOfWork.HasValue)
                workDetailEntity.DateOfWork = (DateTime?)new DateTime?(workDetail.DateOfWork.Value);
            if (workDetail.Header.HasValue)
                workDetailEntity.Header = workDetail.Header.Value.ToString();
            if (workDetail.Seq.HasValue)
                workDetailEntity.Seq = (int?)new int?(workDetail.Seq.Value);
            if (workDetail.CardNo.HasValue)
                workDetailEntity.CardNo = (Decimal?)new Decimal?(workDetail.CardNo.Value);
            if (!string.IsNullOrEmpty(workDetail.CheckIn))
                workDetailEntity.CheckIn = workDetail.CheckIn.Trim();
            if (workDetail.CheckInTime.HasValue)
                workDetailEntity.CheckInTime = (DateTime?)new DateTime?(workDetail.CheckInTime.Value);
            if (!string.IsNullOrEmpty(workDetail.CheckOut))
                workDetailEntity.CheckOut = workDetail.CheckOut.Trim();
            if (workDetail.CheckOutTime.HasValue)
                workDetailEntity.CheckOutTime = (DateTime?)new DateTime?(workDetail.CheckOutTime.Value);
            if (workDetail.DetlComment != null)
                workDetailEntity.DetailComment = workDetail.DetlComment.Trim();
            return workDetailEntity;
        }

        private CompanyEntity BuildCompanyEntity(CompanyMaster company)
        {
            CompanyEntity companyEntity = new CompanyEntity();
            companyEntity.Id = company.CoNo.ToString();
            if (!string.IsNullOrWhiteSpace(company.CompanyId))
                companyEntity.CompanyId = company.CompanyId.Trim();
            if (!string.IsNullOrWhiteSpace(company.CompanyName))
                companyEntity.CompanyName = company.CompanyName.Trim();
            if (!string.IsNullOrWhiteSpace(company.CoSymbol))
                companyEntity.CompanySymbol = company.CoSymbol.Trim();
            if (!string.IsNullOrWhiteSpace(company.CompanyCode))
                companyEntity.CompanyCode = company.CompanyCode.Trim();
            companyEntity.Active = company.Active;
            if (!string.IsNullOrWhiteSpace(company.FileName))
                companyEntity.FileName = company.FileName.Trim();
            if (company.CoImport.HasValue)
                companyEntity.CoImport = (Decimal?)new Decimal?(company.CoImport.Value);
            if (company.HasNotes.HasValue)
                companyEntity.HasNotes = (bool?)new bool?(company.HasNotes.Value);
            return companyEntity;
        }

        private List<DbWorkDetail> BuildWorkDetails(List<WorkDetailEntity> list)
        {
            List<DbWorkDetail> workDetailList = new List<DbWorkDetail>();
            foreach (WorkDetailEntity workDetailEntity in list)
            {
                DbWorkDetail workDetail1 = new DbWorkDetail();
                DateTime? nullable1 = (DateTime?)workDetailEntity.DateOfWork;
                if (nullable1.HasValue)
                {
                    DbWorkDetail workDetail2 = workDetail1;
                    nullable1 = (DateTime?)workDetailEntity.DateOfWork;
                    DateTime? nullable2 = new DateTime?(nullable1.Value);
                    workDetail2.DateOfWork = nullable2;
                }
                if (workDetailEntity.Header != null)
                    workDetail1.Header = new Decimal?(Convert.ToDecimal(workDetailEntity.Header));
                int? seq = (int?)workDetailEntity.Seq;
                if (seq.HasValue)
                {
                    DbWorkDetail workDetail2 = workDetail1;
                    seq = (int?)workDetailEntity.Seq;
                    int? nullable2 = new int?(seq.Value);
                    workDetail2.Seq = nullable2;
                }
                Decimal? cardNo = (Decimal?)workDetailEntity.CardNo;
                if (cardNo.HasValue)
                {
                    DbWorkDetail workDetail2 = workDetail1;
                    cardNo = (Decimal?)workDetailEntity.CardNo;
                    Decimal? nullable2 = new Decimal?(cardNo.Value);
                    workDetail2.CardNo = nullable2;
                }
                if (workDetailEntity.CheckIn != null)
                    workDetail1.CheckIn = workDetailEntity.CheckIn.Trim();
                nullable1 = (DateTime?)workDetailEntity.CheckInTime;
                if (nullable1.HasValue)
                {
                    DbWorkDetail workDetail2 = workDetail1;
                    nullable1 = (DateTime?)workDetailEntity.CheckInTime;
                    DateTime? nullable2 = new DateTime?(nullable1.Value);
                    workDetail2.CheckInTime = nullable2;
                }
                if (workDetailEntity.CheckOut != null)
                    workDetail1.CheckOut = workDetailEntity.CheckOut.Trim();
                nullable1 = (DateTime?)workDetailEntity.CheckOutTime;
                if (nullable1.HasValue)
                {
                    DbWorkDetail workDetail2 = workDetail1;
                    nullable1 = (DateTime?)workDetailEntity.CheckOutTime;
                    DateTime? nullable2 = new DateTime?(nullable1.Value);
                    workDetail2.CheckOutTime = nullable2;
                }
                if (workDetailEntity.DetailComment != null)
                    workDetail1.DetlComment = workDetailEntity.DetailComment.Trim();
                if (workDetailEntity.User != null)
                    workDetail1.AddedUser = workDetailEntity.User.Trim();
                workDetail1.AddedDate = new DateTime?(DateTime.Now);
                workDetailList.Add(workDetail1);
            }
            return workDetailList;
        }
    }
}