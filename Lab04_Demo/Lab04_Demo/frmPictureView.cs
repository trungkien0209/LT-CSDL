using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Lab04_Demo
{
    public partial class frmPictureView : Form
    {
        int count = 0;
        public frmPictureView()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dlg = this.openFileDlg.ShowDialog();
            if (dlg == DialogResult.OK)
            {
                frmPicture frm = new frmPicture(openFileDlg.FileName);
                frm.MdiParent = this;
                count++;
                frm.Text = "Picture -" + count + "-" + openFileDlg.FileName;
                frm.Show();
            }
            this.toolStripStatusLabel1.Text = "Tổng số Form con:" + count.ToString();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dlg = this.saveFileDlg.ShowDialog();
            if (dlg == DialogResult.OK)
            {
                frmPicture frm = this.ActiveMdiChild as frmPicture;

                try
                {
                    Image img = frm.pbHinh.Image;
                    img.Save(saveFileDlg.FileName, ImageFormat.Bmp);
                }
                catch
                {
                    MessageBox.Show("Lỗi lưu file");
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void statusTripToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool check = this.statusTripToolStripMenuItem.Checked;
            if (check)
                this.statusStrip1.Visible = true;
            else
                this.statusStrip1.Visible = false;
        }

        private void toolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool check = this.toolToolStripMenuItem.Checked;
            if (check)
                this.toolStrip1.Visible = true;
            else
                this.toolStrip1.Visible = false;
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void arrangeHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void arrangeVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void maximToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
                frm.WindowState = FormWindowState.Maximized;
        }

        private void minimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
                frm.WindowState = FormWindowState.Minimized;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var frm = ActiveMdiChild as frmPicture;
            frm.zoomToolStripMenuItem.PerformClick();

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var frm = ActiveMdiChild as frmPicture;
            frm.zoomToolStripMenuItem1.PerformClick();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            var frm = ActiveMdiChild as frmPicture;
            frm.editToolStripMenuItem.PerformClick();
        }
    }
}
