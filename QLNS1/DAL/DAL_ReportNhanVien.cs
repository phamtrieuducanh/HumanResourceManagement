﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAL
{
    public class DAL_ReportNhanVien
    {
        public List<DTO_KhenThuong> ListAllDSKhenThuong()
        {
            List<DTO_KhenThuong> lstBH = new List<DTO_KhenThuong>();
            DataTable data = DataConnection.Instance.ExecuteQuery("select * from DSKhenThuong");
            lstBH.Clear();
            foreach (DataRow item in data.Rows)
            {
                lstBH.Add(new DTO_KhenThuong(item));
            }
            return lstBH;
        }
       

       
        // code hiển thị report 
        public List<DTO_KyLuat> ListAllDSKyLuat()
        {
            List<DTO_KyLuat> lstKL = new List<DTO_KyLuat>();
            DataTable data = DataConnection.Instance.ExecuteQuery("select * from DSKyLuat");
            lstKL.Clear();
            foreach (DataRow item in data.Rows)
            {
                lstKL.Add(new DTO_KyLuat(item));
            }
            return lstKL;
        }
        
        public DataTable GetNhanVienByMaBP(string maBP)
        {
            DataTable dt = DataConnection.Instance.ExecuteQuery($"exec RP_NhanVienByMaBP '{maBP}'");
            return dt;
        }
        public DataTable GetGioiTinh(string gioiTinh)
        {
            DataTable dt = DataConnection.Instance.ExecuteQuery($"select *from NhanVien where GioiTinh like N'%{gioiTinh}%'");

            return dt;
        }
        public DataTable GetHopDong(string ngayBatDau,string ngayKetThuc)
        {
            DataTable dt = DataConnection.Instance.ExecuteQuery($"exec RP_HopDong '{ngayBatDau}','{ngayKetThuc}'");

            return dt;
        }
        public DataTable GetThamNien()
        {
            DataTable dt = DataConnection.Instance.ExecuteQuery("select nv.*,DATEDIFF(year, nv.NgayVaoLam,Getdate()) as ThamNien from NhanVien nv");
            return dt;
        }
    }
}
