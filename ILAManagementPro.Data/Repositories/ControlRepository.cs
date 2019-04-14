using ILAManagementPro.Data.Data;
using ILAManagementPro.Data.Interfaces;
using ILAManagementPro.Models;
using System;
using System.Collections.Generic;

namespace ILAManagementPro.Data.Repositories
{
    public class ControlRepository : RepositoryBase<ControlEntity>, IRepository<ControlEntity>
    {
        public List<ControlEntity> GetAll()
        {
            return new List<ControlEntity>()
            {
                SQLData.GetControl()
            };
        }

        public ControlEntity Get(string id)
        {
            throw new NotImplementedException();
        }

        public void Update(ControlEntity entity)
        {
            SQLData.UpdateControl(entity);
        }

        public void Add(ControlEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(ControlEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}