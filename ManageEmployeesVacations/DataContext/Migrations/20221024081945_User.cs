using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataCon.Migrations
{
    public partial class User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "UserInfo");

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.UserId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user");

            //migrationBuilder.CreateTable(
            //    name: "UserInfo",
            //    columns: table => new
            //    {
            //        CreatedDate = table.Column<DateTime>(type: "datetime(6)", unicode: false, nullable: true),
            //        DisplayName = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true)
            //            .Annotation("MySql:CharSet", "utf8mb4"),
            //        Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
            //            .Annotation("MySql:CharSet", "utf8mb4"),
            //        Password = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
            //            .Annotation("MySql:CharSet", "utf8mb4"),
            //        UserId = table.Column<int>(type: "int", nullable: false),
            //        UserName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
            //            .Annotation("MySql:CharSet", "utf8mb4")
            //    },
            //constraints: table =>
            //{
            //})
            //        .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
