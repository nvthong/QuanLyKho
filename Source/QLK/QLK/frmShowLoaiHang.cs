using DevExpress.XtraEditors;
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
    public partial class frmShowLoaiHang : Form
    {
        public frmShowLoaiHang()
        {
            InitializeComponent();
            loadData();
        }

        private readonly frmDMHangHoa form;
        public frmShowLoaiHang(frmDMHangHoa form)
        {
            this.form = form;
        }

        public void loadData()
        {
            try
            {
                using (SqlConnection connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    DataTable dtDVT = new DataTable();
                    SqlCommand sqlCmd = new SqlCommand("SelectDmhhLoaihangsAll", connect);
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

        private void gridDVT_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == System.Windows.Forms.Keys.Enter)
                {
                    string dvtMa = gridView1.GetFocusedRowCellValue("LH_MALOAI").ToString();
                    string dvtTen = gridView1.GetFocusedRowCellValue("LH_TENLOAI").ToString();
                    frmDMHangHoa._frmDMHangHoa.updateLoaiHang(dvtMa, dvtTen);
                    this.Close();
                }
            }catch
            {

            }
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            try
            {
                string dvtMa = gridView1.GetFocusedRowCellValue("LH_MALOAI").ToString();
                string dvtTen = gridView1.GetFocusedRowCellValue("LH_TENLOAI").ToString();
                frmDMHangHoa._frmDMHangHoa.updateLoaiHang(dvtMa, dvtTen);
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
    }
}
