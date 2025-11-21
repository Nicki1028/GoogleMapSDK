using GMap.NET.MapProviders;
using GMap.NET;
using GoogleMapSDK.Core;
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
using static GoogleMapSDK.UI.Contract.Components.AutoComplete.AutoCompleteContract;
using GoogleMapSDK.UI.Contract.API;
using GoogleMapSDK.UI.Contract.API.Directions.Models;
using GoogleMapSDK.UI.Contract.Components.GoogleMap;
using GoogleMapSDK.UI.WPF.Components.Comment;
using GoogleMapSDK.UI.WPF.Components.Photo;
using DIContainer;
using Location = GoogleMapSDK.UI.Contract.API.Models.Location;
using GoogleMapSDK.UI.Contract.Models;
using static GoogleMapSDK.UI.Contract.Components.Comment.ReviewContract;
using static GoogleMapSDK.UI.Contract.Components.Photo.PhotoContract;

namespace GoogleMapSDK.WPF.Test
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        IGoogleContext googleContext;
        IGoogleMap googleMap;
        PlaceAutoComplete_WPF completeView;
        PlaceAutoComplete_WPF completeView2;
        PlaceReviewView_WPF _placeReview;
        PlacePhotoView_WPF _placePhoto;
        public MainWindow(IComponentFactory componentFactory, IGoogleContext googleContext, IGoogleMap googleMap)
        {
            this.googleContext = googleContext;
            this.googleMap = googleMap;
            InitializeComponent();
            completeView = componentFactory.CreateComponent<IAutoCompleteView, PlaceAutoComplete_WPF>();
            componentContainer.Children.Add(completeView);
            completeView.OnSelectItem += CompleteView_OnSelectItem;
            Grid.SetRow(completeView, 0);
            Grid.SetColumn(completeView, 0);
            Grid.SetColumnSpan(completeView, 3);

            completeView2 = componentFactory.CreateComponent<IAutoCompleteView, PlaceAutoComplete_WPF>();         
            componentContainer.Children.Add(completeView2);
            completeView2.OnSelectItem += CompleteView2_OnSelectItemAsync;
            Grid.SetRow(completeView2, 0);
            Grid.SetColumn(completeView2, 3);
            Grid.SetColumnSpan(completeView2 , 3);

            Button button = new Button();
            button.Click += Button_ClickAsync;
            componentContainer.Children.Add(button);
            button.Content = "導航";
            Grid.SetRow(button, 1);
            Grid.SetColumn(button, 0);
            Grid.SetColumnSpan(button, 2);

            Button rmroute = new Button();
            rmroute.Click += Button_Click;
            componentContainer.Children.Add(rmroute);
            rmroute.Content = "移除路徑";
            Grid.SetRow(rmroute, 1);
            Grid.SetColumn(rmroute, 2);
            Grid.SetColumnSpan(rmroute, 2);

            Button rmmarkers = new Button();
            rmmarkers.Click += RemoveMarkers;
            componentContainer.Children.Add(rmmarkers);
            rmmarkers.Content = "移除座標";
            Grid.SetRow(rmmarkers, 1);
            Grid.SetColumn(rmmarkers, 4);
            Grid.SetColumnSpan(rmmarkers, 2);

            _placeReview = componentFactory.CreateComponent<IReviewView, PlaceReviewView_WPF>();
            componentContainer.Children.Add(_placeReview);
            Grid.SetRow(_placeReview, 2);
            Grid.SetColumn(_placeReview, 0);
            Grid.SetColumnSpan(_placeReview, 3);

            _placePhoto = componentFactory.CreateComponent<IPhotoView, PlacePhotoView_WPF>();
            componentContainer.Children.Add(_placePhoto);
            Grid.SetRow(_placePhoto, 3);
            Grid.SetColumn(_placePhoto, 0);
            Grid.SetColumnSpan(_placePhoto, 3);


            var googlemap = (Control)this.googleMap;            
            componentContainer.Children.Add(googlemap);
            Grid.SetRow(googlemap, 2);
            Grid.SetRowSpan(googlemap, 2);
            Grid.SetColumn(googlemap, 3);
            Grid.SetColumnSpan(googlemap, 3);



        }

        private void RemoveMarkers(object sender, RoutedEventArgs e)
        {
            googleMap.ClearMarkers();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            googleMap.ClearRoutes();
        }

        private async void Button_ClickAsync(object sender, RoutedEventArgs e)
        {
            DirectionRequest directionRequest = new DirectionRequest();
            directionRequest.origin = completeView.Text;
            directionRequest.destination = completeView2.Text;
            DirectionResponse points = await googleContext.Direction.GetDirection(directionRequest);
            IEnumerable<Location> route = points.routes[0].overview_polyline.polylinePoints;
            googleMap.AddRoute(route);

        }

        private async void CompleteView2_OnSelectItemAsync(object sender, PlaceInfo e)
        {
            googleMap.AddMarker(new Location(e.Lat, e.Lng));
           
            await _placeReview.RenderReviewDatas<ReviewModel>(e.PlaceId);
            await _placePhoto.RenderPhotos(e.PlaceId, 400);
        }


        //private async void mapControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    System.Windows.Point clickPoint = e.GetPosition(mapControl);
        //    PointLatLng point = mapControl.FromLocalToLatLng((int)clickPoint.X, (int)clickPoint.Y);
        //    GMapMarker marker = new GMapMarker(point);
        //    BitmapImage bitmap = new BitmapImage();
        //    bitmap.BeginInit();
        //    bitmap.UriSource = new Uri("https://raw.githubusercontent.com/luxiaoxun/MapDownloader/refs/heads/master/GMap.NET.WindowsForms/Resources/red-dot.png", UriKind.Absolute);
        //    bitmap.EndInit();
        //    marker.Shape = new Image()
        //    {
        //        Source = bitmap,

        //    };
        //    mapControl.Markers.Add(marker);            

        //    DirectionResponse response = await googleContext.Direction.GetDirection(new UI.Contract.API.Directions.Models.DirectionRequest()
        //    {
        //        origin = "中央大學",
        //        destination = "台灣大學"
        //    });
        //    GMapRoute gmRoute = new GMapRoute(response.routes[0].overview_polyline.polylinePoints.Select(x => new PointLatLng(x.Latitude, x.Longitude)));
        //    gmRoute.Shape = new Line() { StrokeThickness = 20,Stroke = System.Windows.Media.Brushes.BlueViolet };

        //    mapControl.Markers.Add(gmRoute);
        //}

        private void CompleteView_OnSelectItem(object sender, PlaceInfo e)
        {
            googleMap.AddMarker(new Location(e.Lat, e.Lng));
        }
    }
}
