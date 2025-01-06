using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google_Map_API
{
    public class GoogleSigned
    {
        public string _key;

        private static GoogleSigned _universalSigningInstance;

        public GoogleSigned(string apikey)
        {
            _key = apikey;
        }

        public GoogleSigned()
        {
           _key = ConfigurationManager.AppSettings["apikey"];            
        }

        public static GoogleSigned SigningInstance
        {
            get { return _universalSigningInstance; }
        }
        public static void AssignAllServices(GoogleSigned signingInstance)
        {
            _universalSigningInstance = signingInstance;
        }

    }
}
