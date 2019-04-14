using ILAManagementPro.Data.Data;
using ILAManagementPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using InsuredMaster = ILAManagementPro.Data.Data.InsuredMaster;

namespace ILAManagementPro.Data.Repositories
{
    public class DriverAssignmentRepository
    {
        public List<DriverAssignmentEntity> GetAll()
        {
            List<DriverAssignmentEntity> assignmentEntityList = new List<DriverAssignmentEntity>();
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                foreach (InsuredMaster insuredMaster in (IEnumerable<InsuredMaster>)ilaEntities.InsuredMasters)
                    assignmentEntityList.Add(this.BuildEntity(insuredMaster));
            }
            return assignmentEntityList;
        }

        public DriverAssignmentEntity Get(string id)
        {
            DriverAssignmentEntity assignmentEntity = (DriverAssignmentEntity)null;
            Decimal idNumber;
            if (Decimal.TryParse(id, out idNumber))
            {
                using (ILAEntities ilaEntities = new ILAEntities())
                {
                    InsuredMaster dbRecord = ilaEntities.InsuredMasters.Where<InsuredMaster>((Expression<Func<InsuredMaster, bool>>)(m => m.CardNo == idNumber)).FirstOrDefault<InsuredMaster>();
                    if (dbRecord != null)
                        assignmentEntity = this.BuildEntity(dbRecord);
                }
            }
            return assignmentEntity;
        }

        public void Update(InsuredMaster entity)
        {
            throw new NotImplementedException();
        }

        public void Add(HeaderEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(HeaderEntity entity)
        {
            throw new NotImplementedException();
        }

        private DriverAssignmentEntity BuildEntity(InsuredMaster dbRecord)
        {
            return new DriverAssignmentEntity();
        }
    }
}