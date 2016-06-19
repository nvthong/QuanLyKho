using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLK
{ 
    public partial class frmHTCauHinhUngDung : Form
    {
        public frmHTCauHinhUngDung()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switch ((e.Action))
            {
                case TreeViewAction.ByKeyboard:
                    callForm(e.Node.Name.ToString());
                    break;
                case TreeViewAction.ByMouse:
                    callForm(e.Node.Name.ToString());
                    break;
            }
        }

        public void callForm(string pFormName)
        {
            switch(pFormName)
            {
                case "CHUNG":
                    pnCauHinh.Controls.Clear();
                    frmHTCauHinhChung frmObject = new frmHTCauHinhChung();
                    frmObject.TopLevel = false;
                    frmObject.AutoScroll = true;       
                    pnCauHinh.Controls.Add(frmObject);
                    frmObject.Show();
                    break;
                case "GIAODIEN":
                    break;
                case "HOADON":
                    break;
                case "BAOCAO":
                    break;
            }
        }
    }
}
