using Core.Application.Interfaces;
using Core.Application.ModelMapping;
using Core.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IoC.Dependency
{
    public class ForApplication
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configurations)
        {
            services.AddAutoMapper(typeof(AutoMapperProfile));

            services.AddScoped<ITheLoaiServices,TheLoaiServices>();
            services.AddScoped<IMenuMainServices, MenuMainServices>();
            
        }
    }
}
