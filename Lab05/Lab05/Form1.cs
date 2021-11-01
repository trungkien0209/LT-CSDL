using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab05
{
    public partial class Form1 : Form
    {
        QLSinhVien qlds;

        public Form1()
        {
            InitializeComponent();
            qlds = new QLSinhVien();
            qlds.DocTuFile();
        }

        private SinhVien GetSinhVien()
        {
            SinhVien sv = new SinhVien();
            bool gt = true;
            List<string> dsmh = new List<string>();
            sv.MaSo = this.mtxtMaSo.Text;
            sv.HoTenLot = this.txtHoLot.Text;
            sv.Ten = this.txtTen.Text;
            sv.NgaySinh = this.dtpNgaySinh.Value;
            sv.Lop = this.cbLop.Text;
            sv.SoCMND = this.mtxtCMND.Text;
            sv.SDT = this.mtxtSDT.Text;
            sv.DiaChi = this.txtDiaChi.Text;
            if (rdNu.Checked)
                gt = false;
            sv.GioiTinh = gt;
            for (int i = 0; i < this.clbMonHoc.Items.Count; i++)
                if (clbMonHoc.GetItemChecked(i))
                    dsmh.Add(clbMonHoc.Items[i].ToString());
            sv.DanhSachMonHoc = dsmh;
            return sv;
        }

        private SinhVien GetSinhVienLV(ListViewItem lvitem)
        {
            SinhVien sv = new SinhVien();
            sv.MaSo = lvitem.SubItems[0].Text;
            sv.HoTenLot = lvitem.SubItems[1].Text;
            sv.Ten = lvitem.SubItems[2].Text;
            sv.NgaySinh = DateTime.Parse(lvitem.SubItems[3].Text);
            sv.Lop = lvitem.SubItems[4].Text;
            sv.SoCMND = lvitem.SubItems[5].Text;
            sv.SDT = lvitem.SubItems[6].Text;
            sv.DiaChi = lvitem.SubItems[7].Text;
            sv.GioiTinh = false;
            if (lvitem.SubItems[8].Text == "Nam")
                sv.GioiTinh = true;
            List<string> dsmh = new List<string>();
            string[] s = lvitem.SubItems[9].Text.Split(',');
            foreach (string t in s)
                dsmh.Add(t);
            sv.DanhSachMonHoc = dsmh;
            return sv;
        }

        private void ThietLapThongTin(SinhVien sv)
        {
            this.mtxtMaSo.Text = sv.MaSo;
            this.txtHoLot.Text = sv.HoTenLot;
            this.txtTen.Text = sv.Ten;
            this.dtpNgaySinh.Value = sv.NgaySinh;
            this.cbLop.Text = sv.Lop;
            this.mtxtCMND.Text = sv.SoCMND;
            this.mtxtSDT.Text = sv.SDT;
            this.txtDiaChi.Text = sv.DiaChi;
            if (sv.GioiTinh)
                this.rdNam.Checked = true;
            else
                this.rdNu.Checked = true;

            for (int i = 0; i < this.clbMonHoc.Items.Count; i++)
                this.clbMonHoc.SetItemChecked(i, false);

            foreach (string s in sv.DanhSachMonHoc)
            {
                for (int i = 0; i < this.clbMonHoc.Items.Count; i++)
                    if (s.CompareTo(this.clbMonHoc.Items[i]) == 0)
                        this.clbMonHoc.SetItemChecked(i, true);
            }
        }

        private void ThemSV(SinhVien sv)
        {
            ListViewItem lvitem = new ListViewItem(sv.MaSo);
            lvitem.SubItems.Add(sv.HoTenLot);
            lvitem.SubItems.Add(sv.Ten);
            lvitem.SubItems.Add(sv.NgaySinh.ToShortDateString());
            lvitem.SubItems.Add(sv.Lop);
            lvitem.SubItems.Add(sv.SoCMND);
            lvitem.SubItems.Add(sv.SDT);
            lvitem.SubItems.Add(sv.DiaChi);
            string gt = "Nữ";
            if (sv.GioiTinh)
                gt = "Nam";
            lvitem.SubItems.Add(gt);
            string cn = "";
            foreach (string s in sv.DanhSachMonHoc)
                cn += s + ",";
            cn = cn.Substring(0, cn.Length - 1);
            lvitem.SubItems.Add(cn);
            this.lvSinhVien.Items.Add(lvitem);
        }

        public ListViewItem createListViewItem(SinhVien sinhVien)
        {
            ListViewItem listViewItem = new ListViewItem(sinhVien.MaSo);
            listViewItem.SubItems.Add(sinhVien.HoTenLot);
            listViewItem.SubItems.Add(sinhVien.Ten);
            listViewItem.SubItems.Add(sinhVien.NgaySinh.ToString("dd/MM/yyyy"));
            listViewItem.SubItems.Add(sinhVien.Lop);
            listViewItem.SubItems.Add(sinhVien.SoCMND);
            listViewItem.SubItems.Add(sinhVien.SDT);
            listViewItem.SubItems.Add(sinhVien.DiaChi);
            listViewItem.SubItems.Add(sinhVien.GioiTinh ? "Nam" : "Nữ");
            listViewItem.SubItems.Add(string.Join(", ", sinhVien.DanhSachMonHoc));

            return listViewItem;
        }

        private void LoadListView(List<SinhVien> dsSinhVien)
        {
            this.lvSinhVien.Items.Clear();
            foreach (var sinhVien in dsSinhVien)
            {
                lvSinhVien.Items.Add(createListViewItem(sinhVien));
            }
        }




        private void txtHoTen_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadListView(qlds.GetAll());
        }

        private void lvSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = this.lvSinhVien.SelectedItems.Count;
            if (count > 0)
            {
                ListViewItem lvitem = this.lvSinhVien.SelectedItems[0];
                SinhVien sv = GetSinhVienLV(lvitem);
                ThietLapThongTin(sv);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                SinhVien sv = GetSinhVien();
                qlds.Them(sv);
                this.LoadListView(qlds.GetAll());
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Mã sinh viên đã tồn tại!", "Lỗi thêm dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

            var result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận thoát", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
                Application.Exit();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult dlg = MessageBox.Show("Lưu thay đổi", "Thoát", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dlg == DialogResult.OK)
            {
                qlds.Write();
                Application.Exit();
            }
            else if (dlg == DialogResult.Cancel)
            {
                Application.Exit();
            }
        }


        public int SoSanhTheoMa(object obj1, object obj2)
        {
            SinhVien sv = obj2 as SinhVien;
            return sv.MaSo.CompareTo(obj1);
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvSinhVien.CheckedIndices.Count == 0)
            {
                MessageBox.Show("Đánh dấu sinh viên cần xóa");
                return;
            }

            foreach (ListViewItem item in lvSinhVien.CheckedItems)
            {
                SinhVien sv = GetSinhVienLV(item);
                qlds.Xoa(sv.MaSo);
            }
            LoadListView(qlds.GetAll());
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                SinhVien sinhVien = GetSinhVien();
                qlds.CapNhat(sinhVien.MaSo, sinhVien);
                LoadListView(qlds.GetAll());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            frmTimKiem frm = new frmTimKiem();
            DialogResult result = frm.ShowDialog();

            if (result != DialogResult.OK) return;

            string mssv = frm.MSSV;
            string ten = frm.Ten;
            string lop = frm.Lop;

            if (!string.IsNullOrWhiteSpace(mssv))
            {
                var sinhVien = qlds.GetByID(mssv);
                if (sinhVien is null)
                {
                    MessageBox.Show($"Không tìm thấy sinh viên có mã số: {mssv}.");
                    return;
                }

                ListViewItem listViewItem = createListViewItem(sinhVien);
                lvSinhVien.Items.Clear();
                lvSinhVien.Items.Add(listViewItem);
                return;
            }

            List<SinhVien> danhSachKetQua = new List<SinhVien>();
            if (!string.IsNullOrWhiteSpace(ten))
            {
                danhSachKetQua = qlds.GetByName(ten);
            }
            if (!string.IsNullOrWhiteSpace(lop))
            {
                danhSachKetQua = qlds.GetByClassName(lop);
            }
            if (danhSachKetQua.Count == 0)
            {
                MessageBox.Show("Không tìm thấy sinh viên.");
                return;
            }
            LoadListView(danhSachKetQua);
        }
    }
}
