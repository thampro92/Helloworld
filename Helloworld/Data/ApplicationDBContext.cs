using Helloworld.Models;
using Microsoft.EntityFrameworkCore;

namespace Helloworld.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
            
        }

        public DbSet<Category> categories { get; set; } // DbSet<Category> sẽ đại diện cho bảng Category trong cơ sở dữ liệu

        /**
         * OnModelCreating được sử dụng để cấu hình mô hình dữ liệu, bao gồm việc thiết lập các ràng buộc và dữ liệu khởi tạo.
         * Trong trường hợp này, chúng ta đang thêm một số dữ liệu khởi tạo vào bảng Category.
         */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = "1" },
                new Category { Id = 2, Name = "Adventure", DisplayOrder = "2" },
                new Category { Id = 3, Name = "Comedy", DisplayOrder = "3" }
            );
        }
    }
}
