using DIContainer;
using GoogleMapSDK.UI.Contract.API;
using GoogleMapSDK.UI.Contract.API.Directions.Models;
using GoogleMapSDK.UI.Contract.API.Models;
using GoogleMapSDK.UI.Contract.Components.GoogleMap;
using GoogleMapSDK.UI.Contract.Models;
using GoogleMapSDK.UI.WinForm.Components.AutoComplete;
using GoogleMapSDK.UI.WinForm.Components.Comment;
using GoogleMapSDK.UI.WinForm.Components.Photo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GoogleMapSDK.UI.Contract.Components.AutoComplete.AutoCompleteContract;
using static GoogleMapSDK.UI.Contract.Components.Comment.ReviewContract;
using static GoogleMapSDK.UI.Contract.Components.Photo.PhotoContract;

namespace GoogleMapSDK.WinForm.Test
{
    public partial class Form1 : Form
    {
        private IGoogleMap _map;
        private IGoogleContext _context;
        private PlaceAutoCompleteView _place1;
        private PlaceAutoCompleteView _place2;
        private PlaceReviewView _placeReview;
        private PlacePhotoView _placePhoto;
        private PlacePhotoView _placePhoto2;
        public Form1(IComponentFactory componentFactory, IGoogleMap googleMap, IGoogleContext googleContext)
        {
            _place1 = componentFactory.CreateComponent<IAutoCompleteView, PlaceAutoCompleteView>();
            _place2 = componentFactory.CreateComponent<IAutoCompleteView, PlaceAutoCompleteView>();
            _placeReview = componentFactory.CreateComponent<IReviewView, PlaceReviewView>();
            _placePhoto = componentFactory.CreateComponent<IPhotoView, PlacePhotoView>();
            _placePhoto2 = componentFactory.CreateComponent<IPhotoView, PlacePhotoView>();
            //PlaceAutoCompleteView componentFactory.Create<IEnumerable<IAutoCompleteView>>(typeof(PlaceAutoCompleteView))
            
           
            InitializeComponent();
           
            //EmployeeAutoCompleteView empAutoCompleteView = (EmployeeAutoCompleteView)autoCompletes.First(x => x.GetType() ==typeof(EmployeeAutoCompleteView));         
            // this.Controls.Add((Control)autoCompleteBase);
            //this._googlecontext = context;
            //this._map = map;
            //this.Controls.Add((Control)this._map);

            _map = googleMap;
            _context = googleContext;
            flowLayoutPanel1.Controls.Add(_place1);
            flowLayoutPanel1.Controls.Add(_place2);
            flowLayoutPanel1.Controls.Add(_placeReview);
            _placeReview.Width = 400;
            _placeReview.Height = 400;
            

            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.Width = flowLayoutPanel1.Width;
            panel.Height = 600;
            _placePhoto.Width = flowLayoutPanel1.Width; 
            panel.Controls.Add(_placePhoto);
            _placePhoto2.Width = flowLayoutPanel1.Width;
            panel.Controls.Add(_placePhoto2);
            flowLayoutPanel1.Controls.Add(panel);
            Button button1 = new Button();
            flowLayoutPanel1.Controls.Add(button1);
            flowLayoutPanel1.BorderStyle = BorderStyle.FixedSingle;
            button1.Click += Button1_ClickAsync;

            flowLayoutPanel2.Controls.Add((Control)googleMap);
           // this.Controls.Add(flowLayoutPanel);
            this.Controls.Add(flowLayoutPanel1);
            this.Controls.Add(flowLayoutPanel2);
           
            _place1.OnSelectItem += CompleteView_OnSelectItem;
            _place2.OnSelectItem += CompleteView_OnSelectItem;
            //empAutoCompleteView.OnSelectItem += EmpAutoCompleteView_OnSelectItem;

        }

        private async void Button1_ClickAsync(object sender, EventArgs e)
        {
            DirectionRequest directionRequest = new DirectionRequest();
            directionRequest.origin = _place1.Text;
            directionRequest.destination = _place2.Text;
            DirectionResponse points = await _context.Direction.GetDirection(directionRequest);
            IEnumerable<Location> route = points.routes[0].overview_polyline.polylinePoints;
            _map.AddRoute(route);
        }

        private void EmpAutoCompleteView_OnSelectItem(object sender, Core.Models.EmployeeInfoModel e)
        {
            Console.WriteLine(e.ID);
        }

        private async void CompleteView_OnSelectItem(object sender, UI.Contract.API.Models.PlaceInfo e)
        {
       
            _map.AddMarker(new Location(e.Lat, e.Lng));
            await _placeReview.RenderReviewDatas<ReviewModel>(e.PlaceId);
            await _placePhoto.RenderPhotos(e.PlaceId, 400);            

        }
    }
}
