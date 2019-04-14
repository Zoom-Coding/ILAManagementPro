using ILAManagementPro.Data.Data;
using ILAManagementPro.Data.Interfaces;
using ILAManagementPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using InsuredMasterEntity = ILAManagementPro.Models.InsuredMasterEntity;
using System.Linq.Expressions;

namespace ILAManagementPro.Data.Repositories
{
    public class InsuredMasterRepository : RepositoryBase<InsuredMasterEntity>, IRepository<InsuredMasterEntity>
    {
        public List<InsuredMasterEntity> GetAll()
        {
            List<InsuredMasterEntity> source = new List<InsuredMasterEntity>();
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                foreach (InsuredMaster insuredMaster in (IEnumerable<InsuredMaster>)ilaEntities.InsuredMasters)
                    source.Add(this.BuildEntity(insuredMaster));
            }
            return source.OrderBy<InsuredMasterEntity, string>((Func<InsuredMasterEntity, string>)(h => h.Id)).ToList<InsuredMasterEntity>();
        }

        public List<InsuredMasterDetailEntity> GetAllIM()
        {
            List<InsuredMasterDetailEntity> masterDetailEntityList = new List<InsuredMasterDetailEntity>();
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                foreach (InsuredMaster insuredMaster in (IEnumerable<InsuredMaster>)ilaEntities.InsuredMasters)
                    masterDetailEntityList.Add(this.BuildDetailEntity(insuredMaster));
            }
            return masterDetailEntityList;
        }

        public InsuredMasterEntity Get(string id)
        {
            InsuredMasterEntity insuredMasterEntity = (InsuredMasterEntity)null;
            Decimal idNumber;
            if (Decimal.TryParse(id, out idNumber))
            {
                using (ILAEntities ilaEntities = new ILAEntities())
                {
                    InsuredMaster member = ilaEntities.InsuredMasters.Where<InsuredMaster>((Expression<Func<InsuredMaster, bool>>)(m => m.CardNo == idNumber)).FirstOrDefault<InsuredMaster>();
                    if (member != null)
                        insuredMasterEntity = this.BuildEntity(member);
                }
            }
            return insuredMasterEntity;
        }

        public void Update(InsuredMasterEntity entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateDetail(InsuredMasterDetailEntity entity)
        {
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                InsuredMaster insuredMaster1 = ilaEntities.InsuredMasters.Where<InsuredMaster>((Expression<Func<InsuredMaster, bool>>)(m => m.CardNo == entity.CardNo)).FirstOrDefault<InsuredMaster>();
                if (insuredMaster1 == null)
                    return;
                InsuredMaster insuredMaster2 = insuredMaster1;
                bool? nullable1;
                int num1;
                if (!((bool?)entity.Active).HasValue)
                {
                    num1 = 0;
                }
                else
                {
                    nullable1 = (bool?)entity.Active;
                    num1 = nullable1.Value ? 1 : 0;
                }
                bool? nullable2 = new bool?(num1 != 0);
                insuredMaster2.Active = nullable2;
                InsuredMaster insuredMaster3 = insuredMaster1;
                nullable1 = (bool?)entity.HeaderYN;
                int num2;
                if (!nullable1.HasValue)
                {
                    num2 = 0;
                }
                else
                {
                    nullable1 = (bool?)entity.HeaderYN;
                    num2 = nullable1.Value ? 1 : 0;
                }
                bool? nullable3 = new bool?(num2 != 0);
                insuredMaster3.HeaderYN = nullable3;
                InsuredMaster insuredMaster4 = insuredMaster1;
                nullable1 = (bool?)entity.DailySuspension;
                int num3;
                if (!nullable1.HasValue)
                {
                    num3 = 0;
                }
                else
                {
                    nullable1 = (bool?)entity.DailySuspension;
                    num3 = nullable1.Value ? 1 : 0;
                }
                bool? nullable4 = new bool?(num3 != 0);
                insuredMaster4.DailySuspension = nullable4;
                if (!string.IsNullOrEmpty(entity.AreaPhone))
                    insuredMaster1.AreaPhone = entity.AreaPhone;
                if (!string.IsNullOrEmpty(entity.UpdateUser))
                    insuredMaster1.UpdateUser = entity.UpdateUser;
                if (((DateTime?)entity.UpdateDate).HasValue)
                    insuredMaster1.UpdateDate = (DateTime?)entity.UpdateDate;
                if (!string.IsNullOrEmpty(entity.Email))
                    insuredMaster1.EmailAddress = entity.Email;
                if (!string.IsNullOrEmpty(entity.CellPhone))
                    insuredMaster1.CellPhone = entity.CellPhone;
                try
                {
                    ilaEntities.SaveChanges();
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }
            }
        }

        public void Add(InsuredMasterEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(InsuredMasterEntity entity)
        {
            throw new NotImplementedException();
        }

        private InsuredMasterEntity BuildEntity(InsuredMaster member)
        {
            InsuredMasterEntity insuredMasterEntity1 = new InsuredMasterEntity();
            insuredMasterEntity1.Id = member.CardNo.ToString();
            insuredMasterEntity1.FirstName = string.IsNullOrWhiteSpace(member.FirstName) ? " " : member.FirstName.Trim();
            insuredMasterEntity1.MiddleInitial = string.IsNullOrWhiteSpace(member.MI) ? "" : member.MI.Trim();
            insuredMasterEntity1.LastName = string.IsNullOrWhiteSpace(member.LastName) ? "" : member.LastName.Trim();
            insuredMasterEntity1.DisplayName = insuredMasterEntity1.FirstName.Substring(0, 1) + " " + insuredMasterEntity1.LastName;
            insuredMasterEntity1.DisplayName = insuredMasterEntity1.DisplayName.Replace(", JR.", " JR");
            bool? nullable = member.HeaderYN;
            int num1;
            if (nullable.HasValue)
            {
                nullable = member.HeaderYN;
                num1 = !nullable.Value ? 1 : 0;
            }
            else
                num1 = 1;
            insuredMasterEntity1.HeaderMember = num1 == 0;
            if (!string.IsNullOrEmpty(member.AreaPhone))
                insuredMasterEntity1.Phone = member.AreaPhone.Trim();
            nullable = member.DailySuspension;
            if (nullable.HasValue)
            {
                InsuredMasterEntity insuredMasterEntity2 = insuredMasterEntity1;
                nullable = member.DailySuspension;
                int num2 = nullable.Value ? 1 : 0;
                insuredMasterEntity2.DailySuspension = num2 != 0;
            }
            else
                insuredMasterEntity1.DailySuspension = false;
            if (member.Suspension != null)
                insuredMasterEntity1.Suspension = member.Suspension.Trim();
            nullable = member.Active;
            if (nullable.HasValue)
            {
                InsuredMasterEntity insuredMasterEntity2 = insuredMasterEntity1;
                nullable = member.Active;
                int num2 = nullable.Value ? 1 : 0;
                insuredMasterEntity2.Active = num2 != 0;
            }
            else
                insuredMasterEntity1.Active = false;
            insuredMasterEntity1.SSN = !member.SSN.HasValue ? (string)null : member.SSN.Value.ToString();
            if (member.DRIVER_TWIC_ID != null)
                insuredMasterEntity1.TwicCard = member.DRIVER_TWIC_ID.Trim();
            insuredMasterEntity1.Address = string.IsNullOrEmpty(member.Address) ? " " : member.Address;
            insuredMasterEntity1.State = string.IsNullOrEmpty(member.ST) ? " " : member.ST;
            insuredMasterEntity1.City = string.IsNullOrEmpty(member.City) ? " " : member.City;
            insuredMasterEntity1.Zip = string.IsNullOrEmpty(member.Zip) ? " " : member.Zip;
            return insuredMasterEntity1;
        }

        private InsuredMasterDetailEntity BuildDetailEntity(InsuredMaster _detail)
        {
            InsuredMasterDetailEntity masterDetailEntity = new InsuredMasterDetailEntity()
            {
                CardNo = (Decimal)_detail.CardNo,
                OrigCardNo = (Decimal?)_detail.OrigCardNo,
                LastName = _detail.LastName,
                OrigLastName = _detail.OrigLastName,
                MI = _detail.MI,
                MiddleName = _detail.MiddleName,
                FirstName = _detail.FirstName,
                OrigFirstName = _detail.OrigFirstName,
                Address = _detail.Address,
                City = _detail.City,
                ST = _detail.ST,
                Zip = _detail.Zip,
                DateBirth = (DateTime?)_detail.DateBirth,
                DateHired = (DateTime?)_detail.DateHired,
                DateRetired = (DateTime?)_detail.DateRetired,
                ClassCode = _detail.ClassCode,
                Sex = _detail.Sex,
                SSN = (Decimal?)_detail.SSN,
                SSNo = _detail.SSNo,
                AreaPhone = _detail.AreaPhone,
                PrintEmergFundCheck = _detail.PrintEmergFundCheck,
                PrintLabel = (bool?)_detail.PrintLabel,
                Suspension = _detail.Suspension,
                SuspEndedDate = (DateTime?)_detail.SuspEndedDate,
                CheckOffAuth = (bool?)_detail.CheckOffAuth,
                CopeAuth = (bool?)_detail.CopeAuth,
                MemberAgencyFeePay = _detail.MemberAgencyFeePay,
                VotingRights = (bool?)_detail.VotingRights,
                MemberServicePay = (bool?)_detail.MemberServicePay,
                PerCapitaHourly = _detail.PerCapitaHourly,
                MonthCapitaDollars = (Decimal?)_detail.MonthCapitaDollars,
                AddedUser = _detail.AddedUser,
                AddedDate = (DateTime?)_detail.AddedDate,
                UpdateUser = _detail.UpdateUser
            };
            masterDetailEntity.UpdateUser = _detail.UpdateUser;
            masterDetailEntity.HasNotes = (bool?)_detail.HasNotes;
            masterDetailEntity.strDateBirth = _detail.strDateBirth;
            masterDetailEntity.strDateHired = _detail.strDateHired;
            masterDetailEntity.strDateRetired = _detail.strDateRetired;
            masterDetailEntity.DateLastWorked = (DateTime?)_detail.DateLastWorked;
            masterDetailEntity.DateDeceased = (DateTime?)_detail.DateDeceased;
            masterDetailEntity.DateRenewed = (DateTime?)_detail.DateRenewed;
            masterDetailEntity.HiringHallFee = (bool?)_detail.HiringHallFee;
            masterDetailEntity.Active = (bool?)_detail.Active;
            masterDetailEntity.EthnicOrigin = (Decimal?)_detail.EthnicOrigin;
            masterDetailEntity.MemberSince = (DateTime?)_detail.MemberSince;
            masterDetailEntity.LocalRate = (Decimal?)_detail.LocalRate;
            masterDetailEntity.CreditUnion = (Decimal?)_detail.CreditUnion;
            masterDetailEntity.EffDateChkOff = (DateTime?)_detail.EffDateChkOff;
            masterDetailEntity.EffDateHHFee = (DateTime?)_detail.EffDateHHFee;
            masterDetailEntity.Settlement = (bool?)_detail.Settlement;
            masterDetailEntity.DateSettleStart = (DateTime?)_detail.DateSettleStart;
            masterDetailEntity.SettleAmt = (Decimal?)_detail.SettleAmt;
            masterDetailEntity.HeaderYN = (bool?)_detail.HeaderYN;
            masterDetailEntity.DailySuspension = (bool?)_detail.DailySuspension;
            masterDetailEntity.DRIVER_TWIC_ID = _detail.DRIVER_TWIC_ID;
            masterDetailEntity.CellPhone = _detail.CellPhone;
            masterDetailEntity.Email = _detail.EmailAddress;
            return masterDetailEntity;
        }
    }
}