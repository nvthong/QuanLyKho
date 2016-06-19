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
    public partial class frmDMNuocSanXuat : Form
    {
        protected string StatusButton = "";
        protected int StatusRowClick = 0;
        DataTable dtDVT = new DataTable();

        public frmDMNuocSanXuat()
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
                    SqlCommand sqlCmd = new SqlCommand("SelectDmhhQuocgiasAll", connect);
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
            //txtMaQuocGia.Properties.ReadOnly = !status;
            txtTenQuocGia.Properties.ReadOnly = !status;
            chkQuanLy.Properties.ReadOnly = !status;
        }

        public void setEmptyField()
        {
            txtGhiChu.Text = "";
            txtMaQuocGia.Text = "";
            txtTenQuocGia.Text = "";
        }

        public void setStatusButton(bool status)
        {
            btnXoa.Enabled = status;
            btnExcel.Enabled = status;
            btnDong.Enabled = status;
        }

        public bool checkExistMaQuocGia(string QG_MAQUOCGIA)
        {
            try
            {
                using (SqlConnection connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    DataTable dtDVT = new DataTable();
                    SqlCommand sqlCmd = new SqlCommand("SelectDmhhQuocgia", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.Parameters.AddWithValue("@QG_MAQUOCGIA", QG_MAQUOCGIA);
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
            if (gridView1.GetRowCellValue(pRow, "QG_MAQUOCGIA") != null)
            {
                txtMaQuocGia.Text = gridView1.GetRowCellValue(pRow, "QG_MAQUOCGIA").ToString();
                txtTenQuocGia.Text = gridView1.GetRowCellValue(pRow, "QG_TENQUOCGIA").ToString();
                txtGhiChu.Text = gridView1.GetRowCellValue(pRow, "QG_GHICHU").ToString();
                if (gridView1.GetRowCellValue(pRow, "QG_KICHHOAT").ToString() == "0")
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
            chartRange.FormulaR1C1 = "DANH SÁCH NƯỚC SẢN XUẤT";
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
            xlWorkSheet.Cells[4, 3] = "Mã nước";
            xlWorkSheet.Cells[4, 4] = "Tên nước";
            xlWorkSheet.Cells[4, 5] = "Ghi chú";
            xlWorkSheet.Cells[4, 6] = "Quản lý";


            xlWorkSheet.Columns[2].ColumnWidth = 14;
            xlWorkSheet.Columns[3].ColumnWidth = 14;
            xlWorkSheet.Columns[4].ColumnWidth = 14;
            xlWorkSheet.Columns[5].ColumnWidth = 14;
            xlWorkSheet.Columns[6].ColumnWidth = 14;

            for (int i = 5; i < (dtDVT.Rows.Count + 5); i++)
            {
                xlWorkSheet.Cells[i, 2] = (i - 4).ToString();
                xlWorkSheet.Cells[i, 3] = dtDVT.Rows[i - 5]["QG_MAQUOCGIA"].ToString();
                xlWorkSheet.Cells[i, 4] = dtDVT.Rows[i - 5]["QG_TENQUOCGIA"].ToString();
                xlWorkSheet.Cells[i, 5] = dtDVT.Rows[i - 5]["QG_GHICHU"].ToString();
                xlWorkSheet.Cells[i, 6] = dtDVT.Rows[i - 5]["QG_KICHHOAT"].ToString() == "1" ? "Còn quản lý" : "Không";
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
                txtMaQuocGia.Text = ClassController.getMaDanhMuc("QG_MAQUOCGIA");
                StatusButton = "Them";
                btnThem.Text = "Lưu";
                btnSua.Text = "Bỏ qua";
                txtMaQuocGia.Focus();

            }
            else if (btnThem.Text == "Lưu")
            {
                if (StatusButton == "Them")
                {
                    DMHH_QUOCGIA objQG = new DMHH_QUOCGIA();
                    objQG.QG_TENQUOCGIA = txtTenQuocGia.Text.Trim();
                    objQG.QG_MAQUOCGIA = txtMaQuocGia.Text.Trim();
                    objQG.QG_GHICHU = txtGhiChu.Text.Trim();
                    objQG.QG_MACDINH = 0;
                    objQG.QG_KICHHOAT = chkQuanLy.Checked ? 1 : 0;

                    if (objQG.QG_MAQUOCGIA == "")
                    {
                        MessageBox.Show("Mã số không được rỗng");
                        txtMaQuocGia.Focus();
                        return;
                    }

                    if (objQG.QG_TENQUOCGIA == "")
                    {
                        MessageBox.Show("Nước sản xuất không được rỗng");
                        txtTenQuocGia.Focus();
                        return;
                    }

                    if (checkExistMaQuocGia(objQG.QG_MAQUOCGIA))
                    {
                        MessageBox.Show("Mã số đã tồn tại");
                        txtMaQuocGia.Focus();
                        return;
                    }

                    try
                    {
                        using (SqlConnection connect = ClassController.ConnectDatabase())
                        {
                            connect.Open();
                            SqlCommand sqlCmd = new SqlCommand("InsertDmhhQuocgia", connect);
                            sqlCmd.CommandTimeout = 1000;
                            sqlCmd.Parameters.AddWithValue("@QG_MAQUOCGIA", objQG.QG_MAQUOCGIA);
                            sqlCmd.Parameters.AddWithValue("@QG_TENQUOCGIA", objQG.QG_TENQUOCGIA);
                            sqlCmd.Parameters.AddWithValue("@QG_MACDINH", objQG.QG_MACDINH);
                            sqlCmd.Parameters.AddWithValue("@QG_GHICHU", objQG.QG_GHICHU);
                            sqlCmd.Parameters.AddWithValue("@QG_KICHHOAT", objQG.QG_KICHHOAT);
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
                    DMHH_QUOCGIA objQG = new DMHH_QUOCGIA();
                    objQG.QG_TENQUOCGIA = txtTenQuocGia.Text.Trim();
                    objQG.QG_MAQUOCGIA = txtMaQuocGia.Text.Trim();
                    objQG.QG_GHICHU = txtGhiChu.Text.Trim();
                    objQG.QG_MACDINH = 0;
                    objQG.QG_KICHHOAT = chkQuanLy.Checked ? 1 : 0;

                    if (objQG.QG_TENQUOCGIA == "")
                    {
                        MessageBox.Show("Nước sản xuất không được rỗng");
                        txtTenQuocGia.Focus();
                        return;
                    }

                    try
                    {
                        using (SqlConnection connect = ClassController.ConnectDatabase())
                        {
                            connect.Open();
                            SqlCommand sqlCmd = new SqlCommand("UpdateDmhhQuocgia", connect);
                            sqlCmd.CommandTimeout = 1000;
                            sqlCmd.Parameters.AddWithValue("@QG_MAQUOCGIA", objQG.QG_MAQUOCGIA);
                            sqlCmd.Parameters.AddWithValue("@QG_TENQUOCGIA", objQG.QG_TENQUOCGIA);
                            sqlCmd.Parameters.AddWithValue("@QG_MACDINH", objQG.QG_MACDINH);
                            sqlCmd.Parameters.AddWithValue("@QG_GHICHU", objQG.QG_GHICHU);
                            sqlCmd.Parameters.AddWithValue("@QG_KICHHOAT", objQG.QG_KICHHOAT);
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
                if (txtMaQuocGia.Text != "")
                {
                    setStatusField(true);
                    setStatusButton(false);
                    StatusButton = "Sua";
                    btnThem.Text = "Lưu";
                    btnSua.Text = "Bỏ qua";
                    txtTenQuocGia.Focus();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn nước sản xuất");
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
            string QG_MAQUOCGIA = txtMaQuocGia.Text.Trim();
            if (QG_MAQUOCGIA != "")
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có muốn xóa?", "Cảnh báo", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    try
                    {
                        if (!ClassController.kiemTraQuocGiaDuocSuDung(QG_MAQUOCGIA))
                        {
                            using (SqlConnection connect = ClassController.ConnectDatabase())
                            {
                                connect.Open();
                                SqlCommand sqlCmd = new SqlCommand("DeleteDmhhQuocgia", connect);
                                sqlCmd.CommandTimeout = 1000;
                                sqlCmd.Parameters.AddWithValue("@QG_MAQUOCGIA", QG_MAQUOCGIA);
                                sqlCmd.CommandType = CommandType.StoredProcedure;
                                sqlCmd.ExecuteNonQuery();
                                connect.Close();

                                setStatusField(false);
                                setEmptyField();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Nước sản xuất đã sử dụng");
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
                MessageBox.Show("Vui lòng chọn nước sản xuất");
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
