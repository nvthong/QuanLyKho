﻿namespace QLK
{
    partial class frmDMHangHoa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDMHangHoa));
            this.gridDVT = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaSo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenKhachHang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiaChi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDienThoai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuanLy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuanLyCheckEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnNhapExcel = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtLoaiHangMa = new DevExpress.XtraEditors.TextEdit();
            this.txtLoaiHangTen = new DevExpress.XtraEditors.TextEdit();
            this.txtNhomHangTen = new DevExpress.XtraEditors.TextEdit();
            this.txtNhomHangMa = new DevExpress.XtraEditors.TextEdit();
            this.txtTenHang = new DevExpress.XtraEditors.TextEdit();
            this.txtMaHang = new DevExpress.XtraEditors.TextEdit();
            this.txtGhiChu = new DevExpress.XtraEditors.TextEdit();
            this.txtGiaMua = new DevExpress.XtraEditors.TextEdit();
            this.txtGiaBanLe = new DevExpress.XtraEditors.TextEdit();
            this.txtTonToiThieu = new DevExpress.XtraEditors.TextEdit();
            this.chkQuanLy = new DevExpress.XtraEditors.CheckEdit();
            this.lkuDonViTinh = new DevExpress.XtraEditors.LookUpEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridDVT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colQuanLyCheckEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoaiHangMa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoaiHangTen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNhomHangTen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNhomHangMa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenHang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaHang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGiaMua.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGiaBanLe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTonToiThieu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkQuanLy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkuDonViTinh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridDVT
            // 
            this.gridDVT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDVT.Location = new System.Drawing.Point(2, 2);
            this.gridDVT.MainView = this.gridView1;
            this.gridDVT.Name = "gridDVT";
            this.gridDVT.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.colQuanLyCheckEdit,
            this.repositoryItemTextEdit1});
            this.gridDVT.Size = new System.Drawing.Size(896, 325);
            this.gridDVT.TabIndex = 4;
            this.gridDVT.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.ColumnPanelRowHeight = 25;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaSo,
            this.colTenKhachHang,
            this.colDiaChi,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.colDienThoai,
            this.colQuanLy});
            this.gridView1.GridControl = this.gridDVT;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView1.OptionsFind.AllowFindPanel = false;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsMenu.EnableFooterMenu = false;
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsMenu.ShowAutoFilterRowItem = false;
            this.gridView1.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            this.gridView1.OptionsMenu.ShowGroupSortSummaryItems = false;
            this.gridView1.OptionsMenu.ShowSplitItem = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowHeight = 25;
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // colMaSo
            // 
            this.colMaSo.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.colMaSo.AppearanceCell.Options.UseFont = true;
            this.colMaSo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F);
            this.colMaSo.AppearanceHeader.Options.UseFont = true;
            this.colMaSo.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaSo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaSo.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMaSo.Caption = "Mã hàng";
            this.colMaSo.FieldName = "HH_MAHANG";
            this.colMaSo.Name = "colMaSo";
            this.colMaSo.OptionsColumn.AllowEdit = false;
            this.colMaSo.OptionsColumn.ReadOnly = true;
            this.colMaSo.OptionsFilter.AllowAutoFilter = false;
            this.colMaSo.OptionsFilter.AllowFilter = false;
            this.colMaSo.Visible = true;
            this.colMaSo.VisibleIndex = 0;
            this.colMaSo.Width = 100;
            // 
            // colTenKhachHang
            // 
            this.colTenKhachHang.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.colTenKhachHang.AppearanceCell.Options.UseFont = true;
            this.colTenKhachHang.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F);
            this.colTenKhachHang.AppearanceHeader.Options.UseFont = true;
            this.colTenKhachHang.AppearanceHeader.Options.UseTextOptions = true;
            this.colTenKhachHang.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTenKhachHang.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTenKhachHang.Caption = "Tên hàng";
            this.colTenKhachHang.FieldName = "HH_TENHANG";
            this.colTenKhachHang.Name = "colTenKhachHang";
            this.colTenKhachHang.OptionsColumn.AllowEdit = false;
            this.colTenKhachHang.OptionsColumn.AllowShowHide = false;
            this.colTenKhachHang.OptionsColumn.ReadOnly = true;
            this.colTenKhachHang.OptionsFilter.AllowAutoFilter = false;
            this.colTenKhachHang.OptionsFilter.AllowFilter = false;
            this.colTenKhachHang.Visible = true;
            this.colTenKhachHang.VisibleIndex = 1;
            this.colTenKhachHang.Width = 197;
            // 
            // colDiaChi
            // 
            this.colDiaChi.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.colDiaChi.AppearanceCell.Options.UseFont = true;
            this.colDiaChi.AppearanceCell.Options.UseTextOptions = true;
            this.colDiaChi.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDiaChi.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDiaChi.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F);
            this.colDiaChi.AppearanceHeader.Options.UseFont = true;
            this.colDiaChi.AppearanceHeader.Options.UseTextOptions = true;
            this.colDiaChi.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDiaChi.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDiaChi.Caption = "Đơn vị tính";
            this.colDiaChi.FieldName = "DVT_TENDONVI";
            this.colDiaChi.Name = "colDiaChi";
            this.colDiaChi.OptionsColumn.AllowEdit = false;
            this.colDiaChi.OptionsColumn.ReadOnly = true;
            this.colDiaChi.OptionsFilter.AllowAutoFilter = false;
            this.colDiaChi.OptionsFilter.AllowFilter = false;
            this.colDiaChi.Visible = true;
            this.colDiaChi.VisibleIndex = 2;
            this.colDiaChi.Width = 80;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn1.AppearanceCell.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn1.Caption = "Giá mua";
            this.gridColumn1.DisplayFormat.FormatString = "n0";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn1.FieldName = "HH_GIAMUA";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 3;
            this.gridColumn1.Width = 107;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn2.AppearanceCell.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn2.Caption = "Giá bán sỉ";
            this.gridColumn2.DisplayFormat.FormatString = "n0";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn2.FieldName = "HH_GIABANSI";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Width = 109;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn3.AppearanceCell.Options.UseFont = true;
            this.gridColumn3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn3.AppearanceHeader.Options.UseFont = true;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn3.Caption = "Giá bán lẻ";
            this.gridColumn3.DisplayFormat.FormatString = "n0";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn3.FieldName = "HH_GIABANLE";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 4;
            this.gridColumn3.Width = 115;
            // 
            // colDienThoai
            // 
            this.colDienThoai.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.colDienThoai.AppearanceCell.Options.UseFont = true;
            this.colDienThoai.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F);
            this.colDienThoai.AppearanceHeader.Options.UseFont = true;
            this.colDienThoai.AppearanceHeader.Options.UseTextOptions = true;
            this.colDienThoai.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDienThoai.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDienThoai.Caption = "Khuyến mãi (%)";
            this.colDienThoai.DisplayFormat.FormatString = "n1";
            this.colDienThoai.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDienThoai.FieldName = "HH_KHUYENMAI";
            this.colDienThoai.Name = "colDienThoai";
            this.colDienThoai.Width = 105;
            // 
            // colQuanLy
            // 
            this.colQuanLy.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.colQuanLy.AppearanceCell.Options.UseFont = true;
            this.colQuanLy.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F);
            this.colQuanLy.AppearanceHeader.Options.UseFont = true;
            this.colQuanLy.AppearanceHeader.Options.UseTextOptions = true;
            this.colQuanLy.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colQuanLy.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colQuanLy.Caption = "Quản lý";
            this.colQuanLy.ColumnEdit = this.colQuanLyCheckEdit;
            this.colQuanLy.FieldName = "HH_KICHHOAT";
            this.colQuanLy.Name = "colQuanLy";
            this.colQuanLy.OptionsColumn.AllowEdit = false;
            this.colQuanLy.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colQuanLy.OptionsColumn.ReadOnly = true;
            this.colQuanLy.OptionsFilter.AllowAutoFilter = false;
            this.colQuanLy.OptionsFilter.AllowFilter = false;
            this.colQuanLy.Visible = true;
            this.colQuanLy.VisibleIndex = 5;
            this.colQuanLy.Width = 67;
            // 
            // colQuanLyCheckEdit
            // 
            this.colQuanLyCheckEdit.Name = "colQuanLyCheckEdit";
            this.colQuanLyCheckEdit.ReadOnly = true;
            this.colQuanLyCheckEdit.ValueChecked = 1;
            this.colQuanLyCheckEdit.ValueUnchecked = 0;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.gridDVT);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.ShowCaption = false;
            this.groupControl2.Size = new System.Drawing.Size(900, 329);
            this.groupControl2.TabIndex = 5;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl1.Location = new System.Drawing.Point(77, 42);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Loại hàng:";
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl3.Location = new System.Drawing.Point(77, 70);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(70, 16);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Nhóm hàng:";
            // 
            // labelControl5
            // 
            this.labelControl5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl5.Location = new System.Drawing.Point(77, 14);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(59, 16);
            this.labelControl5.TabIndex = 2;
            this.labelControl5.Text = "Tên hàng:";
            // 
            // labelControl18
            // 
            this.labelControl18.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl18.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl18.Location = new System.Drawing.Point(443, 14);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Size = new System.Drawing.Size(66, 16);
            this.labelControl18.TabIndex = 2;
            this.labelControl18.Text = "Đơn vị tính:";
            // 
            // labelControl6
            // 
            this.labelControl6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl6.Location = new System.Drawing.Point(77, 98);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(47, 16);
            this.labelControl6.TabIndex = 2;
            this.labelControl6.Text = "Ghi chú:";
            // 
            // labelControl8
            // 
            this.labelControl8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl8.Location = new System.Drawing.Point(443, 42);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(52, 16);
            this.labelControl8.TabIndex = 2;
            this.labelControl8.Text = "Giá mua:";
            // 
            // labelControl15
            // 
            this.labelControl15.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl15.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl15.Location = new System.Drawing.Point(443, 70);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(62, 16);
            this.labelControl15.TabIndex = 2;
            this.labelControl15.Text = "Giá bán lẻ:";
            // 
            // labelControl16
            // 
            this.labelControl16.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl16.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl16.Location = new System.Drawing.Point(660, 14);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(77, 16);
            this.labelControl16.TabIndex = 2;
            this.labelControl16.Text = "Tồn tối thiểu:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDong);
            this.groupBox1.Controls.Add(this.btnExcel);
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.btnSua);
            this.groupBox1.Controls.Add(this.btnNhapExcel);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(2, 121);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(896, 48);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            // 
            // btnDong
            // 
            this.btnDong.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDong.Image = ((System.Drawing.Image)(resources.GetObject("btnDong.Image")));
            this.btnDong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDong.Location = new System.Drawing.Point(595, 11);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(95, 31);
            this.btnDong.TabIndex = 32;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcel.Location = new System.Drawing.Point(500, 11);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(95, 31);
            this.btnExcel.TabIndex = 31;
            this.btnExcel.Text = "Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa.Location = new System.Drawing.Point(405, 11);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(95, 31);
            this.btnXoa.TabIndex = 30;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Image = ((System.Drawing.Image)(resources.GetObject("btnSua.Image")));
            this.btnSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSua.Location = new System.Drawing.Point(310, 11);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(95, 31);
            this.btnSua.TabIndex = 29;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnNhapExcel
            // 
            this.btnNhapExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNhapExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhapExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnNhapExcel.Image")));
            this.btnNhapExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNhapExcel.Location = new System.Drawing.Point(741, 11);
            this.btnNhapExcel.Name = "btnNhapExcel";
            this.btnNhapExcel.Size = new System.Drawing.Size(145, 31);
            this.btnNhapExcel.TabIndex = 33;
            this.btnNhapExcel.Text = "Nhập từ Excel";
            this.btnNhapExcel.UseVisualStyleBackColor = true;
            this.btnNhapExcel.Click += new System.EventHandler(this.btnNhapExcel_Click);
            // 
            // btnThem
            // 
            this.btnThem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(215, 11);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(95, 31);
            this.btnThem.TabIndex = 28;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtLoaiHangMa
            // 
            this.txtLoaiHangMa.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtLoaiHangMa.EnterMoveNextControl = true;
            this.txtLoaiHangMa.Location = new System.Drawing.Point(173, 39);
            this.txtLoaiHangMa.Name = "txtLoaiHangMa";
            this.txtLoaiHangMa.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtLoaiHangMa.Properties.Appearance.Options.UseFont = true;
            this.txtLoaiHangMa.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.AliceBlue;
            this.txtLoaiHangMa.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtLoaiHangMa.Properties.ReadOnly = true;
            this.txtLoaiHangMa.Size = new System.Drawing.Size(72, 22);
            this.txtLoaiHangMa.TabIndex = 9;
            this.txtLoaiHangMa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLoaiHangMa_KeyDown);
            // 
            // txtLoaiHangTen
            // 
            this.txtLoaiHangTen.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtLoaiHangTen.EnterMoveNextControl = true;
            this.txtLoaiHangTen.Location = new System.Drawing.Point(251, 39);
            this.txtLoaiHangTen.Name = "txtLoaiHangTen";
            this.txtLoaiHangTen.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtLoaiHangTen.Properties.Appearance.Options.UseFont = true;
            this.txtLoaiHangTen.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.AliceBlue;
            this.txtLoaiHangTen.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtLoaiHangTen.Properties.ReadOnly = true;
            this.txtLoaiHangTen.Size = new System.Drawing.Size(179, 22);
            this.txtLoaiHangTen.TabIndex = 10;
            // 
            // txtNhomHangTen
            // 
            this.txtNhomHangTen.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtNhomHangTen.EnterMoveNextControl = true;
            this.txtNhomHangTen.Location = new System.Drawing.Point(251, 67);
            this.txtNhomHangTen.Name = "txtNhomHangTen";
            this.txtNhomHangTen.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtNhomHangTen.Properties.Appearance.Options.UseFont = true;
            this.txtNhomHangTen.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.AliceBlue;
            this.txtNhomHangTen.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtNhomHangTen.Properties.ReadOnly = true;
            this.txtNhomHangTen.Size = new System.Drawing.Size(179, 22);
            this.txtNhomHangTen.TabIndex = 12;
            // 
            // txtNhomHangMa
            // 
            this.txtNhomHangMa.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtNhomHangMa.EnterMoveNextControl = true;
            this.txtNhomHangMa.Location = new System.Drawing.Point(173, 67);
            this.txtNhomHangMa.Name = "txtNhomHangMa";
            this.txtNhomHangMa.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtNhomHangMa.Properties.Appearance.Options.UseFont = true;
            this.txtNhomHangMa.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.AliceBlue;
            this.txtNhomHangMa.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtNhomHangMa.Properties.ReadOnly = true;
            this.txtNhomHangMa.Size = new System.Drawing.Size(72, 22);
            this.txtNhomHangMa.TabIndex = 11;
            this.txtNhomHangMa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNhomHangMa_KeyDown);
            // 
            // txtTenHang
            // 
            this.txtTenHang.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtTenHang.EnterMoveNextControl = true;
            this.txtTenHang.Location = new System.Drawing.Point(251, 11);
            this.txtTenHang.Name = "txtTenHang";
            this.txtTenHang.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtTenHang.Properties.Appearance.Options.UseFont = true;
            this.txtTenHang.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.AliceBlue;
            this.txtTenHang.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtTenHang.Properties.ReadOnly = true;
            this.txtTenHang.Size = new System.Drawing.Size(179, 22);
            this.txtTenHang.TabIndex = 8;
            // 
            // txtMaHang
            // 
            this.txtMaHang.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtMaHang.EnterMoveNextControl = true;
            this.txtMaHang.Location = new System.Drawing.Point(173, 11);
            this.txtMaHang.Name = "txtMaHang";
            this.txtMaHang.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtMaHang.Properties.Appearance.Options.UseFont = true;
            this.txtMaHang.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.AliceBlue;
            this.txtMaHang.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtMaHang.Properties.ReadOnly = true;
            this.txtMaHang.Size = new System.Drawing.Size(72, 22);
            this.txtMaHang.TabIndex = 7;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtGhiChu.EnterMoveNextControl = true;
            this.txtGhiChu.Location = new System.Drawing.Point(173, 95);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtGhiChu.Properties.Appearance.Options.UseFont = true;
            this.txtGhiChu.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.AliceBlue;
            this.txtGhiChu.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtGhiChu.Properties.ReadOnly = true;
            this.txtGhiChu.Size = new System.Drawing.Size(519, 22);
            this.txtGhiChu.TabIndex = 21;
            // 
            // txtGiaMua
            // 
            this.txtGiaMua.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtGiaMua.EnterMoveNextControl = true;
            this.txtGiaMua.Location = new System.Drawing.Point(531, 39);
            this.txtGiaMua.Name = "txtGiaMua";
            this.txtGiaMua.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtGiaMua.Properties.Appearance.Options.UseFont = true;
            this.txtGiaMua.Properties.Appearance.Options.UseTextOptions = true;
            this.txtGiaMua.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtGiaMua.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtGiaMua.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.AliceBlue;
            this.txtGiaMua.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtGiaMua.Properties.Mask.EditMask = "n0";
            this.txtGiaMua.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtGiaMua.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtGiaMua.Properties.MaxLength = 15;
            this.txtGiaMua.Properties.ReadOnly = true;
            this.txtGiaMua.Size = new System.Drawing.Size(270, 22);
            this.txtGiaMua.TabIndex = 19;
            this.txtGiaMua.TextChanged += new System.EventHandler(this.txtGiaMua_TextChanged);
            this.txtGiaMua.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGiaMua_KeyDown);
            // 
            // txtGiaBanLe
            // 
            this.txtGiaBanLe.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtGiaBanLe.EnterMoveNextControl = true;
            this.txtGiaBanLe.Location = new System.Drawing.Point(531, 67);
            this.txtGiaBanLe.Name = "txtGiaBanLe";
            this.txtGiaBanLe.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtGiaBanLe.Properties.Appearance.Options.UseFont = true;
            this.txtGiaBanLe.Properties.Appearance.Options.UseTextOptions = true;
            this.txtGiaBanLe.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtGiaBanLe.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtGiaBanLe.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.AliceBlue;
            this.txtGiaBanLe.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtGiaBanLe.Properties.Mask.EditMask = "n0";
            this.txtGiaBanLe.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtGiaBanLe.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtGiaBanLe.Properties.ReadOnly = true;
            this.txtGiaBanLe.Size = new System.Drawing.Size(270, 22);
            this.txtGiaBanLe.TabIndex = 20;
            // 
            // txtTonToiThieu
            // 
            this.txtTonToiThieu.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtTonToiThieu.EditValue = "";
            this.txtTonToiThieu.EnterMoveNextControl = true;
            this.txtTonToiThieu.Location = new System.Drawing.Point(743, 11);
            this.txtTonToiThieu.Name = "txtTonToiThieu";
            this.txtTonToiThieu.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtTonToiThieu.Properties.Appearance.Options.UseFont = true;
            this.txtTonToiThieu.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTonToiThieu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTonToiThieu.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtTonToiThieu.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.AliceBlue;
            this.txtTonToiThieu.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtTonToiThieu.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTonToiThieu.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTonToiThieu.Properties.Mask.EditMask = "n1";
            this.txtTonToiThieu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTonToiThieu.Properties.ReadOnly = true;
            this.txtTonToiThieu.Size = new System.Drawing.Size(58, 22);
            this.txtTonToiThieu.TabIndex = 18;
            // 
            // chkQuanLy
            // 
            this.chkQuanLy.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkQuanLy.EditValue = true;
            this.chkQuanLy.EnterMoveNextControl = true;
            this.chkQuanLy.Location = new System.Drawing.Point(709, 95);
            this.chkQuanLy.Name = "chkQuanLy";
            this.chkQuanLy.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.chkQuanLy.Properties.Appearance.Options.UseFont = true;
            this.chkQuanLy.Properties.Caption = "Còn quản lý";
            this.chkQuanLy.Properties.ReadOnly = true;
            this.chkQuanLy.Size = new System.Drawing.Size(92, 21);
            this.chkQuanLy.TabIndex = 22;
            // 
            // lkuDonViTinh
            // 
            this.lkuDonViTinh.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lkuDonViTinh.EditValue = "";
            this.lkuDonViTinh.EnterMoveNextControl = true;
            this.lkuDonViTinh.Location = new System.Drawing.Point(531, 11);
            this.lkuDonViTinh.Name = "lkuDonViTinh";
            this.lkuDonViTinh.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lkuDonViTinh.Properties.Appearance.Options.UseFont = true;
            this.lkuDonViTinh.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.AliceBlue;
            this.lkuDonViTinh.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.lkuDonViTinh.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkuDonViTinh.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DVT_MADONVI", "Mã đơn vị"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DVT_TENDONVI", "Tên đơn vị")});
            this.lkuDonViTinh.Properties.DisplayMember = "DVT_TENDONVI";
            this.lkuDonViTinh.Properties.NullText = "Chọn đơn vị";
            this.lkuDonViTinh.Properties.ReadOnly = true;
            this.lkuDonViTinh.Properties.ValueMember = "DVT_MADONVI";
            this.lkuDonViTinh.Size = new System.Drawing.Size(107, 22);
            this.lkuDonViTinh.TabIndex = 17;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.lkuDonViTinh);
            this.groupControl1.Controls.Add(this.chkQuanLy);
            this.groupControl1.Controls.Add(this.txtTonToiThieu);
            this.groupControl1.Controls.Add(this.txtGiaBanLe);
            this.groupControl1.Controls.Add(this.txtGiaMua);
            this.groupControl1.Controls.Add(this.txtGhiChu);
            this.groupControl1.Controls.Add(this.txtMaHang);
            this.groupControl1.Controls.Add(this.txtTenHang);
            this.groupControl1.Controls.Add(this.txtNhomHangMa);
            this.groupControl1.Controls.Add(this.txtNhomHangTen);
            this.groupControl1.Controls.Add(this.txtLoaiHangTen);
            this.groupControl1.Controls.Add(this.txtLoaiHangMa);
            this.groupControl1.Controls.Add(this.groupBox1);
            this.groupControl1.Controls.Add(this.labelControl16);
            this.groupControl1.Controls.Add(this.labelControl15);
            this.groupControl1.Controls.Add(this.labelControl8);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.labelControl18);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl1.Location = new System.Drawing.Point(0, 329);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(900, 171);
            this.groupControl1.TabIndex = 0;
            // 
            // frmDMHangHoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDMHangHoa";
            this.Text = "Hàng hóa";
            ((System.ComponentModel.ISupportInitialize)(this.gridDVT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colQuanLyCheckEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtLoaiHangMa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoaiHangTen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNhomHangTen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNhomHangMa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenHang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaHang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGiaMua.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGiaBanLe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTonToiThieu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkQuanLy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkuDonViTinh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridDVT;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colMaSo;
        private DevExpress.XtraGrid.Columns.GridColumn colTenKhachHang;
        private DevExpress.XtraGrid.Columns.GridColumn colDiaChi;
        private DevExpress.XtraGrid.Columns.GridColumn colDienThoai;
        private DevExpress.XtraGrid.Columns.GridColumn colQuanLy;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit colQuanLyCheckEdit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl18;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnNhapExcel;
        private System.Windows.Forms.Button btnThem;
        private DevExpress.XtraEditors.TextEdit txtLoaiHangMa;
        private DevExpress.XtraEditors.TextEdit txtLoaiHangTen;
        private DevExpress.XtraEditors.TextEdit txtNhomHangTen;
        private DevExpress.XtraEditors.TextEdit txtNhomHangMa;
        private DevExpress.XtraEditors.TextEdit txtTenHang;
        private DevExpress.XtraEditors.TextEdit txtMaHang;
        private DevExpress.XtraEditors.TextEdit txtGhiChu;
        private DevExpress.XtraEditors.TextEdit txtGiaMua;
        private DevExpress.XtraEditors.TextEdit txtGiaBanLe;
        private DevExpress.XtraEditors.TextEdit txtTonToiThieu;
        private DevExpress.XtraEditors.CheckEdit chkQuanLy;
        private DevExpress.XtraEditors.LookUpEdit lkuDonViTinh;
        private DevExpress.XtraEditors.GroupControl groupControl1;

    }
}