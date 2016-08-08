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
    public partial class frmShowKhachHang : Form
    {
        public string dvtMa;
        public string dvtTen;
        List<DM_NHAPHANPHOI> listNPP = new List<DM_NHAPHANPHOI>();
        public frmShowKhachHang()
        {
            InitializeComponent();
            loadData();
        }

        public void loadData()
        {
            try
            {
                SqlDataReader dr;
                using (SqlConnection connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    DataTable dtDVT = new DataTable();
                    SqlCommand sqlCmd = new SqlCommand("SelectDmKhachhangsAll", connect);
                    sqlCmd.CommandTimeout = 1000;
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
                            DM_NHAPHANPHOI obj = new DM_NHAPHANPHOI();
                            obj.NPP_MANPP = dr["NPP_MANPP"].ToString();
                            obj.NPP_TENNPP = dr["NPP_TENNPP"].ToString();
                            obj.NPP_GHICHU = dr["NPP_GHICHU"].ToString();
                            listNPP.Add(obj);
                        }
                    }
                    gridDVT.DataSource = listNPP;
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
                    dvtMa = gridView1.GetFocusedRowCellValue("NPP_MANPP").ToString();
                    dvtTen = gridView1.GetFocusedRowCellValue("NPP_TENNPP").ToString();
                    this.Close();
                }
            }
            catch
            {

            }
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            try
            {
                dvtMa = gridView1.GetFocusedRowCellValue("NPP_MANPP").ToString();
                dvtTen = gridView1.GetFocusedRowCellValue("NPP_TENNPP").ToString();
                this.Close();
            }
            catch
            {

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
                dvtMa = gridView1.GetFocusedRowCellValue("NPP_MANPP").ToString();
                dvtTen = gridView1.GetFocusedRowCellValue("NPP_TENNPP").ToString();
                this.Close();
            }
            catch
            {

            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        public void search()
        {
            string vKeyWord = txtTimKiem.Text.Trim();
            List<DM_NHAPHANPHOI> listSearch = new List<DM_NHAPHANPHOI>();
            listSearch = listNPP.Where(
                x => (x.NPP_MANPP.ToLower().Contains(vKeyWord.ToLower()) || x.NPP_TENNPP.ToLower().Contains(vKeyWord.ToLower())) ||
                    (x.NPP_MANPP.ToLower().StartsWith(vKeyWord.ToLower()) || x.NPP_TENNPP.ToLower().EndsWith(vKeyWord.ToLower())) ||
                    (x.NPP_MANPP.ToLower().StartsWith(vKeyWord.ToLower()) || x.NPP_TENNPP.ToLower().EndsWith(vKeyWord.ToLower()))
                ).ToList();

            if (listSearch.Count > 0)
            {
                gridDVT.DataSource = listSearch;
            }
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gridDVT.Focus();
            }
        }

    }
}
