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
    public partial class frmTienIchMoKhoaSo : Form
    {
        public frmTienIchMoKhoaSo()
        {
            InitializeComponent();
            DisplayKhoaSo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnKhoa_Click(object sender, EventArgs e)
        {
            if(txtTuNgay.DateTime.Year < 2000)
            {
                MessageBox.Show("Từ ngày không hợp lệ");
                return;
            }

            if (txtDenNgay.DateTime.Year < 2000)
            {
                MessageBox.Show("Đến ngày không hợp lệ");
                return;
            }

            DateTime pTuNgay = txtTuNgay.DateTime;
            DateTime pDenNgay = txtDenNgay.DateTime;
            for (var day = pTuNgay.Date; day.Date <= pDenNgay.Date; day = day.AddDays(1))
            {
                HT_KHOASO obj = new HT_KHOASO();
                obj.KS_NGAY = day.Date;
                obj.KS_KHOA = 1;
                obj.KS_GHICHU = txtGhiChu.Text.Trim();
                if(ClassController.selectKhoaSoByDay(day.Date).KS_NGAY.Year == 0001)
                {
                    ClassController.insertKhoaSo(obj);
                }
                else
                {
                    ClassController.updateKhoaSo(obj);
                }
            }
            DisplayKhoaSo();
        }

        private void btnMoKhoa_Click(object sender, EventArgs e)
        {
            if (txtTuNgay.DateTime.Year < 2000)
            {
                MessageBox.Show("Từ ngày không hợp lệ");
                return;
            }

            if (txtDenNgay.DateTime.Year < 2000)
            {
                MessageBox.Show("Đến ngày không hợp lệ");
                return;
            }

            DateTime pTuNgay = txtTuNgay.DateTime;
            DateTime pDenNgay = txtDenNgay.DateTime;
            for (var day = pTuNgay.Date; day.Date <= pDenNgay.Date; day = day.AddDays(1))
            {
                HT_KHOASO obj = new HT_KHOASO();
                obj.KS_NGAY = day.Date;
                obj.KS_KHOA = 0;
                obj.KS_GHICHU = txtGhiChu.Text.Trim();
                if (ClassController.selectKhoaSoByDay(day.Date).KS_NGAY.Year == 0001)
                {
                    ClassController.insertKhoaSo(obj);
                }
                else
                {
                    ClassController.updateKhoaSo(obj);
                }
            }
            DisplayKhoaSo();
        }

        public void DisplayKhoaSo()
        {
            gridControl1.DataSource = ClassController.layDanhSachKhoaSo();
        }
                
    }
}
