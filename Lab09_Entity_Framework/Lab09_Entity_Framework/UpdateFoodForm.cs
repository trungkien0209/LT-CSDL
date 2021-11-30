using Lab09_Entity_Framework.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab09_Entity_Framework
{
    public partial class UpdateFoodForm : Form
    {
		private RestaurantContext _dbContext;
		private int _foodId;

		public UpdateFoodForm(int? foodId = null)
		{
			InitializeComponent();

			_dbContext = new RestaurantContext();
			_foodId = foodId ?? 0;
		}

		private void LoadCategoriesToCombobox()
		{
			//lấy tất cả danh mục thức ăn, sắp theo tên
			var categories = _dbContext.Categories
				.OrderBy(x => x.Name).ToList();
			//nạp danh mục vào cbb và hiển thị nhưng khi dc chọn thì lấy gtrị ID
			cbbFoodCategory.DisplayMember = "Name";
			cbbFoodCategory.ValueMember = "Id";
			cbbFoodCategory.DataSource = categories;
		}

        private void UpdateFoodForm_Load(object sender, EventArgs e)
        {
			//nạp danh sách vào cbb
			LoadCategoriesToCombobox();

			//hiển thị thông tin món ăn lên form
			ShowFoodInformation();
        }

		private Food GetFoodById(int foodId)
		{
			//tìm món ăn theo mã số
			return foodId > 0 ? _dbContext.Foods.Find(foodId) : null;
		}

		private void ShowFoodInformation()
		{
			//tìm món ăn theo ãm đã truyền vào form
			var food = GetFoodById(_foodId);

			//nếu k tìm thấy k cầm làm gì cả
			if (food == null) return;

			//ngược lại hiển thị thông tin lên form
			txtFoodId.Text = food.Id.ToString();
			txtFoodName.Text = food.Name;
			cbbFoodCategory.SelectedValue = food.FoodCategoryId;
			txtFoodUnit.Text = food.Unit;
			nudFoodPrice.Value = food.Price;
			txtFoodNotes.Text = food.Notes;
		}

		private bool ValidateUserInput()
		{
			//ktra tên món ăn dc nhập chưa
			if (string.IsNullOrWhiteSpace(txtFoodName.Text))
			{
				MessageBox.Show("Tên món ăn đồ uống không được để trống", "Thông báo");
				return false;
			}

			//ktra đơn vị tính
			if (string.IsNullOrWhiteSpace(txtFoodUnit.Text))
			{
				MessageBox.Show("Đơn vị tính không được để trống", "Thông báo");
				return false;
			}

			//ktra giá
			if (nudFoodPrice.Value.Equals(0))
			{
				MessageBox.Show("Giá của thức ăn phải lớn hơn 0", "Thông báo");
				return false;
			}

			//ktra nhóm
			if (cbbFoodCategory.SelectedIndex < 0)
			{
				MessageBox.Show("Bạn chưa chọn nhóm thức ăn", "Thông báo");
				return false;
			}

			return true;
		}

		private Food GetUpdatedFood()
		{
			//tạo đtượng food vs thông tin lấy từ các điều khiển trên form
			var food = new Food()
			{
				Name = txtFoodName.Text.Trim(),
				FoodCategoryId = (int)cbbFoodCategory.SelectedValue,
				Unit = txtFoodUnit.Text,
				Price = (int)nudFoodPrice.Value,
				Notes = txtFoodNotes.Text
			};
			//gán gtrị cảu id ban đầu (nếu đang cập nhật)
			if (_foodId > 0)
            {
				food.Id = _foodId;
			}				
			return food;
		}

        private void btnSave_Click(object sender, EventArgs e)
        { 
			//ktra nếu dữ liệu nhập vào alf hợp lệ
			if (ValidateUserInput())
            {
				//thid lấy thông tin người dùng nhập vào
				var newFood = GetUpdatedFood();
				//timd thử đã có trong csdl chưa
				var oldFood = GetFoodById(_foodId);
				//nếu chưa có
				if (oldFood == null)
                {
					//thêm 
					_dbContext.Foods.Add(newFood);
				}		
				else
				{
					//cập nhật
					oldFood.Name = newFood.Name;
					oldFood.FoodCategoryId = newFood.FoodCategoryId;
					oldFood.Unit = newFood.Unit;
					oldFood.Price = newFood.Price;
					oldFood.Notes = newFood.Notes;
				}
			}	
			//lưu xuống csdl
			_dbContext.SaveChanges();
			//đóng
			DialogResult = DialogResult.OK;
		}
    }
}
