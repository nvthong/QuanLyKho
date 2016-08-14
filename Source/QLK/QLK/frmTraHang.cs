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
    public partial class frmTraHang : Form
    {
        protected string StatusButtonHD = "";
        protected string StatusButtonHH = "";
        protected string vIdHH = "";
        protected int StatusRowClickHD = 0;
        protected int StatusRowClickHH = 0;
        public static frmTraHang _frmTraHang;
        DataTable dtHH;
        DataTable dtReport;
        public frmTraHang()
        {
            InitializeComponent();
            InitializeDtHDNX();
            _frmTraHang = this;
            lkHienThi.Properties.DataSource = ClassController.layDSThoiGianHD();
            lkHienThi.EditValue = "0";
            loadDSHoaDon();
            gridCtrlHoaDon.Enabled = true;
            setStatusButtonHD(true);
            setStatucButtonUpdateGia(false);
            btnDongHD.Enabled = true;
        }

        public void InitializeDtHDNX()
        {
            dtHH = new DataTable();
            dtHH.Columns.Add("HDNX_TRAHANG", typeof(string));
            dtHH.Columns.Add("HH_MAHANG", typeof(string));
            dtHH.Columns.Add("HH_TENHANG", typeof(string));
            dtHH.Columns.Add("DVT_TENDONVI", typeof(string));
            dtHH.Columns.Add("HDNX_SOLUONG", typeof(double));
            dtHH.Columns.Add("HDNX_CHIECKHAU", typeof(decimal));
            dtHH.Columns.Add("HDNX_TONGCHIECKHAU", typeof(double));
            dtHH.Columns.Add("HDNX_GIABAN", typeof(decimal));
            dtHH.Columns.Add("HDNX_TONGBAN", typeof(decimal));
            dtHH.Columns.Add("HDNX_THANHTIEN", typeof(decimal));
            dtHH.Columns.Add("ID", typeof(string));
            // 
            dtHH.Columns.Add("HDNX_GIAMUA", typeof(string));
            dtHH.Columns.Add("HDNX_TONGMUA", typeof(string));
            dtHH.Columns.Add("HDNX_VAT", typeof(string));
            dtHH.Columns.Add("HDNX_GIAVAT", typeof(string));
            dtHH.Columns.Add("HDNX_TONGVAT", typeof(string));
        }

        public void InitializeDtReport()
        {
            dtReport = new DataTable();
            dtReport.Columns.Add("HDNX_TRAHANG", typeof(string));
            dtReport.Columns.Add("HH_MAHANG", typeof(string));
            dtReport.Columns.Add("HH_TENHANG", typeof(string));
            dtReport.Columns.Add("DVT_TENDONVI", typeof(string));
            dtReport.Columns.Add("HDNX_SOLUONG", typeof(double));
            dtReport.Columns.Add("HDNX_CHIECKHAU", typeof(decimal));
            dtReport.Columns.Add("HDNX_TONGCHIECKHAU", typeof(double));
            dtReport.Columns.Add("HDNX_GIABAN", typeof(decimal));
            dtReport.Columns.Add("HDNX_TONGBAN", typeof(decimal));
            dtReport.Columns.Add("HDNX_THANHTIEN", typeof(decimal));
            dtReport.Columns.Add("ID", typeof(string));
            // 
            dtReport.Columns.Add("HDNX_GIAMUA", typeof(string));
            dtReport.Columns.Add("HDNX_TONGMUA", typeof(string));
            dtReport.Columns.Add("HDNX_VAT", typeof(string));
            dtReport.Columns.Add("HDNX_GIAVAT", typeof(string));
            dtReport.Columns.Add("HDNX_TONGVAT", typeof(string));
        }

        public void setStatusFieldHD(bool pStatus)
        {
            dateNgayHoaDon.Properties.ReadOnly = !pStatus;
            txtKhachHangMa.Properties.ReadOnly = !pStatus;
            //txtXuatKhoMa.Properties.ReadOnly = !pStatus;
            txtGhiChu.Properties.ReadOnly = !pStatus;
        }

        public void setStatusFieldHH(bool pStatus)
        {
            txtMaHang.Properties.ReadOnly = !pStatus;
            //txtGiaBan.Properties.ReadOnly = !pStatus;
            txtSoLuong.Properties.ReadOnly = !pStatus;
        }

        public void setStatusFieldTT(bool pStatus)
        {
            //txtGiamGiaKhac.Properties.ReadOnly = !pStatus;
            //txtTienKhachTra.Properties.ReadOnly = !pStatus;
            //txtChiecKhau.Properties.ReadOnly = !pStatus;
        }

        public void setStatusButtonHH(bool pStatus)
        {
            btnThemHH.Enabled = pStatus;
            btnSuaHH.Enabled = pStatus;
            btnXoaHH.Enabled = pStatus;
        }

        public void setStatusButtonHD(bool pStatus)
        {
            btnThemHD.Enabled = pStatus;
            btnSuaHD.Enabled = pStatus;
            btnXoaHD.Enabled = pStatus;
        }

        public void setStatucButtonUpdateGia(bool pStatus)
        {
            btnSuaGiaBan.Enabled = pStatus;
            btnSuaGiaNhap.Enabled = pStatus;
        }

        public void setEmptyFieldHD()
        {
            txtHoaDon.Text = "";
            dateNgayHoaDon.Text = "";
            txtKhachHangMa.Text = "";
            txtKhachHangTen.Text = "";
            //txtXuatKhoMa.Text = "";
            //txtXuatKhoTen.Text = "";
            txtGhiChu.Text = "";
        }

        public void setEmptyFieldHH()
        {
            txtMaHang.Text = "";
            txtTenHang.Text = "";
            //txtDonViTinh.Text = "";
            txtGiaNhap.Text = "";
            txtSoLuong.Text = "";
            txtGiaBan.Text = "";
            txtThanhTien.Text = "";
            txtTonKho.Text = "";
        }

        public void setEmptyFieldTT()
        {
            //txtTongHoaDon.Text = "";
            //txtTongChiecKhau.Text = "";
            //txtTongThanhToan.Text = "";
            //txtTongTraHang.Text = "";
            //txtGiamGiaKhac.Text = "";
            //txtTienKhachTra.Text = "";
            //txtTienThoiLai.Text = "";
        }

        public void fillControlHH(int pRowNumber)
        {
            try
            {
                if (dtHH.Rows.Count > 0)
                {
                    vIdHH = gridViewHangHoa.GetRowCellValue(pRowNumber, "ID").ToString();
                    txtMaHang.Text = gridViewHangHoa.GetRowCellValue(pRowNumber, "HH_MAHANG").ToString();
                    txtTenHang.Text = gridViewHangHoa.GetRowCellValue(pRowNumber, "HH_TENHANG").ToString();
                    //txtDonViTinh.Text = gridViewHangHoa.GetRowCellValue(pRowNumber, "DVT_TENDONVI").ToString();
                    txtGiaNhap.Text = double.Parse(gridViewHangHoa.GetRowCellValue(pRowNumber, "HDNX_GIAMUA").ToString()).ToString();
                    txtGiaBan.Text = double.Parse(gridViewHangHoa.GetRowCellValue(pRowNumber, "HDNX_GIABAN").ToString()).ToString();
                    txtSoLuong.Text = gridViewHangHoa.GetRowCellValue(pRowNumber, "HDNX_SOLUONG").ToString();
                    txtThanhTien.Text = double.Parse(gridViewHangHoa.GetRowCellValue(pRowNumber, "HDNX_THANHTIEN").ToString()).ToString();
                    //txtTonKho.Text = ClassController.layTonKhoHangHoa(
                    //    gridViewHangHoa.GetRowCellValue(pRowNumber, "HH_MAHANG").ToString(),
                    //    txtXuatKhoMa.Text.Trim()).ToString();
                    txtTonKho.Text = ClassController.layTonKhoHangHoa(
                        gridViewHangHoa.GetRowCellValue(pRowNumber, "HH_MAHANG").ToString(), "KHO000001").ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void fillDataHHbySHDNB(string pSoHDNB)
        {
            try
            {
                List<HD_NHAPXUAT> objList = new List<HD_NHAPXUAT>();
                objList = ClassController.layDSHoaDonTraHangTheoSHDNB(pSoHDNB);
                if (objList.Count > 0)
                {
                    txtHoaDon.Text = objList[0].HDNX_SOHD;
                    txtKhachHangMa.Text = objList[0].NPP_MANPP;
                    txtKhachHangTen.Text = ClassController.layKhachHangTheoMa(objList[0].NPP_MANPP).NPP_TENNPP;
                    //txtXuatKhoMa.Text = objList[0].KH_MAKHO;
                    //txtXuatKhoTen.Text = ClassController.layKhoHangTheoMa(objList[0].KH_MAKHO).KH_TENKHO;
                    txtHoaDon.Text = objList[0].HDNX_SOHDNB;
                    dateNgayHoaDon.DateTime = objList[0].HDNX_NGAYHD;
                    txtGhiChu.Text = objList[0].HDNX_GHICHU;

                    decimal vTongBan = 0;
                    decimal vThanhTien = 0;
                    decimal vTongChiecKhau = 0;
                    decimal vTongTraHang = 0;

                    if (dtReport == null)
                        InitializeDtHDNX();

                    dtHH.Clear();
                    foreach (var item in objList)
                    {
                        vIdHH = DateTime.Now.Millisecond + "" + DateTime.Now.Second + "" + DateTime.Now.Minute + "" + DateTime.Now.Hour + "" + DateTime.Now.Day + "" + DateTime.Now.Month + "" + DateTime.Now.Year + "";

                        vTongBan += (item.HDNX_TONGBAN);
                        vThanhTien += (item.HDNX_THANHTIEN);
                        vTongChiecKhau += (item.HDNX_TONGCHIECKHAU);

                        if (item.HDNX_TRAHANG == 1)
                        {
                            vTongTraHang += (item.HDNX_THANHTIEN);
                        }

                        DMHH_HANGHOA objHH = new DMHH_HANGHOA();
                        objHH = ClassController.layHangHoaTheoMa(item.HH_MAHANG);
                        DMHH_DONVITINH objDVT = new DMHH_DONVITINH();
                        objDVT = ClassController.layDonViTinhTheoMa(objHH.DVT_MADONVI);
                        dtHH.Rows.Add(
                            item.HDNX_TRAHANG,
                            item.HH_MAHANG,
                            objHH.HH_TENHANG,
                            objDVT.DVT_TENDONVI,
                            item.HDNX_SOLUONG,
                            item.HDNX_CHIECKHAU,
                            item.HDNX_TONGCHIECKHAU,
                            item.HDNX_GIABAN,
                            item.HDNX_TONGBAN,
                            item.HDNX_THANHTIEN,
                            vIdHH.ToString(),
                            item.HDNX_GIAMUA,
                            item.HDNX_TONGMUA,
                            item.HDNX_VAT,
                            item.HDNX_GIAVAT,
                            item.HDNX_TONGVAT
                        );
                    }

                    //txtTongHoaDon.Text = ((double)vTongBan).ToString();
                    //txtTongThanhToan.Text = ((double)vThanhTien).ToString();
                    //txtGiamGiaKhac.Text = ((double)(-objList[0].HDNX_GIAMKHAC)).ToString();
                    //txtTongTraHang.Text = ((double)vTongTraHang).ToString();
                    //txtTongChiecKhau.Text = ((double)vTongChiecKhau).ToString();
                    //txtTienKhachTra.Text = ((double)objList[0].HDNX_KHACHDUA).ToString();
                    //txtTienThoiLai.Text = ((double)objList[0].HDNX_THOILAI).ToString();

                    loadDSHangHoa();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void updateFieldTT()
        {
            try
            {
                int vTongHoaDon = 0;
                int vTongTienChiecKhau = 0;
                int vTongThanhToan = 0;
                int vTongTraHang = 0;

                for (int i = 0; i < dtHH.Rows.Count; i++)
                {
                    vTongHoaDon += ((int)double.Parse(dtHH.Rows[i]["HDNX_TONGBAN"].ToString().Trim()));
                    vTongTienChiecKhau += ((int)double.Parse(dtHH.Rows[i]["HDNX_TONGCHIECKHAU"].ToString().Trim()));
                    vTongThanhToan += ((int)double.Parse(dtHH.Rows[i]["HDNX_THANHTIEN"].ToString().Trim()));

                    if (dtHH.Rows[i]["HDNX_TRAHANG"].ToString() == "1")
                    {
                        vTongTraHang += ((int)double.Parse(dtHH.Rows[i]["HDNX_THANHTIEN"].ToString().Trim()));
                    }
                }

                //txtTongHoaDon.Text = vTongHoaDon.ToString();
                //txtTongChiecKhau.Text = vTongTienChiecKhau.ToString();
                //txtTongThanhToan.Text = vTongThanhToan.ToString();
                //txtTongTraHang.Text = vTongTraHang.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void updateTienThoiLai()
        {
            try
            {
                int vTongThanhToan = 0;
                int vTongHoaDon = 0;
                int vTienGiamKhac = 0;
                int vTienKhachDua = 0;
                int vTienThoiLai = 0;
                int vChiecKhau = 0;
                int vTienChiecKhau = 0;

                //vTongHoaDon = txtTongHoaDon.Text.Trim() != "" ? (int)double.Parse(txtTongHoaDon.Text.Trim()) : 0;
                //vTienGiamKhac = txtGiamGiaKhac.Text.Trim() != "" ? (int)double.Parse(txtGiamGiaKhac.Text.Trim()) : 0;
                //vTienKhachDua = txtTienKhachTra.Text.Trim() != "" ? (int)double.Parse(txtTienKhachTra.Text.Trim()) : 0;
                //vChiecKhau = txtChiecKhau.Text.Trim() != "" ? (int)double.Parse(txtChiecKhau.Text.Trim()) : 0;

                vTienChiecKhau = (vTongHoaDon * vChiecKhau) / 100;
                vTongThanhToan = vTongHoaDon - vTienChiecKhau - vTienGiamKhac;
                vTienThoiLai = vTienKhachDua - vTongThanhToan;

                //txtTongThanhToan.Text = vTongThanhToan.ToString();
                //txtTienThoiLai.Text = vTienThoiLai.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void updateDSHoaDon()
        {
            try
            {
                gridCtrlHoaDon.DataSource = null;
                int vPeriod = Int32.Parse(lkHienThi.EditValue.ToString());
                gridCtrlHoaDon.DataSource = ClassController.layDSHoaDonXuatLeTheoKhoangThoiGian(vPeriod);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void loadDSHoaDon()
        {
            gridCtrlHoaDon.DataSource = ClassController.layDSHoaDonTraHangDSLeft();
        }

        public void loadDSHangHoa()
        {
            gridCtrlHangHoa.DataSource = dtHH;
        }

        public void ThemHH()
        {
            if (btnThemHH.Text == "Thêm")
            {
                StatusButtonHH = "Them";
                btnThemHH.Text = "Lưu";
                btnSuaHH.Text = "Bỏ qua";
                btnSuaHH.Enabled = true;
                btnXoaHH.Enabled = false;
                setStatusFieldHH(true);
                setEmptyFieldHH(); 
                setStatucButtonUpdateGia(true);
                txtMaHang.Focus();
            }
            else if (btnThemHH.Text == "Lưu")
            {
                if (StatusButtonHH == "Them")
                {
                    HD_NHAPXUAT objHDNX = new HD_NHAPXUAT();
                    vIdHH = DateTime.Now.Millisecond + "" + DateTime.Now.Second + "" + DateTime.Now.Minute + "" + DateTime.Now.Hour + "" + DateTime.Now.Day + "" + DateTime.Now.Month + "" + DateTime.Now.Year + "";
                    objHDNX.HH_MAHANG = txtMaHang.Text.Trim();

                    DMHH_HANGHOA objHH = new DMHH_HANGHOA();
                    objHH = ClassController.layHangHoaTheoMa(objHDNX.HH_MAHANG);

                    DMHH_DONVITINH objDVT = new DMHH_DONVITINH();
                    objDVT = ClassController.layDonViTinhTheoMa(objHH.DVT_MADONVI);

                    if (txtTenHang.Text.Trim() == "")
                    {
                        MessageBox.Show("Vui lòng nhập hàng hóa");
                        txtMaHang.Focus();
                        return;
                    }

                    if ((txtGiaNhap.Text.Trim() == "" ? 0 : Decimal.Parse(txtGiaNhap.Text.Trim())) <= 0)
                    {
                        MessageBox.Show("Vui lòng nhập giá nhập");
                        txtGiaNhap.Focus();
                        return;
                    }

                    if ((txtGiaBan.Text.Trim() == "" ? 0 : Decimal.Parse(txtGiaBan.Text.Trim())) <= 0)
                    {
                        MessageBox.Show("Vui lòng nhập giá bán");
                        txtGiaBan.Focus();
                        return;
                    }

                    if ((txtSoLuong.Text.Trim() == "" ? 0 : double.Parse(txtSoLuong.Text.Trim())) <= 0)
                    {
                        MessageBox.Show("Vui lòng nhập số lượng");
                        txtSoLuong.Focus();
                        return;
                    }

                    //double vSoLuongXuatk = 0;
                    //for (int i = 0; i < dtHH.Rows.Count; i++)
                    //{
                    //    if (dtHH.Rows[i]["HH_MAHANG"].ToString() == txtMaHang.Text.Trim())
                    //    {
                    //        vSoLuongXuatk += double.Parse(dtHH.Rows[i]["HDNX_SOLUONG"].ToString());
                    //    }
                    //}

                    //List<HD_NHAPXUAT> listHH = new List<HD_NHAPXUAT>();
                    //listHH = ClassController.layDSHangHoaNhapKhoByMaHang("KHO000001", objHDNX.HH_MAHANG);
                    vIdHH = DateTime.Now.Millisecond + "" + DateTime.Now.Second + "" + DateTime.Now.Minute + "" + DateTime.Now.Hour + "" + DateTime.Now.Day + "" + DateTime.Now.Month + "" + DateTime.Now.Year + "";
                    double vSoLuong = txtSoLuong.Text.Trim() == "" ? 0 : double.Parse(txtSoLuong.Text.Trim());
                    double vGiaBan = txtGiaBan.Text.Trim() == "" ? 0 : double.Parse(txtGiaBan.Text.Trim());
                    double vGiaMua = txtGiaNhap.Text.Trim() == "" ? 0 : double.Parse(txtGiaNhap.Text.Trim());
                    double vTongMua = vGiaMua * vSoLuong;
                    double vTongBan = vGiaBan * vSoLuong;
                    double vVAT = 0;// listHH[0].HDNX_VAT;
                    double vGiaVAT = 0;// (vGiaMua * vVAT) / 100;
                    double vTongVAT = 0;// vGiaVAT* vSoLuong;
                    double vChiecKhau = 0;// objHH.HH_KHUYENMAI;
                    double vTongChiecKhau = 0;// (vTongBan * vChiecKhau) / 100;
                    double vThanhTien = vTongBan - vTongChiecKhau;

                    //vSoLuong = vSoLuong > 0 ? vSoLuong : -vSoLuong;
                    //vTongBan = vTongBan > 0 ? vTongBan : -vTongBan;
                    //vThanhTien = vThanhTien > 0 ? vThanhTien : -vThanhTien;

                    dtHH.Rows.Add(
                        0,
                        objHDNX.HH_MAHANG, objHH.HH_TENHANG, objDVT.DVT_TENDONVI,
                        vSoLuong,
                        vChiecKhau,
                        vTongChiecKhau,
                        vGiaBan,
                        vTongBan,
                        vThanhTien,
                        vIdHH.ToString(),
                        vGiaMua,
                        vTongMua,
                        vVAT,
                        vGiaVAT,
                        vTongVAT
                    );

                    #region 
                    //List<HD_NHAPXUAT> listHH = new List<HD_NHAPXUAT>();
                    //listHH = ClassController.layDSHangHoaNhapKhoByMaHang("KHO000001", objHDNX.HH_MAHANG);

                    //if (listHH.Count == 1)
                    //{
                    //    vIdHH = DateTime.Now.Millisecond + "" + DateTime.Now.Second + "" + DateTime.Now.Minute + "" + DateTime.Now.Hour + "" + DateTime.Now.Day + "" + DateTime.Now.Month + "" + DateTime.Now.Year + "";
                    //    double vSoLuong = txtSoLuong.Text.Trim() == "" ? 0 : double.Parse(txtSoLuong.Text.Trim());
                    //    double vGiaBan = txtGiaBan.Text.Trim() == "" ? 0 : double.Parse(txtGiaBan.Text.Trim());
                    //    double vGiaMua = double.Parse(listHH[0].HDNX_GIAMUA.ToString());
                    //    double vTongMua = vGiaMua * vSoLuong;
                    //    double vTongBan = vGiaBan * vSoLuong;
                    //    double vVAT = listHH[0].HDNX_VAT;
                    //    double vGiaVAT = (vGiaMua * vVAT) / 100;
                    //    double vTongVAT = vGiaVAT * vSoLuong;
                    //    double vChiecKhau = objHH.HH_KHUYENMAI;
                    //    double vTongChiecKhau = (vTongBan * vChiecKhau) / 100;
                    //    double vThanhTien = vTongBan - vTongChiecKhau;

                    //    vSoLuong = vSoLuong > 0 ? vSoLuong : -vSoLuong;
                    //    vTongBan = vTongBan > 0 ? vTongBan : -vTongBan;
                    //    vThanhTien = vThanhTien > 0 ? vThanhTien : -vThanhTien;

                    //    dtHH.Rows.Add(
                    //        0,
                    //        objHDNX.HH_MAHANG, objHH.HH_TENHANG, objDVT.DVT_TENDONVI,
                    //        vSoLuong,
                    //        vChiecKhau,
                    //        vTongChiecKhau,
                    //        vGiaBan,
                    //        vTongBan,
                    //        vThanhTien,
                    //        vIdHH.ToString(),
                    //        vGiaMua,
                    //        vTongMua,
                    //        vVAT,
                    //        vGiaVAT,
                    //        vTongVAT
                    //    );
                    //}
                    //else if (listHH.Count > 1)
                    //{
                    //    double vGiaBan = txtGiaBan.Text.Trim() == "" ? 0 : double.Parse(txtGiaBan.Text.Trim());
                    //    double vSoLuongXuat = txtSoLuong.Text.Trim() == "" ? 0 : double.Parse(txtSoLuong.Text.Trim());
                    //    int flag = 0;
                    //    foreach (var item in listHH)
                    //    {
                    //        flag = flag + 1;
                    //        vIdHH = flag + "" + DateTime.Now.Millisecond + "" + DateTime.Now.Second + "" + DateTime.Now.Minute + "" + DateTime.Now.Hour + "" + DateTime.Now.Day + "" + DateTime.Now.Month + "" + DateTime.Now.Year + "";
                    //        double vSoLuongTon = item.HDNX_SOLUONG;
                    //        double vGiaMua = double.Parse(item.HDNX_GIAMUA.ToString());

                    //        if (vSoLuongTon >= vSoLuongXuat)
                    //        {
                    //            double vTongMua = vGiaMua * vSoLuongXuat;
                    //            double vVAT = item.HDNX_VAT;
                    //            double vGiaVAT = (vGiaMua * vVAT) / 100;
                    //            double vTongVAT = vGiaVAT * vSoLuongXuat;
                    //            double vTongBan = vGiaBan * vSoLuongXuat;
                    //            double vChiecKhau = objHH.HH_KHUYENMAI;
                    //            double vTongChiecKhau = (vTongBan * vChiecKhau) / 100;
                    //            double vThanhTien = vTongBan - vTongChiecKhau;

                    //            vSoLuongXuat = vSoLuongXuat > 0 ? vSoLuongXuat : -vSoLuongXuat;
                    //            vTongBan = vTongBan > 0 ? vTongBan : -vTongBan;
                    //            vThanhTien = vThanhTien > 0 ? vThanhTien : -vThanhTien;

                    //            dtHH.Rows.Add(
                    //                0, objHDNX.HH_MAHANG, objHH.HH_TENHANG, objDVT.DVT_TENDONVI,
                    //                vSoLuongXuat,
                    //                vChiecKhau,
                    //                vTongChiecKhau,
                    //                vGiaBan,
                    //                vTongBan,
                    //                vThanhTien,
                    //                vIdHH.ToString(),
                    //                vGiaMua,
                    //                vTongMua,
                    //                vVAT,
                    //                vGiaVAT,
                    //                vTongVAT
                    //            );
                    //            break;
                    //        }
                    //        else if (vSoLuongTon < vSoLuongXuat)
                    //        {
                    //            vSoLuongXuat -= vSoLuongTon;
                    //            double vTongMua = vGiaMua * vSoLuongTon;
                    //            double vVAT = item.HDNX_VAT;
                    //            double vGiaVAT = (vGiaMua * vVAT) / 100;
                    //            double vTongVAT = vGiaVAT * vSoLuongTon;
                    //            double vTongBan = vGiaBan * vSoLuongTon;
                    //            double vChiecKhau = objHH.HH_KHUYENMAI;
                    //            double vTongChiecKhau = (vTongBan * vChiecKhau) / 100;
                    //            double vThanhTien = vTongBan - vTongChiecKhau;

                    //            vSoLuongTon = vSoLuongTon > 0 ? vSoLuongTon : -vSoLuongTon;
                    //            vTongBan = vTongBan > 0 ? vTongBan : -vTongBan;
                    //            vThanhTien = vThanhTien > 0 ? vThanhTien : -vThanhTien;

                    //            dtHH.Rows.Add(
                    //                0, objHDNX.HH_MAHANG, objHH.HH_TENHANG, objDVT.DVT_TENDONVI,
                    //                vSoLuongTon,
                    //                vChiecKhau,
                    //                vTongChiecKhau,
                    //                vGiaBan,
                    //                vTongBan,
                    //                vThanhTien,
                    //                vIdHH.ToString(),
                    //                vGiaMua,
                    //                vTongMua,
                    //                vVAT,
                    //                vGiaVAT,
                    //                vTongVAT
                    //            );
                    //        }
                    //    }
                    //}
                    #endregion 
                    loadDSHangHoa();
                    setEmptyFieldHH();
                    updateFieldTT();
                    updateTienThoiLai();
                    txtMaHang.Focus();
                }
                else if (StatusButtonHH == "Sua")
                {
                    HD_NHAPXUAT objHDNX = new HD_NHAPXUAT();
                    objHDNX.HH_MAHANG = txtMaHang.Text.Trim();
                    objHDNX.HDNX_SOLUONG = txtSoLuong.Text.Trim() == "" ? 0 : double.Parse(txtSoLuong.Text.Trim());

                    DMHH_HANGHOA objHH = new DMHH_HANGHOA();
                    objHH = ClassController.layHangHoaTheoMa(objHDNX.HH_MAHANG);
                    DMHH_DONVITINH objDVT = new DMHH_DONVITINH();
                    objDVT = ClassController.layDonViTinhTheoMa(objHH.DVT_MADONVI);
                    objHDNX.HDNX_GIABAN = txtGiaBan.Text.Trim() == "" ? 0 : Decimal.Parse(txtGiaBan.Text.Trim());
                    objHDNX.HDNX_CHIECKHAU = objHH.HH_KHUYENMAI;
                    objHDNX.HDNX_TONGBAN = Decimal.Parse(objHDNX.HDNX_SOLUONG.ToString()) * objHDNX.HDNX_GIABAN;
                    objHDNX.HDNX_TONGCHIECKHAU = (objHDNX.HDNX_TONGBAN * Decimal.Parse(objHDNX.HDNX_CHIECKHAU.ToString())) / 100;
                    objHDNX.HDNX_THANHTIEN = objHDNX.HDNX_TONGBAN - objHDNX.HDNX_TONGCHIECKHAU;

                    if (txtTenHang.Text.Trim() == "")
                    {
                        MessageBox.Show("Vui lòng nhập hàng hóa");
                        txtMaHang.Focus();
                        return;
                    }

                    if (objHDNX.HDNX_GIAMUA <= 0)
                    {
                        MessageBox.Show("Vui lòng nhập giá nhập");
                        txtGiaNhap.Focus();
                        return;
                    }

                    if (objHDNX.HDNX_GIABAN <= 0)
                    {
                        MessageBox.Show("Vui lòng nhập giá bán");
                        txtGiaBan.Focus();
                        return;
                    }

                    if (objHDNX.HDNX_SOLUONG <= 0)
                    {
                        MessageBox.Show("Vui lòng nhập số lượng");
                        txtSoLuong.Focus();
                        return;
                    }

                    //double vSoLuongXuatk = 0;
                    //for (int i = 0; i < dtHH.Rows.Count; i++)
                    //{
                    //    if (dtHH.Rows[i]["ID"].ToString() != vIdHH)
                    //    {
                    //        if (dtHH.Rows[i]["HH_MAHANG"].ToString() == txtMaHang.Text.Trim())
                    //        {
                    //            vSoLuongXuatk += double.Parse(dtHH.Rows[i]["HDNX_SOLUONG"].ToString());
                    //        }
                    //    }
                    //}

                    //List<HD_NHAPXUAT> listHH = new List<HD_NHAPXUAT>();
                    //listHH = ClassController.layDSHangHoaNhapKhoByMaHang("KHO000001", objHDNX.HH_MAHANG);
                    string vIdHH_new = DateTime.Now.Millisecond + "" + DateTime.Now.Second + "" + DateTime.Now.Minute + "" + DateTime.Now.Hour + "" + DateTime.Now.Day + "" + DateTime.Now.Month + "" + DateTime.Now.Year + "";
                    double vSoLuong = txtSoLuong.Text.Trim() == "" ? 0 : double.Parse(txtSoLuong.Text.Trim());
                    double vGiaBan = txtGiaBan.Text.Trim() == "" ? 0 : double.Parse(txtGiaBan.Text.Trim());
                    double vGiaMua = txtGiaNhap.Text.Trim() == "" ? 0 : double.Parse(txtGiaNhap.Text.Trim()); 
                    double vTongMua = vGiaMua * vSoLuong;
                    double vTongBan = vGiaBan * vSoLuong;
                    double vGiaVAT = 0;// (vGiaMua * listHH[0].HDNX_VAT) / 100;
                    double vTongVAT = 0;// vGiaVAT* vSoLuong;
                    double vChiecKhau = 0;// objHH.HH_KHUYENMAI;
                    double vTongChiecKhau = 0;// (vTongBan * vChiecKhau) / 100;
                    double vThanhTien = vTongBan - vTongChiecKhau;

                    dtHH.Rows.Add(
                        0,
                        objHDNX.HH_MAHANG, objHH.HH_TENHANG, objDVT.DVT_TENDONVI,
                        vSoLuong,
                        vChiecKhau,
                        vTongChiecKhau,
                        vGiaBan,
                        vTongBan,
                        vThanhTien,
                        vIdHH_new,
                        vGiaMua,//listHH[0].HDNX_GIAMUA,
                        vTongMua,
                        0,//listHH[0].HDNX_VAT,
                        vGiaVAT,
                        vTongVAT
                    );

                    #region 
                    //List<HD_NHAPXUAT> listHH = new List<HD_NHAPXUAT>();
                    //listHH = ClassController.layDSHangHoaNhapKhoByMaHang("KHO000001", objHDNX.HH_MAHANG);

                    //if (listHH.Count == 1)
                    //{
                    //    string vIdHH_new = DateTime.Now.Millisecond + "" + DateTime.Now.Second + "" + DateTime.Now.Minute + "" + DateTime.Now.Hour + "" + DateTime.Now.Day + "" + DateTime.Now.Month + "" + DateTime.Now.Year + "";
                    //    double vSoLuong = txtSoLuong.Text.Trim() == "" ? 0 : double.Parse(txtSoLuong.Text.Trim());
                    //    double vGiaBan = txtGiaBan.Text.Trim() == "" ? 0 : double.Parse(txtGiaBan.Text.Trim());
                    //    double vGiaMua = double.Parse(listHH[0].HDNX_GIAMUA.ToString());
                    //    double vTongMua = vGiaMua * vSoLuong;
                    //    double vTongBan = vGiaBan * vSoLuong;
                    //    double vGiaVAT = (vGiaMua * listHH[0].HDNX_VAT) / 100;
                    //    double vTongVAT = vGiaVAT * vSoLuong;
                    //    double vChiecKhau = objHH.HH_KHUYENMAI;
                    //    double vTongChiecKhau = (vTongBan * vChiecKhau) / 100;
                    //    double vThanhTien = vTongBan - vTongChiecKhau;

                    //    dtHH.Rows.Add(
                    //        0,
                    //        objHDNX.HH_MAHANG, objHH.HH_TENHANG, objDVT.DVT_TENDONVI,
                    //        vSoLuong,
                    //        vChiecKhau,
                    //        vTongChiecKhau,
                    //        vGiaBan,
                    //        vTongBan,
                    //        vThanhTien,
                    //        vIdHH_new,
                    //        listHH[0].HDNX_GIAMUA,
                    //        vTongMua,
                    //        listHH[0].HDNX_VAT,
                    //        vGiaVAT,
                    //        vTongVAT
                    //    );
                    //}
                    //else if (listHH.Count > 1)
                    //{
                    //    double vGiaBan = txtGiaBan.Text.Trim() == "" ? 0 : double.Parse(txtGiaBan.Text.Trim());
                    //    double vSoLuongXuat = txtSoLuong.Text.Trim() == "" ? 0 : double.Parse(txtSoLuong.Text.Trim());
                    //    int flag = 0;
                    //    foreach (var item in listHH)
                    //    {
                    //        flag = flag + 1;
                    //        string vIdHH_new = flag + "" + DateTime.Now.Millisecond + "" + DateTime.Now.Second + "" + DateTime.Now.Minute + "" + DateTime.Now.Hour + "" + DateTime.Now.Day + "" + DateTime.Now.Month + "" + DateTime.Now.Year + "";
                    //        double vSoLuongTon = item.HDNX_SOLUONG;
                    //        double vGiaMua = double.Parse(item.HDNX_GIAMUA.ToString());

                    //        if (vSoLuongTon >= vSoLuongXuat)
                    //        {
                    //            double vTongMua = vGiaMua * vSoLuongXuat;
                    //            double vVAT = item.HDNX_VAT;
                    //            double vGiaVAT = (vGiaMua * vVAT) / 100;
                    //            double vTongVAT = vGiaVAT * vSoLuongXuat;
                    //            double vTongBan = vGiaBan * vSoLuongXuat;
                    //            double vChiecKhau = objHH.HH_KHUYENMAI;
                    //            double vTongChiecKhau = (vTongBan * vChiecKhau) / 100;
                    //            double vThanhTien = vTongBan - vTongChiecKhau;

                    //            dtHH.Rows.Add(
                    //                0, objHDNX.HH_MAHANG, objHH.HH_TENHANG, objDVT.DVT_TENDONVI,
                    //                vSoLuongXuat,
                    //                vChiecKhau,
                    //                vTongChiecKhau,
                    //                vGiaBan,
                    //                vTongBan,
                    //                vThanhTien,
                    //                vIdHH_new,
                    //                vGiaMua,
                    //                vTongMua,
                    //                vVAT,
                    //                vGiaVAT,
                    //                vTongVAT
                    //            );
                    //            break;
                    //        }
                    //        else if (vSoLuongTon < vSoLuongXuat)
                    //        {
                    //            vSoLuongXuat -= vSoLuongTon;
                    //            double vTongMua = vGiaMua * vSoLuongTon;
                    //            double vVAT = item.HDNX_VAT;
                    //            double vGiaVAT = (vGiaMua * vVAT) / 100;
                    //            double vTongVAT = vGiaVAT * vSoLuongTon;
                    //            double vTongBan = vGiaBan * vSoLuongTon;
                    //            double vChiecKhau = objHH.HH_KHUYENMAI;
                    //            double vTongChiecKhau = (vTongBan * vChiecKhau) / 100;
                    //            double vThanhTien = vTongBan - vTongChiecKhau;

                    //            dtHH.Rows.Add(
                    //                0, objHDNX.HH_MAHANG, objHH.HH_TENHANG, objDVT.DVT_TENDONVI,
                    //                vSoLuongTon,
                    //                vChiecKhau,
                    //                vTongChiecKhau,
                    //                vGiaBan,
                    //                vTongBan,
                    //                vThanhTien,
                    //                vIdHH_new,
                    //                vGiaMua,
                    //                vTongMua,
                    //                vVAT,
                    //                vGiaVAT,
                    //                vTongVAT
                    //            );
                    //        }
                    //    }
                    //}
                    #endregion
                    for (int i = 0; i < dtHH.Rows.Count; i++)
                    {
                        if (dtHH.Rows[i]["ID"].ToString() == vIdHH)
                        {
                            dtHH.Rows.RemoveAt(i);
                        }
                    }
                    loadDSHangHoa();
                    updateFieldTT();
                    updateTienThoiLai();
                    setEmptyFieldHH();
                    vIdHH = "";
                    setStatusFieldHH(false);
                    btnThemHH.Text = "Thêm";
                    btnSuaHH.Text = "Sửa";
                    StatusButtonHH = "";
                    btnXoaHH.Enabled = true;

                    if (gridViewHangHoa.DataRowCount > 0)
                    {
                        gridViewHangHoa.FocusedRowHandle = StatusRowClickHH;
                        fillControlHH(StatusRowClickHH);
                    }
                }
            }
        }

        public void SuaHH()
        {
            if (btnSuaHH.Text == "Sửa")
            {
                if (txtTenHang.Text != "")
                {
                    StatusButtonHH = "Sua";
                    btnThemHH.Text = "Lưu";
                    btnSuaHH.Text = "Bỏ qua";
                    btnXoaHH.Enabled = false;
                    setStatusFieldHH(true);
                    setStatucButtonUpdateGia(true);
                    txtMaHang.Focus();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn hàng hóa");
                }
            }
            else if (btnSuaHH.Text == "Bỏ qua")
            {
                StatusButtonHH = "";
                btnThemHH.Text = "Thêm";
                btnSuaHH.Text = "Sửa";
                btnXoaHH.Enabled = true;
                btnSuaHH.Enabled = true;
                btnThemHH.Enabled = true;
                setStatusFieldHH(false);
                setStatucButtonUpdateGia(false);
                if (gridViewHangHoa.DataRowCount > 0)
                {
                    gridViewHangHoa.FocusedRowHandle = StatusRowClickHH;
                    fillControlHH(StatusRowClickHH);
                }
            }
        }

        public void XoaHH()
        {
            if (txtTenHang.Text != "")
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có muốn xóa?", "Cảnh báo", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    try
                    {
                        for (int i = 0; i < dtHH.Rows.Count; i++)
                        {
                            if (dtHH.Rows[i]["ID"].ToString() == vIdHH)
                            {
                                dtHH.Rows.RemoveAt(i);
                            }
                        }
                        vIdHH = "";
                        loadDSHangHoa();
                        updateFieldTT();
                        updateTienThoiLai();
                        StatusButtonHH = "";

                        if (gridViewHangHoa.DataRowCount > 0)
                        {
                            gridViewHangHoa.FocusedRowHandle = 0;
                            fillControlHH(0);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                else if (dialogResult == DialogResult.Cancel)
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hàng hóa");
            }
        }

        public void ThemHD()
        {
            if (btnThemHD.Text == "Thêm")
            {
                setStatusFieldHH(true);
                setStatusFieldHD(true);
                setStatusFieldTT(true);
                setEmptyFieldHD();
                setEmptyFieldHH();
                setEmptyFieldTT();
                txtHoaDon.Text = ClassController.getSoHDNB("TH");
                StatusButtonHD = "Them";
                btnThemHD.Text = "Lưu";
                btnSuaHD.Text = "Bỏ qua";
                dateNgayHoaDon.DateTime = DateTime.Now;
                btnThemHH.Text = "Lưu";
                btnSuaHH.Text = "Bỏ qua";
                StatusButtonHH = "Them";
                btnSuaHH.Enabled = true;
                btnThemHH.Enabled = true;
                txtKhachHangMa.Focus();
                dtHH.Clear();
                loadDSHangHoa();
            }
            else if (btnThemHD.Text == "Lưu")
            {
                HT_KHOASO objKs = new HT_KHOASO();
                objKs = ClassController.selectKhoaSoByDay(dateNgayHoaDon.DateTime.Date);
                if (objKs.KS_KHOA == 1)
                {
                    MessageBox.Show("Ngày này đã khóa sổ");
                    return;
                }

                if (StatusButtonHD == "Them")
                {
                    if (txtKhachHangTen.Text == "" || txtKhachHangMa.Text == "")
                    {
                        MessageBox.Show("Vui lòng chọn khách hàng");
                        txtKhachHangMa.Focus();
                        return;
                    }

                    HD_NHAPXUAT obj = new HD_NHAPXUAT();
                    obj.HDNX_LOAIHD = "TH";
                    obj.HDNX_SOHDNB = txtHoaDon.Text.Trim();
                    obj.HDNX_NGAYLAP = DateTime.Now;
                    obj.HDNX_SOHD = txtHoaDon.Text.Trim();
                    obj.HDNX_NGAYHD = dateNgayHoaDon.Text != "" ? dateNgayHoaDon.DateTime : DateTime.Now;
                    obj.HDNX_SONGAYHD = Int32.Parse(dateNgayHoaDon.DateTime.Year + "" + dateNgayHoaDon.DateTime.Month + "" + dateNgayHoaDon.DateTime.Day);
                    obj.NPP_MANPP = txtKhachHangMa.Text.Trim();
                    obj.HDNX_GHICHU = txtGhiChu.Text.Trim();
                    obj.KH_MAKHO = "KHO000001";
                    obj.HDNX_GIAMKHAC = 0;//-(txtGiamGiaKhac.Text.Trim() != "" ? Decimal.Parse(txtGiamGiaKhac.Text.Trim()) : 0);
                    obj.HDNX_KHACHDUA = 0;// txtTienKhachTra.Text.Trim() != "" ? Decimal.Parse(txtTienKhachTra.Text.Trim()) : 0;
                    obj.HDNX_THOILAI = 0;// txtTienThoiLai.Text.Trim() != "" ? Decimal.Parse(txtTienThoiLai.Text.Trim()) : 0;
                    obj.HDNX_TRANGTHAI = 1;
                    obj.HDNX_GHINO = 0;
                    obj.HDNX_TRAHANG = 1;

                    for (int i = 0; i < dtHH.Rows.Count; i++)
                    {
                        obj.HH_MAHANG = dtHH.Rows[i]["HH_MAHANG"].ToString();
                        obj.HDNX_GIABAN = Decimal.Parse(dtHH.Rows[i]["HDNX_GIABAN"].ToString());
                        obj.HDNX_CHIECKHAU = Int32.Parse(dtHH.Rows[i]["HDNX_CHIECKHAU"].ToString());
                        obj.HDNX_SOLUONG = (double.Parse(dtHH.Rows[i]["HDNX_SOLUONG"].ToString()));
                        obj.HDNX_TONGBAN = (Decimal.Parse(dtHH.Rows[i]["HDNX_TONGBAN"].ToString()));
                        obj.HDNX_THANHTIEN = (Decimal.Parse(dtHH.Rows[i]["HDNX_THANHTIEN"].ToString()));
                        obj.HDNX_TONGCHIECKHAU = (Decimal.Parse(dtHH.Rows[i]["HDNX_TONGCHIECKHAU"].ToString()));
                        obj.HDNX_STT = i + 1;
                        //
                        obj.HDNX_GIAMUA = (Decimal.Parse(dtHH.Rows[i]["HDNX_GIAMUA"].ToString()));
                        obj.HDNX_VAT = (double.Parse(dtHH.Rows[i]["HDNX_VAT"].ToString()));
                        obj.HDNX_GIAVAT = (Decimal.Parse(dtHH.Rows[i]["HDNX_GIAVAT"].ToString()));
                        obj.HDNX_TONGVAT = (Decimal.Parse(dtHH.Rows[i]["HDNX_TONGVAT"].ToString()));
                        obj.HDNX_TONGMUA = (Decimal.Parse(dtHH.Rows[i]["HDNX_TONGMUA"].ToString()));
                        ClassController.themHoaDonTraHang(obj);
                    }
                    btnThemHD.Text = "Thêm";
                    btnSuaHD.Text = "Sửa";
                    StatusButtonHD = "";
                    setStatusButtonHD(true);
                    setStatusButtonHH(false);
                    setStatusFieldHH(false);
                    setStatusFieldHD(false);
                    setStatusFieldTT(false);
                    loadDSHoaDon();
                    //setEmptyFieldHH();
                    //setEmptyFieldHD();
                    //setEmptyFieldTT();
                    //dtHH.Clear();
                }
                else if (StatusButtonHD == "Sua")
                {
                    string HDNX_SOHDNB = txtHoaDon.Text.Trim();
                    try
                    {
                        if (txtKhachHangTen.Text == "" || txtKhachHangMa.Text == "")
                        {
                            MessageBox.Show("Vui lòng chọn khách hàng");
                            txtKhachHangMa.Focus();
                            return;
                        }

                        HD_NHAPXUAT objHDNX_OLD = new HD_NHAPXUAT();
                        objHDNX_OLD = ClassController.layThongTinHoaDonTraHang(HDNX_SOHDNB);

                        using (SqlConnection connect = ClassController.ConnectDatabase())
                        {
                            connect.Open();
                            SqlCommand sqlCmd = new SqlCommand("UpdateHdTraHang", connect);
                            sqlCmd.CommandTimeout = 1000;
                            sqlCmd.Parameters.AddWithValue("@HDNX_SOHDNB", HDNX_SOHDNB);
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.ExecuteNonQuery();
                            connect.Close();
                        }

                        HD_NHAPXUAT objHDNX_NEW = new HD_NHAPXUAT();
                        objHDNX_NEW.HDNX_LOAIHD = "TH";
                        objHDNX_NEW.HDNX_SOHDNB = txtHoaDon.Text.Trim();
                        objHDNX_NEW.HDNX_NGAYLAP = objHDNX_OLD.HDNX_NGAYLAP;
                        objHDNX_NEW.HDNX_NGAYCAPNHAT = DateTime.Now;
                        objHDNX_NEW.HDNX_SOHD = txtHoaDon.Text.Trim();
                        objHDNX_NEW.HDNX_NGAYHD = dateNgayHoaDon.DateTime;
                        objHDNX_NEW.HDNX_SONGAYHD = Int32.Parse(dateNgayHoaDon.DateTime.Year + "" + dateNgayHoaDon.DateTime.Month + "" + dateNgayHoaDon.DateTime.Day);
                        objHDNX_NEW.NPP_MANPP = txtKhachHangMa.Text.Trim();
                        objHDNX_NEW.HDNX_GHICHU = txtGhiChu.Text.Trim();
                        objHDNX_NEW.KH_MAKHO = "KHO000001";
                        objHDNX_NEW.HDNX_GIAMKHAC = 0;// -(txtGiamGiaKhac.Text.Trim() != "" ? Decimal.Parse(txtGiamGiaKhac.Text.Trim()) : 0);
                        objHDNX_NEW.HDNX_KHACHDUA = 0;// txtTienKhachTra.Text.Trim() != "" ? Decimal.Parse(txtTienKhachTra.Text.Trim()) : 0;
                        objHDNX_NEW.HDNX_THOILAI = 0;// txtTienThoiLai.Text.Trim() != "" ? Decimal.Parse(txtTienThoiLai.Text.Trim()) : 0;
                        objHDNX_NEW.HDNX_TRANGTHAI = 1;
                        objHDNX_NEW.HDNX_GHINO = 0;
                        objHDNX_NEW.HDNX_TRAHANG = 1;

                        for (int i = 0; i < dtHH.Rows.Count; i++)
                        {
                            objHDNX_NEW.HH_MAHANG = dtHH.Rows[i]["HH_MAHANG"].ToString();
                            objHDNX_NEW.HDNX_SOLUONG = (double.Parse(dtHH.Rows[i]["HDNX_SOLUONG"].ToString()));
                            objHDNX_NEW.HDNX_GIABAN = Decimal.Parse(dtHH.Rows[i]["HDNX_GIABAN"].ToString());
                            objHDNX_NEW.HDNX_TONGBAN = (Decimal.Parse(dtHH.Rows[i]["HDNX_TONGBAN"].ToString()));
                            objHDNX_NEW.HDNX_THANHTIEN = (Decimal.Parse(dtHH.Rows[i]["HDNX_THANHTIEN"].ToString()));
                            objHDNX_NEW.HDNX_CHIECKHAU = Int32.Parse(dtHH.Rows[i]["HDNX_CHIECKHAU"].ToString());
                            objHDNX_NEW.HDNX_TONGCHIECKHAU = (Decimal.Parse(dtHH.Rows[i]["HDNX_TONGCHIECKHAU"].ToString()));
                            objHDNX_NEW.HDNX_STT = i + 1;
                            //
                            objHDNX_NEW.HDNX_GIAMUA = (Decimal.Parse(dtHH.Rows[i]["HDNX_GIAMUA"].ToString()));
                            objHDNX_NEW.HDNX_VAT = (double.Parse(dtHH.Rows[i]["HDNX_VAT"].ToString()));
                            objHDNX_NEW.HDNX_GIAVAT = (Decimal.Parse(dtHH.Rows[i]["HDNX_GIAVAT"].ToString()));
                            objHDNX_NEW.HDNX_TONGVAT = (Decimal.Parse(dtHH.Rows[i]["HDNX_TONGVAT"].ToString()));
                            objHDNX_NEW.HDNX_TONGMUA = (Decimal.Parse(dtHH.Rows[i]["HDNX_TONGMUA"].ToString()));
                            ClassController.capNhatHoaDonTraHang(objHDNX_NEW);
                        }
                        btnThemHD.Text = "Thêm";
                        btnSuaHD.Text = "Sửa";
                        StatusButtonHD = "";
                        setStatusButtonHD(true);
                        setStatusButtonHH(false);
                        setStatusFieldHH(false);
                        setStatusFieldHD(false);
                        setStatusFieldTT(false);
                        updateDSHoaDon();
                        //setEmptyFieldHH();
                        //setEmptyFieldHD();
                        //setEmptyFieldTT();
                        //dtHH.Clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }

        public void SuaHD()
        {
            if (btnSuaHD.Text == "Sửa")
            {
                if (txtHoaDon.Text != "")
                {
                    HT_KHOASO objKs = new HT_KHOASO();
                    objKs = ClassController.selectKhoaSoByDay(dateNgayHoaDon.DateTime.Date);
                    if (objKs.KS_KHOA == 1)
                    {
                        MessageBox.Show("Ngày này đã khóa sổ");
                        return;
                    }

                    setStatusFieldHH(true);
                    setStatusFieldHD(true);
                    setStatusFieldTT(true);
                    setStatusButtonHD(true);
                    setStatusButtonHH(true);
                    btnInHD.Enabled = false;
                    StatusButtonHD = "Sua";
                    btnThemHD.Text = "Lưu";
                    btnSuaHD.Text = "Bỏ qua";
                    StatusButtonHH = "";
                    btnThemHH.Text = "Thêm";
                    btnSuaHH.Text = "Sửa";
                    txtKhachHangMa.Focus();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn hóa đơn");
                }
            }
            else if (btnSuaHD.Text == "Bỏ qua")
            {
                setStatusFieldHH(false);
                setStatusFieldHD(false);
                setStatusFieldTT(false);
                setStatusButtonHD(true);
                setStatusButtonHH(false);
                setEmptyFieldHD();
                setEmptyFieldHH();
                setEmptyFieldTT();
                btnThemHD.Text = "Thêm";
                btnSuaHD.Text = "Sửa";
                StatusButtonHD = "";
                StatusButtonHH = "";
                dtHH.Clear();
                if (gridViewHoaDon.DataRowCount > 0)
                {
                    gridViewHoaDon.FocusedRowHandle = StatusRowClickHD;
                    fillDataHHbySHDNB(gridViewHoaDon.GetRowCellValue(StatusRowClickHD, "HDNX_SOHDNB").ToString());
                }
            }
        }

        public void XoaHD()
        {
            string HDNX_SOHDNB = txtHoaDon.Text.Trim();
            if (HDNX_SOHDNB != "")
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có muốn xóa?", "Cảnh báo", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    try
                    {
                        HT_KHOASO objKs = new HT_KHOASO();
                        objKs = ClassController.selectKhoaSoByDay(dateNgayHoaDon.DateTime.Date);
                        if (objKs.KS_KHOA == 1)
                        {
                            MessageBox.Show("Ngày này đã khóa sổ");
                            return;
                        }

                        using (SqlConnection connect = ClassController.ConnectDatabase())
                        {
                            connect.Open();
                            SqlCommand sqlCmd = new SqlCommand("DeleteHdTraHang", connect);
                            sqlCmd.CommandTimeout = 1000;
                            sqlCmd.Parameters.AddWithValue("@HDNX_SOHDNB", HDNX_SOHDNB);
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.ExecuteNonQuery();
                            connect.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    setStatusFieldHH(false);
                    setStatusFieldHD(false);
                    setStatusFieldTT(false);
                    setEmptyFieldHD();
                    setEmptyFieldHH();
                    setEmptyFieldTT();
                    StatusButtonHD = "";
                    StatusButtonHH = "";
                    dtHH.Clear();
                    loadDSHoaDon();
                }
                else if (dialogResult == DialogResult.Cancel)
                {
                    return;
                }

            }
            else
            {
                MessageBox.Show("Vui lòng chọn hóa đơn");
            }
        }

        private void btnThemHH_Click(object sender, EventArgs e)
        {
            ThemHH();
        }

        private void btnSuaHH_Click(object sender, EventArgs e)
        {
            SuaHH();
        }

        private void btnXoaHH_Click(object sender, EventArgs e)
        {
            XoaHH();
        }

        private void btnThemHD_Click(object sender, EventArgs e)
        {
            ThemHD();
        }

        private void btnSuaHD_Click(object sender, EventArgs e)
        {
            SuaHD();
        }

        private void btnXoaHD_Click(object sender, EventArgs e)
        {
            XoaHD();
        }

        private void btnDongHD_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInHD_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtHoaDon.Text != "")
                {
                    List<HD_NHAPXUAT> objList = new List<HD_NHAPXUAT>();
                    objList = ClassController.layDSHoaDonXuatLeTheoSHDNB(txtHoaDon.Text);
                    if (objList.Count > 0)
                    {
                        decimal vTongBan = 0;
                        decimal vThanhTien = 0;
                        decimal vTongChiecKhau = 0;
                        decimal vTongTraHang = 0;

                        string vTongHoaDon = "";
                        string vTongThanhToan = "";
                        string vGiamGiaKhac = "";
                        string vTraHang = "";
                        string vChiecKhau = "";
                        string vKhachDua = "";
                        string vThoiLai = "";

                        if (dtHH == null)
                            InitializeDtHDNX();

                        if (dtReport == null)
                            InitializeDtReport();

                        dtReport.Clear();

                        int vSTT = 0;
                        foreach (var item in objList)
                        {
                            vSTT += 1;
                            vTongBan += (item.HDNX_TONGBAN);
                            vThanhTien += (item.HDNX_THANHTIEN);
                            vTongChiecKhau += (item.HDNX_TONGCHIECKHAU);

                            if (item.HDNX_TRAHANG == 1)
                            {
                                vTongTraHang += (item.HDNX_THANHTIEN);
                            }

                            DMHH_HANGHOA objHH = new DMHH_HANGHOA();
                            objHH = ClassController.layHangHoaTheoMa(item.HH_MAHANG);
                            DMHH_DONVITINH objDVT = new DMHH_DONVITINH();
                            objDVT = ClassController.layDonViTinhTheoMa(objHH.DVT_MADONVI);
                            dtReport.Rows.Add(
                                item.HDNX_TRAHANG,
                                item.HH_MAHANG,
                                objHH.HH_TENHANG,
                                objDVT.DVT_TENDONVI,
                                item.HDNX_SOLUONG,
                                item.HDNX_CHIECKHAU,
                                item.HDNX_TONGCHIECKHAU,
                                Decimal.Parse(Double.Parse(item.HDNX_GIABAN.ToString()).ToString()),
                                item.HDNX_TONGBAN,
                                Decimal.Parse(Double.Parse((item.HDNX_THANHTIEN).ToString()).ToString()),
                                vSTT.ToString(),
                                item.HDNX_GIAMUA,
                                item.HDNX_TONGMUA,
                                item.HDNX_VAT,
                                item.HDNX_GIAVAT,
                                item.HDNX_TONGVAT
                            );
                        }

                        vTongHoaDon = ((double)vTongBan).ToString();
                        vTongThanhToan = ((double)vThanhTien).ToString();
                        vGiamGiaKhac = ((double)(-objList[0].HDNX_GIAMKHAC)).ToString();
                        vTraHang = ((double)vTongTraHang).ToString();
                        vChiecKhau = ((double)vTongChiecKhau).ToString();
                        vKhachDua = ((double)objList[0].HDNX_KHACHDUA).ToString();
                        vThoiLai = ((double)objList[0].HDNX_THOILAI).ToString();

                        frmRptPhieuXuatKho frmRptPhieuXuatSi = new frmRptPhieuXuatKho(
                        dtReport,
                        "HÓA ĐƠN BÁN LẺ",
                        objList[0].HDNX_SOHDNB,
                        objList[0].HDNX_NGAYHD.ToShortDateString(),
                        vTongHoaDon, vTraHang, vChiecKhau, vGiamGiaKhac, vTongThanhToan, vKhachDua, vThoiLai
                        );
                        if (ExistFrom(frmRptPhieuXuatSi)) return;
                        frmRptPhieuXuatSi.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnInPX_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtHoaDon.Text != "")
                {
                    List<HD_NHAPXUAT> objList = new List<HD_NHAPXUAT>();
                    objList = ClassController.layDSHoaDonXuatLeTheoSHDNB(txtHoaDon.Text);
                    if (objList.Count > 0)
                    {
                        decimal vTongBan = 0;
                        decimal vThanhTien = 0;
                        decimal vTongChiecKhau = 0;
                        decimal vTongTraHang = 0;

                        string vTongHoaDon = "";
                        string vTongThanhToan = "";
                        string vGiamGiaKhac = "";
                        string vTraHang = "";
                        string vChiecKhau = "";
                        string vKhachDua = "";
                        string vThoiLai = "";

                        if (dtHH == null)
                            InitializeDtHDNX();

                        if (dtReport == null)
                            InitializeDtReport();

                        dtReport.Clear();

                        int vSTT = 0;
                        foreach (var item in objList)
                        {
                            vSTT += 1;
                            vTongBan += (item.HDNX_TONGBAN);
                            vThanhTien += (item.HDNX_THANHTIEN);
                            vTongChiecKhau += (item.HDNX_TONGCHIECKHAU);

                            if (item.HDNX_TRAHANG == 1)
                            {
                                vTongTraHang += (item.HDNX_THANHTIEN);
                            }

                            DMHH_HANGHOA objHH = new DMHH_HANGHOA();
                            objHH = ClassController.layHangHoaTheoMa(item.HH_MAHANG);
                            DMHH_DONVITINH objDVT = new DMHH_DONVITINH();
                            objDVT = ClassController.layDonViTinhTheoMa(objHH.DVT_MADONVI);
                            dtReport.Rows.Add(
                                item.HDNX_TRAHANG,
                                item.HH_MAHANG,
                                objHH.HH_TENHANG,
                                objDVT.DVT_TENDONVI,
                                item.HDNX_SOLUONG,
                                item.HDNX_CHIECKHAU,
                                item.HDNX_TONGCHIECKHAU,
                                Decimal.Parse(Double.Parse(item.HDNX_GIABAN.ToString()).ToString()),
                                item.HDNX_TONGBAN,
                                Decimal.Parse(Double.Parse((item.HDNX_THANHTIEN).ToString()).ToString()),
                                vSTT.ToString(),
                                item.HDNX_GIAMUA,
                                item.HDNX_TONGMUA,
                                item.HDNX_VAT,
                                item.HDNX_GIAVAT,
                                item.HDNX_TONGVAT
                            );
                        }

                        vTongHoaDon = ((double)vTongBan).ToString();
                        vTongThanhToan = ((double)vThanhTien).ToString();
                        vGiamGiaKhac = ((double)(-objList[0].HDNX_GIAMKHAC)).ToString();
                        vTraHang = ((double)vTongTraHang).ToString();
                        vChiecKhau = ((double)vTongChiecKhau).ToString();
                        vKhachDua = ((double)objList[0].HDNX_KHACHDUA).ToString();
                        vThoiLai = ((double)objList[0].HDNX_THOILAI).ToString();

                        frmRptHoaDonXuatKho frmRptHoaDonXuatKho = new frmRptHoaDonXuatKho(
                        dtReport,
                        "PHIẾU XUẤT KHO BÁN LẺ",
                        objList[0].HDNX_SOHDNB,
                        objList[0].HDNX_NGAYHD.ToShortDateString(),
                        vTongHoaDon, vTraHang, vChiecKhau, vGiamGiaKhac, vTongThanhToan,
                        "Quản lý",
                        ClassController.layKhachHangTheoMa(objList[0].NPP_MANPP).NPP_TENNPP
                        );
                        if (ExistFrom(frmRptHoaDonXuatKho)) return;
                        frmRptHoaDonXuatKho.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnSuaGiaNhap_Click(object sender, EventArgs e)
        {
            if (txtGiaNhap.Properties.ReadOnly == false)
            {
                if (txtTenHang.Text.Trim() != "")
                {
                    txtGiaNhap.Properties.ReadOnly = true;
                    DMHH_HANGHOA objHH = new DMHH_HANGHOA();
                    objHH.HH_MAHANG = txtMaHang.Text.Trim();
                    objHH.HH_GIAMUA = txtGiaNhap.Text.Trim() != "" ? Decimal.Parse(txtGiaNhap.Text.Trim()) : 0;
                    ClassController.capNhatGiaNhap(objHH);
                }
                else
                {
                    txtGiaNhap.Properties.ReadOnly = true;
                }
            }
            else
            {
                txtGiaNhap.Properties.ReadOnly = false;
            }
        }

        private void btnSuaGiaBan_Click(object sender, EventArgs e)
        {
            if (txtGiaBan.Properties.ReadOnly == false)
            {
                if (txtTenHang.Text.Trim() != "")
                {
                    txtGiaBan.Properties.ReadOnly = true;
                    DMHH_HANGHOA objHH = new DMHH_HANGHOA();
                    objHH.HH_MAHANG = txtMaHang.Text.Trim();
                    objHH.HH_GIABANLE = txtGiaBan.Text.Trim() != "" ? Decimal.Parse(txtGiaBan.Text.Trim()) : 0;
                    ClassController.capNhatGiaBan(objHH);
                }
                else
                {
                    txtGiaBan.Properties.ReadOnly = true;
                }
            }
            else
            {
                txtGiaBan.Properties.ReadOnly = false;
            }
        }

        private void lkHienThi_EditValueChanged(object sender, EventArgs e)
        {
            updateDSHoaDon();
        }

        private void txtKhachHangMa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (StatusButtonHD != "")
                {
                    if (txtKhachHangMa.Text.Trim() == "")
                    {
                        frmShowKhachHang frm = new frmShowKhachHang();
                        frm.ShowDialog(this);
                        txtKhachHangMa.Text = frm.dvtMa;
                        txtKhachHangTen.Text = frm.dvtTen;
                        txtKhachHangTen.Focus();
                    }
                    else
                    {
                        DM_NHAPHANPHOI objNPP = new DM_NHAPHANPHOI();
                        objNPP = ClassController.layKhachHangTheoMa(txtKhachHangMa.Text.Trim());
                        if (objNPP != null && objNPP.NPP_MANPP != "")
                        {
                            txtKhachHangMa.Text = objNPP.NPP_MANPP;
                            txtKhachHangTen.Text = objNPP.NPP_TENNPP;
                            txtKhachHangTen.Focus();
                        }
                        else
                        {
                            frmShowKhachHang frm = new frmShowKhachHang();
                            frm.ShowDialog(this);
                            txtKhachHangMa.Text = frm.dvtMa;
                            txtKhachHangTen.Text = frm.dvtTen;
                            txtKhachHangTen.Focus();
                        }
                    }
                }
            }
        }

        private void txtXuatKhoMa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (StatusButtonHD != "")
                {
                    //if (txtXuatKhoMa.Text.Trim() == "")
                    //{
                    //    frmShowNhapKho frm = new frmShowNhapKho();
                    //    frm.ShowDialog(this);
                    //    txtXuatKhoMa.Text = frm.dvtMa;
                    //    txtXuatKhoTen.Text = frm.dvtTen;
                    //}
                    //else
                    //{
                    //    DM_KHOHANG objKH = new DM_KHOHANG();
                    //    objKH = ClassController.layKhoHangTheoMa(txtXuatKhoMa.Text.Trim());
                    //    if (objKH != null && objKH.KH_MAKHO != "")
                    //    {
                    //        txtXuatKhoMa.Text = objKH.KH_MAKHO;
                    //        txtXuatKhoTen.Text = objKH.KH_TENKHO;
                    //    }
                    //    else
                    //    {
                    //        frmShowNhapKho frm = new frmShowNhapKho();
                    //        frm.ShowDialog(this);
                    //        txtXuatKhoMa.Text = frm.dvtMa;
                    //        txtXuatKhoTen.Text = frm.dvtTen;
                    //        txtXuatKhoTen.Focus();
                    //    }
                    //}
                }
            }
        }

        private void txtMaHang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (StatusButtonHD != "" && StatusButtonHH != "")
                {
                    //if (txtXuatKhoMa.Text != "" || txtXuatKhoTen.Text != "")
                    //{
                    if (txtMaHang.Text.Trim() == "")
                    {
                        frmShowHangHoa frm = new frmShowHangHoa("KHO000001");
                        frm.ShowDialog(this);
                        if (frm.pHhMa != null)
                        {
                            //txtDonViTinh.Text = frm.pHhDVT;
                            txtGiaNhap.Text = ((int)double.Parse(frm.pHhGiaNhap)).ToString();
                            txtGiaBan.Text = ((int)double.Parse(frm.pHhGiaBan)).ToString();
                            txtMaHang.Text = frm.pHhMa;
                            txtTenHang.Text = frm.pHhTen;
                            txtTonKho.Text = frm.pHhTonKho.ToString();
                            setStatucButtonUpdateGia(true);
                            txtGiaBan.Focus();
                        }
                        else
                        {
                            txtGhiChu.Focus();
                        }
                    }
                    else
                    {
                        DMHH_HANGHOA objHH = new DMHH_HANGHOA();
                        objHH = ClassController.layHangHoaTheoMa(txtMaHang.Text.Trim());
                        if (objHH != null && objHH.HH_MAHANG != "")
                        {
                            txtMaHang.Text = objHH.HH_MAHANG;
                            txtTenHang.Text = objHH.HH_TENHANG;
                            //txtDonViTinh.Text = ClassController.layDonViTinhTheoMa(objHH.DVT_MADONVI).DVT_TENDONVI;
                            txtGiaNhap.Text = ((int)objHH.HH_GIAMUA).ToString();
                            txtGiaBan.Text = ((int)objHH.HH_GIABANLE).ToString();
                            txtTonKho.Text = ClassController.layTonKhoHangHoa(objHH.HH_MAHANG, "KHO000001").ToString();
                            setStatucButtonUpdateGia(true);
                            txtGiaBan.Focus();
                        }
                        else
                        {
                            frmShowHangHoa frm = new frmShowHangHoa("KHO000001");
                            frm.ShowDialog(this);
                            if (frm.pHhMa != null)
                            {
                                txtMaHang.Text = frm.pHhMa;
                                txtTenHang.Text = frm.pHhTen;
                                //txtDonViTinh.Text = frm.pHhDVT;
                                txtGiaNhap.Text = ((int)double.Parse(frm.pHhGiaNhap)).ToString();
                                txtGiaBan.Text = ((int)Double.Parse(frm.pHhGiaBan)).ToString();
                                txtTonKho.Text = frm.pHhTonKho.ToString();
                                setStatucButtonUpdateGia(true);
                                txtGiaBan.Focus();
                            }
                            else
                            {
                                txtGhiChu.Focus();
                            }
                        }
                    }
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Bạn chưa chọn kho xuất");
                    //}
                }

            }
        }

        private void txtSoLuong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTonKho.Focus();
            }
        }

        private void gridViewHoaDon_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                StatusRowClickHD = e.FocusedRowHandle;
                if (StatusButtonHD == "")
                {
                    if (gridViewHoaDon.GetRowCellValue(e.FocusedRowHandle, "HDNX_SOHDNB") != null)
                    {
                        fillDataHHbySHDNB(gridViewHoaDon.GetRowCellValue(e.FocusedRowHandle, "HDNX_SOHDNB").ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void gridViewHoaDon_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                StatusRowClickHD = e.RowHandle;
                if (StatusButtonHD == "")
                {
                    if (gridViewHoaDon.GetRowCellValue(e.RowHandle, "HDNX_SOHDNB") != null)
                    {
                        fillDataHHbySHDNB(gridViewHoaDon.GetRowCellValue(e.RowHandle, "HDNX_SOHDNB").ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void gridViewHangHoa_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                StatusRowClickHH = e.FocusedRowHandle;
                if (StatusButtonHH == "")
                {
                    if (gridViewHangHoa.GetRowCellValue(e.FocusedRowHandle, "ID") != null)
                    {
                        fillControlHH(e.FocusedRowHandle);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void gridViewHangHoa_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                StatusRowClickHH = e.RowHandle;
                if (StatusButtonHH == "")
                {
                    if (gridViewHangHoa.GetRowCellValue(e.RowHandle, "ID") != null)
                    {
                        fillControlHH(e.RowHandle);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtGiamGiaKhac_TextChanged(object sender, EventArgs e)
        {
            updateTienThoiLai();
        }

        private void txtTienKhachTra_TextChanged(object sender, EventArgs e)
        {
            updateTienThoiLai();
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double vGiaBan = txtGiaBan.Text.Trim() != "" ? Double.Parse(txtGiaBan.Text.ToString()) : 0;
                double vSoLuong = txtSoLuong.Text.Trim() != "" ? Double.Parse(txtSoLuong.Text.Trim()) : 0;
                txtThanhTien.Text = (vGiaBan * vSoLuong).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtGiaBan_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double vGiaBan = txtGiaBan.Text.Trim() != "" ? Double.Parse(txtGiaBan.Text.ToString()) : 0;
                double vSoLuong = txtSoLuong.Text.Trim() != "" ? Double.Parse(txtSoLuong.Text.Trim()) : 0;
                txtThanhTien.Text = (vGiaBan * vSoLuong).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtChiecKhau_TextChanged(object sender, EventArgs e)
        {
            updateTienThoiLai();
        }

        private void txtKhachHangMa_TextChanged(object sender, EventArgs e)
        {
            DM_NHAPHANPHOI objNPP = new DM_NHAPHANPHOI();
            objNPP = ClassController.layKhachHangTheoMa(txtKhachHangMa.Text.Trim());
            if (objNPP != null && objNPP.NPP_MANPP != "")
            {
                txtKhachHangMa.Text = objNPP.NPP_MANPP;
                txtKhachHangTen.Text = objNPP.NPP_TENNPP;
                txtGhiChu.Focus();
            }
            else
            {
                txtKhachHangMa.Text = "";
                txtKhachHangTen.Text = "";
            }
        }

        private void txtMaHang_TextChanged(object sender, EventArgs e)
        {
            DMHH_HANGHOA objHH = new DMHH_HANGHOA();
            objHH = ClassController.layHangHoaTheoMa(txtMaHang.Text.Trim());
            if (objHH != null && objHH.HH_MAHANG != "")
            {
                txtMaHang.Text = objHH.HH_MAHANG;
                txtTenHang.Text = objHH.HH_TENHANG;
                txtGiaNhap.Text = ((int)objHH.HH_GIAMUA).ToString();
                txtGiaBan.Text = ((int)objHH.HH_GIABANLE).ToString();
            }
            else
            {
                txtMaHang.Text = "";
                txtTenHang.Text = "";
                txtGiaNhap.Text = "";
                txtGiaBan.Text = "";
            }
        }

        private void chkTraHang_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                double vSL = txtSoLuong.Text.Trim() != "" ? double.Parse(txtSoLuong.Text.Trim()) : 0;
                double vThanhTien = txtThanhTien.Text.Trim() != "" ? double.Parse(txtThanhTien.Text.Trim()) : 0;

                txtSoLuong.Text = (vSL > 0 ? vSL : -vSL).ToString();
                txtThanhTien.Text = (vThanhTien > 0 ? vThanhTien : -vThanhTien).ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F1))
            {
                if (btnThemHD.Enabled)
                    ThemHD();
                return true;
            }

            if (keyData == (Keys.F2))
            {
                if (btnSuaHD.Enabled)
                    SuaHD();
                return true;
            }

            if (keyData == (Keys.F3))
            {
                if (btnXoaHD.Enabled)
                    XoaHD();
                return true;
            }

            if (keyData == (Keys.F4))
            {
                this.Close();
                return true;
            }

            if (keyData == (Keys.F5))
            {
                if (btnThemHH.Enabled)
                    ThemHH();
                return true;
            }

            if (keyData == (Keys.F6))
            {
                if (btnSuaHH.Enabled)
                    SuaHH();
                return true;
            }

            if (keyData == (Keys.F7))
            {
                if (btnXoaHH.Enabled)
                    XoaHH();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public bool ExistFrom(Form frm)
        {
            foreach (var child in MdiChildren)
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
