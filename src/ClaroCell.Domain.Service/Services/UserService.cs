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
    public class UserService : ServiceBase<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
            :base(userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetLogin(string login, string senha)
        {
            var user =  await _userRepository.GetLogin(login, senha);
            if (user == null) return null;

            return await Task.FromResult(user);
        }
    }
}
