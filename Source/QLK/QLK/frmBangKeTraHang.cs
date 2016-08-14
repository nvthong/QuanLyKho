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
    public partial class frmBangKeTraHang : Form
    {
        string vSoHD = "";
        DataTable dtBK = new DataTable();
        public frmBangKeTraHang()
        {
            InitializeComponent();
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
            chartRange.FormulaR1C1 = "BẢNG KÊ TRẢ HÀNG";
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

            chartRange = xlWorkSheet.get_Range("b4", "p4");
            chartRange.Font.Bold = true;


            xlWorkSheet.Cells[4, 2] = "STT";
            chartRange = xlWorkSheet.get_Range("b4", "b4");
            chartRange.BorderAround(
                Excel.XlLineStyle.xlContinuous,
                Excel.XlBorderWeight.xlThin,
                Excel.XlColorIndex.xlColorIndexAutomatic,
                Excel.XlColorIndex.xlColorIndexAutomatic);
            xlWorkSheet.Cells[4, 3] = "Số HĐ";
            chartRange = xlWorkSheet.get_Range("c4", "c4");
            chartRange.BorderAround(
                Excel.XlLineStyle.xlContinuous,
                Excel.XlBorderWeight.xlThin,
                Excel.XlColorIndex.xlColorIndexAutomatic,
                Excel.XlColorIndex.xlColorIndexAutomatic);
            xlWorkSheet.Cells[4, 4] = "Ngày HĐ";
            chartRange = xlWorkSheet.get_Range("d4", "d4");
            chartRange.BorderAround(
                Excel.XlLineStyle.xlContinuous,
                Excel.XlBorderWeight.xlThin,
                Excel.XlColorIndex.xlColorIndexAutomatic,
                Excel.XlColorIndex.xlColorIndexAutomatic);
            xlWorkSheet.Cells[4, 5] = "Mã hàng";
            chartRange = xlWorkSheet.get_Range("e4", "e4");
            chartRange.BorderAround(
                Excel.XlLineStyle.xlContinuous,
                Excel.XlBorderWeight.xlThin,
                Excel.XlColorIndex.xlColorIndexAutomatic,
                Excel.XlColorIndex.xlColorIndexAutomatic);
            xlWorkSheet.Cells[4, 6] = "Tên hàng";
            chartRange = xlWorkSheet.get_Range("f4", "f4");
            chartRange.BorderAround(
                Excel.XlLineStyle.xlContinuous,
                Excel.XlBorderWeight.xlThin,
                Excel.XlColorIndex.xlColorIndexAutomatic,
                Excel.XlColorIndex.xlColorIndexAutomatic);
            xlWorkSheet.Cells[4, 7] = "Đơn vị tính";
            chartRange = xlWorkSheet.get_Range("g4", "g4");
            chartRange.BorderAround(
                Excel.XlLineStyle.xlContinuous,
                Excel.XlBorderWeight.xlThin,
                Excel.XlColorIndex.xlColorIndexAutomatic,
                Excel.XlColorIndex.xlColorIndexAutomatic);
            xlWorkSheet.Cells[4, 8] = "Giá bán";
            chartRange = xlWorkSheet.get_Range("h4", "h4");
            chartRange.BorderAround(
                Excel.XlLineStyle.xlContinuous,
                Excel.XlBorderWeight.xlThin,
                Excel.XlColorIndex.xlColorIndexAutomatic,
                Excel.XlColorIndex.xlColorIndexAutomatic);
            xlWorkSheet.Cells[4, 9] = "Số lượng";
            chartRange = xlWorkSheet.get_Range("i4", "i4");
            chartRange.BorderAround(
                Excel.XlLineStyle.xlContinuous,
                Excel.XlBorderWeight.xlThin,
                Excel.XlColorIndex.xlColorIndexAutomatic,
                Excel.XlColorIndex.xlColorIndexAutomatic);
            xlWorkSheet.Cells[4, 10] = "Tổng bán";
            chartRange = xlWorkSheet.get_Range("j4", "j4");
            chartRange.BorderAround(
                Excel.XlLineStyle.xlContinuous,
                Excel.XlBorderWeight.xlThin,
                Excel.XlColorIndex.xlColorIndexAutomatic,
                Excel.XlColorIndex.xlColorIndexAutomatic);
            xlWorkSheet.Cells[4, 11] = "Chiếc khấu(%)";
            chartRange = xlWorkSheet.get_Range("k4", "k4");
            chartRange.BorderAround(
                Excel.XlLineStyle.xlContinuous,
                Excel.XlBorderWeight.xlThin,
                Excel.XlColorIndex.xlColorIndexAutomatic,
                Excel.XlColorIndex.xlColorIndexAutomatic);
            xlWorkSheet.Cells[4, 12] = "Tổng chiếc khấu";
            chartRange = xlWorkSheet.get_Range("l4", "l4");
            chartRange.BorderAround(
                Excel.XlLineStyle.xlContinuous,
                Excel.XlBorderWeight.xlThin,
                Excel.XlColorIndex.xlColorIndexAutomatic,
                Excel.XlColorIndex.xlColorIndexAutomatic);
            xlWorkSheet.Cells[4, 13] = "Thành tiền";
            chartRange = xlWorkSheet.get_Range("m4", "m4");
            chartRange.BorderAround(
                Excel.XlLineStyle.xlContinuous,
                Excel.XlBorderWeight.xlThin,
                Excel.XlColorIndex.xlColorIndexAutomatic,
                Excel.XlColorIndex.xlColorIndexAutomatic);
            xlWorkSheet.Cells[4, 14] = "Hạn sử dụng";
            chartRange = xlWorkSheet.get_Range("n4", "n4");
            chartRange.BorderAround(
                Excel.XlLineStyle.xlContinuous,
                Excel.XlBorderWeight.xlThin,
                Excel.XlColorIndex.xlColorIndexAutomatic,
                Excel.XlColorIndex.xlColorIndexAutomatic);
            xlWorkSheet.Cells[4, 15] = "Nhà phân phối";
            chartRange = xlWorkSheet.get_Range("o4", "o4");
            chartRange.BorderAround(
                Excel.XlLineStyle.xlContinuous,
                Excel.XlBorderWeight.xlThin,
                Excel.XlColorIndex.xlColorIndexAutomatic,
                Excel.XlColorIndex.xlColorIndexAutomatic);
            xlWorkSheet.Cells[4, 16] = "Kho hàng";
            chartRange = xlWorkSheet.get_Range("p4", "p4");
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
            xlWorkSheet.Columns[10].ColumnWidth = 14;
            xlWorkSheet.Columns[11].ColumnWidth = 14;
            xlWorkSheet.Columns[12].ColumnWidth = 14;
            xlWorkSheet.Columns[13].ColumnWidth = 14;
            xlWorkSheet.Columns[14].ColumnWidth = 14;
            xlWorkSheet.Columns[15].ColumnWidth = 14;
            xlWorkSheet.Columns[16].ColumnWidth = 14;

            double vTongSoLuong = 0;
            double vTongThanhTien = 0;

            string vNewHH = "";
            string vOldHH = "";
            int countRow = 0;
            int sumRow = 0;

            try
            {
                DataView dv = dtBK.DefaultView;
                dv.Sort = "HDNX_SOHD desc";
                DataTable sortedDT = dv.ToTable();
                dtBK = sortedDT;
                for (int i = 5; i < (dtBK.Rows.Count + 5); i++)
                {
                    vNewHH = dtBK.Rows[i - 5 - countRow]["HDNX_SOHD"].ToString();
                    if (vOldHH == "" && vNewHH != "")
                    {
                        xlWorkSheet.Cells[i, 2] = (i - 4).ToString();
                        chartRange = xlWorkSheet.get_Range("b" + i, "b" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 3] = dtBK.Rows[i - 5]["HDNX_SOHD"].ToString();
                        chartRange = xlWorkSheet.get_Range("c" + i, "c" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 4] = DateTime.Parse(dtBK.Rows[i - 5]["HDNX_NGAYHD"].ToString()).ToShortDateString();
                        chartRange = xlWorkSheet.get_Range("d" + i, "d" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 5] = dtBK.Rows[i - 5]["HH_MAHANG"].ToString();
                        chartRange = xlWorkSheet.get_Range("e" + i, "e" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 6] = dtBK.Rows[i - 5]["HH_TENHANG"].ToString();
                        chartRange = xlWorkSheet.get_Range("f" + i, "f" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 7] = dtBK.Rows[i - 5]["DVT_TENDONVI"].ToString();
                        chartRange = xlWorkSheet.get_Range("g" + i, "g" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 8] = double.Parse(dtBK.Rows[i - 5]["HDNX_GIABAN"].ToString()).ToString();
                        chartRange = xlWorkSheet.get_Range("h" + i, "h" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 9] = double.Parse(dtBK.Rows[i - 5]["HDNX_SOLUONG"].ToString()).ToString();
                        chartRange = xlWorkSheet.get_Range("i" + i, "i" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 10] = double.Parse(dtBK.Rows[i - 5]["HDNX_TONGBAN"].ToString()).ToString();
                        chartRange = xlWorkSheet.get_Range("j" + i, "j" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 11] = double.Parse(dtBK.Rows[i - 5]["HDNX_CHIECKHAU"].ToString()).ToString();
                        chartRange = xlWorkSheet.get_Range("k" + i, "k" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 12] = double.Parse(dtBK.Rows[i - 5]["HDNX_TONGCHIECKHAU"].ToString()).ToString();
                        chartRange = xlWorkSheet.get_Range("l" + i, "l" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 13] = double.Parse(dtBK.Rows[i - 5]["HDNX_THANHTIEN"].ToString()).ToString();
                        chartRange = xlWorkSheet.get_Range("m" + i, "m" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 14] = dtBK.Rows[i - 5]["HH_HANSUDUNG"].ToString() != "" ? DateTime.Parse(dtBK.Rows[i - 5]["HH_HANSUDUNG"].ToString()).ToShortDateString() : "";
                        chartRange = xlWorkSheet.get_Range("n" + i, "n" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 15] = dtBK.Rows[i - 5]["NPP_TENNPP"].ToString();
                        chartRange = xlWorkSheet.get_Range("o" + i, "o" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 16] = dtBK.Rows[i - 5]["KH_TENKHO"].ToString();
                        chartRange = xlWorkSheet.get_Range("p" + i, "p" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                    }
                    else if (vOldHH != "" && vOldHH == vNewHH)
                    {
                        xlWorkSheet.Cells[i, 2] = (i - 4 - countRow).ToString();
                        chartRange = xlWorkSheet.get_Range("b" + i, "b" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 3] = dtBK.Rows[i - 5 - countRow]["HDNX_SOHD"].ToString();
                        chartRange = xlWorkSheet.get_Range("c" + i, "c" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 4] = DateTime.Parse(dtBK.Rows[i - 5 - countRow]["HDNX_NGAYHD"].ToString()).ToShortDateString();
                        chartRange = xlWorkSheet.get_Range("d" + i, "d" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 5] = dtBK.Rows[i - 5 - countRow]["HH_MAHANG"].ToString();
                        chartRange = xlWorkSheet.get_Range("e" + i, "e" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 6] = dtBK.Rows[i - 5 - countRow]["HH_TENHANG"].ToString();
                        chartRange = xlWorkSheet.get_Range("f" + i, "f" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 7] = dtBK.Rows[i - 5 - countRow]["DVT_TENDONVI"].ToString();
                        chartRange = xlWorkSheet.get_Range("g" + i, "g" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 8] = double.Parse(dtBK.Rows[i - 5 - countRow]["HDNX_GIABAN"].ToString()).ToString();
                        chartRange = xlWorkSheet.get_Range("h" + i, "h" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 9] = double.Parse(dtBK.Rows[i - 5 - countRow]["HDNX_SOLUONG"].ToString()).ToString();
                        chartRange = xlWorkSheet.get_Range("i" + i, "i" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 10] = double.Parse(dtBK.Rows[i - 5 - countRow]["HDNX_TONGBAN"].ToString()).ToString();
                        chartRange = xlWorkSheet.get_Range("j" + i, "j" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 11] = double.Parse(dtBK.Rows[i - 5 - countRow]["HDNX_CHIECKHAU"].ToString()).ToString();
                        chartRange = xlWorkSheet.get_Range("k" + i, "k" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 12] = double.Parse(dtBK.Rows[i - 5 - countRow]["HDNX_TONGCHIECKHAU"].ToString()).ToString();
                        chartRange = xlWorkSheet.get_Range("l" + i, "l" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 13] = double.Parse(dtBK.Rows[i - 5 - countRow]["HDNX_THANHTIEN"].ToString()).ToString();
                        chartRange = xlWorkSheet.get_Range("m" + i, "m" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 14] = dtBK.Rows[i - 5 - countRow]["HH_HANSUDUNG"].ToString() != "" ? DateTime.Parse(dtBK.Rows[i - 5]["HH_HANSUDUNG"].ToString()).ToShortDateString() : "";
                        chartRange = xlWorkSheet.get_Range("n" + i, "n" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 15] = dtBK.Rows[i - 5 - countRow]["NPP_TENNPP"].ToString();
                        chartRange = xlWorkSheet.get_Range("o" + i, "o" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 16] = dtBK.Rows[i - 5 - countRow]["KH_TENKHO"].ToString();
                        chartRange = xlWorkSheet.get_Range("p" + i, "p" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                    }
                    else if (vOldHH != "" && vOldHH != vNewHH)
                    {
                        countRow += 1;
                        i = i + 1;
                        xlWorkSheet.Cells[i, 2] = "";
                        xlWorkSheet.Cells[i, 3] = "";
                        xlWorkSheet.Cells[i, 4] = "";
                        xlWorkSheet.Cells[i, 5] = "";
                        xlWorkSheet.Cells[i, 6] = "";
                        xlWorkSheet.Cells[i, 7] = "";
                        xlWorkSheet.Cells[i, 8] = "";
                        xlWorkSheet.Cells[i, 9] = "";
                        xlWorkSheet.Cells[i, 10] = "";
                        xlWorkSheet.Cells[i, 11] = "";
                        xlWorkSheet.Cells[i, 12] = "";
                        xlWorkSheet.Cells[i, 13] = "";
                        xlWorkSheet.Cells[i, 14] = "";
                        xlWorkSheet.Cells[i, 15] = "";
                        xlWorkSheet.Cells[i, 16] = "";
                        //
                        xlWorkSheet.Cells[i, 2] = (i - 4 - countRow).ToString();
                        chartRange = xlWorkSheet.get_Range("b" + i, "b" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 3] = dtBK.Rows[i - 5 - countRow]["HDNX_SOHD"].ToString();
                        chartRange = xlWorkSheet.get_Range("c" + i, "c" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 4] = DateTime.Parse(dtBK.Rows[i - 5 - countRow]["HDNX_NGAYHD"].ToString()).ToShortDateString();
                        chartRange = xlWorkSheet.get_Range("d" + i, "d" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 5] = dtBK.Rows[i - 5 - countRow]["HH_MAHANG"].ToString();
                        chartRange = xlWorkSheet.get_Range("e" + i, "e" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 6] = dtBK.Rows[i - 5 - countRow]["HH_TENHANG"].ToString();
                        chartRange = xlWorkSheet.get_Range("f" + i, "f" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 7] = dtBK.Rows[i - 5 - countRow]["DVT_TENDONVI"].ToString();
                        chartRange = xlWorkSheet.get_Range("g" + i, "g" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 8] = double.Parse(dtBK.Rows[i - 5 - countRow]["HDNX_GIABAN"].ToString()).ToString();
                        chartRange = xlWorkSheet.get_Range("h" + i, "h" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 9] = double.Parse(dtBK.Rows[i - 5 - countRow]["HDNX_SOLUONG"].ToString()).ToString();
                        chartRange = xlWorkSheet.get_Range("i" + i, "i" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 10] = double.Parse(dtBK.Rows[i - 5 - countRow]["HDNX_TONGBAN"].ToString()).ToString();
                        chartRange = xlWorkSheet.get_Range("j" + i, "j" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 11] = double.Parse(dtBK.Rows[i - 5 - countRow]["HDNX_CHIECKHAU"].ToString()).ToString();
                        chartRange = xlWorkSheet.get_Range("k" + i, "k" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 12] = double.Parse(dtBK.Rows[i - 5 - countRow]["HDNX_TONGCHIECKHAU"].ToString()).ToString();
                        chartRange = xlWorkSheet.get_Range("l" + i, "l" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 13] = double.Parse(dtBK.Rows[i - 5 - countRow]["HDNX_THANHTIEN"].ToString()).ToString();
                        chartRange = xlWorkSheet.get_Range("m" + i, "m" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 14] = dtBK.Rows[i - 5 - countRow]["HH_HANSUDUNG"].ToString() != "" ? DateTime.Parse(dtBK.Rows[i - 5]["HH_HANSUDUNG"].ToString()).ToShortDateString() : "";
                        chartRange = xlWorkSheet.get_Range("n" + i, "n" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 15] = dtBK.Rows[i - 5 - countRow]["NPP_TENNPP"].ToString();
                        chartRange = xlWorkSheet.get_Range("o" + i, "o" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 16] = dtBK.Rows[i - 5 - countRow]["KH_TENKHO"].ToString();
                        chartRange = xlWorkSheet.get_Range("p" + i, "p" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                    }

                    vOldHH = vNewHH;
                    sumRow = i;

                    vTongSoLuong += double.Parse(dtBK.Rows[i - 5]["HDNX_SOLUONG"].ToString());
                    vTongThanhTien += double.Parse(dtBK.Rows[i - 5]["HDNX_THANHTIEN"].ToString());
                }
                chartRange = xlWorkSheet.get_Range("b4", "p" + sumRow);
                chartRange.BorderAround(
                    Excel.XlLineStyle.xlContinuous,
                    Excel.XlBorderWeight.xlThin,
                    Excel.XlColorIndex.xlColorIndexAutomatic,
                    Excel.XlColorIndex.xlColorIndexAutomatic);

                chartRange = xlWorkSheet.get_Range("h5", "p" + sumRow);
                chartRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            }
            catch
            {

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
                dtBK.Clear();
                string vMaKho = "KHO000001";
                DateTime vTuNgay = dateTuNgay.DateTime;
                DateTime vDenNgay = dateDenNgay.DateTime;
                dtBK = ClassController.bangKeTraHang(vMaKho, vTuNgay, vDenNgay, cbxCaNam.Checked);

                decimal vDonGia = 0;
                decimal vTongDonGia = 0;
                decimal vGiamKhac = (-Decimal.Parse(dtBK.Rows[0]["HDNX_GIAMKHAC"].ToString()));
                decimal vChiecKhau = (Decimal.Parse(dtBK.Rows[0]["HDNX_CHIECKHAU"].ToString()));
                decimal vTienChiecKhau = 0;
                decimal vTongThanhToan = 0;

                for (int i = 0; i < dtBK.Rows.Count; i++)
                {
                    vDonGia = (-Decimal.Parse(dtBK.Rows[i]["HDNX_TONGBAN"].ToString()));
                    vTongDonGia += vDonGia;
                    dtBK.Rows[i]["HDNX_SOLUONG"] = (double.Parse(dtBK.Rows[i]["HDNX_SOLUONG"].ToString())).ToString();
                    dtBK.Rows[i]["HDNX_TONGBAN"] = (Decimal.Parse(dtBK.Rows[i]["HDNX_TONGBAN"].ToString())).ToString();
                    dtBK.Rows[i]["HDNX_THANHTIEN"] = (Decimal.Parse(dtBK.Rows[i]["HDNX_THANHTIEN"].ToString())).ToString();
                    dtBK.Rows[i]["HDNX_GIAMKHAC"] = (Decimal.Parse(dtBK.Rows[i]["HDNX_GIAMKHAC"].ToString())).ToString();
                }

                vTienChiecKhau = (vTongDonGia * vChiecKhau) / 100;
                vTongThanhToan = vTongDonGia - (vGiamKhac + vTienChiecKhau);
                gridControl1.DataSource = dtBK;

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

        private void gridView1_CellMerge(object sender, CellMergeEventArgs e)
        {
            //if (e.Column.FieldName == "HDNX_CHIECKHAU")
            //{
            //    int value1 = Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle1, e.Column));
            //    int value2 = Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle2, e.Column));
            //    if (Math.Sign(value1) == Math.Sign(value2))
            //    {
            //        e.Merge = true;
            //        e.Handled = true;
            //    }
            //}
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            //if (e.Column.FieldName == "HDNX_CHIECKHAU")
            //{
            //    switch (Math.Sign(Convert.ToInt32(e.CellValue)))
            //    {
            //        case -1:
            //            e.DisplayText = "Negative";
            //            break;
            //        case 0:
            //            e.DisplayText = "Zero";
            //            break;
            //        case 1:
            //            e.DisplayText = "Positive";
            //            break;
            //        default:
            //            break;
            //    }
            //}
        }
    
    }
}
