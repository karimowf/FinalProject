using Microsoft.Extensions.DependencyInjection;
using Project.BLL.Abstract;
using Project.BLL.Concrete;
using Project.DAL.UnitOfWorkModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Extensions
{
    public static class BLLConfiguration
    {
        public static void AddBLLConfigures(this IServiceCollection services)
        {
            services.AddScoped<IJwtTokenService, JwtTokenService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IFavoritesService, FavoritesService>();
        }
    }
}
