using ClaroCell.Application.InterfacesService;
using ClaroCell.Domain.Entities;
using ClaroCell.Domain.InterfacesService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaroCell.Application.Services
{
   public class CellAppService: AppServiceBase<Cell>, ICellAppService
    {
        private readonly ICellService _cellService;
        public CellAppService(ICellService cellService)
            :base(cellService)
        {
            _cellService = cellService;
        }

        public async Task<bool> DeleteByCode(string code)
        {
            var result = await _cellService.DeleteByCode(code);
            if(!result) return false;

            return true;
        }

        public async Task<Cell> Get(string code)
        {
            var cell = await _cellService.Get(code);
            if (cell == null) return null;

            return await Task.FromResult(cell);
        }

        public override Task<bool> Add(Cell entity)
        {
            entity.Code = Guid.NewGuid();
            return base.Add(entity);
        }

        public async Task<Cell> UpdateByCode(string code, Cell newEntity)
        {
            var cell = await _cellService.UpdateByCode(code, newEntity);
            if (cell == null) return null;

            return await Task.FromResult(cell);

        }
    }
}
