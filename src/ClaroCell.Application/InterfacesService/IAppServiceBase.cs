using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClaroCell.Application.InterfacesService
{
    public interface IAppServiceBase<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAll();
        Task<bool> Add(TEntity entity);
        Task<bool> Delete(int id);
    }
}
