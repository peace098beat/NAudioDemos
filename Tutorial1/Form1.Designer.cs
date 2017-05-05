namespace Tutorial1
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.button_OpenWav = new System.Windows.Forms.Button();
            this.button_PauseWav = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // button_OpenWav
            // 
            this.button_OpenWav.Location = new System.Drawing.Point(12, 36);
            this.button_OpenWav.Name = "button_OpenWav";
            this.button_OpenWav.Size = new System.Drawing.Size(335, 23);
            this.button_OpenWav.TabIndex = 2;
            this.button_OpenWav.Text = "Open Wave File";
            this.button_OpenWav.UseVisualStyleBackColor = true;
            this.button_OpenWav.Click += new System.EventHandler(this.button_OpenWav_Click);
            // 
            // button_PauseWav
            // 
            this.button_PauseWav.Location = new System.Drawing.Point(12, 66);
            this.button_PauseWav.Name = "button_PauseWav";
            this.button_PauseWav.Size = new System.Drawing.Size(335, 23);
            this.button_PauseWav.TabIndex = 3;
            this.button_PauseWav.Text = "Pause/Play WAV";
            this.button_PauseWav.UseVisualStyleBackColor = true;
            this.button_PauseWav.Click += new System.EventHandler(this.button_PauseWav_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(12, 9);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(287, 12);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://www.youtube.com/watch?v=6XvWRzWzgNI&t=26s";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 105);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.button_PauseWav);
            this.Controls.Add(this.button_OpenWav);
            this.Name = "Form1";
            this.Text = "Tutorial 1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_OpenWav;
        private System.Windows.Forms.Button button_PauseWav;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

