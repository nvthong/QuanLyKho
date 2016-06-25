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
    public partial class frmDMNhomHang : Form
    {
        protected string StatusButton = "";
        protected int StatusRowClick = 0;
        DataTable dtDVT = new DataTable();

        public frmDMNhomHang()
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
                    SqlCommand sqlCmd = new SqlCommand("SelectDmhhNhomhangsAll", connect);
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
            //txtMaNhom.Properties.ReadOnly = !status;
            txtTenNhom.Properties.ReadOnly = !status;
            chkQuanLy.Properties.ReadOnly = !status;
        }

        public void setEmptyField()
        {
            txtGhiChu.Text = "";
            txtMaNhom.Text = "";
            txtTenNhom.Text = "";
        }

        public void setStatusButton(bool status)
        {
            btnXoa.Enabled = status;
            btnExcel.Enabled = status;
            btnDong.Enabled = status;
        }

        public bool checkExistMaDonVi(string NH_MANHOM)
        {
            try
            {
                using (SqlConnection connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    DataTable dtDVT = new DataTable();
                    SqlCommand sqlCmd = new SqlCommand("SelectDmhhNhomhang", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.Parameters.AddWithValue("@NH_MANHOM", NH_MANHOM);
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
            if (gridView1.GetRowCellValue(pRow, "NH_MANHOM") != null)
            {
                txtMaNhom.Text = gridView1.GetRowCellValue(pRow, "NH_MANHOM").ToString();
                txtTenNhom.Text = gridView1.GetRowCellValue(pRow, "NH_TENNHOM").ToString();
                txtGhiChu.Text = gridView1.GetRowCellValue(pRow, "NH_GHICHU").ToString();
                if (gridView1.GetRowCellValue(pRow, "NH_KICHHOAT").ToString() == "0")
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

            xlWorkSheet.get_Range("b2", "f3").Merge(false);

            chartRange = xlWorkSheet.get_Range("b2", "f3");
            chartRange.FormulaR1C1 = "DANH SÁCH NHÓM HÀNG";
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

            chartRange = xlWorkSheet.get_Range("b4", "f4");
            chartRange.Font.Bold = true;
            
            xlWorkSheet.Cells[4, 2] = "STT";
            chartRange = xlWorkSheet.get_Range("b4", "b4");
            chartRange.BorderAround(
                Excel.XlLineStyle.xlContinuous,
                Excel.XlBorderWeight.xlThin,
                Excel.XlColorIndex.xlColorIndexAutomatic,
                Excel.XlColorIndex.xlColorIndexAutomatic);
            xlWorkSheet.Cells[4, 3] = "Mã nhóm";
            chartRange = xlWorkSheet.get_Range("c4", "c4");
            chartRange.BorderAround(
                Excel.XlLineStyle.xlContinuous,
                Excel.XlBorderWeight.xlThin,
                Excel.XlColorIndex.xlColorIndexAutomatic,
                Excel.XlColorIndex.xlColorIndexAutomatic);
            xlWorkSheet.Cells[4, 4] = "Tên nhóm";
            chartRange = xlWorkSheet.get_Range("d4", "d4");
            chartRange.BorderAround(
                Excel.XlLineStyle.xlContinuous,
                Excel.XlBorderWeight.xlThin,
                Excel.XlColorIndex.xlColorIndexAutomatic,
                Excel.XlColorIndex.xlColorIndexAutomatic);
            xlWorkSheet.Cells[4, 5] = "Ghi chú";
            chartRange = xlWorkSheet.get_Range("e4", "e4");
            chartRange.BorderAround(
                Excel.XlLineStyle.xlContinuous,
                Excel.XlBorderWeight.xlThin,
                Excel.XlColorIndex.xlColorIndexAutomatic,
                Excel.XlColorIndex.xlColorIndexAutomatic);
            xlWorkSheet.Cells[4, 6] = "Quản lý";
            chartRange = xlWorkSheet.get_Range("f4", "f4");
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

            for (int i = 5; i < (dtDVT.Rows.Count + 5); i++)
            {
                xlWorkSheet.Cells[i, 2] = (i - 4).ToString();
                chartRange = xlWorkSheet.get_Range("b" + i, "b" + i);
                chartRange.BorderAround(
                    Excel.XlLineStyle.xlContinuous,
                    Excel.XlBorderWeight.xlThin,
                    Excel.XlColorIndex.xlColorIndexAutomatic,
                    Excel.XlColorIndex.xlColorIndexAutomatic);
                xlWorkSheet.Cells[i, 3] = dtDVT.Rows[i - 5]["NH_MANHOM"].ToString();
                chartRange = xlWorkSheet.get_Range("c" + i, "c" + i);
                chartRange.BorderAround(
                    Excel.XlLineStyle.xlContinuous,
                    Excel.XlBorderWeight.xlThin,
                    Excel.XlColorIndex.xlColorIndexAutomatic,
                    Excel.XlColorIndex.xlColorIndexAutomatic);
                xlWorkSheet.Cells[i, 4] = dtDVT.Rows[i - 5]["NH_TENNHOM"].ToString();
                chartRange = xlWorkSheet.get_Range("d" + i, "d" + i);
                chartRange.BorderAround(
                    Excel.XlLineStyle.xlContinuous,
                    Excel.XlBorderWeight.xlThin,
                    Excel.XlColorIndex.xlColorIndexAutomatic,
                    Excel.XlColorIndex.xlColorIndexAutomatic);
                xlWorkSheet.Cells[i, 5] = dtDVT.Rows[i - 5]["NH_GHICHU"].ToString();
                chartRange = xlWorkSheet.get_Range("e" + i, "e" + i);
                chartRange.BorderAround(
                    Excel.XlLineStyle.xlContinuous,
                    Excel.XlBorderWeight.xlThin,
                    Excel.XlColorIndex.xlColorIndexAutomatic,
                    Excel.XlColorIndex.xlColorIndexAutomatic);
                xlWorkSheet.Cells[i, 6] = dtDVT.Rows[i - 5]["NH_KICHHOAT"].ToString() == "1" ? "Còn quản lý" : "Không";
                chartRange = xlWorkSheet.get_Range("f" + i, "f" + i);
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
                txtMaNhom.Text = ClassController.getMaDanhMuc("NH_MANHOM");
                StatusButton = "Them";
                btnThem.Text = "Lưu";
                btnSua.Text = "Bỏ qua";
                txtMaNhom.Focus();

            }
            else if (btnThem.Text == "Lưu")
            {
                if (StatusButton == "Them")
                {
                    DMHH_NHOMHANG objNH = new DMHH_NHOMHANG();
                    objNH.NH_TENNHOM = txtTenNhom.Text.Trim();
                    objNH.NH_MANHOM = txtMaNhom.Text.Trim();
                    objNH.NH_GHICHU = txtGhiChu.Text.Trim();
                    objNH.NH_MACDINH = 0;
                    objNH.NH_KICHHOAT = chkQuanLy.Checked ? 1 : 0;

                    if (objNH.NH_MANHOM == "")
                    {
                        MessageBox.Show("Mã nhóm không được rỗng");
                        txtMaNhom.Focus();
                        return;
                    }

                    if (objNH.NH_TENNHOM == "")
                    {
                        MessageBox.Show("Tên nhóm không được rỗng");
                        txtTenNhom.Focus();
                        return;
                    }

                    if (checkExistMaDonVi(objNH.NH_MANHOM))
                    {
                        MessageBox.Show("Mã nhóm đã tồn tại");
                        txtMaNhom.Focus();
                        return;
                    }

                    try
                    {
                        using (SqlConnection connect = ClassController.ConnectDatabase())
                        {
                            connect.Open();
                            SqlCommand sqlCmd = new SqlCommand("InsertDmhhNhomhang", connect);
                            sqlCmd.CommandTimeout = 1000;
                            sqlCmd.Parameters.AddWithValue("@NH_MANHOM", objNH.NH_MANHOM);
                            sqlCmd.Parameters.AddWithValue("@NH_TENNHOM", objNH.NH_TENNHOM);
                            sqlCmd.Parameters.AddWithValue("@NH_MACDINH", objNH.NH_MACDINH);
                            sqlCmd.Parameters.AddWithValue("@NH_GHICHU", objNH.NH_GHICHU);
                            sqlCmd.Parameters.AddWithValue("@NH_KICHHOAT", objNH.NH_KICHHOAT);
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.ExecuteNonQuery();

                            setEmptyField();
                            setStatusButton(true);
                            setStatusField(false);
                            btnThem.Text = "Thêm";
                            btnSua.Text = "Sửa";
                            StatusButton = "";
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
                    DMHH_NHOMHANG objNH = new DMHH_NHOMHANG();
                    objNH.NH_TENNHOM = txtTenNhom.Text.Trim();
                    objNH.NH_MANHOM = txtMaNhom.Text.Trim();
                    objNH.NH_GHICHU = txtGhiChu.Text.Trim();
                    objNH.NH_MACDINH = 0;
                    objNH.NH_KICHHOAT = chkQuanLy.Checked ? 1 : 0;

                    if (objNH.NH_TENNHOM == "")
                    {
                        MessageBox.Show("Tên nhóm không được rỗng");
                        txtTenNhom.Focus();
                        return;
                    }

                    try
                    {
                        using (SqlConnection connect = ClassController.ConnectDatabase())
                        {
                            connect.Open();
                            SqlCommand sqlCmd = new SqlCommand("UpdateDmhhNhomhang", connect);
                            sqlCmd.CommandTimeout = 1000;
                            sqlCmd.Parameters.AddWithValue("@NH_MANHOM", objNH.NH_MANHOM);
                            sqlCmd.Parameters.AddWithValue("@NH_TENNHOM", objNH.NH_TENNHOM);
                            sqlCmd.Parameters.AddWithValue("@NH_MACDINH", objNH.NH_MACDINH);
                            sqlCmd.Parameters.AddWithValue("@NH_GHICHU", objNH.NH_GHICHU);
                            sqlCmd.Parameters.AddWithValue("@NH_KICHHOAT", objNH.NH_KICHHOAT);
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.ExecuteNonQuery();

                            setEmptyField();
                            setStatusButton(true);
                            setStatusField(false);
                            btnThem.Text = "Thêm";
                            btnSua.Text = "Sửa";
                            StatusButton = "";
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
                if (txtMaNhom.Text != "")
                {
                    setStatusField(true);
                    setStatusButton(false);
                    StatusButton = "Sua";
                    btnThem.Text = "Lưu";
                    btnSua.Text = "Bỏ qua";
                    txtTenNhom.Focus();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn loại hàng");
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
            string NH_MANHOM = txtMaNhom.Text.Trim();
            if (NH_MANHOM != "")
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có muốn xóa?", "Cảnh báo", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    try
                    {
                        if (!ClassController.kiemTraNhomHangDuocSuDung(NH_MANHOM))
                        {
                            using (SqlConnection connect = ClassController.ConnectDatabase())
                            {
                                connect.Open();
                                SqlCommand sqlCmd = new SqlCommand("DeleteDmhhNhomhang", connect);
                                sqlCmd.CommandTimeout = 1000;
                                sqlCmd.Parameters.AddWithValue("@NH_MANHOM", NH_MANHOM);
                                sqlCmd.CommandType = CommandType.StoredProcedure;
                                sqlCmd.ExecuteNonQuery();
                                connect.Close();

                                setStatusField(false);
                                setEmptyField();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Nhóm hàng đã sử dụng");
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
                MessageBox.Show("Vui lòng chọn nhóm hàng");
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
