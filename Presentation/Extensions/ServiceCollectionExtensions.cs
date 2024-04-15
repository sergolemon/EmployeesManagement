using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Interfaces;
using Presentation.Services;
using Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Presentation.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services, IConfiguration configuration)
        {
            //add view models
            services.AddTransient<EmployeeListVm>();
            services.AddTransient<AddNewEmployeeVm>();
            
            //add services
            services.AddSingleton<IExportService, JsonExportService>();
            services.AddSingleton<IImportService, JsonImportService>();

            services.AddSingleton(sp => Dispatcher.CurrentDispatcher);

            return services;
        }
    }
}
