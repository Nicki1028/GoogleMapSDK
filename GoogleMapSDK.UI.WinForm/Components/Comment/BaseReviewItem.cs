using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GoogleMapSDK.UI.Contract.API.Places_Detail.Models.PlacesDetailResponse;

namespace GoogleMapSDK.UI.WinForm.Components.Comment
{
    public class BaseReviewItem:BaseReview
    {
        public BaseReviewItem()
        {
            InitializeComponent();
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
