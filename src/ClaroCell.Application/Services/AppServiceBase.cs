using ClaroCell.Application.InterfacesService;
using ClaroCell.Domain.InterfacesService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaroCell.Application.Services
{
    public class AppServiceBase<TEntity> : IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IServiceBase<TEntity> _serviceBase;

        public AppServiceBase(IServiceBase<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public virtual async Task<bool> Add(TEntity entity)
        {

            var result = await _serviceBase.Add(entity);
            if (!result) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }



        public async Task<bool> Delete(int id)
        {
            var result = await _serviceBase.Delete(id);
            if (!result) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }

        public async Task<List<TEntity>> GetAll()
        {
            var entities = await _serviceBase.GetAll();
            if (entities == null) return null;

            return await Task.FromResult(entities);
        }

        public async Task<bool> Update(TEntity entity)
        {
            var result = await _serviceBase.Update(entity);
            if (!result) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
    }
}
