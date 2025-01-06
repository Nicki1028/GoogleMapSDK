using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gmap
{
    public partial class PhotoItem : UserControl
    {
        List<Bitmap> photos;
        int counter=0;
        public PhotoItem(List<Bitmap> photos)
        {
            InitializeComponent();
            this.photos = photos;
            pictureBox1.Image = photos[0];
            counter = counter + 1< photos.Count ? counter+1: counter;
        }

        private void PhotoItem_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            if(counter +1 < photos.Count)
            {
                counter++;
                pictureBox1.Image = photos[counter];    
            }
            button1.Enabled = counter + 1 < photos.Count;
            button2.Enabled = counter > 0;

            //button1.Enabled = counter + 1 < photos.Count;
            //button2.Enabled = counter > 0;
            //if (photos.Count > 0 && counter+1 <= photos.Count)
            //{
            //    pictureBox1.Image = photos[counter];
            //    counter++;
            //}


        }

        private void button2_Click(object sender, EventArgs e)
        {
            

            if(counter-1>=0)
            {
                counter--;
                pictureBox1.Image = photos[counter];
            }
            button1.Enabled = counter < photos.Count;
            button2.Enabled = counter > 0;

            //if (photos.Count > 0  && counter >0)
            //{
            //    counter--;
            //    pictureBox1.Image = photos[counter];

            //}

            //button1.Enabled = counter < photos.Count;
            //button2.Enabled = counter > 0;

        }
    }
}
