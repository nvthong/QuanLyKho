using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace QLK
{
    public partial class frmDMDonVi : Form
    {
        protected string StatusButton = "";
        protected int StatusRowClick = 0;
        DataTable dtDVT = new DataTable();
        public frmDMDonVi()
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
                    SqlCommand sqlCmd = new SqlCommand("SelectDmhhDonvitinhsAll", connect);
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
                objNK.NK_TENLOI = "Lỗi liên quan tới dữ liệu";
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
            txtMaDonVi.Properties.ReadOnly = !status;
            txtTenDonVi.Properties.ReadOnly = !status;
            chkQuanLy.Properties.ReadOnly = !status;
        }

        public void setEmptyField()
        {
            txtGhiChu.Text = "";
            txtMaDonVi.Text = "";
            txtTenDonVi.Text = "";
        }

        public void setStatusButton(bool status)
        {
            btnXoa.Enabled = status;
            btnExcel.Enabled = status;
            btnDong.Enabled = status;
        }

        public bool checkExistMaDonVi(string DVT_MADONVI)
        {
            try
            {
                using (SqlConnection connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    DataTable dtDVT = new DataTable();
                    SqlCommand sqlCmd = new SqlCommand("SelectDmhhDonvitinh", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.Parameters.AddWithValue("@DVT_MADONVI", DVT_MADONVI);
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
                MessageBox.Show("Đã có lỗi xảy ra (Mã lỗi: )");
                HT_NHATKY objNK = new HT_NHATKY();
                objNK.NK_MALOI = "100";
                objNK.NK_TENLOI = "Lỗi liên quan tới dữ liệu";
                objNK.NK_TACVU = "Lấy dữ liệu";
                objNK.NK_NOIDUNG = ex.ToString();
                objNK.NK_TENMAY = "";
                objNK.NK_THOIGIAN = DateTime.Now;
                objNK.NV_MANV = "";
                ClassController.insertLog(objNK);
                return false;
            }
        }

        public void fillControl(int pRow)
        {
            if (gridView1.GetRowCellValue(pRow, "DVT_MADONVI") != null)
            {
                txtMaDonVi.Text = gridView1.GetRowCellValue(pRow, "DVT_MADONVI").ToString();
                txtTenDonVi.Text = gridView1.GetRowCellValue(pRow, "DVT_TENDONVI").ToString();
                txtGhiChu.Text = gridView1.GetRowCellValue(pRow, "DVT_GHICHU").ToString();
                if (gridView1.GetRowCellValue(pRow, "DVT_KICHHOAT").ToString() == "0")
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
            chartRange.FormulaR1C1 = "DANH SÁCH ĐƠN VỊ TÍNH";
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
            xlWorkSheet.Cells[4, 3] = "Mã đơn vị";
            xlWorkSheet.Cells[4, 4] = "Tên đơn vị";
            xlWorkSheet.Cells[4, 5] = "Ghi chú";
            xlWorkSheet.Cells[4, 6] = "Quản lý";

            
            xlWorkSheet.Columns[2].ColumnWidth = 14;
            xlWorkSheet.Columns[3].ColumnWidth = 14;
            xlWorkSheet.Columns[4].ColumnWidth = 14;
            xlWorkSheet.Columns[5].ColumnWidth = 14;
            xlWorkSheet.Columns[6].ColumnWidth = 14;

            for (int i = 5; i < (dtDVT.Rows.Count + 5); i++ )
            {
                xlWorkSheet.Cells[i, 2] = (i-4).ToString();
                xlWorkSheet.Cells[i, 3] = dtDVT.Rows[i - 5]["DVT_MADONVI"].ToString();
                xlWorkSheet.Cells[i, 4] = dtDVT.Rows[i - 5]["DVT_TENDONVI"].ToString();
                xlWorkSheet.Cells[i, 5] = dtDVT.Rows[i - 5]["DVT_GHICHU"].ToString();
                xlWorkSheet.Cells[i, 6] = dtDVT.Rows[i - 5]["DVT_KICHHOAT"].ToString() == "1" ? "Còn quản lý" : "Không";
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
                txtMaDonVi.Text = ClassController.getMaDanhMuc("DVT_MADONVI");
                StatusButton = "Them";
                btnThem.Text = "Lưu";
                btnSua.Text = "Bỏ qua";
                txtMaDonVi.Focus();

            }
            else if (btnThem.Text == "Lưu")
            {
                if (StatusButton == "Them")
                {
                    DMHH_DONVITINH objDVT = new DMHH_DONVITINH();
                    objDVT.DVT_TENDONVI = txtTenDonVi.Text.Trim();
                    objDVT.DVT_MADONVI = txtMaDonVi.Text.Trim();
                    objDVT.DVT_GHICHU = txtGhiChu.Text.Trim();
                    objDVT.DVT_MACDINH = 0;
                    objDVT.DVT_KICHHOAT = chkQuanLy.Checked ? 1 : 0;

                    if (objDVT.DVT_MADONVI == "")
                    {
                        MessageBox.Show("Mã đơn vị không được rỗng");
                        txtMaDonVi.Focus();
                        return;
                    }

                    if (objDVT.DVT_TENDONVI == "")
                    {
                        MessageBox.Show("Tên đơn vị không được rỗng");
                        txtTenDonVi.Focus();
                        return;
                    }

                    if (checkExistMaDonVi(objDVT.DVT_MADONVI))
                    {
                        MessageBox.Show("Mã đơn vị đã tồn tại");
                        txtMaDonVi.Focus();
                        return;
                    }

                    try
                    {
                        using (SqlConnection connect = ClassController.ConnectDatabase())
                        {
                            connect.Open();
                            SqlCommand sqlCmd = new SqlCommand("InsertDmhhDonvitinh", connect);
                            sqlCmd.CommandTimeout = 1000;
                            sqlCmd.Parameters.AddWithValue("@DVT_MADONVI", objDVT.DVT_MADONVI);
                            sqlCmd.Parameters.AddWithValue("@DVT_TENDONVI", objDVT.DVT_TENDONVI);
                            sqlCmd.Parameters.AddWithValue("@DVT_MACDINH", objDVT.DVT_MACDINH);
                            sqlCmd.Parameters.AddWithValue("@DVT_GHICHU", objDVT.DVT_GHICHU);
                            sqlCmd.Parameters.AddWithValue("@DVT_KICHHOAT", objDVT.DVT_KICHHOAT);
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
                        MessageBox.Show("Đã có lỗi xảy ra (Mã lỗi: )");
                        HT_NHATKY objNK = new HT_NHATKY();
                        objNK.NK_MALOI = "100";
                        objNK.NK_TENLOI = "Lỗi khi thêm dữ liệu";
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
                    DMHH_DONVITINH objDVT = new DMHH_DONVITINH();
                    objDVT.DVT_TENDONVI = txtTenDonVi.Text.Trim();
                    objDVT.DVT_MADONVI = txtMaDonVi.Text.Trim();
                    objDVT.DVT_GHICHU = txtGhiChu.Text.Trim();
                    objDVT.DVT_MACDINH = 0;
                    objDVT.DVT_KICHHOAT = chkQuanLy.Checked ? 1 : 0;

                    if (objDVT.DVT_TENDONVI == "")
                    {
                        MessageBox.Show("Tên đơn vị không được rỗng");
                        txtTenDonVi.Focus();
                        return;
                    }

                    try
                    {
                        using (SqlConnection connect = ClassController.ConnectDatabase())
                        {
                            connect.Open();
                            SqlCommand sqlCmd = new SqlCommand("UpdateDmhhDonvitinh", connect);
                            sqlCmd.CommandTimeout = 1000;
                            sqlCmd.Parameters.AddWithValue("@DVT_MADONVI", objDVT.DVT_MADONVI);
                            sqlCmd.Parameters.AddWithValue("@DVT_TENDONVI", objDVT.DVT_TENDONVI);
                            sqlCmd.Parameters.AddWithValue("@DVT_MACDINH", objDVT.DVT_MACDINH);
                            sqlCmd.Parameters.AddWithValue("@DVT_GHICHU", objDVT.DVT_GHICHU);
                            sqlCmd.Parameters.AddWithValue("@DVT_KICHHOAT", objDVT.DVT_KICHHOAT);
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
                        MessageBox.Show("Đã có lỗi xảy ra (Mã lỗi: )");
                        HT_NHATKY objNK = new HT_NHATKY();
                        objNK.NK_MALOI = "100";
                        objNK.NK_TENLOI = "Lỗi khi thêm dữ liệu";
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
                if (txtMaDonVi.Text != "")
                {
                    setStatusField(true);
                    setStatusButton(false);
                    StatusButton = "Sua";
                    btnThem.Text = "Lưu";
                    btnSua.Text = "Bỏ qua";
                    txtTenDonVi.Focus();
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
            string DVT_MADONVI = txtMaDonVi.Text.Trim();
            if (DVT_MADONVI != "")
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có muốn xóa?", "Cảnh báo", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    try
                    {
                        if (!ClassController.kiemTraDVTDuocSuDung(DVT_MADONVI))
                        {
                            using (SqlConnection connect = ClassController.ConnectDatabase())
                            {
                                connect.Open();
                                SqlCommand sqlCmd = new SqlCommand("DeleteDmhhDonvitinh", connect);
                                sqlCmd.CommandTimeout = 1000;
                                sqlCmd.Parameters.AddWithValue("@DVT_MADONVI", DVT_MADONVI);
                                sqlCmd.CommandType = CommandType.StoredProcedure;
                                sqlCmd.ExecuteNonQuery();
                                connect.Close();

                                setStatusField(false);
                                setEmptyField();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Đơn vị tính đã sử dụng");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã có lỗi xảy ra (Mã lỗi: )");
                        HT_NHATKY objNK = new HT_NHATKY();
                        objNK.NK_MALOI = "100";
                        objNK.NK_TENLOI = "Lỗi khi xóa dữ liệu";
                        objNK.NK_TACVU = "Lấy dữ liệu";
                        objNK.NK_NOIDUNG = ex.ToString();
                        objNK.NK_TENMAY = "";
                        objNK.NK_THOIGIAN = DateTime.Now;
                        objNK.NV_MANV = "";
                        ClassController.insertLog(objNK);
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
                MessageBox.Show("Vui lòng chọn đơn vị");
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
            catch(Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra (Mã lỗi: )");
                HT_NHATKY objNK = new HT_NHATKY();
                objNK.NK_MALOI = "100";
                objNK.NK_TENLOI = "Lỗi xử lý trên giao diện";
                objNK.NK_TACVU = "Lấy dữ liệu";
                objNK.NK_NOIDUNG = ex.ToString();
                objNK.NK_TENMAY = "";
                objNK.NK_THOIGIAN = DateTime.Now;
                objNK.NV_MANV = "";
                ClassController.insertLog(objNK);
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
            }catch(Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra (Mã lỗi: )");
                HT_NHATKY objNK = new HT_NHATKY();
                objNK.NK_MALOI = "100";
                objNK.NK_TENLOI = "Lỗi xử lý trên giao diện";
                objNK.NK_TACVU = "Lấy dữ liệu";
                objNK.NK_NOIDUNG = ex.ToString();
                objNK.NK_TENMAY = "";
                objNK.NK_THOIGIAN = DateTime.Now;
                objNK.NV_MANV = "";
                ClassController.insertLog(objNK);
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
