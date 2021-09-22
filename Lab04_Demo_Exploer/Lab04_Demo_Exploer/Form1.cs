using Microsoft.VisualBasic.FileIO;
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

namespace Lab04_Demo_Exploer
{
    public partial class frmExplorer : Form
    {
        public frmExplorer()
        {
            InitializeComponent();
        }

        private string ImageKeyDriver(DriveInfo drive)
        {
            string type = "";
            switch (drive.DriveType)
            {
                case DriveType.Fixed:
                    type = "HDD";
                    break;
                case DriveType.CDRom:
                    type = "CD";
                    break;
                case DriveType.Removable:
                    type = "Removable";
                    break;
                case DriveType.Network:
                    type = "Network";
                    break;
                default:
                    type = "HDD";
                    break;
            }
            return type;
        }
        //phương thức load các ổ đĩa
        private void LoadDrive(TreeNode tn)
        {
            TreeNode tnode = new TreeNode();

            foreach (DriveInfo dr in DriveInfo.GetDrives())
            {
                tnode = new TreeNode();
                tnode.Text = dr.Name;
                tnode.Tag = dr.ToString();
                tnode.ImageKey = ImageKeyDriver(dr);
                tnode.ImageKey = ImageKeyDriver(dr);
                tn.Nodes.Add(tnode);
            }
        }
        //Phương thức thêm thư mục vào tnParent
        private void InsertFolder(TreeNode tnParent)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(tnParent.Tag.ToString());
                foreach (DirectoryInfo dircur in dir.GetDirectories())
                {
                    TreeNode tnChild = new TreeNode(dircur.Name, 6, 6);
                    tnChild.Tag = dircur.FullName;
                    tnParent.Nodes.Add(tnChild);
                }
            }
            catch
            { }
        }
        //Phương thức file vào listviewFile của tnParent
        private void InserFile(TreeNode tnParent)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(tnParent.Tag.ToString());
                this.listView1.Items.Clear();
                foreach (FileInfo filecur in dir.GetFiles())
                {
                    ListViewItem lvitem = new ListViewItem(filecur.Name);
                    lvitem.SubItems.Add(filecur.LastWriteTime.ToShortDateString());
                    lvitem.SubItems.Add(filecur.Extension);
                    lvitem.SubItems.Add((filecur.Length / 1024).ToString());
                    this.listView1.Items.Add(lvitem);
                }
                this.toolStripStatusLabel1.Text = "Tổng số Files: " +
              this.listView1.Items.Count;
            }
            catch
            { }
        }
        //Phương thức thêm đĩa hoặc thư mục và file của node tnparent
        private void InsertChildParent(TreeNode tnparent)
        {
            if (tnparent != null)
                if (tnparent.Level == 0)
                {
                    TreeNode tnMyDocuments = new TreeNode("My Documents", 2, 2);
                    tnMyDocuments.Tag = SpecialDirectories.MyDocuments;
                    TreeNode tnMyComputer = new TreeNode("My Computer", 1, 1);
                    tnMyComputer.Tag = "My Computer";
                    tnparent.Nodes.Insert(0, tnMyDocuments);
                    tnparent.Nodes.Insert(1, tnMyComputer);
                }
                else
                if (tnparent.Nodes.Count == 0)
                {
                    if (tnparent.Text == "My Computer")
                    {
                        LoadDrive(tnparent);
                        return;
                    }
                    InsertFolder(tnparent);
                }
            InserFile(tnparent);
        }

        private void frmExplorer_Load(object sender, EventArgs e)
        {
            TreeNode tnode = new TreeNode();
            tnode.Text = "Desktop";
            tnode.Tag = SpecialDirectories.Desktop;
            tnode.ImageKey = "Desktop";
            tnode.SelectedImageKey = "Desktop";
            int root = this.treeViewFolder.Nodes.Add(tnode);
            string name = Application.StartupPath;
            name = name.Substring(0, name.LastIndexOf('\\'));
            name = name.Substring(0, name.LastIndexOf('\\'));
        }

        private void treeViewFolder_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode tnParent = e.Node;
            //tnCurrent = e.Node;
            InsertChildParent(tnParent);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
