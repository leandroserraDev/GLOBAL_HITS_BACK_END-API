using ClaroCel.Infra.Repositories;
using ClaroCell.Domain.Entities;
using ClaroCell.Domain.InterfacesRepository;
using ClaroCell.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaroCell.Infra.Repositories
{
    public class CellRepository :Repository<Cell>,  ICellRepository
    {
        public CellRepository(ClaroCellDbContext dbContext)
            :base(dbContext)
        {
        }

        public async Task<bool> DeleteByCode(string code)
        {
            var result =  _dbContext.Cells.FirstOrDefault(obj => obj.Code.ToString() == code);

            if (result == null) return await Task.FromResult(false);
            
            _dbContext.Cells.Remove(result);

            _dbContext.SaveChanges();

            return await Task.FromResult(true);
        }

        public override Task<bool> Add(Cell entity)
        {
            return base.Add(entity);
        }

        public async Task<Cell> Get(string code)
        {
            var entity = _dbContext.Cells.FirstOrDefault(obj => obj.Code.ToString() == code);
            if (entity == null) return null;

            return await Task.FromResult(entity);

        }

  
    }
}
