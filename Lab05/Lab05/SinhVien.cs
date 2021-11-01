using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05
{

    public class SinhVien
    {
        public string MaSo { get; set; }
        public string HoTenLot { get; set; }
        public string Ten { get; set; }
        public string SoCMND { get; set; }
        public string SDT { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string Lop { get; set; }
        public bool GioiTinh { get; set; }
        public List<string> DanhSachMonHoc { get; set; }

        public SinhVien()
        {
            DanhSachMonHoc = new List<string>();
        }

        public SinhVien(string ms, string ht, string sdt, string cmnd, string ten, DateTime ngay, string dc, string lop, string hinh, bool gt, List<string> dsmh)
        {
            this.MaSo = ms;
            this.HoTenLot = ht;
            this.Ten = ten;
            this.SoCMND = cmnd;
            this.SDT = sdt;
            this.NgaySinh = ngay;
            this.DiaChi = dc;
            this.Lop = lop;
            this.GioiTinh = gt;
            this.DanhSachMonHoc = dsmh;
        }
    }
}
