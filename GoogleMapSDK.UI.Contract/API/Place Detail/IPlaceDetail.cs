
using GoogleMapSDK.UI.Contract.API.Places_Detail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.UI.Contract.API.Place_Detail
{
    public interface IPlaceDetail
    {
        Task<PlacesDetailResponse> GetPlaceDetail(PlacesDetailRequest placesdetailRequest);
    }
}
