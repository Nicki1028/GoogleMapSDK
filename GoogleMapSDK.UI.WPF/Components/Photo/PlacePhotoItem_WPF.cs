using GoogleMapSDK.UI.Contract.API;
using GoogleMapSDK.UI.Contract.API.Place_Photo;
using GoogleMapSDK.UI.Contract.API.Places_Detail.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.UI.WPF.Components.Photo
{
    internal class PlacePhotoItem_WPF : BasePhoto_WPF
    {
        public override List<Bitmap> ImageSource
        {
            set
            {
                base._photos = value;
                base.RenderImages();
            }
        }

        private IGoogleContext _googleContext;
        public PlacePhotoItem_WPF(IGoogleContext googleContext)
        {
            this._googleContext = googleContext;
        }
        public async Task<List<Bitmap>> CollectPhotosAsync(string placeId, int maxHeight)
        {
            PlacesDetailRequest placesDetailRequest = new PlacesDetailRequest();
            placesDetailRequest.place_id = placeId;

            var result = await _googleContext.PlaceDetail.GetPlaceDetail(placesDetailRequest);

            List<string> photoReferences = new List<string>();
            foreach (var info in result.result.photos)
            {
                photoReferences.Add(info.photo_reference);
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
                    return _googleContext.PlacePhoto.GetPhoto(photoRequest);
                }));
            }
            List<Bitmap> allPhotos = (await Task.WhenAll(photoTasks)).ToList();
            return allPhotos;
        }

        private void button1_Click(object sender, EventArgs e) => Button_ClickForward(sender, e);
        private void button2_Click(object sender, EventArgs e) => Button_ClickBackward(sender, e);

    }
}
