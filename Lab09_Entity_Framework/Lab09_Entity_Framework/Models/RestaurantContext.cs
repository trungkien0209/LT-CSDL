using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab09_Entity_Framework.Models
{
    public class RestaurantContext : DbContext
    {
        //Tham chiếu tới các nhóm món ăn trong bảng Category
        public DbSet<Category> Categories { get; set; }

        //Tham chiếu tới các nhóm món ăn, đồ uống trong bảng food
        public DbSet<Food> Foods { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Xoá bỏ quy tắc sử dụng danh từ số nhiều cho tên bảng
            //Lúc này, thuộc tính Categories ánh xạ tới bảng Category trong database
            //Và thuộc tính Foods tương ứng với bảng food trong csdl
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Food>()
                .HasRequired(x => x.Category)
                .WithMany()
                .HasForeignKey(x => x.FoodCategoryId)
                .WillCascadeOnDelete(true);
        }
    }
}
