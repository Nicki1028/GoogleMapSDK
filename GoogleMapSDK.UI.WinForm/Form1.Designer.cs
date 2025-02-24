namespace GoogleMapSDK.UI.WinForm
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
            this.placeAutoComplete2 = new GoogleMapSDK.UI.WinForm.Components.AutoComplete.PlaceAutoComplete();
            this.SuspendLayout();
            // 
            // placeAutoComplete2
            // 
            this.placeAutoComplete2.DataSource = null;
            this.placeAutoComplete2.DropDownFontSize = 12F;
            this.placeAutoComplete2.Location = new System.Drawing.Point(474, 402);
            this.placeAutoComplete2.Name = "placeAutoComplete2";
            this.placeAutoComplete2.Size = new System.Drawing.Size(100, 22);
            this.placeAutoComplete2.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 450);
            this.Controls.Add(this.placeAutoComplete2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_LoadAsync);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Components.AutoComplete.PlaceAutoComplete placeAutoComplete2;
    }
}

