using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Google_Map_API.Places_Detail.PlacesDetailResponse;

namespace Gmap
{
    public partial class ReviewItem : UserControl
    {

        public ReviewItem(Review review)
        {
            InitializeComponent();


            if (!string.IsNullOrEmpty(review.text))
            {

                authorLab.Text = review.author_name;
                timeLab.Text = review.relative_time_description;
                ReviewLab.Text = review.text;
                ReviewLab.Font = new Font("Times New Roman", 12);
                starLab.Text = string.Join("  ", Enumerable.Range(1, review.rating).Select(x => "★"));

                pictureBox1.LoadAsync(review.profile_photo_url);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }


        }
            
       

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
