using GoogleMapSDK.API.Places;
using HttpUtility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using GoogleMapSDK.UI.Contract.API.Place_Photo;
using GoogleMapSDK.UI.Contract.API;
using Microsoft.Extensions.Options;

namespace GoogleMapSDK.API.Place_Photo
{
    public class PlacePhoto: BaseGoogleAPI, IPlacePhoto
    {
        public PlacePhoto(HttpUtility.HttpRequest httpRequest, GoogleAPIConfigure apiConfig) : base(httpRequest, apiConfig)
        {
        }

        public Bitmap GetPhoto(PlacePhotoRequest placePhotoRequest)
        {
            BaseService baseService = new BaseService();

            string url = "https://maps.googleapis.com/maps/api/place/photo?" + baseService.ToUri(placePhotoRequest) + "&key=" + _apiConfig.apikey;
            System.Net.WebRequest request = System.Net.WebRequest.Create(url);
            System.Net.WebResponse response = request.GetResponse();
            System.IO.Stream responseStream = response.GetResponseStream();
            Bitmap bitmap = new Bitmap(responseStream);

            return bitmap;
        }

        public async Task<List<Bitmap>> GetPhotos(List<PlacePhotoRequest> placePhotoRequests)
        {
            BaseService baseService = new BaseService();
            List<Bitmap> photos = new List<Bitmap>();
            List<Task> tasks = new List<Task>();

            foreach (var placePhotoRequest in placePhotoRequests)
            {
                tasks.Add(Task.Run(() =>
                { string url = "https://maps.googleapis.com/maps/api/place/photo?" + baseService.ToUri(placePhotoRequest) + "&key=" + _apiConfig.apikey;
                    System.Net.WebRequest request = System.Net.WebRequest.Create(url);
                    System.Net.WebResponse response = request.GetResponse();
                    System.IO.Stream responseStream = response.GetResponseStream();
                    Bitmap bitmap = new Bitmap(responseStream);
                    photos.Add(bitmap);
                }));
            }
            await Task.WhenAll(tasks);

            return photos;
        }

    }
}
