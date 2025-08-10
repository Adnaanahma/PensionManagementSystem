using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using PensionManagementSystem.Domain.Interfaces;
using PensionManagementSystem.Domain.Services;
using PensionManagementSystem.Infrastructure;

namespace PensionManagementSystem.Domain.Helpers
{
    public static class ServiceInjection
    {
        public static IServiceCollection AddInjectedServices(this IServiceCollection services)
        {
            // Register AutoMapper configuration
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutomapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);


            //services.AddTransient<IEmployerService, EmployerService>();
            //services.AddTransient<IMemberService, MemberService>();
            //services.AddUnitOfWork<ApplicationDbContext>();
            // services.AddAutoMapper(typeof(AutomapperProfile).Assembly);


            return services;
        }
    }
}
