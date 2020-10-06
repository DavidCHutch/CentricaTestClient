using CentricaTestClient.CentricaTestAPI.Services;
using CentricaTestClient.Domain.Models;
using CentricaTestClient.Domain.Services;
using CentricaTestClient.WPF.States.Navigators;
using CentricaTestClient.WPF.ViewModels;
using CentricaTestClient.WPF.ViewModels.Factories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CentricTestClient.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //TODO: Handle dependency injection with a dependency injector from microsoft

        // Deleted SartupUri, to handle startup in App.xaml, because of startup properties and dependancy injection further down the pipeline
        protected override void OnStartup(StartupEventArgs e)
        {
            //IServiceProvider serviceProvider = CreateServiceProvider();

            Window window = new MainWindow();
            window.DataContext = new MainViewModel();
            window.Show();

            // Can use different scope if needed
            //using (IServiceScope scope = serviceProvider.CreateScope())
            //{
            //    scope.ServiceProvider.GetRequiredService<MainViewModel>();
            //}

            base.OnStartup(e);
        }

        //Dependency injector container
        //private IServiceProvider CreateServiceProvider()
        //{
        //    IServiceCollection services = new ServiceCollection();

        //    services.AddSingleton<IDistrictService, DistrictService>();

        //    services.AddSingleton<ICentricaViewModelAbstractFactory, CentricaViewModelAbstractFactory>();
        //    services.AddSingleton<ICentricaViewModelFactory<HomeViewModel>, HomeViewModelFactory>();
        //    services.AddSingleton<ICentricaViewModelFactory<DistrictViewModel>, DistrictViewModelFactory>();
        //    services.AddSingleton<ICentricaViewModelFactory<OrdersViewModel>, OrdersViewModelFactory>();

        //    services.AddScoped<INavigator, Navigator>();
        //    services.AddScoped<MainViewModel>();

        //    return services.BuildServiceProvider();
        //}

    }
}
