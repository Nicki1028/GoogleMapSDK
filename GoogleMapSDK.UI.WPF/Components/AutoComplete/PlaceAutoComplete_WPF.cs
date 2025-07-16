
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

namespace GoogleMapSDK.UI.WPF.Components.AutoComplete
{
    [ToolboxItem(true)]
    public class PlaceAutoComplete : BaseAutoComplete<KeyValueModel, MarkerInfo>
    {
        IGoogleContext _googleContext;
        public PlaceAutoComplete(IGoogleContext googleContext)
        {
            _googleContext = googleContext;
        }

        protected override async Task<IEnumerable<KeyValueModel>> GetCompleteSourceAsync()
        {
            AutoCompleteRequest autoCompleteRequest = new AutoCompleteRequest();
            autoCompleteRequest.input = this.Text;
            var result = await _googleContext.AutoComplete.AutoCompleteSearch(autoCompleteRequest);

           
            List<KeyValueModel> places = result.predictions.Select(item => new KeyValueModel
            {
                Name = item.structured_formatting.main_text,
                Id = item.place_id
            }).ToList();


            return places;
        }

        protected override async Task<MarkerInfo> GetSelectItemAsync(string selectedItem)
        {
            PlacesDetailRequest placesDetailRequest = new PlacesDetailRequest();
            placesDetailRequest.place_id = selectedItem;
            var result = await _googleContext.PlaceDetail.GetPlaceDetail(placesDetailRequest);

            MarkerInfo markerinfo = new MarkerInfo();
            markerinfo.Name = result.result.name;
            markerinfo.Address = result.result.formatted_address;
            markerinfo.PlaceId = result.result.place_id;
            markerinfo.TextboxId = this.Name;
            markerinfo.Lat = result.result.geometry.location.lat;
            markerinfo.Lng = result.result.geometry.location.lng;

            return markerinfo;
        }
    }
}
