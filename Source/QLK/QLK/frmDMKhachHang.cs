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
    public partial class frmDMKhachHang : Form
    {
        protected string StatusButton = "";
        protected int StatusRowClick = 0;
        DataTable dtDVT = new DataTable();

        public frmDMKhachHang()
        {
            InitializeComponent();
            loadData();
        }
        
        public void loadData()
        {
            try
            {
                using (SqlConnection connect = ClassController.ConnectDatabase())
                {
                    dtDVT.Clear();
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectDmKhachhangsAll", connect);
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
                MessageBox.Show(ex.ToString());
            }
        }

        public void setStatusField(bool status)
        {
            //txtMaKhachHang.Properties.ReadOnly = !status;
            txtTenKhachHang.Properties.ReadOnly = !status;
            txtWebsite.Properties.ReadOnly = !status;
            txtSDT.Properties.ReadOnly = !status;
            txtGhiChu.Properties.ReadOnly = !status;
            txtNguoiDaiDien.Properties.ReadOnly = !status;
            txtNganHang.Properties.ReadOnly = !status;
            txtMST.Properties.ReadOnly = !status;
            txtFax.Properties.ReadOnly = !status;
            txtEmail.Properties.ReadOnly = !status;
            chkQuanLy.Properties.ReadOnly = !status;
            txtDiaChi.Properties.ReadOnly = !status;
            txtTaiKhoan.Properties.ReadOnly = !status;
        }

        public void setEmptyField()
        {
            txtMaKhachHang.Text = "";
            txtTenKhachHang.Text = "";
            txtWebsite.Text = "";
            txtSDT.Text = "";
            txtGhiChu.Text = "";
            txtNguoiDaiDien.Text = "";
            txtNganHang.Text = "";
            txtMST.Text = "";
            txtFax.Text = "";
            txtEmail.Text = "";
            txtTaiKhoan.Text = "";
            txtDiaChi.Text = "";
        }

        public void setStatusButton(bool status)
        {
            btnXoa.Enabled = status;
            btnExcel.Enabled = status;
            btnDong.Enabled = status;
        }

        public bool checkExistMaKhachHang(string NPP_MANPP)
        {
            try
            {
                using (SqlConnection connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    DataTable dtDVT = new DataTable();
                    SqlCommand sqlCmd = new SqlCommand("SelectDmKhachhang", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.Parameters.AddWithValue("@NPP_MANPP", NPP_MANPP);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlCmd;
                    da.Fill(dtDVT);
                    connect.Close();
                    if (dtDVT.Rows.Count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public void fillControl(int pRow)
        {
            if (gridView1.GetRowCellValue(pRow, "NPP_MANPP") != null)
            {
                txtDiaChi.Text = gridView1.GetRowCellValue(pRow, "NPP_DIACHI").ToString();
                txtEmail.Text = gridView1.GetRowCellValue(pRow, "NPP_EMAIL").ToString();
                txtFax.Text = gridView1.GetRowCellValue(pRow, "NPP_FAX").ToString();
                txtGhiChu.Text = gridView1.GetRowCellValue(pRow, "NPP_GHICHU").ToString();
                txtMaKhachHang.Text = gridView1.GetRowCellValue(pRow, "NPP_MANPP").ToString();
                txtMST.Text = gridView1.GetRowCellValue(pRow, "NPP_MST").ToString();
                txtNganHang.Text = gridView1.GetRowCellValue(pRow, "NPP_NGANHANG").ToString();
                txtNguoiDaiDien.Text = gridView1.GetRowCellValue(pRow, "NPP_NGUOIDAIDIEN").ToString();
                txtSDT.Text = gridView1.GetRowCellValue(pRow, "NPP_DIENTHOAI").ToString();
                txtTaiKhoan.Text = gridView1.GetRowCellValue(pRow, "NPP_TAIKHOAN").ToString();
                txtTenKhachHang.Text = gridView1.GetRowCellValue(pRow, "NPP_TENNPP").ToString();
                txtWebsite.Text = gridView1.GetRowCellValue(pRow, "NPP_WEBSITE").ToString();
                if (gridView1.GetRowCellValue(pRow, "NPP_KICHHOAT").ToString() == "0")
                {
                    chkQuanLy.Checked = false;
                }
                else
                {
                    chkQuanLy.Checked = true;
                }
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

            xlWorkSheet.get_Range("b2", "g3").Merge(false);

            chartRange = xlWorkSheet.get_Range("b2", "g3");
            chartRange.FormulaR1C1 = "DANH SÁCH KHÁCH HÀNG";
            chartRange.HorizontalAlignment = 3;
            chartRange.VerticalAlignment = 3;
            chartRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
            chartRange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
            chartRange.Font.Size = 20;

            chartRange = xlWorkSheet.get_Range("b4", "f4");
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
            xlWorkSheet.Cells[4, 3] = "Mã khách hàng";
            xlWorkSheet.Cells[4, 4] = "Tên khách hàng";
            xlWorkSheet.Cells[4, 5] = "Địa chỉ";
            xlWorkSheet.Cells[4, 6] = "Số điện thoại";
            xlWorkSheet.Cells[4, 7] = "Quản lý";


            xlWorkSheet.Columns[2].ColumnWidth = 14;
            xlWorkSheet.Columns[3].ColumnWidth = 14;
            xlWorkSheet.Columns[4].ColumnWidth = 14;
            xlWorkSheet.Columns[5].ColumnWidth = 14;
            xlWorkSheet.Columns[6].ColumnWidth = 14;
            xlWorkSheet.Columns[7].ColumnWidth = 14;

            for (int i = 5; i < (dtDVT.Rows.Count + 5); i++)
            {
                xlWorkSheet.Cells[i, 2] = (i - 4).ToString();
                xlWorkSheet.Cells[i, 3] = dtDVT.Rows[i - 5]["NPP_MANPP"].ToString();
                xlWorkSheet.Cells[i, 4] = dtDVT.Rows[i - 5]["NPP_TENNPP"].ToString();
                xlWorkSheet.Cells[i, 5] = dtDVT.Rows[i - 5]["NPP_DIACHI"].ToString();
                xlWorkSheet.Cells[i, 6] = dtDVT.Rows[i - 5]["NPP_DIENTHOAI"].ToString();
                xlWorkSheet.Cells[i, 7] = dtDVT.Rows[i - 5]["NPP_KICHHOAT"].ToString() == "1" ? "Còn quản lý" : "Không";
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
                MessageBox.Show(ex.ToString());
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (StatusButton == "")
                {
                    StatusRowClick = e.FocusedRowHandle;
                    if (gridView1.DataRowCount > 0)
                    {
                        fillControl(e.FocusedRowHandle);
                    }
                    else
                    {
                        setEmptyField();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
                txtMaKhachHang.Text = ClassController.getMaDanhMuc("NPP_MANPP_K");
                StatusButton = "Them";
                btnThem.Text = "Lưu";
                btnSua.Text = "Bỏ qua";
                txtMaKhachHang.Focus();

            }
            else if (btnThem.Text == "Lưu")
            {
                if (StatusButton == "Them")
                {
                    DM_NHAPHANPHOI objNPP = new DM_NHAPHANPHOI();
                    objNPP.NPP_DIACHI = txtDiaChi.Text.Trim();
                    objNPP.NPP_DIENTHOAI = txtSDT.Text.Trim();
                    objNPP.NPP_EMAIL = txtEmail.Text.Trim();
                    objNPP.NPP_FAX = txtFax.Text.Trim();
                    objNPP.NPP_GHICHU = txtGhiChu.Text.Trim();
                    objNPP.NPP_WEBSITE = txtWebsite.Text.Trim();
                    objNPP.NPP_LOAIKH = 0; //0: khách hàng/ 1:Nhà phân phối
                    objNPP.NPP_LOAINPP = 0;
                    objNPP.NPP_MANPP = txtMaKhachHang.Text.Trim();
                    objNPP.NPP_MST = txtMST.Text.Trim();
                    objNPP.NPP_NGANHANG = txtNganHang.Text.Trim();
                    objNPP.NPP_NGUOIDAIDIEN = txtNguoiDaiDien.Text.Trim();
                    objNPP.NPP_TAIKHOAN = txtTaiKhoan.Text.Trim();
                    objNPP.NPP_TENNPP = txtTenKhachHang.Text.Trim();
                    objNPP.NPP_KICHHOAT = chkQuanLy.Checked ? 1 : 0;

                    if (objNPP.NPP_MANPP == "")
                    {
                        MessageBox.Show("Mã khách hàng không được rỗng");
                        txtMaKhachHang.Focus();
                        return;
                    }

                    if (objNPP.NPP_TENNPP == "")
                    {
                        MessageBox.Show("Tên khách hàng không được rỗng");
                        txtTenKhachHang.Focus();
                        return;
                    }

                    if (checkExistMaKhachHang(objNPP.NPP_MANPP))
                    {
                        MessageBox.Show("Mã khách hàng đã tồn tại");
                        txtMaKhachHang.Focus();
                        return;
                    }

                    try
                    {
                        using (SqlConnection connect = ClassController.ConnectDatabase())
                        {
                            connect.Open();
                            SqlCommand sqlCmd = new SqlCommand("InsertDmNhaphanphoi", connect);
                            sqlCmd.CommandTimeout = 1000;
                            sqlCmd.Parameters.AddWithValue("@NPP_MANPP", objNPP.NPP_MANPP);
                            sqlCmd.Parameters.AddWithValue("@NPP_TENNPP", objNPP.NPP_TENNPP);
                            sqlCmd.Parameters.AddWithValue("@NPP_DIACHI", objNPP.NPP_DIACHI);
                            sqlCmd.Parameters.AddWithValue("@NPP_MST", objNPP.NPP_MST);
                            sqlCmd.Parameters.AddWithValue("@NPP_FAX", objNPP.NPP_FAX);
                            sqlCmd.Parameters.AddWithValue("@NPP_DIENTHOAI", objNPP.NPP_DIENTHOAI);
                            sqlCmd.Parameters.AddWithValue("@NPP_EMAIL", objNPP.NPP_EMAIL);
                            sqlCmd.Parameters.AddWithValue("@NPP_WEBSITE", objNPP.NPP_WEBSITE);
                            sqlCmd.Parameters.AddWithValue("@NPP_TAIKHOAN", objNPP.NPP_TAIKHOAN);
                            sqlCmd.Parameters.AddWithValue("@NPP_NGANHANG", objNPP.NPP_NGANHANG);
                            sqlCmd.Parameters.AddWithValue("@NPP_NGUOIDAIDIEN", objNPP.NPP_NGUOIDAIDIEN);
                            sqlCmd.Parameters.AddWithValue("@NPP_GHICHU", objNPP.NPP_GHICHU);
                            sqlCmd.Parameters.AddWithValue("@NPP_LOAINPP", objNPP.NPP_LOAINPP);
                            sqlCmd.Parameters.AddWithValue("@NPP_LOAIKH", objNPP.NPP_LOAIKH);
                            sqlCmd.Parameters.AddWithValue("@NPP_KICHHOAT", objNPP.NPP_KICHHOAT);
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.ExecuteNonQuery();
                        }
                        setEmptyField();
                        setStatusButton(true);
                        setStatusField(false);
                        btnThem.Text = "Thêm";
                        btnSua.Text = "Sửa";
                        StatusButton = "";
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
                        MessageBox.Show(ex.ToString());
                    }
                }
                else if (StatusButton == "Sua")
                {
                    DM_NHAPHANPHOI objNPP = new DM_NHAPHANPHOI();
                    objNPP.NPP_DIACHI = txtDiaChi.Text.Trim();
                    objNPP.NPP_DIENTHOAI = txtSDT.Text.Trim();
                    objNPP.NPP_EMAIL = txtEmail.Text.Trim();
                    objNPP.NPP_FAX = txtFax.Text.Trim();
                    objNPP.NPP_GHICHU = txtGhiChu.Text.Trim();
                    objNPP.NPP_WEBSITE = txtWebsite.Text.Trim();
                    objNPP.NPP_LOAIKH = 0; //0: Khách hàng / 1: Nhà phân phối
                    objNPP.NPP_LOAINPP = 0;
                    objNPP.NPP_MANPP = txtMaKhachHang.Text.Trim();
                    objNPP.NPP_MST = txtMST.Text.Trim();
                    objNPP.NPP_NGANHANG = txtNganHang.Text.Trim();
                    objNPP.NPP_NGUOIDAIDIEN = txtNguoiDaiDien.Text.Trim();
                    objNPP.NPP_TAIKHOAN = txtTaiKhoan.Text.Trim();
                    objNPP.NPP_TENNPP = txtTenKhachHang.Text.Trim();
                    objNPP.NPP_KICHHOAT = chkQuanLy.Checked ? 1 : 0;

                    if (objNPP.NPP_TENNPP == "")
                    {
                        MessageBox.Show("Tên khách hàng không được rỗng");
                        txtTenKhachHang.Focus();
                        return;
                    }

                    try
                    {
                        using (SqlConnection connect = ClassController.ConnectDatabase())
                        {
                            connect.Open();
                            SqlCommand sqlCmd = new SqlCommand("UpdateDmNhaphanphoi", connect);
                            sqlCmd.CommandTimeout = 1000;
                            sqlCmd.Parameters.AddWithValue("@NPP_MANPP", objNPP.NPP_MANPP);
                            sqlCmd.Parameters.AddWithValue("@NPP_TENNPP", objNPP.NPP_TENNPP);
                            sqlCmd.Parameters.AddWithValue("@NPP_DIACHI", objNPP.NPP_DIACHI);
                            sqlCmd.Parameters.AddWithValue("@NPP_MST", objNPP.NPP_MST);
                            sqlCmd.Parameters.AddWithValue("@NPP_FAX", objNPP.NPP_FAX);
                            sqlCmd.Parameters.AddWithValue("@NPP_DIENTHOAI", objNPP.NPP_DIENTHOAI);
                            sqlCmd.Parameters.AddWithValue("@NPP_EMAIL", objNPP.NPP_EMAIL);
                            sqlCmd.Parameters.AddWithValue("@NPP_WEBSITE", objNPP.NPP_WEBSITE);
                            sqlCmd.Parameters.AddWithValue("@NPP_TAIKHOAN", objNPP.NPP_TAIKHOAN);
                            sqlCmd.Parameters.AddWithValue("@NPP_NGANHANG", objNPP.NPP_NGANHANG);
                            sqlCmd.Parameters.AddWithValue("@NPP_NGUOIDAIDIEN", objNPP.NPP_NGUOIDAIDIEN);
                            sqlCmd.Parameters.AddWithValue("@NPP_GHICHU", objNPP.NPP_GHICHU);
                            sqlCmd.Parameters.AddWithValue("@NPP_LOAINPP", objNPP.NPP_LOAINPP);
                            sqlCmd.Parameters.AddWithValue("@NPP_LOAIKH", objNPP.NPP_LOAIKH);
                            sqlCmd.Parameters.AddWithValue("@NPP_KICHHOAT", objNPP.NPP_KICHHOAT);
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.ExecuteNonQuery();
                        }
                        setEmptyField();
                        setStatusButton(true);
                        setStatusField(false);
                        btnThem.Text = "Thêm";
                        btnSua.Text = "Sửa";
                        StatusButton = "";
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
                        MessageBox.Show(ex.ToString());
                    }
                }
                StatusButton = "";
            }
        }

        public void Sua()
        {
            if (btnSua.Text == "Sửa")
            {
                if (txtMaKhachHang.Text != "")
                {
                    setStatusField(true);
                    setStatusButton(false);
                    StatusButton = "Sua";
                    btnThem.Text = "Lưu";
                    btnSua.Text = "Bỏ qua";
                    txtTenKhachHang.Focus();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn khách hàng");
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
            string NPP_MANPP = txtMaKhachHang.Text.Trim();
            if (NPP_MANPP != "")
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có muốn xóa?", "Cảnh báo", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    try
                    {
                        if (!ClassController.kiemTraKhachHangDuocSuSung(NPP_MANPP))
                        {
                            using (SqlConnection connect = ClassController.ConnectDatabase())
                            {
                                connect.Open();
                                SqlCommand sqlCmd = new SqlCommand("DeleteDmNhaphanphoi", connect);
                                sqlCmd.CommandTimeout = 1000;
                                sqlCmd.Parameters.AddWithValue("@NPP_MANPP", NPP_MANPP);
                                sqlCmd.CommandType = CommandType.StoredProcedure;
                                sqlCmd.ExecuteNonQuery();
                                connect.Close();

                                setStatusField(false);
                                setEmptyField();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Khách hàng đã sử dụng");
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
                MessageBox.Show("Vui lòng chọn khách hàng");
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
