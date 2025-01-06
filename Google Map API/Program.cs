using Google_Map_API.Direction;
using Google_Map_API.Geocoding;
using Google_Map_API.Place_Photo;
using Google_Map_API.Places;
using Google_Map_API.Places_Detail;
using Google_Map_API.StaticMaps;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Google_Map_API
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            GoogleContext context = new GoogleContext(new GoogleSigned());
            GeocodingRequest geocodingRequest = new GeocodingRequest();
            StaticMapRequest staticMapRequest = new StaticMapRequest();
            PlacesDetailRequest placesDetailRequest = new PlacesDetailRequest();
            TextSearchRequest textSearchRequest = new TextSearchRequest();
            NearbySearchRequest nearbySearchRequest = new NearbySearchRequest();
            PlaceSearchRequest placeSearchRequest = new PlaceSearchRequest();
            AutoCompleteRequest autoCompleteRequest = new AutoCompleteRequest();
            PlacePhotoRequest placePhotoRequest = new PlacePhotoRequest();
            DirectionRequest directionRequest = new DirectionRequest();
            directionRequest.destination = "國立中央大學";
            directionRequest.origin = "我家牛排桃園春日店";
            ////directionRequest.Addwaypoint("中壢高中");
            //var result = await context.Direction.Direction(directionRequest);
            //foreach (var item in result.routes)
            //{
            //    Console.WriteLine(item.legs);
            //    Console.WriteLine(item.bounds.southwest.lat);
            //    Console.WriteLine(item.bounds.northeast.lng);
            //    Console.WriteLine(item.bounds.northeast.lat);
            //}

            //placePhotoRequest.photo_reference = "AelY_CudRrCxsNnjMe23MhVNeSzbp53PcBYq36MEbVQYNN7rRRAq5LIT_A_VfTd_2RQ68yP2uk5IU0JEqEocaeWTYgHcn5YkNouuBhAkgHp-PlXw8kur9VE-23HdvyEh3OaqKeNLz5-BeMArfmEGchqk4Aq2kbPr0Oge_pVTeZknwW60t5Os";
            //placePhotoRequest.maxheight = 100;

            //autoCompleteRequest.input = "我家牛排桃園春日店";
            //var r = await context.AutoComplete.AutoCompleteSearch(autoCompleteRequest);
            //foreach (var i in r.predictions)
            //{
            //    Console.WriteLine(i.place_id);
            //}

            //placeSearchRequest.input = "我家牛排桃園春日店";
            //placeSearchRequest.inputtype = "textquery";
            //placeSearchRequest.searchtype = Enums.EnumPlaceSearchtype.Basic;
            //var re = await context.PlaceSearch.PlaceSearch(placeSearchRequest);
            //foreach (var i in re.candidates)
            //{
            //    Console.WriteLine(i.geometry.location.lat);
            //}

            //textSearchRequest.query = "我家牛排";
            //textSearchRequest.radius = 1000;
            //var data = await context.NearbyAndText.TextSearch(textSearchRequest);
            //foreach (var item in data.results)
            //{
            //    Console.WriteLine(item.name);
            //    Console.WriteLine(item.rating);
            //}

            //nearbySearchRequest.location = new Location(24.966393, 121.1919558);
            //nearbySearchRequest.radius = 1000;
            //var result = await context.NearbyAndText.NearbySearch(nearbySearchRequest);
            //foreach (var item in result.results)
            //{
            //    Console.WriteLine(item.name);
            //    Console.WriteLine(item.geometry);
            //}

            //staticMapRequest.center = "我家牛排桃園春日店";
            //staticMapRequest.size = new Mapsize(400, 400);
            //staticMapRequest.zoom = 15;

            //geocodingRequest.address = "我家牛排桃園春日店";

            //var data = await context.Geocoding.GetPostion(geocodingRequest);
            ////var data =  context.StaticMap.GetStream(staticMapRequest);

            //foreach (var item in data.results)
            //{
            //    Console.WriteLine(item.place_id);
            //    Console.WriteLine(item.formatted_address);
            //}

            placesDetailRequest.place_id = "ChIJXQy7EvkeaDQRmdRXwKhr5OY";
            var result = await context.PlacesDetail.GetPlaceDetail(placesDetailRequest);
            Console.WriteLine($"result: {result.result.reviews}");
            Console.WriteLine($"result: {result.result.formatted_phone_number}");
            Console.WriteLine($"result: {result.result.photos}");
            foreach (var intem in result.result.photos)
            {
                Console.WriteLine(intem.photo_reference);
            }
            //Form1 form1 = new Form1();
            //form1.ShowDialog();

            Console.ReadKey();
        }
    }
}
