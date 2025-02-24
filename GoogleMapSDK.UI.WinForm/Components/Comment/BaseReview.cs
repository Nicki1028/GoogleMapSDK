using GoogleMapSDK.API.Places_Detail;
using GoogleMapSDK.UI.Contract.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GoogleMapSDK.API.Places_Detail.PlacesDetailResponse;

namespace GoogleMapSDK.UI.WinForm.Components.Comment
{
    public abstract class BaseReview : UserControl, ReviewBase
    {
        public abstract Review[] ReviewSource { set; }

        protected Review[] _reviews;

        protected Review review;


        public BaseReview()
        {
            this.SizeChanged += BaseReview_SizeChanged;
        }

        private void BaseReview_SizeChanged(object sender, EventArgs e)
        {
            if(this._reviews!=null)
                InitializeComponent();
        }

        public void InitializeComponent()
        {
            this.Controls.Clear();
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.Size = this.Size;
            flowLayoutPanel.AutoScroll = true;
            foreach (Review review in _reviews)
            {
                FlowLayoutPanel commonPanel = LoadReview(review);
                commonPanel.Width = this.Size.Width;
                flowLayoutPanel.Controls.Add(commonPanel);

            }
            this.Controls.Add(flowLayoutPanel);

        }

        public FlowLayoutPanel LoadReview(Review review)
        {
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
            {

                FlowDirection = FlowDirection.LeftToRight,
                Height = 150,
                WrapContents = true,
                Padding = new Padding(10),
                Margin = new Padding(5),
                BorderStyle = BorderStyle.FixedSingle,
            };


            PictureBox pictureBox = new PictureBox
            {
                Size = new Size(50, 50),
               
                SizeMode = PictureBoxSizeMode.Zoom,
                
            };
            pictureBox.LoadAsync(review.profile_photo_url);

            Label nameLabel = new Label
            {
                Text = review.author_name,
                Font = new Font("Arial", 10, FontStyle.Bold),
             

            };

            Label starLabel = new Label
            {
                Text = string.Join("  ", Enumerable.Range(1, review.rating).Select(x => "★")),
                Font = new Font("Arial", 12),
                

            };

            Label timeLabel = new Label
            {
                Text = review.relative_time_description,
               

            };

            Label commentLabel = new Label
            {
                Text = review.text,
          
                Width = flowLayoutPanel.Width,
                Height = 100,
                
                Font = new Font("Times New Roman", 12)
            };

            TableLayoutPanel tableLayout = new TableLayoutPanel
            {
                ColumnCount = 2,
                RowCount = 4, // 4 行對應 Name, Star, Time, Comment
                Width = 10,
                Height = 20,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
            };

            // 設定欄位寬度
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50)); // 第一列固定 100px 給圖片
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));  // 第二列佔滿剩餘空間

            // 設定每列的大小 (讓元素排列得更自然)
            tableLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // 第一行: Name
            tableLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // 第二行: Star
            tableLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // 第三行: Time
            tableLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // 第四行: Comment

            // 加入控件
            tableLayout.Controls.Add(pictureBox, 0, 0);  // 圖片在第一列第一行 (左上角)
            tableLayout.SetRowSpan(pictureBox, 4);       // 讓圖片跨 4 行

            tableLayout.Controls.Add(nameLabel, 1, 0);   // 名稱
            tableLayout.Controls.Add(starLabel, 1, 1);   // 星星評價
            tableLayout.Controls.Add(timeLabel, 1, 2);   // 時間
            tableLayout.Controls.Add(commentLabel, 1, 3); // 評論


            flowLayoutPanel.Controls.Add(tableLayout);
            return flowLayoutPanel;
            
        }
    }
}
