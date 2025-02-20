using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.UI.Contract.Components
{
    public interface PhotoBase
    {
        List<Bitmap> ImageSource { set;  }
        int index { get; }

        void InitializeComponent();

        void Button_ClickForward(object sender, EventArgs e);

        void Button_ClickBackward(object sender, EventArgs e);
    }
}
