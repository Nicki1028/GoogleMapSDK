using DIContainer;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using GoogleMapSDK.API;
using GoogleMapSDK.UI.WPF;
using GoogleMapSDK.Core;
namespace GoogleMapSDK.WPF.Test
{
    /// <summary>
    /// App.xaml 的互動邏輯
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

            NickiService services = new NickiService();
            services.Collection.AddGoogleMapCoreRegistration(configuration);
            services.Collection.AddGoogleMapRegistration(configuration);
            services.AddSingleton<Window, MainWindow>();

            var provider = services.BuildServiceProvider();
            Window window = provider.GetService<Window>();

            window.Show();
        }
    }
}
