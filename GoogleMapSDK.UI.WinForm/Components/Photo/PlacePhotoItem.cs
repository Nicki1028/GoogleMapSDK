using GoogleMapSDK.API.Place_Photo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using GoogleMapSDK.API.Places_Detail;
using System.Runtime.Remoting.Contexts;
using GoogleMapSDK.API;
using System.Windows.Forms;

namespace GoogleMapSDK.UI.WinForm.Components.Photo
{
    public partial class PlacePhotoItem : BasePhoto
    {
        GoogleContext context = GoogleContext.GetGoogleContext();
        public override List<Bitmap> ImageSource 
        {
            set
            {
                this._photos = value;
                RenderImages();
            }
        }

        public PlacePhotoItem() 
        {
        }
        public async Task<List<Bitmap>> CollectPhotosAsync(string placeId, int maxHeight)
        {
            PlacesDetailRequest placesDetailRequest = new PlacesDetailRequest();
            placesDetailRequest.place_id = placeId;

            var result = await context.PlacesDetail.GetPlaceDetail(placesDetailRequest);

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
                    return context.PlacePhoto.GetPhoto(photoRequest);
                }));
            }

            List<Bitmap> allPhotos = (await Task.WhenAll(photoTasks)).ToList();
            return allPhotos;
        }
        
        private void button1_Click(object sender, EventArgs e) => Button_ClickForward(sender, e);
        private void button2_Click(object sender, EventArgs e) => Button_ClickBackward(sender, e);

    }
}

