using DevExpress.XtraEditors;
using DevExpress.XtraTabbedMdi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLK
{
    public partial class Main : Form
    {
        //frmNhapKho formNhapKho = new frmNhapKho();
        //frmNhapKhac formNhapKhac = new frmNhapKhac();
        //frmBangKeNhapKho formBangKeNhapKho = new frmBangKeNhapKho();
        //frmBangKeNhapKhac formBangKeNhapKhac = new frmBangKeNhapKhac();

        //frmXuatBanSi formXuatBanSi = new frmXuatBanSi();
        //frmXuatBanLe formXuatBanLe = new frmXuatBanLe();
        //frmBangKeBanSi formBangKeBanSi = new frmBangKeBanSi();
        //frmBangKeBanLe formBangKeBanLe = new frmBangKeBanLe();
        public Main()
        {
            InitializeComponent();
        }

        #region Sự kiện chức năng xuất bán
        private void btnXuaBanSi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmXuatBanSi formXuatBanSi = new frmXuatBanSi();
            if (ExistFrom(formXuatBanSi)) return;
            formXuatBanSi.MdiParent = this;
            formXuatBanSi.Show();
        }

        private void btnXuatBanLe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmXuatBanLe formXuatBanLe = new frmXuatBanLe();
            if (ExistFrom(formXuatBanLe)) return;
            formXuatBanLe.MdiParent = this;
            formXuatBanLe.Show();
        }

        private void btnXuatKhac_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmXuatKhac formXuatKhac = new frmXuatKhac();
            if (ExistFrom(formXuatKhac)) return;
            formXuatKhac.MdiParent = this;
            formXuatKhac.Show();
        }

        private void btnBangKeBanSi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmBangKeBanSi formBangKeBanSi = new frmBangKeBanSi();
            if (ExistFrom(formBangKeBanSi)) return;
            formBangKeBanSi.MdiParent = this;
            formBangKeBanSi.Show();
        }

        private void btnBangKeBanLe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmBangKeBanLe formBangKeBanLe = new frmBangKeBanLe();
            if (ExistFrom(formBangKeBanLe)) return;
            formBangKeBanLe.MdiParent = this;
            formBangKeBanLe.Show();
        }

        private void btnBangKeXuatKhac_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmBangKeXuatKhac formBangKeXuatKhac = new frmBangKeXuatKhac();
            if (ExistFrom(formBangKeXuatKhac)) return;
            formBangKeXuatKhac.MdiParent = this;
            formBangKeXuatKhac.Show();
        }
        #endregion

        #region Sự kiện chức năng nhập kho
        private void btnNhapKho_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmNhapKho formNhapKho = new frmNhapKho();
            if (ExistFrom(formNhapKho)) return;
            formNhapKho.MdiParent = this;
            formNhapKho.Show();
        }

        private void btnNhapKhac_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmNhapKhac formNhapKhac = new frmNhapKhac();
            if (ExistFrom(formNhapKhac)) return;
            formNhapKhac.MdiParent = this;
            formNhapKhac.Show();
        }

        private void btnBangKeNhapKho_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmBangKeNhapKho formBangKeNhapKho = new frmBangKeNhapKho();
            if (ExistFrom(formBangKeNhapKho)) return;
            formBangKeNhapKho.MdiParent = this;
            formBangKeNhapKho.Show();
        }

        private void btnBangKeNhapKhac_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmBangKeNhapKhac formBangKeNhapKhac = new frmBangKeNhapKhac();
            if (ExistFrom(formBangKeNhapKhac)) return;
            formBangKeNhapKhac.MdiParent = this;
            formBangKeNhapKhac.Show();
        }
        #endregion

        #region Sự kiện chức năng báo cáo
        private void btnTonKhoHangHoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var form = new frmTonKhoHangHoa();
            if (ExistFrom(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void btnHanSuDung_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var form = new frmHanSuDung();
            if (ExistFrom(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void btnDinhMucTonKho_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var form = new frmDinhMucTonKho();
            if (ExistFrom(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void btnBaoCaoLaiLo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var form = new frmBaoCaoLaiLo();
            if (ExistFrom(form)) return;
            form.MdiParent = this;
            form.Show();
        }
        #endregion

        #region Sự kiện chức năng danh mục
        private void btnDanhMucHangHoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var form = new frmDMHangHoa();
            if (ExistFrom(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void btnDanhMucNhomHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var form = new frmDMNhomHang();
            if (ExistFrom(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void btnDanhMucLoaiHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var form = new frmDMLoaiHang();
            if (ExistFrom(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void btnDanhMucMaVach_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var form = new frmDMMaVach();
            if (ExistFrom(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void btnDanhMucNPP_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var form = new frmDMNhaPhanPhoics();
            if (ExistFrom(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void btnDanhMucKhoHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var form = new frmDMKhoHang();
            if (ExistFrom(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void btnDanhMucNuocSanXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var form = new frmDMNuocSanXuat();
            if (ExistFrom(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void btnDanhMucKhachHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var form = new frmDMKhachHang();
            if (ExistFrom(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void btnDanhMucDonViTinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var form = new frmDMDonVi();
            if (ExistFrom(form)) return;
            form.MdiParent = this;
            form.Show();
        }
        #endregion

        #region Sự kiện chức năng hệ thống
        private void btnCauHinhPhieuThu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var form = new frmHTCauHinhChung();
            if (ExistFrom(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void btnCauHinhPhieuXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var form = new frmHTCauHinhGiaoDien();
            if (ExistFrom(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void btnCauHinhKetNoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            /*
            var form = new frmHTCauHinhKetNoi();
            if (ExistFrom(form)) return;
            form.MdiParent = this;
            form.Show();
            */
            frmHTCauHinhKetNoi frm = new frmHTCauHinhKetNoi();
            frm.ShowDialog(this);
        }

        private void btnCauHinhUngDung_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var form = new frmHTCauHinhUngDung();
            if (ExistFrom(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void btnCauHinhLogo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var form = new frmHTLogo();
            if (ExistFrom(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void btnHeThongNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var form = new frmHTNhanVien();
            if (ExistFrom(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void btnHeThongPhanQuyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var form = new frmHTPhanQuyen();
            if (ExistFrom(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void btnHeThongVaiTro_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var form = new frmHTVaiTro();
            if (ExistFrom(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void btnHeThongMatKhau_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var form = new frmHTMatKhau();
            if (ExistFrom(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void btnHeThongNhatKy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var form = new frmHTNhatKy();
            if (ExistFrom(form)) return;
            form.MdiParent = this;
            form.Show();
        }
        #endregion

        #region Sự kiện chức năng tiện ích
        private void btnTienIchSaoLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //var form = new frmTienIchSaoLuu();
            //if (ExistFrom(form)) return;
            //form.MdiParent = this;
            //form.Show();
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                //saveDialog.Filter = "Excel (2003)(.xls)|*.xls|Excel (2010) (.xlsx)|*.xlsx";
                //saveDialog.Filter = "Excel (2003)(.xls)|*.xls";
                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    string exportFilePath = saveDialog.FileName;
                    string fileExtenstion = new FileInfo(exportFilePath).Extension;

                    ClassController.DatabaseBackup(exportFilePath);
                }
            }
        }

        private void btnTienIchMoKhoaSo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var form = new frmTienIchMoKhoaSo();
            if (ExistFrom(form)) return;
            form.MdiParent = this;
            form.Show();
        }
        #endregion

        public bool ExistFrom(Form frm)
        {
            foreach(var child in MdiChildren)
            {
                if (child.Name == frm.Name)
                {
                    child.Activate();
                    return true;
                }
            }
            return false;
        }
    }
}
