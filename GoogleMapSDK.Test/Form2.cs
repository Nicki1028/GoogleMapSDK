using GMap.NET;
using GoogleMapSDK.Core.Place;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoogleMapSDK.Test
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void placeAutoComplete1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            NearbySearchContext nearbySearchContext = new NearbySearchContext();
            var data = await nearbySearchContext.NearbySearch(placeAutoComplete1.Text, 200);
            listBox1.DataSource = data;
            listBox1.DisplayMember = "NearbySearchName";
            listBox1.ValueMember = "NearbySearchPoint";
        
            //mapControl1._routeContext.PlanRoutes(placeAutoComplete1.Text, placeAutoComplete2.Text);
        }
        
        private void SelectedValueChanged(object sender, EventArgs e)
        {
             
            if(listBox1.SelectedValue is PointLatLng position)
            {
                this.mapControl1.Position = position;

            }
        }
    }
}
