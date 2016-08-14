using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLK
{
    class ClassController
    {
        public ClassController()
        {

        }

        /// <summary>
        /// Kết nối database
        /// </summary>
        public static SqlConnection ConnectDatabase()
        {
            string vConnectionSing = "UID=" + Properties.Settings.Default.Username + ";" +
                                       "password=" + Properties.Settings.Default.Password + ";" +
                                       "server=" + Properties.Settings.Default.ServerName + ";" +
                                       //"Trusted_Connection=yes;" +
                                       "database=" + Properties.Settings.Default.Database + "; " +
                                       "connection timeout=30";

            SqlConnection myConnection = new SqlConnection(vConnectionSing);
            return myConnection;
        }

        /// <summary>
        /// Tạo bản backup database
        /// </summary>
        /// <param name="pBackupPath">Đường dẫn lưu trữ</param>
        public static int DatabaseBackup(string pBackupPath)
        {
            int retVal = 0;

            SqlConnection conn = ConnectDatabase();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"Backup Database QLK To Disk = '" + pBackupPath + "' WITH INIT";
            try
            {
                conn.Open();
                cmd.Connection = conn;
                retVal = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return retVal;
        }

        /// <summary>
        /// Tự sinh mã cho danh mục
        /// </summary>
        /// <param name="pLoaiDanhMuc">Mã danh mục (DVT_MADONVI, KH_MAKHO,...)</param>
        public static string getMaDanhMuc(string pLoaiDanhMuc)
        {
            string MaDanhMuc = "";
            string vNumber = "";
            string pPrefix = "";
            DataTable dtDS = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand sqlCmd;
            try
            {
                using (SqlConnection connect = ConnectDatabase())
                {
                    connect.Open();
                    switch (pLoaiDanhMuc)
                    {
                        //1Đơn vị tính
                        case "DVT_MADONVI":
                            sqlCmd = new SqlCommand("SelectDmhhDonvitinhsAll", connect);
                            sqlCmd.CommandTimeout = 1000;
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            da.SelectCommand = sqlCmd;
                            da.Fill(dtDS);
                            break;
                        //2Kho hàng
                        case "KH_MAKHO":
                            sqlCmd = new SqlCommand("SelectDmKhohangsAll", connect);
                            sqlCmd.CommandTimeout = 1000;
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            da.SelectCommand = sqlCmd;
                            da.Fill(dtDS);
                            break;
                        //3Hàng hóa
                        case "HH_MAHANG":
                            sqlCmd = new SqlCommand("SelectDmhhHanghoasAll", connect);
                            sqlCmd.CommandTimeout = 1000;
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            da.SelectCommand = sqlCmd;
                            da.Fill(dtDS);
                            break;
                        //4Nhà phân phối
                        case "NPP_MANPP_P":
                            sqlCmd = new SqlCommand("SelectDmNhaphanphoisAll", connect);
                            sqlCmd.CommandTimeout = 1000;
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            da.SelectCommand = sqlCmd;
                            da.Fill(dtDS);
                            break;
                        //5Khách hàng
                        case "NPP_MANPP_K":
                            sqlCmd = new SqlCommand("SelectDmKhachhangsAll", connect);
                            sqlCmd.CommandTimeout = 1000;
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            da.SelectCommand = sqlCmd;
                            da.Fill(dtDS);
                            break;
                        //6Loại hàng
                        case "LH_MALOAI":
                            sqlCmd = new SqlCommand("SelectDmhhLoaihangsAll", connect);
                            sqlCmd.CommandTimeout = 1000;
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            da.SelectCommand = sqlCmd;
                            da.Fill(dtDS);
                            break;
                        //7Nhóm hàng
                        case "NH_MANHOM":
                            sqlCmd = new SqlCommand("SelectDmhhNhomhangsAll", connect);
                            sqlCmd.CommandTimeout = 1000;
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            da.SelectCommand = sqlCmd;
                            da.Fill(dtDS);
                            break;
                        //8Quốc gia
                        case "QG_MAQUOCGIA":
                            sqlCmd = new SqlCommand("SelectDmhhQuocgiasAll", connect);
                            sqlCmd.CommandTimeout = 1000;
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            da.SelectCommand = sqlCmd;
                            da.Fill(dtDS);
                            break;

                    }
                    connect.Close();
                    if (dtDS.Rows.Count > 0)
                    {
                        double[] arrDVT_MADONVI = new double[dtDS.Rows.Count];
                        double[] arrKH_MAKHO = new double[dtDS.Rows.Count];
                        double[] arrHH_MAHANG = new double[dtDS.Rows.Count];
                        double[] arrNPP_MANPP = new double[dtDS.Rows.Count];
                        double[] arrKHAH = new double[dtDS.Rows.Count];
                        double[] arrLH_MALOAI = new double[dtDS.Rows.Count];
                        double[] arrNH_MANHOM = new double[dtDS.Rows.Count];
                        double[] arrQG_MAQUOCGIA = new double[dtDS.Rows.Count];

                        for (int i = 0; i < dtDS.Rows.Count; i++)
                        {
                            string vPreName = "";
                            string vPreNumber = "";

                            if (pLoaiDanhMuc == "NPP_MANPP_P" || pLoaiDanhMuc == "NPP_MANPP_K")
                            {
                                vPreName = dtDS.Rows[i]["NPP_MANPP"].ToString().Substring(0, 3);
                            }
                            else
                            {
                                vPreName = dtDS.Rows[i][pLoaiDanhMuc].ToString().Substring(0, 3);
                            }

                            pPrefix = vPreName;
                            if (vPreName == "DVT")
                            {
                                vPreNumber = dtDS.Rows[i][pLoaiDanhMuc].ToString().Substring(3, (dtDS.Rows[i][pLoaiDanhMuc].ToString().Length - 3));
                                arrDVT_MADONVI[i] = Convert.ToInt64(vPreNumber);
                            }
                            else if (vPreName == "KHO")
                            {
                                vPreNumber = dtDS.Rows[i][pLoaiDanhMuc].ToString().Substring(3, (dtDS.Rows[i][pLoaiDanhMuc].ToString().Length - 3));
                                arrKH_MAKHO[i] = Convert.ToInt64(vPreNumber);
                            }
                            else if (vPreName == "HAN")
                            {
                                vPreNumber = dtDS.Rows[i][pLoaiDanhMuc].ToString().Substring(3, (dtDS.Rows[i][pLoaiDanhMuc].ToString().Length - 3));
                                arrHH_MAHANG[i] = Convert.ToInt64(vPreNumber);
                            }
                            else if (vPreName == "NPP")
                            {
                                vPreNumber = dtDS.Rows[i]["NPP_MANPP"].ToString().Substring(3, (dtDS.Rows[i]["NPP_MANPP"].ToString().Length - 3));
                                arrNPP_MANPP[i] = Convert.ToInt64(vPreNumber);
                            }
                            else if (vPreName == "KHA")
                            {
                                vPreNumber = dtDS.Rows[i]["NPP_MANPP"].ToString().Substring(3, (dtDS.Rows[i]["NPP_MANPP"].ToString().Length - 3));
                                arrKHAH[i] = Convert.ToInt64(vPreNumber);
                            }
                            else if (vPreName == "LOA")
                            {
                                vPreNumber = dtDS.Rows[i][pLoaiDanhMuc].ToString().Substring(3, (dtDS.Rows[i][pLoaiDanhMuc].ToString().Length - 3));
                                arrLH_MALOAI[i] = Convert.ToInt64(vPreNumber);
                            }
                            else if (vPreName == "NHO")
                            {
                                vPreNumber = dtDS.Rows[i][pLoaiDanhMuc].ToString().Substring(3, (dtDS.Rows[i][pLoaiDanhMuc].ToString().Length - 3));
                                arrNH_MANHOM[i] = Convert.ToInt64(vPreNumber);
                            }
                            else if (vPreName == "QUO")
                            {
                                vPreNumber = dtDS.Rows[i][pLoaiDanhMuc].ToString().Substring(3, (dtDS.Rows[i][pLoaiDanhMuc].ToString().Length - 3));
                                arrQG_MAQUOCGIA[i] = Convert.ToInt64(vPreNumber);
                            }
                        }

                        switch (pLoaiDanhMuc)
                        {
                            case "DVT_MADONVI":
                                vNumber = (arrDVT_MADONVI.Max() + 1).ToString();
                                break;
                            case "KH_MAKHO":
                                vNumber = (arrKH_MAKHO.Max() + 1).ToString();
                                break;
                            case "HH_MAHANG":
                                vNumber = (arrHH_MAHANG.Max() + 1).ToString();
                                break;
                            case "NPP_MANPP_P":
                                vNumber = (arrNPP_MANPP.Max() + 1).ToString();
                                break;
                            case "NPP_MANPP_K":
                                vNumber = (arrKHAH.Max() + 1).ToString();
                                break;
                            case "LH_MALOAI":
                                vNumber = (arrLH_MALOAI.Max() + 1).ToString();
                                break;
                            case "NH_MANHOM":
                                vNumber = (arrNH_MANHOM.Max() + 1).ToString();
                                break;
                            case "QG_MAQUOCGIA":
                                vNumber = (arrQG_MAQUOCGIA.Max() + 1).ToString();
                                break;
                        }

                        int vLenght = vNumber.Length;
                        if (vLenght < 6)
                        {
                            string vTemp = "";
                            do
                            {
                                vTemp += "0";
                            } while ((vTemp + vNumber).Length < 6);
                            vNumber = vTemp + vNumber;
                            MaDanhMuc = pPrefix + vNumber;
                        }
                        else
                        {
                            //Nếu số lớn hơn 14 chữ số (vd: 99.999.999.999.999)
                            if (Convert.ToInt64(vNumber) > 99999999999999)
                            {
                                MaDanhMuc = "";
                            }
                            else
                            {
                                MaDanhMuc = pPrefix + vNumber;
                            }
                        }
                    }
                    else
                    {
                        switch (pLoaiDanhMuc)
                        {
                            case "DVT_MADONVI":
                                vNumber = "DVT" + "000001";
                                MaDanhMuc = vNumber;
                                break;
                            case "KH_MAKHO":
                                vNumber = "KHO" + "000001";
                                MaDanhMuc = vNumber;
                                break;
                            case "HH_MAHANG":
                                vNumber = "HAN" + "000001";
                                MaDanhMuc = vNumber;
                                break;
                            case "NPP_MANPP_P":
                                vNumber = "NPP" + "000001";
                                MaDanhMuc = vNumber;
                                break;
                            case "NPP_MANPP_K":
                                vNumber = "KHA" + "000001";
                                MaDanhMuc = vNumber;
                                break;
                            case "LH_MALOAI":
                                vNumber = "LOA" + "000001";
                                MaDanhMuc = vNumber;
                                break;
                            case "NH_MANHOM":
                                vNumber = "NHO" + "000001";
                                MaDanhMuc = vNumber;
                                break;
                            case "QG_MAQUOCGIA":
                                vNumber = "QUO" + "000001";
                                MaDanhMuc = vNumber;
                                break;
                        }
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return MaDanhMuc;
        }

        /// <summary>
        /// Tự sinh số hóa đơn
        /// </summary>
        /// <param name="pPrefix">Tiền tố</param> 
        public static string getSoHD(string pPrefix)
        {
            string SoHDNB = "";
            string vNumber = "";
            DataTable dtDS = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand sqlCmd;
            try
            {
                using (SqlConnection connect = ConnectDatabase())
                {
                    connect.Open();
                    sqlCmd = new SqlCommand("SelectHdNhapxuatsAll", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand = sqlCmd;
                    da.Fill(dtDS);
                    connect.Close();
                }

                if (dtDS.Rows.Count > 0)
                {
                    double[] arrHD_NHAPKHO = new double[dtDS.Rows.Count];
                    double[] arrHD_NHAPKHAC = new double[dtDS.Rows.Count];
                    double[] arrHD_XUATKHO = new double[dtDS.Rows.Count];

                    for (int i = 0; i < dtDS.Rows.Count; i++)
                    {
                        string vPreName = dtDS.Rows[i]["HDNX_SOHD"].ToString().Substring(0, 2);
                        string vPreNumber = "";

                        if (vPreName == "NK")
                        {
                            vPreNumber = dtDS.Rows[i]["HDNX_SOHD"].ToString().Substring(2, (dtDS.Rows[i]["HDNX_SOHD"].ToString().Length - 2));
                            arrHD_NHAPKHO[i] = Convert.ToInt64(vPreNumber);
                        }//Nhập khác
                        else if (vPreName == "NC")
                        {
                            vPreNumber = dtDS.Rows[i]["HDNX_SOHD"].ToString().Substring(10, (dtDS.Rows[i]["HDNX_SOHD"].ToString().Length - 10));
                            arrHD_NHAPKHAC[i] = Convert.ToInt64(vPreNumber);
                        }
                        else if (vPreName == "XK")
                        {
                            vPreNumber = dtDS.Rows[i]["HDNX_SOHD"].ToString().Substring(2, (dtDS.Rows[i]["HDNX_SOHDNB"].ToString().Length - 2));
                            arrHD_XUATKHO[i] = Convert.ToInt64(vPreNumber);
                        }
                    }

                    switch (pPrefix)
                    {
                        case "NK":
                            vNumber = (arrHD_NHAPKHO.Max() + 1).ToString();
                            break;
                        case "NC":
                            vNumber = (arrHD_NHAPKHAC.Max() + 1).ToString();
                            break;
                        case "XK":
                            vNumber = (arrHD_XUATKHO.Max() + 1).ToString();
                            break;
                    }

                    int vLenght = vNumber.Length;
                    if (vLenght < 6)
                    {
                        string vTemp = "";
                        do
                        {
                            vTemp += "0";
                        } while ((vTemp + vNumber).Length < 6);
                        vNumber = vTemp + vNumber;
                        SoHDNB = pPrefix + vNumber;
                    }
                    else
                    {
                        //Nếu số hóa đơn lớn hơn 14 chữ số (vd: 99.999.999.999.999)
                        if (Convert.ToInt64(vNumber) > 99999999999999)
                        {
                            SoHDNB = "";
                        }
                        else
                        {
                            SoHDNB = pPrefix + vNumber;
                        }
                    }
                }
                else
                {
                    vNumber = pPrefix + "000001";
                    SoHDNB = vNumber;
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return SoHDNB;
        }

        /// <summary>
        /// Tự sinh số hóa đơn hóa đơn nội bộ
        /// </summary>
        /// <param name="pPrefix">Tiền tố</param>
        public static string getSoHDNB(string pPrefix)
        {
            string SoHDNB = "";
            string vNumber = "";
            DataTable dtDS = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand sqlCmd;
            try
            {
                using (SqlConnection connect = ConnectDatabase())
                {
                    connect.Open();
                    sqlCmd = new SqlCommand("SelectHdNhapxuatsToGenSHDNB", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand = sqlCmd;
                    da.Fill(dtDS);
                    connect.Close();
                }

                if (dtDS.Rows.Count > 0)
                {
                    double[] arrHD_NHAPKHO = new double[dtDS.Rows.Count];
                    double[] arrHD_NHAPKHAC = new double[dtDS.Rows.Count];
                    double[] arrHD_XUATSI = new double[dtDS.Rows.Count];
                    double[] arrHD_XUATLE = new double[dtDS.Rows.Count];
                    double[] arrHD_XUATKHAC = new double[dtDS.Rows.Count];
                    double[] arrHD_TRAHANG = new double[dtDS.Rows.Count];

                    for (int i = 0; i < dtDS.Rows.Count; i++)
                    {
                        string vPreName = dtDS.Rows[i]["HDNX_SOHDNB"].ToString().Substring(0, 2);
                        string vPreNumber = "";

                        //Nhập kho
                        if (vPreName == "NK")
                        {
                            vPreNumber = dtDS.Rows[i]["HDNX_SOHDNB"].ToString().Substring(10, (dtDS.Rows[i]["HDNX_SOHDNB"].ToString().Length - 10));
                            arrHD_NHAPKHO[i] = Convert.ToInt64(vPreNumber);
                        }//Nhập khác
                        else if (vPreName == "NC")
                        {
                            vPreNumber = dtDS.Rows[i]["HDNX_SOHDNB"].ToString().Substring(10, (dtDS.Rows[i]["HDNX_SOHDNB"].ToString().Length - 10));
                            arrHD_NHAPKHAC[i] = Convert.ToInt64(vPreNumber);
                        }//Xuất kho
                        else if (vPreName == "XS")
                        {
                            vPreNumber = dtDS.Rows[i]["HDNX_SOHDNB"].ToString().Substring(10, (dtDS.Rows[i]["HDNX_SOHDNB"].ToString().Length - 10));
                            arrHD_XUATSI[i] = Convert.ToInt64(vPreNumber);
                        }
                        else if (vPreName == "XL")
                        {
                            vPreNumber = dtDS.Rows[i]["HDNX_SOHDNB"].ToString().Substring(10, (dtDS.Rows[i]["HDNX_SOHDNB"].ToString().Length - 10));
                            arrHD_XUATLE[i] = Convert.ToInt64(vPreNumber);
                        }
                        else if (vPreName == "XC")
                        {
                            vPreNumber = dtDS.Rows[i]["HDNX_SOHDNB"].ToString().Substring(10, (dtDS.Rows[i]["HDNX_SOHDNB"].ToString().Length - 10));
                            arrHD_XUATKHAC[i] = Convert.ToInt64(vPreNumber);
                        }
                        else if (vPreName == "TH")
                        {
                            vPreNumber = dtDS.Rows[i]["HDNX_SOHDNB"].ToString().Substring(10, (dtDS.Rows[i]["HDNX_SOHDNB"].ToString().Length - 10));
                            arrHD_TRAHANG[i] = Convert.ToInt64(vPreNumber);
                        }
                    }

                    switch (pPrefix)
                    {
                        case "NK":
                            vNumber = (arrHD_NHAPKHO.Max() + 1).ToString();
                            break;
                        case "NC":
                            vNumber = (arrHD_NHAPKHAC.Max() + 1).ToString();
                            break;
                        case "XS":
                            vNumber = (arrHD_XUATSI.Max() + 1).ToString();
                            break;
                        case "XL":
                            vNumber = (arrHD_XUATLE.Max() + 1).ToString();
                            break;
                        case "XC":
                            vNumber = (arrHD_XUATKHAC.Max() + 1).ToString();
                            break;
                        case "TH":
                            vNumber = (arrHD_TRAHANG.Max() + 1).ToString();
                            break;
                    }

                    int vLenght = vNumber.Length;
                    if (vLenght < 6)
                    {
                        string vTemp = "";
                        do
                        {
                            vTemp += "0";
                        } while ((vTemp + vNumber).Length < 6);
                        vNumber = vTemp + vNumber;
                        SoHDNB = pPrefix + "/" + (DateTime.Now.Month < 10 ? ("0" + DateTime.Now.Month) : DateTime.Now.Month.ToString()) + DateTime.Now.Year + "/" + vNumber;
                    }
                    else
                    {
                        //Nếu số hóa đơn lớn hơn 14 chữ số (vd: 99.999.999.999.999)
                        if (Convert.ToInt64(vNumber) > 99999999999999)
                        {
                            SoHDNB = "";
                        }
                        else
                        {
                            SoHDNB = pPrefix + "/" + (DateTime.Now.Month < 10 ? ("0" + DateTime.Now.Month) : DateTime.Now.Month.ToString()) + DateTime.Now.Year + "/" + vNumber;
                        }
                    }
                }
                else
                {
                    vNumber = pPrefix + "/" + (DateTime.Now.Month < 10 ? ("0" + DateTime.Now.Month) : DateTime.Now.Month.ToString()) + DateTime.Now.Year + "/" + "000001";
                    SoHDNB = vNumber;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return SoHDNB;
        }

        /// <summary>
        /// Trả về Hạn sử dụng của hàng hóa khi nhập kho
        /// </summary>
        /// <param name="pMaHang">Mã hàng hóa</param>
        public static DateTime getHanSuDungHH(string pMaHang)
        {
            DateTime vHSD = new DateTime(1900, 1, 1);
            DMHH_HANGHOA objHH = new DMHH_HANGHOA();
            objHH = layHangHoaTheoMa(pMaHang);
            if(objHH != null)
            {
                if(objHH.HH_HANSUDUNG.Year != 1 && objHH.HH_HSD != 0)
                {
                    vHSD = objHH.HH_HANSUDUNG.AddMonths(objHH.HH_HSD);
                }
                else if(objHH.HH_HANSUDUNG.Year == 1 && objHH.HH_HSD != 0)
                {
                    vHSD = DateTime.Now.AddMonths(objHH.HH_HSD);
                }
            }
            return vHSD;
        }

        /// <summary>
        /// Trả về Hạn sử dụng của hàng hóa khi nhập kho khi cập nhật hóa đơn
        /// </summary>
        /// <param name="pMaHang">Mã hàng hóa</param>
        /// <param name="pMaHoaDon">Mã hóa đơn</param>
        public static DateTime getHanSuDungHHUpdate(string pMaHang, string pMaHoaDon)
        {
            DateTime vHSD = new DateTime(1900, 1, 1);
            DMHH_HANGHOA objHH = new DMHH_HANGHOA();
            objHH = layHangHoaTheoMa(pMaHang);
            if (objHH != null)
            {
                List<HD_NHAPXUAT> objList = new List<HD_NHAPXUAT>();
                objList = layDSHoaDonNhapKhoTheoSHDNB(pMaHoaDon);
                if(objList.Count > 0)
                {
                    List<HD_NHAPXUAT> objList2 = new List<HD_NHAPXUAT>();
                    objList2 = objList.Where(x => x.HH_MAHANG == pMaHang).ToList();
                    foreach(var item in objList2)
                    {
                        if(item.HDNX_HANSUDUNG.Year <= 1900)
                        {
                            if (objHH.HH_HANSUDUNG.Year != 1 && objHH.HH_HSD != 0)
                            {
                                vHSD = objHH.HH_HANSUDUNG.AddMonths(objHH.HH_HSD);
                            }
                            else if (objHH.HH_HANSUDUNG.Year == 1 && objHH.HH_HSD != 0)
                            {
                                vHSD = DateTime.Now.AddMonths(objHH.HH_HSD);
                            }
                        }else
                        {
                            vHSD = item.HDNX_HANSUDUNG;
                        }
                    }
                }

                
            }
            return vHSD;
        }

        #region Danh mục hàng hóa
        #region Loại hàng
        public static DMHH_LOAIHANG layLoaiHangHoaTheoMa(string pMa)
        {
            SqlDataReader dr;
            SqlConnection connect;
            DMHH_LOAIHANG obj = new DMHH_LOAIHANG();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectDmhhLoaihang", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.Parameters.AddWithValue("@LH_MALOAI", pMa);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    dr = sqlCmd.ExecuteReader();
                    if(dr.HasRows)
                    {
                        while(dr.Read())
                        {
                            obj.LH_MALOAI = dr["LH_MALOAI"].ToString();
                            obj.LH_TENLOAI = dr["LH_TENLOAI"].ToString();
                            obj.LH_GHICHU = dr["LH_GHICHU"].ToString();
                            obj.LH_KICHHOAT = Int32.Parse(dr["LH_KICHHOAT"].ToString());
                        }
                    }
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            return obj;
        }

        public static DataTable layDSLoaiHangHoa()
        {
            DataTable dtDVT = new DataTable();
            try
            {
                using (SqlConnection connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectDmhhLoaihangsAll", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlCmd;
                    da.Fill(dtDVT);
                    connect.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return dtDVT;
        }

        public static bool kiemTraLoaiHangDuocSuDung(string pMaLoai)
        {
            bool vReturn = true;
            SqlDataReader dr;
            SqlConnection connect;
            DMHH_LOAIHANG obj = new DMHH_LOAIHANG();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("CheckLoaiHangUsed", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.Parameters.AddWithValue("@LH_MALOAI", pMaLoai);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj.LH_MALOAI = dr["LH_MALOAI"].ToString();
                            obj.LH_TENLOAI = dr["LH_TENLOAI"].ToString();
                        }
                    }
                    else
                    {
                        vReturn = false;
                    }
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return vReturn;
        }

        #endregion

        #region Nhóm hàng
        public static DMHH_NHOMHANG layNhomHangTheoMa(string pMa)
        {
            SqlDataReader dr;
            SqlConnection connect;
            DMHH_NHOMHANG obj = new DMHH_NHOMHANG();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectDmhhNhomhang", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.Parameters.AddWithValue("@NH_MANHOM", pMa);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    dr = sqlCmd.ExecuteReader();
                    if(dr.HasRows)
                    {
                        while(dr.Read())
                        {
                            obj.NH_MANHOM = dr["NH_MANHOM"].ToString();
                            obj.NH_TENNHOM = dr["NH_TENNHOM"].ToString();
                            obj.NH_GHICHU = dr["NH_GHICHU"].ToString();
                            obj.NH_KICHHOAT = Int32.Parse(dr["NH_KICHHOAT"].ToString());
                        }
                    }
                    connect.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return obj;
        }

        public static DataTable layDSNhomHangHoa()
        {
            DataTable dtDVT = new DataTable();
            try
            {
                using (SqlConnection connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectDmhhNhomhangsAll", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlCmd;
                    da.Fill(dtDVT);
                    connect.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return dtDVT;
        }

        public static bool kiemTraNhomHangDuocSuDung(string pMaNhom)
        {
            bool vReturn = true;
            SqlDataReader dr;
            SqlConnection connect;
            DMHH_NHOMHANG obj = new DMHH_NHOMHANG();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("CheckNhomHangUsed", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.Parameters.AddWithValue("@NH_MANHOM", pMaNhom);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj.NH_MANHOM = dr["NH_MANHOM"].ToString();
                            obj.NH_TENNHOM = dr["NH_TENNHOM"].ToString();
                        }
                    }
                    else
                    {
                        vReturn = false;
                    }
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return vReturn;
        }
        #endregion

        #region Hàng hóa
        public static DMHH_HANGHOA layHangHoaTheoMa(string pMa)
        {
            SqlDataReader dr;
            DMHH_HANGHOA obj = new DMHH_HANGHOA();
            SqlConnection connect;
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectDmhhHanghoa", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.Parameters.AddWithValue("@HH_MAHANG", pMa);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj.HH_MAHANG = dr["HH_MAHANG"].ToString();
                            obj.HH_TENHANG = dr["HH_TENHANG"].ToString();
                            obj.HH_GHICHU = dr["HH_GHICHU"].ToString();
                            obj.HH_GIABANLE = dr["HH_GIABANLE"].ToString() != "" ? Decimal.Parse(dr["HH_GIABANLE"].ToString()) : 0;
                            obj.HH_GIABANSI = dr["HH_GIABANSI"].ToString() != "" ? Decimal.Parse(dr["HH_GIABANSI"].ToString()) : 0;
                            obj.HH_GIAMUA = dr["HH_GIAMUA"].ToString() != "" ? Decimal.Parse(dr["HH_GIAMUA"].ToString()) : 0;

                            //if (dr["HH_HANSUDUNG"].ToString() != "")
                            //{ obj.HH_HANSUDUNG = DateTime.Parse(dr["HH_HANSUDUNG"].ToString()); }

                            obj.HH_KICHHOAT = dr["HH_KICHHOAT"].ToString() != "" ? Int32.Parse(dr["HH_KICHHOAT"].ToString()) : 0;
                            //obj.HH_KMDENNGAY = dr["HH_KMDENNGAY"].ToString() != "" ? DateTime.Parse(dr["HH_KMDENNGAY"].ToString()) : DateTime.Now;
                            //obj.HH_KMTUNGAY = DateTime.Parse(dr["HH_KMTUNGAY"].ToString());
                            obj.HH_KHUYENMAI = dr["HH_KHUYENMAI"].ToString() != "" ? Double.Parse(dr["HH_KHUYENMAI"].ToString()) : 0;
                            //obj.HH_LOAISIZE = Int32.Parse(dr["HH_LOAISIZE"].ToString());
                            obj.HH_MAHANG = dr["HH_MAHANG"].ToString();
                            obj.HH_MAUSAC = dr["HH_MAUSAC"].ToString();
                            obj.HH_SIZE = dr["HH_SIZE"].ToString();
                            obj.HH_TENNGAN = dr["HH_TENNGAN"].ToString();
                            //obj.HH_TONTOITHIEU = Double.Parse(dr["HH_TONTOITHIEU"].ToString());
                            obj.HH_THANHPHAN = dr["HH_THANHPHAN"].ToString();
                            //obj.KH_MAKHO = dr["KH_MAKHO"].ToString();
                            obj.LH_MALOAI = dr["LH_MALOAI"].ToString();
                            obj.NPP_MANPP = dr["NPP_MANPP"].ToString();
                            obj.NH_MANHOM = dr["NH_MANHOM"].ToString();
                            obj.QG_MAQUOCGIA = dr["QG_MAQUOCGIA"].ToString();
                            obj.DVT_MADONVI = dr["DVT_MADONVI"].ToString();
                            obj.HH_HANSUDUNG = dr["HH_HANSUDUNG"].ToString() != "" ? DateTime.Parse(dr["HH_HANSUDUNG"].ToString()) : new DateTime(1900, 1, 1);
                            obj.HH_HSD = int.Parse(dr["HH_HSD"].ToString());
                        }
                    }
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return obj;
        }

        public static int layTonKhoHangHoa(string pMaHang)
        {
            int vTon = 0;
            SqlConnection connect;
            List<HD_NHAPXUAT> objList = new List<HD_NHAPXUAT>();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectDmhhHanghoaTonKho", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.Parameters.AddWithValue("@HH_MAHANG", pMaHang);
                    sqlCmd.Parameters.AddWithValue("@TONKHO", "");
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    var returnParameter = sqlCmd.Parameters.Add("@TONKHO", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    sqlCmd.ExecuteNonQuery();
                    vTon = Int32.Parse(returnParameter.Value.ToString());

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return vTon;
        }

        public static double layTonKhoHangHoa(string pMaHang, string pMaKho)
        {
            double vTon = 0;
            SqlDataReader dr;
            SqlConnection connect;
            List<HD_NHAPXUAT> objList = new List<HD_NHAPXUAT>();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectDmhhHanghoaTonKho", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.Parameters.AddWithValue("@HH_MAHANG", pMaHang);
                    sqlCmd.Parameters.AddWithValue("@KH_MAKHO", pMaKho);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            vTon = double.Parse(dr["TONKHO"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return vTon;
        }

        public static double layTonKhoHangHoaKhiSua(string pMaHang, string pSoHDNB, string pMaKho)
        {
            double vTon = 0;
            SqlConnection connect;
            SqlDataReader dr;
            List<HD_NHAPXUAT> objList = new List<HD_NHAPXUAT>();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectDmhhHanghoaTonKhoKhiSua", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.Parameters.AddWithValue("@HH_MAHANG", pMaHang);
                    sqlCmd.Parameters.AddWithValue("@HDNX_SOHDNB", pSoHDNB);
                    sqlCmd.Parameters.AddWithValue("@KH_MAKHO", pMaKho);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            vTon = dr["TONKHO"].ToString() == "" ? 0 : double.Parse(dr["TONKHO"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return vTon;
        }

        public static bool kiemTraHangHoaDuocSuSung(string pMaHang)
        {
            bool vReturn = true;
            SqlDataReader dr;
            SqlConnection connect;
            DMHH_HANGHOA obj = new DMHH_HANGHOA();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("CheckHangHoaUsed", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.Parameters.AddWithValue("@HH_MAHANG", pMaHang);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj.HH_MAHANG = dr["HH_MAHANG"].ToString();
                            obj.HH_TENHANG = dr["HH_TENHANG"].ToString();
                        }
                    }
                    else
                    {
                        vReturn = false;
                    }
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return vReturn;
        }

        public static void capNhatGiaNhap(DMHH_HANGHOA objHH)
        {
            try
            {
                using (SqlConnection connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("UpdateDmhhHangHoaGiaNhap", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.Parameters.AddWithValue("@HH_MAHANG", objHH.HH_MAHANG);
                    sqlCmd.Parameters.AddWithValue("@HH_GIAMUA", objHH.HH_GIAMUA);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.ExecuteNonQuery();
                }
            }
            catch
            {

            }
        }

        public static void capNhatGiaBan(DMHH_HANGHOA objHH)
        {
            try
            {
                using (SqlConnection connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("UpdateDmhhHangHoaGiaBan", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.Parameters.AddWithValue("@HH_MAHANG", objHH.HH_MAHANG);
                    sqlCmd.Parameters.AddWithValue("@HH_GIABANLE", objHH.HH_GIABANLE);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.ExecuteNonQuery();
                }
            }
            catch
            {

            }
        }

        #endregion

        #region Quốc gia
        public static DMHH_QUOCGIA layQuocGiaTheoMa(string pMa)
        {
            SqlDataReader dr;
            SqlConnection connect;
            DMHH_QUOCGIA obj = new DMHH_QUOCGIA();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectDmhhQuocgia", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.Parameters.AddWithValue("@QG_MAQUOCGIA", pMa);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj.QG_MAQUOCGIA = dr["QG_MAQUOCGIA"].ToString();
                            obj.QG_TENQUOCGIA = dr["QG_TENQUOCGIA"].ToString();
                            obj.QG_GHICHU = dr["QG_GHICHU"].ToString();
                            obj.QG_KICHHOAT = Int32.Parse(dr["QG_KICHHOAT"].ToString());
                        }
                    }
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return obj;
        }

        public static DataTable layDSQuocGia()
        {
            DataTable dtDVT = new DataTable();
            try
            {
                using (SqlConnection connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectDmhhQuocgiasAll", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlCmd;
                    da.Fill(dtDVT);
                    connect.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return dtDVT;
        }

        public static bool kiemTraQuocGiaDuocSuDung(string pMaQuocGia)
        {
            bool vReturn = true;
            SqlDataReader dr;
            SqlConnection connect;
            DMHH_QUOCGIA obj = new DMHH_QUOCGIA();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("CheckQuocGiaUsed", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.Parameters.AddWithValue("@QG_MAQUOCGIA", pMaQuocGia);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj.QG_MAQUOCGIA = dr["QG_MAQUOCGIA"].ToString();
                            obj.QG_TENQUOCGIA = dr["QG_TENQUOCGIA"].ToString();
                        }
                    }
                    else
                    {
                        vReturn = false;
                    }
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return vReturn;
        }
        #endregion

        #region Nhà phân phối
        public static DataTable layDSNhaPhanPhoi()
        {
            DataTable dtDVT = new DataTable();
            try
            {
                using (SqlConnection connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectDmNhaphanphoisAll", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlCmd;
                    da.Fill(dtDVT);
                    connect.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return dtDVT;
        }

        public static bool kiemTraNPPDuocSuDung(string pMaLoai)
        {
            bool vReturn = true;
            SqlDataReader dr;
            SqlConnection connect;
            DM_NHAPHANPHOI obj = new DM_NHAPHANPHOI();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("CheckNPPUsed", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.Parameters.AddWithValue("@NPP_MANPP", pMaLoai);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj.NPP_MANPP = dr["NPP_MANPP"].ToString();
                            obj.NPP_TENNPP = dr["NPP_TENNPP"].ToString();
                        }
                    }
                    else
                    {
                        vReturn = false;
                    }
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return vReturn;
        }
        #endregion

        #region Kho hàng
        public static bool kiemTraKhoHangDuocSuDung(string pMaLoai)
        {
            bool vReturn = true;
            SqlDataReader dr;
            SqlConnection connect;
            DM_KHOHANG obj = new DM_KHOHANG();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("CheckKhoHangUsed", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.Parameters.AddWithValue("@KH_MAKHO", pMaLoai);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj.KH_MAKHO = dr["KH_MAKHO"].ToString();
                            obj.KH_TENKHO = dr["KH_TENKHO"].ToString();
                        }
                    }
                    else
                    {
                        vReturn = false;
                    }
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return vReturn;
        }

        /*
        public static List<DM_KHOHANG> layDSKhoHang()
        {
            SqlDataReader dr;
            SqlConnection connect;
            List<DM_KHOHANG> objList = new List<DM_KHOHANG>();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectDmKhohangsAll", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            DM_KHOHANG obj = new DM_KHOHANG();
                            obj.KH_MAKHO = dr["KH_MAKHO"].ToString();
                            obj.KH_TENKHO = dr["KH_TENKHO"].ToString();
                            obj.KH_LOAIKHO = int.Parse(dr["KH_LOAIKHO"].ToString());
                            obj.KH_KHONHAP = int.Parse(dr["KH_KHONHAP"].ToString());
                            obj.KH_BANSI = int.Parse(dr["KH_BANSI"].ToString());
                            obj.KH_BANLE = int.Parse(dr["KH_BANLE"].ToString());
                            obj.KH_KICHHOAT = int.Parse(dr["KH_KICHHOAT"].ToString());
                            obj.KH_GHICHU = dr["KH_GHICHU"].ToString();
                            obj.KH_ID = int.Parse(dr["KH_ID"].ToString());
                            objList.Add(obj);
                        }
                    }
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return objList;
        }
        */
        #endregion

        #region Khách hàng
        public static bool kiemTraKhachHangDuocSuSung(string pMaHang)
        {
            bool vReturn = true;
            SqlDataReader dr;
            SqlConnection connect;
            DM_NHAPHANPHOI obj = new DM_NHAPHANPHOI();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("CheckKhachHangUsed", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.Parameters.AddWithValue("@NPP_MANPP", pMaHang);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj.NPP_MANPP = dr["NPP_MANPP"].ToString();
                            obj.NPP_TENNPP = dr["NPP_TENNPP"].ToString();
                        }
                    }
                    else
                    {
                        vReturn = false;
                    }
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return vReturn;
        }

        public static DataTable layDSKhachHang()
        {
            DataTable dtDVT = new DataTable();
            try
            {
                using (SqlConnection connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectDmKhachhangsAllReNam", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlCmd;
                    da.Fill(dtDVT);
                    connect.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return dtDVT;
        }
        #endregion

        #region Đơn vị tính
        public static DMHH_DONVITINH layDonViTinhTheoMa(string pMa)
        {
            SqlDataReader dr;
            SqlConnection connect;
            DMHH_DONVITINH obj = new DMHH_DONVITINH();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectDmhhDonvitinh", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.Parameters.AddWithValue("@DVT_MADONVI", pMa);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj.DVT_MADONVI = dr["DVT_MADONVI"].ToString();
                            obj.DVT_TENDONVI = dr["DVT_TENDONVI"].ToString();
                            obj.DVT_GHICHU = dr["DVT_GHICHU"].ToString();
                        }
                    }
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return obj;
        }

        public static DataTable layDSDonViTinh()
        {
            DataTable dtDVT = new DataTable();
            try
            {
                using (SqlConnection connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectDmhhDonvitinhsAll", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlCmd;
                    da.Fill(dtDVT);
                    connect.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return dtDVT;
        }

        public static bool kiemTraDVTDuocSuDung(string pMaLoai)
        {
            bool vReturn = true;
            SqlDataReader dr;
            SqlConnection connect;
            DMHH_DONVITINH obj = new DMHH_DONVITINH();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("CheckDVTUsed", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.Parameters.AddWithValue("@DVT_MADONVI", pMaLoai);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj.DVT_MADONVI = dr["DVT_MADONVI"].ToString();
                            obj.DVT_TENDONVI = dr["DVT_TENDONVI"].ToString();
                        }
                    }
                    else
                    {
                        vReturn = false;
                    }
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return vReturn;
        }
        #endregion

        #region Khác
        public static DataTable layDSKieuSize()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("HH_LOAISIZE", typeof(int));
            dt.Columns.Add("KIEUSIZE", typeof(string));
            dt.Rows.Add(0, "Chữ");
            dt.Rows.Add(1, "Số");
            return dt;
        }

        public static DataTable layDSThoiGianHD()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MA_TG", typeof(int));
            dt.Columns.Add("TEN_TG", typeof(string));
            dt.Rows.Add(0, "Tất cả");
            dt.Rows.Add(1, "1 Tháng");
            dt.Rows.Add(2, "2 Tháng");
            dt.Rows.Add(4, "4 Tháng");
            dt.Rows.Add(6, "6 Tháng");
            return dt;
        }

        public static DataTable layDSDKThanhToan()
        {
            DataTable dtDVT = new DataTable();
            try
            {
                using (SqlConnection connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectHdThanhtoansAll", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlCmd;
                    da.Fill(dtDVT);
                    connect.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return dtDVT;
        }
        #endregion
        #endregion

        #region Danh mục
        public static DM_NHAPHANPHOI layNPPTheoMa(string pMa)
        {
            SqlDataReader dr;
            SqlConnection connect;
            DM_NHAPHANPHOI obj = new DM_NHAPHANPHOI();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectDmNhaphanphoi", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.Parameters.AddWithValue("@NPP_MANPP", pMa);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj.NPP_MANPP = dr["NPP_MANPP"].ToString();
                            obj.NPP_TENNPP = dr["NPP_TENNPP"].ToString();
                            obj.NPP_DIACHI = dr["NPP_DIACHI"].ToString();
                            obj.NPP_DIENTHOAI = dr["NPP_DIENTHOAI"].ToString();
                            obj.NPP_EMAIL = dr["NPP_EMAIL"].ToString();
                            obj.NPP_FAX = dr["NPP_FAX"].ToString();
                            obj.NPP_GHICHU = dr["NPP_GHICHU"].ToString();
                            obj.NPP_KICHHOAT = Int32.Parse(dr["NPP_KICHHOAT"].ToString());
                            obj.NPP_LOAIKH = Int32.Parse(dr["NPP_LOAIKH"].ToString());
                            obj.NPP_LOAINPP = Int32.Parse(dr["NPP_LOAINPP"].ToString());
                            obj.NPP_MST = dr["NPP_MST"].ToString();
                            obj.NPP_NGANHANG = dr["NPP_NGANHANG"].ToString();
                            obj.NPP_NGUOIDAIDIEN = dr["NPP_NGUOIDAIDIEN"].ToString();
                            obj.NPP_TAIKHOAN = dr["NPP_TAIKHOAN"].ToString();
                            obj.NPP_WEBSITE = dr["NPP_WEBSITE"].ToString();
                        }
                    }
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return obj;
        }

        public static DM_NHAPHANPHOI layKhachHangTheoMa(string pMa)
        {
            SqlDataReader dr;
            SqlConnection connect;
            DM_NHAPHANPHOI obj = new DM_NHAPHANPHOI();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectDmKhachhang", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.Parameters.AddWithValue("@NPP_MANPP", pMa);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj.NPP_MANPP = dr["NPP_MANPP"].ToString();
                            obj.NPP_TENNPP = dr["NPP_TENNPP"].ToString();
                            obj.NPP_DIACHI = dr["NPP_DIACHI"].ToString();
                            obj.NPP_DIENTHOAI = dr["NPP_DIENTHOAI"].ToString();
                            obj.NPP_EMAIL = dr["NPP_EMAIL"].ToString();
                            obj.NPP_FAX = dr["NPP_FAX"].ToString();
                            obj.NPP_GHICHU = dr["NPP_GHICHU"].ToString();
                            obj.NPP_KICHHOAT = Int32.Parse(dr["NPP_KICHHOAT"].ToString());
                            obj.NPP_LOAIKH = Int32.Parse(dr["NPP_LOAIKH"].ToString());
                            obj.NPP_LOAINPP = Int32.Parse(dr["NPP_LOAINPP"].ToString());
                            obj.NPP_MST = dr["NPP_MST"].ToString();
                            obj.NPP_NGANHANG = dr["NPP_NGANHANG"].ToString();
                            obj.NPP_NGUOIDAIDIEN = dr["NPP_NGUOIDAIDIEN"].ToString();
                            obj.NPP_TAIKHOAN = dr["NPP_TAIKHOAN"].ToString();
                            obj.NPP_WEBSITE = dr["NPP_WEBSITE"].ToString();
                        }
                    }
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return obj;
        }

        public static DM_KHOHANG layKhoHangTheoMa(string pMa)
        {
            SqlDataReader dr;
            SqlConnection connect;
            DM_KHOHANG obj = new DM_KHOHANG();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectDmKhohang", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.Parameters.AddWithValue("@KH_MAKHO", pMa);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj.KH_MAKHO = dr["KH_MAKHO"].ToString();
                            obj.KH_TENKHO = dr["KH_TENKHO"].ToString();
                            obj.KH_LOAIKHO = Int32.Parse(dr["KH_LOAIKHO"].ToString());
                            obj.KH_KHONHAP = Int32.Parse(dr["KH_KHONHAP"].ToString());
                            obj.KH_KICHHOAT = Int32.Parse(dr["KH_KICHHOAT"].ToString());
                            obj.KH_GHICHU = dr["KH_GHICHU"].ToString();
                            obj.KH_BANSI = Int32.Parse(dr["KH_BANSI"].ToString());
                            obj.KH_BANLE = Int32.Parse(dr["KH_BANLE"].ToString());
                        }
                    }
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }            
            return obj;
        }

        public static DM_NHANVIEN layNhanVienTheoMa(string pMa)
        {
            SqlDataReader dr;
            SqlConnection connect;
            DM_NHANVIEN obj = new DM_NHANVIEN();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectDmNhanvien", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.Parameters.AddWithValue("@NV_MANV", pMa);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj.NV_DIACHI = dr["NV_DIACHI"].ToString();
                            obj.NV_DIDONG = dr["NV_DIDONG"].ToString();
                            obj.NV_DIENTHOAI = dr["NV_DIENTHOAI"].ToString();
                            obj.NV_DVTTIENLUONG = dr["NV_DVTTIENLUONG"].ToString() != "" ? Int32.Parse(dr["NV_DVTTIENLUONG"].ToString()) : 0;
                            obj.NV_EMAIL = dr["NV_EMAIL"].ToString();
                            obj.NV_GHICHU = dr["NV_GHICHU"].ToString();
                            obj.NV_GIOITINH = dr["NV_GIOITINH"].ToString() != "" ? Int32.Parse(dr["NV_GIOITINH"].ToString()) : 0;
                            obj.NV_KICHHOAT = dr["NV_KICHHOAT"].ToString() != "" ? Int32.Parse(dr["NV_KICHHOAT"].ToString()) : 0;
                            obj.NV_LOAINV = dr["NV_LOAINV"].ToString() != "" ? Int32.Parse(dr["NV_LOAINV"].ToString()) : 0;
                            obj.NV_MATKHAU = dr["NV_MATKHAU"].ToString();
                            obj.NV_NGAYSINH = dr["NV_NGAYSINH"].ToString() != "" ? DateTime.Parse(dr["NV_NGAYSINH"].ToString()) : new DateTime(2000, 01, 01) ;
                            obj.NV_QUANTRI = dr["NV_QUANTRI"].ToString() != "" ? Int32.Parse(dr["NV_QUANTRI"].ToString()) : 0;
                            obj.NV_TAIKHOAN = dr["NV_TAIKHOAN"].ToString();
                            obj.NV_TENNV = dr["NV_TENNV"].ToString();
                            obj.NV_TIENLUONG = dr["NV_TIENLUONG"].ToString() != "" ? Decimal.Parse(dr["NV_TIENLUONG"].ToString()) : 0;
                            obj.NV_TKNGANHANG = dr["NV_TKNGANHANG"].ToString();
                            obj.NV_MANV = dr["NV_MANV"].ToString();
                        }
                    }
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return obj;
        }
        
        public static DataTable layDSKhoHang()
        {
            DataTable dtDVT = new DataTable();
            try
            {
                using (SqlConnection connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectDmKhohangsAll", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlCmd;
                    da.Fill(dtDVT);
                    connect.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return dtDVT;
        }
        #endregion

        #region Hóa đơn nhập xuất
        #region NHẬP KHO
        public static HD_NHAPXUAT layHoaDonNhapKhoTheoMa(string pMa)
        {
            SqlDataReader dr;
            SqlConnection connect;
            HD_NHAPXUAT obj = new HD_NHAPXUAT();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectHdNhapkho", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.Parameters.AddWithValue("@HDNX_ID", pMa);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj.HDNX_CHIECKHAU = double.Parse(dr["HDNX_CHIECKHAU"].ToString());
                            obj.HDNX_DAIN = Int32.Parse(dr["HDNX_DAIN"].ToString());
                            obj.HDNX_GHICHU = dr["HDNX_GHICHU"].ToString();
                            obj.HDNX_GIABAN = Decimal.Parse(dr["HDNX_GIABAN"].ToString());
                            obj.HDNX_GIAMKHAC = Decimal.Parse(dr["HDNX_GIAMKHAC"].ToString());
                            obj.HDNX_GIAMUA = Decimal.Parse(dr["HDNX_GIAMUA"].ToString());
                            obj.HDNX_GIAVAT = Decimal.Parse(dr["HDNX_GIAVAT"].ToString());
                            obj.HDNX_KHACHDUA = Decimal.Parse(dr["HDNX_KHACHDUA"].ToString());
                            obj.HDNX_LOAIHD = dr["HDNX_LOAIHD"].ToString();
                            obj.HDNX_NGAYCAPNHAT = DateTime.Parse(dr["HDNX_NGAYCAPNHAT"].ToString());
                            obj.HDNX_NGAYHD = DateTime.Parse(dr["HDNX_NGAYHD"].ToString());
                            obj.HDNX_NGAYIN = DateTime.Parse(dr["HDNX_NGAYIN"].ToString());
                            obj.HDNX_NGAYLAP = DateTime.Parse(dr["HDNX_NGAYLAP"].ToString());
                            obj.HDNX_NGAYTT = DateTime.Parse(dr["HDNX_NGAYTT"].ToString());
                            obj.HDNX_QUIDOI = Int32.Parse(dr["HDNX_QUIDOI"].ToString());
                            obj.HDNX_SOHD = dr["HDNX_SOHD"].ToString();
                            obj.HDNX_SOHDNB = dr["HDNX_SOHDNB"].ToString();
                            obj.HDNX_SOLUONG = Double.Parse(dr["HDNX_SOLUONG"].ToString());
                            obj.HDNX_SONGAYHD = Int32.Parse(dr["HDNX_SONGAYHD"].ToString());
                            obj.HDNX_STT = Int32.Parse(dr["HDNX_STT"].ToString());
                            obj.HDNX_TONGBAN = Decimal.Parse(dr["HDNX_TONGBAN"].ToString());
                            obj.HDNX_TONGCHIECKHAU = Decimal.Parse(dr["HDNX_TONGCHIECKHAU"].ToString());
                            obj.HDNX_TONGMUA = Decimal.Parse(dr["HDNX_TONGMUA"].ToString());
                            obj.HDNX_TONGVAT = Decimal.Parse(dr["HDNX_TONGVAT"].ToString());
                            obj.HDNX_THANHTIEN = Decimal.Parse(dr["HDNX_THANHTIEN"].ToString());
                            obj.HDNX_TRAHANG = Int32.Parse(dr["HDNX_TRAHANG"].ToString());
                            obj.HDNX_TRANGTHAI = Int32.Parse(dr["HDNX_TRANGTHAI"].ToString());
                            obj.HDNX_VAT = Double.Parse(dr["HDNX_VAT"].ToString());
                            obj.HDTT_MATT = dr["HDTT_MATT"].ToString();
                            obj.HH_MAHANG = dr["HH_MAHANG"].ToString();
                            obj.KH_MAKHO = dr["KH_MAKHO"].ToString();
                            obj.NPP_MANPP = dr["NPP_MANPP"].ToString();
                            obj.NV_MANV = dr["NV_MANV"].ToString();
                            obj.NV_TAIKHOAN = dr["NV_TAIKHOAN"].ToString();
                        }
                    }
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return obj;
        }
        
        public static List<HD_NHAPXUAT> layDSHoaDonNhapKhoTheoSHDNB(string pSHDNB)
        {
            SqlDataReader dr;
            SqlConnection connect;
            List<HD_NHAPXUAT> objList = new List<HD_NHAPXUAT>();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectHdNhapkhoBySHDNB", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.Parameters.AddWithValue("@HDNX_SOHDNB", pSHDNB);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            HD_NHAPXUAT obj = new HD_NHAPXUAT();
                            obj.HDNX_GHICHU = dr["HDNX_GHICHU"].ToString();
                            obj.HDNX_GIABAN = Decimal.Parse(dr["HDNX_GIABAN"].ToString());
                            obj.HDNX_GIAMUA = Decimal.Parse(dr["HDNX_GIAMUA"].ToString());
                            obj.HDNX_GIAVAT = Decimal.Parse(dr["HDNX_GIAVAT"].ToString());
                            obj.HDNX_LOAIHD = dr["HDNX_LOAIHD"].ToString();
                            obj.HDNX_NGAYHD = DateTime.Parse(dr["HDNX_NGAYHD"].ToString());
                            obj.HDNX_NGAYLAP = DateTime.Parse(dr["HDNX_NGAYLAP"].ToString());
                            obj.HDNX_QUIDOI = Int32.Parse(dr["HDNX_QUIDOI"].ToString());
                            obj.HDNX_SOHD = dr["HDNX_SOHD"].ToString();
                            obj.HDNX_SOHDNB = dr["HDNX_SOHDNB"].ToString();
                            obj.HDNX_SOLUONG = Double.Parse(dr["HDNX_SOLUONG"].ToString());
                            obj.HDNX_STT = Int32.Parse(dr["HDNX_STT"].ToString());
                            obj.HDNX_TONGMUA = Decimal.Parse(dr["HDNX_TONGMUA"].ToString());
                            obj.HDNX_TONGVAT = Decimal.Parse(dr["HDNX_TONGVAT"].ToString());
                            obj.HDNX_THANHTIEN = Decimal.Parse(dr["HDNX_THANHTIEN"].ToString());
                            obj.HDNX_TRANGTHAI = Int32.Parse(dr["HDNX_TRANGTHAI"].ToString());
                            obj.HDNX_VAT = Double.Parse(dr["HDNX_VAT"].ToString());
                            obj.HDTT_MATT = dr["HDTT_MATT"].ToString();
                            obj.HH_MAHANG = dr["HH_MAHANG"].ToString();
                            obj.KH_MAKHO = dr["KH_MAKHO"].ToString();
                            obj.NPP_MANPP = dr["NPP_MANPP"].ToString();
                            obj.NV_MANV = dr["NV_MANV"].ToString();
                            obj.NV_TAIKHOAN = dr["NV_TAIKHOAN"].ToString();
                            obj.HDNX_HANSUDUNG = DateTime.Parse(dr["HDNX_HANSUDUNG"].ToString());
                            objList.Add(obj);
                        }
                    }
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            return objList;
        }

        public static List<HD_NHAPXUAT> layDSHoaDonNhapKhoTheoKhoangThoiGian(int pKhoangThoiGian)
        {
            SqlDataReader dr;
            SqlConnection connect;
            List<HD_NHAPXUAT> objList = new List<HD_NHAPXUAT>();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectHdNhapkhoByPeriod", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.Parameters.AddWithValue("@Period", pKhoangThoiGian);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            HD_NHAPXUAT obj = new HD_NHAPXUAT();
                            obj.HDNX_NGAYHD = DateTime.Parse(dr["HDNX_NGAYHD"].ToString());
                            obj.HDNX_SOHD = dr["HDNX_SOHD"].ToString();
                            obj.HDNX_SOHDNB = dr["HDNX_SOHDNB"].ToString();
                            objList.Add(obj);
                        }
                    }
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return objList;
        }

        public static List<HD_NHAPXUAT> layDSHoaDonNhapKhoDSLeft()
        {
            SqlDataReader dr;
            SqlConnection connect;
            List<HD_NHAPXUAT> objList = new List<HD_NHAPXUAT>();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectHdNhapkhoDSLeft", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            HD_NHAPXUAT obj = new HD_NHAPXUAT();
                            obj.HDNX_NGAYHD = DateTime.Parse(dr["HDNX_NGAYHD"].ToString());
                            obj.HDNX_SOHD = dr["HDNX_SOHD"].ToString();
                            obj.HDNX_SOHDNB = dr["HDNX_SOHDNB"].ToString();
                            objList.Add(obj);
                        }
                    }
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return objList;
        }

        public static HD_NHAPXUAT layThongTinHoaDonNhapKho(string pMa)
        {
            SqlDataReader dr;
            SqlConnection connect;
            HD_NHAPXUAT obj = new HD_NHAPXUAT();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectHdThongTinCoBanNhapkhoBySHDNB", connect);
                    sqlCmd.Parameters.AddWithValue("@HDNX_SOHDNB", pMa);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj.HDNX_NGAYHD = DateTime.Parse(dr["HDNX_NGAYHD"].ToString());
                            obj.HDNX_SOHD = dr["HDNX_SOHD"].ToString();
                            obj.HDNX_SOHDNB = dr["HDNX_SOHDNB"].ToString();
                            obj.HDNX_NGAYLAP = DateTime.Parse(dr["HDNX_NGAYLAP"].ToString());
                        }
                    }
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return obj;
        }

        public static void themHoaDonNhapKho(HD_NHAPXUAT pObj)
        {
            using(SqlConnection connect = ConnectDatabase())
            {
                connect.Open();
                SqlCommand sqlCmd = new SqlCommand("InsertHdNhapkho", connect);
                sqlCmd.CommandTimeout = 1000;
                sqlCmd.Parameters.AddWithValue("@HDNX_GHICHU", pObj.HDNX_GHICHU);
                sqlCmd.Parameters.AddWithValue("@HDNX_GIABAN", pObj.HDNX_GIABAN);
                sqlCmd.Parameters.AddWithValue("@HDNX_GIAMUA", pObj.HDNX_GIAMUA);
                sqlCmd.Parameters.AddWithValue("@HDNX_GIAVAT", pObj.HDNX_GIAVAT);
                sqlCmd.Parameters.AddWithValue("@HDNX_LOAIHD", pObj.HDNX_LOAIHD);
                sqlCmd.Parameters.AddWithValue("@HDNX_NGAYHD", pObj.HDNX_NGAYHD);
                sqlCmd.Parameters.AddWithValue("@HDNX_NGAYLAP", pObj.HDNX_NGAYLAP);
                sqlCmd.Parameters.AddWithValue("@HDNX_QUIDOI", pObj.HDNX_QUIDOI);
                sqlCmd.Parameters.AddWithValue("@HDNX_SOHD", pObj.HDNX_SOHD);
                sqlCmd.Parameters.AddWithValue("@HDNX_SOHDNB", pObj.HDNX_SOHDNB);
                sqlCmd.Parameters.AddWithValue("@HDNX_SOLUONG", pObj.HDNX_SOLUONG);
                sqlCmd.Parameters.AddWithValue("@HDNX_SONGAYHD", pObj.HDNX_SONGAYHD);
                sqlCmd.Parameters.AddWithValue("@HDNX_STT", pObj.HDNX_STT);
                sqlCmd.Parameters.AddWithValue("@HDNX_TONGMUA", pObj.HDNX_TONGMUA);
                sqlCmd.Parameters.AddWithValue("@HDNX_TONGVAT", pObj.HDNX_TONGVAT);
                sqlCmd.Parameters.AddWithValue("@HDNX_THANHTIEN", pObj.HDNX_THANHTIEN);
                sqlCmd.Parameters.AddWithValue("@HDNX_TRANGTHAI", pObj.HDNX_TRANGTHAI);
                sqlCmd.Parameters.AddWithValue("@HDNX_VAT", pObj.HDNX_VAT);
                sqlCmd.Parameters.AddWithValue("@HDTT_MATT", pObj.HDTT_MATT);
                sqlCmd.Parameters.AddWithValue("@HH_MAHANG", pObj.HH_MAHANG);
                sqlCmd.Parameters.AddWithValue("@KH_MAKHO", pObj.KH_MAKHO);
                sqlCmd.Parameters.AddWithValue("@NPP_MANPP", pObj.NPP_MANPP);
                sqlCmd.Parameters.AddWithValue("@NV_MANV", pObj.NV_MANV);
                sqlCmd.Parameters.AddWithValue("@NV_TAIKHOAN", pObj.NV_TAIKHOAN);
                sqlCmd.Parameters.AddWithValue("@HDNX_HANSUDUNG", pObj.HDNX_HANSUDUNG);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.ExecuteNonQuery();
            }
        }

        public static void capNhatHoaDonNhapKho(HD_NHAPXUAT pObj)
        {
            using (SqlConnection connect = ConnectDatabase())
            {
                connect.Open();
                SqlCommand sqlCmd = new SqlCommand("InsertHdNhapkho2", connect);
                sqlCmd.CommandTimeout = 1000;
                sqlCmd.Parameters.AddWithValue("@HDNX_GHICHU", pObj.HDNX_GHICHU);
                sqlCmd.Parameters.AddWithValue("@HDNX_GIABAN", pObj.HDNX_GIABAN);
                sqlCmd.Parameters.AddWithValue("@HDNX_GIAMUA", pObj.HDNX_GIAMUA);
                sqlCmd.Parameters.AddWithValue("@HDNX_GIAVAT", pObj.HDNX_GIAVAT);
                sqlCmd.Parameters.AddWithValue("@HDNX_LOAIHD", pObj.HDNX_LOAIHD);
                sqlCmd.Parameters.AddWithValue("@HDNX_NGAYCAPNHAT", pObj.HDNX_NGAYCAPNHAT);
                sqlCmd.Parameters.AddWithValue("@HDNX_NGAYHD", pObj.HDNX_NGAYHD);
                sqlCmd.Parameters.AddWithValue("@HDNX_NGAYLAP", pObj.HDNX_NGAYLAP);
                sqlCmd.Parameters.AddWithValue("@HDNX_QUIDOI", pObj.HDNX_QUIDOI);
                sqlCmd.Parameters.AddWithValue("@HDNX_SOHD", pObj.HDNX_SOHD);
                sqlCmd.Parameters.AddWithValue("@HDNX_SOHDNB", pObj.HDNX_SOHDNB);
                sqlCmd.Parameters.AddWithValue("@HDNX_SOLUONG", pObj.HDNX_SOLUONG);
                sqlCmd.Parameters.AddWithValue("@HDNX_SONGAYHD", pObj.HDNX_SONGAYHD);
                sqlCmd.Parameters.AddWithValue("@HDNX_STT", pObj.HDNX_STT);
                sqlCmd.Parameters.AddWithValue("@HDNX_TONGMUA", pObj.HDNX_TONGMUA);
                sqlCmd.Parameters.AddWithValue("@HDNX_TONGVAT", pObj.HDNX_TONGVAT);
                sqlCmd.Parameters.AddWithValue("@HDNX_THANHTIEN", pObj.HDNX_THANHTIEN);
                sqlCmd.Parameters.AddWithValue("@HDNX_TRANGTHAI", pObj.HDNX_TRANGTHAI);
                sqlCmd.Parameters.AddWithValue("@HDNX_VAT", pObj.HDNX_VAT);
                sqlCmd.Parameters.AddWithValue("@HDTT_MATT", pObj.HDTT_MATT);
                sqlCmd.Parameters.AddWithValue("@HH_MAHANG", pObj.HH_MAHANG);
                sqlCmd.Parameters.AddWithValue("@KH_MAKHO", pObj.KH_MAKHO);
                sqlCmd.Parameters.AddWithValue("@NPP_MANPP", pObj.NPP_MANPP);
                sqlCmd.Parameters.AddWithValue("@NV_MANV", pObj.NV_MANV);
                sqlCmd.Parameters.AddWithValue("@NV_TAIKHOAN", pObj.NV_TAIKHOAN);
                sqlCmd.Parameters.AddWithValue("@HDNX_HANSUDUNG", pObj.HDNX_HANSUDUNG);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.ExecuteNonQuery();
            }
        }

        public static DataTable bangKeNhapKho(string pMaKho, DateTime pTuNgay, DateTime pDenNgay, bool pCaNam)
        {
            DataTable dt = new DataTable();
            SqlConnection connect;
            List<HD_NHAPXUAT> objList = new List<HD_NHAPXUAT>();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectHdBangKeNhapKho", connect);
                    sqlCmd.Parameters.AddWithValue("@CANAM", pCaNam ? 1 : 0);
                    sqlCmd.Parameters.AddWithValue("@MAKHO", pMaKho);
                    sqlCmd.Parameters.AddWithValue("@TUNGAY", pTuNgay.Year < 2000 ? DateTime.Now.AddYears(-1) : pTuNgay);
                    sqlCmd.Parameters.AddWithValue("@DENNGAY", pDenNgay.Year < 2000 ? DateTime.Now : pDenNgay);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlCmd;
                    da.Fill(dt);
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return dt;
        }

        public static List<HD_NHAPXUAT> layDSHangHoaNhapKhoByMaHang(string pKhoHang, string pMaHang)
        {
            SqlDataReader dr;
            SqlConnection connect;
            List<HD_NHAPXUAT> objList = new List<HD_NHAPXUAT>();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectHdByHangHoa", connect);
                    sqlCmd.Parameters.AddWithValue("@KH_MAKHO", pKhoHang);
                    sqlCmd.Parameters.AddWithValue("@HH_MAHANG", pMaHang);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            HD_NHAPXUAT obj = new HD_NHAPXUAT();
                            obj.HH_MAHANG = dr["HH_MAHANG"].ToString();
                            obj.HDNX_GIAMUA = Decimal.Parse(dr["HDNX_GIAMUA"].ToString());
                            obj.HDNX_SOLUONG = Double.Parse(dr["HDNX_SOLUONG"].ToString());
                            obj.HDNX_VAT = Double.Parse(dr["HDNX_VAT"].ToString());
                            obj.HDNX_GIAVAT = Decimal.Parse(dr["HDNX_GIAVAT"].ToString());
                            obj.HDNX_TONGVAT = Decimal.Parse(dr["HDNX_TONGVAT"].ToString());
                            objList.Add(obj);
                        }
                    }
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return objList;
        }

        #endregion

        #region NHẬP KHÁC

        public static List<HD_NHAPXUAT> layDSHoaDonNhapKhacTheoSHDNB(string pSHDNB)
        {
            SqlDataReader dr;
            SqlConnection connect;
            List<HD_NHAPXUAT> objList = new List<HD_NHAPXUAT>();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectHdNhapkhacBySHDNB", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.Parameters.AddWithValue("@HDNX_SOHDNB", pSHDNB);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            HD_NHAPXUAT obj = new HD_NHAPXUAT();
                            obj.HDNX_GHICHU = dr["HDNX_GHICHU"].ToString();
                            obj.HDNX_GIABAN = Decimal.Parse(dr["HDNX_GIABAN"].ToString());
                            obj.HDNX_GIAMUA = Decimal.Parse(dr["HDNX_GIAMUA"].ToString());
                            obj.HDNX_GIAVAT = Decimal.Parse(dr["HDNX_GIAVAT"].ToString());
                            obj.HDNX_LOAIHD = dr["HDNX_LOAIHD"].ToString();
                            obj.HDNX_NGAYHD = DateTime.Parse(dr["HDNX_NGAYHD"].ToString());
                            obj.HDNX_NGAYLAP = DateTime.Parse(dr["HDNX_NGAYLAP"].ToString());
                            obj.HDNX_SOHD = dr["HDNX_SOHD"].ToString();
                            obj.HDNX_SOHDNB = dr["HDNX_SOHDNB"].ToString();
                            obj.HDNX_SOLUONG = Double.Parse(dr["HDNX_SOLUONG"].ToString());
                            obj.HDNX_STT = Int32.Parse(dr["HDNX_STT"].ToString());
                            obj.HDNX_TONGMUA = Decimal.Parse(dr["HDNX_TONGMUA"].ToString());
                            obj.HDNX_TONGVAT = Decimal.Parse(dr["HDNX_TONGVAT"].ToString());
                            obj.HDNX_THANHTIEN = Decimal.Parse(dr["HDNX_THANHTIEN"].ToString());
                            obj.HDNX_TRANGTHAI = Int32.Parse(dr["HDNX_TRANGTHAI"].ToString());
                            obj.HDNX_VAT = Double.Parse(dr["HDNX_VAT"].ToString());
                            obj.HH_MAHANG = dr["HH_MAHANG"].ToString();
                            obj.KH_MAKHO = dr["KH_MAKHO"].ToString();
                            objList.Add(obj);
                        }
                    }
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return objList;
        }

        public static List<HD_NHAPXUAT> layDSHoaDonNhapKhacTheoKhoangThoiGian(int pKhoangThoiGian)
        {
            SqlDataReader dr;
            SqlConnection connect;
            List<HD_NHAPXUAT> objList = new List<HD_NHAPXUAT>();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectHdNhapkhacByPeriod", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.Parameters.AddWithValue("@Period", pKhoangThoiGian);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            HD_NHAPXUAT obj = new HD_NHAPXUAT();
                            obj.HDNX_NGAYHD = DateTime.Parse(dr["HDNX_NGAYHD"].ToString());
                            obj.HDNX_SOHD = dr["HDNX_SOHD"].ToString();
                            obj.HDNX_SOHDNB = dr["HDNX_SOHDNB"].ToString();
                            objList.Add(obj);
                        }
                    }
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return objList;
        }
        
        public static List<HD_NHAPXUAT> layDSHoaDonNhapKhacDSLeft()
        {
            SqlDataReader dr;
            SqlConnection connect;
            List<HD_NHAPXUAT> objList = new List<HD_NHAPXUAT>();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectHdNhapkhacDSLeft", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            HD_NHAPXUAT obj = new HD_NHAPXUAT();
                            obj.HDNX_NGAYHD = DateTime.Parse(dr["HDNX_NGAYHD"].ToString());
                            obj.HDNX_SOHD = dr["HDNX_SOHD"].ToString();
                            obj.HDNX_SOHDNB = dr["HDNX_SOHDNB"].ToString();
                            objList.Add(obj);
                        }
                    }
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return objList;
        }

        public static HD_NHAPXUAT layThongTinHoaDonNhapKhac(string pMa)
        {
            SqlDataReader dr;
            SqlConnection connect;
            HD_NHAPXUAT obj = new HD_NHAPXUAT();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectHdThongTinCoBanNhapkhacBySHDNB", connect);
                    sqlCmd.Parameters.AddWithValue("@HDNX_SOHDNB", pMa);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj.HDNX_NGAYHD = DateTime.Parse(dr["HDNX_NGAYHD"].ToString());
                            obj.HDNX_SOHD = dr["HDNX_SOHD"].ToString();
                            obj.HDNX_SOHDNB = dr["HDNX_SOHDNB"].ToString();
                            obj.HDNX_NGAYLAP = DateTime.Parse(dr["HDNX_NGAYLAP"].ToString());
                        }
                    }
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return obj;
        }

        public static void themHoaDonNhapKhac(HD_NHAPXUAT pObj)
        {
            using (SqlConnection connect = ConnectDatabase())
            {
                connect.Open();
                SqlCommand sqlCmd = new SqlCommand("InsertHdNhapkhac", connect);
                sqlCmd.CommandTimeout = 1000;
                sqlCmd.Parameters.AddWithValue("@HDNX_GHICHU", pObj.HDNX_GHICHU);
                sqlCmd.Parameters.AddWithValue("@HDNX_GIABAN", pObj.HDNX_GIABAN);
                sqlCmd.Parameters.AddWithValue("@HDNX_GIAMUA", pObj.HDNX_GIAMUA);
                sqlCmd.Parameters.AddWithValue("@HDNX_GIAVAT", pObj.HDNX_GIAVAT);
                sqlCmd.Parameters.AddWithValue("@HDNX_LOAIHD", pObj.HDNX_LOAIHD);
                sqlCmd.Parameters.AddWithValue("@HDNX_NGAYHD", pObj.HDNX_NGAYHD);
                sqlCmd.Parameters.AddWithValue("@HDNX_NGAYLAP", pObj.HDNX_NGAYLAP);
                sqlCmd.Parameters.AddWithValue("@HDNX_SOHD", pObj.HDNX_SOHD);
                sqlCmd.Parameters.AddWithValue("@HDNX_SOHDNB", pObj.HDNX_SOHDNB);
                sqlCmd.Parameters.AddWithValue("@HDNX_SOLUONG", pObj.HDNX_SOLUONG);
                sqlCmd.Parameters.AddWithValue("@HDNX_SONGAYHD", pObj.HDNX_SONGAYHD);
                sqlCmd.Parameters.AddWithValue("@HDNX_STT", pObj.HDNX_STT);
                sqlCmd.Parameters.AddWithValue("@HDNX_TONGMUA", pObj.HDNX_TONGMUA);
                sqlCmd.Parameters.AddWithValue("@HDNX_TONGVAT", pObj.HDNX_TONGVAT);
                sqlCmd.Parameters.AddWithValue("@HDNX_THANHTIEN", pObj.HDNX_THANHTIEN);
                sqlCmd.Parameters.AddWithValue("@HDNX_TRANGTHAI", pObj.HDNX_TRANGTHAI);
                sqlCmd.Parameters.AddWithValue("@HDNX_VAT", pObj.HDNX_VAT);
                sqlCmd.Parameters.AddWithValue("@HH_MAHANG", pObj.HH_MAHANG);
                sqlCmd.Parameters.AddWithValue("@KH_MAKHO", pObj.KH_MAKHO);
                sqlCmd.Parameters.AddWithValue("@HDNX_HANSUDUNG", pObj.HDNX_HANSUDUNG);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.ExecuteNonQuery();
            }
        }

        public static void capNhatHoaDonNhapKhac(HD_NHAPXUAT pObj)
        {
            using (SqlConnection connect = ConnectDatabase())
            {
                connect.Open();
                SqlCommand sqlCmd = new SqlCommand("InsertHdNhapkhac2", connect);
                sqlCmd.CommandTimeout = 1000;
                sqlCmd.Parameters.AddWithValue("@HDNX_GHICHU", pObj.HDNX_GHICHU);
                sqlCmd.Parameters.AddWithValue("@HDNX_GIABAN", pObj.HDNX_GIABAN);
                sqlCmd.Parameters.AddWithValue("@HDNX_GIAMUA", pObj.HDNX_GIAMUA);
                sqlCmd.Parameters.AddWithValue("@HDNX_GIAVAT", pObj.HDNX_GIAVAT);
                sqlCmd.Parameters.AddWithValue("@HDNX_LOAIHD", pObj.HDNX_LOAIHD);
                sqlCmd.Parameters.AddWithValue("@HDNX_NGAYCAPNHAT", pObj.HDNX_NGAYCAPNHAT);
                sqlCmd.Parameters.AddWithValue("@HDNX_NGAYHD", pObj.HDNX_NGAYHD);
                sqlCmd.Parameters.AddWithValue("@HDNX_NGAYLAP", pObj.HDNX_NGAYLAP);
                sqlCmd.Parameters.AddWithValue("@HDNX_SOHD", pObj.HDNX_SOHD);
                sqlCmd.Parameters.AddWithValue("@HDNX_SOHDNB", pObj.HDNX_SOHDNB);
                sqlCmd.Parameters.AddWithValue("@HDNX_SOLUONG", pObj.HDNX_SOLUONG);
                sqlCmd.Parameters.AddWithValue("@HDNX_SONGAYHD", pObj.HDNX_SONGAYHD);
                sqlCmd.Parameters.AddWithValue("@HDNX_STT", pObj.HDNX_STT);
                sqlCmd.Parameters.AddWithValue("@HDNX_TONGMUA", pObj.HDNX_TONGMUA);
                sqlCmd.Parameters.AddWithValue("@HDNX_TONGVAT", pObj.HDNX_TONGVAT);
                sqlCmd.Parameters.AddWithValue("@HDNX_THANHTIEN", pObj.HDNX_THANHTIEN);
                sqlCmd.Parameters.AddWithValue("@HDNX_TRANGTHAI", pObj.HDNX_TRANGTHAI);
                sqlCmd.Parameters.AddWithValue("@HDNX_VAT", pObj.HDNX_VAT);
                sqlCmd.Parameters.AddWithValue("@HH_MAHANG", pObj.HH_MAHANG);
                sqlCmd.Parameters.AddWithValue("@KH_MAKHO", pObj.KH_MAKHO);
                sqlCmd.Parameters.AddWithValue("@HDNX_HANSUDUNG", pObj.HDNX_HANSUDUNG);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.ExecuteNonQuery();
            }
        }

        public static DataTable bangKeNhapKhac(string pMaKho, DateTime pTuNgay, DateTime pDenNgay, bool pCaNam)
        {
            DataTable dt = new DataTable();
            SqlConnection connect;
            List<HD_NHAPXUAT> objList = new List<HD_NHAPXUAT>();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectHdBangKeNhapKhac", connect);
                    sqlCmd.Parameters.AddWithValue("@CANAM", pCaNam ? 1 : 0);
                    sqlCmd.Parameters.AddWithValue("@MAKHO", pMaKho);
                    sqlCmd.Parameters.AddWithValue("@TUNGAY", pTuNgay.Year < 2000 ? DateTime.Now.AddYears(-1) : pTuNgay);
                    sqlCmd.Parameters.AddWithValue("@DENNGAY", pDenNgay.Year < 2000 ? DateTime.Now : pDenNgay);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlCmd;
                    da.Fill(dt);
                    /*
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            HD_NHAPXUAT obj = new HD_NHAPXUAT();
                            obj.HDNX_CHIECKHAU = dr["HDNX_CHIECKHAU"].ToString() != "" ? double.Parse(dr["HDNX_CHIECKHAU"].ToString()) : 0;
                            obj.HDNX_DAIN = dr["HDNX_DAIN"].ToString() != "" ? Int32.Parse(dr["HDNX_DAIN"].ToString()) : 0;
                            obj.HDNX_GHICHU = dr["HDNX_GHICHU"].ToString();
                            obj.HDNX_GIABAN = dr["HDNX_GIABAN"].ToString() != "" ? Decimal.Parse(dr["HDNX_GIABAN"].ToString()) : 0;
                            obj.HDNX_GIAMKHAC = dr["HDNX_GIAMKHAC"].ToString() != "" ? Decimal.Parse(dr["HDNX_GIAMKHAC"].ToString()) : 0;
                            obj.HDNX_GIAMUA = dr["HDNX_GIAMUA"].ToString() != "" ? Decimal.Parse(dr["HDNX_GIAMUA"].ToString()) : 0;
                            obj.HDNX_GIAVAT = dr["HDNX_GIAVAT"].ToString() != "" ? Decimal.Parse(dr["HDNX_GIAVAT"].ToString()) : 0;
                            obj.HDNX_KHACHDUA = dr["HDNX_KHACHDUA"].ToString() != "" ? Decimal.Parse(dr["HDNX_KHACHDUA"].ToString()): 0;
                            obj.HDNX_LOAIHD = dr["HDNX_LOAIHD"].ToString();
                            obj.HDNX_NGAYCAPNHAT = dr["HDNX_NGAYCAPNHAT"].ToString() != "" ? DateTime.Parse(dr["HDNX_NGAYCAPNHAT"].ToString()) : new DateTime(1990, 01, 01);
                            obj.HDNX_NGAYHD = dr["HDNX_NGAYHD"].ToString() != "" ? DateTime.Parse(dr["HDNX_NGAYHD"].ToString()) : new DateTime(1990, 01, 01);
                            obj.HDNX_NGAYIN = dr["HDNX_NGAYIN"].ToString() != "" ? DateTime.Parse(dr["HDNX_NGAYIN"].ToString()) : new DateTime(1990, 01, 01);
                            obj.HDNX_NGAYLAP = dr["HDNX_NGAYLAP"].ToString() != "" ? DateTime.Parse(dr["HDNX_NGAYLAP"].ToString()) : new DateTime(1990, 01, 01);
                            obj.HDNX_NGAYTT = dr["HDNX_NGAYTT"].ToString() != "" ? DateTime.Parse(dr["HDNX_NGAYTT"].ToString()) : new DateTime(1990, 01, 01);
                            obj.HDNX_QUIDOI = dr["HDNX_QUIDOI"].ToString() != "" ? Int32.Parse(dr["HDNX_QUIDOI"].ToString()) : 0;
                            obj.HDNX_SOHD = dr["HDNX_SOHD"].ToString();
                            obj.HDNX_SOHDNB = dr["HDNX_SOHDNB"].ToString();
                            obj.HDNX_SOLUONG = dr["HDNX_SOLUONG"].ToString() != "" ? Double.Parse(dr["HDNX_SOLUONG"].ToString()) : 0;
                            obj.HDNX_SONGAYHD = dr["HDNX_SONGAYHD"].ToString() != "" ? Int32.Parse(dr["HDNX_SONGAYHD"].ToString()): 0;
                            obj.HDNX_STT = dr["HDNX_STT"].ToString() != "" ? Int32.Parse(dr["HDNX_STT"].ToString()) : 0;
                            obj.HDNX_TONGBAN = dr["HDNX_TONGBAN"].ToString() != "" ? Decimal.Parse(dr["HDNX_TONGBAN"].ToString()) : 0;
                            obj.HDNX_TONGCHIECKHAU = dr["HDNX_TONGCHIECKHAU"].ToString() != "" ? Decimal.Parse(dr["HDNX_TONGCHIECKHAU"].ToString()) : 0;
                            obj.HDNX_TONGMUA = dr["HDNX_TONGMUA"].ToString() != "" ? Decimal.Parse(dr["HDNX_TONGMUA"].ToString()) : 0;
                            obj.HDNX_TONGVAT = dr["HDNX_TONGVAT"].ToString() != "" ? Decimal.Parse(dr["HDNX_TONGVAT"].ToString()) : 0;
                            obj.HDNX_THANHTIEN = dr["HDNX_THANHTIEN"].ToString() != "" ? Decimal.Parse(dr["HDNX_THANHTIEN"].ToString()) : 0;
                            obj.HDNX_TRAHANG = dr["HDNX_TRAHANG"].ToString() != "" ?Int32.Parse(dr["HDNX_TRAHANG"].ToString()) : 0;
                            obj.HDNX_TRANGTHAI = dr["HDNX_TRANGTHAI"].ToString() != "" ? Int32.Parse(dr["HDNX_TRANGTHAI"].ToString()) : 0;
                            obj.HDNX_VAT = dr["HDNX_VAT"].ToString() != "" ? Double.Parse(dr["HDNX_VAT"].ToString()) : 0;
                            obj.HDTT_MATT = dr["HDTT_MATT"].ToString();
                            obj.HH_MAHANG = dr["HH_MAHANG"].ToString();
                            obj.KH_MAKHO = dr["KH_MAKHO"].ToString();
                            obj.NPP_MANPP = dr["NPP_MANPP"].ToString();
                            obj.NV_MANV = dr["NV_MANV"].ToString();
                            obj.NV_TAIKHOAN = dr["NV_TAIKHOAN"].ToString();
                            objList.Add(obj);
                        }
                    }
                     */
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return dt;
        }
        #endregion

        #region XUẤT LẺ
        public static HD_NHAPXUAT layHoaDonXuatLeTheoMa(string pMa)
        {
            SqlDataReader dr;
            SqlConnection connect;
            HD_NHAPXUAT obj = new HD_NHAPXUAT();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectHdXuatkho", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.Parameters.AddWithValue("@HDNX_ID", pMa);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj.HDNX_CHIECKHAU = double.Parse(dr["HDNX_CHIECKHAU"].ToString());
                            obj.HDNX_DAIN = Int32.Parse(dr["HDNX_DAIN"].ToString());
                            obj.HDNX_GHICHU = dr["HDNX_GHICHU"].ToString();
                            obj.HDNX_GIABAN = Decimal.Parse(dr["HDNX_GIABAN"].ToString());
                            obj.HDNX_GIAMKHAC = Decimal.Parse(dr["HDNX_GIAMKHAC"].ToString());
                            obj.HDNX_GIAMUA = Decimal.Parse(dr["HDNX_GIAMUA"].ToString());
                            obj.HDNX_GIAVAT = Decimal.Parse(dr["HDNX_GIAVAT"].ToString());
                            obj.HDNX_KHACHDUA = Decimal.Parse(dr["HDNX_KHACHDUA"].ToString());
                            obj.HDNX_LOAIHD = dr["HDNX_LOAIHD"].ToString();
                            obj.HDNX_NGAYCAPNHAT = DateTime.Parse(dr["HDNX_NGAYCAPNHAT"].ToString());
                            obj.HDNX_NGAYHD = DateTime.Parse(dr["HDNX_NGAYHD"].ToString());
                            obj.HDNX_NGAYIN = DateTime.Parse(dr["HDNX_NGAYIN"].ToString());
                            obj.HDNX_NGAYLAP = DateTime.Parse(dr["HDNX_NGAYLAP"].ToString());
                            obj.HDNX_NGAYTT = DateTime.Parse(dr["HDNX_NGAYTT"].ToString());
                            obj.HDNX_QUIDOI = Int32.Parse(dr["HDNX_QUIDOI"].ToString());
                            obj.HDNX_SOHD = dr["HDNX_SOHD"].ToString();
                            obj.HDNX_SOHDNB = dr["HDNX_SOHDNB"].ToString();
                            obj.HDNX_SOLUONG = Double.Parse(dr["HDNX_SOLUONG"].ToString());
                            obj.HDNX_SONGAYHD = Int32.Parse(dr["HDNX_SONGAYHD"].ToString());
                            obj.HDNX_STT = Int32.Parse(dr["HDNX_STT"].ToString());
                            obj.HDNX_TONGBAN = Decimal.Parse(dr["HDNX_TONGBAN"].ToString());
                            obj.HDNX_TONGCHIECKHAU = Decimal.Parse(dr["HDNX_TONGCHIECKHAU"].ToString());
                            obj.HDNX_TONGMUA = Decimal.Parse(dr["HDNX_TONGMUA"].ToString());
                            obj.HDNX_TONGVAT = Decimal.Parse(dr["HDNX_TONGVAT"].ToString());
                            obj.HDNX_THANHTIEN = Decimal.Parse(dr["HDNX_THANHTIEN"].ToString());
                            obj.HDNX_TRAHANG = Int32.Parse(dr["HDNX_TRAHANG"].ToString());
                            obj.HDNX_TRANGTHAI = Int32.Parse(dr["HDNX_TRANGTHAI"].ToString());
                            obj.HDNX_VAT = Double.Parse(dr["HDNX_VAT"].ToString());
                            obj.HDTT_MATT = dr["HDTT_MATT"].ToString();
                            obj.HH_MAHANG = dr["HH_MAHANG"].ToString();
                            obj.KH_MAKHO = dr["KH_MAKHO"].ToString();
                            obj.NPP_MANPP = dr["NPP_MANPP"].ToString();
                            obj.NV_MANV = dr["NV_MANV"].ToString();
                            obj.NV_TAIKHOAN = dr["NV_TAIKHOAN"].ToString();
                        }
                    }
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return obj;
        }

        public static List<HD_NHAPXUAT> layDSHoaDonXuatLeTheoSHDNB(string pSHDNB)
        {
            SqlDataReader dr;
            SqlConnection connect;
            List<HD_NHAPXUAT> objList = new List<HD_NHAPXUAT>();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectHdXuatLeBySHDNB", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.Parameters.AddWithValue("@HDNX_SOHDNB", pSHDNB);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            HD_NHAPXUAT obj = new HD_NHAPXUAT();
                            obj.HDNX_LOAIHD = dr["HDNX_LOAIHD"].ToString();
                            obj.HDNX_SOHDNB = dr["HDNX_SOHDNB"].ToString();
                            obj.HDNX_NGAYLAP = DateTime.Parse(dr["HDNX_NGAYLAP"].ToString());
                            obj.HH_MAHANG = dr["HH_MAHANG"].ToString();
                            obj.HDNX_SOLUONG = Double.Parse(dr["HDNX_SOLUONG"].ToString());
                            obj.HDNX_VAT = Double.Parse(dr["HDNX_VAT"].ToString());
                            obj.HDNX_GIAVAT = Decimal.Parse(dr["HDNX_GIAVAT"].ToString());
                            obj.HDNX_TONGVAT = Decimal.Parse(dr["HDNX_TONGVAT"].ToString());
                            obj.HDNX_GIAMUA = Decimal.Parse(dr["HDNX_GIAMUA"].ToString());
                            obj.HDNX_TONGMUA = Decimal.Parse(dr["HDNX_TONGMUA"].ToString());
                            obj.HDNX_GIABAN = Decimal.Parse(dr["HDNX_GIABAN"].ToString());
                            obj.HDNX_TONGBAN = Decimal.Parse(dr["HDNX_TONGBAN"].ToString());
                            obj.HDNX_THANHTIEN = Decimal.Parse(dr["HDNX_THANHTIEN"].ToString());
                            obj.HDNX_CHIECKHAU = double.Parse(dr["HDNX_CHIECKHAU"].ToString());
                            obj.HDNX_TONGCHIECKHAU = Decimal.Parse(dr["HDNX_TONGCHIECKHAU"].ToString());
                            obj.HDNX_GIAMKHAC = Decimal.Parse(dr["HDNX_GIAMKHAC"].ToString());
                            obj.HDNX_KHACHDUA = Decimal.Parse(dr["HDNX_KHACHDUA"].ToString());
                            obj.HDNX_THOILAI = dr["HDNX_THOILAI"].ToString() != "" ? Decimal.Parse(dr["HDNX_THOILAI"].ToString()) : 0;
                            obj.HDNX_TRAHANG = dr["HDNX_TRAHANG"].ToString() != "" ? Int32.Parse(dr["HDNX_TRAHANG"].ToString()) : 0;
                            obj.HDNX_STT = Int32.Parse(dr["HDNX_STT"].ToString());
                            obj.HDNX_SOHD = dr["HDNX_SOHD"].ToString();
                            obj.HDNX_NGAYHD = DateTime.Parse(dr["HDNX_NGAYHD"].ToString());
                            obj.NPP_MANPP = dr["NPP_MANPP"].ToString();
                            obj.HDNX_GHICHU = dr["HDNX_GHICHU"].ToString();
                            obj.KH_MAKHO = dr["KH_MAKHO"].ToString();
                            obj.HDNX_TRANGTHAI = Int32.Parse(dr["HDNX_TRANGTHAI"].ToString());
                            objList.Add(obj);
                        }
                    }
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return objList;
        }

        public static List<HD_NHAPXUAT> layDSHoaDonXuatLe()
        {
            SqlDataReader dr;
            SqlConnection connect;
            HD_NHAPXUAT obj = new HD_NHAPXUAT();
            List<HD_NHAPXUAT> objList = new List<HD_NHAPXUAT>();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectHdXuatkhosAll", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj.HDNX_CHIECKHAU = double.Parse(dr["HDNX_CHIECKHAU"].ToString());
                            obj.HDNX_DAIN = Int32.Parse(dr["HDNX_DAIN"].ToString());
                            obj.HDNX_GHICHU = dr["HDNX_GHICHU"].ToString();
                            obj.HDNX_GIABAN = Decimal.Parse(dr["HDNX_GIABAN"].ToString());
                            obj.HDNX_GIAMKHAC = Decimal.Parse(dr["HDNX_GIAMKHAC"].ToString());
                            obj.HDNX_GIAMUA = Decimal.Parse(dr["HDNX_GIAMUA"].ToString());
                            obj.HDNX_GIAVAT = Decimal.Parse(dr["HDNX_GIAVAT"].ToString());
                            obj.HDNX_KHACHDUA = Decimal.Parse(dr["HDNX_KHACHDUA"].ToString());
                            obj.HDNX_LOAIHD = dr["HDNX_LOAIHD"].ToString();
                            obj.HDNX_NGAYCAPNHAT = DateTime.Parse(dr["HDNX_NGAYCAPNHAT"].ToString());
                            obj.HDNX_NGAYHD = DateTime.Parse(dr["HDNX_NGAYHD"].ToString());
                            obj.HDNX_NGAYIN = DateTime.Parse(dr["HDNX_NGAYIN"].ToString());
                            obj.HDNX_NGAYLAP = DateTime.Parse(dr["HDNX_NGAYLAP"].ToString());
                            obj.HDNX_NGAYTT = DateTime.Parse(dr["HDNX_NGAYTT"].ToString());
                            obj.HDNX_QUIDOI = Int32.Parse(dr["HDNX_QUIDOI"].ToString());
                            obj.HDNX_SOHD = dr["HDNX_SOHD"].ToString();
                            obj.HDNX_SOHDNB = dr["HDNX_SOHDNB"].ToString();
                            obj.HDNX_SOLUONG = Double.Parse(dr["HDNX_SOLUONG"].ToString());
                            obj.HDNX_SONGAYHD = Int32.Parse(dr["HDNX_SONGAYHD"].ToString());
                            obj.HDNX_STT = Int32.Parse(dr["HDNX_STT"].ToString());
                            obj.HDNX_TONGBAN = Decimal.Parse(dr["HDNX_TONGBAN"].ToString());
                            obj.HDNX_TONGCHIECKHAU = Decimal.Parse(dr["HDNX_TONGCHIECKHAU"].ToString());
                            obj.HDNX_TONGMUA = Decimal.Parse(dr["HDNX_TONGMUA"].ToString());
                            obj.HDNX_TONGVAT = Decimal.Parse(dr["HDNX_TONGVAT"].ToString());
                            obj.HDNX_THANHTIEN = Decimal.Parse(dr["HDNX_THANHTIEN"].ToString());
                            obj.HDNX_TRAHANG = Int32.Parse(dr["HDNX_TRAHANG"].ToString());
                            obj.HDNX_TRANGTHAI = Int32.Parse(dr["HDNX_TRANGTHAI"].ToString());
                            obj.HDNX_VAT = Double.Parse(dr["HDNX_VAT"].ToString());
                            obj.HDTT_MATT = dr["HDTT_MATT"].ToString();
                            obj.HH_MAHANG = dr["HH_MAHANG"].ToString();
                            obj.KH_MAKHO = dr["KH_MAKHO"].ToString();
                            obj.NPP_MANPP = dr["NPP_MANPP"].ToString();
                            obj.NV_MANV = dr["NV_MANV"].ToString();
                            obj.NV_TAIKHOAN = dr["NV_TAIKHOAN"].ToString();
                            objList.Add(obj);
                        }
                    }
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            return objList;
        }

        public static List<HD_NHAPXUAT> layDSHoaDonXuatLeDSLeft()
        {
            SqlDataReader dr;
            SqlConnection connect;
            List<HD_NHAPXUAT> objList = new List<HD_NHAPXUAT>();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectHdXuatLeDSLeft", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            HD_NHAPXUAT obj = new HD_NHAPXUAT();
                            obj.HDNX_NGAYHD = DateTime.Parse(dr["HDNX_NGAYHD"].ToString());
                            obj.HDNX_SOHD = dr["HDNX_SOHD"].ToString();
                            obj.HDNX_SOHDNB = dr["HDNX_SOHDNB"].ToString();
                            objList.Add(obj);
                        }
                    }
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return objList;
        }

        public static List<HD_NHAPXUAT> layDSHoaDonXuatLeTheoKhoangThoiGian(int pKhoangThoiGian)
        {
            SqlDataReader dr;
            SqlConnection connect;
            List<HD_NHAPXUAT> objList = new List<HD_NHAPXUAT>();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectHdXuatLeByPeriod", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.Parameters.AddWithValue("@Period", pKhoangThoiGian);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            HD_NHAPXUAT obj = new HD_NHAPXUAT();
                            obj.HDNX_NGAYHD = DateTime.Parse(dr["HDNX_NGAYHD"].ToString());
                            obj.HDNX_SOHD = dr["HDNX_SOHD"].ToString();
                            obj.HDNX_SOHDNB = dr["HDNX_SOHDNB"].ToString();
                            objList.Add(obj);
                        }
                    }
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return objList;
        }

        public static HD_NHAPXUAT layThongTinHoaDonXuatLe(string pMa)
        {
            SqlDataReader dr;
            SqlConnection connect;
            HD_NHAPXUAT obj = new HD_NHAPXUAT();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectHdThongTinCoBanXuatLeBySHDNB", connect);
                    sqlCmd.Parameters.AddWithValue("@HDNX_SOHDNB", pMa);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj.HDNX_NGAYHD = DateTime.Parse(dr["HDNX_NGAYHD"].ToString());
                            obj.HDNX_SOHD = dr["HDNX_SOHD"].ToString();
                            obj.HDNX_SOHDNB = dr["HDNX_SOHDNB"].ToString();
                            obj.HDNX_NGAYLAP = DateTime.Parse(dr["HDNX_NGAYLAP"].ToString());
                        }
                    }
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return obj;
        }

        public static void themHoaDonXuatLe(HD_NHAPXUAT pObj)
        {
            using (SqlConnection connect = ConnectDatabase())
            {
                connect.Open();
                SqlCommand sqlCmd = new SqlCommand("InsertHdXuatLe", connect);
                sqlCmd.CommandTimeout = 1000;
                sqlCmd.Parameters.AddWithValue("@HDNX_LOAIHD", pObj.HDNX_LOAIHD);
                sqlCmd.Parameters.AddWithValue("@HDNX_SOHDNB", pObj.HDNX_SOHDNB);
                sqlCmd.Parameters.AddWithValue("@HDNX_NGAYLAP", pObj.HDNX_NGAYLAP);
                sqlCmd.Parameters.AddWithValue("@HH_MAHANG", pObj.HH_MAHANG);
                sqlCmd.Parameters.AddWithValue("@HDNX_SOLUONG", pObj.HDNX_SOLUONG);
                sqlCmd.Parameters.AddWithValue("@HDNX_GIABAN", pObj.HDNX_GIABAN);
                sqlCmd.Parameters.AddWithValue("@HDNX_TONGBAN", pObj.HDNX_TONGBAN);
                sqlCmd.Parameters.AddWithValue("@HDNX_THANHTIEN", pObj.HDNX_THANHTIEN);
                sqlCmd.Parameters.AddWithValue("@HDNX_CHIECKHAU", pObj.HDNX_CHIECKHAU);
                sqlCmd.Parameters.AddWithValue("@HDNX_TONGCHIECKHAU", pObj.HDNX_TONGCHIECKHAU);
                sqlCmd.Parameters.AddWithValue("@HDNX_GIAMKHAC", pObj.HDNX_GIAMKHAC);
                sqlCmd.Parameters.AddWithValue("@HDNX_KHACHDUA", pObj.HDNX_KHACHDUA);
                sqlCmd.Parameters.AddWithValue("@HDNX_THOILAI", pObj.HDNX_THOILAI);
                sqlCmd.Parameters.AddWithValue("@HDNX_TRAHANG", pObj.HDNX_TRAHANG);
                sqlCmd.Parameters.AddWithValue("@HDNX_STT", pObj.HDNX_STT);
                sqlCmd.Parameters.AddWithValue("@HDNX_SOHD", pObj.HDNX_SOHD);
                sqlCmd.Parameters.AddWithValue("@HDNX_NGAYHD", pObj.HDNX_NGAYHD);
                sqlCmd.Parameters.AddWithValue("@HDNX_SONGAYHD", pObj.HDNX_SONGAYHD);
                sqlCmd.Parameters.AddWithValue("@NPP_MANPP", pObj.NPP_MANPP);
                sqlCmd.Parameters.AddWithValue("@HDNX_GHICHU", pObj.HDNX_GHICHU);
                sqlCmd.Parameters.AddWithValue("@KH_MAKHO", pObj.KH_MAKHO);
                sqlCmd.Parameters.AddWithValue("@HDNX_TRANGTHAI", pObj.HDNX_TRANGTHAI);
                //
                sqlCmd.Parameters.AddWithValue("@HDNX_GIAMUA", pObj.HDNX_GIAMUA);
                sqlCmd.Parameters.AddWithValue("@HDNX_VAT", pObj.HDNX_VAT);
                sqlCmd.Parameters.AddWithValue("@HDNX_GIAVAT", pObj.HDNX_GIAVAT);
                sqlCmd.Parameters.AddWithValue("@HDNX_TONGVAT", pObj.HDNX_TONGVAT);
                sqlCmd.Parameters.AddWithValue("@HDNX_TONGMUA", pObj.HDNX_TONGMUA);
                sqlCmd.Parameters.AddWithValue("@HDNX_GHINO", pObj.HDNX_GHINO);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.ExecuteNonQuery();
            }
        }

        public static void capNhatHoaDonXuatLe(HD_NHAPXUAT pObj)
        {
            using (SqlConnection connect = ConnectDatabase())
            {
                connect.Open();
                SqlCommand sqlCmd = new SqlCommand("InsertHdXuatLe2", connect);
                sqlCmd.CommandTimeout = 1000;
                sqlCmd.Parameters.AddWithValue("@HDNX_LOAIHD", pObj.HDNX_LOAIHD);
                sqlCmd.Parameters.AddWithValue("@HDNX_SOHDNB", pObj.HDNX_SOHDNB);
                sqlCmd.Parameters.AddWithValue("@HDNX_NGAYLAP", pObj.HDNX_NGAYLAP);
                sqlCmd.Parameters.AddWithValue("@HDNX_NGAYCAPNHAT", pObj.HDNX_NGAYCAPNHAT);
                sqlCmd.Parameters.AddWithValue("@HH_MAHANG", pObj.HH_MAHANG);
                sqlCmd.Parameters.AddWithValue("@HDNX_SOLUONG", pObj.HDNX_SOLUONG);
                sqlCmd.Parameters.AddWithValue("@HDNX_GIABAN", pObj.HDNX_GIABAN);
                sqlCmd.Parameters.AddWithValue("@HDNX_TONGBAN", pObj.HDNX_TONGBAN);
                sqlCmd.Parameters.AddWithValue("@HDNX_THANHTIEN", pObj.HDNX_THANHTIEN);
                sqlCmd.Parameters.AddWithValue("@HDNX_CHIECKHAU", pObj.HDNX_CHIECKHAU);
                sqlCmd.Parameters.AddWithValue("@HDNX_TONGCHIECKHAU", pObj.HDNX_TONGCHIECKHAU);
                sqlCmd.Parameters.AddWithValue("@HDNX_GIAMKHAC", pObj.HDNX_GIAMKHAC);
                sqlCmd.Parameters.AddWithValue("@HDNX_KHACHDUA", pObj.HDNX_KHACHDUA);
                sqlCmd.Parameters.AddWithValue("@HDNX_THOILAI", pObj.HDNX_THOILAI);
                sqlCmd.Parameters.AddWithValue("@HDNX_TRAHANG", pObj.HDNX_TRAHANG);
                sqlCmd.Parameters.AddWithValue("@HDNX_STT", pObj.HDNX_STT);
                sqlCmd.Parameters.AddWithValue("@HDNX_SOHD", pObj.HDNX_SOHD);
                sqlCmd.Parameters.AddWithValue("@HDNX_NGAYHD", pObj.HDNX_NGAYHD);
                sqlCmd.Parameters.AddWithValue("@HDNX_SONGAYHD", pObj.HDNX_SONGAYHD);
                sqlCmd.Parameters.AddWithValue("@NPP_MANPP", pObj.NPP_MANPP);
                sqlCmd.Parameters.AddWithValue("@HDNX_GHICHU", pObj.HDNX_GHICHU);
                sqlCmd.Parameters.AddWithValue("@KH_MAKHO", pObj.KH_MAKHO);
                sqlCmd.Parameters.AddWithValue("@HDNX_TRANGTHAI", pObj.HDNX_TRANGTHAI);
                //
                sqlCmd.Parameters.AddWithValue("@HDNX_GIAMUA", pObj.HDNX_GIAMUA);
                sqlCmd.Parameters.AddWithValue("@HDNX_VAT", pObj.HDNX_VAT);
                sqlCmd.Parameters.AddWithValue("@HDNX_GIAVAT", pObj.HDNX_GIAVAT);
                sqlCmd.Parameters.AddWithValue("@HDNX_TONGVAT", pObj.HDNX_TONGVAT);
                sqlCmd.Parameters.AddWithValue("@HDNX_TONGMUA", pObj.HDNX_TONGMUA);
                sqlCmd.Parameters.AddWithValue("@HDNX_GHINO", pObj.HDNX_GHINO);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.ExecuteNonQuery();
            }
        }

        public static DataTable bangKeXuatLe(string pMaKho, DateTime pTuNgay, DateTime pDenNgay, bool pCaNam)
        {
            DataTable dt = new DataTable();
            SqlConnection connect;
            List<HD_NHAPXUAT> objList = new List<HD_NHAPXUAT>();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectHdBangKeXuatLe", connect);
                    sqlCmd.Parameters.AddWithValue("@CANAM", pCaNam ? 1 : 0);
                    sqlCmd.Parameters.AddWithValue("@MAKHO", pMaKho);
                    sqlCmd.Parameters.AddWithValue("@TUNGAY", pTuNgay.Year < 2000 ? DateTime.Now.AddYears(-1) : pTuNgay);
                    sqlCmd.Parameters.AddWithValue("@DENNGAY", pDenNgay.Year < 2000 ? DateTime.Now : pDenNgay);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlCmd;
                    da.Fill(dt);
                    /*
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            HD_NHAPXUAT obj = new HD_NHAPXUAT();
                            obj.HDNX_CHIECKHAU = dr["HDNX_CHIECKHAU"].ToString() != "" ? double.Parse(dr["HDNX_CHIECKHAU"].ToString()) : 0;
                            obj.HDNX_DAIN = dr["HDNX_DAIN"].ToString() != "" ? Int32.Parse(dr["HDNX_DAIN"].ToString()) : 0;
                            obj.HDNX_GHICHU = dr["HDNX_GHICHU"].ToString();
                            obj.HDNX_GIABAN = dr["HDNX_GIABAN"].ToString() != "" ? Decimal.Parse(dr["HDNX_GIABAN"].ToString()) : 0;
                            obj.HDNX_GIAMKHAC = dr["HDNX_GIAMKHAC"].ToString() != "" ? Decimal.Parse(dr["HDNX_GIAMKHAC"].ToString()) : 0;
                            obj.HDNX_GIAMUA = dr["HDNX_GIAMUA"].ToString() != "" ? Decimal.Parse(dr["HDNX_GIAMUA"].ToString()) : 0;
                            obj.HDNX_GIAVAT = dr["HDNX_GIAVAT"].ToString() != "" ? Decimal.Parse(dr["HDNX_GIAVAT"].ToString()) : 0;
                            obj.HDNX_KHACHDUA = dr["HDNX_KHACHDUA"].ToString() != "" ? Decimal.Parse(dr["HDNX_KHACHDUA"].ToString()): 0;
                            obj.HDNX_LOAIHD = dr["HDNX_LOAIHD"].ToString();
                            obj.HDNX_NGAYCAPNHAT = dr["HDNX_NGAYCAPNHAT"].ToString() != "" ? DateTime.Parse(dr["HDNX_NGAYCAPNHAT"].ToString()) : new DateTime(1990, 01, 01);
                            obj.HDNX_NGAYHD = dr["HDNX_NGAYHD"].ToString() != "" ? DateTime.Parse(dr["HDNX_NGAYHD"].ToString()) : new DateTime(1990, 01, 01);
                            obj.HDNX_NGAYIN = dr["HDNX_NGAYIN"].ToString() != "" ? DateTime.Parse(dr["HDNX_NGAYIN"].ToString()) : new DateTime(1990, 01, 01);
                            obj.HDNX_NGAYLAP = dr["HDNX_NGAYLAP"].ToString() != "" ? DateTime.Parse(dr["HDNX_NGAYLAP"].ToString()) : new DateTime(1990, 01, 01);
                            obj.HDNX_NGAYTT = dr["HDNX_NGAYTT"].ToString() != "" ? DateTime.Parse(dr["HDNX_NGAYTT"].ToString()) : new DateTime(1990, 01, 01);
                            obj.HDNX_QUIDOI = dr["HDNX_QUIDOI"].ToString() != "" ? Int32.Parse(dr["HDNX_QUIDOI"].ToString()) : 0;
                            obj.HDNX_SOHD = dr["HDNX_SOHD"].ToString();
                            obj.HDNX_SOHDNB = dr["HDNX_SOHDNB"].ToString();
                            obj.HDNX_SOLUONG = dr["HDNX_SOLUONG"].ToString() != "" ? Double.Parse(dr["HDNX_SOLUONG"].ToString()) : 0;
                            obj.HDNX_SONGAYHD = dr["HDNX_SONGAYHD"].ToString() != "" ? Int32.Parse(dr["HDNX_SONGAYHD"].ToString()): 0;
                            obj.HDNX_STT = dr["HDNX_STT"].ToString() != "" ? Int32.Parse(dr["HDNX_STT"].ToString()) : 0;
                            obj.HDNX_TONGBAN = dr["HDNX_TONGBAN"].ToString() != "" ? Decimal.Parse(dr["HDNX_TONGBAN"].ToString()) : 0;
                            obj.HDNX_TONGCHIECKHAU = dr["HDNX_TONGCHIECKHAU"].ToString() != "" ? Decimal.Parse(dr["HDNX_TONGCHIECKHAU"].ToString()) : 0;
                            obj.HDNX_TONGMUA = dr["HDNX_TONGMUA"].ToString() != "" ? Decimal.Parse(dr["HDNX_TONGMUA"].ToString()) : 0;
                            obj.HDNX_TONGVAT = dr["HDNX_TONGVAT"].ToString() != "" ? Decimal.Parse(dr["HDNX_TONGVAT"].ToString()) : 0;
                            obj.HDNX_THANHTIEN = dr["HDNX_THANHTIEN"].ToString() != "" ? Decimal.Parse(dr["HDNX_THANHTIEN"].ToString()) : 0;
                            obj.HDNX_TRAHANG = dr["HDNX_TRAHANG"].ToString() != "" ?Int32.Parse(dr["HDNX_TRAHANG"].ToString()) : 0;
                            obj.HDNX_TRANGTHAI = dr["HDNX_TRANGTHAI"].ToString() != "" ? Int32.Parse(dr["HDNX_TRANGTHAI"].ToString()) : 0;
                            obj.HDNX_VAT = dr["HDNX_VAT"].ToString() != "" ? Double.Parse(dr["HDNX_VAT"].ToString()) : 0;
                            obj.HDTT_MATT = dr["HDTT_MATT"].ToString();
                            obj.HH_MAHANG = dr["HH_MAHANG"].ToString();
                            obj.KH_MAKHO = dr["KH_MAKHO"].ToString();
                            obj.NPP_MANPP = dr["NPP_MANPP"].ToString();
                            obj.NV_MANV = dr["NV_MANV"].ToString();
                            obj.NV_TAIKHOAN = dr["NV_TAIKHOAN"].ToString();
                            objList.Add(obj);
                        }
                    }
                     */
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return dt;
        }
        #endregion

        #region XUẤT SỈ
        public static List<HD_NHAPXUAT> layDSHoaDonXuatSiTheoSHDNB(string pSHDNB)
        {
            SqlDataReader dr;
            SqlConnection connect;
            List<HD_NHAPXUAT> objList = new List<HD_NHAPXUAT>();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectHdXuatSiBySHDNB", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.Parameters.AddWithValue("@HDNX_SOHDNB", pSHDNB);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            HD_NHAPXUAT obj = new HD_NHAPXUAT();
                            obj.HDNX_LOAIHD = dr["HDNX_LOAIHD"].ToString();
                            obj.HDNX_SOHDNB = dr["HDNX_SOHDNB"].ToString();
                            obj.HDNX_NGAYLAP = DateTime.Parse(dr["HDNX_NGAYLAP"].ToString());
                            obj.HH_MAHANG = dr["HH_MAHANG"].ToString();
                            obj.HDNX_SOLUONG = Double.Parse(dr["HDNX_SOLUONG"].ToString());
                            obj.HDNX_VAT = Double.Parse(dr["HDNX_VAT"].ToString());
                            obj.HDNX_GIAVAT = Decimal.Parse(dr["HDNX_GIAVAT"].ToString());
                            obj.HDNX_TONGVAT = Decimal.Parse(dr["HDNX_TONGVAT"].ToString());
                            obj.HDNX_GIAMUA = Decimal.Parse(dr["HDNX_GIAMUA"].ToString());
                            obj.HDNX_TONGMUA = Decimal.Parse(dr["HDNX_TONGMUA"].ToString());
                            obj.HDNX_GIABAN = Decimal.Parse(dr["HDNX_GIABAN"].ToString());
                            obj.HDNX_TONGBAN = Decimal.Parse(dr["HDNX_TONGBAN"].ToString());
                            obj.HDNX_THANHTIEN = Decimal.Parse(dr["HDNX_THANHTIEN"].ToString());
                            obj.HDNX_CHIECKHAU = double.Parse(dr["HDNX_CHIECKHAU"].ToString());
                            obj.HDNX_TONGCHIECKHAU = Decimal.Parse(dr["HDNX_TONGCHIECKHAU"].ToString());
                            obj.HDNX_GIAMKHAC = Decimal.Parse(dr["HDNX_GIAMKHAC"].ToString());
                            obj.HDNX_KHACHDUA = Decimal.Parse(dr["HDNX_KHACHDUA"].ToString());
                            obj.HDNX_THOILAI = dr["HDNX_THOILAI"].ToString() != "" ? Decimal.Parse(dr["HDNX_THOILAI"].ToString()) : 0;
                            obj.HDNX_TRAHANG = dr["HDNX_TRAHANG"].ToString() != "" ? Int32.Parse(dr["HDNX_TRAHANG"].ToString()) : 0;
                            obj.HDNX_STT = Int32.Parse(dr["HDNX_STT"].ToString());
                            obj.HDNX_SOHD = dr["HDNX_SOHD"].ToString();
                            obj.HDNX_NGAYHD = DateTime.Parse(dr["HDNX_NGAYHD"].ToString());
                            obj.NPP_MANPP = dr["NPP_MANPP"].ToString();
                            obj.HDNX_GHICHU = dr["HDNX_GHICHU"].ToString();
                            obj.KH_MAKHO = dr["KH_MAKHO"].ToString();
                            obj.HDNX_TRANGTHAI = Int32.Parse(dr["HDNX_TRANGTHAI"].ToString());
                            objList.Add(obj);
                        }
                    }
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return objList;
        }

        public static List<HD_NHAPXUAT> layDSHoaDonXuatSiDSLeft()
        {
            SqlDataReader dr;
            SqlConnection connect;
            List<HD_NHAPXUAT> objList = new List<HD_NHAPXUAT>();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectHdXuatSiDSLeft", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            HD_NHAPXUAT obj = new HD_NHAPXUAT();
                            obj.HDNX_NGAYHD = DateTime.Parse(dr["HDNX_NGAYHD"].ToString());
                            obj.HDNX_SOHD = dr["HDNX_SOHD"].ToString();
                            obj.HDNX_SOHDNB = dr["HDNX_SOHDNB"].ToString();
                            objList.Add(obj);
                        }
                    }
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return objList;
        }

        public static List<HD_NHAPXUAT> layDSHoaDonXuatSiTheoKhoangThoiGian(int pKhoangThoiGian)
        {
            SqlDataReader dr;
            SqlConnection connect;
            List<HD_NHAPXUAT> objList = new List<HD_NHAPXUAT>();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectHdXuatSiByPeriod", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.Parameters.AddWithValue("@Period", pKhoangThoiGian);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            HD_NHAPXUAT obj = new HD_NHAPXUAT();
                            obj.HDNX_NGAYHD = DateTime.Parse(dr["HDNX_NGAYHD"].ToString());
                            obj.HDNX_SOHD = dr["HDNX_SOHD"].ToString();
                            obj.HDNX_SOHDNB = dr["HDNX_SOHDNB"].ToString();
                            objList.Add(obj);
                        }
                    }
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return objList;
        }

        public static HD_NHAPXUAT layThongTinHoaDonXuatSi(string pMa)
        {
            SqlDataReader dr;
            SqlConnection connect;
            HD_NHAPXUAT obj = new HD_NHAPXUAT();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectHdThongTinCoBanXuatSiBySHDNB", connect);
                    sqlCmd.Parameters.AddWithValue("@HDNX_SOHDNB", pMa);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj.HDNX_NGAYHD = DateTime.Parse(dr["HDNX_NGAYHD"].ToString());
                            obj.HDNX_SOHD = dr["HDNX_SOHD"].ToString();
                            obj.HDNX_SOHDNB = dr["HDNX_SOHDNB"].ToString();
                            obj.HDNX_NGAYLAP = DateTime.Parse(dr["HDNX_NGAYLAP"].ToString());
                        }
                    }
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return obj;
        }

        public static void themHoaDonXuatSi(HD_NHAPXUAT pObj)
        {
            using (SqlConnection connect = ConnectDatabase())
            {
                connect.Open();
                SqlCommand sqlCmd = new SqlCommand("InsertHdXuatSi", connect);
                sqlCmd.CommandTimeout = 1000;
                sqlCmd.Parameters.AddWithValue("@HDNX_LOAIHD", pObj.HDNX_LOAIHD);
                sqlCmd.Parameters.AddWithValue("@HDNX_SOHDNB", pObj.HDNX_SOHDNB);
                sqlCmd.Parameters.AddWithValue("@HDNX_NGAYLAP", pObj.HDNX_NGAYLAP);
                sqlCmd.Parameters.AddWithValue("@HH_MAHANG", pObj.HH_MAHANG);
                sqlCmd.Parameters.AddWithValue("@HDNX_SOLUONG", pObj.HDNX_SOLUONG);
                sqlCmd.Parameters.AddWithValue("@HDNX_GIABAN", pObj.HDNX_GIABAN);
                sqlCmd.Parameters.AddWithValue("@HDNX_TONGBAN", pObj.HDNX_TONGBAN);
                sqlCmd.Parameters.AddWithValue("@HDNX_THANHTIEN", pObj.HDNX_THANHTIEN);
                sqlCmd.Parameters.AddWithValue("@HDNX_CHIECKHAU", pObj.HDNX_CHIECKHAU);
                sqlCmd.Parameters.AddWithValue("@HDNX_TONGCHIECKHAU", pObj.HDNX_TONGCHIECKHAU);
                sqlCmd.Parameters.AddWithValue("@HDNX_GIAMKHAC", pObj.HDNX_GIAMKHAC);
                sqlCmd.Parameters.AddWithValue("@HDNX_KHACHDUA", pObj.HDNX_KHACHDUA);
                sqlCmd.Parameters.AddWithValue("@HDNX_THOILAI", pObj.HDNX_THOILAI);
                sqlCmd.Parameters.AddWithValue("@HDNX_TRAHANG", pObj.HDNX_TRAHANG);
                sqlCmd.Parameters.AddWithValue("@HDNX_STT", pObj.HDNX_STT);
                sqlCmd.Parameters.AddWithValue("@HDNX_SOHD", pObj.HDNX_SOHD);
                sqlCmd.Parameters.AddWithValue("@HDNX_NGAYHD", pObj.HDNX_NGAYHD);
                sqlCmd.Parameters.AddWithValue("@HDNX_SONGAYHD", pObj.HDNX_SONGAYHD);
                sqlCmd.Parameters.AddWithValue("@NPP_MANPP", pObj.NPP_MANPP);
                sqlCmd.Parameters.AddWithValue("@HDNX_GHICHU", pObj.HDNX_GHICHU);
                sqlCmd.Parameters.AddWithValue("@KH_MAKHO", pObj.KH_MAKHO);
                sqlCmd.Parameters.AddWithValue("@HDNX_TRANGTHAI", pObj.HDNX_TRANGTHAI);
                //
                sqlCmd.Parameters.AddWithValue("@HDNX_GIAMUA", pObj.HDNX_GIAMUA);
                sqlCmd.Parameters.AddWithValue("@HDNX_VAT", pObj.HDNX_VAT);
                sqlCmd.Parameters.AddWithValue("@HDNX_GIAVAT", pObj.HDNX_GIAVAT);
                sqlCmd.Parameters.AddWithValue("@HDNX_TONGVAT", pObj.HDNX_TONGVAT);
                sqlCmd.Parameters.AddWithValue("@HDNX_TONGMUA", pObj.HDNX_TONGMUA);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.ExecuteNonQuery();
            }
        }

        public static void capNhatHoaDonXuatSi(HD_NHAPXUAT pObj)
        {
            using (SqlConnection connect = ConnectDatabase())
            {
                connect.Open();
                SqlCommand sqlCmd = new SqlCommand("InsertHdXuatSi2", connect);
                sqlCmd.CommandTimeout = 1000;
                sqlCmd.Parameters.AddWithValue("@HDNX_LOAIHD", pObj.HDNX_LOAIHD);
                sqlCmd.Parameters.AddWithValue("@HDNX_SOHDNB", pObj.HDNX_SOHDNB);
                sqlCmd.Parameters.AddWithValue("@HDNX_NGAYLAP", pObj.HDNX_NGAYLAP);
                sqlCmd.Parameters.AddWithValue("@HDNX_NGAYCAPNHAT", pObj.HDNX_NGAYCAPNHAT);
                sqlCmd.Parameters.AddWithValue("@HH_MAHANG", pObj.HH_MAHANG);
                sqlCmd.Parameters.AddWithValue("@HDNX_SOLUONG", pObj.HDNX_SOLUONG);
                sqlCmd.Parameters.AddWithValue("@HDNX_GIABAN", pObj.HDNX_GIABAN);
                sqlCmd.Parameters.AddWithValue("@HDNX_TONGBAN", pObj.HDNX_TONGBAN);
                sqlCmd.Parameters.AddWithValue("@HDNX_THANHTIEN", pObj.HDNX_THANHTIEN);
                sqlCmd.Parameters.AddWithValue("@HDNX_CHIECKHAU", pObj.HDNX_CHIECKHAU);
                sqlCmd.Parameters.AddWithValue("@HDNX_TONGCHIECKHAU", pObj.HDNX_TONGCHIECKHAU);
                sqlCmd.Parameters.AddWithValue("@HDNX_GIAMKHAC", pObj.HDNX_GIAMKHAC);
                sqlCmd.Parameters.AddWithValue("@HDNX_KHACHDUA", pObj.HDNX_KHACHDUA);
                sqlCmd.Parameters.AddWithValue("@HDNX_THOILAI", pObj.HDNX_THOILAI);
                sqlCmd.Parameters.AddWithValue("@HDNX_TRAHANG", pObj.HDNX_TRAHANG);
                sqlCmd.Parameters.AddWithValue("@HDNX_STT", pObj.HDNX_STT);
                sqlCmd.Parameters.AddWithValue("@HDNX_SOHD", pObj.HDNX_SOHD);
                sqlCmd.Parameters.AddWithValue("@HDNX_NGAYHD", pObj.HDNX_NGAYHD);
                sqlCmd.Parameters.AddWithValue("@HDNX_SONGAYHD", pObj.HDNX_SONGAYHD);
                sqlCmd.Parameters.AddWithValue("@NPP_MANPP", pObj.NPP_MANPP);
                sqlCmd.Parameters.AddWithValue("@HDNX_GHICHU", pObj.HDNX_GHICHU);
                sqlCmd.Parameters.AddWithValue("@KH_MAKHO", pObj.KH_MAKHO);
                sqlCmd.Parameters.AddWithValue("@HDNX_TRANGTHAI", pObj.HDNX_TRANGTHAI);
                //
                sqlCmd.Parameters.AddWithValue("@HDNX_GIAMUA", pObj.HDNX_GIAMUA);
                sqlCmd.Parameters.AddWithValue("@HDNX_VAT", pObj.HDNX_VAT);
                sqlCmd.Parameters.AddWithValue("@HDNX_GIAVAT", pObj.HDNX_GIAVAT);
                sqlCmd.Parameters.AddWithValue("@HDNX_TONGVAT", pObj.HDNX_TONGVAT);
                sqlCmd.Parameters.AddWithValue("@HDNX_TONGMUA", pObj.HDNX_TONGMUA);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.ExecuteNonQuery();
            }
        }

        public static DataTable bangKeXuatSi(string pMaKho, DateTime pTuNgay, DateTime pDenNgay, bool pCaNam)
        {
            DataTable dt = new DataTable();
            SqlConnection connect;
            List<HD_NHAPXUAT> objList = new List<HD_NHAPXUAT>();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectHdBangKeXuatSi", connect);
                    sqlCmd.Parameters.AddWithValue("@CANAM", pCaNam ? 1 : 0);
                    sqlCmd.Parameters.AddWithValue("@MAKHO", pMaKho);
                    sqlCmd.Parameters.AddWithValue("@TUNGAY", pTuNgay.Year < 2000 ? DateTime.Now.AddYears(-1) : pTuNgay);
                    sqlCmd.Parameters.AddWithValue("@DENNGAY", pDenNgay.Year < 2000 ? DateTime.Now : pDenNgay);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlCmd;
                    da.Fill(dt);
                    /*
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            HD_NHAPXUAT obj = new HD_NHAPXUAT();
                            obj.HDNX_CHIECKHAU = dr["HDNX_CHIECKHAU"].ToString() != "" ? double.Parse(dr["HDNX_CHIECKHAU"].ToString()) : 0;
                            obj.HDNX_DAIN = dr["HDNX_DAIN"].ToString() != "" ? Int32.Parse(dr["HDNX_DAIN"].ToString()) : 0;
                            obj.HDNX_GHICHU = dr["HDNX_GHICHU"].ToString();
                            obj.HDNX_GIABAN = dr["HDNX_GIABAN"].ToString() != "" ? Decimal.Parse(dr["HDNX_GIABAN"].ToString()) : 0;
                            obj.HDNX_GIAMKHAC = dr["HDNX_GIAMKHAC"].ToString() != "" ? Decimal.Parse(dr["HDNX_GIAMKHAC"].ToString()) : 0;
                            obj.HDNX_GIAMUA = dr["HDNX_GIAMUA"].ToString() != "" ? Decimal.Parse(dr["HDNX_GIAMUA"].ToString()) : 0;
                            obj.HDNX_GIAVAT = dr["HDNX_GIAVAT"].ToString() != "" ? Decimal.Parse(dr["HDNX_GIAVAT"].ToString()) : 0;
                            obj.HDNX_KHACHDUA = dr["HDNX_KHACHDUA"].ToString() != "" ? Decimal.Parse(dr["HDNX_KHACHDUA"].ToString()): 0;
                            obj.HDNX_LOAIHD = dr["HDNX_LOAIHD"].ToString();
                            obj.HDNX_NGAYCAPNHAT = dr["HDNX_NGAYCAPNHAT"].ToString() != "" ? DateTime.Parse(dr["HDNX_NGAYCAPNHAT"].ToString()) : new DateTime(1990, 01, 01);
                            obj.HDNX_NGAYHD = dr["HDNX_NGAYHD"].ToString() != "" ? DateTime.Parse(dr["HDNX_NGAYHD"].ToString()) : new DateTime(1990, 01, 01);
                            obj.HDNX_NGAYIN = dr["HDNX_NGAYIN"].ToString() != "" ? DateTime.Parse(dr["HDNX_NGAYIN"].ToString()) : new DateTime(1990, 01, 01);
                            obj.HDNX_NGAYLAP = dr["HDNX_NGAYLAP"].ToString() != "" ? DateTime.Parse(dr["HDNX_NGAYLAP"].ToString()) : new DateTime(1990, 01, 01);
                            obj.HDNX_NGAYTT = dr["HDNX_NGAYTT"].ToString() != "" ? DateTime.Parse(dr["HDNX_NGAYTT"].ToString()) : new DateTime(1990, 01, 01);
                            obj.HDNX_QUIDOI = dr["HDNX_QUIDOI"].ToString() != "" ? Int32.Parse(dr["HDNX_QUIDOI"].ToString()) : 0;
                            obj.HDNX_SOHD = dr["HDNX_SOHD"].ToString();
                            obj.HDNX_SOHDNB = dr["HDNX_SOHDNB"].ToString();
                            obj.HDNX_SOLUONG = dr["HDNX_SOLUONG"].ToString() != "" ? Double.Parse(dr["HDNX_SOLUONG"].ToString()) : 0;
                            obj.HDNX_SONGAYHD = dr["HDNX_SONGAYHD"].ToString() != "" ? Int32.Parse(dr["HDNX_SONGAYHD"].ToString()): 0;
                            obj.HDNX_STT = dr["HDNX_STT"].ToString() != "" ? Int32.Parse(dr["HDNX_STT"].ToString()) : 0;
                            obj.HDNX_TONGBAN = dr["HDNX_TONGBAN"].ToString() != "" ? Decimal.Parse(dr["HDNX_TONGBAN"].ToString()) : 0;
                            obj.HDNX_TONGCHIECKHAU = dr["HDNX_TONGCHIECKHAU"].ToString() != "" ? Decimal.Parse(dr["HDNX_TONGCHIECKHAU"].ToString()) : 0;
                            obj.HDNX_TONGMUA = dr["HDNX_TONGMUA"].ToString() != "" ? Decimal.Parse(dr["HDNX_TONGMUA"].ToString()) : 0;
                            obj.HDNX_TONGVAT = dr["HDNX_TONGVAT"].ToString() != "" ? Decimal.Parse(dr["HDNX_TONGVAT"].ToString()) : 0;
                            obj.HDNX_THANHTIEN = dr["HDNX_THANHTIEN"].ToString() != "" ? Decimal.Parse(dr["HDNX_THANHTIEN"].ToString()) : 0;
                            obj.HDNX_TRAHANG = dr["HDNX_TRAHANG"].ToString() != "" ?Int32.Parse(dr["HDNX_TRAHANG"].ToString()) : 0;
                            obj.HDNX_TRANGTHAI = dr["HDNX_TRANGTHAI"].ToString() != "" ? Int32.Parse(dr["HDNX_TRANGTHAI"].ToString()) : 0;
                            obj.HDNX_VAT = dr["HDNX_VAT"].ToString() != "" ? Double.Parse(dr["HDNX_VAT"].ToString()) : 0;
                            obj.HDTT_MATT = dr["HDTT_MATT"].ToString();
                            obj.HH_MAHANG = dr["HH_MAHANG"].ToString();
                            obj.KH_MAKHO = dr["KH_MAKHO"].ToString();
                            obj.NPP_MANPP = dr["NPP_MANPP"].ToString();
                            obj.NV_MANV = dr["NV_MANV"].ToString();
                            obj.NV_TAIKHOAN = dr["NV_TAIKHOAN"].ToString();
                            objList.Add(obj);
                        }
                    }
                     */
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return dt;
        }
        #endregion

        #region XUẤT KHÁC
        public static List<HD_NHAPXUAT> layDSHoaDonXuatKhacTheoSHDNB(string pSHDNB)
        {
            SqlDataReader dr;
            SqlConnection connect;
            List<HD_NHAPXUAT> objList = new List<HD_NHAPXUAT>();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectHdXuatKhacBySHDNB", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.Parameters.AddWithValue("@HDNX_SOHDNB", pSHDNB);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            HD_NHAPXUAT obj = new HD_NHAPXUAT();
                            obj.HDNX_LOAIHD = dr["HDNX_LOAIHD"].ToString();
                            obj.HDNX_SOHDNB = dr["HDNX_SOHDNB"].ToString();
                            obj.HDNX_NGAYLAP = DateTime.Parse(dr["HDNX_NGAYLAP"].ToString());
                            obj.HH_MAHANG = dr["HH_MAHANG"].ToString();
                            obj.HDNX_SOLUONG = Double.Parse(dr["HDNX_SOLUONG"].ToString());
                            obj.HDNX_VAT = Double.Parse(dr["HDNX_VAT"].ToString());
                            obj.HDNX_GIAVAT = Decimal.Parse(dr["HDNX_GIAVAT"].ToString());
                            obj.HDNX_TONGVAT = Decimal.Parse(dr["HDNX_TONGVAT"].ToString());
                            obj.HDNX_GIAMUA = Decimal.Parse(dr["HDNX_GIAMUA"].ToString());
                            obj.HDNX_TONGMUA = Decimal.Parse(dr["HDNX_TONGMUA"].ToString());
                            obj.HDNX_GIABAN = Decimal.Parse(dr["HDNX_GIABAN"].ToString());
                            obj.HDNX_TONGBAN = Decimal.Parse(dr["HDNX_TONGBAN"].ToString());
                            obj.HDNX_THANHTIEN = Decimal.Parse(dr["HDNX_THANHTIEN"].ToString());
                            obj.HDNX_CHIECKHAU = double.Parse(dr["HDNX_CHIECKHAU"].ToString());
                            obj.HDNX_TONGCHIECKHAU = Decimal.Parse(dr["HDNX_TONGCHIECKHAU"].ToString());
                            obj.HDNX_GIAMKHAC = Decimal.Parse(dr["HDNX_GIAMKHAC"].ToString());
                            obj.HDNX_KHACHDUA = Decimal.Parse(dr["HDNX_KHACHDUA"].ToString());
                            obj.HDNX_THOILAI = dr["HDNX_THOILAI"].ToString() != "" ? Decimal.Parse(dr["HDNX_THOILAI"].ToString()) : 0;
                            obj.HDNX_TRAHANG = dr["HDNX_TRAHANG"].ToString() != "" ? Int32.Parse(dr["HDNX_TRAHANG"].ToString()) : 0;
                            obj.HDNX_STT = Int32.Parse(dr["HDNX_STT"].ToString());
                            obj.HDNX_SOHD = dr["HDNX_SOHD"].ToString();
                            obj.HDNX_NGAYHD = DateTime.Parse(dr["HDNX_NGAYHD"].ToString());
                            obj.NPP_MANPP = dr["NPP_MANPP"].ToString();
                            obj.HDNX_GHICHU = dr["HDNX_GHICHU"].ToString();
                            obj.KH_MAKHO = dr["KH_MAKHO"].ToString();
                            obj.HDNX_TRANGTHAI = Int32.Parse(dr["HDNX_TRANGTHAI"].ToString());
                            objList.Add(obj);
                        }
                    }
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return objList;
        }

        public static List<HD_NHAPXUAT> layDSHoaDonXuatKhacDSLeft()
        {
            SqlDataReader dr;
            SqlConnection connect;
            List<HD_NHAPXUAT> objList = new List<HD_NHAPXUAT>();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectHdXuatKhacDSLeft", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            HD_NHAPXUAT obj = new HD_NHAPXUAT();
                            obj.HDNX_NGAYHD = DateTime.Parse(dr["HDNX_NGAYHD"].ToString());
                            obj.HDNX_SOHD = dr["HDNX_SOHD"].ToString();
                            obj.HDNX_SOHDNB = dr["HDNX_SOHDNB"].ToString();
                            objList.Add(obj);
                        }
                    }
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return objList;
        }

        public static List<HD_NHAPXUAT> layDSHoaDonXuatKhacTheoKhoangThoiGian(int pKhoangThoiGian)
        {
            SqlDataReader dr;
            SqlConnection connect;
            List<HD_NHAPXUAT> objList = new List<HD_NHAPXUAT>();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectHdXuatKhacByPeriod", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.Parameters.AddWithValue("@Period", pKhoangThoiGian);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            HD_NHAPXUAT obj = new HD_NHAPXUAT();
                            obj.HDNX_NGAYHD = DateTime.Parse(dr["HDNX_NGAYHD"].ToString());
                            obj.HDNX_SOHD = dr["HDNX_SOHD"].ToString();
                            obj.HDNX_SOHDNB = dr["HDNX_SOHDNB"].ToString();
                            objList.Add(obj);
                        }
                    }
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return objList;
        }

        public static HD_NHAPXUAT layThongTinHoaDonXuatKhac(string pMa)
        {
            SqlDataReader dr;
            SqlConnection connect;
            HD_NHAPXUAT obj = new HD_NHAPXUAT();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectHdThongTinCoBanXuatKhacBySHDNB", connect);
                    sqlCmd.Parameters.AddWithValue("@HDNX_SOHDNB", pMa);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj.HDNX_NGAYHD = DateTime.Parse(dr["HDNX_NGAYHD"].ToString());
                            obj.HDNX_SOHD = dr["HDNX_SOHD"].ToString();
                            obj.HDNX_SOHDNB = dr["HDNX_SOHDNB"].ToString();
                            obj.HDNX_NGAYLAP = DateTime.Parse(dr["HDNX_NGAYLAP"].ToString());
                        }
                    }
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return obj;
        }

        public static void themHoaDonXuatKhac(HD_NHAPXUAT pObj)
        {
            using (SqlConnection connect = ConnectDatabase())
            {
                connect.Open();
                SqlCommand sqlCmd = new SqlCommand("InsertHdXuatKhac", connect);
                sqlCmd.CommandTimeout = 1000;
                sqlCmd.Parameters.AddWithValue("@HDNX_LOAIHD", pObj.HDNX_LOAIHD);
                sqlCmd.Parameters.AddWithValue("@HDNX_SOHDNB", pObj.HDNX_SOHDNB);
                sqlCmd.Parameters.AddWithValue("@HDNX_NGAYLAP", pObj.HDNX_NGAYLAP);
                sqlCmd.Parameters.AddWithValue("@HH_MAHANG", pObj.HH_MAHANG);
                sqlCmd.Parameters.AddWithValue("@HDNX_SOLUONG", pObj.HDNX_SOLUONG);
                sqlCmd.Parameters.AddWithValue("@HDNX_GIABAN", pObj.HDNX_GIABAN);
                sqlCmd.Parameters.AddWithValue("@HDNX_TONGBAN", pObj.HDNX_TONGBAN);
                sqlCmd.Parameters.AddWithValue("@HDNX_THANHTIEN", pObj.HDNX_THANHTIEN);
                sqlCmd.Parameters.AddWithValue("@HDNX_CHIECKHAU", pObj.HDNX_CHIECKHAU);
                sqlCmd.Parameters.AddWithValue("@HDNX_TONGCHIECKHAU", pObj.HDNX_TONGCHIECKHAU);
                sqlCmd.Parameters.AddWithValue("@HDNX_GIAMKHAC", pObj.HDNX_GIAMKHAC);
                sqlCmd.Parameters.AddWithValue("@HDNX_KHACHDUA", pObj.HDNX_KHACHDUA);
                sqlCmd.Parameters.AddWithValue("@HDNX_THOILAI", pObj.HDNX_THOILAI);
                sqlCmd.Parameters.AddWithValue("@HDNX_TRAHANG", pObj.HDNX_TRAHANG);
                sqlCmd.Parameters.AddWithValue("@HDNX_STT", pObj.HDNX_STT);
                sqlCmd.Parameters.AddWithValue("@HDNX_SOHD", pObj.HDNX_SOHD);
                sqlCmd.Parameters.AddWithValue("@HDNX_NGAYHD", pObj.HDNX_NGAYHD);
                sqlCmd.Parameters.AddWithValue("@HDNX_SONGAYHD", pObj.HDNX_SONGAYHD);
                sqlCmd.Parameters.AddWithValue("@NPP_MANPP", pObj.NPP_MANPP);
                sqlCmd.Parameters.AddWithValue("@HDNX_GHICHU", pObj.HDNX_GHICHU);
                sqlCmd.Parameters.AddWithValue("@KH_MAKHO", pObj.KH_MAKHO);
                sqlCmd.Parameters.AddWithValue("@HDNX_TRANGTHAI", pObj.HDNX_TRANGTHAI);
                //
                sqlCmd.Parameters.AddWithValue("@HDNX_GIAMUA", pObj.HDNX_GIAMUA);
                sqlCmd.Parameters.AddWithValue("@HDNX_VAT", pObj.HDNX_VAT);
                sqlCmd.Parameters.AddWithValue("@HDNX_GIAVAT", pObj.HDNX_GIAVAT);
                sqlCmd.Parameters.AddWithValue("@HDNX_TONGVAT", pObj.HDNX_TONGVAT);
                sqlCmd.Parameters.AddWithValue("@HDNX_TONGMUA", pObj.HDNX_TONGMUA);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.ExecuteNonQuery();
            }
        }

        public static void capNhatHoaDonXuatKhac(HD_NHAPXUAT pObj)
        {
            using (SqlConnection connect = ConnectDatabase())
            {
                connect.Open();
                SqlCommand sqlCmd = new SqlCommand("InsertHdXuatKhac2", connect);
                sqlCmd.CommandTimeout = 1000;
                sqlCmd.Parameters.AddWithValue("@HDNX_LOAIHD", pObj.HDNX_LOAIHD);
                sqlCmd.Parameters.AddWithValue("@HDNX_SOHDNB", pObj.HDNX_SOHDNB);
                sqlCmd.Parameters.AddWithValue("@HDNX_NGAYLAP", pObj.HDNX_NGAYLAP);
                sqlCmd.Parameters.AddWithValue("@HDNX_NGAYCAPNHAT", pObj.HDNX_NGAYCAPNHAT);
                sqlCmd.Parameters.AddWithValue("@HH_MAHANG", pObj.HH_MAHANG);
                sqlCmd.Parameters.AddWithValue("@HDNX_SOLUONG", pObj.HDNX_SOLUONG);
                sqlCmd.Parameters.AddWithValue("@HDNX_GIABAN", pObj.HDNX_GIABAN);
                sqlCmd.Parameters.AddWithValue("@HDNX_TONGBAN", pObj.HDNX_TONGBAN);
                sqlCmd.Parameters.AddWithValue("@HDNX_THANHTIEN", pObj.HDNX_THANHTIEN);
                sqlCmd.Parameters.AddWithValue("@HDNX_CHIECKHAU", pObj.HDNX_CHIECKHAU);
                sqlCmd.Parameters.AddWithValue("@HDNX_TONGCHIECKHAU", pObj.HDNX_TONGCHIECKHAU);
                sqlCmd.Parameters.AddWithValue("@HDNX_GIAMKHAC", pObj.HDNX_GIAMKHAC);
                sqlCmd.Parameters.AddWithValue("@HDNX_KHACHDUA", pObj.HDNX_KHACHDUA);
                sqlCmd.Parameters.AddWithValue("@HDNX_THOILAI", pObj.HDNX_THOILAI);
                sqlCmd.Parameters.AddWithValue("@HDNX_TRAHANG", pObj.HDNX_TRAHANG);
                sqlCmd.Parameters.AddWithValue("@HDNX_STT", pObj.HDNX_STT);
                sqlCmd.Parameters.AddWithValue("@HDNX_SOHD", pObj.HDNX_SOHD);
                sqlCmd.Parameters.AddWithValue("@HDNX_NGAYHD", pObj.HDNX_NGAYHD);
                sqlCmd.Parameters.AddWithValue("@HDNX_SONGAYHD", pObj.HDNX_SONGAYHD);
                sqlCmd.Parameters.AddWithValue("@NPP_MANPP", pObj.NPP_MANPP);
                sqlCmd.Parameters.AddWithValue("@HDNX_GHICHU", pObj.HDNX_GHICHU);
                sqlCmd.Parameters.AddWithValue("@KH_MAKHO", pObj.KH_MAKHO);
                sqlCmd.Parameters.AddWithValue("@HDNX_TRANGTHAI", pObj.HDNX_TRANGTHAI);
                //
                sqlCmd.Parameters.AddWithValue("@HDNX_GIAMUA", pObj.HDNX_GIAMUA);
                sqlCmd.Parameters.AddWithValue("@HDNX_VAT", pObj.HDNX_VAT);
                sqlCmd.Parameters.AddWithValue("@HDNX_GIAVAT", pObj.HDNX_GIAVAT);
                sqlCmd.Parameters.AddWithValue("@HDNX_TONGVAT", pObj.HDNX_TONGVAT);
                sqlCmd.Parameters.AddWithValue("@HDNX_TONGMUA", pObj.HDNX_TONGMUA);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.ExecuteNonQuery();
            }
        }

        public static DataTable bangKeXuatKhac(string pMaKho, DateTime pTuNgay, DateTime pDenNgay, bool pCaNam)
        {
            DataTable dt = new DataTable();
            SqlConnection connect;
            List<HD_NHAPXUAT> objList = new List<HD_NHAPXUAT>();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectHdBangKeXuatKhac", connect);
                    sqlCmd.Parameters.AddWithValue("@CANAM", pCaNam ? 1 : 0);
                    sqlCmd.Parameters.AddWithValue("@MAKHO", pMaKho);
                    sqlCmd.Parameters.AddWithValue("@TUNGAY", pTuNgay.Year < 2000 ? DateTime.Now.AddYears(-1) : pTuNgay);
                    sqlCmd.Parameters.AddWithValue("@DENNGAY", pDenNgay.Year < 2000 ? DateTime.Now : pDenNgay);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlCmd;
                    da.Fill(dt);
                    /*
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            HD_NHAPXUAT obj = new HD_NHAPXUAT();
                            obj.HDNX_CHIECKHAU = dr["HDNX_CHIECKHAU"].ToString() != "" ? double.Parse(dr["HDNX_CHIECKHAU"].ToString()) : 0;
                            obj.HDNX_DAIN = dr["HDNX_DAIN"].ToString() != "" ? Int32.Parse(dr["HDNX_DAIN"].ToString()) : 0;
                            obj.HDNX_GHICHU = dr["HDNX_GHICHU"].ToString();
                            obj.HDNX_GIABAN = dr["HDNX_GIABAN"].ToString() != "" ? Decimal.Parse(dr["HDNX_GIABAN"].ToString()) : 0;
                            obj.HDNX_GIAMKHAC = dr["HDNX_GIAMKHAC"].ToString() != "" ? Decimal.Parse(dr["HDNX_GIAMKHAC"].ToString()) : 0;
                            obj.HDNX_GIAMUA = dr["HDNX_GIAMUA"].ToString() != "" ? Decimal.Parse(dr["HDNX_GIAMUA"].ToString()) : 0;
                            obj.HDNX_GIAVAT = dr["HDNX_GIAVAT"].ToString() != "" ? Decimal.Parse(dr["HDNX_GIAVAT"].ToString()) : 0;
                            obj.HDNX_KHACHDUA = dr["HDNX_KHACHDUA"].ToString() != "" ? Decimal.Parse(dr["HDNX_KHACHDUA"].ToString()): 0;
                            obj.HDNX_LOAIHD = dr["HDNX_LOAIHD"].ToString();
                            obj.HDNX_NGAYCAPNHAT = dr["HDNX_NGAYCAPNHAT"].ToString() != "" ? DateTime.Parse(dr["HDNX_NGAYCAPNHAT"].ToString()) : new DateTime(1990, 01, 01);
                            obj.HDNX_NGAYHD = dr["HDNX_NGAYHD"].ToString() != "" ? DateTime.Parse(dr["HDNX_NGAYHD"].ToString()) : new DateTime(1990, 01, 01);
                            obj.HDNX_NGAYIN = dr["HDNX_NGAYIN"].ToString() != "" ? DateTime.Parse(dr["HDNX_NGAYIN"].ToString()) : new DateTime(1990, 01, 01);
                            obj.HDNX_NGAYLAP = dr["HDNX_NGAYLAP"].ToString() != "" ? DateTime.Parse(dr["HDNX_NGAYLAP"].ToString()) : new DateTime(1990, 01, 01);
                            obj.HDNX_NGAYTT = dr["HDNX_NGAYTT"].ToString() != "" ? DateTime.Parse(dr["HDNX_NGAYTT"].ToString()) : new DateTime(1990, 01, 01);
                            obj.HDNX_QUIDOI = dr["HDNX_QUIDOI"].ToString() != "" ? Int32.Parse(dr["HDNX_QUIDOI"].ToString()) : 0;
                            obj.HDNX_SOHD = dr["HDNX_SOHD"].ToString();
                            obj.HDNX_SOHDNB = dr["HDNX_SOHDNB"].ToString();
                            obj.HDNX_SOLUONG = dr["HDNX_SOLUONG"].ToString() != "" ? Double.Parse(dr["HDNX_SOLUONG"].ToString()) : 0;
                            obj.HDNX_SONGAYHD = dr["HDNX_SONGAYHD"].ToString() != "" ? Int32.Parse(dr["HDNX_SONGAYHD"].ToString()): 0;
                            obj.HDNX_STT = dr["HDNX_STT"].ToString() != "" ? Int32.Parse(dr["HDNX_STT"].ToString()) : 0;
                            obj.HDNX_TONGBAN = dr["HDNX_TONGBAN"].ToString() != "" ? Decimal.Parse(dr["HDNX_TONGBAN"].ToString()) : 0;
                            obj.HDNX_TONGCHIECKHAU = dr["HDNX_TONGCHIECKHAU"].ToString() != "" ? Decimal.Parse(dr["HDNX_TONGCHIECKHAU"].ToString()) : 0;
                            obj.HDNX_TONGMUA = dr["HDNX_TONGMUA"].ToString() != "" ? Decimal.Parse(dr["HDNX_TONGMUA"].ToString()) : 0;
                            obj.HDNX_TONGVAT = dr["HDNX_TONGVAT"].ToString() != "" ? Decimal.Parse(dr["HDNX_TONGVAT"].ToString()) : 0;
                            obj.HDNX_THANHTIEN = dr["HDNX_THANHTIEN"].ToString() != "" ? Decimal.Parse(dr["HDNX_THANHTIEN"].ToString()) : 0;
                            obj.HDNX_TRAHANG = dr["HDNX_TRAHANG"].ToString() != "" ?Int32.Parse(dr["HDNX_TRAHANG"].ToString()) : 0;
                            obj.HDNX_TRANGTHAI = dr["HDNX_TRANGTHAI"].ToString() != "" ? Int32.Parse(dr["HDNX_TRANGTHAI"].ToString()) : 0;
                            obj.HDNX_VAT = dr["HDNX_VAT"].ToString() != "" ? Double.Parse(dr["HDNX_VAT"].ToString()) : 0;
                            obj.HDTT_MATT = dr["HDTT_MATT"].ToString();
                            obj.HH_MAHANG = dr["HH_MAHANG"].ToString();
                            obj.KH_MAKHO = dr["KH_MAKHO"].ToString();
                            obj.NPP_MANPP = dr["NPP_MANPP"].ToString();
                            obj.NV_MANV = dr["NV_MANV"].ToString();
                            obj.NV_TAIKHOAN = dr["NV_TAIKHOAN"].ToString();
                            objList.Add(obj);
                        }
                    }
                     */
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return dt;
        }
        #endregion

        #region TRẢ HÀNG
        public static List<HD_NHAPXUAT> layDSHoaDonTraHangTheoSHDNB(string pSHDNB)
        {
            SqlDataReader dr;
            SqlConnection connect;
            List<HD_NHAPXUAT> objList = new List<HD_NHAPXUAT>();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectHdTraHangBySHDNB", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.Parameters.AddWithValue("@HDNX_SOHDNB", pSHDNB);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            HD_NHAPXUAT obj = new HD_NHAPXUAT();
                            obj.HDNX_LOAIHD = dr["HDNX_LOAIHD"].ToString();
                            obj.HDNX_SOHDNB = dr["HDNX_SOHDNB"].ToString();
                            obj.HDNX_NGAYLAP = DateTime.Parse(dr["HDNX_NGAYLAP"].ToString());
                            obj.HH_MAHANG = dr["HH_MAHANG"].ToString();
                            obj.HDNX_SOLUONG = Double.Parse(dr["HDNX_SOLUONG"].ToString());
                            obj.HDNX_VAT = Double.Parse(dr["HDNX_VAT"].ToString());
                            obj.HDNX_GIAVAT = Decimal.Parse(dr["HDNX_GIAVAT"].ToString());
                            obj.HDNX_TONGVAT = Decimal.Parse(dr["HDNX_TONGVAT"].ToString());
                            obj.HDNX_GIAMUA = Decimal.Parse(dr["HDNX_GIAMUA"].ToString());
                            obj.HDNX_TONGMUA = Decimal.Parse(dr["HDNX_TONGMUA"].ToString());
                            obj.HDNX_GIABAN = Decimal.Parse(dr["HDNX_GIABAN"].ToString());
                            obj.HDNX_TONGBAN = Decimal.Parse(dr["HDNX_TONGBAN"].ToString());
                            obj.HDNX_THANHTIEN = Decimal.Parse(dr["HDNX_THANHTIEN"].ToString());
                            obj.HDNX_CHIECKHAU = double.Parse(dr["HDNX_CHIECKHAU"].ToString());
                            obj.HDNX_TONGCHIECKHAU = Decimal.Parse(dr["HDNX_TONGCHIECKHAU"].ToString());
                            obj.HDNX_GIAMKHAC = Decimal.Parse(dr["HDNX_GIAMKHAC"].ToString());
                            obj.HDNX_KHACHDUA = Decimal.Parse(dr["HDNX_KHACHDUA"].ToString());
                            obj.HDNX_THOILAI = dr["HDNX_THOILAI"].ToString() != "" ? Decimal.Parse(dr["HDNX_THOILAI"].ToString()) : 0;
                            obj.HDNX_TRAHANG = dr["HDNX_TRAHANG"].ToString() != "" ? Int32.Parse(dr["HDNX_TRAHANG"].ToString()) : 0;
                            obj.HDNX_STT = Int32.Parse(dr["HDNX_STT"].ToString());
                            obj.HDNX_SOHD = dr["HDNX_SOHD"].ToString();
                            obj.HDNX_NGAYHD = DateTime.Parse(dr["HDNX_NGAYHD"].ToString());
                            obj.NPP_MANPP = dr["NPP_MANPP"].ToString();
                            obj.HDNX_GHICHU = dr["HDNX_GHICHU"].ToString();
                            obj.KH_MAKHO = dr["KH_MAKHO"].ToString();
                            obj.HDNX_TRANGTHAI = Int32.Parse(dr["HDNX_TRANGTHAI"].ToString());
                            objList.Add(obj);
                        }
                    }
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return objList;
        }

        public static List<HD_NHAPXUAT> layDSHoaDonTraHangDSLeft()
        {
            SqlDataReader dr;
            SqlConnection connect;
            List<HD_NHAPXUAT> objList = new List<HD_NHAPXUAT>();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectHdTraHangDSLeft", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            HD_NHAPXUAT obj = new HD_NHAPXUAT();
                            obj.HDNX_NGAYHD = DateTime.Parse(dr["HDNX_NGAYHD"].ToString());
                            obj.HDNX_SOHD = dr["HDNX_SOHD"].ToString();
                            obj.HDNX_SOHDNB = dr["HDNX_SOHDNB"].ToString();
                            objList.Add(obj);
                        }
                    }
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return objList;
        }

        public static HD_NHAPXUAT layThongTinHoaDonTraHang(string pMa)
        {
            SqlDataReader dr;
            SqlConnection connect;
            HD_NHAPXUAT obj = new HD_NHAPXUAT();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectHdThongTinCoBanTraHangBySHDNB", connect);
                    sqlCmd.Parameters.AddWithValue("@HDNX_SOHDNB", pMa);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj.HDNX_NGAYHD = DateTime.Parse(dr["HDNX_NGAYHD"].ToString());
                            obj.HDNX_SOHD = dr["HDNX_SOHD"].ToString();
                            obj.HDNX_SOHDNB = dr["HDNX_SOHDNB"].ToString();
                            obj.HDNX_NGAYLAP = DateTime.Parse(dr["HDNX_NGAYLAP"].ToString());
                        }
                    }
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return obj;
        }

        public static void themHoaDonTraHang(HD_NHAPXUAT pObj)
        {
            using (SqlConnection connect = ConnectDatabase())
            {
                connect.Open();
                SqlCommand sqlCmd = new SqlCommand("InsertHdTraHang", connect);
                sqlCmd.CommandTimeout = 1000;
                sqlCmd.Parameters.AddWithValue("@HDNX_LOAIHD", pObj.HDNX_LOAIHD);
                sqlCmd.Parameters.AddWithValue("@HDNX_SOHDNB", pObj.HDNX_SOHDNB);
                sqlCmd.Parameters.AddWithValue("@HDNX_NGAYLAP", pObj.HDNX_NGAYLAP);
                sqlCmd.Parameters.AddWithValue("@HH_MAHANG", pObj.HH_MAHANG);
                sqlCmd.Parameters.AddWithValue("@HDNX_SOLUONG", pObj.HDNX_SOLUONG);
                sqlCmd.Parameters.AddWithValue("@HDNX_GIABAN", pObj.HDNX_GIABAN);
                sqlCmd.Parameters.AddWithValue("@HDNX_TONGBAN", pObj.HDNX_TONGBAN);
                sqlCmd.Parameters.AddWithValue("@HDNX_THANHTIEN", pObj.HDNX_THANHTIEN);
                sqlCmd.Parameters.AddWithValue("@HDNX_CHIECKHAU", pObj.HDNX_CHIECKHAU);
                sqlCmd.Parameters.AddWithValue("@HDNX_TONGCHIECKHAU", pObj.HDNX_TONGCHIECKHAU);
                sqlCmd.Parameters.AddWithValue("@HDNX_GIAMKHAC", pObj.HDNX_GIAMKHAC);
                sqlCmd.Parameters.AddWithValue("@HDNX_KHACHDUA", pObj.HDNX_KHACHDUA);
                sqlCmd.Parameters.AddWithValue("@HDNX_THOILAI", pObj.HDNX_THOILAI);
                sqlCmd.Parameters.AddWithValue("@HDNX_TRAHANG", pObj.HDNX_TRAHANG);
                sqlCmd.Parameters.AddWithValue("@HDNX_STT", pObj.HDNX_STT);
                sqlCmd.Parameters.AddWithValue("@HDNX_SOHD", pObj.HDNX_SOHD);
                sqlCmd.Parameters.AddWithValue("@HDNX_NGAYHD", pObj.HDNX_NGAYHD);
                sqlCmd.Parameters.AddWithValue("@HDNX_SONGAYHD", pObj.HDNX_SONGAYHD);
                sqlCmd.Parameters.AddWithValue("@NPP_MANPP", pObj.NPP_MANPP);
                sqlCmd.Parameters.AddWithValue("@HDNX_GHICHU", pObj.HDNX_GHICHU);
                sqlCmd.Parameters.AddWithValue("@KH_MAKHO", pObj.KH_MAKHO);
                sqlCmd.Parameters.AddWithValue("@HDNX_TRANGTHAI", pObj.HDNX_TRANGTHAI);
                //
                sqlCmd.Parameters.AddWithValue("@HDNX_GIAMUA", pObj.HDNX_GIAMUA);
                sqlCmd.Parameters.AddWithValue("@HDNX_VAT", pObj.HDNX_VAT);
                sqlCmd.Parameters.AddWithValue("@HDNX_GIAVAT", pObj.HDNX_GIAVAT);
                sqlCmd.Parameters.AddWithValue("@HDNX_TONGVAT", pObj.HDNX_TONGVAT);
                sqlCmd.Parameters.AddWithValue("@HDNX_TONGMUA", pObj.HDNX_TONGMUA);
                sqlCmd.Parameters.AddWithValue("@HDNX_GHINO", pObj.HDNX_GHINO);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.ExecuteNonQuery();
            }
        }

        public static void capNhatHoaDonTraHang(HD_NHAPXUAT pObj)
        {
            using (SqlConnection connect = ConnectDatabase())
            {
                connect.Open();
                SqlCommand sqlCmd = new SqlCommand("InsertHdTraHang2", connect);
                sqlCmd.CommandTimeout = 1000;
                sqlCmd.Parameters.AddWithValue("@HDNX_LOAIHD", pObj.HDNX_LOAIHD);
                sqlCmd.Parameters.AddWithValue("@HDNX_SOHDNB", pObj.HDNX_SOHDNB);
                sqlCmd.Parameters.AddWithValue("@HDNX_NGAYLAP", pObj.HDNX_NGAYLAP);
                sqlCmd.Parameters.AddWithValue("@HDNX_NGAYCAPNHAT", pObj.HDNX_NGAYCAPNHAT);
                sqlCmd.Parameters.AddWithValue("@HH_MAHANG", pObj.HH_MAHANG);
                sqlCmd.Parameters.AddWithValue("@HDNX_SOLUONG", pObj.HDNX_SOLUONG);
                sqlCmd.Parameters.AddWithValue("@HDNX_GIABAN", pObj.HDNX_GIABAN);
                sqlCmd.Parameters.AddWithValue("@HDNX_TONGBAN", pObj.HDNX_TONGBAN);
                sqlCmd.Parameters.AddWithValue("@HDNX_THANHTIEN", pObj.HDNX_THANHTIEN);
                sqlCmd.Parameters.AddWithValue("@HDNX_CHIECKHAU", pObj.HDNX_CHIECKHAU);
                sqlCmd.Parameters.AddWithValue("@HDNX_TONGCHIECKHAU", pObj.HDNX_TONGCHIECKHAU);
                sqlCmd.Parameters.AddWithValue("@HDNX_GIAMKHAC", pObj.HDNX_GIAMKHAC);
                sqlCmd.Parameters.AddWithValue("@HDNX_KHACHDUA", pObj.HDNX_KHACHDUA);
                sqlCmd.Parameters.AddWithValue("@HDNX_THOILAI", pObj.HDNX_THOILAI);
                sqlCmd.Parameters.AddWithValue("@HDNX_TRAHANG", pObj.HDNX_TRAHANG);
                sqlCmd.Parameters.AddWithValue("@HDNX_STT", pObj.HDNX_STT);
                sqlCmd.Parameters.AddWithValue("@HDNX_SOHD", pObj.HDNX_SOHD);
                sqlCmd.Parameters.AddWithValue("@HDNX_NGAYHD", pObj.HDNX_NGAYHD);
                sqlCmd.Parameters.AddWithValue("@HDNX_SONGAYHD", pObj.HDNX_SONGAYHD);
                sqlCmd.Parameters.AddWithValue("@NPP_MANPP", pObj.NPP_MANPP);
                sqlCmd.Parameters.AddWithValue("@HDNX_GHICHU", pObj.HDNX_GHICHU);
                sqlCmd.Parameters.AddWithValue("@KH_MAKHO", pObj.KH_MAKHO);
                sqlCmd.Parameters.AddWithValue("@HDNX_TRANGTHAI", pObj.HDNX_TRANGTHAI);
                //
                sqlCmd.Parameters.AddWithValue("@HDNX_GIAMUA", pObj.HDNX_GIAMUA);
                sqlCmd.Parameters.AddWithValue("@HDNX_VAT", pObj.HDNX_VAT);
                sqlCmd.Parameters.AddWithValue("@HDNX_GIAVAT", pObj.HDNX_GIAVAT);
                sqlCmd.Parameters.AddWithValue("@HDNX_TONGVAT", pObj.HDNX_TONGVAT);
                sqlCmd.Parameters.AddWithValue("@HDNX_TONGMUA", pObj.HDNX_TONGMUA);
                sqlCmd.Parameters.AddWithValue("@HDNX_GHINO", pObj.HDNX_GHINO);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.ExecuteNonQuery();
            }
        }

        public static DataTable bangKeTraHang(string pMaKho, DateTime pTuNgay, DateTime pDenNgay, bool pCaNam)
        {
            DataTable dt = new DataTable();
            SqlConnection connect;
            List<HD_NHAPXUAT> objList = new List<HD_NHAPXUAT>();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectHdBangKeTraHang", connect);
                    sqlCmd.Parameters.AddWithValue("@CANAM", pCaNam ? 1 : 0);
                    sqlCmd.Parameters.AddWithValue("@MAKHO", pMaKho);
                    sqlCmd.Parameters.AddWithValue("@TUNGAY", pTuNgay.Year < 2000 ? DateTime.Now.AddYears(-1) : pTuNgay);
                    sqlCmd.Parameters.AddWithValue("@DENNGAY", pDenNgay.Year < 2000 ? DateTime.Now : pDenNgay);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlCmd;
                    da.Fill(dt);
                    /*
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            HD_NHAPXUAT obj = new HD_NHAPXUAT();
                            obj.HDNX_CHIECKHAU = dr["HDNX_CHIECKHAU"].ToString() != "" ? double.Parse(dr["HDNX_CHIECKHAU"].ToString()) : 0;
                            obj.HDNX_DAIN = dr["HDNX_DAIN"].ToString() != "" ? Int32.Parse(dr["HDNX_DAIN"].ToString()) : 0;
                            obj.HDNX_GHICHU = dr["HDNX_GHICHU"].ToString();
                            obj.HDNX_GIABAN = dr["HDNX_GIABAN"].ToString() != "" ? Decimal.Parse(dr["HDNX_GIABAN"].ToString()) : 0;
                            obj.HDNX_GIAMKHAC = dr["HDNX_GIAMKHAC"].ToString() != "" ? Decimal.Parse(dr["HDNX_GIAMKHAC"].ToString()) : 0;
                            obj.HDNX_GIAMUA = dr["HDNX_GIAMUA"].ToString() != "" ? Decimal.Parse(dr["HDNX_GIAMUA"].ToString()) : 0;
                            obj.HDNX_GIAVAT = dr["HDNX_GIAVAT"].ToString() != "" ? Decimal.Parse(dr["HDNX_GIAVAT"].ToString()) : 0;
                            obj.HDNX_KHACHDUA = dr["HDNX_KHACHDUA"].ToString() != "" ? Decimal.Parse(dr["HDNX_KHACHDUA"].ToString()): 0;
                            obj.HDNX_LOAIHD = dr["HDNX_LOAIHD"].ToString();
                            obj.HDNX_NGAYCAPNHAT = dr["HDNX_NGAYCAPNHAT"].ToString() != "" ? DateTime.Parse(dr["HDNX_NGAYCAPNHAT"].ToString()) : new DateTime(1990, 01, 01);
                            obj.HDNX_NGAYHD = dr["HDNX_NGAYHD"].ToString() != "" ? DateTime.Parse(dr["HDNX_NGAYHD"].ToString()) : new DateTime(1990, 01, 01);
                            obj.HDNX_NGAYIN = dr["HDNX_NGAYIN"].ToString() != "" ? DateTime.Parse(dr["HDNX_NGAYIN"].ToString()) : new DateTime(1990, 01, 01);
                            obj.HDNX_NGAYLAP = dr["HDNX_NGAYLAP"].ToString() != "" ? DateTime.Parse(dr["HDNX_NGAYLAP"].ToString()) : new DateTime(1990, 01, 01);
                            obj.HDNX_NGAYTT = dr["HDNX_NGAYTT"].ToString() != "" ? DateTime.Parse(dr["HDNX_NGAYTT"].ToString()) : new DateTime(1990, 01, 01);
                            obj.HDNX_QUIDOI = dr["HDNX_QUIDOI"].ToString() != "" ? Int32.Parse(dr["HDNX_QUIDOI"].ToString()) : 0;
                            obj.HDNX_SOHD = dr["HDNX_SOHD"].ToString();
                            obj.HDNX_SOHDNB = dr["HDNX_SOHDNB"].ToString();
                            obj.HDNX_SOLUONG = dr["HDNX_SOLUONG"].ToString() != "" ? Double.Parse(dr["HDNX_SOLUONG"].ToString()) : 0;
                            obj.HDNX_SONGAYHD = dr["HDNX_SONGAYHD"].ToString() != "" ? Int32.Parse(dr["HDNX_SONGAYHD"].ToString()): 0;
                            obj.HDNX_STT = dr["HDNX_STT"].ToString() != "" ? Int32.Parse(dr["HDNX_STT"].ToString()) : 0;
                            obj.HDNX_TONGBAN = dr["HDNX_TONGBAN"].ToString() != "" ? Decimal.Parse(dr["HDNX_TONGBAN"].ToString()) : 0;
                            obj.HDNX_TONGCHIECKHAU = dr["HDNX_TONGCHIECKHAU"].ToString() != "" ? Decimal.Parse(dr["HDNX_TONGCHIECKHAU"].ToString()) : 0;
                            obj.HDNX_TONGMUA = dr["HDNX_TONGMUA"].ToString() != "" ? Decimal.Parse(dr["HDNX_TONGMUA"].ToString()) : 0;
                            obj.HDNX_TONGVAT = dr["HDNX_TONGVAT"].ToString() != "" ? Decimal.Parse(dr["HDNX_TONGVAT"].ToString()) : 0;
                            obj.HDNX_THANHTIEN = dr["HDNX_THANHTIEN"].ToString() != "" ? Decimal.Parse(dr["HDNX_THANHTIEN"].ToString()) : 0;
                            obj.HDNX_TRAHANG = dr["HDNX_TRAHANG"].ToString() != "" ?Int32.Parse(dr["HDNX_TRAHANG"].ToString()) : 0;
                            obj.HDNX_TRANGTHAI = dr["HDNX_TRANGTHAI"].ToString() != "" ? Int32.Parse(dr["HDNX_TRANGTHAI"].ToString()) : 0;
                            obj.HDNX_VAT = dr["HDNX_VAT"].ToString() != "" ? Double.Parse(dr["HDNX_VAT"].ToString()) : 0;
                            obj.HDTT_MATT = dr["HDTT_MATT"].ToString();
                            obj.HH_MAHANG = dr["HH_MAHANG"].ToString();
                            obj.KH_MAKHO = dr["KH_MAKHO"].ToString();
                            obj.NPP_MANPP = dr["NPP_MANPP"].ToString();
                            obj.NV_MANV = dr["NV_MANV"].ToString();
                            obj.NV_TAIKHOAN = dr["NV_TAIKHOAN"].ToString();
                            objList.Add(obj);
                        }
                    }
                     */
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return dt;
        }

        #endregion 

        #endregion

        #region Báo cáo
        public static List<BAOCAO_TONKHO> baoCaoTonKho(string pMaKho, DateTime pTuNgay, DateTime pDenNgay, bool pTatCa)
        {
            SqlDataReader dr;
            SqlConnection connect;
            List<BAOCAO_TONKHO> objList = new List<BAOCAO_TONKHO>();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectHdTonKhoHangHoa", connect);
                    sqlCmd.Parameters.AddWithValue("@TATCA", pTatCa ? 1 : 0);
                    sqlCmd.Parameters.AddWithValue("@MAKHO", pMaKho);
                    sqlCmd.Parameters.AddWithValue("@TUNGAY", pTuNgay.Year < 2000 ? DateTime.Now.AddYears(-1) : pTuNgay);
                    sqlCmd.Parameters.AddWithValue("@DENNGAY", pDenNgay.Year < 2000 ? DateTime.Now : pDenNgay);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            BAOCAO_TONKHO obj = new BAOCAO_TONKHO();
                            obj.HH_MAHANG = dr["HH_MAHANG"].ToString();
                            obj.HH_TENHANG = dr["HH_TENHANG"].ToString();
                            obj.HH_HANSUDUNG = dr["HH_HANSUDUNG"].ToString() != "" ? DateTime.Parse(dr["HH_HANSUDUNG"].ToString()) : new DateTime(1900, 1, 1);
                            obj.HH_GIAMUA = dr["HH_GIAMUA"].ToString() != "" ? Decimal.Parse(dr["HH_GIAMUA"].ToString()) : 0;
                            obj.HH_GIABANSI = dr["HH_GIABANSI"].ToString() != "" ? Decimal.Parse(dr["HH_GIABANSI"].ToString()) : 0;
                            obj.HH_GIABANLE = dr["HH_GIABANLE"].ToString() != "" ? Decimal.Parse(dr["HH_GIABANLE"].ToString()) : 0;
                            obj.HH_KICHHOAT = dr["HH_KICHHOAT"].ToString() != "" ? Int32.Parse(dr["HH_KICHHOAT"].ToString()) : 0;
                            obj.DVT_TENDONVI = dr["DVT_TENDONVI"].ToString();
                            //obj.BC_TIENTON = dr["BC_TIENTON"].ToString() != "" ? Decimal.Parse(dr["BC_TIENTON"].ToString()) : 0;
                            //obj.BC_TONKHO = dr["BC_TONKHO"].ToString() != "" ? Double.Parse(dr["BC_TONKHO"].ToString()) : 0;
                            obj.BC_TONGNHAPKHAC = dr["BC_TONGNHAPKHAC"].ToString() != "" ? Double.Parse(dr["BC_TONGNHAPKHAC"].ToString()) : 0;
                            obj.BC_TONGNHAPKHO = dr["BC_TONGNHAPKHO"].ToString() != "" ? Double.Parse(dr["BC_TONGNHAPKHO"].ToString()) : 0;
                            //obj.BC_TONGTHANHTOAN = dr["BC_TONGTHANHTOAN"].ToString() != "" ? Decimal.Parse(dr["BC_TONGTHANHTOAN"].ToString()) : 0;
                            obj.BC_TONGXUATKHAC = dr["BC_TONGXUATKHAC"].ToString() != "" ? Double.Parse(dr["BC_TONGXUATKHAC"].ToString()) : 0;
                            obj.BC_TONGXUATLE = dr["BC_TONGXUATLE"].ToString() != "" ? Double.Parse(dr["BC_TONGXUATLE"].ToString()) : 0;
                            obj.BC_TONGXUATSI = dr["BC_TONGXUATSI"].ToString() != "" ? Double.Parse(dr["BC_TONGXUATSI"].ToString()) : 0;
                            obj.BC_TRAHANG = dr["BC_TRAHANG"].ToString() != "" ? Double.Parse(dr["BC_TRAHANG"].ToString()) : 0;
                            
                            objList.Add(obj);
                        }
                    }
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return objList;
        }

        public static List<BAOCAO_HANDUNG> baoCaoHanDung(string pMaKho)
        {
            SqlDataReader dr;
            SqlConnection connect;
            List<BAOCAO_HANDUNG> objList = new List<BAOCAO_HANDUNG>();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectBaoCaoHanDung", connect);
                    sqlCmd.Parameters.AddWithValue("@KH_MAKHO", pMaKho);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            BAOCAO_HANDUNG obj = new BAOCAO_HANDUNG();
                            obj.HDNX_SOHD = dr["HDNX_SOHD"].ToString();
                            obj.HDNX_NGAYHD = dr["HDNX_NGAYHD"].ToString() != "" ? DateTime.Parse(dr["HDNX_NGAYHD"].ToString()) : new DateTime(1900, 1, 1);
                            obj.HH_MAHANG = dr["HH_MAHANG"].ToString();
                            obj.HH_TENHANG = dr["HH_TENHANG"].ToString();
                            obj.HDNX_HANSUDUNG = dr["HDNX_HANSUDUNG"].ToString() != "" ? DateTime.Parse(dr["HDNX_HANSUDUNG"].ToString()) : new DateTime(1900, 1, 1);
                            obj.HH_GIAMUA = dr["HH_GIAMUA"].ToString() != "" ? Decimal.Parse(dr["HH_GIAMUA"].ToString()) : 0;
                            obj.HH_GIABANSI = dr["HH_GIABANSI"].ToString() != "" ? Decimal.Parse(dr["HH_GIABANSI"].ToString()) : 0;
                            obj.HH_GIABANLE = dr["HH_GIABANLE"].ToString() != "" ? Decimal.Parse(dr["HH_GIABANLE"].ToString()) : 0;
                            obj.HH_KICHHOAT = dr["HH_KICHHOAT"].ToString() != "" ? Int32.Parse(dr["HH_KICHHOAT"].ToString()) : 0;
                            obj.DVT_TENDONVI = dr["DVT_TENDONVI"].ToString();
                            objList.Add(obj);
                        }
                    }
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return objList;
        }

        public static List<BAOCAO_LAILO> BaoCaoLaiLo(DateTime pTuNgay, DateTime pDenNgay, bool pCaNam)
        {
            SqlDataReader dr;
            SqlConnection connect;
            List<BAOCAO_LAILO> objList = new List<BAOCAO_LAILO>();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectBaoCaoLaiLo", connect);
                    sqlCmd.Parameters.AddWithValue("@TUNGAY", pTuNgay);
                    sqlCmd.Parameters.AddWithValue("@DENNGAY", pDenNgay);
                    sqlCmd.Parameters.AddWithValue("@TATCA", pCaNam ? 1 : 0);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            BAOCAO_LAILO obj = new BAOCAO_LAILO();
                            obj.HDNX_SOHD = dr["HDNX_SOHD"].ToString();
                            obj.HDNX_SOHDNB = dr["HDNX_SOHDNB"].ToString();
                            obj.HDNX_NGAYHD = dr["HDNX_NGAYHD"].ToString() != "" ? DateTime.Parse(dr["HDNX_NGAYHD"].ToString()) : new DateTime(1900, 1, 1);

                            obj.NPP_MANPP = dr["NPP_MANPP"].ToString();
                            obj.NPP_TENNPP = dr["NPP_TENNPP"].ToString();

                            obj.HH_MAHANG = dr["HH_MAHANG"].ToString();
                            obj.HH_TENHANG = dr["HH_TENHANG"].ToString();
                            obj.DVT_TENDONVI = dr["DVT_TENDONVI"].ToString();

                            obj.HDNX_SOLUONG = dr["HDNX_SOLUONG"].ToString() != "" ? double.Parse(dr["HDNX_SOLUONG"].ToString()) : 0;
                            obj.HDNX_TONGMUA = dr["HDNX_TONGMUA"].ToString() != "" ? Decimal.Parse(dr["HDNX_TONGMUA"].ToString()) : 0;
                            obj.HDNX_TONGVAT = dr["HDNX_TONGVAT"].ToString() != "" ? Decimal.Parse(dr["HDNX_TONGVAT"].ToString()) : 0;

                            obj.HDNX_TONGBAN = dr["HDNX_TONGBAN"].ToString() != "" ? Decimal.Parse(dr["HDNX_TONGBAN"].ToString()) : 0;
                            obj.HDNX_TONGCHIECKHAU = dr["HDNX_TONGCHIECKHAU"].ToString() != "" ? Decimal.Parse(dr["HDNX_TONGCHIECKHAU"].ToString()) : 0;
                            obj.HDNX_THANHTIEN = dr["HDNX_THANHTIEN"].ToString() != "" ? Decimal.Parse(dr["HDNX_THANHTIEN"].ToString()) : 0;

                            obj.HDNX_TRAHANG = dr["HDNX_TRAHANG"].ToString() != "" ? int.Parse(dr["HDNX_TRAHANG"].ToString()) : 0;

                            objList.Add(obj);
                        }
                    }
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return objList;
        }

        public static DataTable baoCaoKhachHang(string pMaKho, DateTime pTuNgay, DateTime pDenNgay, bool pCaNam)
        {
            DataTable dt = new DataTable();
            SqlConnection connect;
            List<HD_NHAPXUAT> objList = new List<HD_NHAPXUAT>();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectHdBaoCaoKhachHang", connect);
                    sqlCmd.Parameters.AddWithValue("@CANAM", pCaNam ? 1 : 0);
                    sqlCmd.Parameters.AddWithValue("@MAKHO", pMaKho);
                    sqlCmd.Parameters.AddWithValue("@TUNGAY", pTuNgay.Year < 2000 ? DateTime.Now.AddYears(-1) : pTuNgay);
                    sqlCmd.Parameters.AddWithValue("@DENNGAY", pDenNgay.Year < 2000 ? DateTime.Now : pDenNgay);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlCmd;
                    da.Fill(dt);
                    /*
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            HD_NHAPXUAT obj = new HD_NHAPXUAT();
                            obj.HDNX_CHIECKHAU = dr["HDNX_CHIECKHAU"].ToString() != "" ? double.Parse(dr["HDNX_CHIECKHAU"].ToString()) : 0;
                            obj.HDNX_DAIN = dr["HDNX_DAIN"].ToString() != "" ? Int32.Parse(dr["HDNX_DAIN"].ToString()) : 0;
                            obj.HDNX_GHICHU = dr["HDNX_GHICHU"].ToString();
                            obj.HDNX_GIABAN = dr["HDNX_GIABAN"].ToString() != "" ? Decimal.Parse(dr["HDNX_GIABAN"].ToString()) : 0;
                            obj.HDNX_GIAMKHAC = dr["HDNX_GIAMKHAC"].ToString() != "" ? Decimal.Parse(dr["HDNX_GIAMKHAC"].ToString()) : 0;
                            obj.HDNX_GIAMUA = dr["HDNX_GIAMUA"].ToString() != "" ? Decimal.Parse(dr["HDNX_GIAMUA"].ToString()) : 0;
                            obj.HDNX_GIAVAT = dr["HDNX_GIAVAT"].ToString() != "" ? Decimal.Parse(dr["HDNX_GIAVAT"].ToString()) : 0;
                            obj.HDNX_KHACHDUA = dr["HDNX_KHACHDUA"].ToString() != "" ? Decimal.Parse(dr["HDNX_KHACHDUA"].ToString()): 0;
                            obj.HDNX_LOAIHD = dr["HDNX_LOAIHD"].ToString();
                            obj.HDNX_NGAYCAPNHAT = dr["HDNX_NGAYCAPNHAT"].ToString() != "" ? DateTime.Parse(dr["HDNX_NGAYCAPNHAT"].ToString()) : new DateTime(1990, 01, 01);
                            obj.HDNX_NGAYHD = dr["HDNX_NGAYHD"].ToString() != "" ? DateTime.Parse(dr["HDNX_NGAYHD"].ToString()) : new DateTime(1990, 01, 01);
                            obj.HDNX_NGAYIN = dr["HDNX_NGAYIN"].ToString() != "" ? DateTime.Parse(dr["HDNX_NGAYIN"].ToString()) : new DateTime(1990, 01, 01);
                            obj.HDNX_NGAYLAP = dr["HDNX_NGAYLAP"].ToString() != "" ? DateTime.Parse(dr["HDNX_NGAYLAP"].ToString()) : new DateTime(1990, 01, 01);
                            obj.HDNX_NGAYTT = dr["HDNX_NGAYTT"].ToString() != "" ? DateTime.Parse(dr["HDNX_NGAYTT"].ToString()) : new DateTime(1990, 01, 01);
                            obj.HDNX_QUIDOI = dr["HDNX_QUIDOI"].ToString() != "" ? Int32.Parse(dr["HDNX_QUIDOI"].ToString()) : 0;
                            obj.HDNX_SOHD = dr["HDNX_SOHD"].ToString();
                            obj.HDNX_SOHDNB = dr["HDNX_SOHDNB"].ToString();
                            obj.HDNX_SOLUONG = dr["HDNX_SOLUONG"].ToString() != "" ? Double.Parse(dr["HDNX_SOLUONG"].ToString()) : 0;
                            obj.HDNX_SONGAYHD = dr["HDNX_SONGAYHD"].ToString() != "" ? Int32.Parse(dr["HDNX_SONGAYHD"].ToString()): 0;
                            obj.HDNX_STT = dr["HDNX_STT"].ToString() != "" ? Int32.Parse(dr["HDNX_STT"].ToString()) : 0;
                            obj.HDNX_TONGBAN = dr["HDNX_TONGBAN"].ToString() != "" ? Decimal.Parse(dr["HDNX_TONGBAN"].ToString()) : 0;
                            obj.HDNX_TONGCHIECKHAU = dr["HDNX_TONGCHIECKHAU"].ToString() != "" ? Decimal.Parse(dr["HDNX_TONGCHIECKHAU"].ToString()) : 0;
                            obj.HDNX_TONGMUA = dr["HDNX_TONGMUA"].ToString() != "" ? Decimal.Parse(dr["HDNX_TONGMUA"].ToString()) : 0;
                            obj.HDNX_TONGVAT = dr["HDNX_TONGVAT"].ToString() != "" ? Decimal.Parse(dr["HDNX_TONGVAT"].ToString()) : 0;
                            obj.HDNX_THANHTIEN = dr["HDNX_THANHTIEN"].ToString() != "" ? Decimal.Parse(dr["HDNX_THANHTIEN"].ToString()) : 0;
                            obj.HDNX_TRAHANG = dr["HDNX_TRAHANG"].ToString() != "" ?Int32.Parse(dr["HDNX_TRAHANG"].ToString()) : 0;
                            obj.HDNX_TRANGTHAI = dr["HDNX_TRANGTHAI"].ToString() != "" ? Int32.Parse(dr["HDNX_TRANGTHAI"].ToString()) : 0;
                            obj.HDNX_VAT = dr["HDNX_VAT"].ToString() != "" ? Double.Parse(dr["HDNX_VAT"].ToString()) : 0;
                            obj.HDTT_MATT = dr["HDTT_MATT"].ToString();
                            obj.HH_MAHANG = dr["HH_MAHANG"].ToString();
                            obj.KH_MAKHO = dr["KH_MAKHO"].ToString();
                            obj.NPP_MANPP = dr["NPP_MANPP"].ToString();
                            obj.NV_MANV = dr["NV_MANV"].ToString();
                            obj.NV_TAIKHOAN = dr["NV_TAIKHOAN"].ToString();
                            objList.Add(obj);
                        }
                    }
                     */
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return dt;
        }
        #endregion

        #region Tiện ích
        public static List<HT_KHOASO> layDanhSachKhoaSo()
        {
            SqlDataReader dr;
            SqlConnection connect;
            List<HT_KHOASO> objList = new List<HT_KHOASO>();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectHtKhoasosAll", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            HT_KHOASO obj = new HT_KHOASO();
                            obj.KS_NGAY = DateTime.Parse(dr["KS_NGAY"].ToString());
                            obj.KS_KHOA = int.Parse(dr["KS_KHOA"].ToString());
                            obj.KS_GHICHU = dr["KS_GHICHU"].ToString();
                            objList.Add(obj);
                        }
                    }
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return objList;
        }

        public static HT_KHOASO selectKhoaSoByDay(DateTime pNgay)
        {
            SqlDataReader dr;
            SqlConnection connect;
            HT_KHOASO obj = new HT_KHOASO();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectHtKhoasoByDay", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.Parameters.AddWithValue("@KS_NGAY", pNgay);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        obj = new HT_KHOASO();
                        while (dr.Read())
                        {
                            obj.KS_NGAY = DateTime.Parse(dr["KS_NGAY"].ToString());
                            obj.KS_KHOA = int.Parse(dr["KS_KHOA"].ToString());
                        }
                    }
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return obj;
        }

        public static void insertKhoaSo(HT_KHOASO pObjKhoaSo)
        {
            SqlConnection connect;
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("InsertHtKhoaso", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.Parameters.AddWithValue("@KS_NGAY", pObjKhoaSo.KS_NGAY);
                    sqlCmd.Parameters.AddWithValue("@KS_KHOA", pObjKhoaSo.KS_KHOA);
                    sqlCmd.Parameters.AddWithValue("@KS_GHICHU", pObjKhoaSo.KS_GHICHU);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.ExecuteNonQuery();
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void updateKhoaSo(HT_KHOASO pObjKhoaSo)
        {
            SqlConnection connect;
            HT_KHOASO obj = new HT_KHOASO();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("UpdateHtKhoaso", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.Parameters.AddWithValue("@KS_NGAY", pObjKhoaSo.KS_NGAY);
                    sqlCmd.Parameters.AddWithValue("@KS_KHOA", pObjKhoaSo.KS_KHOA);
                    sqlCmd.Parameters.AddWithValue("@KS_GHICHU", pObjKhoaSo.KS_GHICHU);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.ExecuteNonQuery();
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region Hệ Thống
        #region Nhật ký
        public static void insertLog(HT_NHATKY objLog)
        {
            SqlConnection connect;
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("InsertHtNhatky", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.Parameters.AddWithValue("@NK_MALOI", objLog.NK_MALOI);
                    sqlCmd.Parameters.AddWithValue("@NK_TENLOI", objLog.NK_TENLOI);
                    sqlCmd.Parameters.AddWithValue("@NK_NOIDUNG", objLog.NK_NOIDUNG);
                    sqlCmd.Parameters.AddWithValue("@NK_TACVU", objLog.NK_TACVU);
                    sqlCmd.Parameters.AddWithValue("@NK_TENMAY", objLog.NK_TENMAY);
                    sqlCmd.Parameters.AddWithValue("@NK_THOIGIAN", objLog.NK_THOIGIAN);
                    sqlCmd.Parameters.AddWithValue("@NV_MANV", objLog.NV_MANV);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.ExecuteNonQuery();
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void deleteLog(HT_NHATKY objLog)
        {
            SqlConnection connect;
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("DeleteHtNhatky", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.Parameters.AddWithValue("@NK_ID", objLog.NK_ID);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.ExecuteNonQuery();
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void deleteAllLog()
        {
            SqlConnection connect;
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("DeleteHtNhatkyAll", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.ExecuteNonQuery();
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public List<HT_NHATKY> selectAllLog()
        {
            SqlDataReader dr;
            List<HT_NHATKY> objList = new List<HT_NHATKY>();
            SqlConnection connect;
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectHtNhatkiesAll", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            HT_NHATKY obj = new HT_NHATKY();
                            obj.NK_MALOI = dr["NK_MALOI"].ToString();
                            obj.NK_NOIDUNG = dr["NK_NOIDUNG"].ToString();
                            obj.NK_TACVU = dr["NK_TACVU"].ToString();
                            obj.NK_TENLOI = dr["NK_TENLOI"].ToString();
                            obj.NK_TENMAY = dr["NK_TENMAY"].ToString();
                            obj.NK_THOIGIAN = DateTime.Parse(dr["NK_THOIGIAN"].ToString());
                            obj.NV_MANV = dr["NV_MANV"].ToString();
                            obj.NK_ID = int.Parse(dr["NK_ID"].ToString());
                            objList.Add(obj);
                        }
                    }
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return objList;
        }
        #endregion

        #region Cấu hình
        public static List<HT_CAUHINH> loadCauHinh()
        {
            SqlDataReader dr;
            SqlConnection connect;
            List<HT_CAUHINH> objList = new List<HT_CAUHINH>();
            try
            {
                using (connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectHtCauhinhsAll", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter();
                    dr = sqlCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            HT_CAUHINH obj = new HT_CAUHINH();
                            obj.CH_TENCH = dr["CH_TENCH"].ToString();
                            obj.CH_GIATRI = dr["CH_GIATRI"].ToString();
                            obj.CH_DIENGIAI = dr["CH_DIENGIAI"].ToString();
                            obj.CH_MACH = dr["CH_MACH"].ToString();
                            objList.Add(obj);
                        }
                    }
                    connect.Close();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return objList;
        }
        #endregion

        public static DataTable layDSNhanVien()
        {
            DataTable dtDVT = new DataTable();
            try
            {
                using (SqlConnection connect = ClassController.ConnectDatabase())
                {
                    connect.Open();
                    SqlCommand sqlCmd = new SqlCommand("SelectDmNhanviensAll", connect);
                    sqlCmd.CommandTimeout = 1000;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlCmd;
                    da.Fill(dtDVT);
                    connect.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return dtDVT;
        }
        #endregion
    }
}
