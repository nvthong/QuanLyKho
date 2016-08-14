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
    public partial class frmBaoCaoLaiLo : Form
    {
        List<BAOCAO_LAILO> objBC = new List<BAOCAO_LAILO>();
        public frmBaoCaoLaiLo()
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

            xlWorkSheet.get_Range("b2", "o3").Merge(false);

            chartRange = xlWorkSheet.get_Range("b2", "o3");
            chartRange.FormulaR1C1 = "BÁO CÁO LÃI LỖ";
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
            xlWorkSheet.Cells[4, 3] = "Số hóa đơn";
            chartRange = xlWorkSheet.get_Range("c4", "c4");
            chartRange.BorderAround(
                Excel.XlLineStyle.xlContinuous,
                Excel.XlBorderWeight.xlThin,
                Excel.XlColorIndex.xlColorIndexAutomatic,
                Excel.XlColorIndex.xlColorIndexAutomatic);
            xlWorkSheet.Cells[4, 4] = "Ngày hóa đơn";
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
            xlWorkSheet.Cells[4, 8] = "Số lượng";
            chartRange = xlWorkSheet.get_Range("h4", "h4");
            chartRange.BorderAround(
                Excel.XlLineStyle.xlContinuous,
                Excel.XlBorderWeight.xlThin,
                Excel.XlColorIndex.xlColorIndexAutomatic,
                Excel.XlColorIndex.xlColorIndexAutomatic);
            xlWorkSheet.Cells[4, 9] = "Tổng nhập";
            chartRange = xlWorkSheet.get_Range("i4", "i4");
            chartRange.BorderAround(
                Excel.XlLineStyle.xlContinuous,
                Excel.XlBorderWeight.xlThin,
                Excel.XlColorIndex.xlColorIndexAutomatic,
                Excel.XlColorIndex.xlColorIndexAutomatic);
            xlWorkSheet.Cells[4, 10] = "Tổng VAT";
            chartRange = xlWorkSheet.get_Range("j4", "j4");
            chartRange.BorderAround(
                Excel.XlLineStyle.xlContinuous,
                Excel.XlBorderWeight.xlThin,
                Excel.XlColorIndex.xlColorIndexAutomatic,
                Excel.XlColorIndex.xlColorIndexAutomatic);
            xlWorkSheet.Cells[4, 11] = "Tổng bán";
            chartRange = xlWorkSheet.get_Range("k4", "k4");
            chartRange.BorderAround(
                Excel.XlLineStyle.xlContinuous,
                Excel.XlBorderWeight.xlThin,
                Excel.XlColorIndex.xlColorIndexAutomatic,
                Excel.XlColorIndex.xlColorIndexAutomatic);
            xlWorkSheet.Cells[4, 12] = "Chiếc khấu";
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
            xlWorkSheet.Cells[4, 14] = "Lãi";
            chartRange = xlWorkSheet.get_Range("n4", "n4");
            chartRange.BorderAround(
                Excel.XlLineStyle.xlContinuous,
                Excel.XlBorderWeight.xlThin,
                Excel.XlColorIndex.xlColorIndexAutomatic,
                Excel.XlColorIndex.xlColorIndexAutomatic);
            xlWorkSheet.Cells[4, 15] = "Lỗ";
            chartRange = xlWorkSheet.get_Range("o4", "o4");
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

            string vNewHH = "";
            string vOldHH = "";
            int countRow = 0;
            int sumRow = 0;
            try
            {
                objBC = objBC.OrderBy(x => x.HH_MAHANG).ToList();
                for (int i = 5; i < (objBC.Count + 5 + (countRow)); i++)
                {
                    vNewHH = objBC[i - 5 - countRow].HH_MAHANG.ToString();
                    if (vOldHH == "" && vNewHH != "")
                    {
                        xlWorkSheet.Cells[i, 2] = (i - 4).ToString();
                        chartRange = xlWorkSheet.get_Range("b" + i, "b" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 3] = objBC[i - 5].HDNX_SOHDNB.ToString();
                        chartRange = xlWorkSheet.get_Range("c" + i, "c" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 4] = objBC[i - 5].HDNX_NGAYHD.ToShortDateString();
                        chartRange = xlWorkSheet.get_Range("d" + i, "d" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 5] = objBC[i - 5].HH_MAHANG.ToString();
                        chartRange = xlWorkSheet.get_Range("e" + i, "e" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 6] = objBC[i - 5].HH_TENHANG.ToString();
                        chartRange = xlWorkSheet.get_Range("f" + i, "f" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 7] = objBC[i - 5].DVT_TENDONVI.ToString();
                        chartRange = xlWorkSheet.get_Range("g" + i, "g" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 8] = objBC[i - 5].HDNX_SOLUONG.ToString();
                        chartRange = xlWorkSheet.get_Range("h" + i, "h" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 9] = double.Parse(objBC[i - 5].HDNX_TONGMUA.ToString()).ToString();
                        chartRange = xlWorkSheet.get_Range("i" + i, "i" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 10] = double.Parse(objBC[i - 5].HDNX_TONGVAT.ToString()).ToString();
                        chartRange = xlWorkSheet.get_Range("j" + i, "j" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 11] = double.Parse(objBC[i - 5].HDNX_TONGBAN.ToString()).ToString();
                        chartRange = xlWorkSheet.get_Range("k" + i, "k" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 12] = double.Parse(objBC[i - 5].HDNX_TONGCHIECKHAU.ToString()).ToString();
                        chartRange = xlWorkSheet.get_Range("l" + i, "l" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 13] = double.Parse(objBC[i - 5].HDNX_THANHTIEN.ToString()).ToString();
                        chartRange = xlWorkSheet.get_Range("m" + i, "m" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 14] = double.Parse(objBC[i - 5].HDNX_LAI.ToString()).ToString();
                        chartRange = xlWorkSheet.get_Range("n" + i, "n" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 15] = double.Parse(objBC[i - 5].HDNX_LO.ToString()).ToString();
                        chartRange = xlWorkSheet.get_Range("o" + i, "o" + i);
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
                        xlWorkSheet.Cells[i, 3] = objBC[i - 5 - countRow].HDNX_SOHDNB.ToString();
                        chartRange = xlWorkSheet.get_Range("c" + i, "c" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 4] = objBC[i - 5 - countRow].HDNX_NGAYHD.ToShortDateString();
                        chartRange = xlWorkSheet.get_Range("d" + i, "d" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 5] = objBC[i - 5 - countRow].HH_MAHANG.ToString();
                        chartRange = xlWorkSheet.get_Range("e" + i, "e" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 6] = objBC[i - 5 - countRow].HH_TENHANG.ToString();
                        chartRange = xlWorkSheet.get_Range("f" + i, "f" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 7] = objBC[i - 5 - countRow].DVT_TENDONVI.ToString();
                        chartRange = xlWorkSheet.get_Range("g" + i, "g" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 8] = objBC[i - 5 - countRow].HDNX_SOLUONG.ToString();
                        chartRange = xlWorkSheet.get_Range("h" + i, "h" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 9] = double.Parse(objBC[i - 5 - countRow].HDNX_TONGMUA.ToString()).ToString();
                        chartRange = xlWorkSheet.get_Range("i" + i, "i" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 10] = double.Parse(objBC[i - 5 - countRow].HDNX_TONGVAT.ToString()).ToString();
                        chartRange = xlWorkSheet.get_Range("j" + i, "j" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 11] = double.Parse(objBC[i - 5 - countRow].HDNX_TONGBAN.ToString()).ToString();
                        chartRange = xlWorkSheet.get_Range("k" + i, "k" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 12] = double.Parse(objBC[i - 5 - countRow].HDNX_TONGCHIECKHAU.ToString()).ToString();
                        chartRange = xlWorkSheet.get_Range("l" + i, "l" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 13] = double.Parse(objBC[i - 5 - countRow].HDNX_THANHTIEN.ToString()).ToString();
                        chartRange = xlWorkSheet.get_Range("m" + i, "m" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 14] = double.Parse(objBC[i - 5 - countRow].HDNX_LAI.ToString()).ToString();
                        chartRange = xlWorkSheet.get_Range("n" + i, "n" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 15] = double.Parse(objBC[i - 5 - countRow].HDNX_LO.ToString()).ToString();
                        chartRange = xlWorkSheet.get_Range("o" + i, "o" + i);
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
                        chartRange = xlWorkSheet.get_Range("b" + i, "b" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 3] = "";
                        chartRange = xlWorkSheet.get_Range("c" + i, "c" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 4] = "";
                        chartRange = xlWorkSheet.get_Range("d" + i, "d" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 5] = "";
                        chartRange = xlWorkSheet.get_Range("e" + i, "e" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 6] = "";
                        chartRange = xlWorkSheet.get_Range("f" + i, "f" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 7] = "";
                        chartRange = xlWorkSheet.get_Range("g" + i, "g" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 8] = "";
                        chartRange = xlWorkSheet.get_Range("h" + i, "h" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 9] = "";
                        chartRange = xlWorkSheet.get_Range("i" + i, "i" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 10] = "";
                        chartRange = xlWorkSheet.get_Range("j" + i, "j" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 11] = "";
                        chartRange = xlWorkSheet.get_Range("k" + i, "k" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 12] = "";
                        chartRange = xlWorkSheet.get_Range("l" + i, "l" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 13] = "";
                        chartRange = xlWorkSheet.get_Range("m" + i, "m" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 14] = "";
                        chartRange = xlWorkSheet.get_Range("n" + i, "n" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 15] = "";
                        chartRange = xlWorkSheet.get_Range("o" + i, "o" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);

                        //
                        xlWorkSheet.Cells[i, 2] = (i - 4 - countRow).ToString();
                        chartRange = xlWorkSheet.get_Range("b" + i, "b" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 3] = objBC[i - 5 - countRow].HDNX_SOHDNB.ToString();
                        chartRange = xlWorkSheet.get_Range("c" + i, "c" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 4] = objBC[i - 5 - countRow].HDNX_NGAYHD.ToShortDateString();
                        chartRange = xlWorkSheet.get_Range("d" + i, "d" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 5] = objBC[i - 5 - countRow].HH_MAHANG.ToString();
                        chartRange = xlWorkSheet.get_Range("e" + i, "e" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 6] = objBC[i - 5 - countRow].HH_TENHANG.ToString();
                        chartRange = xlWorkSheet.get_Range("f" + i, "f" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 7] = objBC[i - 5 - countRow].DVT_TENDONVI.ToString();
                        chartRange = xlWorkSheet.get_Range("g" + i, "g" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 8] = objBC[i - 5 - countRow].HDNX_SOLUONG.ToString();
                        chartRange = xlWorkSheet.get_Range("h" + i, "h" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 9] = double.Parse(objBC[i - 5 - countRow].HDNX_TONGMUA.ToString()).ToString();
                        chartRange = xlWorkSheet.get_Range("i" + i, "i" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 10] = double.Parse(objBC[i - 5 - countRow].HDNX_TONGVAT.ToString()).ToString();
                        chartRange = xlWorkSheet.get_Range("j" + i, "j" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 11] = double.Parse(objBC[i - 5 - countRow].HDNX_TONGBAN.ToString()).ToString();
                        chartRange = xlWorkSheet.get_Range("k" + i, "k" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 12] = double.Parse(objBC[i - 5 - countRow].HDNX_TONGCHIECKHAU.ToString()).ToString();
                        chartRange = xlWorkSheet.get_Range("l" + i, "l" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 13] = double.Parse(objBC[i - 5 - countRow].HDNX_THANHTIEN.ToString()).ToString();
                        chartRange = xlWorkSheet.get_Range("m" + i, "m" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 14] = double.Parse(objBC[i - 5 - countRow].HDNX_LAI.ToString()).ToString();
                        chartRange = xlWorkSheet.get_Range("n" + i, "n" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                        xlWorkSheet.Cells[i, 15] = double.Parse(objBC[i - 5 - countRow].HDNX_LO.ToString()).ToString();
                        chartRange = xlWorkSheet.get_Range("o" + i, "o" + i);
                        chartRange.BorderAround(
                            Excel.XlLineStyle.xlContinuous,
                            Excel.XlBorderWeight.xlThin,
                            Excel.XlColorIndex.xlColorIndexAutomatic,
                            Excel.XlColorIndex.xlColorIndexAutomatic);
                    }
                    vOldHH = vNewHH;
                    sumRow = i;
                }

                chartRange = xlWorkSheet.get_Range("b4", "o" + sumRow);
                chartRange.BorderAround(
                    Excel.XlLineStyle.xlContinuous,
                    Excel.XlBorderWeight.xlThin,
                    Excel.XlColorIndex.xlColorIndexAutomatic,
                    Excel.XlColorIndex.xlColorIndexAutomatic);

                chartRange = xlWorkSheet.get_Range("h5", "o" + sumRow);
                chartRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            }catch
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
                DateTime vTuNgay = dateTuNgay.DateTime;
                DateTime vDenNgay = dateDenNgay.DateTime;
                DataTable dt = new DataTable();

                objBC.Clear();
                objBC = ClassController.BaoCaoLaiLo(vTuNgay, vDenNgay, chkCaNam.Checked);

                //if (!chkVATTrungBinh.Checked)
                //{
                //    objBC = objBC.Where(x => x.HH_KICHHOAT == 1).ToList();
                //}

                foreach (var item in objBC)
                {
                    decimal vLaiLo = 0;
                    if (item.HDNX_TRAHANG == 0)
                    {
                        item.HDNX_SOLUONG = -item.HDNX_SOLUONG;
                        item.HDNX_TONGBAN = -item.HDNX_TONGBAN;
                        item.HDNX_THANHTIEN = -item.HDNX_THANHTIEN;

                        decimal vTongTienNhap = item.HDNX_TONGMUA + item.HDNX_TONGVAT;
                        decimal vTongTienXuat = item.HDNX_THANHTIEN;

                        vLaiLo = vTongTienXuat - vTongTienNhap;
                        if (vLaiLo >= 0)
                        {
                            item.HDNX_LAI = vLaiLo;
                        }
                        else
                        {
                            item.HDNX_LO = -vLaiLo;
                        }
                    }
                    else
                    {
                        item.HDNX_SOLUONG = -item.HDNX_SOLUONG;
                        item.HDNX_TONGBAN = -item.HDNX_TONGBAN;
                        item.HDNX_THANHTIEN = -item.HDNX_THANHTIEN;

                        decimal vTongTienNhap = item.HDNX_TONGMUA + item.HDNX_TONGVAT;
                        decimal vTongTienXuat = item.HDNX_THANHTIEN;

                        vLaiLo = (-vTongTienXuat) - vTongTienNhap;
                        if (vLaiLo >= 0)
                        {
                            item.HDNX_LAI = -vLaiLo;
                        }
                        else
                        {
                            item.HDNX_LO = vLaiLo;
                        }
                    }
                }
                gridControl1.DataSource = objBC;
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
    }
}
