using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.UI.Contract.API.StaticMaps
{
    public class Mapsize
    {
        public int _Width { get; set; }
        public int _Height { get; set; }
        public Mapsize(int width, int height) 
        {
            _Width = width;
            _Height = height;
        }

    }
}
