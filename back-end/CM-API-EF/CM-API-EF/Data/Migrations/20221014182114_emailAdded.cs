using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CM_API_EF.Data.Migrations
{
    public partial class emailAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "passwordSalt",
                table: "Users",
                newName: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "passwordSalt");
        }
    }
}
