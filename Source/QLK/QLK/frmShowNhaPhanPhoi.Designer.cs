namespace QLK
{
    partial class frmShowNhaPhanPhoi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowNhaPhanPhoi));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnDong = new DevExpress.XtraEditors.SimpleButton();
            this.btnChon = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gridDVT = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaDonVi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenDonVi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuanLy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuanLyCheckEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colMacDinh = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDVT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colQuanLyCheckEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnDong);
            this.groupControl1.Controls.Add(this.btnChon);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl1.Location = new System.Drawing.Point(0, 401);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(784, 60);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.TabStop = true;
            // 
            // btnDong
            // 
            this.btnDong.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDong.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnDong.Appearance.Options.UseFont = true;
            this.btnDong.Image = ((System.Drawing.Image)(resources.GetObject("btnDong.Image")));
            this.btnDong.Location = new System.Drawing.Point(395, 14);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(88, 32);
            this.btnDong.TabIndex = 3;
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnChon
            // 
            this.btnChon.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnChon.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnChon.Appearance.Options.UseFont = true;
            this.btnChon.Image = ((System.Drawing.Image)(resources.GetObject("btnChon.Image")));
            this.btnChon.Location = new System.Drawing.Point(301, 14);
            this.btnChon.Name = "btnChon";
            this.btnChon.Size = new System.Drawing.Size(88, 32);
            this.btnChon.TabIndex = 2;
            this.btnChon.Text = "Chọn";
            this.btnChon.Click += new System.EventHandler(this.btnChon_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.gridDVT);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.ShowCaption = false;
            this.groupControl2.Size = new System.Drawing.Size(784, 401);
            this.groupControl2.TabIndex = 1;
            // 
            // gridDVT
            // 
            this.gridDVT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDVT.Location = new System.Drawing.Point(2, 2);
            this.gridDVT.MainView = this.gridView1;
            this.gridDVT.Name = "gridDVT";
            this.gridDVT.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.colQuanLyCheckEdit});
            this.gridDVT.Size = new System.Drawing.Size(780, 397);
            this.gridDVT.TabIndex = 0;
            this.gridDVT.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridDVT.DoubleClick += new System.EventHandler(this.gridDVT_DoubleClick);
            this.gridDVT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridDVT_KeyDown);
            // 
            // gridView1
            // 
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
            this.colMaDonVi.Caption = "Mã nhà phân phối";
            this.colMaDonVi.FieldName = "NPP_MANPP";
            this.colMaDonVi.Name = "colMaDonVi";
            this.colMaDonVi.OptionsColumn.AllowEdit = false;
            this.colMaDonVi.OptionsColumn.ReadOnly = true;
            this.colMaDonVi.OptionsFilter.AllowAutoFilter = false;
            this.colMaDonVi.OptionsFilter.AllowFilter = false;
            this.colMaDonVi.Visible = true;
            this.colMaDonVi.VisibleIndex = 0;
            this.colMaDonVi.Width = 89;
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
            this.colTenDonVi.Caption = "Tên nhà phân phối";
            this.colTenDonVi.FieldName = "NPP_TENNPP";
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
            this.colGhiChu.FieldName = "NPP_GHICHU";
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
            this.colQuanLy.AppearanceHeader.Options.UseTextOptions = true;
            this.colQuanLy.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colQuanLy.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colQuanLy.Caption = "Quản lý";
            this.colQuanLy.ColumnEdit = this.colQuanLyCheckEdit;
            this.colQuanLy.FieldName = "LH_KICHHOAT";
            this.colQuanLy.Name = "colQuanLy";
            this.colQuanLy.OptionsColumn.AllowEdit = false;
            this.colQuanLy.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colQuanLy.OptionsColumn.ReadOnly = true;
            this.colQuanLy.OptionsFilter.AllowAutoFilter = false;
            this.colQuanLy.OptionsFilter.AllowFilter = false;
            this.colQuanLy.Width = 106;
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
            this.colMacDinh.Caption = "Mặc định";
            this.colMacDinh.FieldName = "DVT_MACDINH";
            this.colMacDinh.Name = "colMacDinh";
            // 
            // frmShowNhaPhanPhoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmShowNhaPhanPhoi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nhà phân phối";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDVT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colQuanLyCheckEdit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton btnDong;
        private DevExpress.XtraEditors.SimpleButton btnChon;
        private DevExpress.XtraGrid.GridControl gridDVT;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colMaDonVi;
        private DevExpress.XtraGrid.Columns.GridColumn colTenDonVi;
        private DevExpress.XtraGrid.Columns.GridColumn colGhiChu;
        private DevExpress.XtraGrid.Columns.GridColumn colQuanLy;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit colQuanLyCheckEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colMacDinh;
    }
}