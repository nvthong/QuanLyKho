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
        List<SHOW_HANGHOA> listHangHoa = new List<SHOW_HANGHOA>();
        public frmShowHangHoa()
        {
            InitializeComponent();
            loadData();
        }

        public frmShowHangHoa(string pMaKho)
        {
            InitializeComponent();
            loadData(pMaKho);
            gridDVT.DataSource = listHangHoa;
            txtTim.Focus();
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
                SqlDataReader dr;
                using (SqlConnection connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    DataTable dtDVT = new DataTable();
                    SqlCommand sqlCmd = new SqlCommand("SelectDmhhHanghoasAllRefTonKhoByKhoHang", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.Parameters.AddWithValue("@KH_MAKHO", pMaKho);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    //SqlDataAdapter da = new SqlDataAdapter();
                    //da.SelectCommand = sqlCmd;
                    //da.Fill(dtDVT);
                    //gridDVT.DataSource = dtDVT;

                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            SHOW_HANGHOA obj = new SHOW_HANGHOA();
                            obj.HH_MAHANG = dr["HH_MAHANG"].ToString();
                            obj.HH_TENHANG = dr["HH_TENHANG"].ToString();
                            obj.HH_GHICHU = dr["HH_GHICHU"].ToString();
                            obj.HH_GIABANLE = dr["HH_GIABANLE"].ToString() != "" ? Decimal.Parse(dr["HH_GIABANLE"].ToString()) : 0;
                            obj.HH_GIABANSI = dr["HH_GIABANSI"].ToString() != "" ? Decimal.Parse(dr["HH_GIABANSI"].ToString()) : 0;
                            obj.HH_GIAMUA = dr["HH_GIAMUA"].ToString() != "" ? Decimal.Parse(dr["HH_GIAMUA"].ToString()) : 0;
                            obj.DVT_TENDONVI = dr["DVT_TENDONVI"].ToString();
                            obj.TONKHO = dr["TONKHO"].ToString() != "" ? Double.Parse(dr["TONKHO"].ToString()) : 0;
                            listHangHoa.Add(obj);
                        }
                    }
                    connect.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void search()
        {
            string vKeyWord = txtTim.Text.Trim();
            List<SHOW_HANGHOA> listSearch = new List<SHOW_HANGHOA>();
            listSearch = listHangHoa.Where(
                x => (x.HH_MAHANG.ToLower().Contains(vKeyWord.ToLower()) || x.HH_TENHANG.ToLower().Contains(vKeyWord.ToLower())) ||
                    (x.HH_TENHANG.ToLower().StartsWith(vKeyWord.ToLower()) || x.HH_TENHANG.ToLower().EndsWith(vKeyWord.ToLower())) ||
                    (x.HH_MAHANG.ToLower().StartsWith(vKeyWord.ToLower()) || x.HH_MAHANG.ToLower().EndsWith(vKeyWord.ToLower()))
                ).ToList();

            if (listSearch.Count > 0)
            {
                gridDVT.DataSource = listSearch;
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

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            search();
        }

        private void txtTim_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gridDVT.Focus();
            }
        }
    }
}
