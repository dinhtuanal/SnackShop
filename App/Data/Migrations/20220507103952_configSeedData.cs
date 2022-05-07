using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class configSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    CategoryName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "ntext", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    SubCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    SubCategoryName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.SubCategoryId);
                    table.ForeignKey(
                        name: "FK_SubCategories_Categories",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId");
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    FoodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Content = table.Column<string>(type: "ntext", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: true),
                    SubCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.FoodId);
                    table.ForeignKey(
                        name: "FK_Foods_SubCategories",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategories",
                        principalColumn: "SubCategoryId");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8D04DCE2-969A-435D-BBA4-DF3F325983DC", "c7c74a7e-b68e-4361-ba77-b3127c6b5907", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "69BD714F-9576-45BA-B5B7-F00649BE00DE", 0, "f0ed6ac7-9897-4075-8114-e8af0aff96b7", "dinhtuanal@gmail.com", true, false, null, "dinhtuanal@gmail.com", "dinhtuanal", "AQAAAAEAACcQAAAAEGsnAV/e17yep7Ru/9h0j9Gc2M2MKxZFfEZEMJW+IRJGfkGij0+K8VD1/2dYbsnJyA==", "0999686888", false, "", false, "dinhtuanal" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description", "Status" },
                values: new object[,]
                {
                    { new Guid("7c318165-4fd6-4fe2-a85c-069b08ae611f"), "Thức ăn nhanh", "Bạn có dùng thức ăn nhanh? Có? Hãy bỏ đi.", 1 },
                    { new Guid("a3896e4f-7a28-4668-8ec1-a133b7adb34c"), "Đồ uống", "Free Ship trong phạm vi 100m", 1 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8D04DCE2-969A-435D-BBA4-DF3F325983DC", "69BD714F-9576-45BA-B5B7-F00649BE00DE" });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "SubCategoryId", "CategoryId", "DateCreated", "Description", "Status", "SubCategoryName" },
                values: new object[,]
                {
                    { new Guid("5f613cd6-2e3c-4390-94f9-a12efb1060ec"), new Guid("7c318165-4fd6-4fe2-a85c-069b08ae611f"), new DateTime(2022, 5, 7, 17, 39, 52, 79, DateTimeKind.Local).AddTicks(4980), "Nhiều dầu mỡ, ăn nhanh ngán, nhưng được cái là nhanh no", 1, "Đồ chiên" },
                    { new Guid("6b43eda0-ca64-43e3-8974-6bd6be93b0b5"), new Guid("7c318165-4fd6-4fe2-a85c-069b08ae611f"), new DateTime(2022, 5, 7, 17, 39, 52, 79, DateTimeKind.Local).AddTicks(5028), "Nướng trên than", 1, "Đồ nướng" },
                    { new Guid("aace8b10-cb22-4aa1-98bd-1f469042c35f"), new Guid("a3896e4f-7a28-4668-8ec1-a133b7adb34c"), new DateTime(2022, 5, 7, 17, 39, 52, 79, DateTimeKind.Local).AddTicks(5064), "Trà + sữa + đường + nước", 1, "Trà sữa" }
                });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "FoodId", "Content", "DateCreated", "Description", "Image", "Name", "Price", "Status", "SubCategoryId" },
                values: new object[,]
                {
                    { new Guid("23a2b688-28f9-404a-bc14-80a6537ceb22"), "Cánh gà nướng BBQ đặc trưng bởi hương vị BBQ và được tẩm ướp cũng các gia vị đậm đà, thịt gà mềm ngọt tạo nên sức hấp dẫn cho sản phẩm.", new DateTime(2022, 5, 7, 17, 39, 52, 79, DateTimeKind.Local).AddTicks(5037), "Giảm giá 2,000đ/xiên trong tuần đầu mở bán (từ 23/11 – 29/11/2020)", "https://www.famima.vn/wp-content/uploads/2020/11/Resize-Website-Pop-s%E1%BA%A3n-ph%E1%BA%A9m-m%E1%BB%9Bi-23.11.2020-1.png", "Xiên Cánh Gà Nướng BBQ", 16000m, 1, new Guid("6b43eda0-ca64-43e3-8974-6bd6be93b0b5") },
                    { new Guid("2555c257-cba5-41cf-80c0-68b0a26dd50a"), "Được chiên bằng dầu thừa", new DateTime(2022, 5, 7, 17, 39, 52, 79, DateTimeKind.Local).AddTicks(5018), "Miễn phí tiền ship nếu mua trực tiếp tại quán", "https://ngonaz.com/wp-content/uploads/2021/09/cach-lam-ca-vien-chien-1.jpg", "Cá viên chiên", 28000m, 1, new Guid("5f613cd6-2e3c-4390-94f9-a12efb1060ec") },
                    { new Guid("8105ae8f-5a99-4fb7-b373-2e787c1fc33f"), "Được chiên bằng dầu thừa", new DateTime(2022, 5, 7, 17, 39, 52, 79, DateTimeKind.Local).AddTicks(5005), "Miễn phí tiền ship nếu mua trực tiếp tại quán", "https://danviet.mediacdn.vn/296231569849192448/2021/12/25/chien-khoai-tay-nho-them-2-buoc-nay-truoc-khi-tha-vao-chao-dau-10-mieng-gion-ca-10-maxresdefault-1639967373-880-width640height360-1640420283090-1640420283223274300555.jpg", "Khoai tây chiên", 17000m, 1, new Guid("5f613cd6-2e3c-4390-94f9-a12efb1060ec") },
                    { new Guid("8b5de02c-0745-42cb-9f22-4112050423b1"), "Nghe tên rất chi là xanh", new DateTime(2022, 5, 7, 17, 39, 52, 79, DateTimeKind.Local).AddTicks(5084), "Miễn phí tiền ship nếu mua trực tiếp tại quán", "http://congthucphache.com/wp-content/uploads/2019/12/thai-xanh.jpg", "Trà sữa thái xanh", 27000m, 1, new Guid("aace8b10-cb22-4aa1-98bd-1f469042c35f") },
                    { new Guid("9709c008-f3da-4cfb-93ba-db4d3a58af61"), "Kem sữa Macchiato, Không chọn Topping, Pudding trứng, Thạch nha đam, Trân châu đen, Trân châu trắng", new DateTime(2022, 5, 7, 17, 39, 52, 79, DateTimeKind.Local).AddTicks(5072), "Miễn phí tiền ship nếu mua trực tiếp tại quán", "https://pozaatea.vn/wp-content/uploads/2021/08/2-1.png", "Trà sữa trân châu đường đen", 25000m, 1, new Guid("aace8b10-cb22-4aa1-98bd-1f469042c35f") },
                    { new Guid("c5e79173-f16e-45a6-9d8e-e94d3b17baed"), "Thịt gà góc tư còn da, cắt thành những miếng nhỏ đều nhau, tẩm ướp cùng xốt nướng yakitori kiểu Nhật trong thời gian dài, giúp cho phần thịt gà được ngấm đều gia vị.Sản phẩm sẽ có độ mềm ngọt của thịt gà, béo béo của phần da gà,đậm đà của xốt ướp,dậy mùi thơm lừng sau khi được nướng trực tiếp.", new DateTime(2022, 5, 7, 17, 39, 52, 79, DateTimeKind.Local).AddTicks(5046), "Miễn phí tiền ship nếu mua trực tiếp tại quán", "https://www.famima.vn/wp-content/uploads/2019/07/POP-15.07.2019-Web.png", "Xiên Đùi Gà Nướng Kiểu Nhật", 19000m, 1, new Guid("6b43eda0-ca64-43e3-8974-6bd6be93b0b5") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_SubCategoryId",
                table: "Foods",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CategoryId",
                table: "SubCategories",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
