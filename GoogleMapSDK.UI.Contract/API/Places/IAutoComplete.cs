using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.UI.Contract.API.Places
{
    public interface IAutoComplete
    {
        Task<AutoCompleteResponse> AutoCompleteSearch(AutoCompleteRequest autoCompleteRequest);
    }
}
