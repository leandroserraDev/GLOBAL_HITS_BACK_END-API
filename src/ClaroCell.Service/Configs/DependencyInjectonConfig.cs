using ClaroCel.Infra.Repositories;
using ClaroCell.Application.InterfacesService;
using ClaroCell.Application.Services;
using ClaroCell.Domain.InterfacesRepository;
using ClaroCell.Domain.InterfacesService;
using ClaroCell.Domain.Service.Services;
using ClaroCell.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaroCell.Service.Configs
{
    public static class DependencyInjectionConfig
    {
        public static void ResolverInjection(this IServiceCollection services)
        {
            //DI Generics
            services.AddScoped(typeof(IRepositoryBase<>), typeof(Repository<>));
            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
            services.AddScoped(typeof(IAppServiceBase<>), typeof(AppServiceBase<>));

            //Resolve dependences  Repository
            services.AddScoped<ICellRepository, CellRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            //Resolve dependences Services
            services.AddScoped<ICellService, CellService>();
            services.AddScoped<IUserService, UserService>();

            //Resolve dependences AppService
            services.AddScoped<ICellAppService, CellAppService>();
            services.AddScoped<IUserAppService, UserAppService>();

        }
    }
}
