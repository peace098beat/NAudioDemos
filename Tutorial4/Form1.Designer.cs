namespace Tutorial
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
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.button_StartTone = new System.Windows.Forms.Button();
            this.button_StopTone = new System.Windows.Forms.Button();
            this.SuspendLayout();
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
            // button_StartTone
            // 
            this.button_StartTone.Location = new System.Drawing.Point(14, 36);
            this.button_StartTone.Name = "button_StartTone";
            this.button_StartTone.Size = new System.Drawing.Size(313, 23);
            this.button_StartTone.TabIndex = 5;
            this.button_StartTone.Text = "Start Tone";
            this.button_StartTone.UseVisualStyleBackColor = true;
            this.button_StartTone.Click += new System.EventHandler(this.button_StartTone_Click);
            // 
            // button_StopTone
            // 
            this.button_StopTone.Location = new System.Drawing.Point(14, 66);
            this.button_StopTone.Name = "button_StopTone";
            this.button_StopTone.Size = new System.Drawing.Size(313, 23);
            this.button_StopTone.TabIndex = 6;
            this.button_StopTone.Text = "Stop Tone";
            this.button_StopTone.UseVisualStyleBackColor = true;
            this.button_StopTone.Click += new System.EventHandler(this.button_StopTone_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 104);
            this.Controls.Add(this.button_StopTone);
            this.Controls.Add(this.button_StartTone);
            this.Controls.Add(this.linkLabel1);
            this.Name = "Form1";
            this.Text = "Tutorial";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button button_StartTone;
        private System.Windows.Forms.Button button_StopTone;
    }
}

