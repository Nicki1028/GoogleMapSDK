using GMap.NET.WindowsForms;

namespace GoogleMapSDK.UI.WinForm.Components.GoogleMap
{
    partial class GoogleMapControl
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

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.MapControl = new GMapControl();
            this.SuspendLayout();
            // 
            // MapControl
            // 
            this.MapControl.Bearing = 0F;
            this.MapControl.CanDragMap = true;
            this.MapControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapControl.EmptyTileColor = System.Drawing.Color.Navy;
            this.MapControl.GrayScaleMode = false;
            this.MapControl.LevelsKeepInMemory = 5;
            this.MapControl.Location = new System.Drawing.Point(0, 0);
            this.MapControl.MarkersEnabled = true;
            this.MapControl.MaxZoom = 2;
            this.MapControl.MinZoom = 2;
            this.MapControl.MouseWheelZoomEnabled = true;
            this.MapControl.Name = "MapControl";
            this.MapControl.NegativeMode = false;
            this.MapControl.PolygonsEnabled = true;
            this.MapControl.RetryLoadTile = 0;
            this.MapControl.RoutesEnabled = true;
            this.MapControl.ScaleMode = ScaleModes.Integer;
            this.MapControl.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.MapControl.ShowTileGridLines = false;
            this.MapControl.Size = new System.Drawing.Size(221, 196);
            this.MapControl.TabIndex = 0;
            this.MapControl.Zoom = 0D;
            // 
            // GoogleMapControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MapControl);
            this.Name = "GoogleMapControl";
            this.Size = new System.Drawing.Size(221, 196);
            this.ResumeLayout(false);

        }

        #endregion

        private GMapControl MapControl;
    }
}
