using GoogleMapSDK.UI.WinForm.Components.Photo;
using GoogleMapSDK.UI.WPF.Components.Photo;
using System;
using System.Collections.Generic;
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

namespace GoogleMapSDK.UI.WPF
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BasePhotoItem_WPF basePhoto = new BasePhotoItem_WPF();
            
               
            this.container.Children.Add(basePhoto);
            

        }
    }
}
