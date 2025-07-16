using GoogleMapSDK.UI.Contract.API;
using GoogleMapSDK.UI.Contract.Components;
using GoogleMapSDK.UI.WinForm.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoogleMapSDK.UI.WinForm.Components.Photo
{
    public abstract class BasePhoto : UserControl, PhotoBase
    {
        protected List<Bitmap> _photos;

        protected int counter = 0;

        protected PictureBox pictureBox;
        protected Button previous;
        protected Button next;   
        protected FlowLayoutPanel flowLayoutPanel;
        private TableLayoutPanel tableLayoutPanel1, tableLayoutPanel2;  

        public int index => counter;

        public abstract List<Bitmap> ImageSource { set; }

        protected IGoogleContext context;
        public BasePhoto(IGoogleContext context)
        {
            this.context = context;
            InitializeComponent();
            previous.Click += Button_ClickBackward;
            next.Click += Button_ClickForward;
        }
        public void InitializeComponent()
        {
            flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel.Size = new Size(800,200);
          
            tableLayoutPanel1 = CreateCenteredTableLayoutPanel();
            tableLayoutPanel2 = CreateCenteredTableLayoutPanel();
         

            pictureBox = new PictureBox();
            pictureBox.Image = Image.FromFile("C:\\Users\\USER\\Desktop\\image.jpg");
            pictureBox.Size = new Size(200, 200);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.Anchor = AnchorStyles.None;

            previous = new Button();
            previous.Size = new Size(100, 30);
            previous.Text = "<<";
            previous.Anchor = AnchorStyles.None;
            next = new Button();
            next.Size = new Size(100, 30);
            next.Text = ">>";
            next.Anchor = AnchorStyles.None;

            tableLayoutPanel1.Controls.Add(previous, 0, 1);
            tableLayoutPanel2.Controls.Add(next, 0, 1);

            flowLayoutPanel.Controls.Add(tableLayoutPanel1);
            flowLayoutPanel.Controls.Add(pictureBox);
            flowLayoutPanel.Controls.Add(tableLayoutPanel2); 
            
            this.Controls.Add(flowLayoutPanel);

        }
        private TableLayoutPanel CreateCenteredTableLayoutPanel()
        {
            TableLayoutPanel table = new TableLayoutPanel();
            table.RowCount = 3;
            table.ColumnCount = 1;
            table.Dock = DockStyle.Fill;
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 40)); // 上方空白
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 20)); // 中間放按鈕
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 40)); // 下方空白
            return table;
        }
                 
        protected void RenderImages()
        {           
            if (_photos.Count > 0)
            {
                counter = 0;
                pictureBox.Image = _photos[counter];
                counter = counter + 1 < _photos.Count ? counter + 1 : counter;
            }
        }

        public void MoveNext()
        {
            if (counter + 1 < _photos.Count)
            {
                counter++;
                pictureBox.Image = _photos[counter];
            }
            UpdateButtonState_Startphoto();
        }

        public void MovePrevious()
        {
            if (counter - 1 >= 0)
            {
                counter--;
                pictureBox.Image = _photos[counter];
            }
            UpdateButtonState_Finalphoto();
        }
        public void UpdateButtonState_Finalphoto()
        {                 
            next.Enabled = index < _photos.Count;
            previous.Enabled = index > 0;
        }
        public void UpdateButtonState_Startphoto()
        {
            next.Enabled = index+1 < _photos.Count;
            previous.Enabled = index > 0;
        }

        public void Button_ClickForward(object sender, EventArgs e) => MoveNext();
        public void Button_ClickBackward(object sender, EventArgs e) => MovePrevious();

   
        //protected abstract Task<List<Bitmap>> CollectPhotosAsync(string placeId, int maxHeight);
        
           
    }
}
