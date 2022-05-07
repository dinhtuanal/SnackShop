using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SharedObjects.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            #region Category thức ăn nhanh và các bài viết
            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    CategoryId = Guid.Parse("7C318165-4FD6-4FE2-A85C-069B08AE611F"),
                    CategoryName = "Thức ăn nhanh",
                    Description = "Bạn có dùng thức ăn nhanh? Có? Hãy bỏ đi.",
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<SubCategory>().HasData(
                new SubCategory()
                {
                    SubCategoryId = Guid.Parse("5F613CD6-2E3C-4390-94F9-A12EFB1060EC"),
                    SubCategoryName ="Đồ chiên",
                    Description= "Nhiều dầu mỡ, ăn nhanh ngán, nhưng được cái là nhanh no",
                    DateCreated = DateTime.Now,
                    Status = Status.Active,
                    CategoryId = Guid.Parse("7C318165-4FD6-4FE2-A85C-069B08AE611F")
                }    
            );
            modelBuilder.Entity<Food>().HasData(
                new Food()
                {
                    FoodId = Guid.Parse("8105AE8F-5A99-4FB7-B373-2E787C1FC33F"),
                    Name = "Khoai tây chiên",
                    Price = 17000,
                    Image = "https://danviet.mediacdn.vn/296231569849192448/2021/12/25/chien-khoai-tay-nho-them-2-buoc-nay-truoc-khi-tha-vao-chao-dau-10-mieng-gion-ca-10-maxresdefault-1639967373-880-width640height360-1640420283090-1640420283223274300555.jpg",
                    Description = "Miễn phí tiền ship nếu mua trực tiếp tại quán",
                    Content = "Được chiên bằng dầu thừa",
                    Status = Status.Active,
                    DateCreated= DateTime.Now,
                    SubCategoryId = Guid.Parse("5F613CD6-2E3C-4390-94F9-A12EFB1060EC")
                }    
            );
            modelBuilder.Entity<Food>().HasData(
                new Food()
                {
                    FoodId = Guid.Parse("2555C257-CBA5-41CF-80C0-68B0A26DD50A"),
                    Name = "Cá viên chiên",
                    Price = 28000,
                    Image = "https://ngonaz.com/wp-content/uploads/2021/09/cach-lam-ca-vien-chien-1.jpg",
                    Description = "Miễn phí tiền ship nếu mua trực tiếp tại quán",
                    Content = "Được chiên bằng dầu thừa",
                    Status = Status.Active,
                    DateCreated = DateTime.Now,
                    SubCategoryId = Guid.Parse("5F613CD6-2E3C-4390-94F9-A12EFB1060EC")
                }
            );
            modelBuilder.Entity<SubCategory>().HasData(
                new SubCategory()
                {
                    SubCategoryId = Guid.Parse("6B43EDA0-CA64-43E3-8974-6BD6BE93B0B5"),
                    SubCategoryName = "Đồ nướng",
                    Description = "Nướng trên than",
                    DateCreated = DateTime.Now,
                    Status = Status.Active,
                    CategoryId = Guid.Parse("7C318165-4FD6-4FE2-A85C-069B08AE611F")
                }
            );
            modelBuilder.Entity<Food>().HasData(
                new Food()
                {
                    FoodId = Guid.Parse("23A2B688-28F9-404A-BC14-80A6537CEB22"),
                    Name = "Xiên Cánh Gà Nướng BBQ",
                    Price = 16000,
                    Image = "https://www.famima.vn/wp-content/uploads/2020/11/Resize-Website-Pop-s%E1%BA%A3n-ph%E1%BA%A9m-m%E1%BB%9Bi-23.11.2020-1.png",
                    Description = "Giảm giá 2,000đ/xiên trong tuần đầu mở bán (từ 23/11 – 29/11/2020)",
                    Content = "Cánh gà nướng BBQ đặc trưng bởi hương vị BBQ và được tẩm ướp cũng các gia vị đậm đà, thịt gà mềm ngọt tạo nên sức hấp dẫn cho sản phẩm.",
                    Status = Status.Active,
                    DateCreated = DateTime.Now,
                    SubCategoryId = Guid.Parse("6B43EDA0-CA64-43E3-8974-6BD6BE93B0B5")
                }
            );
            modelBuilder.Entity<Food>().HasData(
                new Food()
                {
                    FoodId = Guid.Parse("C5E79173-F16E-45A6-9D8E-E94D3B17BAED"),
                    Name = "Xiên Đùi Gà Nướng Kiểu Nhật",
                    Price = 19000,
                    Image = "https://www.famima.vn/wp-content/uploads/2019/07/POP-15.07.2019-Web.png",
                    Description = "Miễn phí tiền ship nếu mua trực tiếp tại quán",
                    Content = "Thịt gà góc tư còn da, cắt thành những miếng nhỏ đều nhau, tẩm ướp cùng xốt nướng yakitori kiểu Nhật trong thời gian dài, giúp cho phần thịt gà được ngấm đều gia vị.Sản phẩm sẽ có độ mềm ngọt của thịt gà, béo béo của phần da gà,đậm đà của xốt ướp,dậy mùi thơm lừng sau khi được nướng trực tiếp.",
                    Status = Status.Active,
                    DateCreated = DateTime.Now,
                    SubCategoryId = Guid.Parse("6B43EDA0-CA64-43E3-8974-6BD6BE93B0B5")
                }
            );

            #endregion


            #region Category đồ uống
            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    CategoryId = Guid.Parse("A3896E4F-7A28-4668-8EC1-A133B7ADB34C"),
                    CategoryName = "Đồ uống",
                    Description = "Free Ship trong phạm vi 100m",
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<SubCategory>().HasData(
                new SubCategory()
                {
                    SubCategoryId = Guid.Parse("AACE8B10-CB22-4AA1-98BD-1F469042C35F"),
                    SubCategoryName = "Trà sữa",
                    Description = "Trà + sữa + đường + nước",
                    DateCreated = DateTime.Now,
                    Status = Status.Active,
                    CategoryId = Guid.Parse("A3896E4F-7A28-4668-8EC1-A133B7ADB34C")
                }
            );
            modelBuilder.Entity<Food>().HasData(
                new Food()
                {
                    FoodId = Guid.Parse("9709C008-F3DA-4CFB-93BA-DB4D3A58AF61"),
                    Name = "Trà sữa trân châu đường đen",
                    Price = 25000,
                    Image = "https://pozaatea.vn/wp-content/uploads/2021/08/2-1.png",
                    Description = "Miễn phí tiền ship nếu mua trực tiếp tại quán",
                    Content = "Kem sữa Macchiato, Không chọn Topping, Pudding trứng, Thạch nha đam, Trân châu đen, Trân châu trắng",
                    Status = Status.Active,
                    DateCreated = DateTime.Now,
                    SubCategoryId = Guid.Parse("AACE8B10-CB22-4AA1-98BD-1F469042C35F")
                }
            );
            modelBuilder.Entity<Food>().HasData(
                new Food()
                {
                    FoodId = Guid.Parse("8B5DE02C-0745-42CB-9F22-4112050423B1"),
                    Name = "Trà sữa thái xanh",
                    Price = 27000,
                    Image = "http://congthucphache.com/wp-content/uploads/2019/12/thai-xanh.jpg",
                    Description = "Miễn phí tiền ship nếu mua trực tiếp tại quán",
                    Content = "Nghe tên rất chi là xanh",
                    Status = Status.Active,
                    DateCreated = DateTime.Now,
                    SubCategoryId = Guid.Parse("AACE8B10-CB22-4AA1-98BD-1F469042C35F")
                }
            );
            #endregion
            #region tạo tài khoản và quyền
            //Tao quyen admin
            var roleId = "8D04DCE2-969A-435D-BBA4-DF3F325983DC";
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin",
            });
            var userId = "69BD714F-9576-45BA-B5B7-F00649BE00DE";
            var hasher = new PasswordHasher<IdentityUser>();
            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = userId,
                UserName = "dinhtuanal",
                NormalizedUserName = "dinhtuanal",
                Email = "dinhtuanal@gmail.com",
                NormalizedEmail = "dinhtuanal@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Abcd1234$"),
                SecurityStamp = string.Empty,
                PhoneNumber = "0999686888"
            });
            // gan quyen admin cho user
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = roleId,
                UserId = userId,
            });
            #endregion
        }
    }
}
