using GoogleMapSDK.UI.Contract.Components;
using GoogleMapSDK.UI.WinForm.Components.Photo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GoogleMapSDK.UI.WPF.Components.Photo
{
    /// <summary>
    /// BasePhotoItem.xaml 的互動邏輯
    /// </summary>
    public abstract class BasePhoto_WPF : UserControl, PhotoBase
    {
        protected List<Bitmap> _photos;
        protected int counter = 0;

        protected System.Windows.Controls.Image image;
        protected Button previous;
        protected Button next;
        protected Grid myGrid;

        public abstract List<Bitmap> ImageSource { set; }

        public BasePhoto_WPF()
        {

            InitializeComponent();
            previous.Click += Button_ClickBackward;
            next.Click += Button_ClickForward;
        }

        

        int PhotoBase.index => counter;

        protected BitmapSource ChangeBitmapToBitmapSource(Bitmap bmp)
        {
            BitmapSource returnSource;
            try
            {
                returnSource = Imaging.CreateBitmapSourceFromHBitmap(bmp.GetHbitmap(),
                    IntPtr.Zero,
                    Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions());
            }
            catch
            {
                returnSource = null;
            }
            return returnSource;
        }
        protected void RenderImages()
        {
            if (_photos.Count > 0)
            {
                counter = 0;
                image.Source = ChangeBitmapToBitmapSource(_photos[counter]);
                counter = counter + 1 < _photos.Count ? counter + 1 : counter;
            }
        }
        public void MoveNext()
        {
            if (counter + 1 < _photos.Count)
            {
                counter++;
                image.Source = ChangeBitmapToBitmapSource(_photos[counter]);
            }
            UpdateButtonState_Startphoto();
        }
        public void MovePrevious()
        {
            if (counter - 1 >= 0)
            {
                counter--;
                image.Source = ChangeBitmapToBitmapSource(_photos[counter]);
            }
            UpdateButtonState_Finalphoto();
        }
        public void UpdateButtonState_Finalphoto()
        {
            next.IsEnabled = counter < _photos.Count;
            previous.IsEnabled = counter > 0;
        }
        public void UpdateButtonState_Startphoto()
        {
            next.IsEnabled = counter + 1 < _photos.Count;
            previous.IsEnabled = counter > 0;
        }
        public void Button_ClickBackward(object sender, EventArgs e)
        {
            MovePrevious();
        }

        public void Button_ClickForward(object sender, EventArgs e)
        {
            MoveNext();
        }
        public void InitializeComponent()
        {
            Grid myGrid = new Grid();
            myGrid.Width = 700;
            myGrid.Height = 200;
            myGrid.HorizontalAlignment = HorizontalAlignment.Left;
            myGrid.VerticalAlignment = VerticalAlignment.Top;


            ColumnDefinition colDef1 = new ColumnDefinition();
            ColumnDefinition colDef2 = new ColumnDefinition();
            ColumnDefinition colDef3 = new ColumnDefinition();
            myGrid.ColumnDefinitions.Add(colDef1);
            myGrid.ColumnDefinitions.Add(colDef2);
            myGrid.ColumnDefinitions.Add(colDef3);

            RowDefinition rowDef1 = new RowDefinition();
            RowDefinition rowDef2 = new RowDefinition();
            RowDefinition rowDef3 = new RowDefinition();
            myGrid.RowDefinitions.Add(rowDef1);
            myGrid.RowDefinitions.Add(rowDef2);
            myGrid.RowDefinitions.Add(rowDef3);


            image = new System.Windows.Controls.Image();
            image.Source = new BitmapImage(new Uri("C:\\Users\\USER\\Desktop\\image.jpg"));
            image.Height = 200;
            image.Width = 200;
            image.Stretch = Stretch.Uniform;
            Grid.SetRow(image, 0);
            Grid.SetRowSpan(image, 3);
            Grid.SetColumn(image, 1);
            myGrid.Children.Add(image);

            previous = new Button();
            previous.Height = 30;
            previous.Width = 100;
            previous.Content = "<<";
            Grid.SetRow(previous, 1);
            Grid.SetColumn(previous, 0);
            myGrid.Children.Add(previous);

            next = new Button();
            next.Height = 30;
            next.Width = 100;
            next.Content = ">>";
            Grid.SetRow(next, 1);
            Grid.SetColumn(next, 2);
            myGrid.Children.Add(next);

            this.Content = myGrid;
        }
    }
}
