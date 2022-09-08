namespace VTYSPROJE
{
    partial class FrmAdminDuyuruDetay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAdminDuyuruDetay));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblogretmenadsoyad = new System.Windows.Forms.Label();
            this.lbdlduyurutarihi = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 167);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(760, 334);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(56, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Öğretmen:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(21, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Duyuru Tarihi:";
            // 
            // lblogretmenadsoyad
            // 
            this.lblogretmenadsoyad.AutoSize = true;
            this.lblogretmenadsoyad.BackColor = System.Drawing.Color.Transparent;
            this.lblogretmenadsoyad.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblogretmenadsoyad.Location = new System.Drawing.Point(188, 48);
            this.lblogretmenadsoyad.Name = "lblogretmenadsoyad";
            this.lblogretmenadsoyad.Size = new System.Drawing.Size(66, 25);
            this.lblogretmenadsoyad.TabIndex = 3;
            this.lblogretmenadsoyad.Text = "NULL";
            // 
            // lbdlduyurutarihi
            // 
            this.lbdlduyurutarihi.AutoSize = true;
            this.lbdlduyurutarihi.BackColor = System.Drawing.Color.Transparent;
            this.lbdlduyurutarihi.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbdlduyurutarihi.Location = new System.Drawing.Point(188, 98);
            this.lbdlduyurutarihi.Name = "lbdlduyurutarihi";
            this.lbdlduyurutarihi.Size = new System.Drawing.Size(66, 25);
            this.lbdlduyurutarihi.TabIndex = 4;
            this.lbdlduyurutarihi.Text = "NULL";
            // 
            // FrmAdminDuyuruDetay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(784, 521);
            this.Controls.Add(this.lbdlduyurutarihi);
            this.Controls.Add(this.lblogretmenadsoyad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAdminDuyuruDetay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DUYURU";
            this.Load += new System.EventHandler(this.FrmAdminDuyuruDetay_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblogretmenadsoyad;
        private System.Windows.Forms.Label lbdlduyurutarihi;
    }
}