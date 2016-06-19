namespace QLK
{
    partial class frmDMDonVi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDMDonVi));
            this.gridDVT = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaDonVi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenDonVi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuanLy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuanLyCheckEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colMacDinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.chkQuanLy = new DevExpress.XtraEditors.CheckEdit();
            this.txtGhiChu = new DevExpress.XtraEditors.TextEdit();
            this.txtTenDonVi = new DevExpress.XtraEditors.TextEdit();
            this.txtMaDonVi = new DevExpress.XtraEditors.TextEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridDVT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colQuanLyCheckEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkQuanLy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDonVi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaDonVi.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridDVT
            // 
            this.gridDVT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDVT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridDVT.Location = new System.Drawing.Point(2, 2);
            this.gridDVT.MainView = this.gridView1;
            this.gridDVT.Name = "gridDVT";
            this.gridDVT.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.colQuanLyCheckEdit});
            this.gridDVT.Size = new System.Drawing.Size(696, 247);
            this.gridDVT.TabIndex = 0;
            this.gridDVT.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridView1.Appearance.GroupPanel.Options.UseFont = true;
            this.gridView1.ColumnPanelRowHeight = 25;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaDonVi,
            this.colTenDonVi,
            this.colGhiChu,
            this.colQuanLy,
            this.colMacDinh});
            this.gridView1.GridControl = this.gridDVT;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowHeight = 25;
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // colMaDonVi
            // 
            this.colMaDonVi.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.colMaDonVi.AppearanceCell.Options.UseFont = true;
            this.colMaDonVi.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F);
            this.colMaDonVi.AppearanceHeader.Options.UseFont = true;
            this.colMaDonVi.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaDonVi.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaDonVi.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMaDonVi.Caption = "Mã đơn vị";
            this.colMaDonVi.FieldName = "DVT_MADONVI";
            this.colMaDonVi.Name = "colMaDonVi";
            this.colMaDonVi.OptionsColumn.AllowEdit = false;
            this.colMaDonVi.OptionsColumn.ReadOnly = true;
            this.colMaDonVi.OptionsFilter.AllowAutoFilter = false;
            this.colMaDonVi.OptionsFilter.AllowFilter = false;
            this.colMaDonVi.Visible = true;
            this.colMaDonVi.VisibleIndex = 0;
            this.colMaDonVi.Width = 80;
            // 
            // colTenDonVi
            // 
            this.colTenDonVi.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.colTenDonVi.AppearanceCell.Options.UseFont = true;
            this.colTenDonVi.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F);
            this.colTenDonVi.AppearanceHeader.Options.UseFont = true;
            this.colTenDonVi.AppearanceHeader.Options.UseTextOptions = true;
            this.colTenDonVi.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTenDonVi.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTenDonVi.Caption = "Tên đơn vị";
            this.colTenDonVi.FieldName = "DVT_TENDONVI";
            this.colTenDonVi.Name = "colTenDonVi";
            this.colTenDonVi.OptionsColumn.AllowEdit = false;
            this.colTenDonVi.OptionsColumn.ReadOnly = true;
            this.colTenDonVi.OptionsFilter.AllowAutoFilter = false;
            this.colTenDonVi.OptionsFilter.AllowFilter = false;
            this.colTenDonVi.Visible = true;
            this.colTenDonVi.VisibleIndex = 1;
            this.colTenDonVi.Width = 222;
            // 
            // colGhiChu
            // 
            this.colGhiChu.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.colGhiChu.AppearanceCell.Options.UseFont = true;
            this.colGhiChu.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F);
            this.colGhiChu.AppearanceHeader.Options.UseFont = true;
            this.colGhiChu.AppearanceHeader.Options.UseTextOptions = true;
            this.colGhiChu.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGhiChu.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colGhiChu.Caption = "Ghi chú";
            this.colGhiChu.FieldName = "DVT_GHICHU";
            this.colGhiChu.Name = "colGhiChu";
            this.colGhiChu.OptionsColumn.AllowEdit = false;
            this.colGhiChu.OptionsColumn.ReadOnly = true;
            this.colGhiChu.OptionsFilter.AllowAutoFilter = false;
            this.colGhiChu.OptionsFilter.AllowFilter = false;
            this.colGhiChu.Visible = true;
            this.colGhiChu.VisibleIndex = 2;
            this.colGhiChu.Width = 232;
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
            this.colQuanLy.FieldName = "DVT_KICHHOAT";
            this.colQuanLy.Name = "colQuanLy";
            this.colQuanLy.OptionsColumn.AllowEdit = false;
            this.colQuanLy.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colQuanLy.OptionsColumn.ReadOnly = true;
            this.colQuanLy.OptionsFilter.AllowAutoFilter = false;
            this.colQuanLy.OptionsFilter.AllowFilter = false;
            this.colQuanLy.Visible = true;
            this.colQuanLy.VisibleIndex = 3;
            this.colQuanLy.Width = 117;
            // 
            // colQuanLyCheckEdit
            // 
            this.colQuanLyCheckEdit.Name = "colQuanLyCheckEdit";
            this.colQuanLyCheckEdit.ReadOnly = true;
            this.colQuanLyCheckEdit.ValueChecked = 1;
            this.colQuanLyCheckEdit.ValueUnchecked = 0;
            // 
            // colMacDinh
            // 
            this.colMacDinh.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.colMacDinh.AppearanceCell.Options.UseFont = true;
            this.colMacDinh.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F);
            this.colMacDinh.AppearanceHeader.Options.UseFont = true;
            this.colMacDinh.AppearanceHeader.Options.UseTextOptions = true;
            this.colMacDinh.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMacDinh.Caption = "Mặc định";
            this.colMacDinh.FieldName = "DVT_MACDINH";
            this.colMacDinh.Name = "colMacDinh";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.chkQuanLy);
            this.groupControl1.Controls.Add(this.txtGhiChu);
            this.groupControl1.Controls.Add(this.txtTenDonVi);
            this.groupControl1.Controls.Add(this.txtMaDonVi);
            this.groupControl1.Controls.Add(this.groupBox1);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl1.Location = new System.Drawing.Point(0, 251);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(700, 149);
            this.groupControl1.TabIndex = 1;
            // 
            // chkQuanLy
            // 
            this.chkQuanLy.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkQuanLy.EditValue = true;
            this.chkQuanLy.EnterMoveNextControl = true;
            this.chkQuanLy.Location = new System.Drawing.Point(501, 70);
            this.chkQuanLy.Name = "chkQuanLy";
            this.chkQuanLy.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.chkQuanLy.Properties.Appearance.Options.UseFont = true;
            this.chkQuanLy.Properties.Caption = "Còn quản lý";
            this.chkQuanLy.Size = new System.Drawing.Size(102, 21);
            this.chkQuanLy.TabIndex = 7;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtGhiChu.EnterMoveNextControl = true;
            this.txtGhiChu.Location = new System.Drawing.Point(184, 42);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtGhiChu.Properties.Appearance.Options.UseFont = true;
            this.txtGhiChu.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.AliceBlue;
            this.txtGhiChu.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtGhiChu.Properties.ReadOnly = true;
            this.txtGhiChu.Size = new System.Drawing.Size(408, 22);
            this.txtGhiChu.TabIndex = 6;
            // 
            // txtTenDonVi
            // 
            this.txtTenDonVi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtTenDonVi.EnterMoveNextControl = true;
            this.txtTenDonVi.Location = new System.Drawing.Point(363, 14);
            this.txtTenDonVi.Name = "txtTenDonVi";
            this.txtTenDonVi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtTenDonVi.Properties.Appearance.Options.UseFont = true;
            this.txtTenDonVi.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.AliceBlue;
            this.txtTenDonVi.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtTenDonVi.Properties.ReadOnly = true;
            this.txtTenDonVi.Size = new System.Drawing.Size(229, 22);
            this.txtTenDonVi.TabIndex = 5;
            // 
            // txtMaDonVi
            // 
            this.txtMaDonVi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtMaDonVi.EnterMoveNextControl = true;
            this.txtMaDonVi.Location = new System.Drawing.Point(186, 14);
            this.txtMaDonVi.Name = "txtMaDonVi";
            this.txtMaDonVi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtMaDonVi.Properties.Appearance.Options.UseFont = true;
            this.txtMaDonVi.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.AliceBlue;
            this.txtMaDonVi.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtMaDonVi.Properties.ReadOnly = true;
            this.txtMaDonVi.Size = new System.Drawing.Size(100, 22);
            this.txtMaDonVi.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDong);
            this.groupBox1.Controls.Add(this.btnExcel);
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.btnSua);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(2, 99);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(696, 48);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // btnDong
            // 
            this.btnDong.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDong.Image = ((System.Drawing.Image)(resources.GetObject("btnDong.Image")));
            this.btnDong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDong.Location = new System.Drawing.Point(469, 11);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(77, 31);
            this.btnDong.TabIndex = 1;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcel.Location = new System.Drawing.Point(382, 11);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(87, 31);
            this.btnExcel.TabIndex = 1;
            this.btnExcel.Text = "Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa.Location = new System.Drawing.Point(307, 11);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 31);
            this.btnXoa.TabIndex = 1;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSua.Image = ((System.Drawing.Image)(resources.GetObject("btnSua.Image")));
            this.btnSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSua.Location = new System.Drawing.Point(223, 11);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(84, 31);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(139, 11);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(84, 31);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl3.Location = new System.Drawing.Point(120, 45);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(47, 16);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Ghi chú:";
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl2.Location = new System.Drawing.Point(292, 17);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(65, 16);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Tên đơn vị:";
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl1.Location = new System.Drawing.Point(120, 17);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Mã đơn vị:";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.gridDVT);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.ShowCaption = false;
            this.groupControl2.Size = new System.Drawing.Size(700, 251);
            this.groupControl2.TabIndex = 2;
            // 
            // frmDMDonVi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 400);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.Name = "frmDMDonVi";
            this.ShowIcon = false;
            this.Text = "Đơn vị tính";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.gridDVT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colQuanLyCheckEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkQuanLy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDonVi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaDonVi.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridDVT;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colMaDonVi;
        private DevExpress.XtraGrid.Columns.GridColumn colTenDonVi;
        private DevExpress.XtraGrid.Columns.GridColumn colGhiChu;
        private DevExpress.XtraGrid.Columns.GridColumn colQuanLy;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit colQuanLyCheckEdit;
        private DevExpress.XtraEditors.CheckEdit chkQuanLy;
        private DevExpress.XtraEditors.TextEdit txtGhiChu;
        private DevExpress.XtraEditors.TextEdit txtTenDonVi;
        private DevExpress.XtraEditors.TextEdit txtMaDonVi;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private DevExpress.XtraGrid.Columns.GridColumn colMacDinh;
        private DevExpress.XtraEditors.GroupControl groupControl2;

    }
}