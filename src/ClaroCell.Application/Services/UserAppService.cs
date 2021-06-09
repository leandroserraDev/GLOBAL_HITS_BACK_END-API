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
    public class UserAppService : AppServiceBase<User>, IUserAppService
    {
        private readonly IUserService _userService;
        public UserAppService(IUserService userService)
            :base(userService)
        {
            _userService = userService;
        }

        public async Task<User> GetLogin(string login, string senha)
        {
            var user = await _userService.GetLogin(login, senha);
            if (user == null) return null;

            return await Task.FromResult(user);
        }
    }
}
