using ILAManagementPro.Models;
using System.Collections.Generic;

namespace ILAManagementPro.Data.Interfaces
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        List<TEntity> GetAll();

        TEntity Get(string id);

        void Update(TEntity entity);

        void Add(TEntity entity);

        void Delete(TEntity entity);
    }
}