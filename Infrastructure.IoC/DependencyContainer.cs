using Infrastructure.IoC.Dependency;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterIoC(IServiceCollection services, IConfiguration configurations)
        {
            ForApplication.RegisterServices(services, configurations);
            ForInfrastructure.RegisterInfrastructure(services, configurations);
        }
    }
}
