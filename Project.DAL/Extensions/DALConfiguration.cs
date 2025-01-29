using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Extensions
{
    public static class DALConfiguration
    {
        public static void AddDBConfigures(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<SqlDbContext>(op =>
            op.UseSqlServer(configuration.GetConnectionString("Default")));

            services.AddSingleton<MongoDbContext>();
        }
    }
}