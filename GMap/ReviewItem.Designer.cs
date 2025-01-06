namespace Gmap
{
    partial class ReviewItem
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
            this.authorLab = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.starLab = new System.Windows.Forms.Label();
            this.timeLab = new System.Windows.Forms.Label();
            this.ReviewLab = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // authorLab
            // 
            this.authorLab.AutoSize = true;
            this.authorLab.Location = new System.Drawing.Point(73, 50);
            this.authorLab.Name = "authorLab";
            this.authorLab.Size = new System.Drawing.Size(32, 12);
            this.authorLab.TabIndex = 2;
            this.authorLab.Text = "Name";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(21, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(46, 50);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // starLab
            // 
            this.starLab.AutoSize = true;
            this.starLab.BackColor = System.Drawing.SystemColors.Control;
            this.starLab.ForeColor = System.Drawing.Color.Goldenrod;
            this.starLab.Location = new System.Drawing.Point(21, 74);
            this.starLab.Name = "starLab";
            this.starLab.Size = new System.Drawing.Size(17, 12);
            this.starLab.TabIndex = 4;
            this.starLab.Text = "★";
            // 
            // timeLab
            // 
            this.timeLab.AutoSize = true;
            this.timeLab.Location = new System.Drawing.Point(111, 74);
            this.timeLab.Name = "timeLab";
            this.timeLab.Size = new System.Drawing.Size(29, 12);
            this.timeLab.TabIndex = 5;
            this.timeLab.Text = "Time";
            // 
            // ReviewLab
            // 
            this.ReviewLab.AutoEllipsis = true;
            this.ReviewLab.Location = new System.Drawing.Point(21, 106);
            this.ReviewLab.Name = "ReviewLab";
            this.ReviewLab.Size = new System.Drawing.Size(264, 47);
            this.ReviewLab.TabIndex = 6;
            this.ReviewLab.Text = "label1";
            // 
            // ReviewItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.ReviewLab);
            this.Controls.Add(this.timeLab);
            this.Controls.Add(this.starLab);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.authorLab);
            this.Name = "ReviewItem";
            this.Size = new System.Drawing.Size(300, 162);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label authorLab;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label starLab;
        private System.Windows.Forms.Label timeLab;
        private System.Windows.Forms.Label ReviewLab;
    }
}
