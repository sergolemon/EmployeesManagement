using Core.Data;
using Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Presentation.Extensions;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = CreateHost();
            ConfigureEnvironment();
        }

        public static TService GetService<TService>() where TService : class
        {
            if ((Current as App)!._host.Services.GetService(typeof(TService)) is not TService service)
            {
                throw new ArgumentException($"{typeof(TService)} needs to be registered in ConfigureServices within App.xaml.cs.");
            }

            return service;
        }

        private IHost CreateHost()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {
                    services.AddCore(context.Configuration);
                    services.AddPresentation(context.Configuration);
                })
                .Build();
        }

        private void ConfigureEnvironment()
        {
            var appDataDirectory = GetService<IConfiguration>()["AppDataDirectory"]!;
            Directory.CreateDirectory(appDataDirectory);

            using var dbContext = GetService<AppDbContext>();
            dbContext.Database.Migrate();
        }
    }
}
