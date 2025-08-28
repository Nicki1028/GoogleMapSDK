using DIContainer;
using GoogleMapSDK.Core.AutoComplete;
using GoogleMapSDK.UI.Contract.API;
using GoogleMapSDK.UI.Contract.API.Models;
using GoogleMapSDK.UI.Contract.API.Places;
using GoogleMapSDK.UI.Contract.API.Places_Detail.Models;
using GoogleMapSDK.UI.Contract.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using static GoogleMapSDK.UI.Contract.Components.AutoComplete.AutoCompleteContract;

namespace GoogleMapSDK.UI.WinForm.Components.AutoComplete
{
    public class PlaceAutoCompleteView : BaseAutoComplete<AutoCompleteModel, PlaceInfo>
    {
        IAutoCompletePresenter presenter = null;
        public PlaceAutoCompleteView(PresenterFactory presenterFactory)
        {         
            presenter = presenterFactory.Create<IAutoCompletePresenter, IAutoCompleteView>(this,typeof(PlaceAutoCompletePresenter));     
        }

        protected override async Task<IEnumerable<AutoCompleteModel>> GetCompleteSource(string input)
        {
            var response  = await this.presenter.GetDataSourceAsync(input);
            return response.Select(x=> (AutoCompleteModel)x).ToList();

        }

        protected override async Task<PlaceInfo> GetSelectItemAsync(string selectedItem)
        {
            var selectresponse = await this.presenter.GetSelectItemAsync(selectedItem);
            return (PlaceInfo)selectresponse;
        }
    }
}
