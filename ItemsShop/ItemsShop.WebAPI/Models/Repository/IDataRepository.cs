using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemsShop.WebAPI.Models.Repository
{
    public interface IDataRepository<TEntity, U> where TEntity : class
    {
        Task<long> Add(TEntity entity);

        Task<long> Delete(U id);

        TEntity Get(U id);

        IEnumerable<TEntity> GetAll();

        Task<long> Update(U id, TEntity entity);
    }
}
