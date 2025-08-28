using GoogleMapSDK.UI.Contract.API;
using GoogleMapSDK.UI.Contract.API.Models;
using GoogleMapSDK.UI.Contract.API.Places;
using GoogleMapSDK.UI.Contract.API.Places_Detail.Models;
using GoogleMapSDK.UI.Contract.Components;
using GoogleMapSDK.UI.Contract.Models;
using GoogleMapSDK.UI.WinForm.Components.AutoComplete;
using GoogleMapSDK.UI.WinForm.Components.Comment;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GoogleMapSDK.UI.Contract.Components.AutoComplete.AutoCompleteContract;

namespace GoogleMapSDK.WinForm.Test
{
    public partial class Form1 : Form
    {
       // private IGoogleMap _map;
        public Form1(IEnumerable<IAutoCompleteView> autoCompletes)
        {
            InitializeComponent();
            PlaceAutoCompleteView completeView = (PlaceAutoCompleteView)autoCompletes.First(x => x.GetType() == typeof(PlaceAutoCompleteView));
            EmployeeAutoCompleteView empAutoCompleteView = (EmployeeAutoCompleteView)autoCompletes.First(x => x.GetType() ==typeof(EmployeeAutoCompleteView)); 
            // this.Controls.Add((Control)autoCompleteBase);
            //this._googlecontext = context;
            //this._map = map;
            //this.Controls.Add((Control)this._map);
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.Controls.Add(completeView);
            flowLayoutPanel.Controls.Add(empAutoCompleteView);
            this.Controls.Add(flowLayoutPanel);
            

            completeView.OnSelectItem += CompleteView_OnSelectItem;
            empAutoCompleteView.OnSelectItem += EmpAutoCompleteView_OnSelectItem;

        }

        private void EmpAutoCompleteView_OnSelectItem(object sender, Core.Models.EmployeeInfoModel e)
        {
            Console.WriteLine(e.ID);
        }

        private void CompleteView_OnSelectItem(object sender, UI.Contract.API.Models.PlaceInfo e)
        {
            Console.WriteLine(e.Address);
        }
    }
}
