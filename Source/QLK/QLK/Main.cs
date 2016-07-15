using DevExpress.XtraEditors;
using DevExpress.XtraTabbedMdi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        public Main()
        {
            InitializeComponent();
        }

        #region Sự kiện chức năng xuất bán
        private void btnXuaBanSi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (checkConnect())
            {
                frmXuatBanSi formXuatBanSi = new frmXuatBanSi();
                if (ExistFrom(formXuatBanSi)) return;
                formXuatBanSi.MdiParent = this;
                formXuatBanSi.Show();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Không thể kết nối. Bạn có muốn cấu hình?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    frmHTCauHinhKetNoi frm = new frmHTCauHinhKetNoi();
                    frm.ShowDialog(this);
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
        }

        private void btnXuatBanLe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (checkConnect())
            {
                frmXuatBanLe formXuatBanLe = new frmXuatBanLe();
                if (ExistFrom(formXuatBanLe)) return;
                formXuatBanLe.MdiParent = this;
                formXuatBanLe.Show();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Không thể kết nối. Bạn có muốn cấu hình?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    frmHTCauHinhKetNoi frm = new frmHTCauHinhKetNoi();
                    frm.ShowDialog(this);
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
        }

        private void btnXuatKhac_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (checkConnect())
            {
                frmXuatKhac formXuatKhac = new frmXuatKhac();
                if (ExistFrom(formXuatKhac)) return;
                formXuatKhac.MdiParent = this;
                formXuatKhac.Show();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Không thể kết nối. Bạn có muốn cấu hình?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    frmHTCauHinhKetNoi frm = new frmHTCauHinhKetNoi();
                    frm.ShowDialog(this);
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
        }

        private void btnBangKeBanSi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (checkConnect())
            {
                frmBangKeBanSi formBangKeBanSi = new frmBangKeBanSi();
                if (ExistFrom(formBangKeBanSi)) return;
                formBangKeBanSi.MdiParent = this;
                formBangKeBanSi.Show();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Không thể kết nối. Bạn có muốn cấu hình?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    frmHTCauHinhKetNoi frm = new frmHTCauHinhKetNoi();
                    frm.ShowDialog(this);
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
        }

        private void btnBangKeBanLe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (checkConnect())
            {
                frmBangKeBanLe formBangKeBanLe = new frmBangKeBanLe();
                if (ExistFrom(formBangKeBanLe)) return;
                formBangKeBanLe.MdiParent = this;
                formBangKeBanLe.Show();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Không thể kết nối. Bạn có muốn cấu hình?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    frmHTCauHinhKetNoi frm = new frmHTCauHinhKetNoi();
                    frm.ShowDialog(this);
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
        }

        private void btnBangKeXuatKhac_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (checkConnect())
            {
                frmBangKeXuatKhac formBangKeXuatKhac = new frmBangKeXuatKhac();
                if (ExistFrom(formBangKeXuatKhac)) return;
                formBangKeXuatKhac.MdiParent = this;
                formBangKeXuatKhac.Show();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Không thể kết nối. Bạn có muốn cấu hình?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    frmHTCauHinhKetNoi frm = new frmHTCauHinhKetNoi();
                    frm.ShowDialog(this);
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
        }
        #endregion

        #region Sự kiện chức năng nhập kho
        private void btnNhapKho_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (checkConnect())
            {
                frmNhapKho formNhapKho = new frmNhapKho();
                if (ExistFrom(formNhapKho)) return;
                formNhapKho.MdiParent = this;
                formNhapKho.Show();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Không thể kết nối. Bạn có muốn cấu hình?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    frmHTCauHinhKetNoi frm = new frmHTCauHinhKetNoi();
                    frm.ShowDialog(this);
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
        }

        private void btnNhapKhac_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (checkConnect())
            {
                frmNhapKhac formNhapKhac = new frmNhapKhac();
                if (ExistFrom(formNhapKhac)) return;
                formNhapKhac.MdiParent = this;
                formNhapKhac.Show();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Không thể kết nối. Bạn có muốn cấu hình?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    frmHTCauHinhKetNoi frm = new frmHTCauHinhKetNoi();
                    frm.ShowDialog(this);
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
        }

        private void btnBangKeNhapKho_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (checkConnect())
            {
                frmBangKeNhapKho formBangKeNhapKho = new frmBangKeNhapKho();
                if (ExistFrom(formBangKeNhapKho)) return;
                formBangKeNhapKho.MdiParent = this;
                formBangKeNhapKho.Show();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Không thể kết nối. Bạn có muốn cấu hình?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    frmHTCauHinhKetNoi frm = new frmHTCauHinhKetNoi();
                    frm.ShowDialog(this);
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
        }

        private void btnBangKeNhapKhac_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (checkConnect())
            {
                frmBangKeNhapKhac formBangKeNhapKhac = new frmBangKeNhapKhac();
                if (ExistFrom(formBangKeNhapKhac)) return;
                formBangKeNhapKhac.MdiParent = this;
                formBangKeNhapKhac.Show();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Không thể kết nối. Bạn có muốn cấu hình?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    frmHTCauHinhKetNoi frm = new frmHTCauHinhKetNoi();
                    frm.ShowDialog(this);
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
        }
        #endregion

        #region Sự kiện chức năng báo cáo
        private void btnTonKhoHangHoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (checkConnect())
            {
                var form = new frmTonKhoHangHoa();
                if (ExistFrom(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Không thể kết nối. Bạn có muốn cấu hình?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    frmHTCauHinhKetNoi frm = new frmHTCauHinhKetNoi();
                    frm.ShowDialog(this);
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
        }

        private void btnHanSuDung_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (checkConnect())
            {
                var form = new frmHanSuDung();
                if (ExistFrom(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Không thể kết nối. Bạn có muốn cấu hình?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    frmHTCauHinhKetNoi frm = new frmHTCauHinhKetNoi();
                    frm.ShowDialog(this);
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
        }

        private void btnDinhMucTonKho_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (checkConnect())
            {
                var form = new frmDinhMucTonKho();
                if (ExistFrom(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Không thể kết nối. Bạn có muốn cấu hình?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    frmHTCauHinhKetNoi frm = new frmHTCauHinhKetNoi();
                    frm.ShowDialog(this);
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
        }

        private void btnBaoCaoLaiLo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (checkConnect())
            {
                var form = new frmBaoCaoLaiLo();
                if (ExistFrom(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Không thể kết nối. Bạn có muốn cấu hình?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    frmHTCauHinhKetNoi frm = new frmHTCauHinhKetNoi();
                    frm.ShowDialog(this);
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
        }
        #endregion

        #region Sự kiện chức năng danh mục
        private void btnDanhMucHangHoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (checkConnect())
            {
                var form = new frmDMHangHoa();
                if (ExistFrom(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Không thể kết nối. Bạn có muốn cấu hình?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    frmHTCauHinhKetNoi frm = new frmHTCauHinhKetNoi();
                    frm.ShowDialog(this);
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
        }

        private void btnDanhMucNhomHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (checkConnect())
            {
                var form = new frmDMNhomHang();
                if (ExistFrom(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Không thể kết nối. Bạn có muốn cấu hình?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    frmHTCauHinhKetNoi frm = new frmHTCauHinhKetNoi();
                    frm.ShowDialog(this);
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
        }

        private void btnDanhMucLoaiHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (checkConnect())
            {
                var form = new frmDMLoaiHang();
                if (ExistFrom(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Không thể kết nối. Bạn có muốn cấu hình?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    frmHTCauHinhKetNoi frm = new frmHTCauHinhKetNoi();
                    frm.ShowDialog(this);
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
        }

        private void btnDanhMucMaVach_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (checkConnect())
            {
                var form = new frmDMMaVach();
                if (ExistFrom(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Không thể kết nối. Bạn có muốn cấu hình?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    frmHTCauHinhKetNoi frm = new frmHTCauHinhKetNoi();
                    frm.ShowDialog(this);
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
        }

        private void btnDanhMucNPP_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (checkConnect())
            {
                var form = new frmDMNhaPhanPhoics();
                if (ExistFrom(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Không thể kết nối. Bạn có muốn cấu hình?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    frmHTCauHinhKetNoi frm = new frmHTCauHinhKetNoi();
                    frm.ShowDialog(this);
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
        }

        private void btnDanhMucKhoHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (checkConnect())
            {
                var form = new frmDMKhoHang();
                if (ExistFrom(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Không thể kết nối. Bạn có muốn cấu hình?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    frmHTCauHinhKetNoi frm = new frmHTCauHinhKetNoi();
                    frm.ShowDialog(this);
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
        }

        private void btnDanhMucNuocSanXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (checkConnect())
            {
                var form = new frmDMNuocSanXuat();
                if (ExistFrom(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Không thể kết nối. Bạn có muốn cấu hình?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    frmHTCauHinhKetNoi frm = new frmHTCauHinhKetNoi();
                    frm.ShowDialog(this);
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
        }

        private void btnDanhMucKhachHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (checkConnect())
            {
                var form = new frmDMKhachHang();
                if (ExistFrom(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Không thể kết nối. Bạn có muốn cấu hình?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    frmHTCauHinhKetNoi frm = new frmHTCauHinhKetNoi();
                    frm.ShowDialog(this);
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
        }

        private void btnDanhMucDonViTinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (checkConnect())
            {
                var form = new frmDMDonVi();
                if (ExistFrom(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Không thể kết nối. Bạn có muốn cấu hình?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    frmHTCauHinhKetNoi frm = new frmHTCauHinhKetNoi();
                    frm.ShowDialog(this);
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
        }
        #endregion

        #region Sự kiện chức năng hệ thống
        private void btnCauHinhPhieuThu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (checkConnect())
            {
                var form = new frmHTCauHinhChung();
                if (ExistFrom(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Không thể kết nối. Bạn có muốn cấu hình?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    frmHTCauHinhKetNoi frm = new frmHTCauHinhKetNoi();
                    frm.ShowDialog(this);
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
        }

        private void btnCauHinhPhieuXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (checkConnect())
            {
                var form = new frmHTCauHinhGiaoDien();
                if (ExistFrom(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Không thể kết nối. Bạn có muốn cấu hình?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    frmHTCauHinhKetNoi frm = new frmHTCauHinhKetNoi();
                    frm.ShowDialog(this);
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
        }

        private void btnCauHinhKetNoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmHTCauHinhKetNoi frm = new frmHTCauHinhKetNoi();
            frm.ShowDialog(this);
        }

        private void btnCauHinhUngDung_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (checkConnect())
            {
                var form = new frmHTCauHinhUngDung();
                if (ExistFrom(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Không thể kết nối. Bạn có muốn cấu hình?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    frmHTCauHinhKetNoi frm = new frmHTCauHinhKetNoi();
                    frm.ShowDialog(this);
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
        }

        private void btnCauHinhLogo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (checkConnect())
            {
                var form = new frmHTLogo();
                if (ExistFrom(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Không thể kết nối. Bạn có muốn cấu hình?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    frmHTCauHinhKetNoi frm = new frmHTCauHinhKetNoi();
                    frm.ShowDialog(this);
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
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
            if (checkConnect())
            {
                var form = new frmHTNhatKy();
                if (ExistFrom(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Không thể kết nối. Bạn có muốn cấu hình?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    frmHTCauHinhKetNoi frm = new frmHTCauHinhKetNoi();
                    frm.ShowDialog(this);
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
        }
        #endregion

        #region Sự kiện chức năng tiện ích
        private void btnTienIchSaoLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (checkConnect())
            {
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "Database (.bak)|*.bak";
                    if (saveDialog.ShowDialog() != DialogResult.Cancel)
                    {
                        string exportFilePath = saveDialog.FileName;
                        string fileExtenstion = new FileInfo(exportFilePath).Extension;

                        ClassController.DatabaseBackup(exportFilePath);
                    }
                }
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Không thể kết nối. Bạn có muốn cấu hình?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    frmHTCauHinhKetNoi frm = new frmHTCauHinhKetNoi();
                    frm.ShowDialog(this);
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
        }

        private void btnTienIchMoKhoaSo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (checkConnect())
            {
                var form = new frmTienIchMoKhoaSo();
                if (ExistFrom(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Không thể kết nối. Bạn có muốn cấu hình?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    frmHTCauHinhKetNoi frm = new frmHTCauHinhKetNoi();
                    frm.ShowDialog(this);
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
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

        public bool checkConnect()
        {
            bool vStatus = false;
            SqlConnection connect;
            List<HD_NHAPXUAT> objList = new List<HD_NHAPXUAT>();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    vStatus = true;
                    return vStatus;
                }
            }
            catch
            {
                return vStatus;
            }
        }
    }
}
