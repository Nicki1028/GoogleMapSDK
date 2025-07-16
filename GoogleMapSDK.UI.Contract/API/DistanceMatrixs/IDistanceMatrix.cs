
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.UI.Contract.API.DistanceMatrixs
{
    public interface IDistanceMatrix
    {
        Task<DistanceMatrixResponse> GetDistance(string des, string ori, string key, string language);
    }
}
