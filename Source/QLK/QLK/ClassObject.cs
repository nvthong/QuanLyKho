using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLK
{ 
    #region DM_KHOHANG
    /// <summary>
    /// This object represents the properties and methods of a DM_KHOHANG.
    /// </summary>
    public class DM_KHOHANG
    {
        private string _id;
        private int _kH_ID;
        private string _kH_MAKHO = String.Empty;
        private string _kH_TENKHO = String.Empty;
        private int _kH_LOAIKHO;
        private int _kH_KHONHAP;
        private int _kH_BANLE;
        private int _kH_BANSI;
        private string _kH_GHICHU = String.Empty;
        private int _kH_KICHHOAT;

        public DM_KHOHANG()
        {
        }

        public DM_KHOHANG(string khMaKho, string khTenKho, int khLoaiKho, int khKhoNhap, int khBanLe, int khBanSi, string khGhiChu, int khKichHoat)
        {
            this.KH_MAKHO = khMaKho;
            this.KH_TENKHO = khTenKho;
            this.KH_LOAIKHO = khLoaiKho;
            this.KH_KHONHAP = khKhoNhap;
            this.KH_BANLE = khBanLe;
            this.KH_BANSI = khBanSi;
            this.KH_GHICHU = khGhiChu;
            this.KH_KICHHOAT = khKichHoat;
        }

        #region Public Properties
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int KH_ID
        {
            get { return _kH_ID; }
            set { _kH_ID = value; }
        }
        
        public string KH_MAKHO
        {
            get { return _kH_MAKHO; }
            set { _kH_MAKHO = value; }
        }
        
        public string KH_TENKHO
        {
            get { return _kH_TENKHO; }
            set { _kH_TENKHO = value; }
        }

        public int KH_LOAIKHO
        {
            get { return _kH_LOAIKHO; }
            set { _kH_LOAIKHO = value; }
        }

        public int KH_KHONHAP
        {
            get { return _kH_KHONHAP; }
            set { _kH_KHONHAP = value; }
        }

        public int KH_BANLE
        {
            get { return _kH_BANLE; }
            set { _kH_BANLE = value; }
        }

        public int KH_BANSI
        {
            get { return _kH_BANSI; }
            set { _kH_BANSI = value; }
        }

        public string KH_GHICHU
        {
            get { return _kH_GHICHU; }
            set { _kH_GHICHU = value; }
        }

        public int KH_KICHHOAT
        {
            get { return _kH_KICHHOAT; }
            set { _kH_KICHHOAT = value; }
        }
        #endregion
    }
    #endregion

    #region DM_NHANVIEN
    /// <summary>
    /// This object represents the properties and methods of a DM_NHANVIEN.
    /// </summary>
    public class DM_NHANVIEN
    {
        private string _id;
        private int _nV_ID;
        private string _nV_TENNV = String.Empty;
        private string _nV_MANV = String.Empty;
        private string _nV_TAIKHOAN = String.Empty;
        private string _nV_MATKHAU = String.Empty;
        private int _nV_GIOITINH;
        private DateTime _nV_NGAYSINH;
        private string _nV_DIACHI = String.Empty;
        private string _nV_DIENTHOAI = String.Empty;
        private string _nV_DIDONG = String.Empty;
        private string _nV_EMAIL = String.Empty;
        private string _nV_GHICHU = String.Empty;
        private int _nV_QUANTRI;
        private int _nV_LOAINV;
        private decimal _nV_TIENLUONG;
        private int _nV_DVTTIENLUONG;
        private string _nV_TKNGANHANG = String.Empty;
        private int _nV_KICHHOAT;

        public DM_NHANVIEN()
        {
        }

        #region Public Properties
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int NV_ID
        {
            get { return _nV_ID; }
            set { _nV_ID = value; }
        }

        public string NV_TENNV
        {
            get { return _nV_TENNV; }
            set { _nV_TENNV = value; }
        }

        public string NV_MANV
        {
            get { return _nV_MANV; }
            set { _nV_MANV = value; }
        }

        public string NV_TAIKHOAN
        {
            get { return _nV_TAIKHOAN; }
            set { _nV_TAIKHOAN = value; }
        }

        public string NV_MATKHAU
        {
            get { return _nV_MATKHAU; }
            set { _nV_MATKHAU = value; }
        }

        public int NV_GIOITINH
        {
            get { return _nV_GIOITINH; }
            set { _nV_GIOITINH = value; }
        }

        public DateTime NV_NGAYSINH
        {
            get { return _nV_NGAYSINH; }
            set { _nV_NGAYSINH = value; }
        }

        public string NV_DIACHI
        {
            get { return _nV_DIACHI; }
            set { _nV_DIACHI = value; }
        }

        public string NV_DIENTHOAI
        {
            get { return _nV_DIENTHOAI; }
            set { _nV_DIENTHOAI = value; }
        }

        public string NV_DIDONG
        {
            get { return _nV_DIDONG; }
            set { _nV_DIDONG = value; }
        }

        public string NV_EMAIL
        {
            get { return _nV_EMAIL; }
            set { _nV_EMAIL = value; }
        }

        public string NV_GHICHU
        {
            get { return _nV_GHICHU; }
            set { _nV_GHICHU = value; }
        }

        public int NV_QUANTRI
        {
            get { return _nV_QUANTRI; }
            set { _nV_QUANTRI = value; }
        }

        public int NV_LOAINV
        {
            get { return _nV_LOAINV; }
            set { _nV_LOAINV = value; }
        }

        public decimal NV_TIENLUONG
        {
            get { return _nV_TIENLUONG; }
            set { _nV_TIENLUONG = value; }
        }

        public int NV_DVTTIENLUONG
        {
            get { return _nV_DVTTIENLUONG; }
            set { _nV_DVTTIENLUONG = value; }
        }

        public string NV_TKNGANHANG
        {
            get { return _nV_TKNGANHANG; }
            set { _nV_TKNGANHANG = value; }
        }

        public int NV_KICHHOAT
        {
            get { return _nV_KICHHOAT; }
            set { _nV_KICHHOAT = value; }
        }
        #endregion

    }
    #endregion

    #region DM_NHAPHANPHOI
    /// <summary>
    /// This object represents the properties and methods of a DM_NHAPHANPHOI.
    /// </summary>
    public class DM_NHAPHANPHOI
    {
        private int _nPP_ID;
        private string _nPP_MANPP = String.Empty;
        private string _nPP_TENNPP = String.Empty;
        private string _nPP_DIACHI = String.Empty;
        private string _nPP_MST = String.Empty;
        private string _nPP_FAX = String.Empty;
        private string _nPP_DIENTHOAI = String.Empty;
        private string _nPP_EMAIL = String.Empty;
        private string _nPP_WEBSITE = String.Empty;
        private string _nPP_TAIKHOAN = String.Empty;
        private string _nPP_NGANHANG = String.Empty;
        private string _nPP_NGUOIDAIDIEN = String.Empty;
        private string _nPP_GHICHU = String.Empty;
        private int _nPP_LOAINPP;
        private int _nPP_LOAIKH;
        private int _nPP_KICHHOAT;

        public DM_NHAPHANPHOI()
        {
        }

        public DM_NHAPHANPHOI(int nppId, string nppTenNpp, string nppMaNpp, 
            string nppDiaChi, string nppMst, string nppFax, string nppDienThoai, 
            string nppEmail, string nppWebsite, string nppTaiKhoan, string nppNganHang, 
            string nppNguoiDaiDien, string nppGhiChu, int nppLoaiNpp, int nppLoaiKh, int nppKichHoat)
        {
            this.NPP_ID = nppId;
            this.NPP_TENNPP = nppTenNpp;
            this.NPP_MANPP = nppMaNpp;
            this.NPP_DIACHI = nppDiaChi;
            this.NPP_MST = nppMst;
            this.NPP_FAX = nppFax;
            this.NPP_DIENTHOAI = nppDienThoai;
            this.NPP_EMAIL = nppEmail;
            this.NPP_WEBSITE = nppWebsite;
            this.NPP_TAIKHOAN = nppTaiKhoan;
            this.NPP_NGANHANG = nppNganHang;
            this.NPP_NGUOIDAIDIEN = nppNguoiDaiDien;
            this.NPP_GHICHU = nppGhiChu;
            this.NPP_LOAINPP = nppLoaiNpp;
            this.NPP_LOAIKH = nppLoaiKh;
            this.NPP_KICHHOAT = nppKichHoat;
        }

        #region Public Properties

        public int NPP_ID
        {
            get { return _nPP_ID; }
            set { _nPP_ID = value; }
        }

        public string NPP_MANPP
        {
            get { return _nPP_MANPP; }
            set { _nPP_MANPP = value; }
        }

        public string NPP_TENNPP
        {
            get { return _nPP_TENNPP; }
            set { _nPP_TENNPP = value; }
        }

        public string NPP_DIACHI
        {
            get { return _nPP_DIACHI; }
            set { _nPP_DIACHI = value; }
        }

        public string NPP_MST
        {
            get { return _nPP_MST; }
            set { _nPP_MST = value; }
        }

        public string NPP_FAX
        {
            get { return _nPP_FAX; }
            set { _nPP_FAX = value; }
        }

        public string NPP_DIENTHOAI
        {
            get { return _nPP_DIENTHOAI; }
            set { _nPP_DIENTHOAI = value; }
        }

        public string NPP_EMAIL
        {
            get { return _nPP_EMAIL; }
            set { _nPP_EMAIL = value; }
        }

        public string NPP_WEBSITE
        {
            get { return _nPP_WEBSITE; }
            set { _nPP_WEBSITE = value; }
        }

        public string NPP_TAIKHOAN
        {
            get { return _nPP_TAIKHOAN; }
            set { _nPP_TAIKHOAN = value; }
        }

        public string NPP_NGANHANG
        {
            get { return _nPP_NGANHANG; }
            set { _nPP_NGANHANG = value; }
        }

        public string NPP_NGUOIDAIDIEN
        {
            get { return _nPP_NGUOIDAIDIEN; }
            set { _nPP_NGUOIDAIDIEN = value; }
        }

        public string NPP_GHICHU
        {
            get { return _nPP_GHICHU; }
            set { _nPP_GHICHU = value; }
        }

        public int NPP_LOAINPP
        {
            get { return _nPP_LOAINPP; }
            set { _nPP_LOAINPP = value; }
        }

        public int NPP_LOAIKH
        {
            get { return _nPP_LOAIKH; }
            set { _nPP_LOAIKH = value; }
        }

        public int NPP_KICHHOAT
        {
            get { return _nPP_KICHHOAT; }
            set { _nPP_KICHHOAT = value; }
        }
        #endregion

    }
    #endregion

    #region DMHH_DONVITINH
    /// <summary>
    /// This object represents the properties and methods of a DMHH_DONVITINH.
    /// </summary>
    public class DMHH_DONVITINH
    {
        private int _dVT_ID;
        private string _dVT_TENDONVI = String.Empty;
        private string _dVT_MADONVI = String.Empty;
        private int _dVT_MACDINH;
        private string _dVT_GHICHU = String.Empty;
        private int _dVT_KICHHOAT;

        public DMHH_DONVITINH()
        {
        }

        public DMHH_DONVITINH(int dvtId, string dvtTenDonVi, string dvtMaDonVi, int dvtMacDinh, string dvtGhiChu, int dvtKichHoat)
        {
            this.DVT_ID = dvtId;
            this.DVT_TENDONVI = dvtTenDonVi;
            this.DVT_MADONVI = dvtMaDonVi;
            this.DVT_MACDINH = dvtMacDinh;
            this.DVT_GHICHU = dvtGhiChu;
            this.DVT_KICHHOAT = dvtKichHoat;
        }

        #region Public Properties

        public int DVT_ID
        {
            get { return _dVT_ID; }
            set { _dVT_ID = value; }
        }

        public string DVT_TENDONVI
        {
            get { return _dVT_TENDONVI; }
            set { _dVT_TENDONVI = value; }
        }

        public string DVT_MADONVI
        {
            get { return _dVT_MADONVI; }
            set { _dVT_MADONVI = value; }
        }

        public int DVT_MACDINH
        {
            get { return _dVT_MACDINH; }
            set { _dVT_MACDINH = value; }
        }

        public string DVT_GHICHU
        {
            get { return _dVT_GHICHU; }
            set { _dVT_GHICHU = value; }
        }

        public int DVT_KICHHOAT
        {
            get { return _dVT_KICHHOAT; }
            set { _dVT_KICHHOAT = value; }
        }
        #endregion

    }
    #endregion

    #region DMHH_HANGHOA
    /// <summary>
    /// This object represents the properties and methods of a DMHH_HANGHOA.
    /// </summary>
    public class DMHH_HANGHOA
    {
        private string _id;
        private int _hH_ID;
        private string _hH_MAHANG = String.Empty;
        private string _hH_TENHANG = String.Empty;
        private string _hH_TENNGAN = String.Empty;
        private string _hH_THANHPHAN = String.Empty;
        private int _hH_LOAISIZE;
        private string _hH_SIZE = String.Empty;
        private string _hH_MAUSAC = String.Empty;
        private decimal _hH_GIAMUA;
        private decimal _hH_GIABANLE;
        private decimal _hH_GIABANSI;
        private double _hH_TONTOITHIEU;
        private double _hH_KHUYENMAI;
        private DateTime _hH_KMTUNGAY;
        private DateTime _hH_KMDENNGAY;
        private DateTime _hH_HANSUDUNG;
        private string _hH_GHICHU = String.Empty;
        private int _hH_KICHHOAT;
        private string _dVT_MADONVI = String.Empty;
        private string _nH_MANHOM = String.Empty;
        private string _lH_MALOAI = String.Empty;
        private string _qG_MAQUOCGIA = String.Empty;
        //private string _kH_MAKHO = String.Empty;
        private string _nPP_MANPP = String.Empty;
        private int _hH_HSD;

        public DMHH_HANGHOA()
        {
        }

        public DMHH_HANGHOA(string hhMaHang, string hhTenHang, string hhTenNgan, string hhThanhPhan, 
            int hhLoaiSize, string hhSize, string hhMauSac, decimal hhGiaMua, decimal hhGiaBanLe, 
            decimal hhGiaBanSi, double hhTonToiThieu, double hhKhuyenMai, DateTime hhKmTuNgay, 
            DateTime hhKmDenNgay, DateTime hhHanSuDung, string hhGhiChu, int hhKichHoat, 
            string dvtMaDonVi, string nhMaNhom, string lhMaLoai, string qgMaQuocGia, string nppMaNpp, int hhHsd)
        {
            this.DVT_MADONVI = dvtMaDonVi;
            this.HH_GHICHU = hhGhiChu;
            this.HH_GIABANLE = hhGiaBanLe;
            this.HH_GIABANSI = hhGiaBanSi;
            this.HH_GIAMUA = hhGiaMua;
            this.HH_HANSUDUNG = hhHanSuDung;
            this.HH_KICHHOAT = hhKichHoat;
            this.HH_KMDENNGAY = hhKmDenNgay;
            this.HH_KMTUNGAY = hhKmTuNgay;
            this.HH_KHUYENMAI = hhKhuyenMai;
            this.HH_LOAISIZE = hhLoaiSize;
            this.HH_MAHANG = hhMaHang;
            this.HH_MAUSAC = hhMauSac;
            this.HH_SIZE = hhSize;
            this.HH_TENNGAN = hhTenNgan;
            this.HH_TONTOITHIEU = hhTonToiThieu;
            this.HH_THANHPHAN = hhThanhPhan;
            //this.KH_MAKHO = khMaKho;
            this.LH_MALOAI = lhMaLoai;
            this.NPP_MANPP = nppMaNpp;
            this.NH_MANHOM = nhMaNhom;
            this.QG_MAQUOCGIA = qgMaQuocGia;
            this.HH_HSD = hhHsd;
        }

        #region Public Properties
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int HH_ID
        {
            get { return _hH_ID; }
            set { _hH_ID = value; }
        }

        public string HH_MAHANG
        {
            get { return _hH_MAHANG; }
            set { _hH_MAHANG = value; }
        }

        public string HH_TENHANG
        {
            get { return _hH_TENHANG; }
            set { _hH_TENHANG = value; }
        }

        public string HH_TENNGAN
        {
            get { return _hH_TENNGAN; }
            set { _hH_TENNGAN = value; }
        }

        public string HH_THANHPHAN
        {
            get { return _hH_THANHPHAN; }
            set { _hH_THANHPHAN = value; }
        }

        public int HH_LOAISIZE
        {
            get { return _hH_LOAISIZE; }
            set { _hH_LOAISIZE = value; }
        }

        public string HH_SIZE
        {
            get { return _hH_SIZE; }
            set { _hH_SIZE = value; }
        }

        public string HH_MAUSAC
        {
            get { return _hH_MAUSAC; }
            set { _hH_MAUSAC = value; }
        }

        public decimal HH_GIAMUA
        {
            get { return _hH_GIAMUA; }
            set { _hH_GIAMUA = value; }
        }

        public decimal HH_GIABANLE
        {
            get { return _hH_GIABANLE; }
            set { _hH_GIABANLE = value; }
        }

        public decimal HH_GIABANSI
        {
            get { return _hH_GIABANSI; }
            set { _hH_GIABANSI = value; }
        }

        public double HH_TONTOITHIEU
        {
            get { return _hH_TONTOITHIEU; }
            set { _hH_TONTOITHIEU = value; }
        }

        public double HH_KHUYENMAI
        {
            get { return _hH_KHUYENMAI; }
            set { _hH_KHUYENMAI = value; }
        }

        public DateTime HH_KMTUNGAY
        {
            get { return _hH_KMTUNGAY; }
            set { _hH_KMTUNGAY = value; }
        }

        public DateTime HH_KMDENNGAY
        {
            get { return _hH_KMDENNGAY; }
            set { _hH_KMDENNGAY = value; }
        }

        public DateTime HH_HANSUDUNG
        {
            get { return _hH_HANSUDUNG; }
            set { _hH_HANSUDUNG = value; }
        }

        public string HH_GHICHU
        {
            get { return _hH_GHICHU; }
            set { _hH_GHICHU = value; }
        }

        public int HH_KICHHOAT
        {
            get { return _hH_KICHHOAT; }
            set { _hH_KICHHOAT = value; }
        }

        public string DVT_MADONVI
        {
            get { return _dVT_MADONVI; }
            set { _dVT_MADONVI = value; }
        }

        public string NH_MANHOM
        {
            get { return _nH_MANHOM; }
            set { _nH_MANHOM = value; }
        }

        public string LH_MALOAI
        {
            get { return _lH_MALOAI; }
            set { _lH_MALOAI = value; }
        }

        public string QG_MAQUOCGIA
        {
            get { return _qG_MAQUOCGIA; }
            set { _qG_MAQUOCGIA = value; }
        }

        /*
        public string KH_MAKHO
        {
            get { return _kH_MAKHO; }
            set { _kH_MAKHO = value; }
        }*/

        public string NPP_MANPP
        {
            get { return _nPP_MANPP; }
            set { _nPP_MANPP = value; }
        }

        public int HH_HSD
        {
            get { return _hH_HSD; }
            set { _hH_HSD = value; }
        }
        #endregion

    }
    #endregion

    #region DMHH_LOAIHANG
    /// <summary>
    /// This object represents the properties and methods of a DMHH_LOAIHANG.
    /// </summary>
    public class DMHH_LOAIHANG
    {
        private string _id;
        private int _lH_ID;
        private string _lH_MALOAI = String.Empty;
        private string _lH_TENLOAI = String.Empty;
        private int _lH_MACDINH;
        private string _lH_GHICHU = String.Empty;
        private int _lH_KICHHOAT;

        public DMHH_LOAIHANG()
        {
        }

        public DMHH_LOAIHANG(string lhMaLoai, string lhTenLoai, string lhGhiChu, int lhKichHoat, int lhMacDinh)
        {
            this.LH_MALOAI = lhMaLoai;
            this.LH_TENLOAI = lhTenLoai;
            this.LH_GHICHU = lhGhiChu;
            this.LH_KICHHOAT = lhKichHoat;
            this.LH_MACDINH = lhMacDinh;
        }

        #region Public Properties
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int LH_ID
        {
            get { return _lH_ID; }
            set { _lH_ID = value; }
        }

        public string LH_MALOAI
        {
            get { return _lH_MALOAI; }
            set { _lH_MALOAI = value; }
        }

        public string LH_TENLOAI
        {
            get { return _lH_TENLOAI; }
            set { _lH_TENLOAI = value; }
        }

        public int LH_MACDINH
        {
            get { return _lH_MACDINH; }
            set { _lH_MACDINH = value; }
        }

        public string LH_GHICHU
        {
            get { return _lH_GHICHU; }
            set { _lH_GHICHU = value; }
        }

        public int LH_KICHHOAT
        {
            get { return _lH_KICHHOAT; }
            set { _lH_KICHHOAT = value; }
        }
        #endregion
        
    }
    #endregion

    #region DMHH_MAVACH
    /// <summary>
    /// This object represents the properties and methods of a DMHH_MAVACH.
    /// </summary>
    public class DMHH_MAVACH
    {
        private int _id;
        private string _hH_MAHANG = String.Empty;
        private byte[] _mV_MAVACH;
        private byte[] _mV_ANH;

        public DMHH_MAVACH()
        {
        }

        #region Public Properties
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string HH_MAHANG
        {
            get { return _hH_MAHANG; }
            set { _hH_MAHANG = value; }
        }

        public byte[] MV_MAVACH
        {
            get { return _mV_MAVACH; }
            set { _mV_MAVACH = value; }
        }

        public byte[] MV_ANH
        {
            get { return _mV_ANH; }
            set { _mV_ANH = value; }
        }
        #endregion

    }
    #endregion

    #region DMHH_NHOMHANG
    /// <summary>
    /// This object represents the properties and methods of a DMHH_NHOMHANG.
    /// </summary>
    public class DMHH_NHOMHANG
    {
        private string _id;
        private int _nH_ID;
        private string _nH_MANHOM = String.Empty;
        private string _nH_TENNHOM = String.Empty;
        private int _nH_MACDINH;
        private string _nH_GHICHU = String.Empty;
        private int _nH_KICHHOAT;

        public DMHH_NHOMHANG()
        {
        }

        public DMHH_NHOMHANG(string lhMaNhom, string lhTenNhom, string lhGhiChu, int lhKichHoat, int lhMacDinh)
        {
            this.NH_TENNHOM = lhTenNhom;
            this.NH_MANHOM = lhMaNhom;
            this.NH_GHICHU = lhGhiChu;
            this.NH_KICHHOAT = lhKichHoat;
            this.NH_MACDINH = lhMacDinh;
        }

        #region Public Properties
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int NH_ID
        {
            get { return _nH_ID; }
            set { _nH_ID = value; }
        }

        public string NH_MANHOM
        {
            get { return _nH_MANHOM; }
            set { _nH_MANHOM = value; }
        }

        public string NH_TENNHOM
        {
            get { return _nH_TENNHOM; }
            set { _nH_TENNHOM = value; }
        }

        public int NH_MACDINH
        {
            get { return _nH_MACDINH; }
            set { _nH_MACDINH = value; }
        }

        public string NH_GHICHU
        {
            get { return _nH_GHICHU; }
            set { _nH_GHICHU = value; }
        }

        public int NH_KICHHOAT
        {
            get { return _nH_KICHHOAT; }
            set { _nH_KICHHOAT = value; }
        }
        #endregion

    }
    #endregion

    #region DMHH_QUOCGIA
    /// <summary>
    /// This object represents the properties and methods of a DMHH_QUOCGIA.
    /// </summary>
    public class DMHH_QUOCGIA
    {
        private string _id;
        private int _qG_ID;
        private string _qG_MAQUOCGIA = String.Empty;
        private string _qG_TENQUOCGIA = String.Empty;
        private int _qG_MACDINH;
        private string _qG_GHICHU = String.Empty;
        private int _qG_KICHHOAT;

        public DMHH_QUOCGIA()
        {
        }

        public DMHH_QUOCGIA(int qgId, string qgTenQg, string qgMaQg, int qgMacDinh, string qgGhiChu, int qgKichHoat)
        {
            this.QG_ID = qgId;
            this.QG_TENQUOCGIA = qgTenQg;
            this.QG_MAQUOCGIA = qgMaQg;
            this.QG_MACDINH = qgMacDinh;
            this.QG_GHICHU = qgGhiChu;
            this.QG_KICHHOAT = qgKichHoat;
        }

        #region Public Properties
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int QG_ID
        {
            get { return _qG_ID; }
            set { _qG_ID = value; }
        }

        public string QG_MAQUOCGIA
        {
            get { return _qG_MAQUOCGIA; }
            set { _qG_MAQUOCGIA = value; }
        }

        public string QG_TENQUOCGIA
        {
            get { return _qG_TENQUOCGIA; }
            set { _qG_TENQUOCGIA = value; }
        }

        public int QG_MACDINH
        {
            get { return _qG_MACDINH; }
            set { _qG_MACDINH = value; }
        }

        public string QG_GHICHU
        {
            get { return _qG_GHICHU; }
            set { _qG_GHICHU = value; }
        }

        public int QG_KICHHOAT
        {
            get { return _qG_KICHHOAT; }
            set { _qG_KICHHOAT = value; }
        }
        #endregion
        
    }
    #endregion

    #region HD_NHAPXUAT
    /// <summary>
    /// This object represents the properties and methods of a HD_NHAPXUAT.
    /// </summary>
    public class HD_NHAPXUAT
    {
        private int _id;
        private string _hDNX_LOAIHD = String.Empty;
        private int _hDNX_DAIN;
        private DateTime _hDNX_NGAYIN;
        private string _hDNX_SOHDNB = String.Empty;
        private DateTime _hDNX_NGAYLAP;
        private string _hH_MAHANG = String.Empty;
        private double _hDNX_SOLUONG;
        private decimal _hDNX_GIAMUA;
        private int _hDNX_QUIDOI;
        private decimal _hDNX_TONGMUA;
        private double _hDNX_VAT;
        private decimal _hDNX_GIAVAT;
        private decimal _hDNX_TONGVAT;
        private decimal _hDNX_GIABAN;
        private decimal _hDNX_TONGBAN;
        private decimal _hDNX_THANHTIEN;
        private double _hDNX_CHIECKHAU;
        private decimal _hDNX_TONGCHIECKHAU;
        private decimal _hDNX_GIAMKHAC;
        private decimal _hDNX_KHACHDUA;
        private decimal _hDNX_THOILAI;
        private int _hDNX_TRAHANG;
        private int _hDNX_STT;
        private string _hDNX_SOHD = String.Empty;
        private DateTime _hDNX_NGAYHD;
        private int _hDNX_SONGAYHD;
        private string _nPP_MANPP = String.Empty;
        private string _nV_MANV = String.Empty;
        private string _nV_TAIKHOAN = String.Empty;
        private string _hDTT_MATT = String.Empty;
        private DateTime _hDNX_NGAYTT;
        private DateTime _hDNX_NGAYCAPNHAT;
        private string _hDNX_GHICHU = String.Empty;
        private string _kH_MAKHO = String.Empty;
        private int _hDNX_TRANGTHAI;
        private DateTime _hDNX_HANSUDUNG;
        private int _hDNX_GHINO;

        public HD_NHAPXUAT()
        {
        }

        public HD_NHAPXUAT(string pHdnxLoaiHd, int pHdnxDaIn, DateTime pHdnxNgayIn, string pHdnxSoHdnb,
            DateTime pHdnxNgayLap, string pHdnxMaHang, double pHdnxSoLuong, decimal pHdnxGiaMua,
            int pHdnxQuyDoi, decimal pHdnxTongMua, double pHdnxVat, decimal pHdnxGiaVat, decimal pHdnxTongVat,
            decimal pHdnxTongBan, decimal pHdnxThanhTien, double pHdnxChiecKhau, decimal pHdnxTongChiecKhau,
            decimal pHdnxGiamKhac, decimal pHdnxKhachDua, decimal pHdnxThoiLai, int pHdnxTraHang, int pHdnxStt, string pHdnxSoHd,
            int pHdnxSoNgayHd, string pHdnxNpp, string pHdnxMaNhanVien, string pHdnxTaiKhoan, string pHdnxMaTt,
            DateTime pHdnxNgayTt, DateTime pHdnxNgayCapNhat, string pHdnxGhiChu, string pHdnxMaKho, int pHdnxTrangThai, DateTime pHdnxHanSuDung)
        {
            this.HDNX_LOAIHD = pHdnxLoaiHd;
            this.HDNX_DAIN = pHdnxDaIn;
            this.HDNX_NGAYIN = pHdnxNgayIn;
            this.HDNX_SOHDNB = pHdnxSoHdnb;
            this.HDNX_NGAYLAP = pHdnxNgayLap;
            this.HH_MAHANG = pHdnxMaHang;
            this.HDNX_SOLUONG = pHdnxSoLuong;
            this.HDNX_GIAMUA = pHdnxGiaMua;
            this.HDNX_QUIDOI = pHdnxQuyDoi;
            this.HDNX_TONGMUA = pHdnxTongMua;
            this.HDNX_VAT = pHdnxVat;
            this.HDNX_GIAVAT = pHdnxGiaVat;
            this.HDNX_TONGVAT = pHdnxTongVat;
            this.HDNX_TONGBAN = pHdnxTongBan;
            this.HDNX_THANHTIEN = pHdnxThanhTien;
            this.HDNX_CHIECKHAU = pHdnxChiecKhau;
            this.HDNX_TONGCHIECKHAU = pHdnxTongChiecKhau;
            this.HDNX_GIAMKHAC = pHdnxGiamKhac;
            this.HDNX_KHACHDUA = pHdnxKhachDua;
            this.HDNX_THOILAI = pHdnxThoiLai;
            this.HDNX_TRAHANG = pHdnxTraHang;
            this.HDNX_STT = pHdnxStt;
            this.HDNX_SOHD = pHdnxSoHd;
            this.HDNX_SONGAYHD = pHdnxSoNgayHd;
            this.NPP_MANPP = pHdnxNpp;
            this.NV_MANV = pHdnxMaNhanVien;
            this.NV_TAIKHOAN = pHdnxTaiKhoan;
            this.HDTT_MATT = pHdnxMaTt;
            this.HDNX_NGAYTT = pHdnxNgayTt;
            this.HDNX_NGAYCAPNHAT = pHdnxNgayCapNhat;
            this.HDNX_GHICHU = pHdnxGhiChu;
            this.KH_MAKHO = pHdnxMaKho;
            this.HDNX_TRANGTHAI = pHdnxTrangThai;
            this.HDNX_HANSUDUNG = pHdnxHanSuDung;
        }

        #region Public Properties
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string HDNX_LOAIHD
        {
            get { return _hDNX_LOAIHD; }
            set { _hDNX_LOAIHD = value; }
        }

        public int HDNX_DAIN
        {
            get { return _hDNX_DAIN; }
            set { _hDNX_DAIN = value; }
        }

        public DateTime HDNX_NGAYIN
        {
            get { return _hDNX_NGAYIN; }
            set { _hDNX_NGAYIN = value; }
        }

        public string HDNX_SOHDNB
        {
            get { return _hDNX_SOHDNB; }
            set { _hDNX_SOHDNB = value; }
        }

        public DateTime HDNX_NGAYLAP
        {
            get { return _hDNX_NGAYLAP; }
            set { _hDNX_NGAYLAP = value; }
        }

        public string HH_MAHANG
        {
            get { return _hH_MAHANG; }
            set { _hH_MAHANG = value; }
        }

        public double HDNX_SOLUONG
        {
            get { return _hDNX_SOLUONG; }
            set { _hDNX_SOLUONG = value; }
        }

        public decimal HDNX_GIAMUA
        {
            get { return _hDNX_GIAMUA; }
            set { _hDNX_GIAMUA = value; }
        }

        public int HDNX_QUIDOI
        {
            get { return _hDNX_QUIDOI; }
            set { _hDNX_QUIDOI = value; }
        }

        public decimal HDNX_TONGMUA
        {
            get { return _hDNX_TONGMUA; }
            set { _hDNX_TONGMUA = value; }
        }

        public double HDNX_VAT
        {
            get { return _hDNX_VAT; }
            set { _hDNX_VAT = value; }
        }

        public decimal HDNX_GIAVAT
        {
            get { return _hDNX_GIAVAT; }
            set { _hDNX_GIAVAT = value; }
        }

        public decimal HDNX_TONGVAT
        {
            get { return _hDNX_TONGVAT; }
            set { _hDNX_TONGVAT = value; }
        }

        public decimal HDNX_GIABAN
        {
            get { return _hDNX_GIABAN; }
            set { _hDNX_GIABAN = value; }
        }

        public decimal HDNX_TONGBAN
        {
            get { return _hDNX_TONGBAN; }
            set { _hDNX_TONGBAN = value; }
        }

        public decimal HDNX_THANHTIEN
        {
            get { return _hDNX_THANHTIEN; }
            set { _hDNX_THANHTIEN = value; }
        }

        public double HDNX_CHIECKHAU
        {
            get { return _hDNX_CHIECKHAU; }
            set { _hDNX_CHIECKHAU = value; }
        }

        public decimal HDNX_TONGCHIECKHAU
        {
            get { return _hDNX_TONGCHIECKHAU; }
            set { _hDNX_TONGCHIECKHAU = value; }
        }

        public decimal HDNX_GIAMKHAC
        {
            get { return _hDNX_GIAMKHAC; }
            set { _hDNX_GIAMKHAC = value; }
        }

        public decimal HDNX_THOILAI
        {
            get { return _hDNX_THOILAI; }
            set { _hDNX_THOILAI = value; }
        }

        public decimal HDNX_KHACHDUA
        {
            get { return _hDNX_KHACHDUA; }
            set { _hDNX_KHACHDUA = value; }
        }

        public int HDNX_TRAHANG
        {
            get { return _hDNX_TRAHANG; }
            set { _hDNX_TRAHANG = value; }
        }

        public int HDNX_STT
        {
            get { return _hDNX_STT; }
            set { _hDNX_STT = value; }
        }

        public string HDNX_SOHD
        {
            get { return _hDNX_SOHD; }
            set { _hDNX_SOHD = value; }
        }

        public DateTime HDNX_NGAYHD
        {
            get { return _hDNX_NGAYHD; }
            set { _hDNX_NGAYHD = value; }
        }

        public int HDNX_SONGAYHD
        {
            get { return _hDNX_SONGAYHD; }
            set { _hDNX_SONGAYHD = value; }
        }

        public string NPP_MANPP
        {
            get { return _nPP_MANPP; }
            set { _nPP_MANPP = value; }
        }

        public string NV_MANV
        {
            get { return _nV_MANV; }
            set { _nV_MANV = value; }
        }

        public string NV_TAIKHOAN
        {
            get { return _nV_TAIKHOAN; }
            set { _nV_TAIKHOAN = value; }
        }

        public string HDTT_MATT
        {
            get { return _hDTT_MATT; }
            set { _hDTT_MATT = value; }
        }

        public DateTime HDNX_NGAYTT
        {
            get { return _hDNX_NGAYTT; }
            set { _hDNX_NGAYTT = value; }
        }

        public DateTime HDNX_NGAYCAPNHAT
        {
            get { return _hDNX_NGAYCAPNHAT; }
            set { _hDNX_NGAYCAPNHAT = value; }
        }

        public string HDNX_GHICHU
        {
            get { return _hDNX_GHICHU; }
            set { _hDNX_GHICHU = value; }
        }

        public string KH_MAKHO
        {
            get { return _kH_MAKHO; }
            set { _kH_MAKHO = value; }
        }

        public int HDNX_TRANGTHAI
        {
            get { return _hDNX_TRANGTHAI; }
            set { _hDNX_TRANGTHAI = value; }
        }

        public DateTime HDNX_HANSUDUNG
        {
            get { return _hDNX_HANSUDUNG; }
            set { _hDNX_HANSUDUNG = value; }
        }

        public int HDNX_GHINO
        {
            get { return _hDNX_GHINO; }
            set { _hDNX_GHINO = value; }
        }
        #endregion

    }
    #endregion

    #region HD_THANHTOAN
    /// <summary>
    /// This object represents the properties and methods of a HD_THANHTOAN.
    /// </summary>
    public class HD_THANHTOAN
    {
        private string _id;
        private int _hDTT_ID;
        private string _hDTT_TENTT = String.Empty;
        private int _hDTT_LOAITT;
        private string _hDTT_GHICHU = String.Empty;
        private int _hDTT_MACDINH;
        private int _hDTT_KICHHOAT;

        public HD_THANHTOAN()
        {
        }

        #region Public Properties
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int HDTT_ID
        {
            get { return _hDTT_ID; }
            set { _hDTT_ID = value; }
        }

        public string HDTT_TENTT
        {
            get { return _hDTT_TENTT; }
            set { _hDTT_TENTT = value; }
        }

        public int HDTT_LOAITT
        {
            get { return _hDTT_LOAITT; }
            set { _hDTT_LOAITT = value; }
        }

        public string HDTT_GHICHU
        {
            get { return _hDTT_GHICHU; }
            set { _hDTT_GHICHU = value; }
        }

        public int HDTT_MACDINH
        {
            get { return _hDTT_MACDINH; }
            set { _hDTT_MACDINH = value; }
        }

        public int HDTT_KICHHOAT
        {
            get { return _hDTT_KICHHOAT; }
            set { _hDTT_KICHHOAT = value; }
        }
        #endregion

    }
    #endregion

    #region HT_CAUHINH
    /// <summary>
    /// This object represents the properties and methods of a HT_CAUHINH.
    /// </summary>
    public class HT_CAUHINH
    {
        private string _id;
        private string _cH_MACH = String.Empty;
        private string _cH_TENCH = String.Empty;
        private string _cH_DIENGIAI = String.Empty;
        private string _cH_GIATRI = String.Empty;

        public HT_CAUHINH()
        {
        }

        #region Public Properties
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string CH_MACH
        {
            get { return _cH_MACH; }
            set { _cH_MACH = value; }
        }

        public string CH_TENCH
        {
            get { return _cH_TENCH; }
            set { _cH_TENCH = value; }
        }

        public string CH_DIENGIAI
        {
            get { return _cH_DIENGIAI; }
            set { _cH_DIENGIAI = value; }
        }

        public string CH_GIATRI
        {
            get { return _cH_GIATRI; }
            set { _cH_GIATRI = value; }
        }
        #endregion

    }
    #endregion

    #region HT_DMCHUCNANG
    /// <summary>
    /// This object represents the properties and methods of a HT_DMCHUCNANG.
    /// </summary>
    public class HT_DMCHUCNANG
    {
        private string _id;
        private string _dMCN_TENCN = String.Empty;
        private string _dMCN_LOAICN = String.Empty;
        private string _dMCN_DIENGIAI = String.Empty;
        private int _dMCN_STT;
        private int _dMCN_KICHHOAT;

        public HT_DMCHUCNANG()
        {
        }
        
        #region Public Properties
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string DMCN_TENCN
        {
            get { return _dMCN_TENCN; }
            set { _dMCN_TENCN = value; }
        }

        public string DMCN_LOAICN
        {
            get { return _dMCN_LOAICN; }
            set { _dMCN_LOAICN = value; }
        }

        public string DMCN_DIENGIAI
        {
            get { return _dMCN_DIENGIAI; }
            set { _dMCN_DIENGIAI = value; }
        }

        public int DMCN_STT
        {
            get { return _dMCN_STT; }
            set { _dMCN_STT = value; }
        }

        public int DMCN_KICHHOAT
        {
            get { return _dMCN_KICHHOAT; }
            set { _dMCN_KICHHOAT = value; }
        }
        #endregion

    }
    #endregion

    #region HT_DMVAITRO
    /// <summary>
    /// This object represents the properties and methods of a HT_DMVAITRO.
    /// </summary>
    public class HT_DMVAITRO
    {
        private string _id;
        private string _dMVT_TENVT = String.Empty;
        private string _dMVT_DIENGIAI = String.Empty;
        private int _dMVT_KICHHOAT;

        public HT_DMVAITRO()
        {
        }

        #region Public Properties
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string DMVT_TENVT
        {
            get { return _dMVT_TENVT; }
            set { _dMVT_TENVT = value; }
        }

        public string DMVT_DIENGIAI
        {
            get { return _dMVT_DIENGIAI; }
            set { _dMVT_DIENGIAI = value; }
        }

        public int DMVT_KICHHOAT
        {
            get { return _dMVT_KICHHOAT; }
            set { _dMVT_KICHHOAT = value; }
        }
        #endregion

    }
    #endregion

    #region HT_KHOASO
    /// <summary>
    /// This object represents the properties and methods of a HT_KHOASO.
    /// </summary>
    public class HT_KHOASO
    {
        private int _id;
        private DateTime _kS_NGAY;
        private int _kS_KHOA;
        private string _kS_GHICHU = String.Empty;

        public HT_KHOASO()
        {
        }

        #region Public Properties
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public DateTime KS_NGAY
        {
            get { return _kS_NGAY; }
            set { _kS_NGAY = value; }
        }

        public int KS_KHOA
        {
            get { return _kS_KHOA; }
            set { _kS_KHOA = value; }
        }

        public string KS_GHICHU
        {
            get { return _kS_GHICHU; }
            set { _kS_GHICHU = value; }
        }
        #endregion

    }
    #endregion

    #region HT_NHATKY
    /// <summary>
    /// This object represents the properties and methods of a HT_NHATKY.
    /// </summary>
    public class HT_NHATKY
    {
        private int _nK_ID;
        private string _nV_MANV = String.Empty;
        private DateTime _nK_THOIGIAN;
        private string _nK_TENMAY = String.Empty;
        private string _nK_TACVU = String.Empty;
        private string _nK_MALOI = String.Empty;
        private string _nK_TENLOI = String.Empty;
        private string _nK_NOIDUNG = String.Empty;

        public HT_NHATKY()
        {
        }

        #region Public Properties
        public int NK_ID
        {
            get { return _nK_ID; }
            set { _nK_ID = value; }
        }

        public string NV_MANV
        {
            get { return _nV_MANV; }
            set { _nV_MANV = value; }
        }

        public DateTime NK_THOIGIAN
        {
            get { return _nK_THOIGIAN; }
            set { _nK_THOIGIAN = value; }
        }

        public string NK_TENMAY
        {
            get { return _nK_TENMAY; }
            set { _nK_TENMAY = value; }
        }

        public string NK_TACVU
        {
            get { return _nK_TACVU; }
            set { _nK_TACVU = value; }
        }

        public string NK_MALOI
        {
            get { return _nK_MALOI; }
            set { _nK_MALOI = value; }
        }

        public string NK_TENLOI
        {
            get { return _nK_TENLOI; }
            set { _nK_TENLOI = value; }
        }

        public string NK_NOIDUNG
        {
            get { return _nK_NOIDUNG; }
            set { _nK_NOIDUNG = value; }
        }
        #endregion

    }
    #endregion

    #region HT_PHANQUYEN
    /// <summary>
    /// This object represents the properties and methods of a HT_PHANQUYEN.
    /// </summary>
    public class HT_PHANQUYEN
    {
        private int _id;
        private string _dMVT_MAVT = String.Empty;
        private string _dMVT_MACN = String.Empty;
        private int _pQ_ADMIN;
        private int _pQ_XEM;
        private int _pQ_THEM;
        private int _pQ_SUA;
        private int _pQ_XOA;
        private int _pQ_IN;
        private int _pQ_NHAP;
        private int _pQ_XUAT;
        private int _pQ_STT;

        public HT_PHANQUYEN()
        {
        }

        #region Public Properties
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string DMVT_MAVT
        {
            get { return _dMVT_MAVT; }
            set { _dMVT_MAVT = value; }
        }

        public string DMVT_MACN
        {
            get { return _dMVT_MACN; }
            set { _dMVT_MACN = value; }
        }

        public int PQ_ADMIN
        {
            get { return _pQ_ADMIN; }
            set { _pQ_ADMIN = value; }
        }

        public int PQ_XEM
        {
            get { return _pQ_XEM; }
            set { _pQ_XEM = value; }
        }

        public int PQ_THEM
        {
            get { return _pQ_THEM; }
            set { _pQ_THEM = value; }
        }

        public int PQ_SUA
        {
            get { return _pQ_SUA; }
            set { _pQ_SUA = value; }
        }

        public int PQ_XOA
        {
            get { return _pQ_XOA; }
            set { _pQ_XOA = value; }
        }

        public int PQ_IN
        {
            get { return _pQ_IN; }
            set { _pQ_IN = value; }
        }

        public int PQ_NHAP
        {
            get { return _pQ_NHAP; }
            set { _pQ_NHAP = value; }
        }

        public int PQ_XUAT
        {
            get { return _pQ_XUAT; }
            set { _pQ_XUAT = value; }
        }

        public int PQ_STT
        {
            get { return _pQ_STT; }
            set { _pQ_STT = value; }
        }
        #endregion

    }
    #endregion

    #region BANGKE_BANLE
    public class BANGKE_BANLE
    {
        private int _id;
        private string _hDNX_LOAIHD = String.Empty;
        private int _hDNX_DAIN;
        private DateTime _hDNX_NGAYIN;
        private string _hDNX_SOHDNB = String.Empty;
        private DateTime _hDNX_NGAYLAP;
        private string _hH_MAHANG = String.Empty;
        private double _hDNX_SOLUONG;
        private decimal _hDNX_GIAMUA;
        private int _hDNX_QUIDOI;
        private decimal _hDNX_TONGMUA;
        private double _hDNX_VAT;
        private decimal _hDNX_GIAVAT;
        private decimal _hDNX_TONGVAT;
        private decimal _hDNX_GIABAN;
        private decimal _hDNX_TONGBAN;
        private decimal _hDNX_THANHTIEN;
        private double _hDNX_CHIECKHAU;
        private decimal _hDNX_TONGCHIECKHAU;
        private decimal _hDNX_GIAMKHAC;
        private decimal _hDNX_KHACHDUA;
        private decimal _hDNX_THOILAI;
        private int _hDNX_TRAHANG;
        private int _hDNX_STT;
        private string _hDNX_SOHD = String.Empty;
        private DateTime _hDNX_NGAYHD;
        private int _hDNX_SONGAYHD;
        private string _nPP_MANPP = String.Empty;
        private string _nV_MANV = String.Empty;
        private string _nV_TAIKHOAN = String.Empty;
        private string _hDTT_MATT = String.Empty;
        private DateTime _hDNX_NGAYTT;
        private DateTime _hDNX_NGAYCAPNHAT;
        private string _hDNX_GHICHU = String.Empty;
        private string _kH_MAKHO = String.Empty;
        private int _hDNX_TRANGTHAI;
        private DateTime _hDNX_HANSUDUNG;
        private int _hDNX_GHINO;

        private decimal _hDNX_TONGTHANHTOAN;

        public BANGKE_BANLE()
        {
        }

        public BANGKE_BANLE(string pHdnxLoaiHd, int pHdnxDaIn, DateTime pHdnxNgayIn, string pHdnxSoHdnb,
            DateTime pHdnxNgayLap, string pHdnxMaHang, double pHdnxSoLuong, decimal pHdnxGiaMua,
            int pHdnxQuyDoi, decimal pHdnxTongMua, double pHdnxVat, decimal pHdnxGiaVat, decimal pHdnxTongVat,
            decimal pHdnxTongBan, decimal pHdnxThanhTien, double pHdnxChiecKhau, decimal pHdnxTongChiecKhau,
            decimal pHdnxGiamKhac, decimal pHdnxKhachDua, decimal pHdnxThoiLai, int pHdnxTraHang, int pHdnxStt, string pHdnxSoHd,
            int pHdnxSoNgayHd, string pHdnxNpp, string pHdnxMaNhanVien, string pHdnxTaiKhoan, string pHdnxMaTt,
            DateTime pHdnxNgayTt, DateTime pHdnxNgayCapNhat, string pHdnxGhiChu, string pHdnxMaKho, int pHdnxTrangThai, DateTime pHdnxHanSuDung)
        {
            this.HDNX_LOAIHD = pHdnxLoaiHd;
            this.HDNX_DAIN = pHdnxDaIn;
            this.HDNX_NGAYIN = pHdnxNgayIn;
            this.HDNX_SOHDNB = pHdnxSoHdnb;
            this.HDNX_NGAYLAP = pHdnxNgayLap;
            this.HH_MAHANG = pHdnxMaHang;
            this.HDNX_SOLUONG = pHdnxSoLuong;
            this.HDNX_GIAMUA = pHdnxGiaMua;
            this.HDNX_QUIDOI = pHdnxQuyDoi;
            this.HDNX_TONGMUA = pHdnxTongMua;
            this.HDNX_VAT = pHdnxVat;
            this.HDNX_GIAVAT = pHdnxGiaVat;
            this.HDNX_TONGVAT = pHdnxTongVat;
            this.HDNX_TONGBAN = pHdnxTongBan;
            this.HDNX_THANHTIEN = pHdnxThanhTien;
            this.HDNX_CHIECKHAU = pHdnxChiecKhau;
            this.HDNX_TONGCHIECKHAU = pHdnxTongChiecKhau;
            this.HDNX_GIAMKHAC = pHdnxGiamKhac;
            this.HDNX_KHACHDUA = pHdnxKhachDua;
            this.HDNX_THOILAI = pHdnxThoiLai;
            this.HDNX_TRAHANG = pHdnxTraHang;
            this.HDNX_STT = pHdnxStt;
            this.HDNX_SOHD = pHdnxSoHd;
            this.HDNX_SONGAYHD = pHdnxSoNgayHd;
            this.NPP_MANPP = pHdnxNpp;
            this.NV_MANV = pHdnxMaNhanVien;
            this.NV_TAIKHOAN = pHdnxTaiKhoan;
            this.HDTT_MATT = pHdnxMaTt;
            this.HDNX_NGAYTT = pHdnxNgayTt;
            this.HDNX_NGAYCAPNHAT = pHdnxNgayCapNhat;
            this.HDNX_GHICHU = pHdnxGhiChu;
            this.KH_MAKHO = pHdnxMaKho;
            this.HDNX_TRANGTHAI = pHdnxTrangThai;
            this.HDNX_HANSUDUNG = pHdnxHanSuDung;
        }

        #region Public Properties
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string HDNX_LOAIHD
        {
            get { return _hDNX_LOAIHD; }
            set { _hDNX_LOAIHD = value; }
        }

        public int HDNX_DAIN
        {
            get { return _hDNX_DAIN; }
            set { _hDNX_DAIN = value; }
        }

        public DateTime HDNX_NGAYIN
        {
            get { return _hDNX_NGAYIN; }
            set { _hDNX_NGAYIN = value; }
        }

        public string HDNX_SOHDNB
        {
            get { return _hDNX_SOHDNB; }
            set { _hDNX_SOHDNB = value; }
        }

        public DateTime HDNX_NGAYLAP
        {
            get { return _hDNX_NGAYLAP; }
            set { _hDNX_NGAYLAP = value; }
        }

        public string HH_MAHANG
        {
            get { return _hH_MAHANG; }
            set { _hH_MAHANG = value; }
        }

        public double HDNX_SOLUONG
        {
            get { return _hDNX_SOLUONG; }
            set { _hDNX_SOLUONG = value; }
        }

        public decimal HDNX_GIAMUA
        {
            get { return _hDNX_GIAMUA; }
            set { _hDNX_GIAMUA = value; }
        }

        public int HDNX_QUIDOI
        {
            get { return _hDNX_QUIDOI; }
            set { _hDNX_QUIDOI = value; }
        }

        public decimal HDNX_TONGMUA
        {
            get { return _hDNX_TONGMUA; }
            set { _hDNX_TONGMUA = value; }
        }

        public double HDNX_VAT
        {
            get { return _hDNX_VAT; }
            set { _hDNX_VAT = value; }
        }

        public decimal HDNX_GIAVAT
        {
            get { return _hDNX_GIAVAT; }
            set { _hDNX_GIAVAT = value; }
        }

        public decimal HDNX_TONGVAT
        {
            get { return _hDNX_TONGVAT; }
            set { _hDNX_TONGVAT = value; }
        }

        public decimal HDNX_GIABAN
        {
            get { return _hDNX_GIABAN; }
            set { _hDNX_GIABAN = value; }
        }

        public decimal HDNX_TONGBAN
        {
            get { return _hDNX_TONGBAN; }
            set { _hDNX_TONGBAN = value; }
        }

        public decimal HDNX_THANHTIEN
        {
            get { return _hDNX_THANHTIEN; }
            set { _hDNX_THANHTIEN = value; }
        }

        public double HDNX_CHIECKHAU
        {
            get { return _hDNX_CHIECKHAU; }
            set { _hDNX_CHIECKHAU = value; }
        }

        public decimal HDNX_TONGCHIECKHAU
        {
            get { return _hDNX_TONGCHIECKHAU; }
            set { _hDNX_TONGCHIECKHAU = value; }
        }

        public decimal HDNX_GIAMKHAC
        {
            get { return _hDNX_GIAMKHAC; }
            set { _hDNX_GIAMKHAC = value; }
        }

        public decimal HDNX_THOILAI
        {
            get { return _hDNX_THOILAI; }
            set { _hDNX_THOILAI = value; }
        }

        public decimal HDNX_KHACHDUA
        {
            get { return _hDNX_KHACHDUA; }
            set { _hDNX_KHACHDUA = value; }
        }

        public int HDNX_TRAHANG
        {
            get { return _hDNX_TRAHANG; }
            set { _hDNX_TRAHANG = value; }
        }

        public int HDNX_STT
        {
            get { return _hDNX_STT; }
            set { _hDNX_STT = value; }
        }

        public string HDNX_SOHD
        {
            get { return _hDNX_SOHD; }
            set { _hDNX_SOHD = value; }
        }

        public DateTime HDNX_NGAYHD
        {
            get { return _hDNX_NGAYHD; }
            set { _hDNX_NGAYHD = value; }
        }

        public int HDNX_SONGAYHD
        {
            get { return _hDNX_SONGAYHD; }
            set { _hDNX_SONGAYHD = value; }
        }

        public string NPP_MANPP
        {
            get { return _nPP_MANPP; }
            set { _nPP_MANPP = value; }
        }

        public string NV_MANV
        {
            get { return _nV_MANV; }
            set { _nV_MANV = value; }
        }

        public string NV_TAIKHOAN
        {
            get { return _nV_TAIKHOAN; }
            set { _nV_TAIKHOAN = value; }
        }

        public string HDTT_MATT
        {
            get { return _hDTT_MATT; }
            set { _hDTT_MATT = value; }
        }

        public DateTime HDNX_NGAYTT
        {
            get { return _hDNX_NGAYTT; }
            set { _hDNX_NGAYTT = value; }
        }

        public DateTime HDNX_NGAYCAPNHAT
        {
            get { return _hDNX_NGAYCAPNHAT; }
            set { _hDNX_NGAYCAPNHAT = value; }
        }

        public string HDNX_GHICHU
        {
            get { return _hDNX_GHICHU; }
            set { _hDNX_GHICHU = value; }
        }

        public string KH_MAKHO
        {
            get { return _kH_MAKHO; }
            set { _kH_MAKHO = value; }
        }

        public int HDNX_TRANGTHAI
        {
            get { return _hDNX_TRANGTHAI; }
            set { _hDNX_TRANGTHAI = value; }
        }

        public DateTime HDNX_HANSUDUNG
        {
            get { return _hDNX_HANSUDUNG; }
            set { _hDNX_HANSUDUNG = value; }
        }

        public int HDNX_GHINO
        {
            get { return _hDNX_GHINO; }
            set { _hDNX_GHINO = value; }
        }

        public decimal HDNX_TONGTHANHTOAN
        {
            get { return _hDNX_TONGTHANHTOAN; }
            set { _hDNX_TONGBAN = value; }
        }
        #endregion

    }
    #endregion


    #region BAOCAO_TONKHO
    public class BAOCAO_TONKHO 
    {
        private string _hH_MAHANG = String.Empty;
        private string _hH_TENHANG = String.Empty;
        private decimal _hH_GIAMUA;
        private decimal _hH_GIABANLE;
        private decimal _hH_GIABANSI;
        private DateTime _hH_HANSUDUNG;
        private int _hH_KICHHOAT;

        private string _dVT_TENDONVI = String.Empty;

        private double _bc_NHAPKHO;
        private double _bc_NHAPKHAC;
        private double _bc_XUATSI;
        private double _bc_XUATLE;
        private double _bc_XUATKHAC;
        private double _bc_TRAHANG;
        private double _bc_TONKHO;

        private decimal _bc_TIENTON;
        private decimal _bc_TONGTHANHTOAN;

        public BAOCAO_TONKHO()
        {

        }

        public BAOCAO_TONKHO(string hhMaHang, string hhTenHang, decimal hhGiaMua, decimal hhGiaBanLe, decimal hhGiaBanSi, DateTime hhHanSuDung, int hhKichHoat,
            string dvtTenDonVi, double bcNhapKho, double bcNhapKhac, double bcXuatSi, double bcXuatLe, double bcXuatKhac, double bcTonKho, decimal bcTienTon, decimal bcTongThanhToan)
        {
            this.HH_MAHANG = hhMaHang;
            this.HH_TENHANG = hhTenHang;
            this.HH_GIAMUA = hhGiaMua;
            this.HH_GIABANLE = hhGiaBanLe;
            this.HH_GIABANSI = hhGiaBanSi;
            this.HH_HANSUDUNG = hhHanSuDung;
            this.HH_KICHHOAT = hhKichHoat;
            this.DVT_TENDONVI = dvtTenDonVi;
            this.BC_TIENTON = bcTienTon;
            this.BC_TONKHO = bcTonKho;
            this.BC_TONGNHAPKHAC = bcNhapKhac;
            this.BC_TONGNHAPKHO = bcNhapKho;
            this.BC_TONGTHANHTOAN = bcTongThanhToan;
            this.BC_TONGXUATKHAC = bcXuatKhac;
            this.BC_TONGXUATLE = bcXuatLe;
            this.BC_TONGXUATSI = bcXuatSi;
        }

        public string HH_MAHANG
        {
            get { return _hH_MAHANG; }
            set { _hH_MAHANG = value; }
        }

        public string HH_TENHANG
        {
            get { return _hH_TENHANG; }
            set { _hH_TENHANG = value; }
        }

        public decimal HH_GIAMUA
        {
            get { return _hH_GIAMUA; }
            set { _hH_GIAMUA = value; }
        }

        public decimal HH_GIABANLE
        {
            get { return _hH_GIABANLE; }
            set { _hH_GIABANLE = value; }
        }

        public decimal HH_GIABANSI
        {
            get { return _hH_GIABANSI; }
            set { _hH_GIABANSI = value; }
        }

        public DateTime HH_HANSUDUNG
        {
            get { return _hH_HANSUDUNG; }
            set { _hH_HANSUDUNG = value; }
        }

        public int HH_KICHHOAT
        {
            get { return _hH_KICHHOAT; }
            set { _hH_KICHHOAT = value; }
        }

        public string DVT_TENDONVI
        {
            get { return _dVT_TENDONVI; }
            set { _dVT_TENDONVI = value; }
        }

        public double BC_TONGNHAPKHO
        {
            get { return _bc_NHAPKHO; }
            set { _bc_NHAPKHO = value; }
        }

        public double BC_TONGNHAPKHAC
        {
            get { return _bc_NHAPKHAC; }
            set { _bc_NHAPKHAC = value; }
        }

        public double BC_TONGXUATSI
        {
            get { return _bc_XUATSI; }
            set { _bc_XUATSI = value; }
        }

        public double BC_TONGXUATLE
        {
            get { return _bc_XUATLE; }
            set { _bc_XUATLE = value; }
        }

        public double BC_TONGXUATKHAC
        {
            get { return _bc_XUATKHAC; }
            set { _bc_XUATKHAC = value; }
        }

        public double BC_TONKHO
        {
            get { return _bc_TONKHO; }
            set { _bc_TONKHO = value; }
        }

        public double BC_TRAHANG
        {
            get { return _bc_TRAHANG; }
            set { _bc_TRAHANG = value; }
        }

        public decimal BC_TIENTON
        {
            get { return _bc_TIENTON; }
            set { _bc_TIENTON = value; }
        }

        public decimal BC_TONGTHANHTOAN
        {
            get { return _bc_TONGTHANHTOAN; }
            set { _bc_TONGTHANHTOAN = value; }
        }
    }
    #endregion

    #region BAOCAO_HANDUNG
    public class BAOCAO_HANDUNG
    {
        private string _hDNX_SOHD = String.Empty;
        private DateTime _hDNX_NGAYHD;
        private string _hH_MAHANG = String.Empty;
        private string _hH_TENHANG = String.Empty;
        private decimal _hH_GIAMUA;
        private decimal _hH_GIABANLE;
        private decimal _hH_GIABANSI;
        private DateTime _hDNX_HANSUDUNG;
        private int _hH_KICHHOAT;

        private string _dVT_TENDONVI = String.Empty;

        private double _bc_NGAYCONLAI;

        public BAOCAO_HANDUNG()
        {

        }

        public BAOCAO_HANDUNG(string hdnxSoHD, DateTime hdnxNgayHD, string hhMaHang, string hhTenHang, decimal hhGiaMua, decimal hhGiaBanLe, decimal hhGiaBanSi, DateTime hhHanSuDung, int hhKichHoat,
            string dvtTenDonVi, double bcNgayConLai)
        {
            this.HDNX_SOHD = hdnxSoHD;
            this.HDNX_NGAYHD = hdnxNgayHD;
            this.HH_MAHANG = hhMaHang;
            this.HH_TENHANG = hhTenHang;
            this.HH_GIAMUA = hhGiaMua;
            this.HH_GIABANLE = hhGiaBanLe;
            this.HH_GIABANSI = hhGiaBanSi;
            this.HDNX_HANSUDUNG = hhHanSuDung;
            this.HH_KICHHOAT = hhKichHoat;
            this.DVT_TENDONVI = dvtTenDonVi;
            this.BC_NGAYCONLAI = bcNgayConLai;
        }

        public string HDNX_SOHD
        {
            get { return _hDNX_SOHD; }
            set { _hDNX_SOHD = value; }
        }

        public string HH_MAHANG
        {
            get { return _hH_MAHANG; }
            set { _hH_MAHANG = value; }
        }

        public string HH_TENHANG
        {
            get { return _hH_TENHANG; }
            set { _hH_TENHANG = value; }
        }

        public decimal HH_GIAMUA
        {
            get { return _hH_GIAMUA; }
            set { _hH_GIAMUA = value; }
        }

        public decimal HH_GIABANLE
        {
            get { return _hH_GIABANLE; }
            set { _hH_GIABANLE = value; }
        }

        public decimal HH_GIABANSI
        {
            get { return _hH_GIABANSI; }
            set { _hH_GIABANSI = value; }
        }

        public DateTime HDNX_HANSUDUNG
        {
            get { return _hDNX_HANSUDUNG; }
            set { _hDNX_HANSUDUNG = value; }
        }

        public DateTime HDNX_NGAYHD
        {
            get { return _hDNX_NGAYHD; }
            set { _hDNX_NGAYHD = value; }
        }

        public int HH_KICHHOAT
        {
            get { return _hH_KICHHOAT; }
            set { _hH_KICHHOAT = value; }
        }

        public string DVT_TENDONVI
        {
            get { return _dVT_TENDONVI; }
            set { _dVT_TENDONVI = value; }
        }

        public double BC_NGAYCONLAI
        {
            get { return _bc_NGAYCONLAI; }
            set { _bc_NGAYCONLAI = value; }
        }

    }
    #endregion

    #region BAOCAO_LAILO
    public class BAOCAO_LAILO
    {
        private string _hDNX_SOHD = String.Empty;
        private string _hDNX_SOHDNB = String.Empty;
        private DateTime _hDNX_NGAYHD;

        private string _nPP_MANPP = String.Empty;
        private string _nPP_TENNPP = String.Empty;

        private string _hH_MAHANG = String.Empty;
        private string _hH_TENHANG = String.Empty;
        private string _dVT_TENDONVI = String.Empty;

        private double _hDNX_SOLUONG;
        private decimal _hDNX_GIAMUA;
        private decimal _hDNX_GIABAN;
        private decimal _hDNX_TONGMUA;
        private decimal _hDNX_TONGBAN;

        private double _hDNX_VAT;
        private decimal _hDNX_GIAVAT;
        private decimal _hDNX_TONGVAT;

        private double _hDNX_CHIECKHAU;
        private decimal _hDNX_TONGCHIECKHAU;
        private decimal _hDNX_GIAMKHAC;

        private decimal _hDNX_THANHTIEN;

        private decimal _hDNX_LAI;
        private decimal _hDNX_LO;

        private DateTime _hDNX_NGAYLAP;
        private int _hDNX_QUIDOI;
        private int _hDNX_TRAHANG;
        private int _hDNX_STT;
        
        private string _hDNX_GHICHU = String.Empty;
        private string _kH_MAKHO = String.Empty;
        private int _hDNX_TRANGTHAI;


        public BAOCAO_LAILO()
        {
        }

        public BAOCAO_LAILO(string pHdnxSoHdnb,
            DateTime pHdnxNgayLap, string pHdnxMaHang, double pHdnxSoLuong, decimal pHdnxGiaMua,
            int pHdnxQuyDoi, decimal pHdnxTongMua, double pHdnxVat, decimal pHdnxGiaVat, decimal pHdnxTongVat,
            decimal pHdnxTongBan, decimal pHdnxThanhTien, double pHdnxChiecKhau, decimal pHdnxTongChiecKhau,
            decimal pHdnxGiamKhac, int pHdnxTraHang, int pHdnxStt, string pHdnxSoHd,
            string pHdnxNpp, string pHdnxGhiChu, string pHdnxMaKho, int pHdnxTrangThai)
        {
            this.HDNX_SOHDNB = pHdnxSoHdnb;
            this.HDNX_NGAYLAP = pHdnxNgayLap;
            this.HH_MAHANG = pHdnxMaHang;
            this.HDNX_SOLUONG = pHdnxSoLuong;
            this.HDNX_GIAMUA = pHdnxGiaMua;
            this.HDNX_QUIDOI = pHdnxQuyDoi;
            this.HDNX_TONGMUA = pHdnxTongMua;
            this.HDNX_VAT = pHdnxVat;
            this.HDNX_GIAVAT = pHdnxGiaVat;
            this.HDNX_TONGVAT = pHdnxTongVat;
            this.HDNX_TONGBAN = pHdnxTongBan;
            this.HDNX_THANHTIEN = pHdnxThanhTien;
            this.HDNX_CHIECKHAU = pHdnxChiecKhau;
            this.HDNX_TONGCHIECKHAU = pHdnxTongChiecKhau;
            this.HDNX_GIAMKHAC = pHdnxGiamKhac;
            this.HDNX_TRAHANG = pHdnxTraHang;
            this.HDNX_STT = pHdnxStt;
            this.HDNX_SOHD = pHdnxSoHd;
            this.NPP_MANPP = pHdnxNpp;
            this.HDNX_GHICHU = pHdnxGhiChu;
            this.KH_MAKHO = pHdnxMaKho;
            this.HDNX_TRANGTHAI = pHdnxTrangThai;
        }

        #region Public Properties
        
        public string HDNX_SOHDNB
        {
            get { return _hDNX_SOHDNB; }
            set { _hDNX_SOHDNB = value; }
        }

        public DateTime HDNX_NGAYLAP
        {
            get { return _hDNX_NGAYLAP; }
            set { _hDNX_NGAYLAP = value; }
        }

        public string HH_MAHANG
        {
            get { return _hH_MAHANG; }
            set { _hH_MAHANG = value; }
        }

        public string HH_TENHANG
        {
            get { return _hH_TENHANG; }
            set { _hH_TENHANG = value; }
        }

        public string DVT_TENDONVI
        {
            get { return _dVT_TENDONVI; }
            set { _dVT_TENDONVI = value; }
        }

        public double HDNX_SOLUONG
        {
            get { return _hDNX_SOLUONG; }
            set { _hDNX_SOLUONG = value; }
        }

        public decimal HDNX_GIAMUA
        {
            get { return _hDNX_GIAMUA; }
            set { _hDNX_GIAMUA = value; }
        }

        public int HDNX_QUIDOI
        {
            get { return _hDNX_QUIDOI; }
            set { _hDNX_QUIDOI = value; }
        }

        public decimal HDNX_TONGMUA
        {
            get { return _hDNX_TONGMUA; }
            set { _hDNX_TONGMUA = value; }
        }

        public double HDNX_VAT
        {
            get { return _hDNX_VAT; }
            set { _hDNX_VAT = value; }
        }

        public decimal HDNX_GIAVAT
        {
            get { return _hDNX_GIAVAT; }
            set { _hDNX_GIAVAT = value; }
        }

        public decimal HDNX_TONGVAT
        {
            get { return _hDNX_TONGVAT; }
            set { _hDNX_TONGVAT = value; }
        }

        public decimal HDNX_GIABAN
        {
            get { return _hDNX_GIABAN; }
            set { _hDNX_GIABAN = value; }
        }

        public decimal HDNX_TONGBAN
        {
            get { return _hDNX_TONGBAN; }
            set { _hDNX_TONGBAN = value; }
        }

        public decimal HDNX_THANHTIEN
        {
            get { return _hDNX_THANHTIEN; }
            set { _hDNX_THANHTIEN = value; }
        }

        public decimal HDNX_LAI
        {
            get { return _hDNX_LAI; }
            set { _hDNX_LAI = value; }
        }

        public decimal HDNX_LO
        {
            get { return _hDNX_LO; }
            set { _hDNX_LO = value; }
        }

        public double HDNX_CHIECKHAU
        {
            get { return _hDNX_CHIECKHAU; }
            set { _hDNX_CHIECKHAU = value; }
        }

        public decimal HDNX_TONGCHIECKHAU
        {
            get { return _hDNX_TONGCHIECKHAU; }
            set { _hDNX_TONGCHIECKHAU = value; }
        }

        public decimal HDNX_GIAMKHAC
        {
            get { return _hDNX_GIAMKHAC; }
            set { _hDNX_GIAMKHAC = value; }
        }

        public int HDNX_TRAHANG
        {
            get { return _hDNX_TRAHANG; }
            set { _hDNX_TRAHANG = value; }
        }

        public int HDNX_STT
        {
            get { return _hDNX_STT; }
            set { _hDNX_STT = value; }
        }

        public string HDNX_SOHD
        {
            get { return _hDNX_SOHD; }
            set { _hDNX_SOHD = value; }
        }

        public DateTime HDNX_NGAYHD
        {
            get { return _hDNX_NGAYHD; }
            set { _hDNX_NGAYHD = value; }
        }

        public string NPP_MANPP
        {
            get { return _nPP_MANPP; }
            set { _nPP_MANPP = value; }
        }

        public string NPP_TENNPP
        {
            get { return _nPP_TENNPP; }
            set { _nPP_TENNPP = value; }
        }

        public string HDNX_GHICHU
        {
            get { return _hDNX_GHICHU; }
            set { _hDNX_GHICHU = value; }
        }

        public string KH_MAKHO
        {
            get { return _kH_MAKHO; }
            set { _kH_MAKHO = value; }
        }

        public int HDNX_TRANGTHAI
        {
            get { return _hDNX_TRANGTHAI; }
            set { _hDNX_TRANGTHAI = value; }
        }
        #endregion

    }
    #endregion

    #region SHOW_HANGHOA
    public class SHOW_HANGHOA
    {
        private string _hH_MAHANG = String.Empty;
        private string _hH_TENHANG = String.Empty;
        private decimal _hH_GIAMUA;
        private decimal _hH_GIABANLE;
        private decimal _hH_GIABANSI;
        private DateTime _hH_HANSUDUNG;
        private int _hH_KICHHOAT;

        private string _dVT_TENDONVI = String.Empty;

        private double _bc_NHAPKHO;
        private double _bc_NHAPKHAC;
        private double _bc_XUATSI;
        private double _bc_XUATLE;
        private double _bc_XUATKHAC;
        private double _bc_TONKHO;

        private string _hH_GHICHU = String.Empty;

        public SHOW_HANGHOA()
        {

        }

        public SHOW_HANGHOA(string hhMaHang, string hhTenHang, decimal hhGiaMua, decimal hhGiaBanLe, decimal hhGiaBanSi, DateTime hhHanSuDung, int hhKichHoat,
            string dvtTenDonVi, double bcNhapKho, double bcNhapKhac, double bcXuatSi, double bcXuatLe, double bcXuatKhac, double bcTonKho, string hhGhiChu)
        {
            this.HH_MAHANG = hhMaHang;
            this.HH_TENHANG = hhTenHang;
            this.HH_GIAMUA = hhGiaMua;
            this.HH_GIABANLE = hhGiaBanLe;
            this.HH_GIABANSI = hhGiaBanSi;
            this.HH_HANSUDUNG = hhHanSuDung;
            this.HH_KICHHOAT = hhKichHoat;
            this.DVT_TENDONVI = dvtTenDonVi;
            this.TONKHO = bcTonKho;
            this.BC_TONGNHAPKHAC = bcNhapKhac;
            this.BC_TONGNHAPKHO = bcNhapKho;
            this.BC_TONGXUATKHAC = bcXuatKhac;
            this.BC_TONGXUATLE = bcXuatLe;
            this.BC_TONGXUATSI = bcXuatSi;
            this.HH_GHICHU = hhGhiChu;
        }

        public string HH_MAHANG
        {
            get { return _hH_MAHANG; }
            set { _hH_MAHANG = value; }
        }

        public string HH_TENHANG
        {
            get { return _hH_TENHANG; }
            set { _hH_TENHANG = value; }
        }

        public decimal HH_GIAMUA
        {
            get { return _hH_GIAMUA; }
            set { _hH_GIAMUA = value; }
        }

        public decimal HH_GIABANLE
        {
            get { return _hH_GIABANLE; }
            set { _hH_GIABANLE = value; }
        }

        public decimal HH_GIABANSI
        {
            get { return _hH_GIABANSI; }
            set { _hH_GIABANSI = value; }
        }

        public DateTime HH_HANSUDUNG
        {
            get { return _hH_HANSUDUNG; }
            set { _hH_HANSUDUNG = value; }
        }

        public int HH_KICHHOAT
        {
            get { return _hH_KICHHOAT; }
            set { _hH_KICHHOAT = value; }
        }

        public string DVT_TENDONVI
        {
            get { return _dVT_TENDONVI; }
            set { _dVT_TENDONVI = value; }
        }

        public double BC_TONGNHAPKHO
        {
            get { return _bc_NHAPKHO; }
            set { _bc_NHAPKHO = value; }
        }

        public double BC_TONGNHAPKHAC
        {
            get { return _bc_NHAPKHAC; }
            set { _bc_NHAPKHAC = value; }
        }

        public double BC_TONGXUATSI
        {
            get { return _bc_XUATSI; }
            set { _bc_XUATSI = value; }
        }

        public double BC_TONGXUATLE
        {
            get { return _bc_XUATLE; }
            set { _bc_XUATLE = value; }
        }

        public double BC_TONGXUATKHAC
        {
            get { return _bc_XUATKHAC; }
            set { _bc_XUATKHAC = value; }
        }

        public double TONKHO
        {
            get { return _bc_TONKHO; }
            set { _bc_TONKHO = value; }
        }

        public string HH_GHICHU
        {
            get { return _hH_GHICHU; }
            set { _hH_GHICHU = value; }
        }
    }

    #endregion
}
