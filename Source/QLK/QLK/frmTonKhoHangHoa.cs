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
    public partial class frmTonKhoHangHoa : Form
    {
        DataTable dtHH;
        List<BAOCAO_TONKHO> objBC = new List<BAOCAO_TONKHO>();
        public frmTonKhoHangHoa()
        {
            InitializeComponent();
            //lkKho.Properties.DataSource = ClassController.layDSKhoHang();
            dateDenNgay.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            dateTuNgay.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        }

        public void InitializeDtBangKe()
        {
            dtHH = new DataTable();
            dtHH.Columns.Add("HH_MAHANG", typeof(string));      //1
            dtHH.Columns.Add("HH_TENHANG", typeof(string));     //2
            dtHH.Columns.Add("DVT_TENDONVI", typeof(string));   //3
            dtHH.Columns.Add("HH_GIAMUA", typeof(decimal));     //4
            dtHH.Columns.Add("HH_GIABANLE", typeof(decimal));   //5
            dtHH.Columns.Add("HH_GIABANSI", typeof(decimal));   //6
            dtHH.Columns.Add("TONGNHAP", typeof(double));       //7
            dtHH.Columns.Add("TONGNHAPKHAC", typeof(double));   //8
            dtHH.Columns.Add("TONGXUATSI", typeof(double));     //9
            dtHH.Columns.Add("TONGXUATLE", typeof(double));     //10
            dtHH.Columns.Add("TONGXUATKHAC", typeof(double));   //11
            dtHH.Columns.Add("TONKHO", typeof(double));         //12
            dtHH.Columns.Add("TIENTON", typeof(decimal));       //13
            dtHH.Columns.Add("TONGTHANHTOAN", typeof(decimal)); //14
            dtHH.Columns.Add("HH_HANSUDUNG", typeof(DateTime)); //15
            dtHH.Columns.Add("ID", typeof(string));             //16
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
            chartRange.FormulaR1C1 = "TỒN KHO HÀNG HÓA";
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

            chartRange = xlWorkSheet.get_Range("b4", "o4");
            chartRange.Font.Bold = true;
            
            xlWorkSheet.Cells[4, 2] = "STT";
            chartRange = xlWorkSheet.get_Range("b4", "b4");
            chartRange.BorderAround(
                Excel.XlLineStyle.xlContinuous,
                Excel.XlBorderWeight.xlThin,
                Excel.XlColorIndex.xlColorIndexAutomatic,
                Excel.XlColorIndex.xlColorIndexAutomatic);
            xlWorkSheet.Cells[4, 3] = "Mã hàng";
            chartRange = xlWorkSheet.get_Range("c4", "c4");
            chartRange.BorderAround(
                Excel.XlLineStyle.xlContinuous,
                Excel.XlBorderWeight.xlThin,
                Excel.XlColorIndex.xlColorIndexAutomatic,
                Excel.XlColorIndex.xlColorIndexAutomatic);
            xlWorkSheet.Cells[4, 4] = "Tên hàng";
            chartRange = xlWorkSheet.get_Range("d4", "d4");
            chartRange.BorderAround(
                Excel.XlLineStyle.xlContinuous,
                Excel.XlBorderWeight.xlThin,
                Excel.XlColorIndex.xlColorIndexAutomatic,
                Excel.XlColorIndex.xlColorIndexAutomatic);
            xlWorkSheet.Cells[4, 5] = "Đơn vị tính";
            chartRange = xlWorkSheet.get_Range("e4", "e4");
            chartRange.BorderAround(
                Excel.XlLineStyle.xlContinuous,
                Excel.XlBorderWeight.xlThin,
                Excel.XlColorIndex.xlColorIndexAutomatic,
                Excel.XlColorIndex.xlColorIndexAutomatic);
            xlWorkSheet.Cells[4, 6] = "Giá nhập";
            chartRange = xlWorkSheet.get_Range("f4", "f4");
            chartRange.BorderAround(
                Excel.XlLineStyle.xlContinuous,
                Excel.XlBorderWeight.xlThin,
                Excel.XlColorIndex.xlColorIndexAutomatic,
                Excel.XlColorIndex.xlColorIndexAutomatic);
            xlWorkSheet.Cells[4, 7] = "Giá bán sỉ";
            chartRange = xlWorkSheet.get_Range("g4", "g4");
            chartRange.BorderAround(
                Excel.XlLineStyle.xlContinuous,
                Excel.XlBorderWeight.xlThin,
                Excel.XlColorIndex.xlColorIndexAutomatic,
                Excel.XlColorIndex.xlColorIndexAutomatic);
            xlWorkSheet.Cells[4, 8] = "Giá bán lẻ";
            chartRange = xlWorkSheet.get_Range("h4", "h4");
            chartRange.BorderAround(
                Excel.XlLineStyle.xlContinuous,
                Excel.XlBorderWeight.xlThin,
                Excel.XlColorIndex.xlColorIndexAutomatic,
                Excel.XlColorIndex.xlColorIndexAutomatic);
            xlWorkSheet.Cells[4, 9] = "Nhập kho";
            chartRange = xlWorkSheet.get_Range("i4", "i4");
            chartRange.BorderAround(
                Excel.XlLineStyle.xlContinuous,
                Excel.XlBorderWeight.xlThin,
                Excel.XlColorIndex.xlColorIndexAutomatic,
                Excel.XlColorIndex.xlColorIndexAutomatic);
            xlWorkSheet.Cells[4, 10] = "Nhập khác";
            chartRange = xlWorkSheet.get_Range("j4", "j4");
            chartRange.BorderAround(
                Excel.XlLineStyle.xlContinuous,
                Excel.XlBorderWeight.xlThin,
                Excel.XlColorIndex.xlColorIndexAutomatic,
                Excel.XlColorIndex.xlColorIndexAutomatic);
            xlWorkSheet.Cells[4, 11] = "Xuất sỉ";
            chartRange = xlWorkSheet.get_Range("k4", "k4");
            chartRange.BorderAround(
                Excel.XlLineStyle.xlContinuous,
                Excel.XlBorderWeight.xlThin,
                Excel.XlColorIndex.xlColorIndexAutomatic,
                Excel.XlColorIndex.xlColorIndexAutomatic);
            xlWorkSheet.Cells[4, 12] = "Xuất lẻ";
            chartRange = xlWorkSheet.get_Range("l4", "l4");
            chartRange.BorderAround(
                Excel.XlLineStyle.xlContinuous,
                Excel.XlBorderWeight.xlThin,
                Excel.XlColorIndex.xlColorIndexAutomatic,
                Excel.XlColorIndex.xlColorIndexAutomatic);
            xlWorkSheet.Cells[4, 13] = "Xuất khác";
            chartRange = xlWorkSheet.get_Range("m4", "m4");
            chartRange.BorderAround(
                Excel.XlLineStyle.xlContinuous,
                Excel.XlBorderWeight.xlThin,
                Excel.XlColorIndex.xlColorIndexAutomatic,
                Excel.XlColorIndex.xlColorIndexAutomatic);
            xlWorkSheet.Cells[4, 14] = "Tồn kho";
            chartRange = xlWorkSheet.get_Range("n4", "n4");
            chartRange.BorderAround(
                Excel.XlLineStyle.xlContinuous,
                Excel.XlBorderWeight.xlThin,
                Excel.XlColorIndex.xlColorIndexAutomatic,
                Excel.XlColorIndex.xlColorIndexAutomatic);
            xlWorkSheet.Cells[4, 15] = "Tiền tồn";
            chartRange = xlWorkSheet.get_Range("o4", "o4");
            chartRange.BorderAround(
                Excel.XlLineStyle.xlContinuous,
                Excel.XlBorderWeight.xlThin,
                Excel.XlColorIndex.xlColorIndexAutomatic,
                Excel.XlColorIndex.xlColorIndexAutomatic);
            //xlWorkSheet.Cells[4, 16] = "Tổng thanh toán";
            //chartRange = xlWorkSheet.get_Range("p4", "p4");
            //chartRange.BorderAround(
            //    Excel.XlLineStyle.xlContinuous,
            //    Excel.XlBorderWeight.xlThin,
            //    Excel.XlColorIndex.xlColorIndexAutomatic,
            //    Excel.XlColorIndex.xlColorIndexAutomatic);
            //xlWorkSheet.Cells[4, 17] = "Hạn sử dụng";
            //chartRange = xlWorkSheet.get_Range("q4", "q4");
            //chartRange.BorderAround(
            //    Excel.XlLineStyle.xlContinuous,
            //    Excel.XlBorderWeight.xlThin,
            //    Excel.XlColorIndex.xlColorIndexAutomatic,
            //    Excel.XlColorIndex.xlColorIndexAutomatic);


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
            xlWorkSheet.Columns[17].ColumnWidth = 14;


            for (int i = 5; i < (objBC.Count + 5); i++)
            {
                xlWorkSheet.Cells[i, 2] = (i - 4).ToString();
                chartRange = xlWorkSheet.get_Range("b" + i, "b" + i);
                chartRange.BorderAround(
                    Excel.XlLineStyle.xlContinuous,
                    Excel.XlBorderWeight.xlThin,
                    Excel.XlColorIndex.xlColorIndexAutomatic,
                    Excel.XlColorIndex.xlColorIndexAutomatic);
                xlWorkSheet.Cells[i, 3] = objBC[i - 5].HH_MAHANG.ToString();
                chartRange = xlWorkSheet.get_Range("c" + i, "c" + i);
                chartRange.BorderAround(
                    Excel.XlLineStyle.xlContinuous,
                    Excel.XlBorderWeight.xlThin,
                    Excel.XlColorIndex.xlColorIndexAutomatic,
                    Excel.XlColorIndex.xlColorIndexAutomatic);
                xlWorkSheet.Cells[i, 4] = objBC[i - 5].HH_TENHANG.ToString();
                chartRange = xlWorkSheet.get_Range("d" + i, "d" + i);
                chartRange.BorderAround(
                    Excel.XlLineStyle.xlContinuous,
                    Excel.XlBorderWeight.xlThin,
                    Excel.XlColorIndex.xlColorIndexAutomatic,
                    Excel.XlColorIndex.xlColorIndexAutomatic);
                xlWorkSheet.Cells[i, 5] = objBC[i - 5].DVT_TENDONVI.ToString();
                chartRange = xlWorkSheet.get_Range("e" + i, "e" + i);
                chartRange.BorderAround(
                    Excel.XlLineStyle.xlContinuous,
                    Excel.XlBorderWeight.xlThin,
                    Excel.XlColorIndex.xlColorIndexAutomatic,
                    Excel.XlColorIndex.xlColorIndexAutomatic);
                xlWorkSheet.Cells[i, 6] = double.Parse(objBC[i - 5].HH_GIAMUA.ToString()).ToString();
                chartRange = xlWorkSheet.get_Range("f" + i, "f" + i);
                chartRange.BorderAround(
                    Excel.XlLineStyle.xlContinuous,
                    Excel.XlBorderWeight.xlThin,
                    Excel.XlColorIndex.xlColorIndexAutomatic,
                    Excel.XlColorIndex.xlColorIndexAutomatic);
                xlWorkSheet.Cells[i, 7] = double.Parse(objBC[i - 5].HH_GIABANSI.ToString()).ToString();
                chartRange = xlWorkSheet.get_Range("g" + i, "g" + i);
                chartRange.BorderAround(
                    Excel.XlLineStyle.xlContinuous,
                    Excel.XlBorderWeight.xlThin,
                    Excel.XlColorIndex.xlColorIndexAutomatic,
                    Excel.XlColorIndex.xlColorIndexAutomatic);
                xlWorkSheet.Cells[i, 8] = double.Parse(objBC[i - 5].HH_GIABANLE.ToString()).ToString();
                chartRange = xlWorkSheet.get_Range("h" + i, "h" + i);
                chartRange.BorderAround(
                    Excel.XlLineStyle.xlContinuous,
                    Excel.XlBorderWeight.xlThin,
                    Excel.XlColorIndex.xlColorIndexAutomatic,
                    Excel.XlColorIndex.xlColorIndexAutomatic);
                xlWorkSheet.Cells[i, 9] = objBC[i - 5].BC_TONGNHAPKHO.ToString();
                chartRange = xlWorkSheet.get_Range("i" + i, "i" + i);
                chartRange.BorderAround(
                    Excel.XlLineStyle.xlContinuous,
                    Excel.XlBorderWeight.xlThin,
                    Excel.XlColorIndex.xlColorIndexAutomatic,
                    Excel.XlColorIndex.xlColorIndexAutomatic);
                xlWorkSheet.Cells[i, 10] = objBC[i - 5].BC_TONGNHAPKHAC.ToString();
                chartRange = xlWorkSheet.get_Range("j" + i, "j" + i);
                chartRange.BorderAround(
                    Excel.XlLineStyle.xlContinuous,
                    Excel.XlBorderWeight.xlThin,
                    Excel.XlColorIndex.xlColorIndexAutomatic,
                    Excel.XlColorIndex.xlColorIndexAutomatic);
                xlWorkSheet.Cells[i, 11] = objBC[i - 5].BC_TONGXUATSI.ToString();
                chartRange = xlWorkSheet.get_Range("k" + i, "k" + i);
                chartRange.BorderAround(
                    Excel.XlLineStyle.xlContinuous,
                    Excel.XlBorderWeight.xlThin,
                    Excel.XlColorIndex.xlColorIndexAutomatic,
                    Excel.XlColorIndex.xlColorIndexAutomatic);
                xlWorkSheet.Cells[i, 12] = objBC[i - 5].BC_TONGXUATLE.ToString();
                chartRange = xlWorkSheet.get_Range("l" + i, "l" + i);
                chartRange.BorderAround(
                    Excel.XlLineStyle.xlContinuous,
                    Excel.XlBorderWeight.xlThin,
                    Excel.XlColorIndex.xlColorIndexAutomatic,
                    Excel.XlColorIndex.xlColorIndexAutomatic);
                xlWorkSheet.Cells[i, 13] = objBC[i - 5].BC_TONGXUATKHAC.ToString();
                chartRange = xlWorkSheet.get_Range("m" + i, "m" + i);
                chartRange.BorderAround(
                    Excel.XlLineStyle.xlContinuous,
                    Excel.XlBorderWeight.xlThin,
                    Excel.XlColorIndex.xlColorIndexAutomatic,
                    Excel.XlColorIndex.xlColorIndexAutomatic);
                xlWorkSheet.Cells[i, 14] = objBC[i - 5].BC_TONKHO.ToString();
                chartRange = xlWorkSheet.get_Range("n" + i, "n" + i);
                chartRange.BorderAround(
                    Excel.XlLineStyle.xlContinuous,
                    Excel.XlBorderWeight.xlThin,
                    Excel.XlColorIndex.xlColorIndexAutomatic,
                    Excel.XlColorIndex.xlColorIndexAutomatic);
                xlWorkSheet.Cells[i, 15] = double.Parse(objBC[i - 5].BC_TIENTON.ToString()).ToString();
                chartRange = xlWorkSheet.get_Range("o" + i, "o" + i);
                chartRange.BorderAround(
                    Excel.XlLineStyle.xlContinuous,
                    Excel.XlBorderWeight.xlThin,
                    Excel.XlColorIndex.xlColorIndexAutomatic,
                    Excel.XlColorIndex.xlColorIndexAutomatic);
                //xlWorkSheet.Cells[i, 16] = objBC[i - 5].BC_TONGTHANHTOAN.ToString();
                //chartRange = xlWorkSheet.get_Range("p" + i, "p" + i);
                //chartRange.BorderAround(
                //    Excel.XlLineStyle.xlContinuous,
                //    Excel.XlBorderWeight.xlThin,
                //    Excel.XlColorIndex.xlColorIndexAutomatic,
                //    Excel.XlColorIndex.xlColorIndexAutomatic);
                //xlWorkSheet.Cells[i, 17] = objBC[i - 5].HH_HANSUDUNG.Year == 1900 ? "" : objBC[i - 5].HH_HANSUDUNG.ToShortDateString();
                //chartRange = xlWorkSheet.get_Range("q" + i, "q" + i);
                //chartRange.BorderAround(
                //    Excel.XlLineStyle.xlContinuous,
                //    Excel.XlBorderWeight.xlThin,
                //    Excel.XlColorIndex.xlColorIndexAutomatic,
                //    Excel.XlColorIndex.xlColorIndexAutomatic);
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

        private void frmTonKhoHangHoa_Load(object sender, EventArgs e)
        {

        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
                //if (lkKho.EditValue != null)
                //{
                    string vMaKho = "KHO000001";
                    DateTime vTuNgay = dateTuNgay.DateTime;
                    DateTime vDenNgay = dateDenNgay.DateTime;
                    DataTable dt = new DataTable();

                    objBC.Clear();
                    objBC = ClassController.baoCaoTonKho(vMaKho, vTuNgay, vDenNgay, cbxCaNam.Checked);

                    //Lấy hàng hóa còn quản lý
                    if (!chkKhongQuanLy.Checked) 
                    {
                        objBC =  objBC.Where(x => x.HH_KICHHOAT == 1).ToList();
                    }

                    //Lấy hàng hóa có phát sinh
                    if (!chkKhongPhatSinh.Checked)
                    {
                        objBC = objBC.Where(
                            x => x.BC_TONGNHAPKHO != 0 || x.BC_TONGNHAPKHAC != 0 || x.BC_TONGXUATSI != 0 || x.BC_TONGXUATLE != 0 || x.BC_TONGXUATKHAC != 0)
                            .ToList();
                    }

                    foreach(var item in objBC)
                    {
                        double vTonKho = 0;
                        double vTienTon = 0;
                        double vTongNhap = item.BC_TONGNHAPKHO;
                        double vTongNHapKhac = item.BC_TONGNHAPKHAC;

                        double vTongXuatSi = item.BC_TONGXUATSI;
                        double vTongXuatLe = item.BC_TONGXUATLE;
                        double vTongXuatKhac = item.BC_TONGXUATKHAC;

                        vTonKho = (vTongNhap + vTongNHapKhac) - ((vTongXuatSi) + (vTongXuatLe) + (vTongXuatKhac));
                        vTienTon = (vTonKho * double.Parse(item.HH_GIABANLE.ToString()));

                        item.BC_TONKHO = vTonKho;
                        item.BC_TIENTON = (decimal) vTienTon;
                    }
                    gridControl1.DataSource = objBC;
                //}
                //else
                //{
                //    MessageBox.Show("Vui lòng chọn kho nhập");
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            GridView view = sender as GridView;
            string a = e.Value.ToString();
            if (e.Column.FieldName == "Total" && e.IsGetData)
            {
                e.Value = "";
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
    }    
}
