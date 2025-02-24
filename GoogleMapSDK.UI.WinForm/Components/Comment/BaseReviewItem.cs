using GoogleMapSDK.API.Places_Detail;
using static GoogleMapSDK.API.Places_Detail.PlacesDetailResponse;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoogleMapSDK.UI.WinForm.Components.Comment
{
    internal class BaseReviewItem:BaseReview
    {
        public BaseReviewItem()
        {

        }

        public override PlacesDetailResponse.Review[] ReviewSource
        {
            set
            {
                this._reviews = value;               
            }
        }
        
        
    }
}
