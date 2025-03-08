using GMap.NET;
using GoogleMapSDK.API;
using GoogleMapSDK.API.Geocoding;
using GoogleMapSDK.API.Places;
using GoogleMapSDK.API.Places_Detail;
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
        public MarkerContext(MapControl mapControl) 
        { 
            this._mapControl = mapControl;
        }
        GoogleContext context = new GoogleContext();
        public async void SetMarkerPosition(string placeId)
        {
            PlacesDetailRequest placesDetailRequest = new PlacesDetailRequest();
            placesDetailRequest.place_id = placeId;
            var result = await context.PlacesDetail.GetPlaceDetail(placesDetailRequest);

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
            var result = await context.Geocoding.GetPostion(geocodingRequest);

            PlacesDetailRequest placesDetailRequest = new PlacesDetailRequest();
            placesDetailRequest.place_id = result.results[0].place_id;
            var data = await context.PlacesDetail.GetPlaceDetail(placesDetailRequest);

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
