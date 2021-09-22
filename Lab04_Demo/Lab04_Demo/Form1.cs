using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab04_Demo
{
    public partial class frmPicture : Form
    {
        Point p = new Point();
        bool ctrlKey;

        public frmPicture()
        {
            InitializeComponent();
        }

        public frmPicture(string name)
        {
            InitializeComponent();
            this.pbHinh.ImageLocation = name;
            this.toolStripStatusLabel1.Text = name;
            this.KeyDown += frmPicture_KeyDown;
            this.KeyUp += frmPicture_KeyUp;
        }

        private void frmPicture_Load(object sender, EventArgs e)
        {
            ctrlKey = false;
            p = this.pbHinh.Location;
            this.MouseWheel += frmPicture_MouseWheel;

        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dlg = this.openFileDlg.ShowDialog();
            string title = "";
            if (dlg == DialogResult.OK)
            {
                title =  openFileDlg.FileName;
                this.Text = title;
                this.pbHinh.ImageLocation = openFileDlg.FileName;
            }
        }

        private void zoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pbHinh.Width += 50;
            this.pbHinh.Height += 50;
        }

        private void zoomToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.pbHinh.Width -= 50;
            this.pbHinh.Height -= 50;
        }

        private void vScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            this.pbHinh.Location = new Point(p.X, p.Y - e.NewValue);
        }

        private void hScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            this.pbHinh.Location = new Point(p.X - e.NewValue, p.Y);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("mspaint", this.pbHinh.ImageLocation);
        }


        private void frmPicture_MouseWheel(object sender, MouseEventArgs e)
        {
            bool isGoUp = e.Delta > 0 ? true : false;
            if (ctrlKey)
            {
                if (isGoUp)
                {
                    this.pbHinh.Width += 50;
                    this.pbHinh.Height += 50;
                }
                else
                {
                    this.pbHinh.Width -= 50;
                    this.pbHinh.Height -= 50;
                }
            }
            else
            {
                if (isGoUp && this.vScrollBar.Value > 5)
                {
                    this.vScrollBar.Value -= 5;
                }
                if (!isGoUp && this.vScrollBar.Value < this.vScrollBar.Maximum - 5)
                {
                    this.vScrollBar.Value += 5;
                }

                pbHinh.Location = new Point(p.X, p.Y - this.vScrollBar.Value);
            }
        }

        private void frmPicture_KeyDown(object sender, KeyEventArgs e)
        {
            this.ctrlKey = e.Control;
        }

        private void frmPicture_KeyUp(object sender, KeyEventArgs e)
        {
            this.ctrlKey = e.Control;
        }
    }
}
