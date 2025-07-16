
using GoogleMapSDK.UI.Contract.API.Directions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.UI.Contract.API.Directions
{
    public interface IDirection
    {
        Task<DirectionResponse> GetDirection(DirectionRequest directionRequest);

        string WaypointstoUrl(DirectionRequest directionRequest);
    }
}
