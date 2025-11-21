using GoogleMapSDK.UI.Contract.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GoogleMapSDK.UI.Contract.API.Places_Detail.Models.PlacesDetailResponse;

namespace GoogleMapSDK.UI.Contract.Components.Comment
{
    public class ReviewContract
    {
        public interface IReviewView
        {
            Task RenderReviewDatas<T>(string placeId) where T : ReviewModel;
            void InitializeComponent();
        }

        public interface IReviewPresenter
        {
            Task<List<T>> GetReviewsAsync<T>(string placeId) where T : ReviewModel;

        }
    }
}
