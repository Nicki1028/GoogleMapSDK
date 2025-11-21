using DIContainer;
using GoogleMapSDK.Core.PhotoItem;
using GoogleMapSDK.UI.Contract.API;
using GoogleMapSDK.UI.Contract.API.Place_Photo;
using GoogleMapSDK.UI.Contract.API.Places_Detail.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GoogleMapSDK.UI.Contract.Components.Photo.PhotoContract;

namespace GoogleMapSDK.UI.WPF.Components.Photo
{
    public class PlacePhotoView_WPF : BasePhoto_WPF
    {
        protected IPhotoPresenter presenter = null;
        public PlacePhotoView_WPF(PresenterFactory presenterFactory)
        {
            presenter = presenterFactory.Create<IPhotoPresenter, IPhotoView>(this, typeof(PlacePhotoPresenter));
        }
        public override async Task RenderPhotos(string placeId, int maxHeight)
        {
            _photos = await presenter.CollectPhotosAsync(placeId, maxHeight);
            RenderImages();
        }

    }
}
