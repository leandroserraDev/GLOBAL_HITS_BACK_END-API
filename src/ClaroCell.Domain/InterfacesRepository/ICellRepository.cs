using ClaroCell.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaroCell.Domain.InterfacesRepository
{
    public interface ICellRepository : IRepositoryBase<Cell>
    {
        Task<Cell> Get(string code);
        Task<bool> DeleteByCode(string code);

    }
}
