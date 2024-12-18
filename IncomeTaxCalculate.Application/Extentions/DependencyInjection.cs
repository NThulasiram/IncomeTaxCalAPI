using IncomeTaxCalculate.Application.Interfaces;
using IncomeTaxCalculate.Application.Interfaces.Repository;
using IncomeTaxCalculate.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IncomeTaxCalculate.Application.Extentions
{
    public static class DependencyInjection
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();

        }
    }
}
