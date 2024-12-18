using Arch.EntityFrameworkCore.UnitOfWork;
using IncomeTaxCalculate.Application.Interfaces.Repository;
using IncomeTaxCalculate.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeTaxCalculate.Infrastructure.Extentions
{
    public static class DependencyInjection
    {

        public static void AddPersistenceServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddDbContext<AppDbContext>(optionsAction => optionsAction.UseSqlServer(configuration.GetConnectionString("AppDatabase"))).AddUnitOfWork<AppDbContext>();
        }
    }
}
