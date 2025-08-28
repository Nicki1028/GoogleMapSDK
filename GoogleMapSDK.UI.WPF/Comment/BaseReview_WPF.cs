using GoogleMapSDK.UI.Contract.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using Brushes = System.Windows.Media.Brushes;
using Image = System.Windows.Controls.Image;
using static GoogleMapSDK.UI.Contract.API.Places_Detail.Models.PlacesDetailResponse;

namespace GoogleMapSDK.UI.WPF.Comment
{
    public abstract class BaseReview_WPF : UserControl, ReviewBase
    {
        public abstract List<Review> ReviewSource { set; }

        protected List<Review> _reviews;

        protected Review review;

        private ScrollViewer scrollViewer;

        private StackPanel mainPanel;
        public BaseReview_WPF()
        {
            this.SizeChanged += BaseReview_SizeChanged;
        }

        private void BaseReview_SizeChanged(object sender, EventArgs e)
        {
            if (this._reviews != null)
                InitializeComponent();
        }

        public void InitializeComponent()
        {
            this.Content = null;
            scrollViewer = new ScrollViewer
            {
                Height = 400,
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto
            };

            mainPanel = new StackPanel
            {
                Orientation = Orientation.Vertical
            };

            scrollViewer.Content = mainPanel;
            this.Content = scrollViewer;

            if (_reviews != null)
            {
                foreach (Review review in _reviews)
                {
                    mainPanel.Children.Add(LoadReview(review));
                }
            }
        }
       
        public UIElement LoadReview(Review review)
        {
            Border reviewBorder = new Border
            {
                BorderThickness = new Thickness(1),
                BorderBrush = Brushes.Gray,
                Padding = new Thickness(5),
                Margin = new Thickness(3),
                Background = Brushes.White
            };

            Grid reviewGrid = new Grid
            {
                Margin = new Thickness(5)
            };

            reviewGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(80) });
            reviewGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            reviewGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            reviewGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            reviewGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            reviewGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

            Image profileImage = new Image
            {
                Width = 50,
                Height = 50,
                Stretch = Stretch.UniformToFill,
                Margin = new Thickness(3)
            };

            try
            {
                profileImage.Source = new BitmapImage(new Uri(review.profile_photo_url, UriKind.Absolute));
            }
            catch
            {
            
            }
            Grid.SetColumn(profileImage, 0);
            Grid.SetRowSpan(profileImage, 4);          
            reviewGrid.Children.Add(profileImage);

            TextBlock nameTextBlock = new TextBlock
            {
                Text = review.author_name,
                FontSize = 13,
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(5, 0, 0, 0)
            };
            Grid.SetColumn(nameTextBlock, 1);
            Grid.SetRow(nameTextBlock, 0);
            reviewGrid.Children.Add(nameTextBlock);

            TextBlock starTextBlock = new TextBlock
            {
                Text = string.Join(" ", Enumerable.Range(1, review.rating).Select(x => "★")),
                FontSize = 13,
                Foreground = Brushes.Gold,
                Margin = new Thickness(5, 0, 0, 0)
            };
            Grid.SetColumn(starTextBlock, 1);
            Grid.SetRow(starTextBlock, 1);
            reviewGrid.Children.Add(starTextBlock);

            TextBlock timeTextBlock = new TextBlock
            {
                Text = review.relative_time_description,
                FontSize = 11,
                Foreground = Brushes.Gray,
                Margin = new Thickness(5, 0, 0, 0)
            };
            Grid.SetColumn(timeTextBlock, 1);
            Grid.SetRow(timeTextBlock, 2);
            reviewGrid.Children.Add(timeTextBlock);

            TextBlock commentTextBlock = new TextBlock
            {
                Text = review.text,
                FontSize = 13,
                TextWrapping = TextWrapping.Wrap,
                Margin = new Thickness(5, 0, 0, 0)
            };
            Grid.SetColumn(commentTextBlock, 1);
            Grid.SetRow(commentTextBlock, 3);
            reviewGrid.Children.Add(commentTextBlock);

            reviewBorder.Child = reviewGrid;
            return reviewBorder;
        }

    }   
}

