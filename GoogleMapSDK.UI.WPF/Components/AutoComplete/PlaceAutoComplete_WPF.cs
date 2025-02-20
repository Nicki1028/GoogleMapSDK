
using GoogleMapSDK.API.Places_Detail;
using GoogleMapSDK.API;
using GoogleMapSDK.API.Places;
using GoogleMapSDK.UI.WPF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.UI.WPF.Components.AutoComplete
{
    [ToolboxItem(true)]
    public class PlaceAutoComplete : BaseAutoComplete<KeyValueModel, MarkerInfo>
    {
        GoogleContext context = null;
        public PlaceAutoComplete()
        {
            context = GoogleContext.GetGoogleContext();
        }

        protected override async Task<IEnumerable<KeyValueModel>> GetCompleteSourceAsync()
        {
            AutoCompleteRequest autoCompleteRequest = new AutoCompleteRequest();
            autoCompleteRequest.input = this.Text;
            var result = await context.AutoComplete.AutoCompleteSearch(autoCompleteRequest);

           
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
            var result = await context.PlacesDetail.GetPlaceDetail(placesDetailRequest);

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
