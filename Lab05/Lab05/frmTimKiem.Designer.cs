
namespace Lab05
{
    partial class frmTimKiem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.cboLop = new System.Windows.Forms.ComboBox();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.txtMSSV = new System.Windows.Forms.MaskedTextBox();
            this.rdMaSo = new System.Windows.Forms.RadioButton();
            this.rdTen = new System.Windows.Forms.RadioButton();
            this.rdLop = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 1;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(207, 135);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 16;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(48, 135);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiem.TabIndex = 15;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // cboLop
            // 
            this.cboLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLop.Enabled = false;
            this.cboLop.FormattingEnabled = true;
            this.cboLop.Items.AddRange(new object[] {
            "CTK38",
            "CTK39",
            "CTK40",
            "CTK41",
            "CTK42",
            "CTK43"});
            this.cboLop.Location = new System.Drawing.Point(128, 85);
            this.cboLop.Name = "cboLop";
            this.cboLop.Size = new System.Drawing.Size(191, 21);
            this.cboLop.TabIndex = 14;
            // 
            // txtTen
            // 
            this.txtTen.Enabled = false;
            this.txtTen.Location = new System.Drawing.Point(128, 46);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(191, 20);
            this.txtTen.TabIndex = 12;
            // 
            // txtMSSV
            // 
            this.txtMSSV.Enabled = false;
            this.txtMSSV.Location = new System.Drawing.Point(128, 10);
            this.txtMSSV.Mask = "0000000";
            this.txtMSSV.Name = "txtMSSV";
            this.txtMSSV.Size = new System.Drawing.Size(191, 20);
            this.txtMSSV.TabIndex = 10;
            // 
            // rdMaSo
            // 
            this.rdMaSo.AutoSize = true;
            this.rdMaSo.Location = new System.Drawing.Point(30, 13);
            this.rdMaSo.Name = "rdMaSo";
            this.rdMaSo.Size = new System.Drawing.Size(55, 17);
            this.rdMaSo.TabIndex = 17;
            this.rdMaSo.TabStop = true;
            this.rdMaSo.Text = "MSSV";
            this.rdMaSo.UseVisualStyleBackColor = true;
            this.rdMaSo.CheckedChanged += new System.EventHandler(this.rdMaSo_CheckedChanged);
            // 
            // rdTen
            // 
            this.rdTen.AutoSize = true;
            this.rdTen.Location = new System.Drawing.Point(30, 47);
            this.rdTen.Name = "rdTen";
            this.rdTen.Size = new System.Drawing.Size(44, 17);
            this.rdTen.TabIndex = 18;
            this.rdTen.TabStop = true;
            this.rdTen.Text = "Tên";
            this.rdTen.UseVisualStyleBackColor = true;
            this.rdTen.CheckedChanged += new System.EventHandler(this.rdTen_CheckedChanged);
            // 
            // rdLop
            // 
            this.rdLop.AutoSize = true;
            this.rdLop.Location = new System.Drawing.Point(30, 89);
            this.rdLop.Name = "rdLop";
            this.rdLop.Size = new System.Drawing.Size(43, 17);
            this.rdLop.TabIndex = 19;
            this.rdLop.TabStop = true;
            this.rdLop.Text = "Lớp";
            this.rdLop.UseVisualStyleBackColor = true;
            this.rdLop.CheckedChanged += new System.EventHandler(this.rdLop_CheckedChanged);
            // 
            // frmTimKiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 175);
            this.Controls.Add(this.rdLop);
            this.Controls.Add(this.rdTen);
            this.Controls.Add(this.rdMaSo);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.cboLop);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.txtMSSV);
            this.Controls.Add(this.label1);
            this.Name = "frmTimKiem";
            this.Text = "Tìm kiếm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.ComboBox cboLop;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.MaskedTextBox txtMSSV;
        private System.Windows.Forms.RadioButton rdMaSo;
        private System.Windows.Forms.RadioButton rdTen;
        private System.Windows.Forms.RadioButton rdLop;
    }
}