using ILAManagementPro.Data.Data;
using ILAManagementPro.Data.Interfaces;
using ILAManagementPro.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace ILAManagementPro.Data.Repositories
{
    public class CallBackReportRepository : RepositoryBase<CallBackReportEntity>, IRepository<CallBackReportEntity>
    {
        public List<CallBackReportEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<CallBackReportEntity> GetAllActive()
        {
            List<CallBackReportEntity> source = new List<CallBackReportEntity>();
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                DbSet<absCallBack> absCallBacks = ilaEntities.absCallBacks;
                Expression<Func<absCallBack, bool>> predicate = (Expression<Func<absCallBack, bool>>)(a => a.active);
                foreach (absCallBack CallBack in (IEnumerable<absCallBack>)absCallBacks.Where<absCallBack>(predicate))
                    source.Add(this.BuildEntity(CallBack));
            }
            return source.OrderBy<CallBackReportEntity, string>((Func<CallBackReportEntity, string>)(b => b.Id)).ToList<CallBackReportEntity>();
        }

        public CallBackReportEntity Get(string id)
        {
            throw new NotImplementedException();
        }

        public void Update(CallBackReportEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Add(CallBackReportEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(CallBackReportEntity entity)
        {
            throw new NotImplementedException();
        }

        private CallBackReportEntity BuildEntity(absCallBack CallBack)
        {
            CallBackReportEntity backReportEntity = new CallBackReportEntity();
            backReportEntity.Id = CallBack.id.ToString();
            backReportEntity.Name = this.BuildHeaderDisplayName(CallBack.InsuredMaster.FirstName, CallBack.InsuredMaster.LastName);
            backReportEntity.SSN = this.GetSSNLastFour(CallBack.InsuredMaster.SSNo);
            backReportEntity.CardNumber = CallBack.cardNumberId.ToString();
            backReportEntity.SenClass = CallBack.InsuredMaster.ClassCode;
            backReportEntity.Telephone = this.EncodePhoneNumber(CallBack.phoneNumber.Trim());
            backReportEntity.Date = CallBack.callBackDateTime.ToString("MM/dd/yyyy");
            backReportEntity.Time = CallBack.callBackDateTime.ToString("h:mm tt");
            return backReportEntity;
        }

        private string EncodePhoneNumber(string phone)
        {
            string str;
            if (phone.Length == 10)
                str = "(" + phone.Substring(0, 3) + ")" + phone.Substring(3, 3) + "-" + phone.Substring(6, 4);
            else
                str = phone.Length != 7 ? phone : phone.Substring(0, 3) + "-" + phone.Substring(3, 4);
            return str;
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