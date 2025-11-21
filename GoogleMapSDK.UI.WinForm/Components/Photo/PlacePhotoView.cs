using DIContainer;
using GoogleMapSDK.Core.PhotoItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GoogleMapSDK.UI.Contract.Components.Photo.PhotoContract;

namespace GoogleMapSDK.UI.WinForm.Components.Photo
{
    public class PlacePhotoView : BasePhoto
    {
        protected IPhotoPresenter presenter = null;
        public PlacePhotoView(PresenterFactory presenterFactory) 
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
