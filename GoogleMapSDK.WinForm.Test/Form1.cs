using GoogleMapSDK.UI.Contract.API;
using GoogleMapSDK.UI.Contract.API.Places_Detail.Models;
using GoogleMapSDK.UI.Contract.Components;
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

namespace GoogleMapSDK.WinForm.Test
{
    public partial class Form1 : Form
    {
        private IGoogleContext _googlecontext;
        private IGoogleMap _map;
        public Form1(IGoogleContext context, IGoogleMap map)
        {
            InitializeComponent();

           // this.Controls.Add((Control)autoCompleteBase);
            this._googlecontext = context;
            this._map = map;
            this.Controls.Add((Control)this._map);

        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            PlacesDetailRequest placesDetailRequest = new PlacesDetailRequest();
            placesDetailRequest.place_id = "ChIJXQy7EvkeaDQRmdRXwKhr5OY";
            PlacesDetailResponse response = await _googlecontext.PlaceDetail.GetPlaceDetail(placesDetailRequest);
            _map.SetCenter(response.result.geometry.location.lat, response.result.geometry.location.lng);

            //BaseReviewItem baseReviewItem = new BaseReviewItem();
            //baseReviewItem.Width = 100;
            //baseReviewItem.Height = 100;
            //baseReviewItem.ReviewSource = new API.Places_Detail.PlacesDetailResponse.Review[] {

            //    new API.Places_Detail.PlacesDetailResponse.Review(){profile_photo_url = "https://i0.wp.com/www.kdan.com/zh-tw/blog/wp-content/uploads/2023/02/%E7%B5%9C%E8%8C%B5-KDAN-28.%E7%B7%9A%E4%B8%8A%E6%95%99%E5%AD%B8-%E9%A6%96%E5%9C%96.png"},
            //    new API.Places_Detail.PlacesDetailResponse.Review(){profile_photo_url = "https://i0.wp.com/www.kdan.com/zh-tw/blog/wp-content/uploads/2023/02/%E7%B5%9C%E8%8C%B5-KDAN-28.%E7%B7%9A%E4%B8%8A%E6%95%99%E5%AD%B8-%E9%A6%96%E5%9C%96.png"},
            //    new API.Places_Detail.PlacesDetailResponse.Review(){profile_photo_url = "https://i0.wp.com/www.kdan.com/zh-tw/blog/wp-content/uploads/2023/02/%E7%B5%9C%E8%8C%B5-KDAN-28.%E7%B7%9A%E4%B8%8A%E6%95%99%E5%AD%B8-%E9%A6%96%E5%9C%96.png"},
            //    new API.Places_Detail.PlacesDetailResponse.Review(){profile_photo_url = "https://i0.wp.com/www.kdan.com/zh-tw/blog/wp-content/uploads/2023/02/%E7%B5%9C%E8%8C%B5-KDAN-28.%E7%B7%9A%E4%B8%8A%E6%95%99%E5%AD%B8-%E9%A6%96%E5%9C%96.png"},

            //};
            //this.Controls.Add(baseReviewItem);
        }
    }
}
