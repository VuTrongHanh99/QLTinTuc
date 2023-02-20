using Core.Domain.Interfaces;
using Data.SqlServer.Context;
using Data.SqlServer.Systems.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IoC.Dependency
{
    public class ForInfrastructure
    {
        public static void RegisterInfrastructure(IServiceCollection services, IConfiguration configurations)
        {
            services.AddDbContext<DataContext>(options => options.UseSqlServer(configurations.GetConnectionString("ProductStore")));

            services.AddScoped<ITheLoaiRepository, TheLoaiRepository>();
        }
    }
}
