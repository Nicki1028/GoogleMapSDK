using GoogleMapSDK.API.Places_Detail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GoogleMapSDK.API.Places_Detail.PlacesDetailResponse;

namespace GoogleMapSDK.UI.WPF.Comment
{
    internal class BaseReviewItem_WPF : BaseReview_WPF
    {
        public BaseReviewItem_WPF()
        {

        }

        public override List<Review> ReviewSource
        {
            set
            {
                this._reviews = value;
                InitializeComponent();
            }
        }
    }
}
