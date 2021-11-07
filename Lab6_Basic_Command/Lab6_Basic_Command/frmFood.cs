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
	public partial class frmFood : Form
    {
		int categoryID;
		public frmFood()
        {
            InitializeComponent();
        }

		public void LoadFood(int categoryID)
		{
			this.categoryID = categoryID;
			string connectionString = "server=.; database = RestaurantManagement; Integrated Security = true; ";
			SqlConnection sqlConnection = new SqlConnection(connectionString);

			SqlCommand sqlCommand = sqlConnection.CreateCommand();

			sqlCommand.CommandText = "SELECT Name FROM Category WHERE ID = " + categoryID;

			sqlConnection.Open();

			string catName = sqlCommand.ExecuteScalar().ToString();
			this.Text = "Danh sách các món ăn thuộc nhóm: " + catName;

			sqlCommand.CommandText = "SELECT * FROM Food WHERE FoodCategoryID = " + categoryID;

			SqlDataAdapter da = new SqlDataAdapter(sqlCommand);

			DataTable dt = new DataTable("Food");
			da.Fill(dt);

			dgvFood.DataSource = dt;
			dgvFood.Columns[0].HeaderText = "Mã món ăn";
			dgvFood.Columns[1].HeaderText = "Tên món ăn";
			dgvFood.Columns[2].HeaderText = "Đơn vị";
			dgvFood.Columns[3].HeaderText = "Mã Loại";
			dgvFood.Columns[4].HeaderText = "Giá tiền";
			dgvFood.Columns[5].HeaderText = "Ghi chú";

			sqlConnection.Close();
			sqlConnection.Dispose();
			da.Dispose();
		}

        private void btnSave_Click(object sender, EventArgs e)
        {
		
		}

        private void btnDelete_Click(object sender, EventArgs e)
        {
			if (dgvFood.SelectedRows.Count == 0) return;

			var selectedRow = dgvFood.SelectedRows[0];

			string foodID = selectedRow.Cells[0].Value.ToString();

			string connectionString = "server=.; database = RestaurantManagement; Integrated Security = true; ";
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			SqlCommand sqlCommand = sqlConnection.CreateCommand();

			string query = "DELETE FROM Food WHERE ID = " + foodID;
			sqlCommand.CommandText = query;

			sqlConnection.Open();

			int numOfRowsEffected = sqlCommand.ExecuteNonQuery();

			if (numOfRowsEffected != 1)
			{
				MessageBox.Show("Có lỗi xảy ra.");
				return;
			}

			dgvFood.Rows.Remove(selectedRow);

			sqlConnection.Close();
		}
    }
}
