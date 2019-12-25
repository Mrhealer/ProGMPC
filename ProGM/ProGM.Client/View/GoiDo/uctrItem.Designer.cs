namespace  ProGM.Client.View.GoiDo
{
    partial class uctrItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelItem = new System.Windows.Forms.Panel();
            this.btnBuyNow = new System.Windows.Forms.Button();
            this.btnAddToCart = new System.Windows.Forms.Button();
            this.lbPrice = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.ptImage = new System.Windows.Forms.PictureBox();
            this.panelItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptImage)).BeginInit();
            this.SuspendLayout();
            // 
            // panelItem
            // 
            this.panelItem.BackColor = System.Drawing.Color.LightGray;
            this.panelItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelItem.Controls.Add(this.label2);
            this.panelItem.Controls.Add(this.btnBuyNow);
            this.panelItem.Controls.Add(this.btnAddToCart);
            this.panelItem.Controls.Add(this.pictureBox2);
            this.panelItem.Controls.Add(this.lbPrice);
            this.panelItem.Controls.Add(this.label1);
            this.panelItem.Controls.Add(this.lbName);
            this.panelItem.Controls.Add(this.ptImage);
            this.panelItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelItem.Location = new System.Drawing.Point(0, 0);
            this.panelItem.Name = "panelItem";
            this.panelItem.Size = new System.Drawing.Size(200, 261);
            this.panelItem.TabIndex = 0;
            // 
            // btnBuyNow
            // 
            this.btnBuyNow.BackColor = System.Drawing.Color.Red;
            this.btnBuyNow.FlatAppearance.BorderSize = 0;
            this.btnBuyNow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuyNow.ForeColor = System.Drawing.Color.White;
            this.btnBuyNow.Location = new System.Drawing.Point(116, 220);
            this.btnBuyNow.Name = "btnBuyNow";
            this.btnBuyNow.Size = new System.Drawing.Size(75, 30);
            this.btnBuyNow.TabIndex = 8;
            this.btnBuyNow.Text = "Mua hàng";
            this.btnBuyNow.UseVisualStyleBackColor = false;
            this.btnBuyNow.Click += new System.EventHandler(this.btnBuyNow_Click);
            // 
            // btnAddToCart
            // 
            this.btnAddToCart.BackColor = System.Drawing.Color.Green;
            this.btnAddToCart.FlatAppearance.BorderSize = 0;
            this.btnAddToCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddToCart.ForeColor = System.Drawing.Color.White;
            this.btnAddToCart.Location = new System.Drawing.Point(7, 220);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(75, 30);
            this.btnAddToCart.TabIndex = 7;
            this.btnAddToCart.Text = "Giỏ hàng";
            this.btnAddToCart.UseVisualStyleBackColor = false;
            this.btnAddToCart.Click += new System.EventHandler(this.btnAddToCart_Click);
            // 
            // lbPrice
            // 
            this.lbPrice.AutoSize = true;
            this.lbPrice.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lbPrice.Location = new System.Drawing.Point(106, 193);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(52, 16);
            this.lbPrice.TabIndex = 5;
            this.lbPrice.Text = "99.999";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(67, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Giá:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbName
            // 
            this.lbName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.ForeColor = System.Drawing.Color.White;
            this.lbName.Location = new System.Drawing.Point(0, 164);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(198, 26);
            this.lbName.TabIndex = 3;
            this.lbName.Text = "Ô long vị chanh";
            this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Image = global:: ProGM.Client.Properties.Resources.discount;
            this.label2.Location = new System.Drawing.Point(4, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 33);
            this.label2.TabIndex = 9;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global:: ProGM.Client.Properties.Resources.money;
            this.pictureBox2.Location = new System.Drawing.Point(160, 192);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(31, 29);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // ptImage
            // 
            this.ptImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.ptImage.Image = global:: ProGM.Client.Properties.Resources.QR_code;
            this.ptImage.Location = new System.Drawing.Point(0, 0);
            this.ptImage.Name = "ptImage";
            this.ptImage.Size = new System.Drawing.Size(198, 164);
            this.ptImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptImage.TabIndex = 2;
            this.ptImage.TabStop = false;
            // 
            // uctrItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panelItem);
            this.Name = "uctrItem";
            this.Size = new System.Drawing.Size(200, 261);
            this.panelItem.ResumeLayout(false);
            this.panelItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelItem;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.PictureBox ptImage;
        private System.Windows.Forms.Label lbPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuyNow;
        private System.Windows.Forms.Button btnAddToCart;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
    }
}
