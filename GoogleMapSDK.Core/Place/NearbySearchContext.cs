using GMap.NET;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms;
using GoogleMapSDK.API;
using GoogleMapSDK.API.Places;
using GoogleMapSDK.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoogleMapSDK.Core.Place
{
    public class NearbySearchContext: GoogleContext
    {
        public async Task<List<NearbySearchModel>> NearbySearch(string destination, int radius)
        {
           
            TextSearchRequest textSearchRequest = new TextSearchRequest();
            {
                textSearchRequest.query = destination;
                textSearchRequest.radius = radius;
            };
            var result = await MapAPIContext.NearbyAndText.TextSearch(textSearchRequest);
            var res = result.results.Select(x => new NearbySearchModel
            {
                NearbySearchPoint = new PointLatLng(x.geometry.location.lat, x.geometry.location.lng),
                NearbySearchName = x.name,

            }).ToList();

            return res ;
        }
        
    }
}
