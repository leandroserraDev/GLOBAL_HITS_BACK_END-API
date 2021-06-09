using ClaroCell.Domain.InterfacesRepository;
using ClaroCell.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaroCel.Infra.Repositories
{
    public class Repository<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly ClaroCellDbContext _dbContext;

        public Repository(ClaroCellDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<bool> Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            
            if(!await Save())
            {
                return false;
            }

            return true;
        }


        public async Task<bool> Delete(int id)
        {
            var entity = await _dbContext.Set<TEntity>().FindAsync(id);
            if(entity == null)
            {
                return false;
            }

            _dbContext.Set<TEntity>().Remove(entity);

            if(!await Save())
            {
                return false;
            }

            return true;
        }


        public async Task<IQueryable<TEntity>> GetAll()
        {
            var entities =  _dbContext.Set<TEntity>();
            if (entities == null) return null;

            return await Task.FromResult(entities);
        }

        public async Task<bool> Save()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            
            if(!await Save())
            {
                return await Task.FromResult(false);
            }
            return await Task.FromResult(true);
        }
    }
}
