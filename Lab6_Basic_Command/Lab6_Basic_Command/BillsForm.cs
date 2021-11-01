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

namespace Lab6_Basic_Command
{
    public partial class BillsForm : Form
    {
        public BillsForm()
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

			// Prevent user to edit ID
			dgvHoaDon.Columns[0].ReadOnly = true;

			connection.Close();
		}
	}
}
