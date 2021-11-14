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
    public partial class frmThemNhom : Form
    {
        public frmThemNhom()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string connectionString = "server=.; database = RestaurantManagement; Integrated Security = true; ";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "INSERT INTO Category(Name, [Type])" +
                "VALUES (N'" + txtName.Text + "', " + txtType.Text + ")";

            sqlConnection.Open();

            int numOfRowsEffected = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();
            sqlConnection.Dispose();

            if (numOfRowsEffected > 0)
            {
                MessageBox.Show("Thêm món ăn thành công");
                Close();
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy a vui lòng thử lại");
            }
        }
    }
}
