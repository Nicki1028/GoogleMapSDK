using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.UI.WPF.Components.Photo
{
        public class BasePhotoItem_WPF : BasePhoto_WPF
        {
            public BasePhotoItem_WPF()
            {
             
            }
            public override List<Bitmap> ImageSource
            {
                set
                {
                    base._photos = value;
                    base.RenderImages();
                }
            }
        }
    
}
