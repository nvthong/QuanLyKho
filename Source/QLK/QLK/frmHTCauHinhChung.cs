using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLK
{
    public partial class frmHTCauHinhChung : Form
    {
        public frmHTCauHinhChung()
        {
            InitializeComponent();
            loadKhoHang();
            loadDonViTinh();
            loadKhachHang();
            loadLoaiHang();
            loadNhomHang();
            loadNhanVien();
            loadNpp();
            loadNuocSanXuat();
            loadCauHinh();
        }

        public void loadKhoHang()
        {
            cbxKhoHang.Properties.DataSource = ClassController.layDSKhoHang();
        }

        public void loadDonViTinh()
        {
            cbxDonViTinh.Properties.DataSource = ClassController.layDSDonViTinh();
        }

        public void loadKhachHang()
        {
            cbxKhachHang.Properties.DataSource = ClassController.layDSKhachHang();
        }

        public void loadLoaiHang()
        {
            cbxLoaiHang.Properties.DataSource = ClassController.layDSLoaiHangHoa();
        }

        public void loadNhomHang()
        {
            cbxNhomHang.Properties.DataSource = ClassController.layDSNhomHangHoa();
        }

        public void loadNhanVien()
        {
            cbxNhanVien.Properties.DataSource = ClassController.layDSNhanVien();
        }

        public void loadNpp()
        {
            cbxNhaPhanPhoi.Properties.DataSource = ClassController.layDSNhaPhanPhoi();
        }
        
        public void loadNuocSanXuat()
        {
            cbxNuocSanXuat.Properties.DataSource = ClassController.layDSQuocGia();
        }

        public void loadCauHinh()
        {
            try
            {
                List<HT_CAUHINH> objList = new List<HT_CAUHINH>();
                objList = ClassController.loadCauHinh();

                string vHanSuDung = objList.Where(x => x.CH_MACH == "CH_MACDINH_HANSUDUNG").FirstOrDefault().CH_GIATRI;
                string vSoLuong = objList.Where(x => x.CH_MACH == "CH_MACDINH_SOLUONG").FirstOrDefault().CH_GIATRI;
                string vTonKho = objList.Where(x => x.CH_MACH == "CH_MACDINH_TONkHO").FirstOrDefault().CH_GIATRI;
                string vTonToiThieu = objList.Where(x => x.CH_MACH == "CH_MACDINH_TONTOITHIEU").FirstOrDefault().CH_GIATRI;
                string vDKThanhToan = objList.Where(x => x.CH_MACH == "CH_MACDINH_DIEUKIENTHANHTOAN").FirstOrDefault().CH_GIATRI;
                string vNgayHienThi = objList.Where(x => x.CH_MACH == "CH_MACDINH_NGAY").FirstOrDefault().CH_GIATRI;

                string vKhoHang = objList.Where(x => x.CH_MACH == "CH_MACDINH_KHO").FirstOrDefault().CH_GIATRI;
                string vDVT = objList.Where(x => x.CH_MACH == "CH_MACDINH_DONVITINH").FirstOrDefault().CH_GIATRI;
                string vKhachHang = objList.Where(x => x.CH_MACH == "CH_MACDINH_KHACHHANG").FirstOrDefault().CH_GIATRI;
                string vLoaiHang = objList.Where(x => x.CH_MACH == "CH_MACDINH_LOAIHANG").FirstOrDefault().CH_GIATRI;
                string vNPP = objList.Where(x => x.CH_MACH == "CH_MACDINH_NHAPHANPHOI").FirstOrDefault().CH_GIATRI;
                string vNhomHang = objList.Where(x => x.CH_MACH == "CH_MACDINH_NHOMHANG").FirstOrDefault().CH_GIATRI;
                string vQG = objList.Where(x => x.CH_MACH == "CH_MACDINH_NUOCSANXUAT").FirstOrDefault().CH_GIATRI;
                string vNhanVien = objList.Where(x => x.CH_MACH == "CH_MACDINH_NHANVIEN").FirstOrDefault().CH_GIATRI;

                txtHanSuDung.Text = vHanSuDung != "-1" ? vHanSuDung : "";
                txtSoLuong.Text = vSoLuong != "-1" ? vSoLuong : "";
                txtTonKho.Text = vTonKho != "-1" ? vTonKho : "";
                txtTonToiThieu.Text = vTonToiThieu != "-1" ? vTonToiThieu : "";
                rdDKThanhToan.EditValue = vDKThanhToan;
                rdNgayHienThi.EditValue = vNgayHienThi;

                cbxKhoHang.EditValue = vKhoHang != "-1" ? vKhoHang : "";
                cbxDonViTinh.EditValue = vDVT != "-1" ? vDVT : "";
                cbxKhachHang.EditValue = vKhachHang != "-1" ? vKhachHang : "";
                cbxLoaiHang.EditValue = vLoaiHang != "-1" ? vLoaiHang : "";
                cbxNhaPhanPhoi.EditValue = vNPP != "-1" ? vNPP : "";
                cbxNhomHang.EditValue = vNhomHang != "-1" ? vNhomHang : "";
                cbxNuocSanXuat.EditValue = vQG != "-1" ? vQG : "";
                cbxNhanVien.EditValue = vNhanVien != "-1" ? vNhanVien : "";
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

        }

        private void btnMacDinh_Click(object sender, EventArgs e)
        {

        }
    }
}
