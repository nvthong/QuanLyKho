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
    public partial class frmDMKhoHang : Form
    {
        protected string StatusButton = "";
        protected int StatusRowClick = 0;
        DataTable dtDVT = new DataTable();
        public frmDMKhoHang()
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
                    SqlCommand sqlCmd = new SqlCommand("SelectDmKhohangsAll", connect);
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
            txtGhiChu.Properties.ReadOnly = !status;
            //txtMaKho.Properties.ReadOnly = !status;
            txtTenKho.Properties.ReadOnly = !status;
            chkKhoNhap.Properties.ReadOnly = !status;
            chkKhoBanSi.Properties.ReadOnly = !status;
            chkKhoBanLe.Properties.ReadOnly = !status;
            chkQuanLy.Properties.ReadOnly = !status;
        }

        public void setEmptyField()
        {
            txtGhiChu.Text = "";
            txtMaKho.Text = "";
            txtTenKho.Text = "";
        }

        public void setStatusButton(bool status)
        {
            btnXoa.Enabled = status;
            btnExcel.Enabled = status;
            btnDong.Enabled = status;
        }

        public bool checkExistMaKhoHang(string KH_MAKHO)
        {
            try
            {
                using (SqlConnection connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    DataTable dtDVT = new DataTable();
                    SqlCommand sqlCmd = new SqlCommand("SelectDmKhohang", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.Parameters.AddWithValue("@KH_MAKHO", KH_MAKHO);
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
            if (gridView1.GetRowCellValue(pRow, "KH_MAKHO") != null)
            {
                txtMaKho.Text = gridView1.GetRowCellValue(pRow, "KH_MAKHO").ToString();
                txtTenKho.Text = gridView1.GetRowCellValue(pRow, "KH_TENKHO").ToString();
                txtGhiChu.Text = gridView1.GetRowCellValue(pRow, "KH_GHICHU").ToString();
                if (gridView1.GetRowCellValue(pRow, "KH_KHONHAP").ToString() == "0")
                {
                    chkKhoNhap.Checked = false;
                }
                else
                {
                    chkKhoNhap.Checked = true;
                }
                if (gridView1.GetRowCellValue(pRow, "KH_BANLE").ToString() == "0")
                {
                    chkKhoBanLe.Checked = false;
                }
                else
                {
                    chkKhoBanLe.Checked = true;
                }
                if (gridView1.GetRowCellValue(pRow, "KH_BANSI").ToString() == "0")
                {
                    chkKhoBanSi.Checked = false;
                }
                else
                {
                    chkKhoBanSi.Checked = true;
                }
                if (gridView1.GetRowCellValue(pRow, "KH_KICHHOAT").ToString() == "0")
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

            xlWorkSheet.get_Range("b2", "i3").Merge(false);

            chartRange = xlWorkSheet.get_Range("b2", "i3");
            chartRange.FormulaR1C1 = "DANH SÁCH KHO HÀNG";
            chartRange.HorizontalAlignment = 3;
            chartRange.VerticalAlignment = 3;
            chartRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
            chartRange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
            chartRange.Font.Size = 20;
            chartRange.BorderAround(
                Excel.XlLineStyle.xlContinuous,
                Excel.XlBorderWeight.xlThin,
                Excel.XlColorIndex.xlColorIndexAutomatic,
                Excel.XlColorIndex.xlColorIndexAutomatic);

            chartRange = xlWorkSheet.get_Range("b4", "i4");
            chartRange.Font.Bold = true;


            xlWorkSheet.Cells[4, 2] = "STT";
            chartRange = xlWorkSheet.get_Range("b4", "b4");
            chartRange.BorderAround(
                Excel.XlLineStyle.xlContinuous,
                Excel.XlBorderWeight.xlThin,
                Excel.XlColorIndex.xlColorIndexAutomatic,
                Excel.XlColorIndex.xlColorIndexAutomatic);

            xlWorkSheet.Cells[4, 3] = "Mã kho";
            chartRange = xlWorkSheet.get_Range("c4", "c4");
            chartRange.BorderAround(
                Excel.XlLineStyle.xlContinuous,
                Excel.XlBorderWeight.xlThin,
                Excel.XlColorIndex.xlColorIndexAutomatic,
                Excel.XlColorIndex.xlColorIndexAutomatic);

            xlWorkSheet.Cells[4, 4] = "Tên kho";
            chartRange = xlWorkSheet.get_Range("d4", "d4");
            chartRange.BorderAround(
                Excel.XlLineStyle.xlContinuous,
                Excel.XlBorderWeight.xlThin,
                Excel.XlColorIndex.xlColorIndexAutomatic,
                Excel.XlColorIndex.xlColorIndexAutomatic);

            xlWorkSheet.Cells[4, 5] = "Kho nhập";
            chartRange = xlWorkSheet.get_Range("e4", "e4");
            chartRange.BorderAround(
                Excel.XlLineStyle.xlContinuous,
                Excel.XlBorderWeight.xlThin,
                Excel.XlColorIndex.xlColorIndexAutomatic,
                Excel.XlColorIndex.xlColorIndexAutomatic);

            xlWorkSheet.Cells[4, 6] = "Kho sỉ";
            chartRange = xlWorkSheet.get_Range("f4", "f4");
            chartRange.BorderAround(
                Excel.XlLineStyle.xlContinuous,
                Excel.XlBorderWeight.xlThin,
                Excel.XlColorIndex.xlColorIndexAutomatic,
                Excel.XlColorIndex.xlColorIndexAutomatic);

            xlWorkSheet.Cells[4, 7] = "Kho lẻ";
            chartRange = xlWorkSheet.get_Range("g4", "g4");
            chartRange.BorderAround(
                Excel.XlLineStyle.xlContinuous,
                Excel.XlBorderWeight.xlThin,
                Excel.XlColorIndex.xlColorIndexAutomatic,
                Excel.XlColorIndex.xlColorIndexAutomatic);

            xlWorkSheet.Cells[4, 8] = "Ghi chú";
            chartRange = xlWorkSheet.get_Range("h4", "h4");
            chartRange.BorderAround(
                Excel.XlLineStyle.xlContinuous,
                Excel.XlBorderWeight.xlThin,
                Excel.XlColorIndex.xlColorIndexAutomatic,
                Excel.XlColorIndex.xlColorIndexAutomatic);

            xlWorkSheet.Cells[4, 9] = "Quản lý";
            chartRange = xlWorkSheet.get_Range("i4", "i4");
            chartRange.BorderAround(
                Excel.XlLineStyle.xlContinuous,
                Excel.XlBorderWeight.xlThin,
                Excel.XlColorIndex.xlColorIndexAutomatic,
                Excel.XlColorIndex.xlColorIndexAutomatic);

            xlWorkSheet.Columns[2].ColumnWidth = 14;
            xlWorkSheet.Columns[3].ColumnWidth = 14;
            xlWorkSheet.Columns[4].ColumnWidth = 14;
            xlWorkSheet.Columns[5].ColumnWidth = 14;
            xlWorkSheet.Columns[6].ColumnWidth = 14;
            xlWorkSheet.Columns[7].ColumnWidth = 14;
            xlWorkSheet.Columns[8].ColumnWidth = 14;
            xlWorkSheet.Columns[9].ColumnWidth = 14;

            for (int i = 5; i < (dtDVT.Rows.Count + 5); i++)
            {
                xlWorkSheet.Cells[i, 2] = (i - 4).ToString();
                chartRange = xlWorkSheet.get_Range("b" + i, "b" + i);
                chartRange.BorderAround(
                    Excel.XlLineStyle.xlContinuous,
                    Excel.XlBorderWeight.xlThin,
                    Excel.XlColorIndex.xlColorIndexAutomatic,
                    Excel.XlColorIndex.xlColorIndexAutomatic);

                xlWorkSheet.Cells[i, 3] = dtDVT.Rows[i - 5]["KH_MAKHO"].ToString();
                chartRange = xlWorkSheet.get_Range("c" + i, "c" + i);
                chartRange.BorderAround(
                    Excel.XlLineStyle.xlContinuous,
                    Excel.XlBorderWeight.xlThin,
                    Excel.XlColorIndex.xlColorIndexAutomatic,
                    Excel.XlColorIndex.xlColorIndexAutomatic);

                xlWorkSheet.Cells[i, 4] = dtDVT.Rows[i - 5]["KH_TENKHO"].ToString();
                chartRange = xlWorkSheet.get_Range("d" + i, "d" + i);
                chartRange.BorderAround(
                    Excel.XlLineStyle.xlContinuous,
                    Excel.XlBorderWeight.xlThin,
                    Excel.XlColorIndex.xlColorIndexAutomatic,
                    Excel.XlColorIndex.xlColorIndexAutomatic);

                xlWorkSheet.Cells[i, 5] = dtDVT.Rows[i - 5]["KH_KHONHAP"].ToString() == "1" ? "x" : "";
                chartRange = xlWorkSheet.get_Range("e" + i, "e" + i);
                chartRange.BorderAround(
                    Excel.XlLineStyle.xlContinuous,
                    Excel.XlBorderWeight.xlThin,
                    Excel.XlColorIndex.xlColorIndexAutomatic,
                    Excel.XlColorIndex.xlColorIndexAutomatic);

                xlWorkSheet.Cells[i, 6] = dtDVT.Rows[i - 5]["KH_BANLE"].ToString() == "1" ? "x" : "";
                chartRange = xlWorkSheet.get_Range("f" + i, "f" + i);
                chartRange.BorderAround(
                    Excel.XlLineStyle.xlContinuous,
                    Excel.XlBorderWeight.xlThin,
                    Excel.XlColorIndex.xlColorIndexAutomatic,
                    Excel.XlColorIndex.xlColorIndexAutomatic);

                xlWorkSheet.Cells[i, 7] = dtDVT.Rows[i - 5]["KH_BANSI"].ToString() == "1" ? "x" : "";
                chartRange = xlWorkSheet.get_Range("g" + i, "g" + i);
                chartRange.BorderAround(
                    Excel.XlLineStyle.xlContinuous,
                    Excel.XlBorderWeight.xlThin,
                    Excel.XlColorIndex.xlColorIndexAutomatic,
                    Excel.XlColorIndex.xlColorIndexAutomatic);

                xlWorkSheet.Cells[i, 8] = dtDVT.Rows[i - 5]["KH_GHICHU"].ToString();
                chartRange = xlWorkSheet.get_Range("h" + i, "h" + i);
                chartRange.BorderAround(
                    Excel.XlLineStyle.xlContinuous,
                    Excel.XlBorderWeight.xlThin,
                    Excel.XlColorIndex.xlColorIndexAutomatic,
                    Excel.XlColorIndex.xlColorIndexAutomatic);

                xlWorkSheet.Cells[i, 9] = dtDVT.Rows[i - 5]["KH_GHICHU"].ToString() == "1" ? "Còn quản lý" : "Không";
                chartRange = xlWorkSheet.get_Range("i" + i, "i" + i);
                chartRange.BorderAround(
                    Excel.XlLineStyle.xlContinuous,
                    Excel.XlBorderWeight.xlThin,
                    Excel.XlColorIndex.xlColorIndexAutomatic,
                    Excel.XlColorIndex.xlColorIndexAutomatic);
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
                txtMaKho.Text = ClassController.getMaDanhMuc("KH_MAKHO");
                StatusButton = "Them";
                btnThem.Text = "Lưu";
                btnSua.Text = "Bỏ qua";
                txtMaKho.Focus();

            }
            else if (btnThem.Text == "Lưu")
            {
                if (StatusButton == "Them")
                {
                    DM_KHOHANG objKH = new DM_KHOHANG();
                    objKH.KH_MAKHO = txtMaKho.Text.Trim();
                    objKH.KH_TENKHO = txtTenKho.Text.Trim();
                    objKH.KH_LOAIKHO = 0;
                    objKH.KH_BANLE = chkKhoBanLe.Checked ? 1 : 0;
                    objKH.KH_BANSI = chkKhoBanSi.Checked ? 1 : 0;
                    objKH.KH_KHONHAP = chkKhoNhap.Checked ? 1 : 0;
                    objKH.KH_GHICHU = txtGhiChu.Text.Trim();
                    objKH.KH_KICHHOAT = chkQuanLy.Checked ? 1 : 0;

                    if (objKH.KH_MAKHO == "")
                    {
                        MessageBox.Show("Mã kho không được rỗng");
                        txtMaKho.Focus();
                        return;
                    }

                    if (objKH.KH_TENKHO == "")
                    {
                        MessageBox.Show("Tên kho không được rỗng");
                        txtTenKho.Focus();
                        return;
                    }

                    if (checkExistMaKhoHang(objKH.KH_MAKHO))
                    {
                        MessageBox.Show("Mã kho đã tồn tại");
                        txtMaKho.Focus();
                        return;
                    }

                    try
                    {
                        using (SqlConnection connect = ClassController.ConnectDatabase())
                        {
                            connect.Open();
                            SqlCommand sqlCmd = new SqlCommand("InsertDmKhohang", connect);
                            sqlCmd.CommandTimeout = 1000;
                            sqlCmd.Parameters.AddWithValue("@KH_MAKHO", objKH.KH_MAKHO);
                            sqlCmd.Parameters.AddWithValue("@KH_TENKHO", objKH.KH_TENKHO);
                            sqlCmd.Parameters.AddWithValue("@KH_LOAIKHO", objKH.KH_LOAIKHO);
                            sqlCmd.Parameters.AddWithValue("@KH_KHONHAP", objKH.KH_KHONHAP);
                            sqlCmd.Parameters.AddWithValue("@KH_BANLE", objKH.KH_BANLE);
                            sqlCmd.Parameters.AddWithValue("@KH_BANSI", objKH.KH_BANSI);
                            sqlCmd.Parameters.AddWithValue("@KH_GHICHU", objKH.KH_GHICHU);
                            sqlCmd.Parameters.AddWithValue("@KH_KICHHOAT", objKH.KH_KICHHOAT);
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.ExecuteNonQuery();

                            setEmptyField();
                            setStatusButton(true);
                            setStatusField(false);
                            btnThem.Text = "Thêm";
                            btnSua.Text = "Sửa";
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
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                else if (StatusButton == "Sua")
                {
                    DM_KHOHANG objKH = new DM_KHOHANG();
                    objKH.KH_MAKHO = txtMaKho.Text.Trim();
                    objKH.KH_TENKHO = txtTenKho.Text.Trim();
                    objKH.KH_LOAIKHO = 0;
                    objKH.KH_BANLE = chkKhoBanLe.Checked ? 1 : 0;
                    objKH.KH_BANSI = chkKhoBanSi.Checked ? 1 : 0;
                    objKH.KH_KHONHAP = chkKhoNhap.Checked ? 1 : 0;
                    objKH.KH_GHICHU = txtGhiChu.Text.Trim();
                    objKH.KH_KICHHOAT = chkQuanLy.Checked ? 1 : 0;

                    if (objKH.KH_TENKHO == "")
                    {
                        MessageBox.Show("Tên kho không được rỗng");
                        txtTenKho.Focus();
                        return;
                    }

                    try
                    {
                        using (SqlConnection connect = ClassController.ConnectDatabase())
                        {
                            connect.Open();
                            SqlCommand sqlCmd = new SqlCommand("UpdateDmKhohang", connect);
                            sqlCmd.CommandTimeout = 1000;
                            sqlCmd.Parameters.AddWithValue("@KH_MAKHO", objKH.KH_MAKHO);
                            sqlCmd.Parameters.AddWithValue("@KH_TENKHO", objKH.KH_TENKHO);
                            sqlCmd.Parameters.AddWithValue("@KH_LOAIKHO", objKH.KH_LOAIKHO);
                            sqlCmd.Parameters.AddWithValue("@KH_KHONHAP", objKH.KH_KHONHAP);
                            sqlCmd.Parameters.AddWithValue("@KH_BANLE", objKH.KH_BANLE);
                            sqlCmd.Parameters.AddWithValue("@KH_BANSI", objKH.KH_BANSI);
                            sqlCmd.Parameters.AddWithValue("@KH_GHICHU", objKH.KH_GHICHU);
                            sqlCmd.Parameters.AddWithValue("@KH_KICHHOAT", objKH.KH_KICHHOAT);
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.ExecuteNonQuery();

                            setEmptyField();
                            setStatusButton(true);
                            setStatusField(false);
                            btnThem.Text = "Thêm";
                            btnSua.Text = "Sửa";
                        }
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
                if (txtMaKho.Text != "")
                {
                    setStatusField(true);
                    setStatusButton(false);
                    StatusButton = "Sua";
                    btnThem.Text = "Lưu";
                    btnSua.Text = "Bỏ qua";
                    txtTenKho.Focus();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn đơn vị");
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
            string KH_MAKHO = txtMaKho.Text.Trim();
            if (KH_MAKHO != "")
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có muốn xóa?", "Cảnh báo", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    try
                    {
                        if (!ClassController.kiemTraKhoHangDuocSuDung(KH_MAKHO))
                        {
                            using (SqlConnection connect = ClassController.ConnectDatabase())
                            {
                                connect.Open();
                                SqlCommand sqlCmd = new SqlCommand("DeleteDmKhohang", connect);
                                sqlCmd.CommandTimeout = 1000;
                                sqlCmd.Parameters.AddWithValue("@KH_MAKHO", KH_MAKHO);
                                sqlCmd.CommandType = CommandType.StoredProcedure;
                                sqlCmd.ExecuteNonQuery();
                                connect.Close();

                                setStatusField(false);
                                setEmptyField();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Kho hàng đã sử dụng");
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
                MessageBox.Show("Vui lòng chọn kho");
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
