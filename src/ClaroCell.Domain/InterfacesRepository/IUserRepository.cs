using ClaroCell.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaroCell.Domain.InterfacesRepository
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User> GetLogin(string login, string senha);

    }
}
