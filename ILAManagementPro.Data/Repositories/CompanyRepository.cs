using ILAManagementPro.Data.Data;
using ILAManagementPro.Data.Interfaces;
using ILAManagementPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ILAManagementPro.Data.Repositories
{
    public class CompanyRepository : RepositoryBase<CompanyEntity>, IRepository<CompanyEntity>
    {
        public List<CompanyEntity> GetAll()
        {
            List<CompanyEntity> source = new List<CompanyEntity>();
            using (ILAEntities ilaEntities = new ILAEntities())
            {
                foreach (CompanyMaster companyMaster in (IEnumerable<CompanyMaster>)ilaEntities.CompanyMasters)
                    source.Add(this.BuildEntity(companyMaster));
            }
            return source.OrderBy<CompanyEntity, string>((Func<CompanyEntity, string>)(c => c.Id)).ToList<CompanyEntity>();
        }

        public CompanyEntity Get(string id)
        {
            throw new NotImplementedException();
        }

        public void Update(CompanyEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Add(CompanyEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(CompanyEntity entity)
        {
            throw new NotImplementedException();
        }

        private CompanyEntity BuildEntity(CompanyMaster company)
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
    }
}