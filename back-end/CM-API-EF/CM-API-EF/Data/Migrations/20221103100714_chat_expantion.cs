using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CM_API_EF.Data.Migrations
{
    public partial class chat_expantion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Users_UserID",
                table: "Ratings");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Ratings",
                newName: "RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_UserID",
                table: "Ratings",
                newName: "IX_Ratings_RoomId");

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                    table.ForeignKey(
                        name: "FK_Rooms_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    ChatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.ChatId);
                    table.ForeignKey(
                        name: "FK_Chats_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_Messages_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "ChatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chats_RoomId",
                table: "Chats",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ChatId",
                table: "Messages",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_UserID",
                table: "Rooms",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Rooms_RoomId",
                table: "Ratings",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Rooms_RoomId",
                table: "Ratings");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "Ratings",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_RoomId",
                table: "Ratings",
                newName: "IX_Ratings_UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Users_UserID",
                table: "Ratings",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
