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
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ClaroCellDbContext dbContext)
            :base(dbContext)
        {

        }

        public async Task<User> GetLogin(string login, string senha)
        {
            var user =  _dbContext.Users.FirstOrDefault(obj => obj.Login == login && obj.Password == senha);
            if (user == null) return null;

            return await Task.FromResult(user);
        }
    }
}
