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

namespace GoogleMapSDK.API.Place_Photo
{
    public class PlacePhotoServise
    {
        public Bitmap GetPhoto(PlacePhotoRequest placePhotoRequest)
        {
            BaseService baseService = new BaseService();

            string url = "https://maps.googleapis.com/maps/api/place/photo?" + baseService.ToUri(placePhotoRequest) + "&key=" + GoogleSigned.SigningInstance._key;
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
                { string url = "https://maps.googleapis.com/maps/api/place/photo?" + baseService.ToUri(placePhotoRequest) + "&key=" + GoogleSigned.SigningInstance._key;
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
