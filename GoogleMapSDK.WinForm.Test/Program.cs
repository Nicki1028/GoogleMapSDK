using DIContainer;
using GoogleMapSDK.UI.Contract.Components;
using GoogleMapSDK.UI.WinForm.Components.AutoComplete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GoogleMapSDK.API;
using GoogleMapSDK.UI.Contract.API;
using GoogleMapSDK.Core;
using System.IO;
using Microsoft.Extensions.Configuration;
using static GoogleMapSDK.UI.Contract.Components.AutoComplete.AutoCompleteContract;
using GoogleMapSDK.Core.AutoComplete;
namespace GoogleMapSDK.WinForm.Test
{
    internal static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

            NickiService services = new NickiService();
            services.Collection.AddGoogleMapAPIRegistration(configuration);
            services.AddSingleton<IAutoCompleteView, PlaceAutoCompleteView>();
            services.AddSingleton<IAutoCompleteView, EmployeeAutoCompleteView>();

            //在factory會不知道要找哪一個
            services.AddSingleton<IAutoCompletePresenter, PlaceAutoCompletePresenter>();
            services.AddSingleton<IAutoCompletePresenter, EmployeeAutoCompletePresenter>();
            //services.AddSingleton<AutoCompleteBase, EmployeeAutoComplete>();

            services.AddSingleton<IGoogleMap, MapControl>();
            services.AddSingleton<Form, Form1>();
            IServiceProvider provider = services.BuildServiceProvider();
            Form form = provider.GetService<Form>();


            Application.Run(form);
        }
    }
}
