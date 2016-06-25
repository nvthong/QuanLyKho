using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLK
{
    public partial class frmHTCauHinhKetNoi : Form
    {
        public frmHTCauHinhKetNoi()
        {
            InitializeComponent();
            try
            {
                this.txtMayChu.Text = Properties.Settings.Default.ServerName.ToString();
                this.txtCong.Text = Properties.Settings.Default.ServerPort.ToString();
                this.txtCSDL.Text = Properties.Settings.Default.Database.ToString();
                this.txtTaiKhoan.Text = Properties.Settings.Default.Username.ToString();
                this.txtMatKhau.Text = Properties.Settings.Default.Password.ToString();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCapNhat_Click_1(object sender, EventArgs e)
        {
            Properties.Settings.Default.ServerName = this.txtMayChu.Text.ToString().Trim();
            Properties.Settings.Default.ServerPort = this.txtCong.Text.ToString().Trim();
            Properties.Settings.Default.Database = this.txtCSDL.Text.ToString().Trim();
            Properties.Settings.Default.Username = this.txtTaiKhoan.Text.ToString().Trim();
            Properties.Settings.Default.Password = this.txtMatKhau.Text.ToString().Trim();
            Properties.Settings.Default.Save();

            try
            {
                SqlConnection myConnection = ClassController.ConnectDatabase();
                if (myConnection.State == ConnectionState.Closed)
                    myConnection.Open();

                MessageBox.Show("Kết nối thành công!", "Quản Lý Kho", MessageBoxButtons.OK, MessageBoxIcon.Information);
                myConnection.Close();
            }
            catch
            {
                MessageBox.Show("Không thể kết nối!", "Quản Lý Kho", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
