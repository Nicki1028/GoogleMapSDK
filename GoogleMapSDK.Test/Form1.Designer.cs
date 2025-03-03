namespace GoogleMapSDK.Test
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.mapControl1 = new GoogleMapSDK.Core.MapControl();
            this.mapControl2 = new GoogleMapSDK.Core.MapControl();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(407, 65);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(407, 112);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_ClickAsync);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(533, 65);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 3;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(407, 161);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(226, 160);
            this.listBox1.TabIndex = 4;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(407, 394);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_ClickAsync);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(407, 356);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 22);
            this.textBox3.TabIndex = 6;
            // 
            // mapControl1
            // 
            this.mapControl1.Bearing = 0F;
            this.mapControl1.CanDragMap = true;
            this.mapControl1.EmptyTileColor = System.Drawing.Color.Navy;
            this.mapControl1.GrayScaleMode = false;
            this.mapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.mapControl1.LevelsKeepInMemmory = 5;
            this.mapControl1.Location = new System.Drawing.Point(35, 65);
            this.mapControl1.MarkersEnabled = true;
            this.mapControl1.MaxZoom = 2;
            this.mapControl1.MinZoom = 2;
            this.mapControl1.MouseWheelZoomEnabled = true;
            this.mapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;
            this.mapControl1.Name = "mapControl1";
            this.mapControl1.NegativeMode = false;
            this.mapControl1.PolygonsEnabled = true;
            this.mapControl1.RetryLoadTile = 0;
            this.mapControl1.RoutesEnabled = true;
            this.mapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.mapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.mapControl1.ShowTileGridLines = false;
            this.mapControl1.Size = new System.Drawing.Size(342, 352);
            this.mapControl1.TabIndex = 0;
            this.mapControl1.Zoom = 2D;
            // 
            // mapControl2
            // 
            this.mapControl2.Bearing = 0F;
            this.mapControl2.CanDragMap = true;
            this.mapControl2.EmptyTileColor = System.Drawing.Color.Navy;
            this.mapControl2.GrayScaleMode = false;
            this.mapControl2.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.mapControl2.LevelsKeepInMemmory = 5;
            this.mapControl2.Location = new System.Drawing.Point(718, 65);
            this.mapControl2.MarkersEnabled = true;
            this.mapControl2.MaxZoom = 20;
            this.mapControl2.MinZoom = 4;
            this.mapControl2.MouseWheelZoomEnabled = true;
            this.mapControl2.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;
            this.mapControl2.Name = "mapControl2";
            this.mapControl2.NegativeMode = false;
            this.mapControl2.PolygonsEnabled = true;
            this.mapControl2.RetryLoadTile = 0;
            this.mapControl2.RoutesEnabled = true;
            this.mapControl2.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.mapControl2.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.mapControl2.ShowTileGridLines = false;
            this.mapControl2.Size = new System.Drawing.Size(263, 285);
            this.mapControl2.TabIndex = 7;
            this.mapControl2.Zoom = 15D;
            this.mapControl2.Load += new System.EventHandler(this.mapControl2_Load);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(739, 356);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.mapControl2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.mapControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Core.MapControl mapControl1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox3;
        private Core.MapControl mapControl2;
        private System.Windows.Forms.Button button3;
    }
}

