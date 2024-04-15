using Core.Data;
using Core.Interfaces;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
        {
            string connStr = configuration.GetConnectionString("DefaultSqliteConnStr")!;

            var optsBuilderAction = (DbContextOptionsBuilder optsBuilder) => 
            { 
                optsBuilder.UseSqlite(connStr);
            };

            services.AddDbContextFactory<AppDbContext>(optsBuilderAction);
            services.AddDbContext<AppDbContext>(optsBuilderAction);

            services.AddSingleton<IEmployeeRepository, EmployeeRepository>();

            return services;
        }
    }
}
