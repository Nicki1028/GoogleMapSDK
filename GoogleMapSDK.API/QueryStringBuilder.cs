using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API
{
    internal class QueryStringBuilder
    {
        public string url = "";
        private Dictionary<string, string> _parameters = new Dictionary<string, string>();
        public void Append(string key, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                _parameters.Add(key, value);             

            }    
        }
        public void Restructure(string key, string symbol)
        {
            string redata = "";
            List<string> keys = new List<string>();
            foreach (var kvp in _parameters)
            {
                if (kvp.Key.Contains("Re-"))
                {
                    keys.Add(kvp.Key);                  
                    redata += kvp.Value + symbol;
                }
            }
            foreach (var item in keys)
            {
                _parameters.Remove(item);
            }
            redata = redata.Substring(0, redata.Length - symbol.Length);
            _parameters.Add(key, redata);

        }

        public string GetValue(string key)
        {
            return _parameters.TryGetValue(key, out var value) ? value : null;
        }

        public void Delete(string key)
        {
            if (!string.IsNullOrEmpty(key))
            {
                _parameters.Remove(key);
            }
        }

        public string Combine()
        {
            foreach (var kvp in _parameters)
            {
                url = url + kvp.Key + "=" + kvp.Value + "&";
            }
            return url;
        }
    }
}
