using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04
{
    public class SinhVien
    {
        public string MaSo { get; set; }
        public string HoTen { get; set; }
        public bool GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string Lop { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string Hinh { get; set; }

        public SinhVien()
        {
            new List<string>();
        }

        public SinhVien(string ms, string ht, bool gt, DateTime ns, string lop, string sdt, string mail, string dc, string hinh)
        {
            this.MaSo = ms;
            this.HoTen = ht;
            this.GioiTinh = gt;
            this.NgaySinh = ns;
            this.Lop = lop;
            this.SDT = sdt;
            this.Email = mail;
            this.DiaChi = dc;
            this.Hinh = hinh;
        }
    }
}
