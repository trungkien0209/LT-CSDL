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
    public partial class UpdateCategoryForm : Form
    {
        private RestaurantContext _dbContext;
        private int _categoryId;

        public UpdateCategoryForm(int? categoryId = null)
        {
            InitializeComponent();

            _dbContext = new RestaurantContext();
            _categoryId = categoryId ?? 0;
        }

        private Category GetCategoryById(int categoryId)
        {
            //Nếu id dc truyền vaod là hợp lệ, ta tìm thông tin theo id
            //Ngược lại, chỉ đơn giản alf trả về null. cho biết không thấy
            return categoryId > 0 ? _dbContext.Categories.Find(categoryId) : null;
        }

        private void ShowCategory()
        {
            //lấy thông tin của nhóm thức ăn
            var category = GetCategoryById(_categoryId);
            
            //nếu không tìm thấy thông tin, không vần làm gì cả
            if (category == null) return;


            //nếu tìm thấy hiển thị lên form
            txtCategoryId.Text = category.Id.ToString();
            txtCategoryName.Text = category.Name;
            cbbCategoryType.SelectedIndex = (int)category.Type;
        }

        private void UpdateCategoryForm_Load(object sender, EventArgs e)
        {
            //hiển thị thông tin nhóm thức ăn lên form
            ShowCategory();
        }

        private Category GetUpdateCategory()
        {
            //tạo đối tượng category với thông tin đã nhập
            var category = new Category()
            {
                Name = txtCategoryName.Text.Trim(),
                Type = (CategoryType)cbbCategoryType.SelectedIndex
            };
            //gán giá trị của id ban đầu (nếu đang cập nhật)
            if (_categoryId > 0)
            {
                category.Id = _categoryId;
            }    
            return category;
        }

        private bool ValidateUserInput()
        {
            //ktra tên nhóm tức ăn đã dc cập nhật hay chưa
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Tên nhóm thức ăn không được để trống", "Thông báo");
                return false;
            }
            //ktra loại nhóm thức ăn đã dc chọn hay chưa
            if (cbbCategoryType.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn loại nhóm thức ăn", "Thông báo");
                return false;
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //ktra nếu dữ liệu nhập vào là hợp lệ
            if (ValidateUserInput())
            {
                //thì lấy thông tin của ng dùng nhập vào
                var newCategory = GetUpdateCategory();
                 // và thử tìm xem đã có nhóm thức ăn trong csdl chưa
                var oldCategory = GetCategoryById(_categoryId);

                //nếu chưa có
                if (oldCategory == null)
                {
                    //thêm nhóm thức ăn mới
                    _dbContext.Categories.Add(newCategory);
                }
                else
                {
                    //ngược lại cập nhật
                    oldCategory.Name = newCategory.Name;
                    oldCategory.Type = newCategory.Type;
                }
                //lưu xuống csdl
                _dbContext.SaveChanges();
                //đóng
                DialogResult = DialogResult.OK;
            }  
        }
    }
}
