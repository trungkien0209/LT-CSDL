using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab05
{
    public partial class frmTimKiem : Form
    {
        public string MSSV { get; set; }
        public string Ten { get; set; }
        public string Lop { get; set; }

        bool IsValid { get => rdMaSo.Checked || rdTen.Checked || rdLop.Checked; }
        public frmTimKiem()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void rdMaSo_CheckedChanged(object sender, EventArgs e)
        {
            txtMSSV.Enabled = rdMaSo.Checked;
        }

        private void rdTen_CheckedChanged(object sender, EventArgs e)
        {
            txtTen.Enabled = rdTen.Checked;
        }

        private void rdLop_CheckedChanged(object sender, EventArgs e)
        {
            cboLop.Enabled = rdLop.Checked;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (!IsValid)
            {
                MessageBox.Show("Chọn tiêu chí để tìm kiếm.");
                return;
            }

            if (rdMaSo.Checked) MSSV = txtMSSV.Text;
            if (rdTen.Checked) Ten = txtTen.Text;
            if (rdLop.Checked) Lop = cboLop.Text;

            this.DialogResult = DialogResult.OK;
            Close();

        }
    }
}
