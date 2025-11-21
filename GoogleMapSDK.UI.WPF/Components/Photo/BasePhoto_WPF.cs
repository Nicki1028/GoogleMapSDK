using GoogleMapSDK.UI.Contract.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static GoogleMapSDK.UI.Contract.Components.Photo.PhotoContract;

namespace GoogleMapSDK.UI.WPF.Components.Photo
{
    /// <summary>
    /// BasePhotoItem.xaml 的互動邏輯
    /// </summary>
    public abstract class BasePhoto_WPF : UserControl, IPhotoView
    {
        protected List<System.Drawing.Bitmap> _photos;
        protected int counter = 0;

        protected System.Windows.Controls.Image image;
        protected Button previous;
        protected Button next;
        protected Grid myGrid;

        public BasePhoto_WPF()
        {
            InitializeComponent();           
        }
     
        protected BitmapSource ChangeBitmapToBitmapSource(System.Drawing.Bitmap bmp)
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
            // ===== 主容器 Grid =====
            Grid myGrid = new Grid();
            myGrid.Margin = new Thickness(20);

            // 背景深色漸層（類 WinUI / macOS 深色風）
            myGrid.Background = new System.Windows.Media.LinearGradientBrush(
                System.Windows.Media.Color.FromRgb(24, 26, 38),
                System.Windows.Media.Color.FromRgb(10, 12, 20),
                new Point(0, 0),
                new Point(1, 1));

            ColumnDefinition colDef1 = new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) };
            ColumnDefinition colDef2 = new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) };
            ColumnDefinition colDef3 = new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) };
            myGrid.ColumnDefinitions.Add(colDef1);
            myGrid.ColumnDefinitions.Add(colDef2);
            myGrid.ColumnDefinitions.Add(colDef3);

            RowDefinition rowDef1 = new RowDefinition();
            myGrid.RowDefinitions.Add(rowDef1);

            // ===== 中間圖片 + 外框陰影 =====
            image = new System.Windows.Controls.Image();
            image.Source = new BitmapImage(new Uri("C:\\Users\\USER\\Desktop\\image.jpg"));
            image.Stretch = Stretch.Uniform;
            image.Margin = new Thickness(0);
            image.Opacity = 1.0;

            Border imageBorder = new Border
            {
                Padding = new Thickness(8),
                CornerRadius = new CornerRadius(18),
                Background = new System.Windows.Media.SolidColorBrush(
                    System.Windows.Media.Color.FromArgb(220, 20, 20, 30)),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Effect = new System.Windows.Media.Effects.DropShadowEffect
                {
                    Color = Colors.Black,
                    BlurRadius = 25,
                    ShadowDepth = 5,
                    Opacity = 0.7
                }
            };
            imageBorder.Child = image;

            Grid.SetRow(imageBorder, 0);
            Grid.SetColumn(imageBorder, 1);
            myGrid.Children.Add(imageBorder);

            // ===== 按鈕樣式模板：圓角按鈕 =====
            FrameworkElementFactory borderFactory = new FrameworkElementFactory(typeof(Border));
            borderFactory.SetValue(Border.CornerRadiusProperty, new CornerRadius(20));
            borderFactory.SetValue(Border.BackgroundProperty,
                new TemplateBindingExtension(Button.BackgroundProperty));
            borderFactory.SetValue(Border.SnapsToDevicePixelsProperty, true);

            FrameworkElementFactory contentPresenterFactory =
                new FrameworkElementFactory(typeof(ContentPresenter));
            contentPresenterFactory.SetValue(ContentPresenter.HorizontalAlignmentProperty,
                HorizontalAlignment.Center);
            contentPresenterFactory.SetValue(ContentPresenter.VerticalAlignmentProperty,
                VerticalAlignment.Center);
            contentPresenterFactory.SetValue(ContentPresenter.MarginProperty, new Thickness(4, 0, 4, 0));

            borderFactory.AppendChild(contentPresenterFactory);

            ControlTemplate buttonTemplate = new ControlTemplate(typeof(Button));
            buttonTemplate.VisualTree = borderFactory;

            // ===== 本地函式：按鈕 hover 動畫（放大 + 發光） =====
            void AttachButtonHoverEffects(Button btn)
            {
                btn.RenderTransformOrigin = new Point(0.5, 0.5);
                btn.RenderTransform = new System.Windows.Media.ScaleTransform(1.0, 1.0);

                btn.MouseEnter += (s, e) =>
                {
                    var transform = btn.RenderTransform as System.Windows.Media.ScaleTransform;
                    if (transform == null)
                    {
                        transform = new System.Windows.Media.ScaleTransform(1.0, 1.0);
                        btn.RenderTransform = transform;
                    }

                    var anim = new System.Windows.Media.Animation.DoubleAnimation
                    {
                        To = 1.06,
                        Duration = new Duration(TimeSpan.FromMilliseconds(150))
                    };
                    transform.BeginAnimation(
                        System.Windows.Media.ScaleTransform.ScaleXProperty, anim);
                    transform.BeginAnimation(
                        System.Windows.Media.ScaleTransform.ScaleYProperty, anim);

                    btn.Effect = new System.Windows.Media.Effects.DropShadowEffect
                    {
                        Color = Colors.DeepSkyBlue,
                        BlurRadius = 18,
                        ShadowDepth = 0,
                        Opacity = 0.8
                    };
                };

                btn.MouseLeave += (s, e) =>
                {
                    var transform = btn.RenderTransform as System.Windows.Media.ScaleTransform;
                    if (transform == null)
                    {
                        transform = new System.Windows.Media.ScaleTransform(1.0, 1.0);
                        btn.RenderTransform = transform;
                    }

                    var anim = new System.Windows.Media.Animation.DoubleAnimation
                    {
                        To = 1.0,
                        Duration = new Duration(TimeSpan.FromMilliseconds(150))
                    };
                    transform.BeginAnimation(
                        System.Windows.Media.ScaleTransform.ScaleXProperty, anim);
                    transform.BeginAnimation(
                        System.Windows.Media.ScaleTransform.ScaleYProperty, anim);

                    btn.Effect = null;
                };
            }

            // ===== 本地函式：點擊時圖片滑動（左 / 右） + 淡入 =====
            void AttachSlideAnimation(Button btn, int direction)
            {
                // direction: -1 往左滑入, 1 往右滑入
                btn.Click += (s, e) =>
                {
                    var tt = image.RenderTransform as System.Windows.Media.TranslateTransform;
                    if (tt == null)
                    {
                        tt = new System.Windows.Media.TranslateTransform(0, 0);
                        image.RenderTransform = tt;
                    }

                    var moveAnim = new System.Windows.Media.Animation.DoubleAnimation
                    {
                        From = direction * 60,
                        To = 0,
                        Duration = new Duration(TimeSpan.FromMilliseconds(260)),
                        EasingFunction = new System.Windows.Media.Animation.CubicEase
                        {
                            EasingMode = System.Windows.Media.Animation.EasingMode.EaseOut
                        }
                    };
                    tt.BeginAnimation(
                        System.Windows.Media.TranslateTransform.XProperty, moveAnim);

                    var fadeAnim = new System.Windows.Media.Animation.DoubleAnimation
                    {
                        From = 0.6,
                        To = 1.0,
                        Duration = new Duration(TimeSpan.FromMilliseconds(260))
                    };
                    image.BeginAnimation(UIElement.OpacityProperty, fadeAnim);
                };
            }

            // ===== 本地函式：套共用按鈕外觀 =====
            void StyleNavButton(Button btn)
            {
                btn.Height = 40;
                btn.Width = 110;
                btn.FontSize = 18;
                btn.Foreground = Brushes.White;
                btn.Background = new System.Windows.Media.LinearGradientBrush(
                    System.Windows.Media.Color.FromRgb(70, 120, 220),
                    System.Windows.Media.Color.FromRgb(40, 80, 160),
                    new Point(0, 0),
                    new Point(1, 1));
                btn.BorderThickness = new Thickness(0);
                btn.Padding = new Thickness(12, 4, 12, 4);
                btn.HorizontalAlignment = HorizontalAlignment.Center;
                btn.VerticalAlignment = VerticalAlignment.Center;
                btn.Template = buttonTemplate;

                AttachButtonHoverEffects(btn);
            }

            // ===== 左邊 previous 按鈕 =====
            previous = new Button();
            previous.Content = "<<";
            StyleNavButton(previous);
            AttachSlideAnimation(previous, -1);

            Grid.SetRow(previous, 0);
            Grid.SetColumn(previous, 0);
            myGrid.Children.Add(previous);

            // ===== 右邊 next 按鈕 =====
            next = new Button();
            next.Content = ">>";
            StyleNavButton(next);
            AttachSlideAnimation(next, 1);

            Grid.SetRow(next, 0);
            Grid.SetColumn(next, 2);
            myGrid.Children.Add(next);

            // ===== 保持原本的功能事件 =====
            previous.Click += Button_ClickBackward;
            next.Click += Button_ClickForward;

            this.Content = myGrid;
        }

        // 建立按鈕圓角模板（在同一個檔案內，未新增任何類別）
        private FrameworkElementFactory GetButtonTemplate()
        {
            var border = new FrameworkElementFactory(typeof(Border));
            border.SetValue(Border.CornerRadiusProperty, new CornerRadius(20));
            border.SetValue(Border.BackgroundProperty, new TemplateBindingExtension(Button.BackgroundProperty));

            var contentPresenter = new FrameworkElementFactory(typeof(ContentPresenter));
            contentPresenter.SetValue(ContentPresenter.HorizontalAlignmentProperty, HorizontalAlignment.Center);
            contentPresenter.SetValue(ContentPresenter.VerticalAlignmentProperty, VerticalAlignment.Center);

            border.AppendChild(contentPresenter);
            return border;
        }

        public abstract Task RenderPhotos(string placeId, int maxHeight);
       
    }
}
