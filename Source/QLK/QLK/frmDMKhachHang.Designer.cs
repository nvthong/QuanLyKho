namespace QLK
{
    partial class frmDMKhachHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDMKhachHang));
            this.gridDVT = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaSo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenKhachHang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiaChi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDienThoai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuanLy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuanLyCheckEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.chkQuanLy = new DevExpress.XtraEditors.CheckEdit();
            this.txtGhiChu = new DevExpress.XtraEditors.TextEdit();
            this.txtNganHang = new DevExpress.XtraEditors.TextEdit();
            this.txtWebsite = new DevExpress.XtraEditors.TextEdit();
            this.txtFax = new DevExpress.XtraEditors.TextEdit();
            this.txtEmail = new DevExpress.XtraEditors.TextEdit();
            this.txtNguoiDaiDien = new DevExpress.XtraEditors.TextEdit();
            this.txtTaiKhoan = new DevExpress.XtraEditors.TextEdit();
            this.txtMST = new DevExpress.XtraEditors.TextEdit();
            this.txtSDT = new DevExpress.XtraEditors.TextEdit();
            this.txtDiaChi = new DevExpress.XtraEditors.TextEdit();
            this.txtTenKhachHang = new DevExpress.XtraEditors.TextEdit();
            this.txtMaKhachHang = new DevExpress.XtraEditors.TextEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridDVT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colQuanLyCheckEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkQuanLy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNganHang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWebsite.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNguoiDaiDien.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaiKhoan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMST.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSDT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenKhachHang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaKhachHang.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridDVT
            // 
            this.gridDVT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDVT.Location = new System.Drawing.Point(0, 0);
            this.gridDVT.MainView = this.gridView1;
            this.gridDVT.Name = "gridDVT";
            this.gridDVT.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.colQuanLyCheckEdit});
            this.gridDVT.Size = new System.Drawing.Size(900, 290);
            this.gridDVT.TabIndex = 2;
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
            this.colDienThoai,
            this.colQuanLy});
            this.gridView1.GridControl = this.gridDVT;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsFind.AlwaysVisible = true;
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
            this.colMaSo.Caption = "Mã số";
            this.colMaSo.FieldName = "NPP_MANPP";
            this.colMaSo.Name = "colMaSo";
            this.colMaSo.OptionsColumn.AllowEdit = false;
            this.colMaSo.OptionsColumn.ReadOnly = true;
            this.colMaSo.OptionsFilter.AllowAutoFilter = false;
            this.colMaSo.OptionsFilter.AllowFilter = false;
            this.colMaSo.Visible = true;
            this.colMaSo.VisibleIndex = 0;
            this.colMaSo.Width = 80;
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
            this.colTenKhachHang.Caption = "Tên khách hàng";
            this.colTenKhachHang.FieldName = "NPP_TENNPP";
            this.colTenKhachHang.Name = "colTenKhachHang";
            this.colTenKhachHang.OptionsColumn.AllowEdit = false;
            this.colTenKhachHang.OptionsColumn.ReadOnly = true;
            this.colTenKhachHang.OptionsFilter.AllowAutoFilter = false;
            this.colTenKhachHang.OptionsFilter.AllowFilter = false;
            this.colTenKhachHang.Visible = true;
            this.colTenKhachHang.VisibleIndex = 1;
            this.colTenKhachHang.Width = 255;
            // 
            // colDiaChi
            // 
            this.colDiaChi.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.colDiaChi.AppearanceCell.Options.UseFont = true;
            this.colDiaChi.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F);
            this.colDiaChi.AppearanceHeader.Options.UseFont = true;
            this.colDiaChi.AppearanceHeader.Options.UseTextOptions = true;
            this.colDiaChi.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDiaChi.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDiaChi.Caption = "Địa chỉ";
            this.colDiaChi.FieldName = "NPP_DIACHI";
            this.colDiaChi.Name = "colDiaChi";
            this.colDiaChi.OptionsColumn.AllowEdit = false;
            this.colDiaChi.OptionsColumn.ReadOnly = true;
            this.colDiaChi.OptionsFilter.AllowAutoFilter = false;
            this.colDiaChi.OptionsFilter.AllowFilter = false;
            this.colDiaChi.Visible = true;
            this.colDiaChi.VisibleIndex = 2;
            this.colDiaChi.Width = 302;
            // 
            // colDienThoai
            // 
            this.colDienThoai.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.colDienThoai.AppearanceCell.Options.UseFont = true;
            this.colDienThoai.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F);
            this.colDienThoai.AppearanceHeader.Options.UseFont = true;
            this.colDienThoai.AppearanceHeader.Options.UseTextOptions = true;
            this.colDienThoai.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDienThoai.Caption = "Điện thoại";
            this.colDienThoai.FieldName = "NPP_DIENTHOAI";
            this.colDienThoai.Name = "colDienThoai";
            this.colDienThoai.Visible = true;
            this.colDienThoai.VisibleIndex = 3;
            this.colDienThoai.Width = 160;
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
            this.colQuanLy.FieldName = "NPP_KICHHOAT";
            this.colQuanLy.Name = "colQuanLy";
            this.colQuanLy.OptionsColumn.AllowEdit = false;
            this.colQuanLy.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colQuanLy.OptionsColumn.ReadOnly = true;
            this.colQuanLy.OptionsFilter.AllowAutoFilter = false;
            this.colQuanLy.OptionsFilter.AllowFilter = false;
            this.colQuanLy.Visible = true;
            this.colQuanLy.VisibleIndex = 4;
            this.colQuanLy.Width = 85;
            // 
            // colQuanLyCheckEdit
            // 
            this.colQuanLyCheckEdit.Name = "colQuanLyCheckEdit";
            this.colQuanLyCheckEdit.ReadOnly = true;
            this.colQuanLyCheckEdit.ValueChecked = 1;
            this.colQuanLyCheckEdit.ValueUnchecked = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.chkQuanLy);
            this.groupControl1.Controls.Add(this.txtGhiChu);
            this.groupControl1.Controls.Add(this.txtNganHang);
            this.groupControl1.Controls.Add(this.txtWebsite);
            this.groupControl1.Controls.Add(this.txtFax);
            this.groupControl1.Controls.Add(this.txtEmail);
            this.groupControl1.Controls.Add(this.txtNguoiDaiDien);
            this.groupControl1.Controls.Add(this.txtTaiKhoan);
            this.groupControl1.Controls.Add(this.txtMST);
            this.groupControl1.Controls.Add(this.txtSDT);
            this.groupControl1.Controls.Add(this.txtDiaChi);
            this.groupControl1.Controls.Add(this.txtTenKhachHang);
            this.groupControl1.Controls.Add(this.txtMaKhachHang);
            this.groupControl1.Controls.Add(this.groupBox1);
            this.groupControl1.Controls.Add(this.labelControl12);
            this.groupControl1.Controls.Add(this.labelControl10);
            this.groupControl1.Controls.Add(this.labelControl8);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl11);
            this.groupControl1.Controls.Add(this.labelControl9);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl1.Location = new System.Drawing.Point(0, 290);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(900, 210);
            this.groupControl1.TabIndex = 3;
            // 
            // chkQuanLy
            // 
            this.chkQuanLy.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkQuanLy.EditValue = true;
            this.chkQuanLy.EnterMoveNextControl = true;
            this.chkQuanLy.Location = new System.Drawing.Point(685, 137);
            this.chkQuanLy.Name = "chkQuanLy";
            this.chkQuanLy.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.chkQuanLy.Properties.Appearance.Options.UseFont = true;
            this.chkQuanLy.Properties.Caption = "Còn quản lý";
            this.chkQuanLy.Properties.ReadOnly = true;
            this.chkQuanLy.Size = new System.Drawing.Size(92, 21);
            this.chkQuanLy.TabIndex = 12;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtGhiChu.EnterMoveNextControl = true;
            this.txtGhiChu.Location = new System.Drawing.Point(419, 137);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtGhiChu.Properties.Appearance.Options.UseFont = true;
            this.txtGhiChu.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.AliceBlue;
            this.txtGhiChu.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtGhiChu.Properties.ReadOnly = true;
            this.txtGhiChu.Size = new System.Drawing.Size(257, 22);
            this.txtGhiChu.TabIndex = 11;
            // 
            // txtNganHang
            // 
            this.txtNganHang.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtNganHang.EnterMoveNextControl = true;
            this.txtNganHang.Location = new System.Drawing.Point(520, 111);
            this.txtNganHang.Name = "txtNganHang";
            this.txtNganHang.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtNganHang.Properties.Appearance.Options.UseFont = true;
            this.txtNganHang.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.AliceBlue;
            this.txtNganHang.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtNganHang.Properties.ReadOnly = true;
            this.txtNganHang.Size = new System.Drawing.Size(257, 22);
            this.txtNganHang.TabIndex = 9;
            // 
            // txtWebsite
            // 
            this.txtWebsite.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtWebsite.EnterMoveNextControl = true;
            this.txtWebsite.Location = new System.Drawing.Point(520, 85);
            this.txtWebsite.Name = "txtWebsite";
            this.txtWebsite.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtWebsite.Properties.Appearance.Options.UseFont = true;
            this.txtWebsite.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.AliceBlue;
            this.txtWebsite.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtWebsite.Properties.ReadOnly = true;
            this.txtWebsite.Size = new System.Drawing.Size(257, 22);
            this.txtWebsite.TabIndex = 7;
            // 
            // txtFax
            // 
            this.txtFax.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtFax.EnterMoveNextControl = true;
            this.txtFax.Location = new System.Drawing.Point(520, 60);
            this.txtFax.Name = "txtFax";
            this.txtFax.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtFax.Properties.Appearance.Options.UseFont = true;
            this.txtFax.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.AliceBlue;
            this.txtFax.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtFax.Properties.ReadOnly = true;
            this.txtFax.Size = new System.Drawing.Size(257, 22);
            this.txtFax.TabIndex = 5;
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtEmail.EnterMoveNextControl = true;
            this.txtEmail.Location = new System.Drawing.Point(520, 35);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtEmail.Properties.Appearance.Options.UseFont = true;
            this.txtEmail.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.AliceBlue;
            this.txtEmail.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtEmail.Properties.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(257, 22);
            this.txtEmail.TabIndex = 3;
            // 
            // txtNguoiDaiDien
            // 
            this.txtNguoiDaiDien.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtNguoiDaiDien.EnterMoveNextControl = true;
            this.txtNguoiDaiDien.Location = new System.Drawing.Point(175, 137);
            this.txtNguoiDaiDien.Name = "txtNguoiDaiDien";
            this.txtNguoiDaiDien.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtNguoiDaiDien.Properties.Appearance.Options.UseFont = true;
            this.txtNguoiDaiDien.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.AliceBlue;
            this.txtNguoiDaiDien.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtNguoiDaiDien.Properties.ReadOnly = true;
            this.txtNguoiDaiDien.Size = new System.Drawing.Size(179, 22);
            this.txtNguoiDaiDien.TabIndex = 10;
            // 
            // txtTaiKhoan
            // 
            this.txtTaiKhoan.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtTaiKhoan.EnterMoveNextControl = true;
            this.txtTaiKhoan.Location = new System.Drawing.Point(175, 111);
            this.txtTaiKhoan.Name = "txtTaiKhoan";
            this.txtTaiKhoan.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtTaiKhoan.Properties.Appearance.Options.UseFont = true;
            this.txtTaiKhoan.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.AliceBlue;
            this.txtTaiKhoan.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtTaiKhoan.Properties.ReadOnly = true;
            this.txtTaiKhoan.Size = new System.Drawing.Size(257, 22);
            this.txtTaiKhoan.TabIndex = 8;
            // 
            // txtMST
            // 
            this.txtMST.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtMST.EnterMoveNextControl = true;
            this.txtMST.Location = new System.Drawing.Point(175, 85);
            this.txtMST.Name = "txtMST";
            this.txtMST.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtMST.Properties.Appearance.Options.UseFont = true;
            this.txtMST.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.AliceBlue;
            this.txtMST.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtMST.Properties.ReadOnly = true;
            this.txtMST.Size = new System.Drawing.Size(257, 22);
            this.txtMST.TabIndex = 6;
            // 
            // txtSDT
            // 
            this.txtSDT.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtSDT.EnterMoveNextControl = true;
            this.txtSDT.Location = new System.Drawing.Point(175, 60);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtSDT.Properties.Appearance.Options.UseFont = true;
            this.txtSDT.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.AliceBlue;
            this.txtSDT.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtSDT.Properties.ReadOnly = true;
            this.txtSDT.Size = new System.Drawing.Size(257, 22);
            this.txtSDT.TabIndex = 4;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtDiaChi.EnterMoveNextControl = true;
            this.txtDiaChi.Location = new System.Drawing.Point(175, 35);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtDiaChi.Properties.Appearance.Options.UseFont = true;
            this.txtDiaChi.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.AliceBlue;
            this.txtDiaChi.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtDiaChi.Properties.ReadOnly = true;
            this.txtDiaChi.Size = new System.Drawing.Size(257, 22);
            this.txtDiaChi.TabIndex = 2;
            // 
            // txtTenKhachHang
            // 
            this.txtTenKhachHang.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtTenKhachHang.EnterMoveNextControl = true;
            this.txtTenKhachHang.Location = new System.Drawing.Point(419, 11);
            this.txtTenKhachHang.Name = "txtTenKhachHang";
            this.txtTenKhachHang.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtTenKhachHang.Properties.Appearance.Options.UseFont = true;
            this.txtTenKhachHang.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.AliceBlue;
            this.txtTenKhachHang.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtTenKhachHang.Properties.ReadOnly = true;
            this.txtTenKhachHang.Size = new System.Drawing.Size(358, 22);
            this.txtTenKhachHang.TabIndex = 1;
            // 
            // txtMaKhachHang
            // 
            this.txtMaKhachHang.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtMaKhachHang.EnterMoveNextControl = true;
            this.txtMaKhachHang.Location = new System.Drawing.Point(175, 11);
            this.txtMaKhachHang.Name = "txtMaKhachHang";
            this.txtMaKhachHang.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtMaKhachHang.Properties.Appearance.Options.UseFont = true;
            this.txtMaKhachHang.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.AliceBlue;
            this.txtMaKhachHang.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtMaKhachHang.Properties.ReadOnly = true;
            this.txtMaKhachHang.Size = new System.Drawing.Size(132, 22);
            this.txtMaKhachHang.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDong);
            this.groupBox1.Controls.Add(this.btnExcel);
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.btnSua);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(2, 160);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(896, 48);
            this.groupBox1.TabIndex = 13;
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
            this.btnDong.TabIndex = 18;
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
            this.btnExcel.TabIndex = 17;
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
            this.btnXoa.TabIndex = 16;
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
            this.btnSua.TabIndex = 15;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
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
            this.btnThem.TabIndex = 14;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // labelControl12
            // 
            this.labelControl12.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl12.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl12.Location = new System.Drawing.Point(366, 140);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(47, 16);
            this.labelControl12.TabIndex = 2;
            this.labelControl12.Text = "Ghi chú:";
            // 
            // labelControl10
            // 
            this.labelControl10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl10.Location = new System.Drawing.Point(448, 114);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(66, 16);
            this.labelControl10.TabIndex = 2;
            this.labelControl10.Text = "Ngân hàng:";
            // 
            // labelControl8
            // 
            this.labelControl8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl8.Location = new System.Drawing.Point(448, 88);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(51, 16);
            this.labelControl8.TabIndex = 2;
            this.labelControl8.Text = "Website:";
            // 
            // labelControl6
            // 
            this.labelControl6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl6.Location = new System.Drawing.Point(448, 63);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(25, 16);
            this.labelControl6.TabIndex = 2;
            this.labelControl6.Text = "Fax:";
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl4.Location = new System.Drawing.Point(448, 38);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(36, 16);
            this.labelControl4.TabIndex = 2;
            this.labelControl4.Text = "Email:";
            // 
            // labelControl11
            // 
            this.labelControl11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl11.Location = new System.Drawing.Point(82, 140);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(87, 16);
            this.labelControl11.TabIndex = 2;
            this.labelControl11.Text = "Người địa diện:";
            // 
            // labelControl9
            // 
            this.labelControl9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl9.Location = new System.Drawing.Point(82, 114);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(61, 16);
            this.labelControl9.TabIndex = 2;
            this.labelControl9.Text = "Tài khoản:";
            // 
            // labelControl7
            // 
            this.labelControl7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl7.Location = new System.Drawing.Point(82, 88);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(31, 16);
            this.labelControl7.TabIndex = 2;
            this.labelControl7.Text = "MST:";
            // 
            // labelControl5
            // 
            this.labelControl5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl5.Location = new System.Drawing.Point(82, 63);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(30, 16);
            this.labelControl5.TabIndex = 2;
            this.labelControl5.Text = "SĐT:";
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl3.Location = new System.Drawing.Point(82, 38);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(44, 16);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Địa chỉ:";
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl2.Location = new System.Drawing.Point(313, 14);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(96, 16);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Tên khách hàng:";
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl1.Location = new System.Drawing.Point(82, 14);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(43, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Mã số: ";
            // 
            // frmDMKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Controls.Add(this.gridDVT);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDMKhachHang";
            this.Text = "Khách hàng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.gridDVT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colQuanLyCheckEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkQuanLy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNganHang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWebsite.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNguoiDaiDien.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaiKhoan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMST.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSDT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenKhachHang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaKhachHang.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridDVT;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colMaSo;
        private DevExpress.XtraGrid.Columns.GridColumn colTenKhachHang;
        private DevExpress.XtraGrid.Columns.GridColumn colDiaChi;
        private DevExpress.XtraGrid.Columns.GridColumn colQuanLy;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit colQuanLyCheckEdit;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.CheckEdit chkQuanLy;
        private DevExpress.XtraEditors.TextEdit txtDiaChi;
        private DevExpress.XtraEditors.TextEdit txtTenKhachHang;
        private DevExpress.XtraEditors.TextEdit txtMaKhachHang;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtFax;
        private DevExpress.XtraEditors.TextEdit txtEmail;
        private DevExpress.XtraEditors.TextEdit txtSDT;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txtNganHang;
        private DevExpress.XtraEditors.TextEdit txtWebsite;
        private DevExpress.XtraEditors.TextEdit txtTaiKhoan;
        private DevExpress.XtraEditors.TextEdit txtMST;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.TextEdit txtNguoiDaiDien;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.TextEdit txtGhiChu;
        private DevExpress.XtraGrid.Columns.GridColumn colDienThoai;

    }
}