using ClaroCell.Domain.InterfacesRepository;
using ClaroCell.Domain.InterfacesService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaroCell.Domain.Service.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repositoryBase;

        public ServiceBase(IRepositoryBase<TEntity> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public virtual async Task<bool> Add(TEntity entity)
        {
            var result = await _repositoryBase.Add(entity);

            if (!result) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _repositoryBase.Delete(id);
            if (!result) await Task.FromResult(false);

            return await Task.FromResult(true);
        }


        public async Task<List<TEntity>> GetAll()
        {
            var entities = await _repositoryBase.GetAll();
            if (entities == null) return  null;

            return entities.ToList();
        }

        public async Task<bool> Update(TEntity entity)
        {
            var result = await _repositoryBase.Update(entity);
            if (!result) return await Task.FromResult(false);

            return await Task.FromResult(true);
         }
    }
}
