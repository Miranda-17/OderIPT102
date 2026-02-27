using Framework.Data;
using Framework.Repositories;
using Framework.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderManagement.ViewModels;
using OrderManagement.Views;
using System;
using System.IO;
using System.Windows;

namespace OrderManagement
{
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            // Subscribe to UI thread exceptions
            this.DispatcherUnhandledException += App_DispatcherUnhandledException;

            base.OnStartup(e);

            try
            {
                var services = new ServiceCollection();
                ConfigureServices(services);

                ServiceProvider = services.BuildServiceProvider();

                // Resolve MainWindow from DI
                var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
                mainWindow.Show();
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw; // rethrow so debugger can break if configured
            }
        }

        private void App_DispatcherUnhandledException(object? sender,
            System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            LogException(e.Exception);
            // Let debugger handle it
        }

        private void LogException(Exception ex)
        {
            try
            {
                var path = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "OrderManagement",
                    "crash.log");

                Directory.CreateDirectory(Path.GetDirectoryName(path)!);

                File.AppendAllText(path,
                    $"[{DateTime.Now:O}] {ex}\n\n");
            }
            catch
            {
                // ignore logging errors
            }
        }

        private void ConfigureServices(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            services.AddSingleton<IConfiguration>(configuration);

            // Framework Layer
            services.AddSingleton<AppDbContext>();
            services.AddSingleton<IOrderRepository, OrderRepository>();
            services.AddSingleton<IOrderService, OrderService>();

            // WPF Layer
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainWindow>();
        }
    }
}