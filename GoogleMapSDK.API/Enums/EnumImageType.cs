using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API.Enums
{
    public enum EnumImageType
    {
        Unspecified = 0,
		/// <summary>
		/// (default) specifies the 8-bit PNG format
		/// </summary>
		PNG = 1,
		/// <summary>
		/// specifies the 8-bit PNG format
		/// </summary>
		PNG8 = 1,
		/// <summary>
		/// specifies the 32-bit PNG format
		/// </summary>
		PNG32 = 2,
		/// <summary>
		/// specifies the GIF format
		/// </summary>
		GIF = 4,
		/// <summary>
		/// specifies the JPEG compression format
		/// </summary>
		JPG = 5,
		/// <summary>
		/// specifies a non-progressive JPEG compression format
		/// </summary>
		JPGbaseline = 6
    }
}
