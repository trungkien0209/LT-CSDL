using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab02_ViDu2
{
    public partial class FormTimKiem : Form
    {
        private QuanLyGiaoVien quanlyGV;
        public FormTimKiem()
        {
            InitializeComponent();
        }

        public FormTimKiem(QuanLyGiaoVien qlgv) : this()
        {
            quanlyGV = qlgv;
        }

        private void rdMaGV_CheckedChanged(object sender, EventArgs e)
        {
            if (rdMaGV.Checked)
            {
                lblTimKiem.Text = rdMaGV.Text;
                txtSearch.Text = "";
            }
        }

        private void rdHoTen_CheckedChanged(object sender, EventArgs e)
        {
            if (rdHoTen.Checked)
            {
                lblTimKiem.Text = rdHoTen.Text;
                txtSearch.Text = "";
            }
        }

        private void rdSoDT_CheckedChanged(object sender, EventArgs e)
        {
            if (rdSoDT.Checked)
            {
                lblTimKiem.Text = rdSoDT.Text;
                txtSearch.Text = "";
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var kieuTim = KieuTim.TheoHoTen;
            if (rdMaGV.Checked)
            {
                kieuTim = KieuTim.TheoMa;
            }
            else if (rdHoTen.Checked)
            {
                kieuTim = KieuTim.TheoHoTen;
            }
            else if (rdSoDT.Checked)
            {
                kieuTim = KieuTim.TheoSDT;
            }

            var ketQua = quanlyGV.Tim(txtSearch.Text, kieuTim);

            if (ketQua is null)
            {
                MessageBox.Show("Không tìm thấy thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                frmTBGiaoVien frm = new frmTBGiaoVien();
                frm.SetText(ketQua.ToString());
                frm.ShowDialog();
            }
        }
    }
}
