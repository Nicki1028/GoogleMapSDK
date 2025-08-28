using GoogleMapSDK.UI.WPF.Components.AutoComplete;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GoogleMapSDK.UI.Contract.Components.AutoComplete.AutoCompleteContract;

namespace GoogleMapSDK.UI.WPF
{
    public static class GoogleMapWPFRegistration
    {
        public static void AddGoogleMapRegistration(this IServiceCollection collection, IConfiguration configuration)
        {

            collection.AddSingleton<IAutoCompleteView, PlaceAutoComplete>();
          
        }
    }
}
