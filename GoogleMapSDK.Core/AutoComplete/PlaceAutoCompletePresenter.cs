using GoogleMapSDK.UI.Contract.API;
using GoogleMapSDK.UI.Contract.API.Models;
using GoogleMapSDK.UI.Contract.API.Places;
using GoogleMapSDK.UI.Contract.API.Places_Detail.Models;
using GoogleMapSDK.UI.Contract.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GoogleMapSDK.UI.Contract.Components.AutoComplete.AutoCompleteContract;

namespace GoogleMapSDK.Core.AutoComplete
{
    public class PlaceAutoCompletePresenter : IAutoCompletePresenter
    {
        IGoogleContext context = null;      
        public PlaceAutoCompletePresenter(IGoogleContext context,IAutoCompleteView autoCompleteView)
        {
            this.context = context;
        }
        public async Task<object> GetSelectItemAsync(string selectedValue)
        {
            PlacesDetailRequest placesDetailRequest = new PlacesDetailRequest();
            placesDetailRequest.place_id = selectedValue;
            var result = await context.PlaceDetail.GetPlaceDetail(placesDetailRequest);

            PlaceInfo markerinfo = new PlaceInfo();
            markerinfo.Name = result.result.name;
            markerinfo.Address = result.result.formatted_address;
            markerinfo.PlaceId = result.result.place_id;
            markerinfo.Lat = result.result.geometry.location.lat;
            markerinfo.Lng = result.result.geometry.location.lng;

            return markerinfo;
        }
        public async Task<List<object>> GetDataSourceAsync(string query)
        {
            AutoCompleteRequest autoCompleteRequest = new AutoCompleteRequest();
            autoCompleteRequest.input = query;
            var result = await context.AutoComplete.AutoCompleteSearch(autoCompleteRequest);

            List<object> places = result.predictions.Select(item => (object)new AutoCompleteModel
            {
                Key = item.structured_formatting.main_text,
                Value = item.place_id
            }).ToList();

            return places;
        }
    }
}
