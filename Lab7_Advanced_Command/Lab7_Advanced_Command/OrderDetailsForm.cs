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
    public partial class OrderDetailsForm : Form
    {
        public OrderDetailsForm()
        {
            InitializeComponent();
        }

        private void LoadBuid()
        {
            string connectionstring = "server=.; database = RestaurantManagement; Integrated Security = true; ";
            SqlConnection sqlConnection = new SqlConnection(connectionstring);
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = "Select * from BillDetails";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            sqlConnection.Open();
            adapter.Fill(dataTable);
            sqlConnection.Close();
            sqlConnection.Dispose();

            dgvBuilDetail.DataSource = dataTable;
            dgvBuilDetail.Columns[0].HeaderText = "STT";
            dgvBuilDetail.Columns[1].HeaderText = "Mã hoá đơn";
            dgvBuilDetail.Columns[2].HeaderText = "Mã món ăn";
            dgvBuilDetail.Columns[3].HeaderText = "Số lượng";
        }

        private void OrderDetailsForm_Load(object sender, EventArgs e)
        {
            LoadBuid();
        }
    }
}
