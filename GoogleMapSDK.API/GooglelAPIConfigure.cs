using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API
{
    public class GoogleAPIConfigure
    {
        public string apikey {  get; set; }
        public GoogleAPIConfigure(string key)
        {
            this.apikey = key;
        }
    }



    public class GoogleAPIConfig
    {
        public string apikey { get; set; }
        public string defaultPlace { get; set; }
        
    }
}
