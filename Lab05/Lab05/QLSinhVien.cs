using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05
{
    public class QLSinhVien
    {
        private List<SinhVien> DanhSach;

        public QLSinhVien()
        {
            DanhSach = new List<SinhVien>();

        }

        public List<SinhVien> GetAll()
        {
            return DanhSach;
        }


        public SinhVien this[int index]
        {
            get { return DanhSach[index]; }
            set { DanhSach[index] = value; }
        }

        public void Them(SinhVien sv)
        {
            var isExists = DanhSach.Exists(sinhVien => sinhVien.MaSo == sv.MaSo);
            if (isExists)
                throw new ArgumentException("Sinh viên có mã: " + sv.MaSo + " đã tồn tại");
            DanhSach.Add(sv);
        }

        public void Xoa(string MSSV)
        {
            var sinhVien = DanhSach.Find(sv => sv.MaSo == MSSV);
            DanhSach.Remove(sinhVien);
        }

        public void CapNhat(string MSSV, SinhVien sinhVienMoi)
        {
            if (string.IsNullOrWhiteSpace(MSSV))
                throw new ArgumentException($"Mã số sinh viên không hợp lệ!");

            var isExist = DanhSach.Exists(sv => sv.MaSo == MSSV);
            if (!isExist)
                throw new ArgumentException($"Sinh viên có mã số {MSSV} không tồn tại!");

            var index = DanhSach.FindIndex(sv => sv.MaSo == MSSV);
            DanhSach[index] = sinhVienMoi;
        }

        public SinhVien GetByID(string MSSV)
        {
            if (string.IsNullOrWhiteSpace(MSSV))
                throw new ArgumentException($"Tên sinh viên không hợp lệ!");

            SinhVien sv = null;

            sv = DanhSach.Find(s => s.MaSo == MSSV);

            return sv;
        }

        public List<SinhVien> GetByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"Tên sinh viên không hợp lệ!");

            return DanhSach.FindAll(sv => sv.Ten.ToLower() == name.ToLower());
        }

        public List<SinhVien> GetByClassName(string className)
        {
            if (string.IsNullOrWhiteSpace(className))
                throw new ArgumentException($"Lớp không hợp lệ!");

            return DanhSach.FindAll(sv => sv.Lop.ToLower() == className.ToLower());
        }

        public void Write()
        {
            string filename = "DanhSachSV.txt";
            StreamWriter writer = new StreamWriter(new FileStream(filename, FileMode.Create));

            foreach (var sinhVien in DanhSach)
            {
                StringBuilder builder = new StringBuilder();

                string gioiTinh = sinhVien.GioiTinh ? "1" : "0";
                string dsMonHoc = string.Join(",", sinhVien.DanhSachMonHoc);
                if (string.IsNullOrWhiteSpace(dsMonHoc)) dsMonHoc = "null";
                builder.Append($"{sinhVien.MaSo}\t");
                builder.Append($"{sinhVien.HoTenLot}\t");
                builder.Append($"{sinhVien.Ten}\t");
                builder.Append($"{sinhVien.NgaySinh.ToShortDateString()}\t");
                builder.Append($"{sinhVien.Lop}\t");
                builder.Append($"{sinhVien.SoCMND}\t");
                builder.Append($"{sinhVien.SDT}\t");
                builder.Append($"{sinhVien.DiaChi}\t");
                builder.Append($"{gioiTinh}\t");
                builder.Append($"{dsMonHoc}");

                writer.WriteLine(builder.ToString());
            }

            writer.Close();
        }


        public void DocTuFile()
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
                sv.HoTenLot = s[1].Trim();
                sv.Ten = s[2].Trim();
                sv.NgaySinh = DateTime.Parse(s[3].Trim());
                sv.Lop = s[4].Trim();
                sv.SoCMND = s[5].Trim();
                sv.SDT = s[6].Trim();
                sv.DiaChi = s[7].Trim();
                if (s[8] == "1")
                    sv.GioiTinh = true;
                string[] dsdk = s[9].Trim().Split(',');
                foreach (var c in dsdk)
                {
                    sv.DanhSachMonHoc.Add(c.Trim());
                }
                Them(sv);
            }
            sr.Close();
        }
    }
}

