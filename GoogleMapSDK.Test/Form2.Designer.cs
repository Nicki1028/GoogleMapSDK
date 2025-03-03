namespace GoogleMapSDK.Test
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
            this.mapControl1 = new GoogleMapSDK.Core.MapControl();
            this.placeAutoComplete1 = new GoogleMapSDK.UI.WinForm.Components.AutoComplete.PlaceAutoComplete();
            this.button1 = new System.Windows.Forms.Button();
            this.placeAutoComplete2 = new GoogleMapSDK.UI.WinForm.Components.AutoComplete.PlaceAutoComplete();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // mapControl1
            // 
            this.mapControl1.Bearing = 0F;
            this.mapControl1.CanDragMap = true;
            this.mapControl1.EmptyTileColor = System.Drawing.Color.Navy;
            this.mapControl1.GrayScaleMode = false;
            this.mapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.mapControl1.LevelsKeepInMemmory = 5;
            this.mapControl1.Location = new System.Drawing.Point(56, 46);
            this.mapControl1.MarkersEnabled = true;
            this.mapControl1.MaxZoom = 20;
            this.mapControl1.MinZoom = 4;
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
            this.mapControl1.Size = new System.Drawing.Size(210, 283);
            this.mapControl1.TabIndex = 0;
            this.mapControl1.Zoom = 15D;
            // 
            // placeAutoComplete1
            // 
            this.placeAutoComplete1.DataSource = null;
            this.placeAutoComplete1.DropDownFontSize = 12F;
            this.placeAutoComplete1.Location = new System.Drawing.Point(304, 46);
            this.placeAutoComplete1.Name = "placeAutoComplete1";
            this.placeAutoComplete1.Size = new System.Drawing.Size(100, 22);
            this.placeAutoComplete1.TabIndex = 1;
            this.placeAutoComplete1.TextChanged += new System.EventHandler(this.placeAutoComplete1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(304, 165);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_ClickAsync);
            // 
            // placeAutoComplete2
            // 
            this.placeAutoComplete2.DataSource = null;
            this.placeAutoComplete2.DropDownFontSize = 12F;
            this.placeAutoComplete2.Location = new System.Drawing.Point(304, 101);
            this.placeAutoComplete2.Name = "placeAutoComplete2";
            this.placeAutoComplete2.Size = new System.Drawing.Size(100, 22);
            this.placeAutoComplete2.TabIndex = 3;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(461, 46);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(200, 232);
            this.listBox1.TabIndex = 4;
            this.listBox1.SelectedValueChanged += new System.EventHandler(this.SelectedValueChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.placeAutoComplete2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.placeAutoComplete1);
            this.Controls.Add(this.mapControl1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Core.MapControl mapControl1;
        private UI.WinForm.Components.AutoComplete.PlaceAutoComplete placeAutoComplete1;
        private System.Windows.Forms.Button button1;
        private UI.WinForm.Components.AutoComplete.PlaceAutoComplete placeAutoComplete2;
        private System.Windows.Forms.ListBox listBox1;
    }
}