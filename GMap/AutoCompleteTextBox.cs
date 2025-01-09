using GMap.NET;
using Google_Map_API;
using Google_Map_API.Direction;
using Google_Map_API.Place_Photo;
using Google_Map_API.Places;
using Google_Map_API.Places_Detail;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HttpUtility.AllbumCreateResponseModel;

namespace Gmap
{
    public class AutoCompleteTextBox:TextBox
    {
        private ListBox _listBox;
        private bool _isAdded;
        private IEnumerable _values;
        private string _displaymember;
        private string _valuemember;
        private String _formerValue = String.Empty;
        private float _dropDownFontSize = 12f; // 預設字體大小
        public EventHandler<string> _onTextChanged;
        public EventHandler<object> _getPlaceId;
        public string _placeId;
        public float DropDownFontSize
        {
            get => _dropDownFontSize;
            set
            {
                _dropDownFontSize = value;
                if (_listBox != null)
                {
                    _listBox.Font = new Font(_listBox.Font.FontFamily, _dropDownFontSize);
                }
            }
        }
        GoogleContext context = new GoogleContext(new GoogleSigned());
        List<Bitmap> allPhotos;
        public AutoCompleteTextBox()
        {
            InitializeComponent();
            ResetListBox();
        }
        private void InitializeComponent()
        {
            this._listBox = new ListBox();
            this.SuspendLayout();

            this._listBox.ItemHeight = 20;

            KeyDown += this_KeyDown;
            _listBox.DoubleClick += new System.EventHandler(this.ListBoxDouble_Click);
            this.ResumeLayout(false);

        }
        private void ListBoxDouble_Click(object sender, EventArgs e)
        {
            if (_listBox.Visible)
            {
                var selecteditem_dismem = _listBox.SelectedItem.GetType().GetProperty(_displaymember);
                this.Text = (selecteditem_dismem.GetValue(_listBox.SelectedItem)).ToString();
                _getPlaceId.Invoke(this, this.Text);
                ResetListBox();
                
            }
        }
        private async Task<List<Bitmap>> CollectPhotosAsync(List<string> photoReferences, int maxHeight)
        {
            List<Task<Bitmap>> photoTasks = new List<Task<Bitmap>>();
            foreach (var photoRef in photoReferences)
            {
                photoTasks.Add(Task.Run(() =>
                {
                    var photoRequest = new PlacePhotoRequest
                    {
                        photo_reference = photoRef,
                        maxheight = maxHeight
                    };
                    return context.PlacePhoto.GetPhoto(photoRequest);
                }));
            }
            allPhotos = (await Task.WhenAll(photoTasks)).ToList();
            return allPhotos;
        }

        private async void GetPlaceInfo(string placeId, MapControl mapControl, string overlayId)
        {
            PlacesDetailRequest placesDetailRequest = new PlacesDetailRequest();
            placesDetailRequest.place_id = placeId;
            var result = await context.PlacesDetail.GetPlaceDetail(placesDetailRequest);

            List<string> photoReferences = new List<string>();
            foreach (var info in result.result.photos)
            {
                photoReferences.Add(info.photo_reference);
            }

            allPhotos = await CollectPhotosAsync(photoReferences, 200);

            PointLatLng markerdestination = new PointLatLng(result.result.geometry.location.lat, result.result.geometry.location.lng);
            
            MarkerInfo markerinfo = new MarkerInfo();
            markerinfo.Name = result.result.name;
            markerinfo.Address = result.result.formatted_address;
            markerinfo.PlaceId = result.result.place_id;
            markerinfo.TextboxId = _listBox.Name;
            markerinfo.reviews = result.result.reviews;
            markerinfo.Lat = result.result.geometry.location.lat;
            markerinfo.Lng = result.result.geometry.location.lng;

            mapControl.AddMarker(markerdestination, overlayId, markerinfo);
            mapControl.SetCenter(markerinfo.Lat, markerinfo.Lng);
        }
        private void TextAutoComplete(Form form)
        {
            form.Timerextention((async () =>
            {
                AutoCompleteRequest autoCompleteRequest = new AutoCompleteRequest();
                autoCompleteRequest.input = this.Text;
                var result = await context.AutoComplete.AutoCompleteSearch(autoCompleteRequest);

                List<PlaceModel> places = new List<PlaceModel>();
                foreach (var item in result.predictions)
                {
                    places.Add(new PlaceModel
                    {
                        Name = item.structured_formatting.main_text,
                        Id = item.place_id
                    });
                }
                this.DataSource = places;
            }));
        } 
        private async void GetRoute(RouteOverlay route)
        {            
            PointLatLng origin;
            PointLatLng destination;

            DirectionRequest directionRequest = new DirectionRequest();
            directionRequest.origin = this.GetPlaceId();
            directionRequest.destination = this.GetPlaceId();
            var result = await context.Direction.Direction(directionRequest);
            foreach (var item in result.routes)
            {
                origin = new PointLatLng(item.legs[0].start_location.lat, item.legs[0].start_location.lng);
                destination = new PointLatLng(item.legs[0].end_location.lat, item.legs[0].end_location.lng);
                route.AddRange(item.overview_polyline.polylinePoints.Select(x => (x.Latitude, x.Longitude)));
            }
        }
        public string GetPlaceId()
        {
            return "place_id:" + _placeId;
        }
        private void ShowListBox()
        {
            if (!_isAdded && Parent != null)
            {
                Parent.Controls.Add(_listBox);
                _listBox.Left = Left;
                _listBox.Top = Top + Height;
                _isAdded = true;
            }
            
            _listBox.Visible = true;
            _listBox.BringToFront();
        }

        private void ResetListBox()
        {
            _listBox.Visible = false;
        }

        private void this_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    {
                        if ((_listBox.Visible) && (_listBox.SelectedIndex < _listBox.Items.Count - 1))
                            _listBox.SelectedIndex++;

                        break;
                    }
                case Keys.Up:
                    {
                        if ((_listBox.Visible) && (_listBox.SelectedIndex > 0))
                            _listBox.SelectedIndex--;

                        break;
                    }
                case Keys.Tab:
                case Keys.Enter:
                    {
                        if (_listBox.Visible)
                        {
                            var selecteditem_dismem = _listBox.SelectedItem.GetType().GetProperty(_displaymember);
                            this.Text = (selecteditem_dismem.GetValue(_listBox.SelectedItem)).ToString();
                            var selecteditem_value = _listBox.SelectedItem.GetType().GetProperty(_valuemember);
                            _placeId = (selecteditem_value.GetValue(_listBox.SelectedItem)).ToString();
                            _getPlaceId.Invoke(this, _placeId);
                            ResetListBox();
                            _formerValue = Text;
                          
                        }
                        break;
                    }
            }
        }
       
        private void UpdateListBox()
        {
            if (Text == _formerValue) return;

            _formerValue = Text;
            _listBox.DataSource = _values;
            _listBox.DisplayMember = "Name";
            _listBox.ValueMember = "Id";
            ShowListBox();
            _listBox.Width = this.Size.Width;
 
        }
        public object DataSource
        {
            get
            {
                return _values;
            }
            set
            {                
                _values = (IEnumerable)value;
                UpdateListBox();
            }
        }

        public string DisplayMember
        {
            get
            {
                return _displaymember;
            }
            set
            {
                _displaymember = value;
                _listBox.DisplayMember = value;
            }
        }

        public string ValueMember
        {
            get
            {
                return _valuemember;
            }
            set {
                _valuemember = value; 
                _listBox.ValueMember = value;
            }
        }

       

    }

}

