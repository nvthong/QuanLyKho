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
    public partial class frmShowNhaPhanPhoi : Form
    {
        public string dvtMa;
        public string dvtTen;
        public frmShowNhaPhanPhoi()
        {
            InitializeComponent();
            loadData();
        }

        private readonly frmDMHangHoa form;
        public frmShowNhaPhanPhoi(frmDMHangHoa form)
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
                    SqlCommand sqlCmd = new SqlCommand("SelectDmNhaphanphoisAll", connect);
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
                    dvtMa = gridView1.GetFocusedRowCellValue("NPP_MANPP").ToString();
                    dvtTen = gridView1.GetFocusedRowCellValue("NPP_TENNPP").ToString();
                    frmDMHangHoa._frmDMHangHoa.updateNhaPhanPhoi(dvtMa, dvtTen);
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
                frmDMHangHoa._frmDMHangHoa.updateNhaPhanPhoi(dvtMa, dvtTen);
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
