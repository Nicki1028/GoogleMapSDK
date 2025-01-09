namespace Gmap
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button2 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.mapControl1 = new Gmap.MapControl();
            this.autoCompleteTextBox2 = new Gmap.AutoCompleteTextBox();
            this.autoCompleteTextBox1 = new Gmap.AutoCompleteTextBox();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(37, 307);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(671, 261);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(452, 304);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Location = new System.Drawing.Point(671, 12);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(452, 243);
            this.flowLayoutPanel2.TabIndex = 11;
            // 
            // mapControl1
            // 
            this.mapControl1.Bearing = 0F;
            this.mapControl1.CanDragMap = true;
            this.mapControl1.EmptyTileColor = System.Drawing.Color.Navy;
            this.mapControl1.GrayScaleMode = false;
            this.mapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.mapControl1.LevelsKeepInMemory = 5;
            this.mapControl1.Location = new System.Drawing.Point(200, 12);
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
            this.mapControl1.Size = new System.Drawing.Size(450, 553);
            this.mapControl1.TabIndex = 9;
            this.mapControl1.Zoom = 0D;
            this.mapControl1.Load += new System.EventHandler(this.mapControl1_Load);
            // 
            // autoCompleteTextBox2
            // 
            this.autoCompleteTextBox2.DataSource = null;
            this.autoCompleteTextBox2.DisplayMember = null;
            this.autoCompleteTextBox2.DropDownFontSize = 12F;
            this.autoCompleteTextBox2.Location = new System.Drawing.Point(37, 249);
            this.autoCompleteTextBox2.Name = "autoCompleteTextBox2";
            this.autoCompleteTextBox2.Size = new System.Drawing.Size(146, 22);
            this.autoCompleteTextBox2.TabIndex = 7;
            this.autoCompleteTextBox2.ValueMember = null;
            // 
            // autoCompleteTextBox1
            // 
            this.autoCompleteTextBox1.DataSource = null;
            this.autoCompleteTextBox1.DisplayMember = null;
            this.autoCompleteTextBox1.DropDownFontSize = 12F;
            this.autoCompleteTextBox1.Location = new System.Drawing.Point(37, 188);
            this.autoCompleteTextBox1.Name = "autoCompleteTextBox1";
            this.autoCompleteTextBox1.Size = new System.Drawing.Size(146, 22);
            this.autoCompleteTextBox1.TabIndex = 4;
            this.autoCompleteTextBox1.ValueMember = null;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 577);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.mapControl1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.autoCompleteTextBox2);
            this.Controls.Add(this.autoCompleteTextBox1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private AutoCompleteTextBox autoCompleteTextBox1;
        private AutoCompleteTextBox autoCompleteTextBox2;
        private System.Windows.Forms.Button button2;
        private MapControl mapControl1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
    }
}