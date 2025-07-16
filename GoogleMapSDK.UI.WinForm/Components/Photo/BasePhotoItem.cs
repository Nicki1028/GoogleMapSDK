using GoogleMapSDK.UI.Contract.API;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.UI.WinForm.Components.Photo
{
    public class BasePhotoItem : BasePhoto
    {
        public BasePhotoItem(IGoogleContext context) : base(context)
        {
        }

        public override List<Bitmap> ImageSource
        {
            set
            {
                
                this._photos = value;
                RenderImages();
            }
        }
        
    }
}
