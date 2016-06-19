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
using Excel = Microsoft.Office.Interop.Excel;

namespace QLK
{
    public partial class frmDMHangHoa : Form
    {
        protected string StatusButton = "";
        protected int StatusRowClick = 0;
        public static frmDMHangHoa _frmDMHangHoa;
        DataTable dtDVT = new DataTable();

        public frmDMHangHoa()
        {
            InitializeComponent();
            _frmDMHangHoa = this;
            loadData();
            lkuDonViTinh.Properties.DataSource = ClassController.layDSDonViTinh();
            cbxKieuSize.Properties.DataSource = ClassController.layDSKieuSize();
        }

        public void updateLoaiHang(string pLhMa, string pLhTen)
        {
            txtLoaiHangMa.Text = pLhMa;
            txtLoaiHangTen.Text = pLhTen;
        }

        public void updateNhomHang(string pNhMa, string pNhTen)
        {
            txtNhomHangMa.Text = pNhMa;
            txtNhomHangTen.Text = pNhTen;
        }

        public void updateQuocGia(string pQgMa, string pQgTen)
        {
            txtNuocSXMa.Text = pQgMa;
            txtNuocSanXuatTen.Text = pQgTen;
        }

        public void updateNhaPhanPhoi(string pNppMa, string pNppTen)
        {
            txtNPPMa.Text = pNppMa;
            txtNPPTen.Text = pNppTen;
        }

        public void loadData()
        {
            try
            {
                using (SqlConnection connect = ClassController.ConnectDatabase())
                {
                    dtDVT.Clear();
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectDmhhHanghoasAllRef", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlCmd;
                    da.Fill(dtDVT);
                    gridDVT.DataSource = dtDVT;
                    connect.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra (Mã lỗi: )");
                HT_NHATKY objNK = new HT_NHATKY();
                objNK.NK_MALOI = "100";
                objNK.NK_TENLOI = "Lỗi xử lý";
                objNK.NK_TACVU = "Lấy dữ liệu";
                objNK.NK_NOIDUNG = ex.ToString();
                objNK.NK_TENMAY = "";
                objNK.NK_THOIGIAN = DateTime.Now;
                objNK.NV_MANV = "";
                ClassController.insertLog(objNK);
            }
        }

        public void setStatusField(bool status)
        {
            txtGhiChu.Properties.ReadOnly = !status;
            txtGiaBanLe.Properties.ReadOnly = !status;
            txtGiaBanSi.Properties.ReadOnly = !status;
            txtGiaMua.Properties.ReadOnly = !status;
            txtSize.Properties.ReadOnly = !status;
            txtSize.Properties.ReadOnly = !status;
            txtLoaiHangMa.Properties.ReadOnly = !status;
            //txtLoaiHangTen.Properties.ReadOnly = status;
            //txtMaHang.Properties.ReadOnly = status;
            txtMauSac.Properties.ReadOnly = !status;
            txtNPPMa.Properties.ReadOnly = !status;
            //txtNPPTen.Properties.ReadOnly = status;
            //txtNuocSanXuatTen.Properties.ReadOnly = status;
            txtNuocSXMa.Properties.ReadOnly = !status;
            txtNhomHangMa.Properties.ReadOnly = !status;
            //txtNhomHangTen.Properties.ReadOnly = status;
            txtTenHang.Properties.ReadOnly = !status;
            txtTenNgan.Properties.ReadOnly = !status;
            txtTonToiThieu.Properties.ReadOnly = !status;
            txtThanhPhan.Properties.ReadOnly = !status;
            txtKhuyenMai.Properties.ReadOnly = !status;
            lkuDonViTinh.Properties.ReadOnly = !status;
            cbxKieuSize.Properties.ReadOnly = !status;
            dateKMTuNgay.Properties.ReadOnly = !status;
            dateKMDenNgay.Properties.ReadOnly = !status;
            dateHanSuDung.Properties.ReadOnly = !status;
            chkQuanLy.Properties.ReadOnly = !status;
            spinEditHSD.Properties.ReadOnly = !status;
        }

        public void setEmptyField()
        {
            txtGhiChu.Text = "";
            txtGiaBanLe.Text = "";
            txtGiaBanSi.Text = "";
            txtGiaMua.Text = "";
            txtSize.Text = "";
            txtSize.Text = "";
            txtLoaiHangMa.Text = "";
            txtLoaiHangTen.Text = "";
            txtMaHang.Text = "";
            txtMauSac.Text = "";
            txtNPPMa.Text = "";
            txtNPPTen.Text = "";
            txtNuocSanXuatTen.Text = "";
            txtNuocSXMa.Text = "";
            txtNhomHangMa.Text = "";
            txtNhomHangTen.Text = "";
            txtTenHang.Text = "";
            txtTenNgan.Text = "";
            txtTonToiThieu.Text = "";
            txtThanhPhan.Text = "";
            txtKhuyenMai.Text = "";
            dateHanSuDung.Text = "";
            dateKMDenNgay.Text = "";
            dateKMTuNgay.Text = "";
            //lkuDonViTinh.ResetText();
            //cbxKieuSize.ResetText();
        }

        public void setStatusButton(bool status)
        {
            btnXoa.Enabled = status;
            btnExcel.Enabled = status;
            btnDong.Enabled = status;
        }

        public void fillControl(int pRow)
        {
            if (gridView1.GetRowCellValue(pRow, "HH_MAHANG") != null)
            {
                txtGhiChu.Text = gridView1.GetRowCellValue(pRow, "HH_GHICHU").ToString();
                txtGiaBanLe.Text = ((int)double.Parse(gridView1.GetRowCellValue(pRow, "HH_GIABANLE").ToString())).ToString();
                txtGiaBanSi.Text = ((int)double.Parse(gridView1.GetRowCellValue(pRow, "HH_GIABANSI").ToString())).ToString();
                txtGiaMua.Text = ((int)double.Parse(gridView1.GetRowCellValue(pRow, "HH_GIAMUA").ToString())).ToString();
                txtSize.Text = gridView1.GetRowCellValue(pRow, "HH_SIZE").ToString();
                txtLoaiHangMa.Text = gridView1.GetRowCellValue(pRow, "LH_MALOAI").ToString();
                txtLoaiHangTen.Text = gridView1.GetRowCellValue(pRow, "LH_TENLOAI").ToString();
                txtMaHang.Text = gridView1.GetRowCellValue(pRow, "HH_MAHANG").ToString();
                txtMauSac.Text = gridView1.GetRowCellValue(pRow, "HH_MAUSAC").ToString();
                txtNPPMa.Text = gridView1.GetRowCellValue(pRow, "NPP_MANPP").ToString();
                txtNPPTen.Text = gridView1.GetRowCellValue(pRow, "NPP_TENNPP").ToString();
                txtNuocSanXuatTen.Text = gridView1.GetRowCellValue(pRow, "QG_TENQUOCGIA").ToString();
                txtNuocSXMa.Text = gridView1.GetRowCellValue(pRow, "QG_MAQUOCGIA").ToString();
                txtNhomHangMa.Text = gridView1.GetRowCellValue(pRow, "NH_MANHOM").ToString();
                txtNhomHangTen.Text = gridView1.GetRowCellValue(pRow, "NH_TENNHOM").ToString();
                txtTenHang.Text = gridView1.GetRowCellValue(pRow, "HH_TENHANG").ToString();
                txtTenNgan.Text = gridView1.GetRowCellValue(pRow, "HH_TENNGAN").ToString();
                txtTonToiThieu.Text = gridView1.GetRowCellValue(pRow, "HH_TONTOITHIEU").ToString();
                txtThanhPhan.Text = gridView1.GetRowCellValue(pRow, "HH_THANHPHAN").ToString();
                txtKhuyenMai.Text = gridView1.GetRowCellValue(pRow, "HH_KHUYENMAI").ToString();
                lkuDonViTinh.EditValue = gridView1.GetRowCellValue(pRow, "DVT_MADONVI").ToString();
                cbxKieuSize.EditValue = Int32.Parse(gridView1.GetRowCellValue(pRow, "HH_LOAISIZE").ToString());

                if (gridView1.GetRowCellValue(pRow, "HH_HANSUDUNG").ToString() != "")
                {
                    dateHanSuDung.DateTime = DateTime.Parse(gridView1.GetRowCellValue(pRow, "HH_HANSUDUNG").ToString());
                }
                else
                {
                    dateHanSuDung.Text = "";
                }

                if (gridView1.GetRowCellValue(pRow, "HH_KMDENNGAY").ToString() != "")
                {
                    dateKMDenNgay.DateTime = DateTime.Parse(gridView1.GetRowCellValue(pRow, "HH_KMDENNGAY").ToString());
                }
                else
                {
                    dateKMDenNgay.Text = "";
                }

                if (gridView1.GetRowCellValue(pRow, "HH_KMTUNGAY").ToString() != "")
                {
                    dateKMTuNgay.DateTime = DateTime.Parse(gridView1.GetRowCellValue(pRow, "HH_KMTUNGAY").ToString());
                }
                else
                {
                    dateKMTuNgay.Text = "";
                }


                if (gridView1.GetRowCellValue(pRow, "HH_KICHHOAT").ToString() == "0")
                {
                    chkQuanLy.Checked = false;
                }
                else
                {
                    chkQuanLy.Checked = true;
                }
                spinEditHSD.Value = gridView1.GetRowCellValue(pRow, "HH_HSD").ToString() != "" ? int.Parse(gridView1.GetRowCellValue(pRow, "HH_HSD").ToString()) : 0;
            }
        }

        public void excelExport(string filepath)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            Excel.Range chartRange;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            xlWorkSheet.get_Range("b2", "o3").Merge(false);

            chartRange = xlWorkSheet.get_Range("b2", "o3");
            chartRange.FormulaR1C1 = "DANH SÁCH HÀNG HÓA";
            chartRange.HorizontalAlignment = 3;
            chartRange.VerticalAlignment = 3;
            chartRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
            chartRange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
            chartRange.Font.Size = 20;

            chartRange = xlWorkSheet.get_Range("b4", "o4");
            chartRange.Font.Bold = true;

            /*
            chartRange = xlWorkSheet.get_Range("b2", "f9");
            chartRange.BorderAround(
                Excel.XlLineStyle.xlContinuous,
                Excel.XlBorderWeight.xlThin,
                Excel.XlColorIndex.xlColorIndexAutomatic,
                Excel.XlColorIndex.xlColorIndexAutomatic);
            */

            xlWorkSheet.Cells[4, 2] = "STT";
            xlWorkSheet.Cells[4, 3] = "Mã hàng";
            xlWorkSheet.Cells[4, 4] = "Tên hàng";
            xlWorkSheet.Cells[4, 5] = "Đơn vị tính";
            xlWorkSheet.Cells[4, 6] = "Loại hàng";
            xlWorkSheet.Cells[4, 7] = "Nhóm hàng";
            xlWorkSheet.Cells[4, 8] = "Nước sản xuất";
            xlWorkSheet.Cells[4, 9] = "Nhà phân phối";
            xlWorkSheet.Cells[4, 10] = "Giá mua";
            xlWorkSheet.Cells[4, 11] = "Giá bán sỉ";
            xlWorkSheet.Cells[4, 12] = "Giá bán lẻ";
            xlWorkSheet.Cells[4, 13] = "Khuyến mãi (%)";
            xlWorkSheet.Cells[4, 14] = "Ghi chú";
            xlWorkSheet.Cells[4, 15] = "Quản lý";


            xlWorkSheet.Columns[2].ColumnWidth = 14;
            xlWorkSheet.Columns[3].ColumnWidth = 14;
            xlWorkSheet.Columns[4].ColumnWidth = 14;
            xlWorkSheet.Columns[5].ColumnWidth = 14;
            xlWorkSheet.Columns[6].ColumnWidth = 14;
            xlWorkSheet.Columns[7].ColumnWidth = 14;
            xlWorkSheet.Columns[8].ColumnWidth = 14;
            xlWorkSheet.Columns[9].ColumnWidth = 14;
            xlWorkSheet.Columns[10].ColumnWidth = 14;
            xlWorkSheet.Columns[11].ColumnWidth = 14;
            xlWorkSheet.Columns[12].ColumnWidth = 14;
            xlWorkSheet.Columns[13].ColumnWidth = 14;
            xlWorkSheet.Columns[14].ColumnWidth = 14;
            xlWorkSheet.Columns[15].ColumnWidth = 14;

            for (int i = 5; i < (dtDVT.Rows.Count + 5); i++)
            {
                xlWorkSheet.Cells[i, 2] = (i - 4).ToString();
                xlWorkSheet.Cells[i, 3] = dtDVT.Rows[i - 5]["HH_MAHANG"].ToString();
                xlWorkSheet.Cells[i, 4] = dtDVT.Rows[i - 5]["HH_TENHANG"].ToString();
                xlWorkSheet.Cells[i, 5] = dtDVT.Rows[i - 5]["DVT_TENDONVI"].ToString();
                xlWorkSheet.Cells[i, 6] = dtDVT.Rows[i - 5]["LH_TENLOAI"].ToString();
                xlWorkSheet.Cells[i, 7] = dtDVT.Rows[i - 5]["NH_TENNHOM"].ToString();
                xlWorkSheet.Cells[i, 8] = dtDVT.Rows[i - 5]["QG_TENQUOCGIA"].ToString();
                xlWorkSheet.Cells[i, 9] = dtDVT.Rows[i - 5]["NPP_TENNPP"].ToString();
                xlWorkSheet.Cells[i, 10] = double.Parse(dtDVT.Rows[i - 5]["HH_GIAMUA"].ToString()).ToString();
                xlWorkSheet.Cells[i, 11] = double.Parse(dtDVT.Rows[i - 5]["HH_GIABANSI"].ToString()).ToString();
                xlWorkSheet.Cells[i, 12] = double.Parse(dtDVT.Rows[i - 5]["HH_GIABANLE"].ToString()).ToString();
                xlWorkSheet.Cells[i, 13] = dtDVT.Rows[i - 5]["HH_KHUYENMAI"].ToString();
                xlWorkSheet.Cells[i, 14] = dtDVT.Rows[i - 5]["HH_GHICHU"].ToString();
                xlWorkSheet.Cells[i, 15] = dtDVT.Rows[i - 5]["HH_KICHHOAT"].ToString() == "1" ? "Còn quản lý" : "Không";
            }



            xlWorkBook.SaveAs(filepath,
                Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue,
                Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlApp);
            releaseObject(xlWorkBook);
            releaseObject(xlWorkSheet);
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        } 

        public void Them()
        {
            if (btnThem.Text == "Thêm")
            {
                setStatusField(true);
                setEmptyField();
                setStatusButton(false);
                chkQuanLy.Checked = true;
                StatusButton = "Them";
                btnThem.Text = "Lưu";
                btnSua.Text = "Bỏ qua";
                txtMaHang.Text = ClassController.getMaDanhMuc("HH_MAHANG");
                txtTenHang.Focus();

            }
            else if (btnThem.Text == "Lưu")
            {
                if (StatusButton == "Them")
                {
                    DMHH_HANGHOA objHH = new DMHH_HANGHOA();
                    objHH.HH_GHICHU = txtGhiChu.Text.Trim();
                    objHH.HH_GIABANLE = txtGiaBanLe.Text.Trim() != "" ? Decimal.Parse(txtGiaBanLe.Text.Trim()) : 0;
                    objHH.HH_GIABANSI = txtGiaBanSi.Text.Trim() != "" ? Decimal.Parse(txtGiaBanSi.Text.Trim()) : 0;
                    objHH.HH_GIAMUA = txtGiaMua.Text.Trim() != "" ? Decimal.Parse(txtGiaMua.Text.Trim()) : 0;
                    objHH.HH_HANSUDUNG = dateHanSuDung.DateTime.Date;
                    objHH.HH_KICHHOAT = chkQuanLy.Checked ? 1 : 0;
                    objHH.HH_KMDENNGAY = dateKMDenNgay.DateTime.Date;
                    objHH.HH_KMTUNGAY = dateKMTuNgay.DateTime.Date;
                    objHH.HH_KHUYENMAI = txtKhuyenMai.Text.Trim() != "" ? Double.Parse(txtKhuyenMai.Text.Trim()) : 0;
                    objHH.HH_LOAISIZE = cbxKieuSize.EditValue == null ? -1 : Int32.Parse(cbxKieuSize.EditValue.ToString());
                    objHH.HH_MAHANG = txtMaHang.Text.Trim();
                    objHH.HH_MAUSAC = txtMauSac.Text.Trim();
                    objHH.HH_SIZE = txtSize.Text.Trim();
                    objHH.HH_TENNGAN = txtTenNgan.Text.Trim();
                    objHH.HH_TENHANG = txtTenHang.Text.Trim();
                    objHH.HH_TONTOITHIEU = txtTonToiThieu.Text.Trim() != "" ? Double.Parse(txtTonToiThieu.Text.Trim()) : 0;
                    objHH.HH_THANHPHAN = txtThanhPhan.Text.Trim();
                    //objHH.KH_MAKHO = "KHO000001";
                    objHH.LH_MALOAI = txtLoaiHangMa.Text.Trim();
                    objHH.NPP_MANPP = txtNPPMa.Text.Trim();
                    objHH.NH_MANHOM = txtNhomHangMa.Text.Trim();
                    objHH.QG_MAQUOCGIA = txtNuocSXMa.Text.Trim();
                    objHH.DVT_MADONVI = lkuDonViTinh.EditValue == null ? "" : lkuDonViTinh.EditValue.ToString();
                    objHH.HH_HSD = (int) spinEditHSD.Value;

                    if (objHH.HH_TENHANG == "")
                    {
                        MessageBox.Show("Tên hàng hóa không được rỗng");
                        txtTenHang.Focus();
                        return;
                    }

                    if (objHH.LH_MALOAI == "")
                    {
                        MessageBox.Show("Loại hàng hóa không được rỗng");
                        txtLoaiHangMa.Focus();
                        return;
                    }

                    if (objHH.NH_MANHOM == "")
                    {
                        MessageBox.Show("Nhóm hàng hóa không được rỗng");
                        txtNhomHangMa.Focus();
                        return;
                    }

                    if (objHH.DVT_MADONVI == "")
                    {
                        MessageBox.Show("Đơn vị tính không được rỗng");
                        lkuDonViTinh.Focus();
                        return;
                    }

                    if (objHH.QG_MAQUOCGIA == "")
                    {
                        MessageBox.Show("Nước sản xuất không được rỗng");
                        txtNuocSXMa.Focus();
                        return;
                    }

                    if (objHH.NPP_MANPP == "")
                    {
                        MessageBox.Show("Nhà phân phối không được rỗng");
                        txtNPPMa.Focus();
                        return;
                    }

                    try
                    {
                        using (SqlConnection connect = ClassController.ConnectDatabase())
                        {
                            connect.Open();
                            SqlCommand sqlCmd = new SqlCommand("InsertDmhhHanghoa", connect);
                            sqlCmd.CommandTimeout = 1000;
                            sqlCmd.Parameters.AddWithValue("@HH_MAHANG", objHH.HH_MAHANG);
                            sqlCmd.Parameters.AddWithValue("@HH_TENHANG", objHH.HH_TENHANG);
                            sqlCmd.Parameters.AddWithValue("@HH_TENNGAN", objHH.HH_TENNGAN);
                            sqlCmd.Parameters.AddWithValue("@HH_THANHPHAN", objHH.HH_THANHPHAN);
                            sqlCmd.Parameters.AddWithValue("@HH_LOAISIZE", objHH.HH_LOAISIZE);
                            sqlCmd.Parameters.AddWithValue("@HH_SIZE", objHH.HH_SIZE);
                            sqlCmd.Parameters.AddWithValue("@HH_MAUSAC", objHH.HH_MAUSAC);
                            sqlCmd.Parameters.AddWithValue("@HH_GIAMUA", objHH.HH_GIAMUA);
                            sqlCmd.Parameters.AddWithValue("@HH_GIABANLE", objHH.HH_GIABANLE);
                            sqlCmd.Parameters.AddWithValue("@HH_GIABANSI", objHH.HH_GIABANSI);
                            sqlCmd.Parameters.AddWithValue("@HH_TONTOITHIEU", objHH.HH_TONTOITHIEU);
                            sqlCmd.Parameters.AddWithValue("@HH_KHUYENMAI", objHH.HH_KHUYENMAI);

                            if (objHH.HH_KMTUNGAY.Year == 1)
                            { sqlCmd.Parameters.AddWithValue("@HH_KMTUNGAY", DBNull.Value); }
                            else { sqlCmd.Parameters.AddWithValue("@HH_KMTUNGAY", objHH.HH_KMTUNGAY); }

                            if (objHH.HH_KMDENNGAY.Year == 1)
                            { sqlCmd.Parameters.AddWithValue("@HH_KMDENNGAY", DBNull.Value); }
                            else { sqlCmd.Parameters.AddWithValue("@HH_KMDENNGAY", objHH.HH_KMDENNGAY); }

                            if (objHH.HH_HANSUDUNG.Year == 1)
                            { sqlCmd.Parameters.AddWithValue("@HH_HANSUDUNG", DBNull.Value); }
                            else { sqlCmd.Parameters.AddWithValue("@HH_HANSUDUNG", objHH.HH_HANSUDUNG); }

                            sqlCmd.Parameters.AddWithValue("@HH_GHICHU", objHH.HH_GHICHU);
                            sqlCmd.Parameters.AddWithValue("@HH_KICHHOAT", objHH.HH_KICHHOAT);
                            sqlCmd.Parameters.AddWithValue("@DVT_MADONVI", objHH.DVT_MADONVI);
                            sqlCmd.Parameters.AddWithValue("@NH_MANHOM", objHH.NH_MANHOM);
                            sqlCmd.Parameters.AddWithValue("@LH_MALOAI", objHH.LH_MALOAI);
                            sqlCmd.Parameters.AddWithValue("@QG_MAQUOCGIA", objHH.QG_MAQUOCGIA);
                            //sqlCmd.Parameters.AddWithValue("@KH_MAKHO", objHH.KH_MAKHO);
                            sqlCmd.Parameters.AddWithValue("@NPP_MANPP", objHH.NPP_MANPP);
                            sqlCmd.Parameters.AddWithValue("@HH_HSD", objHH.HH_HSD);
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.ExecuteNonQuery();
                        }
                        setEmptyField();
                        setStatusButton(true);
                        setStatusField(false);
                        btnThem.Text = "Thêm";
                        btnSua.Text = "Sửa";
                        loadData();
                        if (gridView1.RowCount > 0)
                        {
                            StatusRowClick = gridView1.RowCount - 1;
                            gridView1.FocusedRowHandle = StatusRowClick;
                            if (StatusRowClick >= 0)
                                fillControl(StatusRowClick);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã có lỗi xảy ra (Mã lỗi: )");
                        HT_NHATKY objNK = new HT_NHATKY();
                        objNK.NK_MALOI = "100";
                        objNK.NK_TENLOI = "Lỗi xử lý";
                        objNK.NK_TACVU = "Lấy dữ liệu";
                        objNK.NK_NOIDUNG = ex.ToString();
                        objNK.NK_TENMAY = "";
                        objNK.NK_THOIGIAN = DateTime.Now;
                        objNK.NV_MANV = "";
                        ClassController.insertLog(objNK);
                    }
                }
                else if (StatusButton == "Sua")
                {
                    DMHH_HANGHOA objHH = new DMHH_HANGHOA();
                    objHH.HH_GHICHU = txtGhiChu.Text.Trim();
                    objHH.HH_GIABANLE = txtGiaBanLe.Text.Trim() != "" ? Decimal.Parse(txtGiaBanLe.Text.Trim()) : 0;
                    objHH.HH_GIABANSI = txtGiaBanSi.Text.Trim() != "" ? Decimal.Parse(txtGiaBanSi.Text.Trim()) : 0;
                    objHH.HH_GIAMUA = txtGiaMua.Text.Trim() != "" ? Decimal.Parse(txtGiaMua.Text.Trim()) : 0;
                    objHH.HH_HANSUDUNG = dateHanSuDung.DateTime.Date;
                    objHH.HH_KICHHOAT = chkQuanLy.Checked ? 1 : 0;
                    objHH.HH_KMDENNGAY = dateKMDenNgay.DateTime.Date;
                    objHH.HH_KMTUNGAY = dateKMTuNgay.DateTime.Date;
                    objHH.HH_KHUYENMAI = txtKhuyenMai.Text.Trim() != "" ? Double.Parse(txtKhuyenMai.Text.Trim()) : 0;
                    objHH.HH_LOAISIZE = cbxKieuSize.EditValue == null ? -1 : Int32.Parse(cbxKieuSize.EditValue.ToString());
                    objHH.HH_MAHANG = txtMaHang.Text.Trim();
                    objHH.HH_MAUSAC = txtMauSac.Text.Trim();
                    objHH.HH_SIZE = txtSize.Text.Trim();
                    objHH.HH_TENNGAN = txtTenNgan.Text.Trim();
                    objHH.HH_TENHANG = txtTenHang.Text.Trim();
                    objHH.HH_TONTOITHIEU = txtTonToiThieu.Text.Trim() != "" ? Double.Parse(txtTonToiThieu.Text.Trim()) : 0;
                    objHH.HH_THANHPHAN = txtThanhPhan.Text.Trim();
                    //objHH.KH_MAKHO = "KHO000001";
                    objHH.LH_MALOAI = txtLoaiHangMa.Text.Trim();
                    objHH.NPP_MANPP = txtNPPMa.Text.Trim();
                    objHH.NH_MANHOM = txtNhomHangMa.Text.Trim();
                    objHH.QG_MAQUOCGIA = txtNuocSXMa.Text.Trim();
                    objHH.DVT_MADONVI = lkuDonViTinh.EditValue == null ? "" : lkuDonViTinh.EditValue.ToString();
                    objHH.HH_HSD = (int)spinEditHSD.Value;

                    if (objHH.HH_TENHANG == "")
                    {
                        MessageBox.Show("Tên hàng hóa không được rỗng");
                        txtTenHang.Focus();
                        return;
                    }

                    if (objHH.LH_MALOAI == "")
                    {
                        MessageBox.Show("Loại hàng hóa không được rỗng");
                        txtLoaiHangMa.Focus();
                        return;
                    }

                    if (objHH.NH_MANHOM == "")
                    {
                        MessageBox.Show("Nhóm hàng hóa không được rỗng");
                        txtNhomHangMa.Focus();
                        return;
                    }

                    if (objHH.DVT_MADONVI == "")
                    {
                        MessageBox.Show("Đơn vị tính không được rỗng");
                        lkuDonViTinh.Focus();
                        return;
                    }

                    if (objHH.QG_MAQUOCGIA == "")
                    {
                        MessageBox.Show("Nước sản xuất không được rỗng");
                        txtNuocSXMa.Focus();
                        return;
                    }

                    if (objHH.NPP_MANPP == "")
                    {
                        MessageBox.Show("Nhà phân phối không được rỗng");
                        txtNPPMa.Focus();
                        return;
                    }

                    try
                    {
                        using (SqlConnection connect = ClassController.ConnectDatabase())
                        {
                            connect.Open();
                            SqlCommand sqlCmd = new SqlCommand("UpdateDmhhHanghoa", connect);
                            sqlCmd.CommandTimeout = 1000;
                            sqlCmd.Parameters.AddWithValue("@HH_MAHANG", objHH.HH_MAHANG);
                            sqlCmd.Parameters.AddWithValue("@HH_TENHANG", objHH.HH_TENHANG);
                            sqlCmd.Parameters.AddWithValue("@HH_TENNGAN", objHH.HH_TENNGAN);
                            sqlCmd.Parameters.AddWithValue("@HH_THANHPHAN", objHH.HH_THANHPHAN);
                            sqlCmd.Parameters.AddWithValue("@HH_LOAISIZE", objHH.HH_LOAISIZE);
                            sqlCmd.Parameters.AddWithValue("@HH_SIZE", objHH.HH_SIZE);
                            sqlCmd.Parameters.AddWithValue("@HH_MAUSAC", objHH.HH_MAUSAC);
                            sqlCmd.Parameters.AddWithValue("@HH_GIAMUA", objHH.HH_GIAMUA);
                            sqlCmd.Parameters.AddWithValue("@HH_GIABANLE", objHH.HH_GIABANLE);
                            sqlCmd.Parameters.AddWithValue("@HH_GIABANSI", objHH.HH_GIABANSI);
                            sqlCmd.Parameters.AddWithValue("@HH_TONTOITHIEU", objHH.HH_TONTOITHIEU);
                            sqlCmd.Parameters.AddWithValue("@HH_KHUYENMAI", objHH.HH_KHUYENMAI);

                            if (objHH.HH_KMTUNGAY.Year == 1)
                            { sqlCmd.Parameters.AddWithValue("@HH_KMTUNGAY", DBNull.Value); }
                            else { sqlCmd.Parameters.AddWithValue("@HH_KMTUNGAY", objHH.HH_KMTUNGAY); }

                            if (objHH.HH_KMDENNGAY.Year == 1)
                            { sqlCmd.Parameters.AddWithValue("@HH_KMDENNGAY", DBNull.Value); }
                            else { sqlCmd.Parameters.AddWithValue("@HH_KMDENNGAY", objHH.HH_KMDENNGAY); }

                            if (objHH.HH_HANSUDUNG.Year == 1)
                            { sqlCmd.Parameters.AddWithValue("@HH_HANSUDUNG", DBNull.Value); }
                            else { sqlCmd.Parameters.AddWithValue("@HH_HANSUDUNG", objHH.HH_HANSUDUNG); }

                            sqlCmd.Parameters.AddWithValue("@HH_GHICHU", objHH.HH_GHICHU);
                            sqlCmd.Parameters.AddWithValue("@HH_KICHHOAT", objHH.HH_KICHHOAT);
                            sqlCmd.Parameters.AddWithValue("@DVT_MADONVI", objHH.DVT_MADONVI);
                            sqlCmd.Parameters.AddWithValue("@NH_MANHOM", objHH.NH_MANHOM);
                            sqlCmd.Parameters.AddWithValue("@LH_MALOAI", objHH.LH_MALOAI);
                            sqlCmd.Parameters.AddWithValue("@QG_MAQUOCGIA", objHH.QG_MAQUOCGIA);
                            //sqlCmd.Parameters.AddWithValue("@KH_MAKHO", objHH.KH_MAKHO);
                            sqlCmd.Parameters.AddWithValue("@NPP_MANPP", objHH.NPP_MANPP);
                            sqlCmd.Parameters.AddWithValue("@HH_HSD", objHH.HH_HSD);
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.ExecuteNonQuery();
                        }
                        setEmptyField();
                        setStatusButton(true);
                        setStatusField(false);
                        btnThem.Text = "Thêm";
                        btnSua.Text = "Sửa";
                        loadData();
                        if (gridView1.RowCount > 0)
                        {
                            if (StatusRowClick >= 0)
                            {
                                gridView1.FocusedRowHandle = StatusRowClick;
                                fillControl(StatusRowClick);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã có lỗi xảy ra (Mã lỗi: )");
                        HT_NHATKY objNK = new HT_NHATKY();
                        objNK.NK_MALOI = "100";
                        objNK.NK_TENLOI = "Lỗi xử lý";
                        objNK.NK_TACVU = "Lấy dữ liệu";
                        objNK.NK_NOIDUNG = ex.ToString();
                        objNK.NK_TENMAY = "";
                        objNK.NK_THOIGIAN = DateTime.Now;
                        objNK.NV_MANV = "";
                        ClassController.insertLog(objNK);
                    }
                }
                StatusButton = "";
            }
        }

        public void Sua()
        {
            if (btnSua.Text == "Sửa")
            {
                if (txtMaHang.Text != "")
                {
                    setStatusField(true);
                    setStatusButton(false);
                    StatusButton = "Sua";
                    btnThem.Text = "Lưu";
                    btnSua.Text = "Bỏ qua";
                    txtTenHang.Focus();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn hàng hóa");
                }
            }
            else if (btnSua.Text == "Bỏ qua")
            {
                setStatusField(false);
                setStatusButton(true);
                btnThem.Text = "Thêm";
                btnSua.Text = "Sửa";
                StatusButton = "";
                if (gridView1.RowCount > 0)
                {
                    if (StatusRowClick >= 0)
                    {
                        gridView1.FocusedRowHandle = StatusRowClick;
                        fillControl(StatusRowClick);
                    }
                }
            }
        }

        public void Xoa()
        {
            string HH_MAHANG = txtMaHang.Text.Trim();
            if (HH_MAHANG != "")
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có muốn xóa?", "Cảnh báo", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    try
                    {
                        if (!ClassController.kiemTraHangHoaDuocSuSung(HH_MAHANG))
                        {
                            using (SqlConnection connect = ClassController.ConnectDatabase())
                            {
                                connect.Open();
                                SqlCommand sqlCmd = new SqlCommand("DeleteDmhhHanghoa", connect);
                                sqlCmd.CommandTimeout = 1000;
                                sqlCmd.Parameters.AddWithValue("@HH_MAHANG", HH_MAHANG);
                                sqlCmd.CommandType = CommandType.StoredProcedure;
                                sqlCmd.ExecuteNonQuery();
                                connect.Close();

                                setStatusField(false);
                                setEmptyField();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Hàng hóa đã sử dụng");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    loadData();
                    if (gridView1.RowCount > 0)
                    {
                        StatusRowClick = gridView1.RowCount - 1;
                        gridView1.FocusedRowHandle = StatusRowClick;
                        if (StatusRowClick >= 0)
                            fillControl(StatusRowClick);
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            Them();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Sua();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Xoa();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (gridView1.DataRowCount < 1)
            {
                MessageBox.Show("Không có dữ liệu để xuất");
                return;
            }
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                //saveDialog.Filter = "Excel (2003)(.xls)|*.xls|Excel (2010) (.xlsx)|*.xlsx";
                saveDialog.Filter = "Excel (2003)(.xls)|*.xls";
                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    string exportFilePath = saveDialog.FileName;
                    string fileExtenstion = new FileInfo(exportFilePath).Extension;

                    excelExport(exportFilePath);

                    if (File.Exists(exportFilePath))
                    {
                        try
                        {
                            System.Diagnostics.Process.Start(exportFilePath);
                        }
                        catch
                        {
                            String msg = "Không thể mở tập tin." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                            MessageBox.Show(msg, "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        String msg = "Không thể lưu tập tin." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                        MessageBox.Show(msg, "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNhapExcel_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (StatusButton == "")
                {
                    StatusRowClick = e.FocusedRowHandle;
                    fillControl(e.FocusedRowHandle);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra (Mã lỗi: )");
                HT_NHATKY objNK = new HT_NHATKY();
                objNK.NK_MALOI = "100";
                objNK.NK_TENLOI = "Lỗi giao diện";
                objNK.NK_TACVU = "Lấy dữ liệu";
                objNK.NK_NOIDUNG = ex.ToString();
                objNK.NK_TENMAY = "";
                objNK.NK_THOIGIAN = DateTime.Now;
                objNK.NV_MANV = "";
                ClassController.insertLog(objNK);
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (StatusButton == "")
                {
                    StatusRowClick = e.RowHandle;
                    fillControl(e.RowHandle);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra (Mã lỗi: )");
                HT_NHATKY objNK = new HT_NHATKY();
                objNK.NK_MALOI = "100";
                objNK.NK_TENLOI = "Lỗi giao diện";
                objNK.NK_TACVU = "Lấy dữ liệu";
                objNK.NK_NOIDUNG = ex.ToString();
                objNK.NK_TENMAY = "";
                objNK.NK_THOIGIAN = DateTime.Now;
                objNK.NV_MANV = "";
                ClassController.insertLog(objNK);
            }
        }
        
        private void txtLoaiHangMa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmShowLoaiHang frm = new frmShowLoaiHang();
                frm.ShowDialog(this);
                frm.Dispose();
            }
        }

        private void txtNhomHangMa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmShowNhomHang frm = new frmShowNhomHang();
                frm.ShowDialog(this);
                frm.Dispose();
            }
        }

        private void txtNuocSXMa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmShowQuocGia frm = new frmShowQuocGia();
                frm.ShowDialog(this);
                frm.Dispose();
            }
        }

        private void txtNPPMa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmShowNhaPhanPhoi frm = new frmShowNhaPhanPhoi();
                frm.ShowDialog(this);
                frm.Dispose();
            }
        }

        private void dateKMDenNgay_EditValueChanged(object sender, EventArgs e)
        {

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F1))
            {
                if (btnThem.Enabled)
                    Them();
                return true;
            }

            if (keyData == (Keys.F2))
            {
                if (btnSua.Enabled)
                    Sua();
                return true;
            }

            if (keyData == (Keys.F3))
            {
                if (btnXoa.Enabled)
                    Xoa();
                return true;
            }

            if (keyData == (Keys.F4))
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
