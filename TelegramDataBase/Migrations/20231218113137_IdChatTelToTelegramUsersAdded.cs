using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TelegramDataBase.Migrations
{
    /// <inheritdoc />
    public partial class IdChatTelToTelegramUsersAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "IdChatTel",
                table: "TelegramUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdChatTel",
                table: "TelegramUsers");
        }
    }
}
