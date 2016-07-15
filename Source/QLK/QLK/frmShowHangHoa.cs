using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLK
{
    public partial class frmShowHangHoa : Form
    {
        public string pHhMa;
        public string pHhTen;
        public string pHhDVT;
        public string pHhGiaNhap;
        public string pHhGiaBan;
        public string pHhGiaBanSi;
        public double pHhTonKho = 0;
        public frmShowHangHoa()
        {
            InitializeComponent();
            loadData();
        }

        public frmShowHangHoa(string pMaKho)
        {
            InitializeComponent();
            loadData(pMaKho);
        }

        public void loadData()
        {
            try
            {
                using (SqlConnection connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    DataTable dtDVT = new DataTable();
                    SqlCommand sqlCmd = new SqlCommand("SelectDmhhHanghoasAllRefTonKho", connect);
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

        public void loadData(string pMaKho)
        {
            try
            {
                using (SqlConnection connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    DataTable dtDVT = new DataTable();
                    SqlCommand sqlCmd = new SqlCommand("SelectDmhhHanghoasAllRefTonKhoByKhoHang", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.Parameters.AddWithValue("@KH_MAKHO", pMaKho);
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

        private void gridDVT_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == System.Windows.Forms.Keys.Enter)
                {
                    pHhMa = gridView1.GetFocusedRowCellValue("HH_MAHANG").ToString();
                    pHhTen = gridView1.GetFocusedRowCellValue("HH_TENHANG").ToString();
                    pHhDVT = gridView1.GetFocusedRowCellValue("DVT_TENDONVI").ToString();
                    pHhGiaNhap = gridView1.GetFocusedRowCellValue("HH_GIAMUA").ToString();
                    pHhGiaBan = gridView1.GetFocusedRowCellValue("HH_GIABANLE").ToString();
                    pHhGiaBanSi = gridView1.GetFocusedRowCellValue("HH_GIABANSI").ToString();
                    pHhTonKho = gridView1.GetFocusedRowCellValue("TONKHO").ToString() != "" ? Double.Parse(gridView1.GetFocusedRowCellValue("TONKHO").ToString()) : 0;
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            try
            {
                pHhMa = gridView1.GetFocusedRowCellValue("HH_MAHANG").ToString();
                pHhTen = gridView1.GetFocusedRowCellValue("HH_TENHANG").ToString();
                pHhDVT = gridView1.GetFocusedRowCellValue("DVT_TENDONVI").ToString();
                pHhGiaNhap = gridView1.GetFocusedRowCellValue("HH_GIAMUA").ToString();
                pHhGiaBan = gridView1.GetFocusedRowCellValue("HH_GIABANLE").ToString();
                pHhGiaBanSi = gridView1.GetFocusedRowCellValue("HH_GIABANSI").ToString();
                pHhTonKho = gridView1.GetFocusedRowCellValue("TONKHO").ToString() != "" ? Double.Parse(gridView1.GetFocusedRowCellValue("TONKHO").ToString()) : 0;
                this.Close();
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

        private void gridDVT_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                pHhMa = gridView1.GetFocusedRowCellValue("HH_MAHANG").ToString();
                pHhTen = gridView1.GetFocusedRowCellValue("HH_TENHANG").ToString();
                pHhDVT = gridView1.GetFocusedRowCellValue("DVT_TENDONVI").ToString();
                pHhGiaNhap = gridView1.GetFocusedRowCellValue("HH_GIAMUA").ToString();
                pHhGiaBan = gridView1.GetFocusedRowCellValue("HH_GIABANLE").ToString();
                pHhGiaBanSi = gridView1.GetFocusedRowCellValue("HH_GIABANSI").ToString();
                pHhTonKho = gridView1.GetFocusedRowCellValue("TONKHO").ToString() != "" ? Double.Parse(gridView1.GetFocusedRowCellValue("TONKHO").ToString()) : 0;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
