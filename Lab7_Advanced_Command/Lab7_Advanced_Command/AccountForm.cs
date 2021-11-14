using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab7_Advanced_Command
{
    public partial class AccountForm : Form
    {
        public AccountForm()
        {
            InitializeComponent();
        }

        private void btnLoadAccount_Click(object sender, EventArgs e)
        {
            string connectionString = "server=.; database = RestaurantManagement; Integrated Security = true; ";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();

            command.CommandText = "SELECT * FROM Account";

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable accountable = new DataTable();
            connection.Open();
            adapter.Fill(accountable);
            connection.Close();
            connection.Dispose();

            dgvAccount.DataSource = accountable;
            dgvAccount.Columns[0].HeaderText = "Tên tài khoản";
            dgvAccount.Columns[1].HeaderText = "Mật khẩu";
            dgvAccount.Columns[2].HeaderText = "Họ và tên";
            dgvAccount.Columns[3].HeaderText = "Email";
            dgvAccount.Columns[4].HeaderText = "Số điện thoại";
            dgvAccount.Columns[5].HeaderText = "Ngày tạo";
        }

        private void dgvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvAccount.Rows[e.RowIndex];

                txtName.Text = row.Cells[0].Value.ToString();
                txtPassword.Text = row.Cells[1].Value.ToString();
                txtFullName.Text = row.Cells[2].Value.ToString();
                txtEmail.Text = row.Cells[3].Value.ToString();
                txtCall.Text = row.Cells[4].Value.ToString();
                dtpNgay.Text = row.Cells[5].Value.ToString();

            }
        }
    }
}
