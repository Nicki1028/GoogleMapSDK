using GoogleMapSDK.Core.AutoComplete;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GoogleMapSDK.UI.Contract.Components.AutoComplete.AutoCompleteContract;
using GoogleMapSDK.API;

namespace GoogleMapSDK.Core
{
    public static class GoogleMapCoreRegistration
    {
        public static void AddGoogleMapCoreRegistration(this IServiceCollection collection, IConfiguration configuration)
        {
            collection.AddGoogleMapAPIRegistration(configuration);
            collection.AddSingleton<IAutoCompletePresenter, PlaceAutoCompletePresenter>();
            collection.AddSingleton<IAutoCompletePresenter, EmployeeAutoCompletePresenter>();
        }
    }
}
