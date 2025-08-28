using GoogleMapSDK.Core.Models;
using GoogleMapSDK.UI.Contract.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GoogleMapSDK.UI.Contract.Components.AutoComplete.AutoCompleteContract;

namespace GoogleMapSDK.Core.AutoComplete
{
    public class EmployeeAutoCompletePresenter : IAutoCompletePresenter
    {
        public EmployeeAutoCompletePresenter(IAutoCompleteView employeeView) 
        {
          

        }

        public async Task<List<object>> GetDataSourceAsync(string query)
        {
            EmployeeModel employeeModel = new EmployeeModel();
            employeeModel.Name = query;
            employeeModel.Address = "桃園市";
            EmployeeModel employeeModel1 = new EmployeeModel();
            employeeModel1.Name = query;
            employeeModel1.Address = "台南市";
            List<object> list = new List<object>();
            list.Add(employeeModel1);
            list.Add(employeeModel);

            return list;
            
        }

        public Task<object> GetSelectItemAsync(string selectedValue)
        {
            EmployeeInfoModel employeeModel = new EmployeeInfoModel();
            employeeModel.ID = selectedValue;
            employeeModel.Number = "桃園市";

            object temp = employeeModel;
            return Task.FromResult(temp);


        }
    }
}
