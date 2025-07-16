using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.UI.Contract.API.Place_Photo
{
    public interface IPlacePhoto
    {
        Bitmap GetPhoto(PlacePhotoRequest placePhotoRequest);

        Task<List<Bitmap>> GetPhotos(List<PlacePhotoRequest> placePhotoRequests);

    }
}
