using GoogleMapSDK.API;
using GoogleMapSDK.API.Places;
using GoogleMapSDK.API.Places_Detail;
using GoogleMapSDK.Core;
using GoogleMapSDK.UI.WinForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleMapSDK.UI.WinForm.Components.AutoComplete
{
    public class PlaceAutoComplete : BaseAutoComplete<KeyValueModel,PlaceInfo>
    {
        GoogleContext context = null;
        public override string DisplayMember => "Name";
        public override string ValueMember => "Id";
        public PlaceAutoComplete() { context = GoogleContext.InitialGoogleContext(); }

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

        protected override async Task<PlaceInfo> GetSelectItemAsync(string selectedItem)
        {
            PlacesDetailRequest placesDetailRequest = new PlacesDetailRequest();
            placesDetailRequest.place_id = selectedItem;
            var result = await context.PlacesDetail.GetPlaceDetail(placesDetailRequest);

            PlaceInfo markerinfo = new PlaceInfo();
            markerinfo.Name = result.result.name;
            markerinfo.Address = result.result.formatted_address;
            markerinfo.PlaceId = result.result.place_id;
            markerinfo.TextboxId = this.Name;
            markerinfo.Lat = result.result.geometry.location.lat;
            markerinfo.Lng = result.result.geometry.location.lng;

            Console.WriteLine(markerinfo.PlaceId);
            return markerinfo;  
        }
    }
}
