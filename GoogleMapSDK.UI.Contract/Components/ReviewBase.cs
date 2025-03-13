using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GoogleMapSDK.API.Places_Detail.PlacesDetailResponse;

namespace GoogleMapSDK.UI.Contract.Components
{
    public interface ReviewBase
    {
        List<Review> ReviewSource { set; }
       
        void InitializeComponent();
      
    }
}
