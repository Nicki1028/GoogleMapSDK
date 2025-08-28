
using GoogleMapSDK.UI.WPF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMapSDK.Core;
using GoogleMapSDK.UI.Contract.API;
using GoogleMapSDK.UI.Contract.API.Places;
using GoogleMapSDK.UI.Contract.API.Places_Detail.Models;
using GoogleMapSDK.UI.Contract.API.Models;
using GoogleMapSDK.UI.Contract.Models;
using GoogleMapSDK.Core.AutoComplete;
using static GoogleMapSDK.UI.Contract.Components.AutoComplete.AutoCompleteContract;
using DIContainer;

namespace GoogleMapSDK.UI.WPF.Components.AutoComplete
{
    [ToolboxItem(true)]
    public class PlaceAutoComplete : BaseAutoComplete<AutoCompleteModel, PlaceInfo>
    {
     
        IAutoCompletePresenter presenter = null;
        public PlaceAutoComplete(PresenterFactory presenterFactory)
        {
            presenter = presenterFactory.Create<IAutoCompletePresenter, IAutoCompleteView>(this, typeof(PlaceAutoCompletePresenter));
        }

        protected override async Task<IEnumerable<AutoCompleteModel>> GetCompleteSourceAsync(string input)
        {
            var response = await this.presenter.GetDataSourceAsync(input);
            return response.Select(x => (AutoCompleteModel)x).ToList();
        }

        protected override async Task<PlaceInfo> GetSelectItemAsync(string selectedItem)
        {
            var selectresponse = await this.presenter.GetSelectItemAsync(selectedItem);
            return (PlaceInfo)selectresponse;
        }
    }
}
