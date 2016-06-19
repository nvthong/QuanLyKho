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
    public partial class frmHanSuDung : Form
    {
        List<BAOCAO_HANDUNG> objBC = new List<BAOCAO_HANDUNG>();

        public frmHanSuDung()
        {
            InitializeComponent();
            lkKho.Properties.DataSource = ClassController.layDSKhoHang();
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

            xlWorkSheet.get_Range("b2", "j3").Merge(false);

            chartRange = xlWorkSheet.get_Range("b2", "j3");
            chartRange.FormulaR1C1 = "TỒN KHO HÀNG HÓA";
            chartRange.HorizontalAlignment = 3;
            chartRange.VerticalAlignment = 3;
            chartRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
            chartRange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
            chartRange.Font.Size = 20;

            chartRange = xlWorkSheet.get_Range("b4", "j4");
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
            xlWorkSheet.Cells[4, 6] = "Giá nhập";
            xlWorkSheet.Cells[4, 7] = "Giá bán sỉ";
            xlWorkSheet.Cells[4, 8] = "Giá bán lẻ";
            xlWorkSheet.Cells[4, 9] = "Hạn sử dụng";
            xlWorkSheet.Cells[4, 10] = "Số ngày còn lại";

            xlWorkSheet.Columns[2].ColumnWidth = 14;
            xlWorkSheet.Columns[3].ColumnWidth = 14;
            xlWorkSheet.Columns[4].ColumnWidth = 14;
            xlWorkSheet.Columns[5].ColumnWidth = 14;
            xlWorkSheet.Columns[6].ColumnWidth = 14;
            xlWorkSheet.Columns[7].ColumnWidth = 14;
            xlWorkSheet.Columns[8].ColumnWidth = 14;
            xlWorkSheet.Columns[9].ColumnWidth = 14;
            xlWorkSheet.Columns[10].ColumnWidth = 14;


            for (int i = 5; i < (objBC.Count + 5); i++)
            {
                xlWorkSheet.Cells[i, 2] = (i - 4).ToString();
                xlWorkSheet.Cells[i, 3] = objBC[i - 5].HH_MAHANG.ToString();
                xlWorkSheet.Cells[i, 4] = objBC[i - 5].HH_TENHANG.ToString();
                xlWorkSheet.Cells[i, 5] = objBC[i - 5].DVT_TENDONVI.ToString();
                xlWorkSheet.Cells[i, 6] = double.Parse(objBC[i - 5].HH_GIAMUA.ToString()).ToString();
                xlWorkSheet.Cells[i, 7] = double.Parse(objBC[i - 5].HH_GIABANSI.ToString()).ToString();
                xlWorkSheet.Cells[i, 8] = double.Parse(objBC[i - 5].HH_GIABANLE.ToString()).ToString();
                xlWorkSheet.Cells[i, 9] = objBC[i - 5].HDNX_HANSUDUNG.Year == 1900 ? "" : objBC[i - 5].HDNX_HANSUDUNG.ToShortDateString();
                xlWorkSheet.Cells[i, 10] = objBC[i - 5].BC_NGAYCONLAI.ToString();
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
                    string vMaKho = lkKho.EditValue.ToString();

                    objBC.Clear();
                    objBC = ClassController.baoCaoHanDung(vMaKho);

                    
                    foreach (var item in objBC)
                    {
                        item.BC_NGAYCONLAI = 
                            item.HDNX_HANSUDUNG.Year <= 1900 ? 0 : 
                            (item.HDNX_HANSUDUNG.Subtract(DateTime.Now).Days > 0 ? item.HDNX_HANSUDUNG.Subtract(DateTime.Now).Days : 0);
                    }
                    gridControl1.DataSource = objBC;
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn kho nhập");
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

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "HDNX_HANSUDUNG")
                if (Convert.ToDateTime(e.Value).Year <= 1900) e.DisplayText = "";
        }
    }
}
