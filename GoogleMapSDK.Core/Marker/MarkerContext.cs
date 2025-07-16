using GMap.NET;
using GoogleMapSDK.UI.Contract.API;
using GoogleMapSDK.UI.Contract.API.Geocodings.Models;
using GoogleMapSDK.UI.Contract.API.Models;
using GoogleMapSDK.UI.Contract.API.Places_Detail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Core.Marker
{
   public class MarkerContext
    {
        public MapControl _mapControl;
        private IGoogleContext _googlecontext;
        public MarkerContext(MapControl mapControl, IGoogleContext googleContext) 
        { 
            this._mapControl = mapControl;
            this._googlecontext = googleContext;
        }
       
        public async void SetMarkerPosition(string placeId)
        {
            PlacesDetailRequest placesDetailRequest = new PlacesDetailRequest();
            placesDetailRequest.place_id = placeId;
            var result = await _googlecontext.PlaceDetail.GetPlaceDetail(placesDetailRequest);

            PointLatLng markerdestination = new PointLatLng(result.result.geometry.location.lat, result.result.geometry.location.lng);
            PlaceInfo markerinfo = new PlaceInfo();
            markerinfo.Name = result.result.name;
            markerinfo.Address = result.result.formatted_address;
            markerinfo.PlaceId = result.result.place_id;
            markerinfo.TextboxId = result.result.name;
            markerinfo.Lat = result.result.geometry.location.lat;
            markerinfo.Lng = result.result.geometry.location.lng;

            this._mapControl.AddMarker(markerdestination, "mapoverlay", markerinfo);
            this._mapControl.SetCenter(markerinfo.Lat, markerinfo.Lng);
        }

        public async void SetMarkerPosition(Location point)
        {
            GeocodingRequest geocodingRequest = new GeocodingRequest();
            geocodingRequest.Location = point;
            var result = await _googlecontext.Geocoding.GetPostion(geocodingRequest);

            PlacesDetailRequest placesDetailRequest = new PlacesDetailRequest();
            placesDetailRequest.place_id = result.results[0].place_id;
            var data = await _googlecontext.PlaceDetail.GetPlaceDetail(placesDetailRequest);

            PointLatLng markerdestination = new PointLatLng(data.result.geometry.location.lat, data.result.geometry.location.lng);
            PlaceInfo markerinfo = new PlaceInfo();
            markerinfo.Name = data.result.name;
            markerinfo.Address = data.result.formatted_address;
            markerinfo.PlaceId = data.result.place_id;
            markerinfo.TextboxId = data.result.name;          
            markerinfo.Lat = data.result.geometry.location.lat;
            markerinfo.Lng = data.result.geometry.location.lng;

            this._mapControl.AddMarker(markerdestination, "mapoverlay", markerinfo);
            this._mapControl.SetCenter(markerinfo.Lat, markerinfo.Lng);
        }
    }
}
