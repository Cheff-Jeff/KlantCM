using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CM_API_EF.Data.Migrations
{
    public partial class addbytearray : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "MessageData",
                table: "Messages",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MessageData",
                table: "Messages");
        }
    }
}
