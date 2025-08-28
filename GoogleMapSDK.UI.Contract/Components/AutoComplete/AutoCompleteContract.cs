using GoogleMapSDK.UI.Contract.API.Models;
using GoogleMapSDK.UI.Contract.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.UI.Contract.Components.AutoComplete
{
    public class AutoCompleteContract
    {
        public interface IAutoCompleteView
        {
            object DataSource { get; set; }
            string DisplayMember { get; }
            string ValueMember { get; }
            
           
            void InitializeComponent();
            void ResetListBox();
            void UpdateListBox();
            void ShowListBox();

            //Event 要求要註冊的事件
            void BaseAutoComplete_ItemSelectedAsync(object sender, EventArgs e);
            void AutoCompelte_KeyUp(object sender, ConsoleKey key);
            Task AutoComplete_KeyDown(object sender, ConsoleKey key);          
           
        }

        public interface IAutoCompletePresenter
        {
            //TODO: 思考如何約束 object 避免再多轉型一次
            //功能 事件觸發後要求要實作的功能
            Task<List<object>> GetDataSourceAsync(string query);
            //Task<List<AutoCompleteModel>> GetDataSourceAsync(string query);
            Task<object> GetSelectItemAsync(string selectedValue);
            //Task<PlaceInfo> GetSelectItemAsync(string selectedValue);
        }
    }
}
