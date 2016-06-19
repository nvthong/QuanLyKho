using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace QLK
{
    public partial class frmBangKeXuatKhac : Form
    {
        string vSoHD = "";
        DataTable dtBK = new DataTable();
        public frmBangKeXuatKhac()
        {
            InitializeComponent();
            lkKho.Properties.DataSource = ClassController.layDSKhoHang();
            dateDenNgay.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            dateTuNgay.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
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

             xlWorkSheet.get_Range("b2", "p3").Merge(false);

             chartRange = xlWorkSheet.get_Range("b2", "p3");
             chartRange.FormulaR1C1 = "BẢNG KÊ XUẤT KHÁC";
             chartRange.HorizontalAlignment = 3;
             chartRange.VerticalAlignment = 3;
             chartRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
             chartRange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
             chartRange.Font.Size = 20;

             chartRange = xlWorkSheet.get_Range("b4", "p4");
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
             xlWorkSheet.Cells[4, 3] = "Số HĐ";
             xlWorkSheet.Cells[4, 4] = "Ngày HĐ";
             xlWorkSheet.Cells[4, 5] = "Mã hàng";
             xlWorkSheet.Cells[4, 6] = "Tên hàng";
             xlWorkSheet.Cells[4, 7] = "Đơn vị tính";
             xlWorkSheet.Cells[4, 8] = "Giá bán";
             xlWorkSheet.Cells[4, 9] = "Số lượng";
             xlWorkSheet.Cells[4, 10] = "Tổng bán";
             xlWorkSheet.Cells[4, 11] = "Chiếc khấu(%)";
             xlWorkSheet.Cells[4, 12] = "Tổng chiếc khấu";
             xlWorkSheet.Cells[4, 13] = "Thành tiền";
             xlWorkSheet.Cells[4, 14] = "Hạn sử dụng";
             xlWorkSheet.Cells[4, 15] = "Nhà phân phối";
             xlWorkSheet.Cells[4, 16] = "Kho hàng";


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
             xlWorkSheet.Columns[16].ColumnWidth = 14;

             double vTongSoLuong = 0;
             double vTongThanhTien = 0;
             for (int i = 5; i < (dtBK.Rows.Count + 5); i++)
             {
                 xlWorkSheet.Cells[i, 2] = (i - 4).ToString();
                 xlWorkSheet.Cells[i, 3] = dtBK.Rows[i - 5]["HDNX_SOHD"].ToString();
                 xlWorkSheet.Cells[i, 4] = DateTime.Parse(dtBK.Rows[i - 5]["HDNX_NGAYHD"].ToString()).ToShortDateString();
                 xlWorkSheet.Cells[i, 5] = dtBK.Rows[i - 5]["HH_MAHANG"].ToString();
                 xlWorkSheet.Cells[i, 6] = dtBK.Rows[i - 5]["HH_TENHANG"].ToString();
                 xlWorkSheet.Cells[i, 7] = dtBK.Rows[i - 5]["DVT_TENDONVI"].ToString();
                 xlWorkSheet.Cells[i, 8] = double.Parse(dtBK.Rows[i - 5]["HDNX_GIABAN"].ToString()).ToString();
                 xlWorkSheet.Cells[i, 9] = double.Parse(dtBK.Rows[i - 5]["HDNX_SOLUONG"].ToString()).ToString();
                 xlWorkSheet.Cells[i, 10] = double.Parse(dtBK.Rows[i - 5]["HDNX_TONGBAN"].ToString()).ToString();
                 xlWorkSheet.Cells[i, 11] = double.Parse(dtBK.Rows[i - 5]["HDNX_CHIECKHAU"].ToString()).ToString();
                 xlWorkSheet.Cells[i, 12] = double.Parse(dtBK.Rows[i - 5]["HDNX_TONGCHIECKHAU"].ToString()).ToString();
                 xlWorkSheet.Cells[i, 13] = double.Parse(dtBK.Rows[i - 5]["HDNX_THANHTIEN"].ToString()).ToString();
                 xlWorkSheet.Cells[i, 14] = dtBK.Rows[i - 5]["HH_HANSUDUNG"].ToString() != "" ? DateTime.Parse(dtBK.Rows[i - 5]["HH_HANSUDUNG"].ToString()).ToShortDateString() : "";
                 xlWorkSheet.Cells[i, 15] = dtBK.Rows[i - 5]["NPP_TENNPP"].ToString();
                 xlWorkSheet.Cells[i, 16] = dtBK.Rows[i - 5]["KH_TENKHO"].ToString();

                 vTongSoLuong += double.Parse(dtBK.Rows[i - 5]["HDNX_SOLUONG"].ToString());
                 vTongThanhTien += double.Parse(dtBK.Rows[i - 5]["HDNX_THANHTIEN"].ToString());

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

        private void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
                if (lkKho.EditValue != null)
                {
                    dtBK.Clear();
                    string vMaKho = lkKho.EditValue.ToString();
                    DateTime vTuNgay = dateTuNgay.DateTime;
                    DateTime vDenNgay = dateDenNgay.DateTime;
                    dtBK = ClassController.bangKeXuatKhac(vMaKho, vTuNgay, vDenNgay, cbxCaNam.Checked);
                    for (int i = 0; i < dtBK.Rows.Count; i++)
                    {
                        dtBK.Rows[i]["HDNX_SOLUONG"] = (-double.Parse(dtBK.Rows[i]["HDNX_SOLUONG"].ToString())).ToString();
                        dtBK.Rows[i]["HDNX_TONGBAN"] = (-Decimal.Parse(dtBK.Rows[i]["HDNX_TONGBAN"].ToString())).ToString();
                        dtBK.Rows[i]["HDNX_THANHTIEN"] = (-Decimal.Parse(dtBK.Rows[i]["HDNX_THANHTIEN"].ToString())).ToString();
                    }

                    gridControl1.DataSource = dtBK;
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn kho");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnExcell_Click(object sender, EventArgs e)
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

        private void gridView1_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            GridView view = sender as GridView;
            GridGroupRowInfo info = e.Info as GridGroupRowInfo;

            if (info.Column.Caption == "Hóa đơn")
            {
                vSoHD = view.GetGroupRowValue(e.RowHandle, info.Column).ToString();
                info.GroupText = "<color=LightSteelBlue>" +
                    "Hóa đơn: " + vSoHD + 
                    " Ngày: " + gridView1.GetRowCellValue(e.RowHandle, "HDNX_NGAYHD") + 
                    " Tổng tiền: " +
                    "</color> ";
            }
        }
    
    }
}
