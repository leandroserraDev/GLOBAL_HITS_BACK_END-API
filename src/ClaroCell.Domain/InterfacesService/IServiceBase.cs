using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaroCell.Domain.InterfacesService
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAll();
        Task<bool> Add(TEntity entity);
        Task<bool> Update(TEntity entity);
        Task<bool> Delete(int id);
    }
}
