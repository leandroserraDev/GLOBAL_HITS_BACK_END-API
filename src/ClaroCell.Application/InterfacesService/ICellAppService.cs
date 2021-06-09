using ClaroCell.Application.Services;
using ClaroCell.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaroCell.Application.InterfacesService
{
    public interface ICellAppService : IAppServiceBase<Cell>
    {
        Task<Cell> Get(string code);
        Task<bool> DeleteByCode(string code);
        Task<Cell> UpdateByCode(string code, Cell newEntity);

    }
}
