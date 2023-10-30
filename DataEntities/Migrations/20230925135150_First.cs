using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataEntities.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Registered Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Course = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registered Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Registered Users",
                columns: new[] { "Id", "Course", "Email", "FirstName", "LastName", "Password", "PhoneNumber" },
                values: new object[] { new Guid("ab3f3c9d-3711-4017-98b4-4f5396b54a4a"), "Asp.net", "daveelvis.369@gmail.com", "David", "Elvis", "See9lu$9lu$", "07823622281" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registered Users");
        }
    }
}
