namespace ServerSoket
{
    partial class Form1
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
            this.txtMsgSent = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lblMsg = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMsgReceiver = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.lstClient = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ddlClient = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtMsgSent
            // 
            this.txtMsgSent.Location = new System.Drawing.Point(109, 73);
            this.txtMsgSent.Multiline = true;
            this.txtMsgSent.Name = "txtMsgSent";
            this.txtMsgSent.Size = new System.Drawing.Size(282, 40);
            this.txtMsgSent.TabIndex = 0;
            this.txtMsgSent.Text = "Hello";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Message sent";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(109, 172);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(183, 44);
            this.button1.TabIndex = 2;
            this.button1.Text = "Sent";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(106, 12);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(294, 23);
            this.lblMsg.TabIndex = 3;
            this.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Message receiver";
            this.label2.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtMsgReceiver
            // 
            this.txtMsgReceiver.Location = new System.Drawing.Point(109, 120);
            this.txtMsgReceiver.Multiline = true;
            this.txtMsgReceiver.Name = "txtMsgReceiver";
            this.txtMsgReceiver.Size = new System.Drawing.Size(282, 40);
            this.txtMsgReceiver.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(316, 172);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 44);
            this.button2.TabIndex = 4;
            this.button2.Text = "Close server";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lstClient
            // 
            this.lstClient.FormattingEnabled = true;
            this.lstClient.Location = new System.Drawing.Point(112, 232);
            this.lstClient.Name = "lstClient";
            this.lstClient.Size = new System.Drawing.Size(282, 173);
            this.lstClient.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 317);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Client connect";
            this.label3.Click += new System.EventHandler(this.label1_Click);
            // 
            // ddlClient
            // 
            this.ddlClient.FormattingEnabled = true;
            this.ddlClient.Location = new System.Drawing.Point(109, 46);
            this.ddlClient.Name = "ddlClient";
            this.ddlClient.Size = new System.Drawing.Size(285, 21);
            this.ddlClient.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Client";
            this.label4.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 485);
            this.Controls.Add(this.ddlClient);
            this.Controls.Add(this.lstClient);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMsgReceiver);
            this.Controls.Add(this.txtMsgSent);
            this.Name = "Form1";
            this.Text = "Server";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMsgSent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMsgReceiver;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox lstClient;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ddlClient;
        private System.Windows.Forms.Label label4;
    }
}

