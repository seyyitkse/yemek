namespace YemekDunyası
{
    partial class FrmAnaGiris
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAnaGiris));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtnRestoran = new System.Windows.Forms.Button();
            this.BtnSiparis = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(128, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(453, 40);
            this.label1.TabIndex = 36;
            this.label1.Text = "Yemek Dünyasına Hoş Geldiniz ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(26, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(96, 93);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            // 
            // BtnRestoran
            // 
            this.BtnRestoran.BackColor = System.Drawing.Color.RosyBrown;
            this.BtnRestoran.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnRestoran.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnRestoran.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnRestoran.Image = ((System.Drawing.Image)(resources.GetObject("BtnRestoran.Image")));
            this.BtnRestoran.Location = new System.Drawing.Point(338, 223);
            this.BtnRestoran.Name = "BtnRestoran";
            this.BtnRestoran.Size = new System.Drawing.Size(190, 126);
            this.BtnRestoran.TabIndex = 2;
            this.BtnRestoran.Text = "Admin İşlemleri";
            this.BtnRestoran.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnRestoran.UseVisualStyleBackColor = false;
            this.BtnRestoran.Click += new System.EventHandler(this.BtnRestoran_Click);
            // 
            // BtnSiparis
            // 
            this.BtnSiparis.BackColor = System.Drawing.Color.RosyBrown;
            this.BtnSiparis.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSiparis.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnSiparis.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnSiparis.Image = ((System.Drawing.Image)(resources.GetObject("BtnSiparis.Image")));
            this.BtnSiparis.Location = new System.Drawing.Point(109, 223);
            this.BtnSiparis.Name = "BtnSiparis";
            this.BtnSiparis.Size = new System.Drawing.Size(190, 126);
            this.BtnSiparis.TabIndex = 1;
            this.BtnSiparis.Text = "Sipariş Ver";
            this.BtnSiparis.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnSiparis.UseVisualStyleBackColor = false;
            this.BtnSiparis.Click += new System.EventHandler(this.BtnSiparis_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(583, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(34, 36);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 37;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // FrmAnaGiris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(617, 403);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.BtnSiparis);
            this.Controls.Add(this.BtnRestoran);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmAnaGiris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAnaGiris";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BtnRestoran;
        private System.Windows.Forms.Button BtnSiparis;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}