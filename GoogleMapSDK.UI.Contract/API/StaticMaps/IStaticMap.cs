
using GoogleMapSDK.UI.Contract.API.StaticMaps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.UI.Contract.API.StaticMaps
{
    public interface IStaticMap
    {
        string GetStream(StaticMapRequest staticmapRequest);
    }
}
 