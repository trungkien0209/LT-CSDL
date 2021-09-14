using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03_Demo
{
    public delegate int SoSanh(object sv1, object sv2);
    public class QuanLySinhVien
    {
        public List<SinhVien> DanhSach;
        public QuanLySinhVien()
        {
            DanhSach = new List<SinhVien>();
        }

        public void Them(SinhVien sv, Action tongSo)
        {
            var isExists = DanhSach.Exists(sinhVien => sinhVien.MaSo == sv.MaSo);
            if (isExists)
                throw new ArgumentException("Sinh viên có mã: " + sv.MaSo + " đã tồn tại");
            DanhSach.Add(sv);
            tongSo();
        }

        public SinhVien this[int index]
        {
            get { return DanhSach[index]; }
            set { DanhSach[index] = value; }
        }

        public void Xoa(object obj, SoSanh ss, Action tongSo)
        {
            int i = DanhSach.Count - 1;
            for (; i >= 0; i--)
                if (ss(obj, this[i]) == 0)
                    this.DanhSach.RemoveAt(i);
            tongSo();
        }

        public SinhVien Tim(SinhVien sv) => DanhSach.Find(s => s.MaSo == sv.MaSo);

        public bool Sua(SinhVien svsua, object obj, SoSanh ss)
        {
            int i, count;
            bool kq = false;
            count = this.DanhSach.Count - 1;
            for (i = 0; i < count; i++)
                if (ss(obj, this[i]) == 0)
                {
                    this[i] = svsua;
                    kq = true;
                    break;
                }
            return kq;
        }

        public void DocTuFile(Action tongSo)
        {
            string filename = "DanhSachSV.txt", t;
            string[] s;
            SinhVien sv;
            StreamReader sr = new StreamReader(new FileStream(filename, FileMode.Open));
            while ((t = sr.ReadLine()) != null)
            {
                s = t.Split('\t');
                sv = new SinhVien();
                sv.MaSo = s[0].Trim();
                sv.HoTen = s[1].Trim();
                sv.NgaySinh = DateTime.Parse(s[2].Trim());
                sv.DiaChi = s[3].Trim();
                sv.Lop = s[4].Trim();
                sv.Hinh = s[5].Trim();
                sv.GioiTinh = s[6].Trim() == "1" ? true : false;
                string[] cn = s[7].Trim().Split(',');
                foreach (var c in cn)
                {
                    sv.ChuyenNganh.Add(c.Trim());
                }
                Them(sv, tongSo);
            }
            sr.Close();
        }
    }
}
    

