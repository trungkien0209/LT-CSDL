using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Lab04
{
    public partial class frmSinhVien : Form
    {
        QuanLySinhVien qlsv;

        public frmSinhVien()
        {
            InitializeComponent();
        }

        private void RenderListViewItem(SinhVien sv)
        {
            ListViewItem item = new ListViewItem(sv.MaSo);
            item.SubItems.Add(sv.HoTen);
            item.SubItems.Add(sv.GioiTinh ? "Nam" : "Nữ");
            item.SubItems.Add(sv.NgaySinh.ToString("dd/MM/yyyy"));
            item.SubItems.Add(sv.Lop);
            item.SubItems.Add(sv.SDT);
            item.SubItems.Add(sv.Email);
            item.SubItems.Add(sv.DiaChi);
            item.SubItems.Add(sv.Hinh);

            lvSinhVien.Items.Add(item);
        }

        private void RenderListView()
        {
            lvSinhVien.Items.Clear();
            qlsv.DanhSach.ForEach(sv => RenderListViewItem(sv));
        }

        private SinhVien GetSinhVien()
        {
            bool gioiTinh = rdNam.Checked ? true : false;
            string maSo = mtxtMaSo.Text;
            string hoTen = txtHoTen.Text;
            DateTime ngaySinh = dtpNgaySinh.Value;
            string lop = cbbLop.Text;
            string sdt = mtxtSDT.Text;
            string mail = txtMail.Text;
            string diaChi = txtDiaChi.Text;
            string hinh = txtHinh.Text;

            return new SinhVien(maSo, hoTen, gioiTinh, ngaySinh, lop, sdt, mail, diaChi, hinh);
        }

        private SinhVien GetSinhVienOnListViewItem(ListViewItem item)
        {
            string maSo = item.SubItems[0].Text;
            return qlsv.Tim(new SinhVien { MaSo = maSo });
        }

        private void ThietLapThongTin(SinhVien sv)
        {
            mtxtMaSo.Text = sv.MaSo;
            txtHoTen.Text = sv.HoTen;
            if (sv.GioiTinh) rdNam.Checked = true;
            else rdNu.Checked = true;
            dtpNgaySinh.Value = sv.NgaySinh;
            cbbLop.Text = sv.Lop;
            mtxtSDT.Text = sv.SDT;
            txtMail.Text = sv.Email;
            txtDiaChi.Text = sv.DiaChi;
            txtHinh.Text = sv.Hinh;
            pbHinh.ImageLocation = sv.Hinh;

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnChonHinh_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.FileName = "Hãy chọn file";
            dlg.Title = "Open File Image";
            dlg.Filter = "Image Files (*.bmp;*.jpg;*.png)|"
            + "*.bmp;*.jpg;*png|;"
            + "All files (*.*)|*.*";
            dlg.InitialDirectory = Environment.CurrentDirectory;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var fileName = dlg.FileName;
                txtHinh.Text = fileName;
                pbHinh.Load(fileName);
            }
        }

        private void btnMacDinh_Click(object sender, EventArgs e)
        {
            this.mtxtMaSo.Text = "";
            this.txtHoTen.Text = "";
            this.txtMail.Text = "";
            this.dtpNgaySinh.Value = DateTime.Now;
            this.txtDiaChi.Text = "";
            this.cbbLop.Text = this.cbbLop.Items[0].ToString();
            this.txtHinh.Text = "";
            this.pbHinh.ImageLocation = "";
            this.mtxtSDT.Text = "";
            this.rdNam.Checked = true;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            qlsv = new QuanLySinhVien();
            qlsv.DocTuFile();
            RenderListView();
        }

        private int SoSanhTheoMa(object obj1, object obj2)
        {
            SinhVien sv = obj2 as SinhVien;
            return sv.MaSo.CompareTo(obj1);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

            //Sửa
            SinhVien sv = GetSinhVien();
            bool kqsua;
            kqsua = qlsv.Sua(sv, sv.MaSo, SoSanhTheoMa);
            if (kqsua)
            {
                this.RenderListView();
            }

            //Thêm
            try
            {
                SinhVien sinhVien = GetSinhVien();
                qlsv.Them(sinhVien);
                this.RenderListView();
                MessageBox.Show("Đã thêm sinh viên mới!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Đã chỉnh sửa sinh viên có mã số: " + mtxtMaSo.Text, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void lvSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSinhVien.SelectedItems.Count == 0) return;

            var sinhVien = GetSinhVienOnListViewItem(lvSinhVien.SelectedItems[0]);
            ThietLapThongTin(sinhVien);
        }

        private void xoáToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count, i;
            ListViewItem lvitem;
            count = this.lvSinhVien.Items.Count - 1;
            for (i = count; i >= 0; i--)
            {
                lvitem = this.lvSinhVien.Items[i];
                if (lvitem.Checked)
                    qlsv.Xoa(lvitem.SubItems[0].Text, SoSanhTheoMa);
            }
            this.RenderListView();
            this.btnMacDinh.PerformClick();
        }

        private void tảiLạiDanhSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            qlsv = new QuanLySinhVien();
            qlsv.DocTuFile();
            RenderListView();
        }
    }
}
