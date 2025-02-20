using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API
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
            // 確保不在設計階段才執行檢查
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                return;
            }
           _key = ConfigurationManager.AppSettings["apikey"];  
           if (string.IsNullOrEmpty(_key))
            {
                throw new Exception("尚未輸入Apikey");
            }
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
