
namespace Lab7_Advanced_Command
{
    partial class OrderDetailsForm
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
            this.dgvBuilDetail = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuilDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBuilDetail
            // 
            this.dgvBuilDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBuilDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBuilDetail.Location = new System.Drawing.Point(0, 0);
            this.dgvBuilDetail.Margin = new System.Windows.Forms.Padding(2);
            this.dgvBuilDetail.Name = "dgvBuilDetail";
            this.dgvBuilDetail.RowHeadersWidth = 51;
            this.dgvBuilDetail.RowTemplate.Height = 24;
            this.dgvBuilDetail.Size = new System.Drawing.Size(808, 352);
            this.dgvBuilDetail.TabIndex = 2;
            // 
            // OrderDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 352);
            this.Controls.Add(this.dgvBuilDetail);
            this.Name = "OrderDetailsForm";
            this.Text = "OrderDetailsForm";
            this.Load += new System.EventHandler(this.OrderDetailsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuilDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBuilDetail;
    }
}