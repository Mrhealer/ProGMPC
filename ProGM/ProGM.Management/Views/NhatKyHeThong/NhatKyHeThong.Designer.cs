namespace ProGM.Management.Views.NhatKyHeThong
{
    partial class NhatKyHeThong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NhatKyHeThong));
            this.chkTaiKhoan = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.May = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkBox = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.NguoiDung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Ngay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ThoiGian = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TinhTrang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edTrangThai = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.DaDung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdTaiKhoan = new DevExpress.XtraGrid.GridControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.panelTaiKhoan = new DevExpress.XtraEditors.PanelControl();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.dateEdit2 = new DevExpress.XtraEditors.DateEdit();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.chkTaiKhoan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edTrangThai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTaiKhoan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTaiKhoan)).BeginInit();
            this.panelTaiKhoan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // chkTaiKhoan
            // 
            this.chkTaiKhoan.AutoHeight = false;
            this.chkTaiKhoan.Name = "chkTaiKhoan";
            // 
            // May
            // 
            this.May.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.May.AppearanceCell.Options.UseFont = true;
            this.May.Caption = "Máy";
            this.May.FieldName = "May";
            this.May.Name = "May";
            this.May.OptionsColumn.AllowEdit = false;
            this.May.Visible = true;
            this.May.VisibleIndex = 1;
            this.May.Width = 146;
            // 
            // chkBox
            // 
            this.chkBox.ColumnEdit = this.chkTaiKhoan;
            this.chkBox.Name = "chkBox";
            this.chkBox.Visible = true;
            this.chkBox.VisibleIndex = 0;
            this.chkBox.Width = 69;
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.chkBox,
            this.May,
            this.NguoiDung,
            this.Ngay,
            this.ThoiGian,
            this.TinhTrang,
            this.DaDung});
            this.gridView1.GridControl = this.grdTaiKhoan;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsPrint.PrintPreview = true;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowHeight = 30;
            // 
            // NguoiDung
            // 
            this.NguoiDung.Caption = "Người dùng";
            this.NguoiDung.FieldName = "NguoiDung";
            this.NguoiDung.Name = "NguoiDung";
            this.NguoiDung.Visible = true;
            this.NguoiDung.VisibleIndex = 2;
            this.NguoiDung.Width = 269;
            // 
            // Ngay
            // 
            this.Ngay.Caption = "Ngày";
            this.Ngay.FieldName = "Ngay";
            this.Ngay.Name = "Ngay";
            this.Ngay.Visible = true;
            this.Ngay.VisibleIndex = 3;
            this.Ngay.Width = 180;
            // 
            // ThoiGian
            // 
            this.ThoiGian.Caption = "Thời gian";
            this.ThoiGian.FieldName = "ThoiGian";
            this.ThoiGian.Name = "ThoiGian";
            this.ThoiGian.Visible = true;
            this.ThoiGian.VisibleIndex = 4;
            this.ThoiGian.Width = 216;
            // 
            // TinhTrang
            // 
            this.TinhTrang.AppearanceCell.ForeColor = System.Drawing.Color.Green;
            this.TinhTrang.AppearanceCell.Options.UseForeColor = true;
            this.TinhTrang.AppearanceCell.Options.UseImage = true;
            this.TinhTrang.Caption = "Tình trạng";
            this.TinhTrang.ColumnEdit = this.edTrangThai;
            this.TinhTrang.FieldName = "TinhTrang";
            this.TinhTrang.Name = "TinhTrang";
            this.TinhTrang.Visible = true;
            this.TinhTrang.VisibleIndex = 5;
            this.TinhTrang.Width = 237;
            // 
            // edTrangThai
            // 
            this.edTrangThai.AutoHeight = false;
            this.edTrangThai.ContextImageOptions.Image = global::ProGM.Management.Properties.Resources.xanh;
            this.edTrangThai.Name = "edTrangThai";
            // 
            // DaDung
            // 
            this.DaDung.Caption = "Đã dùng";
            this.DaDung.FieldName = "DaDung";
            this.DaDung.Name = "DaDung";
            this.DaDung.Visible = true;
            this.DaDung.VisibleIndex = 6;
            this.DaDung.Width = 264;
            // 
            // grdTaiKhoan
            // 
            this.grdTaiKhoan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdTaiKhoan.Location = new System.Drawing.Point(0, 49);
            this.grdTaiKhoan.MainView = this.gridView1;
            this.grdTaiKhoan.Name = "grdTaiKhoan";
            this.grdTaiKhoan.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.edTrangThai});
            this.grdTaiKhoan.Size = new System.Drawing.Size(1399, 430);
            this.grdTaiKhoan.TabIndex = 11;
            this.grdTaiKhoan.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.grdTaiKhoan.Click += new System.EventHandler(this.grdTaiKhoan_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(1145, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(102, 15);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = "Tổng 1000 bản ghi";
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(1288, 15);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(69, 15);
            this.labelControl3.TabIndex = 10;
            this.labelControl3.Text = "Trang 1/200";
            // 
            // simpleButton4
            // 
            this.simpleButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton4.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton4.ImageOptions.SvgImage")));
            this.simpleButton4.ImageOptions.SvgImageSize = new System.Drawing.Size(15, 20);
            this.simpleButton4.Location = new System.Drawing.Point(1366, 10);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(25, 23);
            this.simpleButton4.TabIndex = 6;
            // 
            // simpleButton3
            // 
            this.simpleButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton3.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton3.ImageOptions.SvgImage")));
            this.simpleButton3.ImageOptions.SvgImageSize = new System.Drawing.Size(15, 20);
            this.simpleButton3.Location = new System.Drawing.Point(1255, 11);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(25, 23);
            this.simpleButton3.TabIndex = 5;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(629, 18);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(0, 15);
            this.labelControl7.TabIndex = 1;
            // 
            // panelTaiKhoan
            // 
            this.panelTaiKhoan.Appearance.BackColor = System.Drawing.Color.White;
            this.panelTaiKhoan.Appearance.Options.UseBackColor = true;
            this.panelTaiKhoan.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.panelTaiKhoan.Controls.Add(this.textEdit2);
            this.panelTaiKhoan.Controls.Add(this.textEdit1);
            this.panelTaiKhoan.Controls.Add(this.simpleButton3);
            this.panelTaiKhoan.Controls.Add(this.simpleButton1);
            this.panelTaiKhoan.Controls.Add(this.simpleButton4);
            this.panelTaiKhoan.Controls.Add(this.dateEdit2);
            this.panelTaiKhoan.Controls.Add(this.labelControl3);
            this.panelTaiKhoan.Controls.Add(this.dateEdit1);
            this.panelTaiKhoan.Controls.Add(this.labelControl1);
            this.panelTaiKhoan.Controls.Add(this.labelControl5);
            this.panelTaiKhoan.Controls.Add(this.labelControl6);
            this.panelTaiKhoan.Controls.Add(this.labelControl2);
            this.panelTaiKhoan.Controls.Add(this.labelControl4);
            this.panelTaiKhoan.Controls.Add(this.labelControl7);
            this.panelTaiKhoan.Location = new System.Drawing.Point(0, 0);
            this.panelTaiKhoan.Name = "panelTaiKhoan";
            this.panelTaiKhoan.Size = new System.Drawing.Size(1399, 49);
            this.panelTaiKhoan.TabIndex = 10;
            // 
            // textEdit2
            // 
            this.textEdit2.Location = new System.Drawing.Point(769, 12);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Size = new System.Drawing.Size(211, 20);
            this.textEdit2.TabIndex = 24;
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(496, 14);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(147, 20);
            this.textEdit1.TabIndex = 24;
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.simpleButton1.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.simpleButton1.Location = new System.Drawing.Point(1006, 11);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(86, 23);
            this.simpleButton1.TabIndex = 23;
            this.simpleButton1.Text = "Tìm kiếm";
            // 
            // dateEdit2
            // 
            this.dateEdit2.EditValue = null;
            this.dateEdit2.Location = new System.Drawing.Point(275, 15);
            this.dateEdit2.Name = "dateEdit2";
            this.dateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Size = new System.Drawing.Size(123, 20);
            this.dateEdit2.TabIndex = 21;
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(70, 14);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Size = new System.Drawing.Size(123, 20);
            this.dateEdit1.TabIndex = 22;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(214, 16);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(55, 15);
            this.labelControl5.TabIndex = 19;
            this.labelControl5.Text = "Đến ngày:";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(675, 16);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(69, 15);
            this.labelControl6.TabIndex = 20;
            this.labelControl6.Text = "Người dùng:";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(425, 18);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(50, 15);
            this.labelControl2.TabIndex = 20;
            this.labelControl2.Text = "Tên máy:";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(9, 15);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(49, 15);
            this.labelControl4.TabIndex = 20;
            this.labelControl4.Text = "Từ ngày:";
            // 
            // NhatKyHeThong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelTaiKhoan);
            this.Controls.Add(this.grdTaiKhoan);
            this.Name = "NhatKyHeThong";
            this.Size = new System.Drawing.Size(1399, 513);
            ((System.ComponentModel.ISupportInitialize)(this.chkTaiKhoan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edTrangThai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTaiKhoan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTaiKhoan)).EndInit();
            this.panelTaiKhoan.ResumeLayout(false);
            this.panelTaiKhoan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn May;
        private DevExpress.XtraGrid.Columns.GridColumn chkBox;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl grdTaiKhoan;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.PanelControl panelTaiKhoan;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.DateEdit dateEdit2;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraGrid.Columns.GridColumn NguoiDung;
        private DevExpress.XtraGrid.Columns.GridColumn Ngay;
        private DevExpress.XtraGrid.Columns.GridColumn ThoiGian;
        private DevExpress.XtraGrid.Columns.GridColumn DaDung;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkTaiKhoan;
        private DevExpress.XtraGrid.Columns.GridColumn TinhTrang;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit edTrangThai;
    }
}
