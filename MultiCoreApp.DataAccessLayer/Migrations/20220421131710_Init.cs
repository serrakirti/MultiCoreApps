using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiCoreApp.DataAccessLayer.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblCustomers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCustomers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblProducts_tblCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "tblCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tblCategories",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("90206461-51c0-4edb-b3f9-c868c788f380"), false, "Defterler" },
                    { new Guid("e9489a7d-d9e2-46c0-afbf-5f06f1316dfd"), false, "Kalemler" }
                });

            migrationBuilder.InsertData(
                table: "tblCustomers",
                columns: new[] { "Id", "Address", "City", "Email", "IsDeleted", "Name", "Phone" },
                values: new object[,]
                {
                    { new Guid("90206461-51c0-4edb-b3f9-c868c788f380"), "Aydinli mah. İstanbul", "İstanbul", "ozan@gmail.com", false, "Ozan BALCI", "0165454" },
                    { new Guid("e9489a7d-d9e2-46c0-afbf-5f06f1316dfd"), "Aydinli mah. İstanbul", "İstanbul", "burcu@gmail.com", false, "Burcu BALCI", "02456546" }
                });

            migrationBuilder.InsertData(
                table: "tblProducts",
                columns: new[] { "Id", "CategoryId", "IsDeleted", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { new Guid("03c93562-2f90-44d8-829a-3c7e07c8badd"), new Guid("90206461-51c0-4edb-b3f9-c868c788f380"), false, "Çizgili Defter", 22.53m, 100 },
                    { new Guid("364eca26-7d5c-46e7-99cd-08d6bde9e9a0"), new Guid("e9489a7d-d9e2-46c0-afbf-5f06f1316dfd"), false, "Tükenmez Kalem", 18.06m, 100 },
                    { new Guid("4688f2bf-95b9-4268-8948-bfea09532ec4"), new Guid("90206461-51c0-4edb-b3f9-c868c788f380"), false, "Karali Defter", 8.06m, 100 },
                    { new Guid("a351e374-cc6f-404c-bbb4-6f927139fd88"), new Guid("e9489a7d-d9e2-46c0-afbf-5f06f1316dfd"), false, "Kursun Kalem", 62.19m, 100 },
                    { new Guid("c9c3498f-54f4-48f0-a23c-a9e3bceb6d79"), new Guid("90206461-51c0-4edb-b3f9-c868c788f380"), false, "Dumduz Defter", 12.19m, 100 },
                    { new Guid("e0b06e03-5c5d-4d30-85bd-0f009aaf063d"), new Guid("e9489a7d-d9e2-46c0-afbf-5f06f1316dfd"), false, "Dolma Kalem", 122.53m, 100 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblProducts_CategoryId",
                table: "tblProducts",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblCustomers");

            migrationBuilder.DropTable(
                name: "tblProducts");

            migrationBuilder.DropTable(
                name: "tblCategories");
        }
    }
}
