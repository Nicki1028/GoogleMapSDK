﻿namespace GoogleMap_SDK
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
            this.autoCompleteTextBox1 = new Gmap.AutoCompleteTextBox();
            this.SuspendLayout();
            // 
            // autoCompleteTextBox1
            // 
            this.autoCompleteTextBox1.DataSource = null;
            this.autoCompleteTextBox1.DisplayMember = null;
            this.autoCompleteTextBox1.DropDownFontSize = 12F;
            this.autoCompleteTextBox1.Location = new System.Drawing.Point(116, 195);
            this.autoCompleteTextBox1.Name = "autoCompleteTextBox1";
            this.autoCompleteTextBox1.Size = new System.Drawing.Size(166, 22);
            this.autoCompleteTextBox1.TabIndex = 2;
            this.autoCompleteTextBox1.ValueMember = null;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.autoCompleteTextBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Gmap.AutoCompleteTextBox autoCompleteTextBox1;
    }
}

