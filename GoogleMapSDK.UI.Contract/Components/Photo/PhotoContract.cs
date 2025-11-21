using GoogleMapSDK.UI.Contract.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.UI.Contract.Components.Photo
{
    public class PhotoContract
    {
        public interface IPhotoView
        {
            Task RenderPhotos(string placeId, int maxHeight);
            void InitializeComponent();
            void Button_ClickForward(object sender, EventArgs e);
            void Button_ClickBackward(object sender, EventArgs e);
        }

        public interface IPhotoPresenter
        {
            Task<List<Bitmap>> CollectPhotosAsync(string placeId, int maxHeight);

        }
    }
}
