using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04
{
    public delegate int SoSanh(object sv1, object sv2);
    public class QuanLySinhVien
    {
        public List<SinhVien> DanhSach;

        public QuanLySinhVien()
        {
            DanhSach = new List<SinhVien>();
        }

        public SinhVien this[int index]
        {
            get { return DanhSach[index]; }
            set { DanhSach[index] = value; }
        }

        public SinhVien Tim(SinhVien sv) => DanhSach.Find(s => s.MaSo == sv.MaSo);

        public void Them(SinhVien sinhVien)
        {
            var isExists = DanhSach.Exists(sv => sv.MaSo == sinhVien.MaSo);
            if (isExists)
                throw new ArgumentException("Sinh viên có mã: " + sinhVien.MaSo + " đã tồn tại");
            DanhSach.Add(sinhVien);
        }

        public void Xoa(object obj, SoSanh ss)
        {
            int i = DanhSach.Count - 1;
            for (; i >= 0; i--)
                if (ss(obj, this[i]) == 0)
                    this.DanhSach.RemoveAt(i);
        }

        public void DocTuFile()
        {
            string filename = "DSSV.txt", t;
            string[] s;
            SinhVien sv;
            StreamReader reader = new StreamReader(new FileStream(filename, FileMode.Open));
            while ((t = reader.ReadLine()) != null)
            {
                s = t.Split('\t');
                sv = new SinhVien();
                sv.MaSo = s[0].Trim();
                sv.HoTen = s[1].Trim();
                sv.GioiTinh = s[2].Trim() == "1" ? true : false;
                sv.NgaySinh = DateTime.Parse(s[3].Trim());
                sv.Lop = s[4].Trim();
                sv.SDT = s[5].Trim();
                sv.Email = s[6].Trim();
                sv.DiaChi = s[7].Trim();
                sv.Hinh = s[8].Trim();
                Them(sv);
            }
            reader.Close();
        }



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
    }
}
