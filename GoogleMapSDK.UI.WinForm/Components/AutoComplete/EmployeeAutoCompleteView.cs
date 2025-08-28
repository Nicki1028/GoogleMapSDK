using DIContainer;
using GoogleMapSDK.Core.AutoComplete;
using GoogleMapSDK.Core.Models;
using GoogleMapSDK.UI.Contract.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GoogleMapSDK.UI.Contract.Components.AutoComplete.AutoCompleteContract;

namespace GoogleMapSDK.UI.WinForm.Components.AutoComplete
{
    public class EmployeeAutoCompleteView : BaseAutoComplete<EmployeeModel, EmployeeInfoModel>
    {
        IAutoCompletePresenter presenter;
        public override string DisplayMember => "Name";
        public override string ValueMember => "Address";
        public EmployeeAutoCompleteView(PresenterFactory presenterfactory)
        {
            InitializeComponent();
            presenter = presenterfactory.Create<IAutoCompletePresenter, IAutoCompleteView>(this,typeof(EmployeeAutoCompletePresenter));

        }

        protected override async Task<IEnumerable<EmployeeModel>> GetCompleteSource(string input)
        {
            List<object> list = await presenter.GetDataSourceAsync(input);

            return list.Select(x => (EmployeeModel)x).ToList();

        }

        protected override async Task<EmployeeInfoModel> GetSelectItemAsync(string selectedItem)
        {
            var data = await presenter.GetSelectItemAsync(selectedItem);
            return (EmployeeInfoModel)data;

        }
    }
}
