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
    public partial class OrdersForm : Form
    {
        public OrdersForm()
        {
            InitializeComponent();
			LoadBills();
        }

		public void LoadBills()
		{
			string connectionString = "server=.; database = RestaurantManagement; Integrated Security = true; ";
			SqlConnection connection = new SqlConnection(connectionString);
			SqlCommand command = connection.CreateCommand();

			command.CommandText = "SELECT * FROM Bills";

			connection.Open();

			string categoryName = command.ExecuteScalar().ToString();
			this.Text = "Danh sách toàn bộ hóa đơn";

			SqlDataAdapter adapter = new SqlDataAdapter(command);

			DataTable table = new DataTable("Food");
			adapter.Fill(table);

			dgvHoaDon.DataSource = table;
			dgvHoaDon.Columns[0].HeaderText = "Mã hoá đơn";
			dgvHoaDon.Columns[1].HeaderText = "Tên hoá đơn";
			dgvHoaDon.Columns[2].HeaderText = "Số bàn";
			dgvHoaDon.Columns[3].HeaderText = "Tiền";
			dgvHoaDon.Columns[4].HeaderText = "Chiết khấu";
			dgvHoaDon.Columns[5].HeaderText = "Thuế";
			dgvHoaDon.Columns[6].HeaderText = "Tình trạng";
			dgvHoaDon.Columns[7].HeaderText = "Ngày thanh toán";
			dgvHoaDon.Columns[8].HeaderText = "Tài khoản";


			// Prevent user to edit ID
			dgvHoaDon.Columns[0].ReadOnly = true;

			connection.Close();

		}

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
			OrderDetailsForm frm = new OrderDetailsForm();
			frm.Show();
		}
    }
}
