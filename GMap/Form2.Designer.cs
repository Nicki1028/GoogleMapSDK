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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.mapControl1 = new Gmap.MapControl();
            this.autoCompleteTextBox2 = new Gmap.AutoCompleteTextBox();
            this.autoCompleteTextBox1 = new Gmap.AutoCompleteTextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(108, 40);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(108, 77);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(108, 116);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(101, 380);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(153, 40);
            this.listBox1.TabIndex = 6;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(108, 286);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(769, 221);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(452, 278);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Location = new System.Drawing.Point(769, 12);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(452, 203);
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
            this.mapControl1.Location = new System.Drawing.Point(277, 22);
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
            this.mapControl1.Size = new System.Drawing.Size(450, 477);
            this.mapControl1.TabIndex = 9;
            this.mapControl1.Zoom = 0D;
            this.mapControl1.Load += new System.EventHandler(this.mapControl1_Load);
            // 
            // autoCompleteTextBox2
            // 
            this.autoCompleteTextBox2.DataSource = null;
            this.autoCompleteTextBox2.DisplayMember = null;
            this.autoCompleteTextBox2.DropDownFontSize = 12F;
            this.autoCompleteTextBox2.Location = new System.Drawing.Point(108, 242);
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
            this.autoCompleteTextBox1.Location = new System.Drawing.Point(108, 198);
            this.autoCompleteTextBox1.Name = "autoCompleteTextBox1";
            this.autoCompleteTextBox1.Size = new System.Drawing.Size(146, 22);
            this.autoCompleteTextBox1.TabIndex = 4;
            this.autoCompleteTextBox1.ValueMember = null;
            this.autoCompleteTextBox1.TextChanged += new System.EventHandler(this.autoCompleteTextBox1_TextChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 511);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.mapControl1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.autoCompleteTextBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.autoCompleteTextBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private AutoCompleteTextBox autoCompleteTextBox1;
        private System.Windows.Forms.ListBox listBox1;
        private AutoCompleteTextBox autoCompleteTextBox2;
        private System.Windows.Forms.Button button2;
        private MapControl mapControl1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
    }
}