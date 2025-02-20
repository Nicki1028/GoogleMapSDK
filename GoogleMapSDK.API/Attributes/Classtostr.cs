using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API.Attributes
{
    internal class Classtostr:Attribute
    {
        public string _rename { get; set; }
        public string _symbol { get; set; }
        public Classtostr(string rename, string symbol) 
        { 
            this._rename = rename;
            this._symbol = symbol;
        }
    }
}
