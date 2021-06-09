using ClaroCell.Domain.Entities;
using ClaroCell.Domain.InterfacesRepository;
using ClaroCell.Domain.InterfacesService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaroCell.Domain.Service.Services
{
    public class CellService :  ServiceBase<Cell>, ICellService
    {
        private readonly ICellRepository _cellRepository;
        public CellService(ICellRepository cellRepository)
            :base(cellRepository)
        {
            _cellRepository = cellRepository;
        }

        public async Task<bool> DeleteByCode(string code)
        {
            var result = await _cellRepository.DeleteByCode(code);
            if (!result) return false;

            return true;
        }

        public override Task<bool> Add(Cell entity)
        {

            return base.Add(entity);
        }


        public async Task<Cell> Get(string code)
        {
            var cell = await _cellRepository.Get(code);
            if (cell == null) return null;

            return await Task.FromResult(cell);
        }

        public async Task<Cell> UpdateByCode(string code, Cell newentity)
        {
            var cell = await _cellRepository.Get(code);
            if (cell == null) return null;

            cell.Brand = newentity.Brand;
            cell.Date = newentity.Date;
            cell.Model = newentity.Model;
            cell.Photo = newentity.Photo;
            cell.Price = newentity.Price;

            if(!await _cellRepository.Save())
            {
                return null;
            }

            return await Task.FromResult(cell);
        }
    }
}
