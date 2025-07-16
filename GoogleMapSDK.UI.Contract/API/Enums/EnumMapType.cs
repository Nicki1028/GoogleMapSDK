using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.UI.Contract.API.StaticMaps
{
    public enum EnumMapType
    {
        Unspecified = 0,
		/// <summary>
		/// Roadmap
		/// </summary>
		Roadmap = 1,
		/// <summary>
		/// Satellite
		/// </summary>
		Satellite = 2,
		/// <summary>
		/// Hybrid
		/// </summary>
		Hybrid = 3,
		/// <summary>
		/// Terrain
		/// </summary>
		Terrain = 4
    }
}
