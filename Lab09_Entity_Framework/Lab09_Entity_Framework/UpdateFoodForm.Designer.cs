
namespace Lab09_Entity_Framework
{
    partial class UpdateFoodForm
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.nudFoodPrice = new System.Windows.Forms.NumericUpDown();
            this.cbbFoodCategory = new System.Windows.Forms.ComboBox();
            this.txtFoodNotes = new System.Windows.Forms.TextBox();
            this.txtFoodUnit = new System.Windows.Forms.TextBox();
            this.txtFoodName = new System.Windows.Forms.TextBox();
            this.txtFoodId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudFoodPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(303, 293);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 27;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(404, 293);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 26;
            this.btnCancel.Text = "Thoát";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // nudFoodPrice
            // 
            this.nudFoodPrice.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudFoodPrice.Location = new System.Drawing.Point(117, 167);
            this.nudFoodPrice.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudFoodPrice.Name = "nudFoodPrice";
            this.nudFoodPrice.Size = new System.Drawing.Size(358, 20);
            this.nudFoodPrice.TabIndex = 25;
            this.nudFoodPrice.ThousandsSeparator = true;
            // 
            // cbbFoodCategory
            // 
            this.cbbFoodCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFoodCategory.FormattingEnabled = true;
            this.cbbFoodCategory.Location = new System.Drawing.Point(117, 92);
            this.cbbFoodCategory.Name = "cbbFoodCategory";
            this.cbbFoodCategory.Size = new System.Drawing.Size(358, 21);
            this.cbbFoodCategory.TabIndex = 24;
            // 
            // txtFoodNotes
            // 
            this.txtFoodNotes.Location = new System.Drawing.Point(117, 201);
            this.txtFoodNotes.Multiline = true;
            this.txtFoodNotes.Name = "txtFoodNotes";
            this.txtFoodNotes.Size = new System.Drawing.Size(358, 76);
            this.txtFoodNotes.TabIndex = 23;
            // 
            // txtFoodUnit
            // 
            this.txtFoodUnit.Location = new System.Drawing.Point(117, 129);
            this.txtFoodUnit.Name = "txtFoodUnit";
            this.txtFoodUnit.Size = new System.Drawing.Size(358, 20);
            this.txtFoodUnit.TabIndex = 22;
            // 
            // txtFoodName
            // 
            this.txtFoodName.Location = new System.Drawing.Point(117, 54);
            this.txtFoodName.Name = "txtFoodName";
            this.txtFoodName.Size = new System.Drawing.Size(358, 20);
            this.txtFoodName.TabIndex = 21;
            // 
            // txtFoodId
            // 
            this.txtFoodId.Location = new System.Drawing.Point(117, 17);
            this.txtFoodId.Name = "txtFoodId";
            this.txtFoodId.ReadOnly = true;
            this.txtFoodId.Size = new System.Drawing.Size(100, 20);
            this.txtFoodId.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 204);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Ghi chú khác";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Đơn giá";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Đơn vị tính";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Thuộc danh mục";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Tên món ăn";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Mã số";
            // 
            // UpdateFoodForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(491, 328);
            this.ControlBox = false;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.nudFoodPrice);
            this.Controls.Add(this.cbbFoodCategory);
            this.Controls.Add(this.txtFoodNotes);
            this.Controls.Add(this.txtFoodUnit);
            this.Controls.Add(this.txtFoodName);
            this.Controls.Add(this.txtFoodId);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateFoodForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm/cập nhật món ăn";
            this.Load += new System.EventHandler(this.UpdateFoodForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudFoodPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown nudFoodPrice;
        private System.Windows.Forms.ComboBox cbbFoodCategory;
        private System.Windows.Forms.TextBox txtFoodNotes;
        private System.Windows.Forms.TextBox txtFoodUnit;
        private System.Windows.Forms.TextBox txtFoodName;
        private System.Windows.Forms.TextBox txtFoodId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}