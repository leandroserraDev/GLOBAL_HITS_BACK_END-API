using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaroCell.Domain.InterfacesRepository
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<IQueryable<TEntity>> GetAll();
        Task<bool> Add(TEntity entity);
        Task<bool> Update(TEntity entity);
        Task<bool> Delete(int id);
        Task<bool> Save();
    }
}
