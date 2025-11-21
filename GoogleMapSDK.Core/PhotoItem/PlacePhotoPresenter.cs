using GoogleMapSDK.UI.Contract.API;
using GoogleMapSDK.UI.Contract.API.Place_Photo;
using GoogleMapSDK.UI.Contract.API.Places_Detail.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GoogleMapSDK.UI.Contract.Components.Comment.ReviewContract;
using static GoogleMapSDK.UI.Contract.Components.Photo.PhotoContract;

namespace GoogleMapSDK.Core.PhotoItem
{
    public class PlacePhotoPresenter: IPhotoPresenter
    {
        IGoogleContext context = null;
        public PlacePhotoPresenter(IGoogleContext context, IPhotoView reviewView)
        {
            this.context = context;
        }

        public async Task<List<Bitmap>> CollectPhotosAsync(string placeId, int maxHeight)
        {
            PlacesDetailRequest placesDetailRequest = new PlacesDetailRequest();
            placesDetailRequest.place_id = placeId;

            var result = await context.PlaceDetail.GetPlaceDetail(placesDetailRequest);

            List<string> photoReferences = new List<string>();
            foreach (var info in result.result.photos)
            {
                photoReferences.Add(info.photo_reference);
                //Console.WriteLine(info.photo_reference);
            }

            List<Task<Bitmap>> photoTasks = new List<Task<Bitmap>>();

            foreach (var photoRef in photoReferences)
            {
                photoTasks.Add(Task.Run(() =>
                {
                    var photoRequest = new PlacePhotoRequest
                    {
                        photo_reference = photoRef,
                        maxheight = maxHeight
                    };
                    Console.WriteLine(photoRequest.photo_reference);
                    return context.PlacePhoto.GetPhoto(photoRequest);
                }));
                
            }
            
            List<Bitmap> allPhotos = (await Task.WhenAll(photoTasks)).ToList();
            return allPhotos;
        }
    }
}
