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
    public partial class frmNhapKho : Form
    {
        protected string StatusButtonHD = "";
        protected string StatusButtonHH = "";
        protected int StatusRowClickHD = 0;
        protected int StatusRowClickHH = 0;
        protected string vIdHH = "";
        public static frmNhapKho _frmNhapKho;
        DataTable dtHH;
        DataTable dtReport;

        public frmNhapKho()
        {
            InitializeComponent();
            _frmNhapKho = this;
            lkpDKThanhToan.Properties.DataSource = ClassController.layDSDKThanhToan();
            cbxHienThi.Properties.DataSource = ClassController.layDSThoiGianHD();
            cbxHienThi.EditValue = "0";
            loadDataHD();
            InitializeDtHDNX();
            if (gridViewDSHoaDon.DataRowCount > 1)
            {
                gridViewDSHoaDon.FocusedRowHandle = 0;
                fillDataHHbySHDNB(gridViewDSHoaDon.GetRowCellValue(0, "HDNX_SOHDNB").ToString());
            }
        }

        public void InitializeDtHDNX()
        {
                dtHH = new DataTable();
                dtHH.Columns.Add("HH_MAHANG", typeof(string));
                dtHH.Columns.Add("HH_TENHANG", typeof(string));
                dtHH.Columns.Add("DVT_TENDONVI", typeof(string));
                dtHH.Columns.Add("HDNX_GIAMUA", typeof(decimal));
                dtHH.Columns.Add("HDNX_QUIDOI", typeof(double));
                dtHH.Columns.Add("HDNX_GIABAN", typeof(decimal));
                dtHH.Columns.Add("HDNX_VAT", typeof(double));
                dtHH.Columns.Add("HDNX_GIAVAT", typeof(decimal));
                dtHH.Columns.Add("HDNX_SOLUONG", typeof(double));
                dtHH.Columns.Add("HDNX_THANHTIEN", typeof(decimal));
                dtHH.Columns.Add("HDNX_TONGMUA", typeof(decimal));
                dtHH.Columns.Add("HDNX_TONGVAT", typeof(decimal));
                dtHH.Columns.Add("ID", typeof(string));
        }

        public void InitializeDtReport()
        {
            dtReport = new DataTable();
            dtReport.Columns.Add("HH_MAHANG", typeof(string));
            dtReport.Columns.Add("HH_TENHANG", typeof(string));
            dtReport.Columns.Add("DVT_TENDONVI", typeof(string));
            dtReport.Columns.Add("HDNX_GIAMUA", typeof(decimal));
            dtReport.Columns.Add("HDNX_QUIDOI", typeof(double));
            dtReport.Columns.Add("HDNX_GIABAN", typeof(decimal));
            dtReport.Columns.Add("HDNX_VAT", typeof(double));
            dtReport.Columns.Add("HDNX_GIAVAT", typeof(decimal));
            dtReport.Columns.Add("HDNX_SOLUONG", typeof(double));
            dtReport.Columns.Add("HDNX_THANHTIEN", typeof(decimal));
            dtReport.Columns.Add("HDNX_TONGMUA", typeof(decimal));
            dtReport.Columns.Add("HDNX_TONGVAT", typeof(decimal));
            dtReport.Columns.Add("ID", typeof(string));
        }

        public void loadDataHH()
        {
            gridCtrlDSHangHoa.DataSource = dtHH;
        }

        public void loadDataHD()
        {
            gridCtrlDSHoaDon.DataSource = ClassController.layDSHoaDonNhapKhoDSLeft();
        }

        public void fillDataHHbySHDNB(string pSoHDNB)
        {
            try
            {
                List<HD_NHAPXUAT> objList = new List<HD_NHAPXUAT>();
                objList = ClassController.layDSHoaDonNhapKhoTheoSHDNB(pSoHDNB);
                if (objList.Count > 0)
                {
                    txtHoaDon.Text = objList[0].HDNX_SOHD;
                    txtNhaCungCapMa.Text = objList[0].NPP_MANPP;
                    txtNhaCungCapTen.Text = ClassController.layNPPTheoMa(objList[0].NPP_MANPP).NPP_TENNPP;
                    txtNhanVienMa.Text = objList[0].NV_MANV;
                    txtNhanVienTen.Text = objList[0].NV_TAIKHOAN;
                    txtNhapVaoKhoMa.Text = objList[0].KH_MAKHO;
                    txtNhapVaoKhoTen.Text = ClassController.layKhoHangTheoMa(objList[0].KH_MAKHO).KH_TENKHO;
                    txtSoHDNB.Text = objList[0].HDNX_SOHDNB;
                    lkpDKThanhToan.EditValue = objList[0].HDTT_MATT;
                    dateNgayHoaDon.DateTime = objList[0].HDNX_NGAYHD;
                    txtGhiChu.Text = objList[0].HDNX_GHICHU;

                    if (dtHH == null)
                        InitializeDtHDNX();

                    dtHH.Clear();
                    foreach (var item in objList)
                    {
                        vIdHH = DateTime.Now.Millisecond + "" + DateTime.Now.Second + "" + DateTime.Now.Minute + "" + DateTime.Now.Hour + "" + DateTime.Now.Day + "" + DateTime.Now.Month + "" + DateTime.Now.Year + "";
                        DMHH_HANGHOA objHH = new DMHH_HANGHOA();
                        objHH = ClassController.layHangHoaTheoMa(item.HH_MAHANG);
                        DMHH_DONVITINH objDVT = new DMHH_DONVITINH();
                        objDVT = ClassController.layDonViTinhTheoMa(objHH.DVT_MADONVI);
                        dtHH.Rows.Add(
                            item.HH_MAHANG,
                            objHH.HH_TENHANG,
                            objDVT.DVT_TENDONVI,
                            item.HDNX_GIAMUA,
                            item.HDNX_QUIDOI,
                            item.HDNX_GIABAN,
                            item.HDNX_VAT,
                            item.HDNX_GIAVAT,
                            item.HDNX_SOLUONG,
                            item.HDNX_THANHTIEN,
                            item.HDNX_TONGMUA,
                            item.HDNX_TONGVAT,
                            vIdHH.ToString()
                        );
                    }
                    loadDataHH();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void fillControlHH(int pRowNumber)
        {
            try
            {
                vIdHH = gridViewDSHangHoa.GetRowCellValue(pRowNumber, "ID").ToString();
                txtMaHang.Text = gridViewDSHangHoa.GetRowCellValue(pRowNumber, "HH_MAHANG").ToString();
                txtTenHang.Text = gridViewDSHangHoa.GetRowCellValue(pRowNumber, "HH_TENHANG").ToString();
                txtDVT.Text = gridViewDSHangHoa.GetRowCellValue(pRowNumber, "DVT_TENDONVI").ToString();
                txtGiaBan.Text = ((int)Double.Parse(gridViewDSHangHoa.GetRowCellValue(pRowNumber, "HDNX_GIABAN").ToString())).ToString();
                txtQC.Text = gridViewDSHangHoa.GetRowCellValue(pRowNumber, "HDNX_QUIDOI").ToString();
                txtSL.Text = gridViewDSHangHoa.GetRowCellValue(pRowNumber, "HDNX_SOLUONG").ToString();
                txtVAT.Text = gridViewDSHangHoa.GetRowCellValue(pRowNumber, "HDNX_VAT").ToString();
                txtGiaNhap.Text = ((int)Double.Parse(gridViewDSHangHoa.GetRowCellValue(pRowNumber, "HDNX_GIAMUA").ToString())).ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void setStatusFieldHH(bool pStatus)
        {
            txtMaHang.Properties.ReadOnly = !pStatus;
            txtGiaNhap.Properties.ReadOnly = !pStatus;
            txtQC.Properties.ReadOnly = !pStatus;
            txtVAT.Properties.ReadOnly = !pStatus;
            txtSL.Properties.ReadOnly = !pStatus;
            txtGiaBan.Properties.ReadOnly = !pStatus;
        }

        public void setStatusFieldHD(bool pStatus)
        {
            txtHoaDon.Properties.ReadOnly = !pStatus;
            dateNgayHoaDon.Properties.ReadOnly = !pStatus;
            txtNhaCungCapMa.Properties.ReadOnly = !pStatus;
            txtNhapVaoKhoMa.Properties.ReadOnly = !pStatus;
            txtNhanVienMa.Properties.ReadOnly = !pStatus;
            txtGhiChu.Properties.ReadOnly = !pStatus;
            lkpDKThanhToan.Properties.ReadOnly = !pStatus;
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

        public void resetFieldHoaDon()
        {
            txtHoaDon.Text = "";
            dateNgayHoaDon.Text = "";
            txtNhaCungCapMa.Text = "";
            txtNhaCungCapTen.Text = "";
            txtNhanVienMa.Text = "";
            txtNhanVienTen.Text = "";
            txtNhapVaoKhoMa.Text = "";
            txtNhapVaoKhoTen.Text = "";
            txtSoHDNB.Text = "";
            txtGhiChu.Text = "";
            lkpDKThanhToan.EditValue = "DK01";
        }

        public void resetFieldHangHoa()
        {
            txtMaHang.Text = "";
            txtTenHang.Text = "";
            txtDVT.Text = "";
            txtGiaNhap.Text = "";
            txtQC.Text = "";
            txtVAT.Text = "";
            txtSL.Text = "";
            txtGiaBan.Text = "";
            txtMaHang.Focus();
        }
        
        public void ThemHH()
        {
            try
            {
                if (btnThemHH.Text == "Thêm")
                {
                    StatusButtonHH = "Them";
                    btnThemHH.Text = "Lưu";
                    btnSuaHH.Text = "Bỏ qua";
                    btnSuaHH.Enabled = true;
                    btnXoaHH.Enabled = false;
                    setStatusFieldHH(true);
                    resetFieldHangHoa();
                    txtMaHang.Focus();
                }
                else if (btnThemHH.Text == "Lưu")
                {
                    if (StatusButtonHH == "Them")
                    {
                        HD_NHAPXUAT objHDNX = new HD_NHAPXUAT();
                        vIdHH = DateTime.Now.Millisecond + "" + DateTime.Now.Second + "" + DateTime.Now.Minute + "" + DateTime.Now.Hour + "" + DateTime.Now.Day + "" + DateTime.Now.Month + "" + DateTime.Now.Year + "";
                        objHDNX.HH_MAHANG = txtMaHang.Text.Trim();
                        objHDNX.HDNX_SOLUONG = txtSL.Text.Trim() == "" ? 0 : Double.Parse(txtSL.Text.Trim());
                        objHDNX.HDNX_GIAMUA = txtGiaNhap.Text.Trim() == "" ? 0 : Decimal.Parse(txtGiaNhap.Text.Trim());
                        objHDNX.HDNX_QUIDOI = txtQC.Text.Trim() == "" ? 0 : Int32.Parse(txtQC.Text.Trim());
                        objHDNX.HDNX_TONGMUA = (Decimal.Parse(objHDNX.HDNX_SOLUONG.ToString()) * objHDNX.HDNX_GIAMUA);
                        objHDNX.HDNX_VAT = txtVAT.Text.Trim() == "" ? 0 : Double.Parse(txtVAT.Text.Trim());
                        objHDNX.HDNX_GIAVAT = ((objHDNX.HDNX_GIAMUA * Decimal.Parse(objHDNX.HDNX_VAT.ToString())) / 100);
                        objHDNX.HDNX_TONGVAT = (Decimal.Parse(objHDNX.HDNX_SOLUONG.ToString()) * objHDNX.HDNX_GIAVAT);
                        objHDNX.HDNX_GIABAN = txtGiaBan.Text.Trim() == "" ? 0 : Decimal.Parse(txtGiaBan.Text.Trim());
                        objHDNX.HDNX_THANHTIEN = objHDNX.HDNX_TONGMUA + objHDNX.HDNX_TONGVAT;

                        if (txtTenHang.Text.Trim() == "" || txtMaHang.Text.Trim() == "")
                        {
                            MessageBox.Show("Vui lòng nhập hàng hóa");
                            txtMaHang.Focus();
                            return;
                        }

                        DMHH_HANGHOA objHH = new DMHH_HANGHOA();
                        objHH = ClassController.layHangHoaTheoMa(objHDNX.HH_MAHANG);
                        if(objHH == null || objHH.HH_MAHANG == "")
                        {
                            MessageBox.Show("Vui lòng nhập hàng hóa");
                            txtMaHang.Focus();
                            return;
                        }

                        if (objHDNX.HDNX_SOLUONG <= 0)
                        {
                            MessageBox.Show("Vui lòng nhập số lượng");
                            txtSL.Focus();
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

                        for(int i=0; i<dtHH.Rows.Count; i++)
                        {
                            if (objHDNX.HH_MAHANG.Equals(dtHH.Rows[i]["HH_MAHANG"].ToString().Trim()))
                            {
                                MessageBox.Show("Đã có hàng hóa này trong hóa đơn");
                                txtMaHang.Focus();
                                return;
                            }
                        }


                        DMHH_DONVITINH objDVT = new DMHH_DONVITINH();
                        objDVT = ClassController.layDonViTinhTheoMa(objHH.DVT_MADONVI);
                        dtHH.Rows.Add(
                            objHDNX.HH_MAHANG,
                            objHH.HH_TENHANG,
                            objDVT.DVT_TENDONVI,
                            objHDNX.HDNX_GIAMUA,
                            objHDNX.HDNX_QUIDOI,
                            objHDNX.HDNX_GIABAN,
                            objHDNX.HDNX_VAT,
                            objHDNX.HDNX_GIAVAT,
                            objHDNX.HDNX_SOLUONG,
                            objHDNX.HDNX_THANHTIEN,
                            objHDNX.HDNX_TONGMUA,
                            objHDNX.HDNX_TONGVAT,
                            vIdHH.ToString()
                        );
                        loadDataHH();
                        resetFieldHangHoa();
                    }
                    else if (StatusButtonHH == "Sua")
                    {
                        HD_NHAPXUAT objHDNX = new HD_NHAPXUAT();
                        objHDNX.HH_MAHANG = txtMaHang.Text.Trim();
                        objHDNX.HDNX_SOLUONG = txtSL.Text.Trim() == "" ? 0 : Double.Parse(txtSL.Text.Trim());
                        objHDNX.HDNX_GIAMUA = txtGiaNhap.Text.Trim() == "" ? 0 : Decimal.Parse(txtGiaNhap.Text.Trim());
                        objHDNX.HDNX_QUIDOI = txtQC.Text.Trim() == "" ? 0 : Int32.Parse(txtQC.Text.Trim());
                        objHDNX.HDNX_TONGMUA = (Decimal.Parse(objHDNX.HDNX_SOLUONG.ToString()) * objHDNX.HDNX_GIAMUA); //Số lượng x Đơn giá
                        objHDNX.HDNX_VAT = txtVAT.Text.Trim() == "" ? 0 : Double.Parse(txtVAT.Text.Trim());
                        objHDNX.HDNX_GIAVAT = ((objHDNX.HDNX_GIAMUA * Decimal.Parse(objHDNX.HDNX_VAT.ToString())) / 100); // VAT x Đơn giá
                        objHDNX.HDNX_TONGVAT = (Decimal.Parse(objHDNX.HDNX_SOLUONG.ToString()) * objHDNX.HDNX_GIAVAT); // Giá VAT x Số lượng
                        objHDNX.HDNX_GIABAN = txtGiaBan.Text.Trim() == "" ? 0 : Decimal.Parse(txtGiaBan.Text.Trim());
                        objHDNX.HDNX_THANHTIEN = objHDNX.HDNX_TONGMUA + objHDNX.HDNX_TONGVAT;

                        if (txtTenHang.Text.Trim() == "" || txtMaHang.Text.Trim() == "")
                        {
                            MessageBox.Show("Vui lòng nhập hàng hóa");
                            txtMaHang.Focus();
                            return;
                        }

                        if (objHDNX.HDNX_SOLUONG <= 0)
                        {
                            MessageBox.Show("Vui lòng nhập số lượng");
                            txtSL.Focus();
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

                        for (int i = 0; i < dtHH.Rows.Count; i++)
                        {
                            if (objHDNX.HH_MAHANG.Equals(dtHH.Rows[i]["HH_MAHANG"].ToString().Trim()) && (!vIdHH.Equals(dtHH.Rows[i]["ID"].ToString())))
                            {
                                MessageBox.Show("Đã có hàng hóa này trong hóa đơn");
                                txtMaHang.Focus();
                                return;
                            }
                        }

                        DMHH_HANGHOA objHH = new DMHH_HANGHOA();
                        objHH = ClassController.layHangHoaTheoMa(objHDNX.HH_MAHANG);
                        DMHH_DONVITINH objDVT = new DMHH_DONVITINH();
                        objDVT = ClassController.layDonViTinhTheoMa(objHH.DVT_MADONVI);

                        for (int i = 0; i < dtHH.Rows.Count; i++)
                        {
                            if (dtHH.Rows[i]["ID"].ToString() == vIdHH)
                            {
                                dtHH.Rows[i]["HH_MAHANG"] = objHDNX.HH_MAHANG;
                                dtHH.Rows[i]["HH_TENHANG"] = objHH.HH_TENHANG;
                                dtHH.Rows[i]["DVT_TENDONVI"] = objDVT.DVT_TENDONVI;
                                dtHH.Rows[i]["HDNX_GIAMUA"] = objHDNX.HDNX_GIAMUA;
                                dtHH.Rows[i]["HDNX_QUIDOI"] = objHDNX.HDNX_QUIDOI;
                                dtHH.Rows[i]["HDNX_GIABAN"] = objHDNX.HDNX_GIABAN;
                                dtHH.Rows[i]["HDNX_VAT"] = objHDNX.HDNX_VAT;
                                dtHH.Rows[i]["HDNX_GIAVAT"] = objHDNX.HDNX_GIAVAT;
                                dtHH.Rows[i]["HDNX_SOLUONG"] = objHDNX.HDNX_SOLUONG;
                                dtHH.Rows[i]["HDNX_THANHTIEN"] = objHDNX.HDNX_THANHTIEN;
                                dtHH.Rows[i]["HDNX_TONGMUA"] = objHDNX.HDNX_TONGMUA;
                                dtHH.Rows[i]["HDNX_TONGVAT"] = objHDNX.HDNX_TONGVAT;
                            }
                        }
                        loadDataHH();
                        resetFieldHangHoa();
                        vIdHH = "";
                        setStatusFieldHH(false);
                        btnThemHH.Text = "Thêm";
                        btnSuaHH.Text = "Sửa";
                        StatusButtonHH = "";
                        btnXoaHH.Enabled = true;

                        if (gridViewDSHangHoa.DataRowCount > 0)
                        {
                            gridViewDSHangHoa.FocusedRowHandle = StatusRowClickHH;
                            fillControlHH(StatusRowClickHH);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
                    txtMaHang.Focus();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn hàng hóa");
                }
            }
            else if (btnSuaHH.Text == "Bỏ qua")
            {
                resetFieldHangHoa();
                StatusButtonHH = "";
                btnThemHH.Text = "Thêm";
                btnSuaHH.Text = "Sửa";
                btnXoaHH.Enabled = true;
                btnSuaHH.Enabled = true;
                btnThemHH.Enabled = true;
                setStatusFieldHH(false);
                if (gridViewDSHangHoa.DataRowCount > 0)
                {
                    gridViewDSHangHoa.FocusedRowHandle = StatusRowClickHH;
                    fillControlHH(StatusRowClickHH);
                }

            }
        }

        public void XoaHH()
        {
            try
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
                            StatusButtonHH = "";
                            loadDataHH();
                            resetFieldHangHoa();

                            if (gridViewDSHangHoa.DataRowCount > 0)
                            {
                                gridViewDSHangHoa.FocusedRowHandle = 0;
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void ThemHD()
        {
            try
            {
                if (btnThemHD.Text == "Thêm")
                {
                    setStatusFieldHH(true);
                    setStatusFieldHD(true);
                    resetFieldHoaDon();
                    resetFieldHangHoa();
                    setStatusButtonHD(false);
                    btnThemHD.Enabled = true;
                    btnSuaHD.Enabled = true;
                    txtHoaDon.Text = ClassController.getSoHD("NK");
                    txtSoHDNB.Text = ClassController.getSoHDNB("NK");
                    StatusButtonHD = "Them";
                    btnThemHD.Text = "Lưu";
                    btnSuaHD.Text = "Bỏ qua";
                    dateNgayHoaDon.DateTime = DateTime.Now;
                    btnThemHH.Text = "Lưu";
                    btnSuaHH.Text = "Bỏ qua";
                    StatusButtonHH = "Them";
                    btnSuaHH.Enabled = true;
                    btnThemHH.Enabled = true;
                    txtHoaDon.Focus();
                    dtHH.Clear();
                    loadDataHH();

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
                        HD_NHAPXUAT obj = new HD_NHAPXUAT();
                        obj.HDNX_LOAIHD = "NK";
                        obj.HDNX_SOHDNB = txtSoHDNB.Text.Trim();
                        obj.HDNX_NGAYLAP = DateTime.Now;
                        obj.HDNX_SOHD = txtHoaDon.Text.Trim();
                        obj.HDNX_NGAYHD = dateNgayHoaDon.DateTime;
                        obj.HDNX_SONGAYHD = Int32.Parse(dateNgayHoaDon.DateTime.Year + "" + dateNgayHoaDon.DateTime.Month + "" + dateNgayHoaDon.DateTime.Day);
                        obj.NPP_MANPP = txtNhaCungCapMa.Text.Trim();
                        obj.NV_MANV = txtNhanVienMa.Text.Trim();
                        obj.NV_TAIKHOAN = txtNhanVienTen.Text.Trim();
                        obj.HDTT_MATT = lkpDKThanhToan.EditValue.ToString();
                        obj.HDNX_GHICHU = txtGhiChu.Text.Trim();
                        obj.KH_MAKHO = txtNhapVaoKhoMa.Text.Trim();
                        obj.HDNX_TRANGTHAI = 1;


                        if (obj.HDNX_SOHD == "")
                        {
                            MessageBox.Show("Vui lòng nhập hóa đơn");
                            txtHoaDon.Focus();
                            return;
                        }

                        if (obj.NPP_MANPP == "" || txtNhaCungCapTen.Text.Trim() == "")
                        {
                            MessageBox.Show("Vui lòng chọn nhà phân phối");
                            txtNhaCungCapMa.Focus();
                            return;
                        }

                        DM_NHAPHANPHOI objNPP = new DM_NHAPHANPHOI();
                        objNPP = ClassController.layNPPTheoMa(obj.NPP_MANPP);
                        if(objNPP == null || objNPP.NPP_MANPP == "")
                        {
                            MessageBox.Show("Vui lòng chọn nhà phân phối");
                            txtNhaCungCapMa.Focus();
                            return;
                        }

                        if (obj.KH_MAKHO == "" || txtNhapVaoKhoTen.Text.Trim() == "")
                        {
                            MessageBox.Show("Vui lòng chọn kho nhập");
                            txtNhapVaoKhoMa.Focus();
                            return;
                        }

                        DM_KHOHANG objKH = new DM_KHOHANG();
                        objKH = ClassController.layKhoHangTheoMa(obj.KH_MAKHO);
                        if(objKH == null || objKH.KH_MAKHO == "")
                        {
                            MessageBox.Show("Vui lòng chọn kho nhập");
                            txtNhapVaoKhoMa.Focus();
                            return;
                        }

                        if (obj.NV_MANV == "" || txtNhanVienTen.Text.Trim() == "")
                        {
                            MessageBox.Show("Vui lòng chọn nhân viên");
                            txtNhanVienMa.Focus();
                            return;
                        }

                        DM_NHANVIEN objNV = new DM_NHANVIEN();
                        objNV = ClassController.layNhanVienTheoMa(obj.NV_MANV);
                        if(objNV == null || objNV.NV_MANV == "")
                        {
                            MessageBox.Show("Vui lòng chọn nhân viên");
                            txtNhanVienMa.Focus();
                            return;
                        }

                        if (dtHH.Rows.Count <= 0)
                        {
                            MessageBox.Show("Không có hàng hóa để nhập kho");
                            txtMaHang.Focus();
                            return;
                        }

                        for (int i = 0; i < dtHH.Rows.Count; i++)
                        {
                            obj.HH_MAHANG = dtHH.Rows[i]["HH_MAHANG"].ToString();
                            obj.HDNX_HANSUDUNG = ClassController.getHanSuDungHH(obj.HH_MAHANG);
                            obj.HDNX_SOLUONG = Double.Parse(dtHH.Rows[i]["HDNX_SOLUONG"].ToString());
                            obj.HDNX_GIAMUA = Decimal.Parse(dtHH.Rows[i]["HDNX_GIAMUA"].ToString());
                            obj.HDNX_QUIDOI = Int32.Parse(dtHH.Rows[i]["HDNX_QUIDOI"].ToString());
                            obj.HDNX_TONGMUA = Decimal.Parse(dtHH.Rows[i]["HDNX_TONGMUA"].ToString());
                            obj.HDNX_VAT = Double.Parse(dtHH.Rows[i]["HDNX_VAT"].ToString());
                            obj.HDNX_GIAVAT = Decimal.Parse(dtHH.Rows[i]["HDNX_GIAVAT"].ToString());
                            obj.HDNX_TONGVAT = Decimal.Parse(dtHH.Rows[i]["HDNX_TONGVAT"].ToString());
                            obj.HDNX_GIABAN = Decimal.Parse(dtHH.Rows[i]["HDNX_GIABAN"].ToString());
                            obj.HDNX_THANHTIEN = Decimal.Parse(dtHH.Rows[i]["HDNX_THANHTIEN"].ToString());
                            obj.HDNX_STT = i + 1;
                            ClassController.themHoaDonNhapKho(obj);
                        }
                        btnThemHD.Text = "Thêm";
                        btnSuaHD.Text = "Sửa";
                        StatusButtonHD = "";
                        setStatusButtonHD(true);
                        setStatusButtonHH(false);
                        setStatusFieldHH(false);
                        setStatusFieldHD(false);
                        loadDataHD();
                        resetFieldHangHoa();
                        resetFieldHoaDon();
                        dtHH.Clear();

                        if (gridViewDSHoaDon.DataRowCount > 1)
                        {
                            gridViewDSHoaDon.FocusedRowHandle = (gridViewDSHoaDon.DataRowCount - 1);
                            fillDataHHbySHDNB(gridViewDSHoaDon.GetRowCellValue((gridViewDSHoaDon.DataRowCount - 1), "HDNX_SOHDNB").ToString());
                        }
                    }
                    else if (StatusButtonHD == "Sua")
                    {
                        string HDNX_SOHDNB = txtSoHDNB.Text.Trim();
                        try
                        {
                            HD_NHAPXUAT objHDNX_OLD = new HD_NHAPXUAT();
                            objHDNX_OLD = ClassController.layThongTinHoaDonNhapKho(HDNX_SOHDNB);

                            HD_NHAPXUAT objHDNX_NEW = new HD_NHAPXUAT();
                            objHDNX_NEW.HDNX_LOAIHD = "NK";
                            objHDNX_NEW.HDNX_SOHDNB = txtSoHDNB.Text.Trim();
                            objHDNX_NEW.HDNX_NGAYLAP = objHDNX_OLD.HDNX_NGAYLAP;
                            objHDNX_NEW.HDNX_NGAYCAPNHAT = DateTime.Now;
                            objHDNX_NEW.HDNX_SOHD = txtHoaDon.Text.Trim();
                            objHDNX_NEW.HDNX_NGAYHD = dateNgayHoaDon.DateTime;
                            objHDNX_NEW.HDNX_SONGAYHD = Int32.Parse(dateNgayHoaDon.DateTime.Year + "" + dateNgayHoaDon.DateTime.Month + "" + dateNgayHoaDon.DateTime.Day);
                            objHDNX_NEW.NPP_MANPP = txtNhaCungCapMa.Text.Trim();
                            objHDNX_NEW.NV_MANV = txtNhanVienMa.Text.Trim();
                            objHDNX_NEW.NV_TAIKHOAN = txtNhanVienTen.Text.Trim();
                            objHDNX_NEW.HDTT_MATT = lkpDKThanhToan.EditValue.ToString();
                            objHDNX_NEW.HDNX_GHICHU = txtGhiChu.Text.Trim();
                            objHDNX_NEW.KH_MAKHO = txtNhapVaoKhoMa.Text.Trim();
                            objHDNX_NEW.HDNX_TRANGTHAI = 1;

                            if (objHDNX_NEW.HDNX_SOHD == "")
                            {
                                MessageBox.Show("Vui lòng nhập hóa đơn");
                                txtHoaDon.Focus();
                                return;
                            }

                            if (objHDNX_NEW.NPP_MANPP == "" || txtNhaCungCapTen.Text.Trim() == "")
                            {
                                MessageBox.Show("Vui lòng chọn nhà phân phối");
                                txtNhaCungCapMa.Focus();
                                return;
                            }

                            DM_NHAPHANPHOI objNPP = new DM_NHAPHANPHOI();
                            objNPP = ClassController.layNPPTheoMa(objHDNX_NEW.NPP_MANPP);
                            if (objNPP == null || objNPP.NPP_MANPP == "")
                            {
                                MessageBox.Show("Vui lòng chọn nhà phân phối");
                                txtNhaCungCapMa.Focus();
                                return;
                            }

                            if (objHDNX_NEW.KH_MAKHO == "" || txtNhapVaoKhoTen.Text.Trim() == "")
                            {
                                MessageBox.Show("Vui lòng chọn kho nhập");
                                txtNhapVaoKhoMa.Focus();
                                return;
                            }

                            DM_KHOHANG objKH = new DM_KHOHANG();
                            objKH = ClassController.layKhoHangTheoMa(objHDNX_NEW.KH_MAKHO);
                            if (objKH == null || objKH.KH_MAKHO == "")
                            {
                                MessageBox.Show("Vui lòng chọn kho nhập");
                                txtNhapVaoKhoMa.Focus();
                                return;
                            }

                            if (objHDNX_NEW.NV_MANV == "" || txtNhanVienTen.Text.Trim() == "")
                            {
                                MessageBox.Show("Vui lòng chọn nhân viên");
                                txtNhanVienMa.Focus();
                                return;
                            }

                            DM_NHANVIEN objNV = new DM_NHANVIEN();
                            objNV = ClassController.layNhanVienTheoMa(objHDNX_NEW.NV_MANV);
                            if (objNV == null || objNV.NV_MANV == "")
                            {
                                MessageBox.Show("Vui lòng chọn nhân viên");
                                txtNhanVienMa.Focus();
                                return;
                            }

                            if (dtHH.Rows.Count <= 0)
                            {
                                MessageBox.Show("Không có hàng hóa để nhập kho");
                                txtMaHang.Focus();
                                return;
                            }

                            using (SqlConnection connect = ClassController.ConnectDatabase())
                            {
                                connect.Open();
                                SqlCommand sqlCmd = new SqlCommand("UpdateHdNhapkho", connect);
                                sqlCmd.CommandTimeout = 1000;
                                sqlCmd.Parameters.AddWithValue("@HDNX_SOHDNB", HDNX_SOHDNB);
                                sqlCmd.CommandType = CommandType.StoredProcedure;
                                sqlCmd.ExecuteNonQuery();
                                connect.Close();
                            }

                            for (int i = 0; i < dtHH.Rows.Count; i++)
                            {
                                objHDNX_NEW.HH_MAHANG = dtHH.Rows[i]["HH_MAHANG"].ToString();
                                objHDNX_NEW.HDNX_SOLUONG = Double.Parse(dtHH.Rows[i]["HDNX_SOLUONG"].ToString());
                                objHDNX_NEW.HDNX_GIAMUA = Decimal.Parse(dtHH.Rows[i]["HDNX_GIAMUA"].ToString());
                                objHDNX_NEW.HDNX_QUIDOI = Int32.Parse(dtHH.Rows[i]["HDNX_QUIDOI"].ToString());
                                objHDNX_NEW.HDNX_TONGMUA = Decimal.Parse(dtHH.Rows[i]["HDNX_TONGMUA"].ToString());
                                objHDNX_NEW.HDNX_VAT = Double.Parse(dtHH.Rows[i]["HDNX_VAT"].ToString());
                                objHDNX_NEW.HDNX_GIAVAT = Decimal.Parse(dtHH.Rows[i]["HDNX_GIAVAT"].ToString());
                                objHDNX_NEW.HDNX_TONGVAT = Decimal.Parse(dtHH.Rows[i]["HDNX_TONGVAT"].ToString());
                                objHDNX_NEW.HDNX_GIABAN = Decimal.Parse(dtHH.Rows[i]["HDNX_GIABAN"].ToString());
                                objHDNX_NEW.HDNX_THANHTIEN = Decimal.Parse(dtHH.Rows[i]["HDNX_THANHTIEN"].ToString());
                                objHDNX_NEW.HDNX_STT = i + 1;
                                ClassController.capNhatHoaDonNhapKho(objHDNX_NEW);
                            }
                            btnThemHD.Text = "Thêm";
                            btnSuaHD.Text = "Sửa";
                            StatusButtonHD = "";
                            setStatusButtonHD(true);
                            setStatusButtonHH(false);
                            setStatusFieldHH(false);
                            setStatusFieldHD(false);
                            loadDataHD();
                            resetFieldHangHoa();
                            resetFieldHoaDon();
                            dtHH.Clear();

                            if (gridViewDSHoaDon.DataRowCount > 1 && StatusRowClickHD >= 0)
                            {
                                gridViewDSHoaDon.FocusedRowHandle = StatusRowClickHD;
                                fillDataHHbySHDNB(gridViewDSHoaDon.GetRowCellValue(StatusRowClickHD, "HDNX_SOHDNB").ToString());
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void SuaHD()
        {
            try
            {
                if (btnSuaHD.Text == "Sửa")
                {
                    if (txtSoHDNB.Text != "")
                    {
                        HT_KHOASO objKs = new HT_KHOASO();
                        objKs = ClassController.selectKhoaSoByDay(dateNgayHoaDon.DateTime.Date);
                        if (objKs.KS_KHOA == 1)
                        {
                            MessageBox.Show("Ngày này đã khóa sổ");
                            return;
                        }

                        setStatusFieldHH(false);
                        setStatusFieldHD(true);
                        setStatusButtonHD(true);
                        setStatusButtonHH(true);
                        btnXoaHH.Enabled = true;
                        btnExcelHD.Enabled = false;
                        resetFieldHangHoa();
                        StatusButtonHD = "Sua";
                        btnThemHD.Text = "Lưu";
                        btnSuaHD.Text = "Bỏ qua";
                        StatusButtonHH = "";
                        btnThemHH.Text = "Thêm";
                        btnSuaHH.Text = "Sửa";
                        if (gridViewDSHangHoa.DataRowCount > 0 && StatusRowClickHH >= 0)
                        {
                            gridViewDSHangHoa.FocusedRowHandle = StatusRowClickHH;
                            fillControlHH(StatusRowClickHH);
                        }else
                        {
                            gridViewDSHangHoa.FocusedRowHandle = 0;
                            fillControlHH(0);
                        }

                        txtHoaDon.Focus();
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
                    setStatusButtonHD(true);
                    setStatusButtonHH(false);
                    resetFieldHangHoa();
                    resetFieldHoaDon();
                    btnThemHD.Text = "Thêm";
                    btnSuaHD.Text = "Sửa";
                    StatusButtonHD = "";
                    dtHH.Clear();

                    if (gridViewDSHoaDon.DataRowCount > 0)
                    {
                        gridViewDSHoaDon.FocusedRowHandle = StatusRowClickHD;
                        fillDataHHbySHDNB(gridViewDSHoaDon.GetRowCellValue(StatusRowClickHD, "HDNX_SOHDNB").ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void XoaHD()
        {
            try
            {
                string HDNX_SOHDNB = txtSoHDNB.Text.Trim();
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
                                SqlCommand sqlCmd = new SqlCommand("DeleteHdNhapkho", connect);
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
                        resetFieldHangHoa();
                        resetFieldHoaDon();
                        dtHH.Clear();
                        loadDataHD();
                        if (gridViewDSHoaDon.DataRowCount > 0)
                        {
                            gridViewDSHoaDon.FocusedRowHandle = 0;
                            fillDataHHbySHDNB(gridViewDSHoaDon.GetRowCellValue(0, "HDNX_SOHDNB").ToString());
                        }
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cbxHienThi_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                gridCtrlDSHoaDon.DataSource = null;
                int vPeriod = Int32.Parse(cbxHienThi.EditValue.ToString());
                gridCtrlDSHoaDon.DataSource = ClassController.layDSHoaDonNhapKhoTheoKhoangThoiGian(vPeriod);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtNhaCungCapMa_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (StatusButtonHD != "")
                    {
                        if (txtNhaCungCapMa.Text.Trim() == "")
                        {
                            frmShowNhaPhanPhoi_NK frm = new frmShowNhaPhanPhoi_NK();
                            frm.ShowDialog(this);
                            txtNhaCungCapMa.Text = frm.dvtMa;
                            txtNhaCungCapTen.Text = frm.dvtTen;
                            txtNhaCungCapTen.Focus();
                        }
                        else
                        {
                            DM_NHAPHANPHOI objNPP = new DM_NHAPHANPHOI();
                            objNPP = ClassController.layNPPTheoMa(txtNhaCungCapMa.Text.Trim());
                            if(objNPP != null && objNPP.NPP_MANPP != "")
                            {
                                txtNhaCungCapMa.Text = objNPP.NPP_MANPP;
                                txtNhaCungCapTen.Text = objNPP.NPP_TENNPP;
                            }
                            else
                            {
                                frmShowNhaPhanPhoi_NK frm = new frmShowNhaPhanPhoi_NK();
                                frm.ShowDialog(this);
                                txtNhaCungCapMa.Text = frm.dvtMa;
                                txtNhaCungCapTen.Text = frm.dvtTen;
                                txtNhaCungCapTen.Focus();
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtNhapVaoKhoMa_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (StatusButtonHD != "")
                    {
                        if (txtNhapVaoKhoMa.Text.Trim() == "")
                        {
                            frmShowNhapKho frm = new frmShowNhapKho();
                            frm.ShowDialog(this);
                            txtNhapVaoKhoMa.Text = frm.dvtMa;
                            txtNhapVaoKhoTen.Text = frm.dvtTen;
                            txtNhapVaoKhoTen.Focus();
                        }
                        else
                        {
                            DM_KHOHANG objKH = new DM_KHOHANG();
                            objKH = ClassController.layKhoHangTheoMa(txtNhapVaoKhoMa.Text.Trim());
                            if(objKH != null && objKH.KH_MAKHO != "")
                            {
                                txtNhapVaoKhoMa.Text = objKH.KH_MAKHO;
                                txtNhapVaoKhoTen.Text = objKH.KH_TENKHO;
                            }
                            else
                            {
                                frmShowNhapKho frm = new frmShowNhapKho();
                                frm.ShowDialog(this);
                                txtNhapVaoKhoMa.Text = frm.dvtMa;
                                txtNhapVaoKhoTen.Text = frm.dvtTen;
                                txtNhapVaoKhoTen.Focus();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtMaHang_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (StatusButtonHD != "" && StatusButtonHH != "")
                    {
                        if (txtNhapVaoKhoTen.Text != "" || txtNhapVaoKhoMa.Text != "")
                        {
                            if (txtMaHang.Text.Trim() == "")
                            {
                                frmShowHangHoa frm = new frmShowHangHoa(txtNhapVaoKhoMa.Text.Trim());
                                frm.ShowDialog(this);
                                if (frm.pHhMa != null)
                                {
                                    txtMaHang.Text = frm.pHhMa;
                                    txtTenHang.Text = frm.pHhTen;
                                    txtDVT.Text = frm.pHhDVT;
                                    txtGiaNhap.Text = ((int)Double.Parse(frm.pHhGiaNhap)).ToString();
                                    txtGiaBan.Text = ((int)Double.Parse(frm.pHhGiaBan)).ToString();
                                }
                                else
                                {
                                    txtGhiChu.Focus();
                                }
                            }else
                            {
                                DMHH_HANGHOA objHH = new DMHH_HANGHOA();
                                objHH = ClassController.layHangHoaTheoMa(txtMaHang.Text.Trim());
                                if(objHH != null && objHH.HH_MAHANG != "")
                                {
                                    txtMaHang.Text = objHH.HH_MAHANG;
                                    txtTenHang.Text = objHH.HH_TENHANG;
                                    txtDVT.Text = ClassController.layDonViTinhTheoMa(objHH.DVT_MADONVI).DVT_TENDONVI;
                                    txtGiaNhap.Text = ((int) objHH.HH_GIAMUA).ToString();
                                    txtGiaBan.Text = ((int) objHH.HH_GIABANLE).ToString();
                                }
                                else
                                {
                                    frmShowHangHoa frm = new frmShowHangHoa(txtNhapVaoKhoMa.Text.Trim());
                                    frm.ShowDialog(this);
                                    if (frm.pHhMa != null)
                                    {
                                        txtMaHang.Text = frm.pHhMa;
                                        txtTenHang.Text = frm.pHhTen;
                                        txtDVT.Text = frm.pHhDVT;
                                        txtGiaNhap.Text = ((int)Double.Parse(frm.pHhGiaNhap)).ToString();
                                        txtGiaBan.Text = ((int)Double.Parse(frm.pHhGiaBan)).ToString();
                                    }
                                    else
                                    {
                                        txtGhiChu.Focus();
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng chọn kho nhập");
                            txtNhaCungCapTen.Focus();
                            return;
                        }
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtNhanVienMa_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (StatusButtonHD != "")
                    {
                        if (txtNhanVienMa.Text.Trim() == "")
                        {
                            frmShowNhanVien frm = new frmShowNhanVien();
                            frm.ShowDialog(this);
                            txtNhanVienMa.Text = frm.pKhMa;
                            txtNhanVienTen.Text = frm.pKhTen;
                            txtNhanVienTen.Focus();
                        }
                        else
                        {
                            DM_NHANVIEN objNV = new DM_NHANVIEN();
                            objNV = ClassController.layNhanVienTheoMa(txtNhanVienMa.Text.Trim());
                            if(objNV != null  && objNV.NV_MANV != "")
                            {
                                txtNhanVienMa.Text = objNV.NV_MANV;
                                txtNhanVienTen.Text = objNV.NV_TENNV;
                            }
                            else
                            {
                                frmShowNhanVien frm = new frmShowNhanVien();
                                frm.ShowDialog(this);
                                txtNhanVienMa.Text = frm.pKhMa;
                                txtNhanVienTen.Text = frm.pKhTen;
                                txtNhanVienTen.Focus();
                            }
                        }
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
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

        private void btnExcelHD_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSoHDNB.Text != "")
                {
                    List<HD_NHAPXUAT> objList = new List<HD_NHAPXUAT>();
                    objList = ClassController.layDSHoaDonNhapKhoTheoSHDNB(txtSoHDNB.Text);
                    if (objList.Count > 0)
                    {
                        if (dtReport == null)
                            InitializeDtReport();

                        dtReport.Clear();
                        int vSTT = 0;
                        decimal vTongHD = 0;
                        foreach (var item in objList)
                        {
                            vSTT += 1;
                            DMHH_HANGHOA objHH = new DMHH_HANGHOA();
                            objHH = ClassController.layHangHoaTheoMa(item.HH_MAHANG);
                            DMHH_DONVITINH objDVT = new DMHH_DONVITINH();
                            objDVT = ClassController.layDonViTinhTheoMa(objHH.DVT_MADONVI);

                            vTongHD += item.HDNX_THANHTIEN;
                            dtReport.Rows.Add(
                                item.HH_MAHANG,
                                objHH.HH_TENHANG,
                                objDVT.DVT_TENDONVI,
                                item.HDNX_GIAMUA,
                                item.HDNX_QUIDOI,
                                item.HDNX_GIABAN,
                                item.HDNX_VAT,
                                item.HDNX_GIAVAT,
                                item.HDNX_SOLUONG,
                                item.HDNX_THANHTIEN,
                                item.HDNX_TONGMUA,
                                item.HDNX_TONGVAT,
                                vSTT.ToString()
                            );
                        }
                        frmRptPhieuNhap frmRptPhieuNhap = new frmRptPhieuNhap(
                        dtReport,
                        "HÓA ĐƠN NHẬP KHO",
                        objList[0].HDNX_SOHDNB,
                        objList[0].HDNX_NGAYHD.ToShortDateString(),
                        objList[0].NPP_MANPP,
                        double.Parse(vTongHD.ToString()).ToString()
                        );
                        if (ExistFrom(frmRptPhieuNhap)) return;
                        frmRptPhieuNhap.Show();
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnDongHD_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridViewDSHangHoa_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                StatusRowClickHH = e.FocusedRowHandle;
                if (StatusButtonHH == "")
                {
                    if (gridViewDSHangHoa.GetRowCellValue(e.FocusedRowHandle, "ID") != null)
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

        private void gridViewDSHangHoa_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                StatusRowClickHH = e.RowHandle;
                if (StatusButtonHH == "")
                {
                    if (gridViewDSHangHoa.GetRowCellValue(e.RowHandle, "ID") != null)
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

        private void gridViewDSHoaDon_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                StatusRowClickHD = e.FocusedRowHandle;
                if (StatusButtonHD == "")
                {
                    if (gridViewDSHoaDon.GetRowCellValue(e.FocusedRowHandle, "HDNX_SOHDNB") != null)
                    {
                        fillDataHHbySHDNB(gridViewDSHoaDon.GetRowCellValue(e.FocusedRowHandle, "HDNX_SOHDNB").ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void gridViewDSHoaDon_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                StatusRowClickHD = e.RowHandle;
                if (StatusButtonHD == "")
                {
                    if (gridViewDSHoaDon.GetRowCellValue(e.RowHandle, "HDNX_SOHDNB") != null)
                    {
                        fillDataHHbySHDNB(gridViewDSHoaDon.GetRowCellValue(e.RowHandle, "HDNX_SOHDNB").ToString());
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F1))
            {
                if(btnThemHD.Enabled)
                ThemHD();
                return true;
            }

            if (keyData == (Keys.F2))
            {
                if(btnSuaHD.Enabled)
                SuaHD();
                return true;
            }

            if (keyData == (Keys.F3))
            {
                if(btnXoaHD.Enabled)
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
                if(btnThemHH.Enabled)
                ThemHH();
                return true;
            }

            if (keyData == (Keys.F6))
            {
                if(btnSuaHH.Enabled)
                SuaHH();
                return true;
            }

            if (keyData == (Keys.F7))
            {
                if(btnXoaHH.Enabled)
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
