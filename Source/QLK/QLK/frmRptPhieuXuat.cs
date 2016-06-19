using Microsoft.Reporting.WinForms;
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
    public partial class frmRptPhieuXuatKho : Form
    {
        public frmRptPhieuXuatKho()
        {
            InitializeComponent();
        }

        public frmRptPhieuXuatKho(DataTable pDt,
            string pTitle,
            string pSoHD, 
            string pNgayHD, 
            string pTongHD, 
            string pTraHang, 
            string pChiecKhau,
            string pGiamGia, 
            string pTongThanhToan, 
            string pTienKhachTra, 
            string pTienThoiLai)
        {
            InitializeComponent();

            List<HT_CAUHINH> objListCH = new List<HT_CAUHINH>();
            objListCH = ClassController.loadCauHinh();

            string vReNameCompany = objListCH.Where(x => x.CH_MACH == "CH_HOADON_TENCONGTY_TIENTO").FirstOrDefault().CH_GIATRI;
            string vCompanyName = objListCH.Where(x => x.CH_MACH == "CH_HOADON_TENCONGTY").FirstOrDefault().CH_GIATRI;
            string vFax = objListCH.Where(x => x.CH_MACH == "CH_HOADON_FAX").FirstOrDefault().CH_GIATRI;
            string vAddress = objListCH.Where(x => x.CH_MACH == "CH_HOADON_DIACHI").FirstOrDefault().CH_GIATRI;
            string vPhone = objListCH.Where(x => x.CH_MACH == "CH_HOADON_SODIENTHOAI").FirstOrDefault().CH_GIATRI;
            string vFooterTitle = objListCH.Where(x => x.CH_MACH == "CH_HOADON_FOOTERTITLE").FirstOrDefault().CH_GIATRI;
            string vLogo = objListCH.Where(x => x.CH_MACH == "CH_HOADON_LOGO").FirstOrDefault().CH_GIATRI;

            rptViewerPhieuXuatSi.Reset();
            rptViewerPhieuXuatSi.LocalReport.ReportEmbeddedResource = "QLK.rptPhieuXuat.rdlc";
            rptViewerPhieuXuatSi.LocalReport.DataSources.Clear();
            ReportDataSource newDataSource = new ReportDataSource("dsPhieuXuatSi", pDt);
            rptViewerPhieuXuatSi.LocalReport.DataSources.Add(newDataSource);
            
            List<ReportParameter> listParameter = new List<ReportParameter>();
            ReportParameter rpRenameCompany = new ReportParameter("pRenameCompany", vReNameCompany);
            listParameter.Add(rpRenameCompany);

            ReportParameter rpNameCompany = new ReportParameter("pNameCompany", vCompanyName);
            listParameter.Add(rpNameCompany);

            ReportParameter rpImgLogo = new ReportParameter("pImgLogo", vLogo);
            listParameter.Add(rpImgLogo);

            ReportParameter rpAddress = new ReportParameter("pAddress", vAddress);
            listParameter.Add(rpAddress);

            ReportParameter rpPhone = new ReportParameter("pPhone", vPhone);
            listParameter.Add(rpPhone);

            ReportParameter rpFax = new ReportParameter("pFax", vFax);
            listParameter.Add(rpFax);

            ReportParameter rpTitle = new ReportParameter("pTitle", pTitle);
            listParameter.Add(rpTitle);

            ReportParameter rpSoHoaDon = new ReportParameter("pSoHoaDon", pSoHD);
            listParameter.Add(rpSoHoaDon);

            ReportParameter rpNgay = new ReportParameter("pNgay", pNgayHD);
            listParameter.Add(rpNgay);

            ReportParameter rpTongHoaDon = new ReportParameter("pTongHoaDon", pTongHD);
            listParameter.Add(rpTongHoaDon);

            ReportParameter rpTraHang = new ReportParameter("pTraHang", pTraHang);
            listParameter.Add(rpTraHang);

            ReportParameter rpGiamGia = new ReportParameter("pGiamGia", pGiamGia);
            listParameter.Add(rpGiamGia);

            ReportParameter rpChiecKhau = new ReportParameter("pChiecKhau", pChiecKhau);
            listParameter.Add(rpChiecKhau);

            ReportParameter rpTongThanhToan = new ReportParameter("pTongThanhToan", pTongThanhToan);
            listParameter.Add(rpTongThanhToan);

            ReportParameter rpTienKhachTra = new ReportParameter("pTienKhachTra", pTienKhachTra);
            listParameter.Add(rpTienKhachTra);

            ReportParameter rpTienThoiLai = new ReportParameter("pTienThoiLai", pTienThoiLai);
            listParameter.Add(rpTienThoiLai);

            ReportParameter rpHeaderTitle = new ReportParameter("pHeaderTitle", vFooterTitle);
            listParameter.Add(rpHeaderTitle);

            rptViewerPhieuXuatSi.LocalReport.SetParameters(listParameter);

            rptViewerPhieuXuatSi.RefreshReport();
            rptViewerPhieuXuatSi.LocalReport.DisplayName = "Call Logs";
            rptViewerPhieuXuatSi.SetDisplayMode(DisplayMode.PrintLayout);
            rptViewerPhieuXuatSi.ZoomMode = ZoomMode.Percent;
            rptViewerPhieuXuatSi.ZoomPercent = 100;
        }

        private void frmRptPhieuXuatSi_Load(object sender, EventArgs e)
        {
            this.rptViewerPhieuXuatSi.RefreshReport();
        }
    }
}
