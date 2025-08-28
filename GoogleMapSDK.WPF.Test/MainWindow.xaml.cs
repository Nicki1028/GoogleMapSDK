using GoogleMapSDK.UI.Contract.API.Models;
using GoogleMapSDK.UI.WPF.Components.AutoComplete;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static GoogleMapSDK.UI.Contract.Components.AutoComplete.AutoCompleteContract;

namespace GoogleMapSDK.WPF.Test
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IEnumerable<IAutoCompleteView> autoCompletes)
        {
            InitializeComponent();
            PlaceAutoComplete completeView = (PlaceAutoComplete)autoCompletes.First(x => x.GetType() == typeof(PlaceAutoComplete));
            completeView.Height = 30;
            completeView.Width = 400;
            container.Children.Add(completeView);
            completeView.OnSelectItem += CompleteView_OnSelectItem;
        }

        private void CompleteView_OnSelectItem(object sender, PlaceInfo e)
        {
            Debug.WriteLine(e.Name);
        }
    }
}
